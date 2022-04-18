using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Hubs;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IHubContext<Chat> _chatHub;
        private readonly MessageOperations _messageOperations;
        private readonly UserOperations _userOperations;
        public ChatController(IHubContext<Chat> chatHub, IDbContextFactory<DietProjectContext> contextFactory)
        {
            _chatHub = chatHub;
            _messageOperations = new MessageOperations(contextFactory);
            _userOperations = new UserOperations(contextFactory);

            //ClaimHelper.SetUserIdentity(User.Identity);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetChatHistory()
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            IList<Message> oldMessages = _messageOperations.GetLastMessagesUser(ClaimHelper.UserID);

            IList<ChatMessage> messages = new List<ChatMessage>();
            foreach (Message message in oldMessages)
            {
                ChatMessage row = new ChatMessage();

                User userData = message.SendedUserID == ClaimHelper.UserID ? _userOperations.Get(x => x.ID == message.ReceiverUserID)
                    : _userOperations.Get(x => x.ID == message.SendedUserID);

                row.FullName = userData.FullName;
                row.Id = userData.ID; // UserID
                row.LastMessage = message.MessageText;
                row.LastMessageDate = message.MessageDate.ToString("dd MMM hh:mm");

                messages.Add(row);
            }


            return Ok(messages);
        }

        [HttpGet("/Chat/GetChatHistory/{id}")]
        public IActionResult GetChatHistory(Int64 Id)
        {
            ClaimHelper.SetUserIdentity(User.Identity);
            IList<Message> oldMessages = _messageOperations.GetLastMessagesUser(ClaimHelper.UserID, Id);

            IList<ChatMessage> messages = new List<ChatMessage>();
            foreach (Message message in oldMessages)
            {
                ChatMessage row = new ChatMessage();

                row.Id = message.ID; //Message ID
                row.LastMessage = message.MessageText;
                row.LastMessageDate = message.MessageDate < DateTime.Today ? message.MessageDate.ToString("dd MM hh:mm") : message.MessageDate.ToString("hh:mm");
                row.IsLeft = message.SendedUserID == Id;

                messages.Add(row);
            }

            User userData = _userOperations.Get(x => x.ID == Id);

            var objectToSerialize = new { Messages = messages, UserData = new { FullName = userData.FullName, UID = userData.ID } };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(objectToSerialize, new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() });

            return Ok(json);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessageUser([FromBody] SocketMessage msgData)
        {
            try
            {
                ClaimHelper.SetUserIdentity(User.Identity);

                Message msg = new Message();
                msg.SendedUserID = ClaimHelper.UserID;
                msg.ReceiverUserID = msgData.UserID;
                msg.MessageText = msgData.Message;
                msg.MessageDate = DateTime.Now;

                bool isScucces = _messageOperations.Add(msg);
                if (!isScucces)
                    return BadRequest();

                ChatMessage row = new ChatMessage();
                row.Id = msg.ID; //Message ID
                row.FullName = _userOperations.Get(x=>x.ID == msg.SendedUserID).FullName;
                row.LastMessage = msg.MessageText;
                row.LastMessageDate = msg.MessageDate < DateTime.Today ? msg.MessageDate.ToString("dd MM hh:mm") : msg.MessageDate.ToString("hh:mm");
                row.IsLeft = msg.SendedUserID != ClaimHelper.UserID;

                await _chatHub.Clients.All.SendAsync("receiveMessage", row);
                //await _chatHub.Clients.User(Chat.AcitveUsers.First(x => x.UserID == msgData.UserID.ToString()).ConID).SendAsync("receiveMessage", ClaimHelper.UserID, msgData.Message);
                return Ok(new { IsSuccess = true });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IActionResult GetActiveUsers()
        {
            return Ok(Chat.AcitveUsers);
        }
    }
}

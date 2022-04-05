using DietProject.Core.DataAccess;
using DietProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
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
                row.Id = userData.ID;
                row.LastMessage = message.MessageText;
                row.LastMessageDate = message.MessageDate.ToString("dd MMM hh:mm");

                messages.Add(row);
            }


            return Ok(messages);
        }

        public IActionResult GetActiveUsers()
        {
            return Ok(Chat.AcitveUsers);
        }
    }
}

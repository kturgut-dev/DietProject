
var connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.None)
    .withUrl("/chatHub").build();
let userList = [];

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

start();


connection.on("receiveMessage", function (senderUserId, message) {
    console.log(message);
});


function SendMessage(msg) {
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
}

function userListFill() {
    axios.get('/Chat/GetChatHistory')
        .then(res => {
            userList = res.data;
            userListAdd();
        })
        .catch(err => {
            console.error(err);
        })

    //$('#userMessageList').each(function (i) {
    //    userList.push($(this).attr('id')); // This is your rel value
    //});
}

function userListAdd() {

    userList.forEach(element => {

        const formatedUser = '<li onclick="clickUserShowMessages(' + element.Id + ')" class="list-group-item px-md-4 py-3 py-md-4 userChatList">' +
            '<a href="javascript:void(0);" class="d-flex">' +
            '<img class="avatar rounded" src="assets/images/xs/avatar6.svg" alt="">' +
            '<div class="flex-fill ms-3 text-truncate">' +
            '<h6 class="d-flex justify-content-between mb-0">' +
            '<span data-content="FullName">' + element.FullName + '</span>' +
            '<small class="msg-time" data-content="LastMessageDate">' + element.LastMessageDate + '</small>' +
            '</h6>' +
            '<span class="text-muted" data-content="LastMessage">' + element.LastMessage + '</span>' +
            '</div>' + '</a>' + '</li>'

        $("#userMessageList").append(formatedUser);

    })

}

function clickUserShowMessages(id) {
    $('#chatHistory').empty()

    axios.get("/chat/GetChatHistory/" + id)
        .then(res => {
            res.data.forEach(element => {
                appendMessages(element)
            })
        })
        .catch(err => {
            console.error(err);
        })

}

function appendMessages(message) {
    var message = '<li class="mb-3 d-flex ' + (message.IsLeft == false ? 'flex-row' : 'flex-row-reverse') + ' align-items-end">' +
        '<div class="max-width-70" >' +
        '<div class="user-info mb-1">' +
        '<img class="avatar sm rounded-circle me-1" src="assets/images/xs/avatar2.svg" alt="avatar">' +
        '<span class="text-muted small">10:10 AM, Today</span>' +
        '</div>' +
        '<div class="card border-0 p-3 ">' +
        '<div class="message"> ' + message.LastMessage + '</div>' +
        '</div></div></li >'

    $("#chatHistory").append(message);
}



function msgSendOnClick() {



    alert("send msg click");
}

userListFill();
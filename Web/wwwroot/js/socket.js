
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
const userList = [];

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

const messageList =
{
    userData: { userID: '', userName: '', msgTime: '' },
    messages: []
};


connection.on("receiveMessage", function (senderUserId, message) {
    console.log(message);
});


function SendMessage(msg) {
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
}

function userListFill() {
    $('#userMessageList').each(function (i) {
        userList.push($(this).attr('id')); // This is your rel value
    });
}

function userListAdd(userList) {
    $("#userMessageList").loadTemplate($("#userTemplate"), userList);
}

//$("#msgSend").click(function () {
//    const msg = $('#msgTxt').dxTextBox('instance').option('value');
//    console.log(msg)

//    alert("send msg click");
//});

function msgSendOnClick() {
    const msg = $('#msgTxt').dxTextBox('instance').option('value');
    console.log(msg)

    alert("send msg click");
}


userListFill();
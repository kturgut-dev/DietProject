
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
    //userList.forEach(element => {
    //    console.log(element)
    $("#userMessageList").loadTemplate($("#userTemplate"), userList);
    //});
}

//$("#msgSend").click(function () {
//    const msg = $('#msgTxt').dxTextBox('instance').option('value');
//    console.log(msg)

//    alert("send msg click");
//});

function msgSendOnClick() {

    //var txt = $("#msgTxt").val();
    //console.log(txt)

    alert("send msg click");
}

userListFill();

var connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.None)
    .withUrl("/chatHub").build();
let userList = [];
let currentMsgList = [];
let selectedUserId = null;

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

connection.on("receivemessage", function (message) {
    currentMsgList.push(message);
    fillMessges();
});


function SendMessage(user, msg) {
    axios.post('/Chat/SendMessageUser', { UserID: user, Message: msg })
        .then(res => {
            //console.log(res)
        })
        .catch(err => {
            console.error(err)
        })

    $("#msgTxt").val('');

    if (chatuId != null)
        userListFill();
    //connection.invoke("sendmessage", user, msg).catch(function (err) {
    //    return console.error(err.toString());
    //});
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

$('#chatSearch').on('input', function () {
    if ($('#chatSearch').val().length > 0)
        $("#userMessageList li").each(function () {
            if ($(this).attr('data-fullName').toLowerCase().indexOf($('#chatSearch').val().toLowerCase()) < 0) {
                $(this).hide();
            } else {
                $(this).show()
            }
        });
    else
        $("#userMessageList li").each(function () {
            $(this).show()
        });
});

function userListAdd() {

    userList.forEach(element => {

        const formatedUser = '<li data-id="' + element.Id + '" data-fullname="' + element.FullName + '" onclick="clickUserShowMessages(' + element.Id + ')" class="list-group-item px-md-4 py-3 py-md-4 userMsgItem">' +
            '<a href="javascript:void(0);" class="d-flex">' +
            //'<img class="avatar rounded" src="assets/images/xs/avatar6.svg" alt="">' +
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

$("#userMessageList").on("click", ".userMsgItem", function (event) {
    $("#userMessageList li").each(function () {
        $(this).removeClass('selectedUser')
    });
    $(this).addClass('selectedUser');
});

function fillMessges() {
    $('#chatHistory').empty();
    //let entries = Object.entries(currentMsgList);
    //let capsEntries = entries.map((entry) => [entry[0][0].toUpperCase() + entry[0].slice(1), entry[1]]);
    //let capsPopulations = Object.fromEntries(capsEntries);
    //console.log(capsPopulations);

    currentMsgList.forEach(element => {
        appendMessages(element);
    })
}

function clickUserShowMessages(id) {
    $('#emptyChat').attr('style', 'display: none !important;');
    $('#chat').attr('style', '');

    selectedUserId = id;

    axios.get("/chat/GetChatHistory/" + id)
        .then(res => {
            currentMsgList = res.data.messages;
            fillMessges();
            $('#userFullName').text(res.data.userData.fullName);
        })
        .catch(err => {
            console.error(err);
        })

}

function appendMessages(message) {
    var message = '<li data-message-id="' + message.iD + '" class="mb-3 d-flex ' + (message.isLeft == true ? 'flex-row' : 'flex-row-reverse') + ' align-items-end">' +
        '<div class="max-width-70" >' +
        '<div class="user-info mb-1">' +
        //'<img class="avatar sm rounded-circle me-1" src="assets/images/xs/avatar2.svg" alt="avatar">' +
        '<span class="text-muted small">' + message.lastMessageDate + '</span>' +
        '</div>' +
        '<div class="card border-0 p-3 ">' +
        '<div class="message">' + message.lastMessage + '</div>' +
        '</div></div></li >'

    $("#chatHistory").append(message);
}

function msgSendOnClick() {
    const msg = $("#msgTxt").val();
    if (selectedUserId != null)
        SendMessage(selectedUserId, msg);
}

userListFill();

const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const chatuId = urlParams.get('uId')

if (chatuId != null) {
    clickUserShowMessages(chatuId);
}

const dateTimePickerSetStart = {
    format: 'd.m.Y',
    lang: 'tr',
    //onChangeDateTime: function (dp, $input) {
    //    var date = $input.val();
    //    console.log(date);
    //    console.log(d.addMonth(1));
    //}
};

let d = new Date();
let today = d.getFullYear() + "/" + (d.getMonth() + 1) + "/" + d.getDate()
//let today = new Date().toLocaleDateString()
console.log(today)
const dateTimePickerSet = {
    format: 'd.m.Y',
    timepicker: false,
    lang: 'tr',
    minDate: '-' + today,
};

$(document).ready(function () {
    console.log("ready!");
    jQuery('#startDate').datetimepicker(dateTimePickerSet);
    jQuery('#endDate').datetimepicker(dateTimePickerSet);

});


$(".closeModal").click((e) => {
    $('#specialOfferModal').modal('hide');
})

$("#sendSpecialOffer").click((e) => {
    $("#CustomerID").val(selectedUserId);
    $('#specialOfferModal').modal('show');
});

$("form").on("submit", function (event) {
    event.preventDefault();
    var serializedData = $(this).serialize();
    axios.post('/Contract', serializedData).then(res => {
        console.log(res)

        Swal.fire({
            title: 'Uyarı',
            html: res.data.Message,
            timer: 3000,
        })

        $('#specialOfferModal').modal('hide');


        if (res.data.IsSuccess) {
            let msg = '<div class="row">'+
            '<div class="col-12>Onayınıza teklif geldi. Detay için <a href="#">tıklayınız.</a></div>' +
                '</div > ';
            SendMessage(selectedUserId, msg);
        }


        $('#startDate').val('');
        $('#endDate').val('');
        $('#priceTxt').val('');
    }).catch(err => {
        console.error(err)
    })
});
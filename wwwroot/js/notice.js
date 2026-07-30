$(document).ready(function () {
    const url = 'https://localhost:7134/hub/dgtal';
    const hub = new signalR.HubConnectionBuilder().withUrl(url).build();
    hub.on('NewContactRequest', function (customerName, mobilePhone) {
        console.log(`Была заполнена заявка обратной связи: ${customerName} ${mobilePhone}`);
        const newNotificationDiv = $('<div>');
        newNotificationDiv.addClass('notification-add-movie');
        newNotificationDiv.text(`Был добавлен свежий проект: ${data}`);
        $('.notification-container-add-movie').append(newNotificationDiv);

        setTimeout(() => {
            newNotificationDiv.hide(500);
        }, 10000);
        newNotificationDiv.click(hideNotificationDiv);
    });
    function hideNotificationDiv() {
        $(this).hide(500)
    };
    hub.start();
});
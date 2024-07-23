var app = app || {};

(function ($) {
    app.notificationDetailModal = {
        show: function (text, isHtml) {
            if (!text) {
                return;
            }

            var notificationModal = $('#NotificationDetailModal');
            if (isHtml) {
                notificationModal.find('.modal-body').html(text);
            } else {
                notificationModal.find('.modal-body').text(text);
            }
            notificationModal.modal('show');
        }
    };
})(jQuery);

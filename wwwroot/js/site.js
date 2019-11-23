$(document).ready(function () {
    validation();
    $(document).on('keyup', function (e) {
        validation();
    });

});


function validation() {
    if ($('.validar').val().length == 0)
        $('.btnSubmit').prop("disabled", true);
    else if ($('.validar').val().length > 0)
        $('.btnSubmit').prop("disabled", false);
}



function NotificaoSucesso(msg) {
    $.notify(
        {
            icon: 'fa fa-check-double',
            message: msg
        },
        {
            element: 'body',
            position: null,
            type: 'success',
            allow_dismiss: true,
            newest_on_top: false,
            offset: {
                x: 20,
                y: 60
            },
            placement: {
                from: "bottom",
                align: "right"
            },
            delay: 5000,
            timer: 1000,
            animate: {
                enter: 'animated fadeInUp',
                exit: 'animated fadeOutDown'
            },
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                '<colgroup><span data-notify="icon" style="margin-right:4px;"></span> ' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '</div>'
        });
}
function NotificaoAviso(msg) {
    $.notify(
        {
            icon: 'fa fa-exclamation-triangle',
            message: msg
        },
        {
            element: 'body',
            position: null,
            type: 'warning',
            allow_dismiss: true,
            newest_on_top: false,
            offset: {
                x: 20,
                y: 60
            },
            placement: {
                from: "bottom",
                align: "right"
            },
            delay: 5000,
            timer: 1000,
            animate: {
                enter: 'animated fadeInUp',
                exit: 'animated fadeOutDown'
            },
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                '<colgroup><span data-notify="icon" style="margin-right:4px;"></span>' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '</div>'
        });
}
function NotificaoErro(msg) {
    $.notify(
        {
            icon: 'fa fa-exclamation-circle',
            message: msg
        },
        {
            element: 'body',
            position: null,
            type: 'danger',
            allow_dismiss: true,
            newest_on_top: false,
            offset: {
                x: 20,
                y: 60
            },
            placement: {
                from: "bottom",
                align: "right"
            },
            delay: 5000,
            timer: 1000,
            animate: {
                enter: 'animated fadeInUp',
                exit: 'animated fadeOutDown'
            },
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0}" role="alert">' +
                '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
                '<colgroup><span data-notify="icon" style="margin-right:4px;"></span> ' +
                '<span data-notify="title">{1}</span> ' +
                '<span data-notify="message">{2}</span>' +
                '</div>'
        });
}

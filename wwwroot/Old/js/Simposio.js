$(document).ready(function () {
    ReadDataTable();
    navegar();
    LoadArquivos();
});
function LoadArquivos() {
    $("#ArquivoBanner").fileinput({
        initialPreview: urlArquivoBanner,
        initialPreviewAsData: true,
        overwriteInitial: true,
        showRemove: false,
        initialCaption: nomeArquivoBanner,
        layoutTemplates: {
            actionDrag: ''
        }
    });
    $("#ArquivoLogo").fileinput({
        initialPreview: urlArquivoLogo,
        initialPreviewAsData: true,
        overwriteInitial: true,
        showRemove: false,
        initialCaption: nomeArquivoLogo,
        layoutTemplates: {
            actionDrag: ''
        }
    });
    $("#ArquivoCertificado").fileinput({
        initialPreview: urlArquivoCertificado,
        initialPreviewAsData: true,
        overwriteInitial: true,
        showRemove: false,
        initialCaption: nomeArquivoCertificado,
        layoutTemplates: {
            actionDrag: ''
        }
    });
};
function navegar() {
    $('.VaiParaSimposio').click(function (e) {
        e.preventDefault();
        $('#tabSimposio a[href="#simposio"]').tab('show');
        $("html, body").animate({ scrollTop: 0 }, 500);
    });
    $('.VaiParaImagens').click(function (e) {
        e.preventDefault();
        $('#tabSimposio a[href="#imagens"]').tab('show');
        $("html, body").animate({ scrollTop: 0 }, 500);
    });
    $('.VaiParaPropositura').click(function (e) {
        e.preventDefault();
        $('#tabSimposio a[href="#propositura"]').tab('show');
        $("html, body").animate({ scrollTop: 0 }, 500);
    });
    $('.VaiParaRegulamento').click(function (e) {
        e.preventDefault();
        $('#tabSimposio a[href="#regulamento"]').tab('show');
        $("html, body").animate({ scrollTop: 0 }, 500);
    });
    $('.VaiParaRegrasAvaliacao').click(function (e) {
        e.preventDefault();
        $('#tabSimposio a[href="#regrasAvaliacao"]').tab('show');
        $("html, body").animate({ scrollTop: 0 }, 500);
    });
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


function ReadDataTable() {
    $('#tbSimposio').DataTable({
        "order": [[0, "desc"]],
        columnDefs: [{
            'targets': [0],
            'visible': false,
            'searchable': false
        }],
        responsive: true,
        language: {
            processing: "Processando...",
            search: "Procurar:",
            lengthMenu: "Mostrar _MENU_ registros",
            info: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrando de 0 até 0 de 0 registros",
            infoFiltered: "(filtrado de _MAX_ registros no total)",
            infoPostFix: "",
            loadingRecords: "Carregando registros...",
            zeroRecords: "Não foi encontrado nenhum resultado",
            emptyTable: "Não há nenhum dado disponível na tabela",
            paginate: {
                first: "Primeiro",
                previous: "Anterior",
                next: "Próximo",
                last: "Último"
            },
            aria: {
                sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
    $('#tbPropositura').DataTable({
        responsive: true,
        initComplete: function () {
            this.api().columns([2, 3]).every(function () {
                var column = this;
                var select = $('<select style="width:100%"><option value=""></option></select>')
                    .appendTo($(column.footer()).empty())
                    .on('change', function () {
                        var val = $.fn.dataTable.util.escapeRegex(
                            $(this).val()
                        );

                        column
                            .search(val ? '^' + val + '$' : '', true, false)
                            .draw();
                    });

                column.data().unique().sort().each(function (d, j) {
                    var val = $('<div/>').html(d).text();
                    select.append('<option value="' + val + '">' + val + '</option>');
                });
            });
        },
        language: {
            processing: "Processando...",
            search: "Procurar:",
            lengthMenu: "Mostrar _MENU_ registros",
            info: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrando de 0 até 0 de 0 registros",
            infoFiltered: "(filtrado de _MAX_ registros no total)",
            infoPostFix: "",
            loadingRecords: "Carregando proposituras...",
            zeroRecords: "Não foi encontrado nenhum resultado",
            emptyTable: "Ainda não há proposituras cadastradas para este simpósio",
            paginate: {
                first: "Primeiro",
                previous: "Anterior",
                next: "Próximo",
                last: "Último"
            },
            aria: {
                sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
    $('#tbEtapa').DataTable({
        responsive: true,
        "columnDefs": [
            { "width": "10%", "targets": 3 }
        ],
        language: {
            processing: "Processando...",
            search: "Procurar:",
            lengthMenu: "Mostrar _MENU_ registros",
            info: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrando de 0 até 0 de 0 registros",
            infoFiltered: "(filtrado de _MAX_ registros no total)",
            infoPostFix: "",
            loadingRecords: "Carregando registros...",
            zeroRecords: "Não foi encontrado nenhum resultado",
            emptyTable: "Não há nenhum dado disponível na tabela",
            paginate: {
                first: "Primeiro",
                previous: "Anterior",
                next: "Próximo",
                last: "Último"
            },
            aria: {
                sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
    $('#tbCategoria').DataTable({
        responsive: true,
        language: {
            processing: "Processando...",
            search: "Procurar:",
            lengthMenu: "Mostrar _MENU_ registros",
            info: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrando de 0 até 0 de 0 registros",
            infoFiltered: "(filtrado de _MAX_ registros no total)",
            infoPostFix: "",
            loadingRecords: "Carregando registros...",
            zeroRecords: "Não foi encontrado nenhum resultado",
            emptyTable: "Não há nenhum dado disponível na tabela",
            paginate: {
                first: "Primeiro",
                previous: "Anterior",
                next: "Próximo",
                last: "Último"
            },
            aria: {
                sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
    $('#tbModalidade').DataTable({
        responsive: true,
        language: {
            processing: "Processando...",
            search: "Procurar:",
            lengthMenu: "Mostrar _MENU_ registros",
            info: "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrando de 0 até 0 de 0 registros",
            infoFiltered: "(filtrado de _MAX_ registros no total)",
            infoPostFix: "",
            loadingRecords: "Carregando registros...",
            zeroRecords: "Não foi encontrado nenhum resultado",
            emptyTable: "Não há nenhum dado disponível na tabela",
            paginate: {
                first: "Primeiro",
                previous: "Anterior",
                next: "Próximo",
                last: "Último"
            },
            aria: {
                sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
  }

// Funções para passar requisições das partial views.
var CriarEtapa = function () {
    $.ajax({
        url: urlCriarEtapa,
        type: 'GET',
        success: function (result) {
            iniciarMasks();
            $('#partialCriarEtapa').html(result);
            $("#CriarEtapa").modal({ backdrop: 'static', keyboard: false });
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};
var EditarEtapa = function (url) {
    $.ajax({
        url: url,
        type: 'GET',
        success: function (result) {
            $('#partialEditarEtapa').html(result);
            $("#ModalEditarEtapa").modal({ backdrop: 'static', keyboard: false });
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};
var CriarCategoria = function () {
    $.ajax({
        url: urlCriarCategoria,
        type: 'GET',
        success: function (result) {
            $('#partialCriarCategoria').html(result);
            $("#ModalCriarCategoria").modal({ backdrop: 'static', keyboard: false });
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};
var EditarCategoria = function (url) {
    $.ajax({
        url: url,
        type: 'GET',
        success: function (result) {
            $('#partialEditarCategoria').html(result);
            $("#ModalEditarCategoria").modal({ backdrop: 'static', keyboard: false });
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};

var CriarModalidade = function () {
    $.ajax({
        url: urlCriarModalidade,
        type: 'GET',
        success: function (result) {
            $('#partialCriarModalidade').html(result);
            $("#ModalCriarModalidade").modal({ backdrop: 'static', keyboard: false });
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};
var EditarModalidade = function (url) {
    $.ajax({
        url: url,
        type: 'GET',
        success: function (result) {
            $('#partialEditarModalidade').html(result);
            $("#ModalEditarModalidade").modal({ backdrop: 'static', keyboard: false });
            iniciarMasks();
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};

function showMessage(strMsg) {

    $("#response").animate({
        height: '+=72px'
    });
    $('<div class="alert alert-danger">' +
        '<button type="button" class="close" data-dismiss="alert">' +
        '&times;</button>' + strMsg + '</div>').hide().appendTo('#response').fadeIn(1000);

    $('select option:contains("Selecione...")').prop('selected', true);

    $(".alert").delay(5000).fadeOut(
        "normal",
        function () {
            $(this).remove();
        });

    $("#response").delay(6000).animate({
        height: '-=72px'
    }, 300);

}

var AdicionarEtapa = function () {
    $.ajaxSetup({ cache: false });
    $.ajax({
        url: urlAdicionarEtapa,
        type: 'POST',
        data: $('#EditarCategoria').serialize(),
        success: function (result) {
            $('.Partialmodal').html(result);
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
    return false;
};
var RemoverEtapa = function (url) {

    var choice = confirm("ATENÇÃO: Ao excluir uma etapa vinculada a categoria, as etapas vinculadas as modalidadades também serão excluídas após clicar em Atualizar.");

    if (choice) {
        $.ajax({
            url: url,
            type: 'POST',
            data: $('#EditarCategoria').serialize(),
            success: function (result) {
                if (result.erro) {
                    console.log("resultado:" + result.erro);
                    console.log("msg:" + result.message);
                    showMessage(result.message);
                }
                else {

                    $(document.body).on('hidden.bs.modal', function () {
                        $('#ModalEditarCategoria').removeData('bs.modal');
                    });
                    $('.Partialmodal').empty();
                    $('.Partialmodal').html(result);
                }
            },
            error: function (xhr, status) {
                alert(status);
            }
        });
    }

};

var AdicionarEtapaCriar = function (url) {
    $.ajax({
        url: url,
        type: 'POST',
        data: $('#CriarCategoria').serialize(),
        success: function (result) {
            $('.PartialmodalCriar').html(result);
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};

var RemoverEtapaCriar = function (url) {
    $.ajax({
        url: url,
        type: 'POST',
        data: $('#CriarCategoria').serialize(),
        success: function (result) {
            $(document.body).on('hidden.bs.modal', function () {
                $('#ModalCriarCategoria').removeData('bs.modal');
            });
            $('.PartialmodalCriar').empty();
            $('.PartialmodalCriar').html(result);
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};
var LoadEtapasCriar = function (url) {
    $.ajax({
        url: url,
        type: 'POST',
        data: $('#CriarModalidade').serialize(),
        success: function (result) {
            $(document.body).on('hidden.bs.modal', function () {
                $('#ModalCriarModalidade').removeData('bs.modal');
            });
            $('.Partialmodal').empty();
            $('.Partialmodal').html(result);
            iniciarMasks();
        },
        error: function (xhr, status) {
            alert(status);
            ReloadForm(xhr);
        }
    });
};
var LoadEtapasEditar = function (url) {
    $.ajax({
        url: url,
        type: 'POST',
        data: $('#EditarModalidade').serialize(),
        success: function (result) {
            $(document.body).on('hidden.bs.modal', function () {
                $('#ModalEditarModalidade').removeData('bs.modal');
            });
            $('.Partialmodal').empty();
            $('.Partialmodal').html(result);
            iniciarMasks();
        },
        error: function (xhr, status) {
            alert(status);
            ReloadForm(xhr);
        }
    });
};

var RejeitarPropositura = function (url) {
    $.ajax({
        url: url,
        type: 'GET',
        success: function (result) {
            $('#partialRejeitar').html(result);
            $("#ModalRejeitar").modal({ backdrop: 'static', keyboard: false });
            iniciarMasks();
        },
        error: function (xhr, status) {
            alert(status);
        }
    });
};
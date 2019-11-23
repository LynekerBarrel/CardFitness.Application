var validationExpressionEmail = /^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
var validationExpressionTelefone = /^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$/;


var maskTelefone = "(99) 9999-9999";
var maskCelular = "(99) 99999-9999";
var maskData = "99/99/9999";
var maskDataHora = "99/99/9999 99:99:99";
var maskCPF = "999.999.999-99";
var maskDinhero = "#.##9,99";

function textCounter(field, field2, maxlimit) {
    var countfield = document.getElementById(field2);
    if (field.value.length > maxlimit) {
        field.value = field.value.substring(0, maxlimit);
        return false;
    } else {
        countfield.innerHTML = "Caracteres Restantes: <b>" + (maxlimit - field.value.length) + "</b>";
    }
}
function ValidarMultipleSelect(id) {

    $('#' + id).removeClass("input-erro");
    $('.' + id).removeClass("input-erro");
    $('#' + id).removeClass("input-sucesso");
    $('.' + id).removeClass("input-sucesso");
    if ($('#' + id).val().length !== 0) {
        inputSucesso($('.' + id));
    }
}

function ChecarDataFim(datafim, datainicio) {
    if (datafim.value < $(datainicio).val()) {
        NotificaoErro("Data final não pode ser menor que a data inicial");
        $(datafim).val("");
        inputErro($(datafim));
    }
}
function ChecarDataInicio(datainicio, datafim) {
    if ($(datafim).val()) {
        if (datainicio.value > $(datafim).val()) {
            NotificaoErro("Data inicial não pode ser maior que a data final");
            $(datainicio).val("");
            inputErro($(datainicio));
        }
    }
}
function ChecarDataFimModal(datafim, datainicio) {
    if (datafim.value < $(datainicio).val()) {
        showMessage("Data final não pode ser menor que a data inicial");
        $(datafim).val("");
        inputErro($(datafim));
    }
}
function ChecarDataInicioModal(datainicio, datafim) {
    if ($(datafim).val()) {
        if (datainicio.value > $(datafim).val()) {
            showMessage("Data inicial não pode ser maior que a data final");
            $(datainicio).val("");
            inputErro($(datainicio));
        }
    }
}

$(document).ready(function () {
    ValidaFormulario();

    $('.confirmar').on("click", function (e) {
        e.preventDefault();

        var choice = confirm($(this).attr('data-confirm'));

        if (choice) {
            window.location.href = $(this).attr('href');
        }
    });

    $(".numero").bind('keyup mouseup', function () {
        var max = parseInt($(this).attr('max'));
        if ($(this).val() > max) {
            $(this).val(max);
        }
    });
});

function ConfirmarOnClick(Msg) {
    var choice = confirm(Msg);

    if (choice) {
        return true;
    }
    else {
        return false;
    }
}
function ValidaFormulario() {
    iniciarMasks();
    inicarCamposValidacao();
}
function inicarCamposValidacao() {
    $('.obrigatorio').blur(function () { validarCampoFormulario(this); });
}
function validarCampoFormulario(campo) {
    var valor = $(campo).val();
    var tipo = $(campo).attr('type');
    var id = $(campo).attr('id');


    if ($(campo).is("select")) {
        if ($("#" + id).prop('multiple')) {
            if ($('#' + id).val().length === 0) {
                inputErro($('.' + id));
            }
            else {
                $('#' + id).removeClass("input-erro");
                $('.' + id).removeClass("input-erro");
                inputSucesso($('.' + id));
            }
        }
        else {
            if ($("#" + id).prop('selectedIndex') == 0) {
                inputErro(campo);
            }
            else {
                inputSucesso(campo);
            }
        }
    }

    if ($(campo).is("textarea")) {
        if (valor === "") {
            inputErro(campo);
        }
        else {
            inputSucesso(campo);
        }
    }
    //Textos, numeros 
    if (tipo === "text" || id === "DescSimposio" || tipo === "datetime-local" || tipo === "date" || tipo === "password") {
        if (valor === "" || valor === null) {
            inputErro(campo);
        }
        else if (valor !== "" || valor !== null) {
            inputSucesso(campo);
        }
    }
    else if (tipo === "number") {
        if (valor === "" || valor === "0" || valor === null) {
            if (id === "CargaHoraria" && valor === "0") {
                inputSucesso(campo);
            }
            else {

                inputErro(campo);
            }
        }
        else if (valor !== 0 || valor !== null) {
            inputSucesso(campo);
        }
    }
    else if (tipo === "email")//Valida Email
    {
        if (validationExpressionEmail.test(valor)) {
            inputSucesso(campo);
        }
        else {
            inputErro(campo);
        }
    }
    //else if (tipo == "tel")//Telefones
    //{
    //    inputSucesso(campo);
    //    //if (valor == "" || valor == null) {
    //    //    inputErro(campo);
    //    //}
    //    //else if (valor != "" || valor != null) {
    //    //    inputSucesso(campo);
    //    //}
    //    //if (validationExpressionTelefone.test(valor) || validationExpressionTelefone.test(valor)) {
    //    //    inputSucesso(campo);
    //    //}
    //    //else {
    //    //    inputErro(campo);
    //    //}
    //}
}
function inputSucesso(campo) {

    var campoId = $(campo).attr('id');
    var label = $(campo).prev().text();
    $(".span" + campoId).remove();

    $(campo).addClass('input-sucesso');
    $(campo).removeClass('input-erro');
}
function inputErro(campo) {
    var campoId = $(campo).attr('id');
    var label = $(campo).prev().text();

    $(".span" + campoId).remove();
    //$("#" + campoId).after("<span class='text-danger span" + campoId + "'>" + label + " obrigatório!</span>");

    $(campo).addClass('input-erro');
    $(campo).removeClass('input-sucesso');
}
function validaForm(btnS) {

    camposValidaDados();

    $('#NomeTrabalho').each(function () {
        if ($(this).val() === primeiroTitulo) {
            var conf = confirm("O nome do arquivo que deseja postar é o mesmo do outro trabalho. Desejar continuar?");
            if (conf === true) {
                inputSucesso(this);
            }
            else {
                inputErro(this);
            }
        }
    });

    if ($('.input-erro').length > 0) {
        $('#dvMensagemErro').removeAttr("style");
        return false;
    }
    else {
        
        $('#dvMensagemErro').css('display', 'none');
        return true;
        //$(btnS).href();
    }
}
function camposValidaDados() {
    $('.obrigatorio').each(function () {
        validarCampoFormulario(this);
    });
}
function iniciarMasks() {

    //$(".telefone").mask(maskTelefone).focusout(function (event) {
    //    var target, phone, element;
    //    target = (event.currentTarget) ? event.currentTarget : event.srcElement;
    //    phone = target.value.replace(/\D/g, '');
    //    element = $(target);
    //    element.unmask();
    //    if (phone.length > 10) {
    //        element.mask(maskCelular);
    //    } else {
    //        element.mask(maskTelefone);
    //    }
    //});
    $(".campoDinheiro").mask(maskDinhero, { reverse: true });
    $(".cep").mask("00000-000");
    $(".campoTelefone").mask("0000-0000");
    $(".campoCelular").mask(maskCelular);
    $(".campoData").mask(maskData);
    $(".campoDataHora").mask(maskDataHora);

    $(".cpf").mask(maskCPF);
}

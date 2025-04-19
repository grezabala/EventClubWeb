
var iNumber = Math.floor(1000 + Math.random() * 9000);

$(document).ready(function () {
    $("#btnSubmit").prop("disabled", true);
    $("#divGenerateRandomValues").html("<input id='txtNewInput' value='" + iNumber + "' disabled />");

    //Validar la cahe
    $("#btnSubmit").click(function (e) {
        e.preventDefault();
        if ($("#textInput").val() != iNumber) {
            $('errCap').text('Invalid Captcha!');

        } else {
            $('.errCap').text('');
            submitForm();
        }
    });

    var wrongInput = function () {

        return $("#textInput").val() != iNumber;
    };

    $("#textInput").bind('input', function () {

        $("#btnSubmit").prop('disabeld', wrongInput);

    });

});


function submitForm() {

    $('#booking_form').validate({
        rules: {
            nombre: { required: true, minlength: 10, maxlength: 250 },
            email: { required: true, email: true },
            asunto: { required: true, minlength: 20, maxlength: 250 },
            mensaje: { required: true, minlength: 50, maxlength: 550 },
            telefono: { required: true, minlength: 10, maxlength: 20, number: true },
            celular: { required: true, minlength: 10, maxlength: 20, number: true }

        },
        mensaje: {
            nombre: { required: "Ingrese su Nombre Completo", minlength: "Mínimo 10 caracteres" },
            email: { required: "Ingrese un Correo Electrónico valido." },
            asunto: { required: "Ingrese el Asunto", minlength: "Mínimo 20 caracteres" },
            mensaje: { required: "Ingrese el Mensajes", minlength: "Mínimo 50 caracteres" },
            telefono: { required: "Ingrese su Número de Telefono", minlength: "Mínimo 10 caracteres" },
            celular: { required: "Ingrese su Número Celular", minlength: "Mínimo 10 caracteres" }

        },
        submitHandler: function (from) {
            $.ajax({
                type: "POST",
                url: "/Home/Contact",
                data: $(form).serialize(),
                success: function (reponse) {
                    $('#sccmodl').modal('show');
                    $('.indxmsg').html(reponse);
                },
                error: function () {
                    alert("Error en el envío del formulario.");
                }

            });

        }
    });

}

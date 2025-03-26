// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

////Codigo para fijar el menus
//$(document).ready(function () {
//    $(document).scroll(function () {
//        var scroll = $(this).scrollTop();
//        var topDist = $(#container).position();
//        if (scroll > topDist.top) {
//            $('nav').css({ "position": "fixed", "top": "0" });

//        }
//        else {
//            $('nav').css({ "position": "static", "top": "auto" })

//        }

//    });

//});

//CODIGO JAVASCRIPT PARA EL MENU RESPONSIVE
function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}


//CODIGO PARA VALIDAR EL EMIAL
//Código para validar el email
function validarEmail(email, div) {
    console.log(email);

    //validar el email
    var caract = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a - zA - Z0 - 9 -]) +\.)+([a-zA-Z0-9]{2,4})+$/);

    if (caract.text(email) == false) {
        $(div).hide().removeClass('hide').slideDown('fast');

        return false;

    } else {
        $(div).hide().addClass('hide').slideDown('slow');
        return true;
    }
}

$('#verPassword').on('mousedown', function () {
    $('#PasswordUser').attr("type", "text");

});

$('#verPassword').on('mouseup mouseleave', function () {
    $('#PasswordUser').attr("type", "PasswordUser");

})
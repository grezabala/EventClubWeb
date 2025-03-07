// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Codigo para fijar el menu
$(document).ready(function () {
    $(document).scroll(function () {
        var scroll = $(this).scrollTop();
        var topDist = $(#container).position();
        if (scroll > topDist.top) {
            $('nav').css({ "position": "fixed", "top": "0" });

        }
        else {
            $('nav').css({ "position": "static", "top": "auto" })

        }

    });

});
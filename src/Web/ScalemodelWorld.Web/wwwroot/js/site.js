// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $("#sidebarCollapse").on("click", function () {
        $("#sidebar").toggleClass("active");
        $(this).toggleClass("active");
    });
});

if (navigator.platform.indexOf('Win') != -1) {
    window.document.getElementById("wrapper").setAttribute("class", "windows");
} else if (navigator.platform.indexOf('Mac') != -1) {
    window.document.getElementById("wrapper").setAttribute("class", "mac");
}
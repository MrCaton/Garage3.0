// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//if (i < 10) {
//    i = "0" + i;

//return i;
//}

//function Time() {
//    var d = new Date();
//    var x = document.getElementById("time");
//    var h = addZero(d.getHours());
//    var m = addZero(d.getMinutes());
//    var s = addZero(d.getSeconds());
//    x.innerHTML = h + ":" + m + ":" + s;
//}

function Time1() {
    var d = new Date();
    document.getElementById("demo").innerHTML = d;
}
function Confirmation() {
    alert("Your car has been parked");
}
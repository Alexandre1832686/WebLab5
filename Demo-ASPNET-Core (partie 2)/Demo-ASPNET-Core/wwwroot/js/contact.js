$(document).ready(function () {
    setTimeout(function () { ChangeTitleColor("blue"); }, 2000);
});

function ChangeTitleColor(color) {
    $("h2").css("color", color);
}

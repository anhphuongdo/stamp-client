function showPopup() {
    var body = document.querySelector("body");
    var overlay = document.getElementById("overlay");
    var popup = document.getElementById("product-info");

    popup.classList.remove("display-none");
    overlay.classList.remove("display-none");
    body.style.overflow = "hidden";

    overlay.addEventListener('click', function () {
        $('#product-info').empty();
        popup.classList.add("display-none");
        overlay.classList.add("display-none");
        body.style.overflow = "auto";
    })
}
function loginRequired() {
    var body = document.querySelector("body");
    var overlay = document.getElementById("overlay");
    var popup = document.getElementById("popup");

    popup.classList.remove("display-none");
    overlay.classList.remove("display-none");
    body.style.overflow = "hidden";

    overlay.addEventListener('click', function () {
        popup.classList.add("display-none");
        overlay.classList.add("display-none");
        body.style.overflow = "auto";
    })
}
function like_action(val) {
    /*var csrfToken = $('input[name="__RequestVerificationToken"]').val();
    var popup = document.getElementById("product-info");
    var body = document.querySelector("body");
    var overlay = document.getElementById("overlay");
    $.ajax({
        type: "POST",
        url: "/Vote/Voting",
        data: {
            id: val,
            __RequestVerificationToken: csrfToken
        },
        success: function (response) {
            popup.classList.add("display-none");
            overlay.classList.add("display-none");
            body.style.overflow = "auto";
            alert("Bạn đã bình chọn cho tác phẩm số " + val + " thành công!")
        },
        error: function (response) {
            alert("Mỗi tác phẩm chỉ được bình chọn 01 lần.")
        }
    });*/
    alert("Thời gian bình chọn cho tác phẩm đã hết");
};

function showInforVoting(val) {
    showPopup();
    $.ajax({
        type: 'GET',
        url: '/Vote/Details',
        data: { id: val },
        success: function (result) {
            $('#product-info').html(result);
        }
    });
}

function showInforRanking(val) {
    showPopup();
    $.ajax({
        type: 'GET',
        url: '/Ranking/Details',
        data: { id: val },
        success: function (result) {
            $('#product-info').html(result);
        }
    });
}
function like_action_ranking(event, val) {
    event.stopPropagation();
    var current = event.currentTarget
    const default_color = current.getAttribute("default-color");
    let current_style = window.getComputedStyle(current);
    var like_number = current.getElementsByClassName("like-number")[0];
    const parent = current.parentElement;
    const name = parent.getElementsByClassName("contest-name");
    if (current_style.backgroundColor === default_color) {
        current.style.backgroundColor = "rgb(66, 133, 244)";
        current.children[1].src = "../image/Ranking/like_bold.svg";
        like_number.style.color = "white";
        like_number.textContent = parseInt(like_number.textContent) + 1;
        if (like_number.textContent < 10) {
            like_number.textContent = like_number.textContent;
        }
        if (name.length > 0) {
            name[0].style.color = "#6EACE3";
        }

        var csrfToken = $('input[name="__RequestVerificationToken"]').val();
        $.ajax({
            type: "POST",
            url: "/Ranking/Voting",
            data: {
                id: val,
                __RequestVerificationToken: csrfToken
            },
            success: function (response) {
                //window.location.reload();
            },
            error: function (response) {
                console.log(response);
            }
        });
    }
};
function like_action(val) {
    var csrfToken = $('input[name="__RequestVerificationToken"]').val();
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
            /*window.location.reload();*/
            alert("Bạn đã bình chọn cho tác phẩm số " + val + " thành công!")
        },
        error: function (response) {
            alert("Mỗi tác phẩm chỉ được bình chọn 01 lần.")
        }
    });
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
/*function update_navbar () {
    var current_url = window.location.href;
    var current_page = current_url.split("/")[3];
    var navbar_items = document.getElementsByClassName("nav-link item");
    var idx;
    if (current_page.includes("News")) {
        idx = 1;
    }
    else if (current_page.includes("About")) {
        idx = 2;
    }
    else if (current_page.includes("Voting")) {
        idx = 3;
    }
    else if (current_page.includes("Ranking")) {
        idx = 4;
    }
    else {
        idx = 0;
    }

    for (let i = 0; i < navbar_items.length; i++) {
        if (i===idx) {
            navbar_items[i].classList.add("blue-color");
        }
        else {
            navbar_items[i].classList.remove("blue-color");
        }
    }
}

update_navbar();*/
var days, hours, minutes, seconds;

var day_e, hour_e, minute_e, second_e;

var compute_interval;

function init_time(deadline_date) {
    day_e = document.getElementById("day");
    hour_e = document.getElementById("hour");
    minute_e = document.getElementById("minute");
    second_e = document.getElementById("second");

    const deadline = new Date(deadline_date).getTime();
    compute_time(deadline);
    compute_interval = setInterval(()=>compute_time(deadline), 1000);
}

function compute_time(deadline) {
    const time_remain = deadline - (new Date().getTime());
    if (time_remain < 0) {
        days = 0;
        hours = 0;
        minutes = 0;
        seconds = 0;
        clearInterval(compute_interval);
    }
    else {
        days = Math.floor(time_remain / (1000 * 60 * 60 * 24));
        hours = Math.floor((time_remain % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        minutes = Math.floor((time_remain % (1000 * 60 * 60)) / (1000 * 60));
        seconds = Math.floor((time_remain % (1000 * 60)) / 1000);
    }
    days = days < 10 ? "0" + days : days;
    hours = hours < 10 ? "0" + hours : hours;
    minutes = minutes < 10 ? "0" + minutes : minutes;
    seconds = seconds < 10 ? "0" + seconds : seconds;

    day_e.innerText = days;
    hour_e.innerText = hours;
    minute_e.innerText = minutes;
    second_e.innerText = seconds;
}

window.addEventListener("load", ()=>{init_time("2023-11-17 23:59")});
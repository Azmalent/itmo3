function addZero(time) {
    return time < 10 ? "0" + time : time;
}

function updateClock() {
    var now = new Date();

    var year = now.getFullYear();
    var month = addZero(now.getMonth() + 1);
    var day = addZero(now.getDate());

    var hours = addZero(now.getHours());
    var minutes = addZero(now.getMinutes());
    var seconds = addZero(now.getSeconds());

    document.getElementById("date_label").innerHTML = day + "." + month + "." + year;
    document.getElementById("time_label").innerHTML = hours + ":" + minutes + ":" + seconds;
    return 0;
}
function startClock() {
    updateClock();
    setInterval(updateClock, 1000);
}
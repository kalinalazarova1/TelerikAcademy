function randomColor() {
    return "rgb(" + Number.parseInt(Math.random() * 256) + "," + Number.parseInt(Math.random() * 256) + "," + Number.parseInt(Math.random() * 256) + ")";
}
function moveDiv(angle, singleDiv) {
    angle = angle + 0.1; //speed 1 radian per second;
    var r = 100,         //radius of circle path
        xCenter = 200,   //x location of circle path centre on screen
        yCenter = 600,   //y location of circle path centre on screen
        x = Math.floor(xCenter + (r * Math.cos(angle))),
        y = Math.floor(yCenter + (r * Math.sin(angle)));
    singleDiv.style.top = x + "px"; //set divs new coordinates
    singleDiv.style.left = y + "px"; //set divs new coordinates

    setTimeout(function () { //repeats the function moveDiv after 100 miliseconds
        moveDiv(angle, singleDiv);
    }, 100);
}

function createMultipleDivs(divCount) {
    var wrapper = document.getElementById("wrapper"),
        i,
        singleDiv;
    for (i = wrapper.firstChild; i !== null; i = wrapper.firstChild) {
        i.parentNode.removeChild(i);
    }
    for (i = 0; i < divCount; i++) {
        singleDiv = document.createElement("div");
        singleDiv.className = "circles";
        singleDiv.style.backgroundColor = randomColor();
        wrapper.appendChild(singleDiv);
        moveDiv(Math.PI * 2 * i / divCount, singleDiv);
    }
}

function enterKeyPressed(event) {
    if (event.keyCode === 13) {
        createMultipleDivs(document.getElementById("count").value);
    }
}

window.onload = function () {
    document.getElementById("count").focus();
};
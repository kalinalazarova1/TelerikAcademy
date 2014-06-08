function randomInRange(start, end) {
    return start + Math.random() * end;
}

function randomColor() {
    return "rgb(" + Math.floor(randomInRange(0, 256)) + "," + Math.floor(randomInRange(0, 256)) + "," + Math.floor(randomInRange(0, 256)) + ")";
}

function createMultipleDivs() {
    var wrapper = document.getElementById("wrapper"),
        i,
        count,
        docFrag,
        singleDiv;
    for (i = wrapper.firstChild; i !== null; i = wrapper.firstChild) {
        i.parentNode.removeChild(i);
    }
    count = Number(document.getElementById("count").value);
    docFrag = document.createDocumentFragment();
    for (i = 0; i < count; i++) {
        singleDiv = document.createElement("div");
        singleDiv.style.width = randomInRange(20, 100) + "px";
        singleDiv.style.height = randomInRange(20, 100) + "px";
        singleDiv.style.backgroundColor = randomColor();
        singleDiv.style.color = randomColor();
        singleDiv.style.borderRadius = randomInRange(1, 20) + "px";
        singleDiv.style.borderColor = randomColor();
        singleDiv.style.position = "absolute";
        singleDiv.style.left = Number.parseInt(randomInRange(10, 1000)) + "px";
        singleDiv.style.top = Number.parseInt(randomInRange(10, 500)) + "px";
        singleDiv.style.borderWidth = randomInRange(1, 20) + "px";
        singleDiv.innerHTML = "<strong>DIV</strong>";
        docFrag.appendChild(singleDiv);
    }
    wrapper.appendChild(docFrag);
}

function enterKeyPressed(event) {
    if (event.keyCode === 13) {
        createMultipleDivs();
    }
}

window.onload = function () {
    document.getElementById("count").focus();
};

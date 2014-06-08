function createTextarea() {             //returns new textarea if not present or returns the first of the existing
    var tArea = document.getElementsByTagName("textarea")[0];
    if (tArea === undefined) {
        tArea = document.createElement("textarea");
        tArea.style.fontSize = "18px";
        tArea.style.fontWeight = "bold";
        tArea.rows = 20;
        tArea.style.width = "500px";
        tArea.innerHTML = "Sample text";
        document.body.appendChild(tArea);
    }
    return tArea;
}

function changeBackground(element) {
    element.style.backgroundColor = document.getElementById("background").value;
}

function changeFontColor(element) {
    element.style.color = document.getElementById("font").value;
}

window.onload = function () {
    document.getElementById("font").focus();
};
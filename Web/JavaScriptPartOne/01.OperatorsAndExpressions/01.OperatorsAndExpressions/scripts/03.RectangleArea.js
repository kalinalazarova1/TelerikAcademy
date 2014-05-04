//Write an expression that calculates rectangle’s area by given width and height.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function rectangleArea() {
    var width = jsConsole.readFloat("input#number-input1"),
        height = jsConsole.readFloat("input#number-input2");
    if (!width || !height || width <= 0 || height <= 0) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else {
        jsConsole.writeLine("The area of the rectangle is: " + width * height);
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            rectangleArea();
        }
    }
}
//Write an expression that calculates trapezoid's area by given sides a and b and height h.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function trapezoidArea() {
    var a = jsConsole.readFloat("input#number-input1"),
        b = jsConsole.readFloat("input#number-input2"),
        h = jsConsole.readFloat("input#number-input3");
    if (!a || !b || !h || a <= 0 || b <= 0 || h <= 0) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else {
        jsConsole.writeLine("The area of the trapezoid is: " + ((a + b) * h) / 2);
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else if (document.activeElement === document.getElementById("number-input2")) {
            document.getElementById("number-input3").focus();
        } else {
            trapezoidArea();
        }
    }
}
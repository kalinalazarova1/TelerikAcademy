//Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function pointInCircle() {
    var x = jsConsole.readFloat("input#number-input1"),
        y = jsConsole.readFloat("input#number-input2"),
        radius = 0;
    if ((!x && x !== 0) || (!y && y !== 0)) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else {
        radius = Math.sqrt(x * x + y * y);
        jsConsole.writeLine("The point (" + x + ", " + y + ") is " + (radius <= 5 ? "in" : "out of") + " the circle.");
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            pointInCircle();
        }
    }
}
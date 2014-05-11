// Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3)
//and out of the rectangle R(top=1, left=-1, width=6, height=2).

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function pointInCircleOutRectangle() {
    var x = jsConsole.readFloat("input#number-input1"),
        y = jsConsole.readFloat("input#number-input2"),
        inCircle,
        outRectangle;
    if ((!x && x !== 0) || (!y && y !== 0)) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else {
        inCircle = (Math.sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) - 3) <= 0;
        outRectangle = (x < -1) || (x > 5) || (y < -1) || (y > 1);
        jsConsole.writeLine("The point (" + x + ", " + y + ") is " + (inCircle ? "in" : "out of") + " the circle and " + (outRectangle ? "out of" : "in") + " the rectangle.");
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            pointInCircleOutRectangle();
        }
    }
}
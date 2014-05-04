// Write a script that enters the coefficients a, b and c of a quadratic equation
// a*x2 + b*x + c = 0
// and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function solveQuadEquation() {
    var a = jsConsole.readFloat("input#number-input1"),
        b = jsConsole.readFloat("input#number-input2"),
        c = jsConsole.readFloat("input#number-input3"),
        d;
    if ((!a && a !== 0) || (!b && b !== 0) || (!c && c !== 0)) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else {
        d = b * b - 4 * a * c;
        if (d < 0) {
            jsConsole.writeLine("The equation has no real roots.");
        } else if (d === 0) {
            jsConsole.writeLine("The equation has one real root: " + -b / (2 * a));
        } else {
            jsConsole.writeLine("The equation has two real roots: " + (-b + Math.sqrt(d)) / (2 * a) + ", " + (-b - Math.sqrt(d)) / (2 * a));
        }
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else if (document.activeElement === document.getElementById("number-input2")) {
            document.getElementById("number-input3").focus();
        } else {
            solveQuadEquation();
        }
    }
}
//Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function thirdBitCheck() {
    var number = jsConsole.readInteger("input");
    if (!number && number !== 0) {
        jsConsole.writeLine("The entered number is not valid.");
    } else {
        jsConsole.writeLine("The bit 3 of " + number + " is: " + ((number >> 3) & 1));
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        thirdBitCheck();
    }
}
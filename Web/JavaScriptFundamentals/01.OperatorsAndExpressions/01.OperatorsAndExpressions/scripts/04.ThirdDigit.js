//Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function thirdDigitCheck() {
    var number = jsConsole.readInteger("input");
    if (!number || number < 100) {
        jsConsole.writeLine("The entered number is not valid.");
    } else {
        jsConsole.writeLine("The third digit of " + number + " is: " + Number.parseInt((number / 100) % 10));
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        thirdDigitCheck();
    }
}
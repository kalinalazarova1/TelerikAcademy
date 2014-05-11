// Write a boolean expression that checks for given integer if it can be divided
//(without remainder) by 7 and 5 in the same time.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function divideByFiveAndSeven() {
    var number = jsConsole.readInteger("input");
    if (!number && number !== 0) {
        jsConsole.writeLine("The entered number is not valid.");
    } else {
        jsConsole.writeLine("The number " + number + " could" + (number % 35 ? " not " : " ") + "be divided by 5 and 7 at the same time.");
    }
}

function enterKeyPressed(event) {
    if (event.keyCode === 13) {
        divideByFiveAndSeven();
    }
}
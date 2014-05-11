// Write script that asks for a digit and depending on the input shows the name of that digit
//(in English) using a switch statement.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function englishDigit() {
    var number = jsConsole.readInteger("input");
    if ((!number && number !== 0) || number < 0 || number > 10) {
        jsConsole.writeLine("The entered digit is not valid.");
    } else {
        switch (number) {
        case 0:
            jsConsole.writeLine("zero");
            break;
        case 1:
            jsConsole.writeLine("one");
            break;
        case 2:
            jsConsole.writeLine("two");
            break;
        case 3:
            jsConsole.writeLine("three");
            break;
        case 4:
            jsConsole.writeLine("four");
            break;
        case 5:
            jsConsole.writeLine("five");
            break;
        case 6:
            jsConsole.writeLine("six");
            break;
        case 7:
            jsConsole.writeLine("seven");
            break;
        case 8:
            jsConsole.writeLine("eight");
            break;
        case 9:
            jsConsole.writeLine("nine");
            break;
        default:
            jsConsole.writeLine("The entered digit is not valid.");
            break;
        }
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        englishDigit();
    }
}
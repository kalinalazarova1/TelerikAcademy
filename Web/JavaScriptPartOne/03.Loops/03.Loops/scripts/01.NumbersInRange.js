// 1.Write a script that prints all the numbers from 1 to N

window.onload = function () {
    document.getElementById("number-input").focus();
};

function numbersInRange() {
    var number = jsConsole.readInteger("input"),
        i;
    if (!number && number !== 0) {
        jsConsole.writeLine("The entered number is not valid");
    } else {
        for (i = 0; i < number; i++) {
            if (i !== number - 1) {
                jsConsole.write((i + 1) + ", ");
            } else {
                jsConsole.writeLine(i + 1);
            }
        }
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        numbersInRange();
    }
}
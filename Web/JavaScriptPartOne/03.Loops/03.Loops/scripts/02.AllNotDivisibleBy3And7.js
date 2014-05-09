// 2.Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time

window.onload = function () {
    document.getElementById("number-input").focus();
};

function numbersNotDivisibleBy21() {
    var number = jsConsole.readInteger("input"),
        i;
    if (!number && number !== 0) {
        jsConsole.writeLine("The entered number is not valid");
    } else {
        jsConsole.writeLine("All the numbers in the range [1, " + number + "] not divisible by 3 and 7 at the same time are:");
        for (i = 0; i < number; i++) {
            if ((i + 1) % 21 !== 0) {
                jsConsole.write((i + 1) + " ");
            }
        }
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        numbersNotDivisibleBy21();
    }
}
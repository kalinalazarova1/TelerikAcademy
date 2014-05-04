//Write a script that finds the biggest of three integers using nested if statements.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function biggestInteger() {
    var first = jsConsole.readInteger("input#number-input1"),
        second = jsConsole.readInteger("input#number-input2"),
        third = jsConsole.readInteger("input#number-input3"),
        biggestInt;
    if ((!first && first !== 0) || (!second && second !== 0) || (!third && third !== 0)) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else if (first < second) {
        if (third > second) {
            biggestInt = third;
        } else {
            biggestInt = second;
        }
    } else {
        if (third > first) {
            biggestInt = third;
        } else {
            biggestInt = first;
        }
    }
    jsConsole.writeLine("The biggest integer is: " + biggestInt);
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else if (document.activeElement === document.getElementById("number-input2")) {
            document.getElementById("number-input3").focus();
        } else {
            biggestInteger();
        }
    }
}
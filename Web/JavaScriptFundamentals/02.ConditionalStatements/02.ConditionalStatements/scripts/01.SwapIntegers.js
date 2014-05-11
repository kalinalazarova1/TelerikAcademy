//Write an if statement that examines two integer variables and exchanges their
//values if the first one is greater than the second one.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function swapIntegers() {
    var first = jsConsole.readInteger("input#number-input1"),
        second = jsConsole.readInteger("input#number-input2"),
        temp;
    if ((!first && first !== 0) || (!second && second !== 0)) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else if (first > second) {
        temp = first;
        first = second;
        second = temp;
    }
    jsConsole.writeLine("The first integer is: " + first + " and the second integer is: " + second);
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            swapIntegers();
        }
    }
}
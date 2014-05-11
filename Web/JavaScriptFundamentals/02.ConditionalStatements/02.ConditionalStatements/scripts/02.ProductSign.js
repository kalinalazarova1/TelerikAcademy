//Write a script that shows the sign (+ or -) of the product of three real numbers
//without calculating it. Use a sequence of if statements.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function productSign() {
    var first = jsConsole.readFloat("input#number-input1"),
        second = jsConsole.readFloat("input#number-input2"),
        third = jsConsole.readFloat("input#number-input3"),
        prodSign = "negative";
    if ((!first && first !== 0) || (!second && second !== 0) || (!third && third !== 0)) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else if ((first < 0 && second < 0 && third > 0) || (first < 0 && second > 0 && third < 0) || (first > 0 && second < 0 && third < 0) || (first > 0 && second > 0 && third > 0)) {
        prodSign = 'positive';
    }
    jsConsole.writeLine("The sign of the product of the three numbers is: " + prodSign);
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else if (document.activeElement === document.getElementById("number-input2")) {
            document.getElementById("number-input3").focus();
        } else {
            productSign();
        }
    }
}
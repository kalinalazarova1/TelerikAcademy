//Sort 3 real values in descending order using nested if statements.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function sortThreeReal() {
    var first = jsConsole.readFloat("input#number-input1"),
        second = jsConsole.readFloat("input#number-input2"),
        third = jsConsole.readFloat("input#number-input3"),
        biggestReal,
        smallestReal,
        middleReal;
    if ((!first && first !== 0) || (!second && second !== 0) || (!third && third !== 0)) {
        jsConsole.writeLine("The entered numbers are not valid.");
    } else {
        if (first < second) {
            if (third > second) {
                biggestReal = third;
                smallestReal = first;
                middleReal = second;
            } else {
                biggestReal = second;
                if (first < third) {
                    smallestReal = first;
                    middleReal = third;
                } else {
                    smallestReal = third;
                    middleReal = first;
                }
            }
        } else {
            if (third > first) {
                biggestReal = third;
                smallestReal = second;
                middleReal = first;
            } else {
                biggestReal = first;
                if (second < third) {
                    smallestReal = second;
                    middleReal = third;
                } else {
                    smallestReal = third;
                    middleReal = second;
                }
            }
        }
        jsConsole.writeLine("The sorted numbers are: " + biggestReal + ", " + middleReal + ", " + smallestReal);
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else if (document.activeElement === document.getElementById("number-input2")) {
            document.getElementById("number-input3").focus();
        } else {
            sortThreeReal();
        }
    }
}
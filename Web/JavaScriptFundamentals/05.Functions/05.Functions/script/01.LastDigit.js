// 1.Write a function that returns the last digit of given integer as an English word.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function lastDigit(number) {          //this is the function that gets a digit and returns the english digit
    var names = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"],
        digit = Number.parseInt(number.charAt(number.length - 1));
    if (!digit && digit !== 0) {
        return undefined;
    }
    return names[digit];
}

function lastDigitTest() {      //this function tests the LastDigit() function
    var number = jsConsole.read("input");
    jsConsole.writeLine("The last digit of " + number + " is: " + lastDigit(number));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        lastDigitTest();
    }
}
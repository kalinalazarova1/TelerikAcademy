// 2.Write a function that reverses the digits of given decimal number.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function reverseDigits(number) {          //this is the function that reverses the digits of a number and returns the reversed number 
    var result = "",
        original = Number.parseInt(number),
        i;
    if (!original && original !== 0) {
        return undefined;
    }
    for (i = number.length - 1; i >= 0 ; i--) {
        result += number.charAt(i);
    }
    return result;
}

function reverseDigitsTest() {      //this function tests the LastDigit() function
    var number = jsConsole.read("input");
    jsConsole.writeLine("The reversed number is: " + reverseDigits(number));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        reverseDigitsTest();
    }
}
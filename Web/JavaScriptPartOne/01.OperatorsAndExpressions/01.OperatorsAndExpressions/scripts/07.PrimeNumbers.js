//Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function primeCheck() {
    var number = jsConsole.readInteger("input"),
        isPrime;
    if (!number || number > 100 || number <= 0) {
        jsConsole.writeLine("The entered number is not valid.");
    } else if (number === 2 || number === 3 || number === 5 || number === 7) {
        jsConsole.writeLine("The number " + number + " is prime.");
    } else {
        isPrime = (number % 2) && (number % 3) && (number % 5) && (number % 7);
        jsConsole.writeLine("The number " + number + " is " + (isPrime ? " " : "not ") + "prime.");
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        primeCheck();
    }
}
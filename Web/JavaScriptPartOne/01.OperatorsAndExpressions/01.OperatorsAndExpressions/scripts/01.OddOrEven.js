//Write an expression that checks if given integer is odd or even.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function oddOrEven() {
    var number = jsConsole.readInteger("input");
    if (!number && number !== 0) {
        jsConsole.writeLine("The entered number is not valid");
    } else {
        jsConsole.writeLine("The number " + number + " is " + (number % 2 ? "odd" : "even") + ".");
    }
}

function enterKeyPressed(event) {
    if (event.keyCode === 13) {
        oddOrEven();
    }
}
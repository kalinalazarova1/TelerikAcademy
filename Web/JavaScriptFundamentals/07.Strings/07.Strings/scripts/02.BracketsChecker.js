// 2.Write a JavaScript function to check if in a given expression the brackets are put correctly.

window.onload = function () {
    document.getElementById("input").focus();
};

function isCorrectBrackets(exp) {
    var flag = 0,
        i;
    for (i = 0; i < exp.length && flag >= 0; i++) {
        if (exp[i] === '(') {
            flag++;
        } else if (exp[i] === ')') {
            flag--;
        }
    }
    return flag === 0;
}

function isCorrectBracketsTest() {
    var exp = jsConsole.read("input");
    jsConsole.writeLine("The brackets in the expression " + exp + " are " + (isCorrectBrackets(exp) ? "correctly" : "incorrectly") + " placed.");
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        isCorrectBracketsTest();
    }
}
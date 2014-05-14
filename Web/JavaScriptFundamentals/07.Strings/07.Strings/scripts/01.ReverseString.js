// 1.Write a JavaScript function reverses string and returns it

window.onload = function () {
    document.getElementById("input").focus();
};

function reverseString(text) {
    var result = "",
        i;
    for (i = text.length - 1; i >= 0; i--) {
        result += text[i];
    }
    return result;
}

function reverseStringTest() {
    var text = jsConsole.read("input");
    jsConsole.writeLine("The reversed string of " + text + " is: " + reverseString(text));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        reverseStringTest();
    }
}
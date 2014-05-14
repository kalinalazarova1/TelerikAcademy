// 5.Write a function that replaces non breaking white-spaces in a text with &nbsp;

window.onload = function () {
    document.getElementById("input1").focus();
};

function replaceSpaces(text) {
    return text.split(" ").join('&nbsp;');
}

function replaceSpacesTest() {
    var text = jsConsole.read("input#input1");
    jsConsole.writeLine("The result is written in the browser console");
    console.log(replaceSpaces(text));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        replaceSpacesTest();
    }
}
// 8.Write a JavaScript function that replaces in a HTML document given
// as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

window.onload = function () {
    document.getElementById("input1").focus();
};

function replaceURL(text) {
    text = text.replace(/<a href="/gi, "[URL=");
    text = text.replace(/">/gi, "]");
    text = text.replace(/<\/a>/gi, "[/URL]");
    return text;
}

function replaceURLTest() {
    var text = jsConsole.read("input#input1");
    //var text = "<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>";
    jsConsole.writeLine("The result is:");
    jsConsole.writeLine(replaceURL(text));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        replaceURLTest();
    }
}
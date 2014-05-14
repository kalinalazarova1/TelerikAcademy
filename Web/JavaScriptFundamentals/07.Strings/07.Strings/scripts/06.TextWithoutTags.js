// 6.Write a function that extracts the content of a html page given as text.
// The function should return anything that is in a tag, without the tags:

window.onload = function () {
    document.getElementById("input1").focus();
};

function removeTags(text) {
    return text.replace(/<[^>]+>/ig, "");
}

function removeTagsTest() {
    var text = jsConsole.read("input#input1");
    //var text = "<html><head><title>News </title></head><body><p><a href=&quot;http://academy.telerik.com&quot;>Telerik Academy</a> aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body></html>";
    jsConsole.writeLine("The result is: " + removeTags(text));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        removeTagsTest();
    }
}
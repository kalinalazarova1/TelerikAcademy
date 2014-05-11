// 4.Write a function to count the number of divs on the web page

function divCount() {
    return document.getElementsByTagName("div").length;
}

window.onload = function () {
    jsConsole.writeLine("The number of div tags in the current page are: " + divCount());
};
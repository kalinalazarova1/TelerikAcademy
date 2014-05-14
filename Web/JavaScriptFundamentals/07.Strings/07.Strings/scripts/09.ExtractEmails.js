// 9.Write a function for extracting all email addresses from given text.
// All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.
// Return the emails as array of strings.

window.onload = function () {
    document.getElementById("input1").focus();
};

function extractEmails(text) {
    return text.match(/\b[A-Z0-9\._%+-]+@[A-Z0-9\.-]+\.[A-Z]{2,4}\b/gi);
}

function extractEmailsTest() {
    var text = jsConsole.read("input#input1");
    //var text = "Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @telerik.com. Neither this: a@a.b.";
    jsConsole.writeLine("The result is:");
    jsConsole.writeLine(extractEmails(text).join('<br />'));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        extractEmailsTest();
    }
}
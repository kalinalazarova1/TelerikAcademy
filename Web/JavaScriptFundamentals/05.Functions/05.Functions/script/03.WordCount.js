// 3.Write a function that finds all the occurrences of word in a text
// The search can be case sensitive or case insensitive
// Use function overloading

window.onload = function () {
    document.getElementById("input1").focus();
};

function wordCount(text, word, isSensitive) {
    function wordCountSensitive(text, word) {
        var words = text.split(new RegExp("\\b" + word + "\\b"));       //the text is splitted by the search word
        return words.length - 1;                                        //the number of pieces after the split minus one are the count of the occurances of the searched word
    }

    function wordCountInsensitive(text, word, isSensitive) {
        if (isSensitive) {
            return wordCountSensitive(text, word);
        }
        return wordCountSensitive(text.toLowerCase(), word.toLowerCase()); //calls the case-sensitive search but the text and the searched word are both made lower case
    }

    if (arguments.length === 2) {
        return wordCountSensitive(text, word);
    }
    return wordCountInsensitive(text, word, isSensitive);
}

function wordCountTest() {      //tests WordCount() function and its overloading by calling it with 2 or 3 arguments
    var text = jsConsole.read("input#input1"),
        word = jsConsole.read("input#input2");
    jsConsole.writeLine("The word(case-sensitive): " + word + " is found " + wordCount(text, word) + (wordCount(text, word) === 1 ? " time" : " times."));
    jsConsole.writeLine("The word(case-insensitive): " + word + " is found " + wordCount(text, word, false) + (wordCount(text, word, false) === 1 ? " time" : " times."));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("input1")) {
            document.getElementById("input2").focus();
        } else {
            wordCountTest();
        }
    }
}
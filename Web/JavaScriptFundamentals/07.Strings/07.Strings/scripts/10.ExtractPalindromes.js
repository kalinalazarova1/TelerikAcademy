// 10.Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

window.onload = function () {
    document.getElementById("input1").focus();
};

function isPalindrome(word) {
    return word === word.split('').reverse().join('') && word !== '' && word.length > 1;
}

function extractPalindromes(text) {
    var words = text.split(/\W/),
        result = [],
        i;
    for (i = 0; i < words.length; i++) {
        if (isPalindrome(words[i])) {
            result.push(words[i]);
        }
    }
    return result;
}

function extractPalindromesTest() {
    var text = jsConsole.read("input#input1");
    jsConsole.writeLine("The result is:");
    jsConsole.writeLine(extractPalindromes(text).join('<br />'));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        extractPalindromesTest();
    }
}
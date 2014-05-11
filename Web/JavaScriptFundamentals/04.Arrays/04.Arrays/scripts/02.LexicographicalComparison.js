// 2.Write a script that compares two char arrays lexicographically (letter by letter).

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function arraysEqual(first, second) {
    var i = first.length;
    if (i !== second.length) {
        return false;
    }
    while (i--) {
        if (first[i] !== second[i]) {
            return false;
        }
    }
    return true;
}

function charsComparer() {
    var first = jsConsole.read("input#number-input1").split(' '),
        second = jsConsole.read("input#number-input2").split(' ');
    if (arraysEqual(first, second)) {
        jsConsole.writeLine("The two arrays are equal.");
    } else {
        jsConsole.writeLine("The first array is lexicografically" + (first < second ? " before " : " after ") + "the second array.");
    }
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            charsComparer();
        }
    }
}
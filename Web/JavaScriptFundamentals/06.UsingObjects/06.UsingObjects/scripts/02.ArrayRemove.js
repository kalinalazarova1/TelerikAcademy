// 2.Write a function that removes all elements with a given value
// Attach it to the array class
// Read about prototype and how to attach methods

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function arrayRemoveTest() {
    var arr = jsConsole.read("input#number-input1").split(' '),
        item = jsConsole.read("input#number-input2");
    arr.remove(item);
    jsConsole.writeLine("Array after removal: " + arr.join(" "));
}

Array.prototype.remove = function (value) {
    var i = 0;
    while (i < this.length) {
        if (this[i] === value) {
            this.splice(i, 1);
        } else {
            i++;
        }
    }
};

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            arrayRemoveTest();
        }
    }
}
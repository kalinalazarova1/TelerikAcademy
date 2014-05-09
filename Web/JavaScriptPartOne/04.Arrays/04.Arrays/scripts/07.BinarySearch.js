// 7.Write a program that finds the index of given element in a sorted array of integers by using the binary
// search algorithm (find it in Wikipedia)

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function binarySearch() {
    var arr = jsConsole.read("input#number-input1").split(' '),
        value,
        l,
        m,
        r;
    arr.sort(function (x, y) { return x - y; });
    jsConsole.writeLine("The sorted array is: " + arr.join(' '));
    value = jsConsole.readFloat("input#number-input2");
    if (!value && value !== 0) {
        jsConsole.writeLine("Invalid search value.");
        return;
    }
    r = arr.length - 1;
    l = 0;
    while (l <= r) {
        m = Number.parseInt((l + r) / 2);
        if (arr[m] < value) {
            l = m + 1;
        } else if (arr[m] > value) {
            r = m - 1;
        } else {
            jsConsole.writeLine("The index of the element in the sorted array is: " + m);
            return;
        }
    }
    jsConsole.writeLine("There is no such element in the array.");
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            binarySearch();
        }
    }
}
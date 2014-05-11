// 5.Sorting an array means to arrange its elements in increasing order. Write a script to sort an array.
// Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the
// smallest from the rest, move it at the second position, etc.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function selectionSort() {
    //This version uses two arrays according to the task hint
    var sequence = jsConsole.read("input#number-input1").split(' '),
        sorted = [],
        min,
        minIndex,
        i;
    while (sequence.length > 0) {
        min = Number(sequence[0]);
        minIndex = 0;
        for (i = 1; i < sequence.length; i++) {
            if (Number(sequence[i]) < min) {
                min = sequence[i];
                minIndex = i;
            }
        }
        sorted.push(min);
        sequence.splice(minIndex, 1);
    }
    jsConsole.writeLine("The sorted array is: " + sorted.join(', '));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        selectionSort();
    }
}
// 5.Sorting an array means to arrange its elements in increasing order. Write a script to sort an array.
// Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the
// smallest from the rest, move it at the second position, etc.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function selectionSort() {
    //This version uses one array
    var sequence = jsConsole.read("input#number-input1").split(' '),
        min,
        temp,
        i,
        j;
    for (i = 0; i < sequence.length; i++) {
        min = i;
        for (j = i; j < sequence.length; j++) {
            if (Number(sequence[j]) < Number(sequence[min])) {
                min = j;
            }
        }
        temp = sequence[i];
        sequence[i] = sequence[min];
        sequence[min] = temp;
    }
    jsConsole.writeLine("The sorted array is: " + sequence.join(', '));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        selectionSort();
    }
}
// 7.Write a Function that returns the index of the first element in array that is bigger than its neighbours, or -1, if there’s no such element.
// Use the function from the previous exercise.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function biggerThanNeighbours(arr, i) {
    return (i === 0 || arr[i] - arr[i - 1] > 0) && (i === arr.length - 1 || arr[i] - arr[i + 1] > 0);
}

function firstBiggerThanNeighbours(arr) {
    var i;
    for (i = 0; i < arr.length; i++) {
        if (biggerThanNeighbours(arr, i)) {
            return i;
        }
    }
    return -1;
}

function firstBiggerThanNeighboursTest() {
    var arr = jsConsole.read("input#number-input1").split(' ');
    jsConsole.writeLine("The first element in the array, bigger than its neighbours, is at index: " + (firstBiggerThanNeighbours(arr) !== -1 ? firstBiggerThanNeighbours(arr) : "no such element"));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        firstBiggerThanNeighboursTest();
    }
}
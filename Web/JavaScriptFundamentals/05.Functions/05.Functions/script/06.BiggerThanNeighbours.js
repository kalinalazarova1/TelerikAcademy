// 6.Write a function that checks if the element at given position in given array of integers
// is bigger than its two neighbors (when such exist).

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function biggerThanNeighbours(arr, i) {
    return (i === 0 || arr[i] - arr[i - 1] > 0) && (i === arr.length - 1 || arr[i] - arr[i + 1] > 0);
}

function biggerThanNeighboursTest() {
    var arr = jsConsole.read("input#number-input1").split(' '),
        index = jsConsole.readInteger("input#number-input2");
    if ((!index && index !== 0) || index < 0 || index > arr.length - 1) {
        jsConsole.writeLine("Invalid index.");
        return;
    }
    jsConsole.writeLine("The element at index " + index + " in the array " + (biggerThanNeighbours(arr, index) ? " is " : " is not ") + "bigger than its neighbours.");
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            biggerThanNeighboursTest();
        }
    }
}
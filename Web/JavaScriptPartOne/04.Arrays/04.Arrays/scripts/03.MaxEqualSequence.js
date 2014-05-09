// 3.Write a script that finds the maximal sequence of equal elements in an array.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function findMaxSequence() {
    var sequence = jsConsole.read("input#number-input1").split(' '),
        maxSequence = 0,
        maxElementIndex = 0,
        currentSequence = 1,
        i;
    for (i = 1; i < sequence.length; i++) {
        if (sequence[i] === sequence[i - 1]) {
            currentSequence++;
            if (currentSequence > maxSequence) {
                maxSequence = currentSequence;
                maxElementIndex = i;
            }
        } else {
            currentSequence = 1;
        }
    }
    jsConsole.writeLine("The longest sequence of equals is " + maxSequence + " elements long and consists of: " + sequence[maxElementIndex]);
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        findMaxSequence();
    }
}
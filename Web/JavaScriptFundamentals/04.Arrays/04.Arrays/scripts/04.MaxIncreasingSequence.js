// 4.Write a script that finds the maximal increasing sequence in an array.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function maxIncreasingSequence() {
    var sequence = jsConsole.read("input#number-input1").split(' '),
        maxSequence = 0,
        startElementIndex = 0,
        currentSequence = 1,
        i;
    for (i = 1; i < sequence.length; i++) {
        if (Number.parseInt(sequence[i]) > Number.parseInt(sequence[i - 1])) {
            currentSequence++;
            if (currentSequence > maxSequence) {
                maxSequence = currentSequence;
                startElementIndex = i - maxSequence + 1;
            }
        } else {
            currentSequence = 1;
        }
    }
    jsConsole.writeLine("The longest sequence of increasing elements is: " + sequence.splice(startElementIndex, maxSequence).join(' '));
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        maxIncreasingSequence();
    }
}
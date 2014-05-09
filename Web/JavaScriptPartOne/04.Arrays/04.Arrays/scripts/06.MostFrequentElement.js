// 6.Write a program that finds the most frequent number in an array.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function mostFrequent() {
    var currCount = 1,
        maxCount = 0,
        maxIndex = -1,
        arr = jsConsole.read("input#number-input1").split(' '),
        i;
    arr.sort();             //this sort is lexicographical but it is ok for my purpose
    for (i = 1; i < arr.length; i++) {
        if (arr[i] === arr[i - 1]) {
            currCount++;
            if (currCount > maxCount) {
                maxCount = currCount;
                maxIndex = i;
            }
        } else {
            currCount = 1;
        }
    }
    jsConsole.writeLine("The most frequent element in the array is " + arr[maxIndex] + " and is found " + maxCount + " times.");
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        mostFrequent();
    }
}
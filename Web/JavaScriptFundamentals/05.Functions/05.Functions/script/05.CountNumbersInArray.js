// 5.Write a function that counts how many times given number appears in given array.
// Write a test function to check if the function is working correctly.

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function countNumbers(arr, num) {
    var counter = 0,
        i;
    for (i = 0; i < arr.length; i++) {
        if (Number(arr[i]) === num) {
            counter++;
        }
    }
    return counter;
}

function countNumbersTest() {
    var arr = jsConsole.read("input#number-input1").split(' '),
        num = jsConsole.readFloat("input#number-input2");
    if (!num && num !== 0) {
        jsConsole.writeLine("Invalid search value.");
        return;
    }
    jsConsole.writeLine("Number " + num + " is found " + countNumbers(arr, num) + " time/times in the array.");
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else {
            countNumbersTest();
        }
    }
}
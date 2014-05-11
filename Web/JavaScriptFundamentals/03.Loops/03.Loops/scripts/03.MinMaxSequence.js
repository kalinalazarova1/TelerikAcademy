// 3.Write a script that finds the max and min number from a sequence of numbers

window.onload = function () {
    document.getElementById("number-input").focus();
};

function minMaxNumber() {
    var input = jsConsole.read("input"),
        arr = input.split(" "),
        max = parseFloat(arr[0]),
        min = max,
        i,
        temp;
    if (input === "") {
        return;
    }
    for (i = 1; i < arr.length; i++) {
        temp = parseFloat(arr[i]);
        if ((!temp && temp !== 0) || (!max && max !== 0)) {
            jsConsole.writeLine("Invalid input string.");
            return;
        }

        if (temp > max) {
            max = temp;
        } else if (temp < min) {
            min = temp;
        }
    }

    jsConsole.writeLine("The minimal number is: " + min);
    jsConsole.writeLine("The maximal number is: " + max);
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        minMaxNumber();
    }
}
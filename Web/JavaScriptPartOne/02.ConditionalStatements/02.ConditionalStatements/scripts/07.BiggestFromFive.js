// Write a script that finds the greatest of given 5 variables.

window.onload = function () {
    document.getElementById("number-input").focus();
};

function biggestNumber() {
    var input = jsConsole.read("input"),
        arr = input.split(" "),
        biggest = parseFloat(arr[0]),
        i,
        temp;
    for (i = 1; i < 5; i++) {
        temp = parseFloat(arr[i]);
        if ((!temp && temp !== 0) || (!biggest && biggest !== 0)) {
            jsConsole.writeLine("Invalid input string.");
            return;
        }
        if (temp > biggest) {
            biggest = temp;
        }
    }
    jsConsole.writeLine("The biggest number is: " + biggest);
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        biggestNumber();
    }
}
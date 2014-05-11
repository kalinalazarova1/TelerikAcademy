// 4.Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects

function minMaxProperty(myObject) {
    var min = "",
        max = "",
        p;
    for (p in myObject) {
        if (myObject.hasOwnProperty(p)) {
            if (min === "" || p < min) {
                min = p;
            }
            if (max === "" || p > max) {
                max = p;
            }
        }
    }
    jsConsole.writeLine("Lexicographically smallest property of " + myObject + " is: " + min);
    jsConsole.writeLine("Lexicographically largest property of " + myObject + " is: " + max);
}

window.onload = function () {
    minMaxProperty(document);
    minMaxProperty(window);
    minMaxProperty(navigator);
};
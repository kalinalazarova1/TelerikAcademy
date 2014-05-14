// 11.-Write a function that formats a string using placeholders. The function should work with up to 30 placeholders and all types.

function format(str) {
    var result = "",
        splitted = str.split(/[{}]/),
        i;
    for (i = 1; i < splitted.length; i += 2) {
        result += splitted[i - 1] + arguments[Number(splitted[i]) + 1];
    }
    result += splitted[splitted.length - 1];
    return result;
}

window.onload = function () {
    jsConsole.writeLine(format("Hello, {0}, congratulations on your {2}th {1}, {0}!", "Pesho", "birthday", 21));
};
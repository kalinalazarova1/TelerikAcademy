// 3.Create a module to work with the console object.
// Implement functionality for:
// Writing a line to the console 
// Writing a line to the console using a format
// Writing to the console should call toString() to each element
// Writing errors and warnings to the console with and without format

var specialConsole = (function () {
    'use strict';
    function format(args) {
        var result = "",
            splitted,
            i;

        if (args.length <= 1) {
            return args[0];
        }
        splitted = args[0].split(/[{}]/); // no need to call toString() because split always returns an array of strings
        for (i = 1; i < splitted.length; i += 2) {
            result += splitted[i - 1] + args[Number(splitted[i]) + 1];
        }
        result += splitted[splitted.length - 1];
        return result;
    }

    function writeLine() {
        console.log(format(arguments));
    }

    function writeError() {
        console.error(format(arguments));
    }

    function writeWarning() {
        console.warn(format(arguments));
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
}());
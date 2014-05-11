// 3.Write a function that makes a deep copy of an object
// The function should work for both primitive and reference types

var myArr = [2, 3, [4, 5, 6], 7];
var num = 5;
function deepCopy(obj) {
    var copy,
        p;
    if (typeof obj === 'object') {
        if (obj instanceof Array) {
            copy = [];
        } else {
            copy = {};
        }
        for (p in obj) {
            if (obj.hasOwnProperty(p)) {
                if (typeof obj[p] === 'object') {
                    copy[p] = deepCopy(obj[p]);
                } else {
                    copy[p] = obj[p];
                }
            }
        }
        return copy;
    }
    return obj;
}

window.onload = function () {
    var numCopy = deepCopy(num),
        myArrCopy = deepCopy(myArr);
    myArrCopy[2].push(15);
    numCopy = 7;
    jsConsole.writeLine("After push 15 in the array in position 2 in the copy array: ");
    jsConsole.writeLine("Original: " + myArr.join(","));
    jsConsole.writeLine("Copy: " + myArrCopy.join(","));
    jsConsole.writeLine("After change the number in the copy to 7: ");
    jsConsole.writeLine("Original: " + num);
    jsConsole.writeLine("Copy: " + numCopy);
};
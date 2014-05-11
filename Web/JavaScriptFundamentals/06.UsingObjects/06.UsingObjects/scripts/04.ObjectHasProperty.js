// 4.Write a function that checks if a given object contains a given property

var myObj = [2, 3, 4],
    myString = 'alabala',
    myNumber = Number(5),
    propName = 'length';

function hasProperty(obj, propName) {
    if (obj.hasOwnProperty(propName)) {
        return true;
    }
    return false;
}
jsConsole.writeLine("The object " + myObj + (myObj.hasOwnProperty(propName) ? " has " : " has not ") + "a property named " + propName + ".");
jsConsole.writeLine("The object " + myString + (myString.hasOwnProperty(propName) ? " has " : " has not ") + "a property named " + propName + ".");
jsConsole.writeLine("The object " + myNumber + (myNumber.hasOwnProperty(propName) ? " has " : " has not ") + "a property named " + propName + ".");


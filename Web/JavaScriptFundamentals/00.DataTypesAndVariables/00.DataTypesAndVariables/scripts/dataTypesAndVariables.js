//1. Assign all the possible JavaScript literals to different variables.

var integer = 24;
var float = -0.31;
var boolean = true;
var string = 'Telerik Academy';
var object = {
    name: 'Doncho',
    course: 'Java Script Fundamentals',
    grade: 6
};

var array = [23, 71, 11, 22, '5', 'true'];
var func = function () {
    return 'Hello!';
};

jsConsole.writeLine('Task 1:');
jsConsole.writeLine('The value of var integer is: ' + integer);
jsConsole.writeLine('The value of var float is: ' + float);
jsConsole.writeLine('The value of var boolean is: ' + boolean);
jsConsole.writeLine('The value of var string is: ' + string);
jsConsole.writeLine('The value of var object is: ' + JSON.stringify(object));
jsConsole.writeLine('The value of var array is: ' + array);
jsConsole.writeLine('The value of var func is: ' + func);

//2. Create a string variable with quoted text in it. For example: "How you doin'?", Joey said.

var quotedText = '"How you doin\'?", Joey said.';
jsConsole.writeLine('Task 2:');
jsConsole.writeLine('Quoted text: ' + quotedText);

//3. Try typeof on all variables you created.

jsConsole.writeLine('Task 3:');
jsConsole.writeLine('Type of integer is: ' + typeof integer);
jsConsole.writeLine('Type of float is: ' + typeof float);
jsConsole.writeLine('Type of boolean is: ' + typeof boolean);
jsConsole.writeLine('Type of string is: ' + typeof string);
jsConsole.writeLine('Type of object is: ' + typeof object);
jsConsole.writeLine('Type of array is: ' + typeof array);
jsConsole.writeLine('Type of function is: ' + typeof func);

//4. Create null, undefined variables and try typeof on them.

var nullVariable = null;
var undefinedVariable = undefined;

jsConsole.writeLine('Task 4:');
jsConsole.writeLine('Type of null is: ' + nullVariable);
jsConsole.writeLine('Type of undefined is: ' + undefinedVariable);
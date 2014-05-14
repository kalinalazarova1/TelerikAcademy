function Solve(args) {
    var variables = {},
        i,
        j,
        name,
        check = 0;

    function clear(arr) {       //cleans from the array the empty strings
        var p,
            arrNew = [];
        for (p = 0; p < arr.length; p++) {
            if (arr[p] !== '') {
                arrNew.push(arr[p]);
            }
        }
        return arrNew;
    }

    function action(a, b, operation) {      // calculates result given two operands and operation
        switch (operation) {
        case '+':
            return a + b;
        case '-':
            return a - b;
        case '*':
            return a * b;
        case '/':
            return a / b;
        }
    }

    function parseLine(expression) {                    // calculates and returns a result from a single expression enclosed in brackets 
        var exp = expression.substring(1, expression.length - 1),
            tokens = exp.split(' '),
            result,
            p;
        tokens = clear(tokens);
        if (tokens[0] === 'def') {
            variables[tokens[1]] = tokens[2] | 0;
            return;
        }
        if (tokens[1] | 0) {
            result = tokens[1] | 0;
        } else {
            result = variables[tokens[1]] | 0;
        }
        if (tokens.length === 2) {
            return result;
        }
        for (p = 2; p < tokens.length; p++) {
            if (Number(tokens[p]) || Number(tokens[p]) === 0) {
                result = action(result, Number(tokens[p]), tokens[0]);
            } else {
                result = action(result, Number(variables[tokens[p]]), tokens[0]);
            }
            if (!isFinite(result)) {
                return false;                                       // when there is division by zero the function returns false
            }
        }
        return result;
    }

    for (i = 0; i < args.length; i++) {
        for (j = 1; j < args[i].length; j++) {
            if (args[i].charAt(j) === 'd') {        // parses lines starting with 'def'
                name = '';
                while (args[i].charAt(j) !== ' ') {
                    j++;
                }
                while (args[i].charAt(j) === ' ') {
                    j++;
                }
                while (args[i].charAt(j) !== ' ') {
                    name += args[i].charAt(j);
                    j++;
                }
                while (args[i].charAt(j) === ' ') {
                    j++;
                }
                if (args[i].charAt(j) === '(') {
                    if (parseLine(args[i].substring(j, args[i].indexOf(')') + 1)) === false) {      // division by zero
                        return 'Division by zero! At Line:' + (i + 1);
                    }
                    variables[name] = parseLine(args[i].substring(j, args[i].indexOf(')') + 1));    // the second operand is expression
                    j = args[i].length;
                } else {
                    if (isNaN(Number(args[i].substring(j, args[i].length - 1)))) {                  // the second operand is variable
                        variables[name] = variables[args[i].substring(j, args[i].length - 1).trim()];
                        j = args[i].length;
                    } else {                                                                        // the second operand is number
                        variables[name] = Number(args[i].substring(j, args[i].length - 1));
                        j = args[i].length;
                    }
                }
            } else if (args[i].charAt(j) !== ' ' && args[i].charAt(j) !== '(') {        // parses the last line and returns the result
                return parseLine(args[i]) | 0;
            }
        }
    }
}


(function print() {
    var args = ['(def func 10)', '(def newFunc (+  func 2))', '(def sumFunc (+ func func newFunc 0 0 0))', '(* sumFunc 2)'];
    console.log(Solve(args));
})();
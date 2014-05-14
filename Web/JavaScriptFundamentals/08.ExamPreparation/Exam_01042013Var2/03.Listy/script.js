function Solve(args) {
    var i,
        j,
        k,
        name,
        part,
        variables = {};

    function calcExpression(operation, operands) {  // calculates an expression enclosed in [] brackets
        var numbers = operands.split(','),
            nums = [],
            p,
            q,
            sum,
            max,
            min;
        for (p = 0; p < numbers.length; p++) {
            if (numbers[p] === ' ') {
                continue;
            }
            if (isNaN(Number(numbers[p]))) {
                if (variables[numbers[p].trim()] instanceof Array) {
                    for (q = 0; q < variables[numbers[p].trim()].length; q++) {
                        nums.push(variables[numbers[p].trim()][q] | 0);
                    }
                } else {
                    nums.push(variables[numbers[p].trim()] | 0);
                }
            } else {
                nums.push(Number(numbers[p]));
            }
        }
        switch (operation) {
        case 'min':
            min = nums[0] | 0;
            nums.forEach(function (x) { min = Math.min(x, min); });
            return min;
        case 'max':
            max = nums[0] | 0;
            nums.forEach(function (x) { max = Math.max(x, max); });
            return max;
        case 'avg':
            sum = 0;
            nums.forEach(function (x) { sum += x; });
            return Math.floor(sum / nums.length);
        case 'sum':
            sum = 0;
            nums.forEach(function (x) { sum += x; });
            return sum;
        }
    }

    String.prototype.between = function (start, end) {      // returns a string which is between start and end index (position of the start and end are not included)
        return this.substring(start + 1, end);
    };

    for (i = 0; i < args.length; i++) {
        name = '';
        if (args[i].indexOf('def') < 0 && i !== args.length - 1) {
            continue;
        }
        for (j = 0; j < args[i].length; j++) {
            if (args[i].charAt(j) === 'd') {                    // if starts with 'd' it is a definition of new variable
                j = args[i].indexOf('f') + 1;
                while (args[i].charAt(j) === ' ') {
                    j++;
                }
                while (args[i].charAt(j) !== ' ' && args[i].charAt(j) !== '[') {
                    name += args[i].charAt(j);                  // gets the name of the variable
                    j++;
                }
                while (args[i].charAt(j) === ' ') {
                    j++;
                }
                if (args[i].charAt(j) === '[') {
                    variables[name] = [];
                    part = args[i].between(args[i].indexOf('[', j), args[i].indexOf(']', j)).split(',');
                    for (k = 0; k < part.length; k++) {
                        if (isNaN(Number(part[k]))) {
                            variables[name].push(variables[part[k].trim()]);
                        } else {
                            variables[name].push(Number(part[k]));
                        }
                    }
                } else {
                    while (args[i].charAt(j) === ' ') {
                        j++;
                    }
                    variables[name] = calcExpression(args[i].substr(j, 3), args[i].between(args[i].indexOf('[', j), args[i].indexOf(']', j)));
                }
                j = args[i].length - 1;
            } else if (args[i].charAt(j) === '[') {         // only one variable on the last line
                if (isNaN(Number(args[i].between(0, args[i].length - 1)))) {
                    return variables[args[i].between(j, args[i].length - 1).trim()] | 0;
                }
                return Number(args[i].between(j, args[i].length - 1));
            } else {                                        // operation expression on the last line
                if (args[i].charAt(j) === 'm' || args[i].charAt(j) === 'a' || args[i].charAt(j) === 's') {
                    return calcExpression(args[i].substr(j, 3), args[i].between(args[i].indexOf('[', j), args[i].indexOf(']', j))) | 0;
                }
            }
        }
    }
}


(function print() {
    var args = ['def maxy max[100]', 'def summary [0]', 'combo [maxy, maxy,maxy,maxy, 5,6]', 'summary sum[combo, maxy, -18000]', 'def pe6o avg[summary,maxy]', 'sum[7, pe6o]'];
    console.log(Solve(args));
})();
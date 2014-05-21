function solve(lines) {
    var result = '',
        vars = {V: 0, W: 0, X: 0, Y: 0, Z: 0},
        i,
        code = [],
        isTerminated = false,
        splitIndex;

    function calcExp(exp) {
        var left,
            right;
        if (exp.indexOf('+') < 0 && exp.indexOf('-') < 0) {
            return !isNaN(Number(exp)) ? Number(exp) : vars[exp.trim()];
        }
        if (exp.indexOf('+') >= 0) {
            left = exp.split('+')[0];
            if (left === '') {
                left = 0;
            }
            right = exp.split('+')[1];
            return (!isNaN(Number(left)) ? Number(left) : vars[left.trim()]) + (!isNaN(Number(right)) ? Number(right) : vars[right.trim()]);
        }
        left = exp.split('-')[0];
        if (left === '') {
            left = 0;
        }
        right = exp.split('-')[1];
        return (!isNaN(Number(left)) ? Number(left) : vars[left.trim()]) - (!isNaN(Number(right)) ? Number(right) : vars[right.trim()]);
    }

    function calcCond(cond) {
        var left,
            right;
        if (cond.indexOf('>') >= 0) {
            left = cond.split('>')[0];
            right = cond.split('>')[1];
            return (!isNaN(Number(left)) ? Number(left) : vars[left.trim()]) > (!isNaN(Number(right)) ? Number(right) : vars[right.trim()]);
        }
        if (cond.indexOf('<') >= 0) {
            left = cond.split('<')[0];
            right = cond.split('<')[1];
            return (!isNaN(Number(left)) ? Number(left) : vars[left.trim()]) < (!isNaN(Number(right)) ? Number(right) : vars[right.trim()]);
        }
        left = cond.split('=')[0];
        right = cond.split('=')[1];
        return (!isNaN(Number(left)) ? Number(left) : vars[left.trim()]) === (!isNaN(Number(right)) ? Number(right) : vars[right.trim()]);
    }

    function execute(com) {
        var p,
            next;
        if (com.indexOf('IF') >= 0) {
            if (calcCond(com.substring(com.indexOf('IF') + 2, com.indexOf('THEN')))) {
                execute(com.substring(com.indexOf('THEN') + 4));
            }
        } else if (com.indexOf('GOTO') >= 0) {
            next = Number(com.split('GOTO')[1]);
            for (p = 0; p < lines.length; p++) {
                if (Number(code[p][0]) === next) {
                    i = p;
                    break;
                }
            }
            i--;
        } else if (com.indexOf('PRINT') >= 0) {
            result += vars[com.split('PRINT')[1].trim()] + '\n';
        } else if (com.indexOf('CLS') >= 0) {
            result = '';
        } else if (com.indexOf('STOP') >= 0 || com.indexOf('RUN') >= 0) {
            isTerminated = true;
        } else {
            vars[com.split('=')[0]] = calcExp(com.split('=')[1]);
        }
    }
    for (i = 0; i < lines.length; i++) {
        splitIndex = lines[i].indexOf(' ');
        lines[i] = lines[i].replace(/\s+/g, '');
        code[i] = [];
        code[i].push(lines[i].substring(0, splitIndex));
        code[i].push(lines[i].substring(splitIndex));
    }
    for (i = 0; i < code.length; i++) {
        execute(code[i][1]);
        if (isTerminated) {
            return result.substr(0, result.length - 1);
        }
    }
}

var args = ['0    X   =    1', '1    Y     =     2', '2 Z    =    Y    -    X', '5    PRINT          X', '6    PRINT     Z', '10          X   =   X    +1', '20   IF  X  =  Y  THEN  GOTO 2', 'RUN'];
console.log(solve(args));
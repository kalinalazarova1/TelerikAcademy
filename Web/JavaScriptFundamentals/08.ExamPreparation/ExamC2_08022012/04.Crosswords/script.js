function solve(args){
    var words = args.slice(1),
        found = false,
        n = args[0] | 0,
      crossword = [];

    function check() {
        var j,
            k,
            current;
        for (j = 0; j < n; j++) {
            current = '';
            for (k = 0; k < n; k++) {
                current += crossword[k][j];
            }
            if (words.indexOf(current) < 0) {
                return false;
            }
        }
        return true;
    }

    function fill(start) {
        var i;
        if (found) {
            return;
        }

        if (start >= n) {
            if (check()) {
                found = true;
            }
            return;
        }

        for (i = 0; i < n * 2; i++) {
            if (!found) {
                crossword[start] = words[i];
                fill(start + 1);
            }
        }
    }

    words = words.sort();
    fill(0);
    return found ? crossword.join('\n') : 'NO SOLUTION!';
}

var args = ['4', 'FIRE', 'ACID', 'CENG', 'EDGE', 'FACE', 'ICED', 'RING', 'CERN'];
console.log(solve(args));
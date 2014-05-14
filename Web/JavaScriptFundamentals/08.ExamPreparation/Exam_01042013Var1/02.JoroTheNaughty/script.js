function Solve(args) {
    var input = args[0].split(' '),
        n = input[0] | 0,
        m = input[1] | 0,
        pos = args[1].split(' '),
        curRow = pos[0] | 0,
        curCol = pos[1] | 0,
        field = [],
        sum = curRow * m + curCol + 1,
        i,
        jumps = [],
        coordArray;

    for (i = 2; i < (input[2] | 0) + 2; i++) {  // stores the coordinates of the jumps in the jumps array
        coordArray = args[i].split(' ');
        jumps.push(coordArray);
    }
    i = 0;
    while (true) {
        curRow += jumps[i % jumps.length][0] | 0;
        curCol += jumps[i % jumps.length][1] | 0;
        if (curRow < 0 || curRow >= n || curCol < 0 || curCol >= m) {   // if outside the array then Joro is escaped
            return 'escaped ' + sum;
        }
        if (field[curRow * m + curCol + 1]) {                           // if step on visited position Joro is caught
            return 'caught ' + (i + 1);
        }
        field[curRow * m + curCol + 1] = true;
        sum += curRow * m + curCol + 1;
        i++;
    }
}


(function print() {
    var args = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1'];
    console.log(Solve(args));
})();
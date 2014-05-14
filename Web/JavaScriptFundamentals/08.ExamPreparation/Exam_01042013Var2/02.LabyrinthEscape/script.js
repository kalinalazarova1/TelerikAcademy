function Solve(args) {
    var dim = args[0].split(' '),
        rows = dim[0] | 0,
        cols = dim[1] | 0,
        coord = args[1].split(' '),
        r = coord[0] | 0,
        c = coord[1] | 0,
        field = [],
        isVisited = [],
        i,
        j,
        sum = 0;

    for (i = 0; i < rows; i++) {        // parses the labyrinth with the directions
        for (j = 0; j < cols; j++) {
            field.push(args[i + 2].charAt(j));
        }
    }
    i = 0;                              // counts number of the steps
    while (true) {
        if (c < 0 || c >= cols || r >= rows || r < 0) {
            return 'out ' + sum;            
        }
        if (isVisited[c + r * cols]) {
            return 'lost ' + i;
        }
        sum += (c + r * cols + 1);
        isVisited[c + r * cols] = true;
        i++;
        switch (field[c + r * cols]) {
        case 'l':
            c--;
            break;
        case 'r':
            c++;
            break;
        case 'u':
            r--;
            break;
        case 'd':
            r++;
            break;
        }
    }
}

(function print() {
    var args = ["5 8", "0 0", "rrrrrrrd", "rludulrd", "lurlddud", "urrrldud", "ulllllll"];
    console.log(Solve(args));
})();
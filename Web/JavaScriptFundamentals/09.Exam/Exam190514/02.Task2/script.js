function solve(args) {
    var input = args[0];
    var rows = input.split(' ')[0] | 0;
    var cols = input.split(' ')[1] | 0;
    var matrix = [];
    var sum = 0;
    for (var r = 0; r < rows; r++) {
        var temp = args[r + 1].split(' ');
        matrix[r] = [];
        for (var c = 0; c < cols; c++) {
            matrix[r][c] = temp[c];
        }
    }
    var curRow = 0;
    var curCol = 0;
    while (true) {
        if (curRow < 0 || curRow >= rows || curCol < 0 || curCol >= cols) {
            return 'successed with ' + sum;
        }
        if (!matrix[curRow][curCol]) {
            return 'failed at (' + curRow + ', ' + curCol + ')';
        }
        
        sum += Math.pow(2, curRow) + curCol;
        var dir = matrix[curRow][curCol];
        matrix[curRow][curCol] = false;
        switch (dir) {
            case 'dr': curRow++; curCol++; break;
            case 'ur': curRow--; curCol++; break;
            case 'ul': curRow--; curCol--; break;
            case 'dl': curRow++; curCol--; break;
        }
        
    }
}

var args = [
  '3 5',
  'dr dl dr ur ul',
  'dr dr ul ur ur',
  'dl dr ur dl ur'
];
console.log(solve(args));
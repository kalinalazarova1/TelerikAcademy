function Solve(input) {
    var rowsColsJumps = input[0].split(' ').map(Number);
    var rows = rowsColsJumps[0];
    var cols = rowsColsJumps[1];
    var matrix = [];
    var counter = 1;

    for (var k = 0; k < rows; k += 1) {
        matrix[k] = [];
        for (var m = 0; m < cols; m += 1) {
            matrix[k][m] = counter++;
        }
    }

    console.log(matrix);

    var numJumps = rowsColsJumps[2];
    var currentPos = input[1].split(' ').map(Number);
    var curPosRow = currentPos[0];
    var curPosCol = currentPos[1];
    var sum = parseInt(matrix[curPosRow][curPosCol]);
    var visited = '';
    var broqch = 2;

    while (true) {
        var curJumpRC = input[broqch].split(' ').map(Number);
        var curJumpRow = curJumpRC[0];
        var curJumpCol = curJumpRC[1];
        var numOfJumps = 0;
        curPosRow = curPosRow + curJumpRow;
        curPosCol = curPosCol + curJumpCol;
        currentPos = [curPosRow, curPosCol];

        if (curPosRow >= rows || curPosCol >= rows || curPosRow < 0 || curPosCol < 0) {
            console.log('escaped ' + sum);
            break;
        }
        if (visited === 'v') {
            console.log('caught ' + numOfJumps);
            break;
        }

        sum += parseInt(matrix[Number(currentPos[0])][Number(currentPos[1])]);
        currentPos = 'v';
        numOfJumps++;
        broqch++;
        if (broqch === (numJumps + 1)) {
            broqch = 2;
        }
    }
}

var input = [
    '6 7 3',
    '0 0',
    '2 2',
    '-2 2',
    '3 -1'
];
Solve(input);
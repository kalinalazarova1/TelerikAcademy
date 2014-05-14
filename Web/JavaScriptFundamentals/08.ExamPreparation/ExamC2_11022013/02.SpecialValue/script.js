// 70/100 in BGCoder due to excess memory

function Solve(args) {
    var matrix = [];
    for (var i = 0; i < Number(args[0]) ; i++) {
        matrix.push(args[i + 1].split(', '));
    }
    var bestValue = -1;
    for (var start = 0; start < matrix[0].length; start++) {
        var r = 0;
        var path = 1;
        var specialValue = -1;
        var visited = [];
        for (var c = start; visited.indexOf(r + "-" + c) == -1;) {
            if (matrix[r][c] < 0) {
                specialValue = path + (-1) * matrix[r][c];
                if (specialValue > bestValue) bestValue = specialValue;
                break;
            }
            var prevCol = c;
            c = matrix[r][c];
            r++;
            if (r >= Number(args[0])) r %= Number(args[0]);
            path++;
            visited.push([r - 1] + "-" + [prevCol]);
        }
    }
    return bestValue;
}
function solve(args) {
    var terrain = args[0].split(', ');
    var sorted = args[0].split(', ').sort(function (x, y) { return x - y; });
    var bestJump = 0;
    for (var start = 0; start < terrain.length; start++) {
        if (terrain.length - sorted.indexOf(terrain[start]) <= bestJump) continue;
        for (var step = 1; step < terrain.length; step++) {
            var last = -1001;
            var jumps = 1;
            for (var i = start; ; jumps++) {
                last = terrain[i];
                i += step;
                if (i >= terrain.length) i %= terrain.length;
                if (terrain[i] - last <= 0) break;
            }
            if (jumps > bestJump) bestJump = jumps;
        }
    }
    return bestJump;
}

(function print() {
    var args = ['1, -2, -3, 4, -5, 6, -7, -8'];
    console.log(solve(args));
})();

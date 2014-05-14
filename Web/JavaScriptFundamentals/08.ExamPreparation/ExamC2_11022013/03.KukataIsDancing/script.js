function solve(args) {
    var field = [['RED', 'BLUE', 'RED'], ['BLUE', 'GREEN', 'BLUE'], ['RED', 'BLUE', 'RED']],
        r,
        c,
        dir,
        i,
        j,
        result = [];

    for (i = 1; i <= args[0]; i++) {
        dir = 0;
        r = 1;
        c = 1;
        for (j = 0; j < args[i].length; j++) {
            switch (args[i].charAt(j)) {
            case 'L':
                dir--;
                dir = (dir < 0 ? 3 : dir);
                break;
            case 'R':
                dir++;
                dir = dir % 4;
                break;
            case 'W':
                switch (dir) {
                case 0:
                    r--;
                    r = (r < 0 ? 2 : r);
                    break;
                case 1:
                    c++;
                    c = (c > 2 ? 0 : c);
                    break;
                case 2:
                    r++;
                    r = (r > 2 ? 0 : r);
                    break;
                case 3:
                    c--;
                    c = (c < 0 ? 2 : c);
                    break;
                }

                break;
            }
        }

        result.push(field[r][c]);
    }

    return result.join('\n');
}

(function print() {
    var args = ['5', 'WWRLLW','RWLW','WWL','W','LWWW'];
    console.log(solve(args));
})();

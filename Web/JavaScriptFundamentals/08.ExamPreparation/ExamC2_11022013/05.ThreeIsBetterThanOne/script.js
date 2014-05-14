// 0/100 in BGCoder time limits

function solve(args) {
    function firstTask(input) {
        var points = input.split(','),
            original = input.split(','),
            p = points.length - 1;
        points.sort(function (x, y) { return x - y; });
        while (true) {
            if (p < 0) {
                return -1;
            }

            if (points[p] <= 21) {
                if (p > 1) {
                    return points[p] === points[p - 1] ? -1 : original.indexOf(points[p]);
                }
                return original.indexOf(points[p]);
            }
            p++;
        }
    }

    function secondTask(c, f) {
        var cakes = c.split(','),
            p,
            bites = 0;
        cakes.sort(function (x, y) { return y - x; });
        for (p = 0; p < cakes.length; p++) {
            if (p % (Number(f) + 1) === 0) {
                bites += cakes[p] | 0;
            }
        }

        return bites;
    }

    function thirdTask(input) {
        var coins = input.split(' '),
            diff = [],
            count = 0,
            p;
        for (p = 0; p < 3; p++) {
            diff[p] = coins[p] - coins[p + 3];
        }
        if (diff[0] >= 0 && diff[1] >= 0 && diff[2] >= 0) {
            return 0;
        } else if (diff[0] < 0 && diff[1] < 0 && diff[2] < 0) {
            return -1;
        } else if (diff[0] >= 0 && diff[1] * diff[2] > 0 || diff[1] >= 0 && diff[0] * diff[2] > 0 || diff[2] >= 0 && diff[1] * diff[0] > 0) {      //two negative diff
            if (diff[0] >= 0) {
                while (diff[0] > 0 && (diff[1] < 0 || diff[2] < 0)) {
                    if (diff[0] > 0 && diff[1] < 0) {
                        diff[0]--;
                        diff[1] += 9;
                        count++;
                    }

                    if (diff[1] > 0 && diff[2] < 0) {
                        diff[1]--;
                        diff[2] += 9;
                        count++;
                    }
                }

                return diff[1] < 0 || diff[2] < 0 ? -1 : count;
            } else if (diff[1] >= 0) {
                while (diff[1] > 0 && (diff[0] < 0 || diff[2] < 0)) {
                    if (diff[1] >= 11 && diff[0] < 0) {
                        diff[1] -= 11;
                        diff[0]++;
                        count++;
                    }

                    if (diff[1] > 0 && diff[2] < 0) {
                        diff[1]--;
                        diff[2] += 9;
                        count++;
                    }
                }

                return diff[0] < 0 || diff[2] < 0 ? -1 : count;
            } else {
                while (diff[2] >= 11 && (diff[0] < 0 || diff[1] < 0)) {
                    if (diff[2] > 11 && diff[0] < 0) {
                        diff[2] -= 11;
                        diff[1]++;
                        count++;
                    }

                    if (diff[1] > 11 && diff[0] < 0) {
                        diff[1] -= 11;
                        diff[0]++;
                        count++;
                    }
                }

                return diff[0] < 0 || diff[1] < 0 ? -1 : count;
            }
        } else {
            if (diff[0] < 0) {
                while (diff[0] < 0 && (diff[1] >= 11 || diff[2] >= 11)) {
                    if(diff[1] >= 11){
                        diff[1] -= 11;
                        diff[0]++;
                        count++;
                    }

                    if(diff[2] > 11 && diff[1] < 11){
                        diff[2] -= 11;
                        diff[1]++;
                        count++;
                    }
                }

                return diff[0] < 0 ? -1 : count;
            } else if (diff[1] < 0) {
                while (diff[1] < 0 && (diff[0] > 0 || diff[2] >= 11)) {
                    if (diff[0] > 0) {
                        diff[0]--;
                        diff[1] += 9;
                        count++;
                    }
                    
                    if (diff[2] > 11 && diff[1] <= 0) {
                        diff[2] -= 11;
                        diff[1]++;
                        count++;
                    }
                }

                return diff[1] < 0 ? -1 : count;
            } else {
                while (diff[2] < 0 && (diff[0] > 0 || diff[1] > 0)) {
                    if (diff[1] > 0) {
                        diff[1]--;
                        diff[2] += 9;
                        count++;
                    }

                    if (diff[0] > 0 && diff[1] <= 0) {
                        diff[0]--;
                        diff[1] += 9;
                        count++;
                    }
                }

                return diff[2] < 0 ? -1 : count;
            }
        }
    }

    return firstTask(args[0]) + '\n' + secondTask(args[1], args[2]) + '\n' + thirdTask(args[3]);
}

(function print() {
    var args = ['1,2,3,3,2','1,1,1,5,1','3','1 100 12 5 53 33'];
    console.log(solve(args));
})();

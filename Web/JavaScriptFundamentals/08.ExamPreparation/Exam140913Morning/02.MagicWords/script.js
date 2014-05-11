function solve(args) {
    'use strict';
    var i,
        arr = [],
        max = 0,
        end,
        n = args[0] | 0;

    function swap(firstIndex, secondIndex) {
        var temp;
        temp = arr[secondIndex];
        arr[secondIndex] = arr[firstIndex];
        arr[firstIndex] = temp;
    }

    function print() {
        var result = "",
            j,
            len = arr.length;

        for (j = 0; j < max; j++) {
            for (i = 0; i < len; i++) {
                if (arr[i].length > j) {
                    result += arr[i].charAt(j);
                }
            }
        }

        return result;
    }

    for (i = 1; i <= n; i++) {
        arr.push(args[i]);
        max = Math.max(args[i].length, max);
    }

    for (i = 0; i < n; i++) {
        end = arr[i].length % (n + 1);
        if (i < end) {
            swap(i, end - 1);
        } else if (i > end) {
            swap(i, end);
        }
    }

    return print(arr);
}

function test() {
    'use strict';
    var args = ["2", "you", "win"];
    console.log(solve(args));
}
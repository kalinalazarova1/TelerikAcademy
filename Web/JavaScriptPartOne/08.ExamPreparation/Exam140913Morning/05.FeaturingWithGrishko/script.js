function solve(args) {
    'use strict';
    
    var comb = [],
        letters = [],
        freq = [],
        counter = 0,
        i,
        j = 0;

    for (i = 0; i < args[0].length; i++) {
        if (letters.indexOf(args[0].charAt(i)) >= 0) {
            freq[letters.indexOf(args[0].charAt(i))]++;
        } else {
            letters[j] = args[0].charAt(i);
            freq[j] = 1;
            j++;
        }
    }

    getComb(0);

    function getComb(startIndex) {
        var p;
        if (startIndex >= args[0].length) {
            counter++;
            return;
        }
        for (p = 0;  p < letters.length; p++) {
            if ((startIndex === 0 || comb[startIndex - 1] != letters[p]) && (freq[p] > 0)) {
                freq[p]--;
                comb[startIndex] = letters[p];
                getComb(startIndex + 1);
                freq[p]++;
            }
        }
    }

    return counter;
}

function test() {
    'use strict';
    var args = ["nopqrstuvw"];
    console.log(solve(args));
}
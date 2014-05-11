function solve(args) {
    'use strict';
    var digits = ["CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA"],
        i,
        pow = 1,
        result = 0;

    for (i = args[0].length - 1; i >= 0; i -= 3, pow *= 13) {
        result += digits.indexOf(args[0].charAt(i - 2) + args[0].charAt(i - 1) + args[0].charAt(i)) * pow;
    }
    return result;
}

function test() {
    'use strict';
    var args = ["TELERIK-ACADEMY"];
    console.log(solve(args));
}
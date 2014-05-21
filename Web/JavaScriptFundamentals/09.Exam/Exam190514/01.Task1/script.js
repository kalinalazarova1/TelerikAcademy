function solve(args) {
    var s = args[0] | 0;
    var count = 0;
    var allWheels = 0;
    var w = [4, 10, 3];

    for (var i = 0; i <= 50; i++) {
        for (var j = 0; j <= 20; j++) {
            for (var k = 0; k < 67; k++) {
                allWheels = w[0] * i + w[1] * j + w[2] * k;
                if (allWheels === s) {
                    count++;
                }
            }
        }
    }
    return count;
}
var args = ['40'];
console.log(solve(args));
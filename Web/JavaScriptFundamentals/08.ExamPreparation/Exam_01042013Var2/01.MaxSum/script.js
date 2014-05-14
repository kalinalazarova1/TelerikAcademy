function Solve(args) {
    var arr = args.slice(1),
        n = args[0] | 0,
        i,
        j,
        sum,
        maxSum = arr[0] | 0;
    for (i = 0; i < n; i++) {
        sum = 0;
        for (j = i; j < n; j++) {
            sum += (arr[j] | 0);
            maxSum = Math.max(sum, maxSum);
        }
    }
    return maxSum;
}


(function print() {
    var args = ['9', '-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6'];
    console.log(Solve(args));
})();
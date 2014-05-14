function Solve(args) {
    var seqCount = 0,
        i;
    for (i = 2; i < args.length; i++) {
        if (Number(args[i]) < Number(args[i - 1])) { // finds the count of the interruptions in the sequences
            seqCount++;                             
        }
    }
    return seqCount === 0 ? 0 : seqCount + 1;       // the count of the sequences is equal to the count of interruptions plus one or if no interruptions then the count of the sequences is zero
}


(function print() {
    var args = ['7', '1', '2', '-3', '4', '4', '0', '1'];
    console.log(Solve(args));
})();
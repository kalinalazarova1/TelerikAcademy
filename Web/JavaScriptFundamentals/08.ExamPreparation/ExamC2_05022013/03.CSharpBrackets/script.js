function solve(args) {
    var n = args[0] | 0,
        indent = args[1],
        i,
        j,
        countOpen = 0,
        line = '',
        sline,
        result = '';

    function repeat(string, count) {
        return (new Array(count + 1)).join(string);
    }

    for (i = 2; i < n + 2; i++) {

        line = args[i].replace(/\s+/g, ' ').trim();
        line = line.replace(/{/g, 'б{б');
        line = line.replace(/}/g, 'б}б');
        sline = line.split('б');

        for (j = 0; j < sline.length; j++) {
            if (sline[j].trim() === '{') {
                result += repeat(indent, countOpen) + sline[j].trim() + '\n';
                countOpen++;
            } else if (sline[j].trim() === '}') {
                countOpen--;
                result += repeat(indent, countOpen) + sline[j].trim() + '\n';
            } else if (sline[j].trim() !== '') {
                result += repeat(indent, countOpen) + sline[j].trim() + '\n';
            }
        }
    }
    return result;
}

(function print() {
    var args = ['2','..','    { a()  ){sa}{dsdas}}{!{{adasds{a}}','}{}}'];
    console.log(solve(args));
})();
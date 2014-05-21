function solve(args) {
    var n = args[0] | 0,
        maxWidth = args[1] | 0,
        all = args.slice(2).join(' '),
        words = all.split(' '),
        i,
        j,
        result = [],
        spacesCount = 0,
        wordsCount = 0,
        currentWidth = 0;

    function repeat(string, count) {
        return (new Array(count + 1)).join(string);
    }

    function clean(arr) {
        var p,
            arrNew = [];
        for (p = 0; p < arr.length; p++) {
            if (arr[p] !== '') {
                arrNew.push(arr[p]);
            }
        }
        return arrNew;
    }

    words = clean(words);
    for (i = 0; i <= words.length; i++) {
        if (i !== words.length && currentWidth + wordsCount + words[i].length  <= maxWidth) {
            currentWidth += words[i].length;
            wordsCount++;
        } else if (wordsCount === 1) {
            result += words[i - 1] + '\n';
            currentWidth = (words[i] || '').length;
        } else {
            spacesCount = ((maxWidth - currentWidth) / (wordsCount - 1)) | 0;

            for (j = 0; j < wordsCount; j++) {
                if (j !== wordsCount - 1) {
                    result += words[j + i - wordsCount] + repeat(' ', spacesCount);
                } else {
                    result += words[j + i - wordsCount];
                }
                if (j < (maxWidth - currentWidth) % (wordsCount - 1)) {
                    result += ' ';
                }
            }

            result += '\n';
            wordsCount = 1;
            currentWidth = (words[i] || '').length;
        }
    }

    result = result.substring(0, result.length - 1);
    return result;
}

(function print() {
    var args = ['5','20','We happy few        we band','of brothers for he who sheds','his blood','with','me shall be my brother'];
    console.log(solve(args));
})();
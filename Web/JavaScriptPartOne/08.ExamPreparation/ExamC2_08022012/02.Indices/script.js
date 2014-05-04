function print() {

    var args = ["6", "0"];
    console.log(Solve(args));
}


function Solve(args) {
    var arr = args[1].split(' ');
    var result = [];
    var currentIndex = 0;
    var repeatIndex = -1;

    while (currentIndex < arr.length && currentIndex >= 0) {
        if (result.indexOf(currentIndex) >= 0) {
            repeatIndex = result.indexOf(currentIndex);
            break;
        }
        result.push(currentIndex);
        result.push(' ');
        currentIndex = Number(arr[currentIndex]);
    }
    if (repeatIndex > 0) {
        result[repeatIndex - 1] = '(';
        result[result.length - 1] = ')';
    }
    else if (repeatIndex < 0) {
        result[result.length - 1] = '';
    }
    else {
        result[result.length - 1] = ')';
    }

    return repeatIndex !== 0 ? result.join('') : '(' + result.join('');
}
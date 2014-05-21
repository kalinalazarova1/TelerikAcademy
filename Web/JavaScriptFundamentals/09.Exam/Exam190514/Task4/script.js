function s(a) {
    var x = a[0] | 0,
        y = a[1] | 0;
    return x > 0 ? y > 0 ? 1 : 3 : y > 0 ? 0 : 2;
}

var a = [-1, -2];
console.log(s(a));
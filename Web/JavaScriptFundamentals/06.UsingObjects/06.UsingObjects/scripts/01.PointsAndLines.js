// 1.Write functions for working with shapes in  standard Planar coordinate system
// Points are represented by coordinates P(X, Y)
// Lines are represented by two points, marking their beginning and ending
// L(P1(X1,Y1),P2(X2,Y2))
// Calculate the distance between two points
// Check if three segment lines can form a triangle

window.onload = function () {
    document.getElementById("number-input1").focus();
};

function Point(x, y) {
    this.x = x;
    this.y = y;
    this.toString = function () { return "Point (" + this.x + ", " + this.y + ")"; };
}

function calcDistance(point1, point2) {
    return Math.sqrt((point1.x - point2.x) * (point1.x - point2.x) + (point1.y - point2.y) * (point1.y - point2.y));
}

function Line(point1, point2) {
    this.start = point1;
    this.end = point2;
    this.length = function () { return calcDistance(this.start, this.end); };
    this.toString = function () { return "Line (" + this.start + ", " + this.end + ")"; };
}

function formsTriangle(segment1, segment2, segment3) {
    var a = segment1.length,
        b = segment2.length,
        c = segment3.length;
    return ((a + b) > c) && ((a + c) > b) && ((b + c) > a);
}

function pointsAndLinesTest() {
    var first = jsConsole.read("input#number-input1").split(' '),
        second = jsConsole.read("input#number-input2").split(' '),
        third = jsConsole.read("input#number-input3").split(' '),
        point1start = new Point(first[0], first[1]),
        point1end = new Point(first[2], first[3]),
        point2start = new Point(second[0], second[1]),
        point2end = new Point(second[2], second[3]),
        point3start = new Point(third[0], third[1]),
        point3end = new Point(third[2], third[3]),
        line1 = new Line(point1start, point1end),
        line2 = new Line(point2start, point2end),
        line3 = new Line(point3start, point3end);
    jsConsole.writeLine("The distance between " + point1start + " and " + point1end + " is: " + calcDistance(point1start, point1end));
    jsConsole.writeLine("The distance between " + point2start + " and " + point2end + " is: " + calcDistance(point2start, point2end));
    jsConsole.writeLine("The distance between " + point3start + " and " + point3end + " is: " + calcDistance(point3start, point3end));
    jsConsole.writeLine("The three segments of the lines: " + line1 + " " + line2 + " " + line3 + " " + (formsTriangle(line1, line2, line3) ? " can " : " can not ") + "form triangle.");
}

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        if (document.activeElement === document.getElementById("number-input1")) {
            document.getElementById("number-input2").focus();
        } else if (document.activeElement === document.getElementById("number-input2")) {
            document.getElementById("number-input3").focus();
        } else {
            pointsAndLinesTest();
        }
    }
}
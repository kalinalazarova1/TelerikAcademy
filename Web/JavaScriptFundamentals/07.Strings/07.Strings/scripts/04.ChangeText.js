// 4.You are given a text. Write a function that changes the text in all regions:
// <upcase>text</upcase> to uppercase.
// <lowcase>text</lowcase> to lowercase
// <mixcase>text</mixcase> to mix casing(random)
// Regions can be nested

window.onload = function () {
    document.getElementById("input1").focus();
};

String.prototype.toRandomCase = function () {
    var ran = Math.random();
    if (ran > 0.5) {
        return this.toUpperCase();
    }
    return this.toLowerCase();
};

function changeText(text) {
    var result = "",
        tags = [],
        state = "plain",
        i;
    for (i = 0; i < text.length; i++) {
        if (text[i] === '<') {
            switch (text[i + 1]) {
            case 'u':
                tags.push(state);
                state = "upper";
                break;
            case 'l':
                tags.push(state);
                state = "lower";
                break;
            case 'm':
                tags.push(state);
                state = "random";
                break;
            case '/':
                if (tags.length) {
                    state = tags.pop();
                } else {
                    state = "plain";
                }
                break;
            }
            while (text[i] !== '>') {
                i++;
            }
        } else {
            switch (state) {
            case "plain":
                result += text[i];
                break;
            case "upper":
                result += text[i].toUpperCase();
                break;
            case "lower":
                result += text[i].toLowerCase();
                break;
            case "random":
                result += text[i].toRandomCase();
                break;
            }
        }
    }
    return result;
}

function changeTextTest() {
    var text = jsConsole.read("input#input1");
    jsConsole.writeLine("The result is: " + changeText(text));
}

Array.prototype.remove = function (value) {
    var i = 0;
    while (i < this.length) {
        if (this[i] === value) {
            this.splice(i, 1);
        } else {
            i++;
        }
    }
    return this;
};

function onEnterKeyPressed(event) {
    if (event.keyCode === 13) {
        changeTextTest();
    }
}
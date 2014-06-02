// 1.Write a script that selects all the div nodes that are directly inside other div elements
// Create a function using querySelectorAll()
// Create a function using getElementsByTagName()

function selectByTagName() {
    var divs = document.getElementsByTagName('div'),
        i,
        len;
    for (i = 0, len = divs.length; i < len; i++) {
        if (divs[i].parentNode.nodeName === 'DIV') {
            divs[i].style.backgroundColor = '#00ff90';
        }
    }
}

function selectByQuerySelector() {
    var divs = document.querySelectorAll('div'),
        i;
    for (i = 0; i < divs.length; i++) {
        if (divs[i].parentNode.nodeName === 'DIV') {
            divs[i].style.backgroundColor = '#00ff90';
        }
    }
}

function undoStyle() {
    var divs = document.getElementsByTagName('div'),
        i,
        len;
    for (i = 0, len = divs.length; i < len; i++) {
        divs[i].style.backgroundColor = '#ff6a00';
    }
}
// 4.*Write a script that shims querySelector and querySelectorAll in older browsers

if (!document.querySelector) {
    document.querySelector = function (selector) {
        return Sizzle(selector)[0];
    };
}

if (!document.querySelectorAll) {
    document.querySelectorAll = function (selector) {
        return Sizzle(selector);
    };
}

var container = document.querySelector('#wrapper').style.border = "2px solid red";
var all = document.querySelectorAll('div.foo');
for (var i = 0, len = all.length; i < len; i++) {
    all[i].style.left = 50 + i * 150 + "px";
    all[i].innerHTML = 'This is the content of div number ' + (i + 1);
}
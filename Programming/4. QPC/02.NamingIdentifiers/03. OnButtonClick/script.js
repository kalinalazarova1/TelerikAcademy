// 3. Refactor the following examples to produce code with well-named identifiers in JavaScript

function onButtonClick() {
    var currentWindow = window,
        currentBrowser = currentWindow.navigator.appCodeName,
        isMozilla = currentBrowser === "Mozilla";
    if (isMozilla) {
        alert("Yes");
    } else {
        alert("No");
    }
}
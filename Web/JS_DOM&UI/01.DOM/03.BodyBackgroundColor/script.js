// 3.Crеate a function that gets the value of <input type="color"> and sets the background of the body to this value

function changeBackground() {
    var color = document.querySelector('input[type="color"]').value;
    document.body.style.backgroundColor = color;
}
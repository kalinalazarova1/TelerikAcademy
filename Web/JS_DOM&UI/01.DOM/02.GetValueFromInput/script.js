// 2.Create a function that gets the value of <input type="text"> ands prints its value to the console

function getValue() {
    var content = document.querySelector('input[type = "text"]').value;
    console.log(content);
}
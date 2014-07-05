// 1.Implement a ComboBox control (like a dropdown list)
// The ComboBox holds a set of items (an array)
// Initially only a single item, the selected item, is visible (the ComboBox is collapsed)
// When the selected item is clicked, all other items are shown (the ComboBox is expanded)
// If an item is clicked, it becomes the selected item and the ComboBox collapses
// Each of the items in a ComboBox can contain any valid HTML code
// Implement a ComboBox control (like a dropdown list)
// Use RequireJS and handlebars.js
// jQuery is not obligatory (use it if you will)


///<reference path="libs/require.js" />
///<reference path="libs/jquery.js" />
///<reference path="controls.js" />

require(['controls', 'libs/jquery'], function (controls) {
    var people = [{ id: 1, name: "Doncho Minkov", age: 25, avatarUrl: "images/doncho.jpg" },
        { id: 2, name: "Nikolay Kostov", age: 24, avatarUrl: "images/niki.jpg" },
        { id: 3, name: "Ivaylo Kenov", age: 22, avatarUrl: "images/ivo.jpg" },
        { id: 4, name: "Todor Stoyqnov", age: 26, avatarUrl: "images/todor.jpg" }];
    var comboBox =  controls.ComboBox(people);
    var template = $("#person-template").html();
    var comboBoxHtml = comboBox.render(template);
    var container = document.getElementById('container');
    container.innerHTML = comboBoxHtml;
});
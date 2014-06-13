// 1.Create a jQuery plugin for creating dropdown list
// By given the following:
// <select id="dropdown">
// <option value="1">One</option>
// <option value="2">Two</option>
// </select>
// $('#dropdown').dropdown()
// Produces the following HTML:
// <select id="dropdown" style="display: none">…</select>
// <div class="dropdown-list-container">
//   <ul class="dropdown-list-options">
//     <li class="dropdown-list-option" data-value="0">One</li>
//     …
//   </ul>
// </div>
// And make it work as SELECT node
// Selecting an one of the generated LI nodes, selects the corresponding OPTION node
// So $('#dropdown:selected') works

/// <reference path="jquery-1.11.1.js" />

(function ($) {
    $.fn.dropdown = function () {
        var $this,
            $options,
            $dropdown,
            $current,
            i;

        function onClick() {
            var childIndex = ($(this).attr('data-value') | 0) + 1;
            $('#dropdown')
                .find('option')
                .removeAttr('selected');
            $('#dropdown :nth-child(' + childIndex + ')')
                .attr('selected', 'selected');
            // click on item in the list to see the result in the console
            console.log($('#dropdown option:selected').text());
        }

        $('#dropdown').css('display', 'none');
        $this = $(this);
        $options = $('<ul>')
                .addClass('dropdown-list-options');
        $dropdown = $('<div>')
            .addClass('dropdown-list-container')
            .append($options);
        $current = $this.children().first();
        for (i = 0; i < $this.children().length; i++) {
            $('<li>')
                .addClass('dropdown-list-option')
                .text($current.text())
                .attr('data-value', i)
                .appendTo($options);
            $current = $current.next();
        }
        $options.on('click', 'li', onClick);
        $dropdown.appendTo($('body'));
        return this;
    };
}(jQuery));
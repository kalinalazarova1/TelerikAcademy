// 5.*Implement a GridView control
// Rows can be added dynamically
// A header row can be added dynamically
// Each GridView can have at most one header row
// Each row can have  a nested GridView
// Each GridView can have at most one nested GridView

var grid = (function () {
    var $table;
    function createGrid() {
        $table = $('<table>');
        return $table;
    }

    return {
        create: createGrid
    };
})();

(function ($) {
    $.fn.addRow = function () {
        var $this,
            i,
            $row = $('<tr>');
        $this = $(this);

        for (i = 0; i < arguments.length; i++) {
            $('<td>')
                .text(arguments[i])
                .appendTo($row);
        }
        $this.append($row);
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.addHeader = function () {
        var $this,
            i,
            $header = $('<tr>');
        $this = $(this);
        if ($this.find('th').length === 0) {
            for (i = 0; i < arguments.length; i++) {
                $('<th>')
                    .text(arguments[i])
                    .appendTo($header);
            }
            $this.prepend($header);
        }
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.addNestedGrid = function ($nested, colspan) {
        var $this = $(this);
        if ($this.find('table').length === 0) {
            $this.append($('<tr>').append($('<td>').attr('colspan', colspan).append($nested)));
        }
        return this;
    };
}(jQuery));

(function ($) {
    $.fn.render = function (selector) {
        var $this = $(this);
        $(selector).append($this);
        return this;
    };
}(jQuery));
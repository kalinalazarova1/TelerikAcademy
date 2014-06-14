// 4.*Extend the previous task to set the template inside the DOM element, instead of setting it with data-template

/// <reference path="jquery-1.11.1.js" />
/// <reference path="handlebars-v1.3.0.js" />

(function ($) {
    $.fn.listview = function (collection) {
        var $this = $(this);
        var template = Handlebars.compile($this.html());
        $this.html(template(collection[0]));
        for (var i = 1; i < collection.length; i++) {
            $this.html($this.html() + template(collection[i]));
        }
        return this;
    };
}(jQuery));
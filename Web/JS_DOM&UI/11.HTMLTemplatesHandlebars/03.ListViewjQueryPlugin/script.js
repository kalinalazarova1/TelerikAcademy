// 3.*Create a jQuery plugin for ListView
// Apply a template for each item of a collection
// Using the data-template attribute set the ID of the template to use for the items
// Must work with different collections and templates

/// <reference path="jquery-1.11.1.js" />
/// <reference path="handlebars-v1.3.0.js" />

(function ($) {
    $.fn.listview = function (collection) {
        var $this = $(this);
        var templateId = $this.attr('data-template');
        var template = Handlebars.compile($('#' + templateId).html());
        for (var i = 0; i < collection.length; i++) {
            $this.html($this.html() + template(collection[i]));
        }
        return this;
    };
}(jQuery));
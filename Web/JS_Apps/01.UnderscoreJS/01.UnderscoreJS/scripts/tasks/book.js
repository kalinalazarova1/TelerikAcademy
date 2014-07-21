/// <reference path="../libs/require.js" />

define(function () {
    'use strict';
    var Book;
    Book = (function () {
        function Book(title, author) {
            this.title = title;
            this.author = author;
        }

        return Book;
    }());

    return Book;
});

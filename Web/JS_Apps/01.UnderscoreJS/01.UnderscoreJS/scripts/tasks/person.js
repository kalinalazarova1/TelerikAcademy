/// <reference path="../libs/require.js" />

define(function () {
    'use strict';
    var Person;
    Person = (function () {
        function Person(fname, lname) {
            this.fname = fname;
            this.lname = lname;
        }

        return Person;
    }());

    return Person;
});

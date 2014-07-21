/// <reference path="../libs/require.js" />

define(function () {
    'use strict';
    var Animal;
    Animal = (function () {
        function Animal(name, type, legs) {
            this.name = name;
            this.type = type;
            this.legs = legs;
        }

        return Animal;
    }());

    return Animal;
});

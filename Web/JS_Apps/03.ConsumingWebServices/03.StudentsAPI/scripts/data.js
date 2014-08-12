/// <reference path="libs/require.js"/>
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="libs/jquery.js"/>

define(['libs/handlebars-v1.3.0', 'libs/jquery'], function () {
    'use strict';

    Handlebars.registerHelper("increment", function (num) {
        return num + 1;
    });

    var studentsTable;
    studentsTable = (function () {
        function getCollectionView(collection) {
            var collectionTemplate = Handlebars.compile($('#students-template').html());
            return collectionTemplate(collection);
        }

        return {
            getCollectionView: getCollectionView
        };
    }());

    return studentsTable;
});
/// <reference path="libs/require.js"/>
/// <reference path="libs/handlebars-v1.3.0.js" />
/// <reference path="libs/jquery.js"/>

define(['handlebars', 'jquery'], function () {
    'use strict';

    var chatContent;
    chatContent = (function () {
        function getCollectionView(collection) {
            var collectionTemplate = Handlebars.compile($('#chat-template').html());
            return collectionTemplate(collection);
        }

        return {
            getMessagesView: getCollectionView
        };
    }());

    return chatContent;
});
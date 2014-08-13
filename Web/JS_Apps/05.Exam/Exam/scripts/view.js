/// <reference path="../libs/require.js" />
/// <reference path="../libs/handlebars.js" />


define(['handlebars'], function (handlebars) {
    'use strict';
        var view = (function () {
                
        function getHTML(template, collection) {
            var compTemplate = Handlebars.compile(template);
            return compTemplate(collection);
        }

        function getPostsHTML(response) {
            var template = document.getElementById('posts-template');
            var test = template.innerHTML;
            return getHTML(template.innerHTML, response);
        }

        function initial() {
            $('aside').children().hide();
            $('#main-register-btn').show();
            $('#main-login-btn').show();
        }

        function logedin(user) {
            $('#logout-wrapper').show();
            $('#logout-wrapper').html(user + ' : <strong>Logged In </strong><button id="logout">LogOut</button>');
        }

        return {
            posts: getPostsHTML,
            initial: initial,
            logedin: logedin
        };
    }());

    return view;
});
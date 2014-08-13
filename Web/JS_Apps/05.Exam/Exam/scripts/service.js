/// <reference path="xhr.js" />
/// <reference path="libs/require.js" />
/// <reference path="../libs/cryptojs-sha1.js" />

define(['xhr', 'sha1'], function (xhr, sha1) {
    'use strict';
    var service = (function () {
        var url = 'http://localhost:3000';
        return {
            register: function (name, pass) {
                return xhr.postJSON(url + '/user', {
                    username: name,
                    authCode: CryptoJS.SHA1(name + pass).toString()
                });
            },
            login: function (name, pass) {
                return xhr.postJSON(url + '/auth', {
                    username: name,
                    authCode: CryptoJS.SHA1(name + pass).toString()
                });
            },
            logout: function () {
                return xhr.putJSON(url + '/user', {
                    'X-SessionKey': localStorage.getItem('xSessionKey')
                });
            },
            posts: function (user, pattern) {
                if (!user && !pattern) {
                    return xhr.getJSON(url + '/post');
                } else if (!pattern) {
                    return xhr.getJSON(url + '/post?user=' + user);
                } else if (!user) {
                    return xhr.getJSON(url + '/post?pattern=' + pattern);
                } else {
                    return xhr.getJSON(url + '/post?pattern=' + pattern + '&user=' + user);
                }
            },
            create: function (title, body) {
                return xhr.postJSON(url + '/post', {
                    title: title,
                    body: body
                }, {
                    'X-SessionKey': localStorage.getItem('xSessionKey')
                });
            }
        };
    }());

    return service;
});
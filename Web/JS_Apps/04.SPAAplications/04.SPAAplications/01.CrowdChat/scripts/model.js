///<reference path="libs/require.js" />
///<reference path="libs/jquery.js" />

define(['jquery'], function ($) {
    'use strict';
    var httpJQueryRequest;
    httpJQueryRequest = (function () {

        function requestJSON(method, url, requestData) {
            if (method === 'POST') {
                var data = JSON.stringify(requestData);
            }

            return $.ajax(url, {
                type: method,
                data: requestData,
                dataType: "json",
                timeout: 5000
            }).promise();
        }

        return {
            getJSON: function (url) {
                return requestJSON('GET', url, null);
            },
            postJSON: function (url, requestData) {
                return requestJSON('POST', url, requestData);
            }
        };
    }());

    return httpJQueryRequest;
});
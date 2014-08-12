///<reference path="libs/require.js" />
///<reference path="libs/jquery.js" />

define(['libs/jquery'], function () {
    'use strict';
    var httpJQueryRequest;
    httpJQueryRequest = (function () {

        function requestJSON(method, url, requestData, headers) {
            if (method === 'POST') {
                var data = JSON.stringify(requestData);
            }

            return $.ajax(url, {
                type: method,
                data: requestData,
                headers: headers,
                dataType: "json",
            }).promise();
        }

        return {
            getJSON: function (url, headers) {
                return requestJSON('GET', url, null, headers);
            },
            postJSON: function (url, requestData, headers) {
                return requestJSON('POST', url, requestData, headers);
            }
        };
    }());

    return httpJQueryRequest;
});
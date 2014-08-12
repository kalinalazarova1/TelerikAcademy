///<reference path="libs/require.js" />
///<reference path="libs/q.js" />

define(['libs/jquery', 'libs/q'], function ($, Q) {
    'use strict';
    var httpRequest;
    httpRequest = (function () {
        
        function requestJSON(method, url, requestData, headers) {
            var httpRequest;
            if (window.XMLHttpRequest) {
                httpRequest = new XMLHttpRequest();
            } else if (window.ActiveXObject) {
                try {
                    httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
                }
                catch (e) {
                    httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
                }
            }

            var deferred = Q.defer();
            if (method === 'POST') {
                var data = JSON.stringify(requestData);
            }
            httpRequest.open(method, url, true);
            httpRequest.setRequestHeader("Content-type", "application/json");
            httpRequest.setRequestHeader("Accept", "application/json");
            for (var index in headers) {
                httpRequest.setRequestHeader(index, headers[index]);
            } 

            httpRequest.onreadystatechange = function () {
                if (httpRequest.readyState === 4) {
                    var statusType = Math.floor(httpRequest.status / 100);
                    if (statusType === 2) {
                        deferred.resolve(httpRequest.responseText);
                    } else {
                        deferred.reject('Unable to make ' + method + ' request!');
                    }
                }
            };
            httpRequest.send(data);
            return deferred.promise;
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

    return httpRequest;
});

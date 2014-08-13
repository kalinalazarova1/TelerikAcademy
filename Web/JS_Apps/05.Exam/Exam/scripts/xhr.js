define(['Q'], function (Q) {
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
            var data;
            if (method === 'POST') {
                 data = JSON.stringify(requestData);
            }
            httpRequest.open(method, url, true);
            httpRequest.setRequestHeader("content-type", "application/json");
            httpRequest.setRequestHeader("accept", "application/json");
            if (headers) {
                for (var index in headers) {
                    httpRequest.setRequestHeader(index, headers[index]);
                }
            }
            
            httpRequest.onreadystatechange = function () {
                if (httpRequest.readyState === 4) {
                    var statusType = Math.floor(httpRequest.status / 100);
                    if (statusType === 2) {
                        deferred.resolve(httpRequest.responseText);
                    } else {
                        deferred.reject(httpRequest.responseText);
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
            },
            putJSON: function (url, headers) {
                return requestJSON('PUT', url, null, headers)
            }
        };
    }());

    return httpRequest;
});

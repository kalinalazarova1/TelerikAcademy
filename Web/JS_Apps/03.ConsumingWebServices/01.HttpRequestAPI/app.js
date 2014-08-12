///<reference path="libs/require.js" />
///<reference path="libs/jquery.js" />
///<reference path="xhr.js" />

require(['xhr', 'jQueryXhr', 'libs/jquery'], function (httpRequest, jQueryHttpRequest) {
    'use strict';
    var students = [{
        name: 'gumble',
        grade: 2
    }, {
        name: 'darwin',
        grade: 1
    }, {
        name: 'richard',
        grade: 12
    }, {
        name: 'penny',
        grade: 2
    }, {
        name: 'sassy',
        grade: 2
    }];

    var url = 'http://localhost:3000/students';
    var url1 = 'http://localhost:3000/no_students'; //for fail tests
    var customHeaders = {
        'X-Requested-with': 'some value'
    };

    function error(err) {
        var msg = 'Error: ' + err;
        console.log(msg);
        $('#result').html(msg);
    }

    httpRequest.postJSON(url, students[0])
        .then(httpRequest.postJSON(url, students[1]), error)
        .then(httpRequest.postJSON(url, students[2], customHeaders), error);
  
    httpRequest.getJSON(url, customHeaders)
        .then(function (data) {
            var students = JSON.parse(data).students;
            var wrapper = $('<div>');
            for (var i = 0; i < students.length; i++) {
                $('<p>')
                    .html('ID: ' + students[i].id + '; Name: ' + students[i].name + '; Grade: ' + students[i].grade)
                    .appendTo(wrapper);
            }
            $('#result').append(wrapper);
        }, error);

    jQueryHttpRequest.postJSON(url, students[3])
        .then(jQueryHttpRequest.postJSON(url, students[4]), error);

    jQueryHttpRequest.getJSON(url, customHeaders)
        .done(function (data) {
            var students = data.students;
            var wrapper = $('<div>');
            for (var i = 0; i < students.length; i++) {
                $('<p>')
                    .html('ID: ' + students[i].id + '; Name: ' + students[i].name + '; Grade: ' + students[i].grade)
                    .appendTo(wrapper);
            }
            $('#jq-result').append(wrapper);
        })
        .fail(error);

    
});
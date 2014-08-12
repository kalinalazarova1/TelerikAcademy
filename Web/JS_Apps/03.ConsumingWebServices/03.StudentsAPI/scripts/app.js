/// <reference path="xhr.js" />
/// <reference path="libs/jquery.js" />
/// <reference path="data.js" />
/// <reference path="libs/require.js"/>

require(['xhr', 'data', 'libs/jquery'], function (xhr, data) {
    'use strict';
    var url = 'http://localhost:3000/students';

    function loadData() {
        xhr.getJSON(url)
            .done(function (response) {
                $('#result').html(data.getCollectionView(response));
            })
            .fail(function (response) {
                $('#result').html('Error: Could not load data!');
            });
    }

    loadData();

    $('#result').on('click', 'button', function () {
        var studentId = $(this).data('id');
        $.ajax({
            url: url + '/' +studentId + '/',
            type: 'POST',
            timeout: 5000,
            data: { _method: 'delete' }
        }).promise()
            .done(loadData());
    });

    $('#add-student').on('click', 'button', function (ev) {
        var name = $('#add-student #name').val();
        var grade = $('#add-student #grade').val();
        xhr.postJSON(url, {
            name: name,
            grade: grade
        })
    });
});
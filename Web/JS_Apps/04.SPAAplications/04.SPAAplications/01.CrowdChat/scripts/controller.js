///<reference path="libs/require.js" />
///<reference path="libs/jquery.js" />

define(['model', 'view', 'jquery'], function (model, view) {
    'use strict';
    var controller;
    controller = (function () {

        var url = 'http://crowd-chat.herokuapp.com/posts';
        var username;

        function toSaveString(str) {            // this function is not really needed because the validation is done by the server
            str = str.replace(/</g, '&lt;');
            str = str.replace(/>/g, '&gt;');
            return str;
        }

        function loadData() {
            model.getJSON(url)
                .done(function (response) {
                    var messages = { posts: response };
                    $('#content').html(view.getMessagesView(messages));
                })
                .fail(function (response) {
                    $('#content').html('Error: Could not load data!');
                });
            setTimeout(loadData, 10000);
        }

        $('#chat').hide();

        $('#login button').on('click', function () {
            var $this = $(this);
            username = toSaveString($this.prev('input').val());
            $this.parent('#login').hide();
            $('#chat').show();
            $('#content').scrollTop($('#content').prop('scrollHeight'));
            event.preventDefault();
        })

        $('#send').on('click', function () {
            var msg = toSaveString($(this).prev('input').val());
            $(this).prev('input').val('');
            var data = {
                user: username,
                text: msg
            }
            model.postJSON(url, data)
                .done(loadData)
                .fail(function (response) {
                    $('#content').html('Error: Could not load data!');
                });
        });

        

        return {
            run: loadData,
            toSaveString: toSaveString
        };
    }());

    return controller;
});
/// <reference path="libs/jquery.js" />
/// <reference path="libs/require.js" />
/// <reference path="viewController.js" />

define(['view', 'service', 'underscore', 'jquery'], function (view, service) {
    var controller = (function () {
        var currentPage = 0;

        function error(err) {
            var parsed = JSON.parse(err);
            alert('Error: ' + parsed.message);
        }

        function sortPosts(unsorted, by, method) {
            var sorted;
             
            if (method === 'ascending') {
                sorted = _.chain(unsorted)
                        .sortBy(by)
                        .value();
            } else {
                sorted = _.chain(unsorted)
                        .sortBy(by)
                        .reverse()
                        .value();
            }

            return sorted;
        }

        function loadPosts() {
            var user = $('#user').val().toLocaleLowerCase(),
                pattern = $('#pattern').val().toLocaleLowerCase();
            service.posts(user, pattern)
                .then(function (response) {
                    var unsorted = JSON.parse(response),
                        method = $("input[type='radio'][name='sort-method']:checked").val(),
                        by = $("input[type='radio'][name='sort-by']:checked").val(),
                        count = $("input#pages").val() || unsorted.length;
                    if (count > unsorted.length) {
                        count = unsorted.length;
                    }
                    if (currentPage > Math.ceil(unsorted.length / count - 1)) {
                        currentPage = Math.ceil(unsorted.length / count - 1);
                    }
                   unsorted = _.chain(unsorted)
                    .rest(currentPage * count)
                    .first(count);
                    var sorted = sortPosts(unsorted, by, method);
                    var posts = view.posts({ posts: sorted});
                    $('#content').html(posts);
                }, error);
        }

        function registered(user) {
            alert('User ' + user + ' successfully registered!');
            view.initial();
        }

        function sendPost() {
            var title = $('#post-title-input').val(),
                body = $('#post-body-input').val();
            if (localStorage.getItem('xUsername') && localStorage.getItem('xSessionKey')) {
                service.create(title, body)
                    .then(function () {
                        $('#post-title-input').val(''),
                        $('#post-body-input').val('');
                    }, error)
                    .then(loadPosts);
            } else {
                alert('You must be logged in to create post.')
            }
        }

        function loggedIn(response) {
            var data = JSON.parse(response);
            localStorage.setItem('xSessionKey', data.sessionKey);
            var user = data.username;
            localStorage.setItem('xUsername', user);
            
            view.initial();
            view.logedin(user);
            $('#logout').on('click', function () {
                service.logout()
                .then(loggedOut, error);
            });
            $('#send').on('click', sendPost);
        }

        function loggedOut() {
            localStorage.removeItem('xSessionKey');
            localStorage.removeItem('xUsername');
            view.initial();
        }

        function attachEventHandlers() {
            $('#main-register-btn').on('click', function () {
                $('aside').children().hide();
                $('#register-wrapper').show();
            });

            $('#register-btn').on('click', function () {
                var name = $('#reg-username').val(),
                    pass = $('#reg-password').val();
                service.register(name, pass)
                    .then(function () {
                        registered(name);
                    }, error);
            });

            $('#login-btn').on('click', function () {
                var name = $('#login-username').val(),
                    pass = $('#login-password').val();
                service.login(name, pass)
                    .then(loggedIn, error)
            });

            $('#logout').on('click', function () {
                service.logout()
                    .then(loggedOut, error);
            });
   
            $('.cancel').on('click', function () {
                $('aside').children().hide();
                $('#main-register-btn').show();
                $('#main-login-btn').show();
            });
            
            $('#main-login-btn').on('click', function () {
                $('aside').children().hide();
                $('#login-wrapper').show();
            });

            $('#next').on('click', function () {
                currentPage++;
            });

            $('#prev').on('click', function () {
                if (currentPage > 0) {
                    currentPage--;
                }
            });
        }
    
        function start() {
            if (localStorage.getItem('xSessionKey') && localStorage.getItem('xUsername')) {
                loggedIn(JSON.stringify({
                    username: localStorage.getItem('xUsername'),
                    sessionKey: localStorage.getItem('xSessionKey')
                }));
            }
            loadPosts();
            attachEventHandlers();
            setInterval(loadPosts, 1000);
        }

        return {
            run: start,
            sortPosts: sortPosts
        };
    }());

    return controller;
});
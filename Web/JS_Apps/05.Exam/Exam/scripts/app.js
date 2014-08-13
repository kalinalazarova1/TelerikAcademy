define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'sha1': 'libs/cryptojs-sha1',
            'handlebars': 'libs/handlebars',
            'Q': 'libs/q',
            'underscore': 'libs/underscore',
            'xhr': 'xhr',
            'controller': 'controller',
            'view': 'view',
            'service': 'service'
        }
    });


    require(['controller'], function (controller, requester) {
        'use strict';
        controller.run();
    });
});
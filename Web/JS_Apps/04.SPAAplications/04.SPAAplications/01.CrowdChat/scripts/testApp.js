define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'model': 'model',
            'view': 'view',
            'controller': 'controller',
            'handlebars': 'libs/handlebars-v1.3.0',
            'chai': 'libs/chai',
            'mocha': 'libs/mocha',
            'test': '../tests/test',
            'init': '../tests/init'
        }
    });


    require(['mocha','test'], function () {
        'use strict';
        mocha.run();
    });
});
/// <reference path="libs/jquery.js" />
/// <reference path="libs/require.js" />

define(function () {
    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'model': 'model',
            'view': 'view',
            'handlebars': 'libs/handlebars-v1.3.0',
            'controller': 'controller'
        }
    });


    require(['controller'], function(controller){
        'use strict';
        controller.run();
    });
});
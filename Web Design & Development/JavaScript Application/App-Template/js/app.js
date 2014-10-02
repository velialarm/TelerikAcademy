'use strict';
(function() {
    require.config({
        paths: {
            "jquery": "libs/jquery",
            "sammy" : "libs/sammy",
            "handlebars": "libs/handlebars-v1.3.0",
            "Q" : "libs/Q",
            "controller": "app/controller",
            "ui": "app/ui",
            "manager": "app/dataManager"
        }
    });
    require(['jquery'], function($) {

        $(document).ready(function () {
            //TODO
        });
    });
}());
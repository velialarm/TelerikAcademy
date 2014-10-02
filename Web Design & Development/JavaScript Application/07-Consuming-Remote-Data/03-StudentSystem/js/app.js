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
        },
        shim: {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
    });
    require(['jquery', 'controller', 'ui'], function($, Controller, ui) {

        $(document).ready(function () {
            Controller.reloadStudents();
            ui.attachHandlers(Controller.addStudent, Controller.removeStudent);
        });
    });
}());
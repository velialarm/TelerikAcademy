define(function() {
    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'sammy': 'libs/sammy',
            'handlebars': 'libs/handlebars-v1.3.0',
            'q': 'libs/q',
            'http-requester': 'app/http-requester',
            'ui': 'app/ui',
            'controller': 'app/controller'
        }
    });

    require(['jquery', 'sammy', 'controller'], function($, Sammy, Controller) {
        var appController = new Controller('http://crowd-chat.herokuapp.com/posts');
        appController.setEventHandler();

        var app = Sammy('#wrapper', function() {
            this.get("#/login", function() {
                if (appController.isLoggedIn()) {
                    window.location = '#/';
                    return;
                }
                appController.loadLoginForm();
            });

            this.get("#/", function() {
                if (!appController.isLoggedIn()) {
                    window.location = '#/login';
                    return;
                }
                appController.loadMainView();
            });
        });

        app.run('#/login');
    });
});
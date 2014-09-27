define(function() {
    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'handlebars': 'libs/handlebars-v1.3.0',
            'q': 'libs/q',
            'underscore': 'libs/undescore',
           // 'sha1' : 'libs/sha1',
            'http-requester': 'app/http-requester',
            'ui': 'app/ui',
            'controller': 'app/controller',
            'manager': 'app/dataManager'
        }
    });

    require(['jquery', 'controller','manager',], function($, Controller, Manager) {

        var ROOT_URL = "http://localhost:3000/",
            appManager = new Manager(ROOT_URL),
            appController = new Controller(appManager);

        appController.setEventHandler();

        if (appController.isLoggedIn()) {
            appController.loadLogoutForm();
            appController.loadPostForm();
        }else{
            appController.loadLoginForm();
        }
        appController.loadMainView();
    });
});
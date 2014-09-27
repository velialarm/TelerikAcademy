define(function() {

    "use strict";

    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'handlebars': 'libs/handlebars-v1.3.0',
            'q': 'libs/q',
            'underscore': 'libs/undescore',
            'mocha': 'libs/mocha',
            'chai': 'libs/chai',
            'appTest': 'test/app-test',
            'ui': 'app/ui',
            'controller': 'app/controller',
            'http-requester': 'app/http-requester'
        }
    });

    require(['mocha', 'chai','appTest'], function(mocha, chai, appTest) {
        console.log("Test is running");
        //mocha.setup('bdd');

//        var t = appTest;
//        console.log(t);
//        var expect = chai.expect;
//        expect(4+5).to.not.equal(10);


    });
});
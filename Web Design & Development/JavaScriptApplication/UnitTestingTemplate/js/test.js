define(function() {

    "use strict";

    require.config({
        paths: {
            'jquery': 'libs/jquery',
            'mocha': 'libs/mocha',
            'chai': 'libs/chai',
            'appTest': 'test/app-test',
            'main': 'app/main'
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
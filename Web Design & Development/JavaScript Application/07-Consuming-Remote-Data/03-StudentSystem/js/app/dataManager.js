'use strict';
define(['jquery'], function ($) {
    var resourceUrl = 'http://localhost:3000/students/';

    function DataManager(rootURL){
        this.url= resourceUrl;
    }
    return new DataManager;
});
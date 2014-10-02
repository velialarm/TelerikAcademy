'use strict';
define(['jquery', 'q'], function($, Q) {

    var HttpRequester = (function() {
        var makeHttpRequest = function(url, type, data, sessionKey) {
            var deferred = Q.defer();
            $.ajax({
                url: url,
                type: type,
                data: data ? JSON.stringify(data) : "",
                contentType: "application/json",
                timeout: 5000,
                'X-sessionKey': sessionKey || '',
                success: function(resultData) {
                    deferred.resolve(resultData);
                },
                error: function(errorData) {
                    deferred.reject(errorData);
                }
            });

            return deferred.promise;
    };

        var getJSON = function(url) {
            return makeHttpRequest(url, "GET");
        };

        var postJSON = function(url, data, sessionKey) {
            return makeHttpRequest(url, "POST", data, sessionKey);
        };
        var putJSON = function(url, sessionKey){
            return makeHttpRequest(url, "PUT", '', sessionKey);
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON
        };
    }());
    return HttpRequester;
});
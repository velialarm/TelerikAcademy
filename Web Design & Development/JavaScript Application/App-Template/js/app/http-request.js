'use strict';
define(['jquery','Q'], function ($, Q) {

    var request = function (url, type, data) {
        var defer = Q.defer();
        if(data){
            data = JSON.stringify(data);
        }
        $.ajax({
            url: url,
            type: type,
            data: data,
            contentType: "application/json",
            success: function (responseData) {
                defer.resolve(responseData);
            },
            error: function (errorData) {
                defer.reject(errorData);
            }
        });
        return defer.promise();
    };

    var requestGet = function (url) {
        return request(url, "get");
    };

    var requestPost = function (url, data) {
        return request(url, "post", data);
    };

    var requestDelete = function (url, data) {
        return request(url, "delete", data);
    };

    return {
        getJson: requestGet,
        postJson: requestPost,
        deleteJson: requestDelete
    };
});

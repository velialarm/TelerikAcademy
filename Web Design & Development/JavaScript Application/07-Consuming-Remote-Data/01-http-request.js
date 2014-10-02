/*
    Taks 1: Create a module that exposes methods for
    performing HTTP requests by given URL and
    headers
         getJSON and postJSON
         Both methods should work with promises
*/

var HttpRequester = (function () {
    var promiseRequest = function (url, type, data) {
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

    var promiseAjaxRequestGet = function (url) {
        return promiseRequest(url, "get");
    };

    var promiseAjaxRequestPost = function (url, data) {
        return promiseRequest(url, "post", data);
    };

    return {
        getJson: promiseAjaxRequestGet,
        postJson: promiseAjaxRequestPost
    }
}());

// Module for access to the REST API

define(['jquery', 'http-requester'], function($, HttpRequester) {

    var DataManager = (function() {

        function DataManager(resourceUrl){
            this.resourseUrl = resourceUrl;
        }

//LOGIN
        DataManager.prototype.login = function(username, password){
            var self = this;
            var hash = CryptoJS.SHA1(username + password).toString();
            console.log('User hash is : ' + hash);
            var userData = {
                username : username,
                authCode : hash
            };
            return HttpRequester.postJSON(self.resourseUrl + 'auth', userData).then(function(result){
                console.log(result.sessionKey);
                return result.sessionKey;
            });
        };

//REGISTER
        DataManager.prototype.register = function(username, password){
            var self = this;
            var hash = CryptoJS.SHA1(username + password).toString();
            console.log('User hash is : ' + hash);
            var userData = {
                username : username,
                authCode : hash
            };
            HttpRequester.postJSON(self.resourseUrl + 'user', userData).then(function(result){
                if(result){
                    console.log('User is register successfull');
                    //TODO add info message
                }
            });
        };

//LOGOUT
        DataManager.prototype.logout = function(sessionKey){
            return HttpRequester.putJSON(self.resourseUrl + 'user', sessionKey).then(function(result){
                if(result){
                    console.log(result);//TODO
                }
            });
        };

// GET POST
        DataManager.prototype.getPosts = function(options){
            var res = '?',
                userFilter = options.username || false,
                patternFilter = options.pattern || false;
            if(patternFilter){
                res += 'pattern=';
                res += patternFilter;
            }
            if(userFilter){
                res += 'user=';
                res += userFilter;
            }
            return HttpRequester.getJSON(self.resourseUrl + 'post' + res == '?' ? res : '')
                .then(function(result){
                console.log(result);//TODO
            });
        };

//CREATE POST
        DataManager.prototype.createPost = function(titleData, bodyData, sessionKey){
            var data = {
                title: titleData,
                body: bodyData
            };
            return HttpRequester.postJSON(self.resourseUrl + 'post', data, sessionKey)
                .then(function(result){
                    console.log(result);//TODO
                });
        };
        return DataManager;
    }());

    return DataManager;
});
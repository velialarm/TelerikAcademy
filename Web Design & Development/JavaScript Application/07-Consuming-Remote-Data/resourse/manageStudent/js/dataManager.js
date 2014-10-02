'use strict';

var App = App || {};

App.Manager = (function () {

    var UserManager = (function(){

        function UserManager(serviceRootUrl){
            this.serviceRootUrl = serviceRootUrl;
        }

        UserManager.prototype.login = function(username, password){
            var self = this;
            return HttpRequester.postJson(this.serviceRootUrl + "login",{
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            }).then(function(result){
                self._setSessionKey(result.sessionKey);
                self._setNickname(result.nickname);
                self._setUsername(username);
            });
        };
        UserManager.prototype.logout = function(){
            var self = this;
            return HttpRequester.getJson(this.serviceRootUrl + "logout/" + this._getSessionKey()).then(function(){
                self._clearSessionKey();
                self._clearNickname();
                self._clearUsername();
            });
        };
        UserManager.prototype.register = function(username, nickname, password){
            var self = this;
            return HttpRequester.postJson(this.serviceRootUrl + "register", {
                username: username,
                nickname: nickname,
                authCode: CryptoJS.SHA1(password).toString()
            }).then(function(result){
                console.log(result);
                self._setSessionKey(result.sessionKey);
                self._setNickname(result.nickname);
                self._setUsername(username);
            });
        };

        UserManager.prototype.isUserLoggedIn = function(){
            return (this._getNickname() !== null);
        };

        UserManager.prototype.getCurrentUserData = function(){
            return {
                username: this._getUsername(),
                nickname: this._getNickname(),
                sessionKey: this._getSessionKey()
            }
        };

        UserManager.prototype.getAllUserScores = function(){
            return HttpRequester.getJson(this.serviceRootUrl + "scores/" + this._getSessionKey());
        };

        return UserManager;
    }());

    var GameManager = (function(){
        function GameManager(serviceRootUrl, userManager){
            this.serviceRootUrl = serviceRootUrl;
            this.userManager = userManager;
        }
        GameManager.prototype.create = function(gameTitle, playerNumber, gamePassword){
            var gameOptions = {
                title: gameTitle,
                number: playerNumber
            };
            if (gamePassword) {
                gameOptions.password = CryptoJS.SHA1(gamePassword).toString();
            }
            return HttpRequester.postJson(this.serviceRootUrl + "create/" + this.userManager.getCurrentUserData().sessionKey, gameOptions);
        };
        GameManager.prototype.join = function(gameId, playerNumber, gamePassword){};    //TODO
        GameManager.prototype.start = function(gameId){};                               //TODO
        GameManager.prototype.start = function(){};                                     //TODO
        GameManager.prototype.getOpen = function(){};                                   //TODO
        GameManager.prototype.getCurrentUserActive = function(){};                      //TODO
        GameManager.prototype.getState = function(gameId){};                            //TODO

        return GameManager;
    }());

    var GuessManager = (function(){
        function GuessManager(serviceRootUrl, userManager){
            this.serviceRootUrl = serviceRootUrl;
            this.userManager = userManager;
        }
        GuessManager.prototype.make = function(guessNumber, gameId){
            return HttpRequester.postJson(this.serviceRootUrl + "make/" + this.userManager.getCurrentUserData().sessionKey, {
                gameId: gameId,
                number: guessNumber
            });
        };

    }());

    var MessageManager = (function(){
        function MessageManager(serviceRootUrl, userManager){
            this.serviceRootUrl = serviceRootUrl;
            this.userManager = userManager;
        }

        MessageManager.prototype.getUserUnread = function(){
            return HttpRequester.getJson(this.serviceRootUrl + "unread/" + this.userManager.getCurrentUserData().sessionKey);
        };
        MessageManager.prototype.getUserAll = function(){
            return HttpRequester.getJson(this.serviceRootUrl + "all/" + this.userManager.getCurrentUserData().sessionKey);
        };

        return MessageManager;
    }());

    var Manager = (function(){
        function MainManager(serviceRootUrl){
            this.serviceRootUrl = serviceRootUrl;
            this.user = UserManager(serviceRootUrl + "user/");
            this.games = GameManager(serviceRootUrl + "game/", this.user);
            this.guesses = GuessManager(serviceRootUrl + "guess/", this.user);
            this.messages = MessageManager(serviceRootUrl + "messages/", this.user);
        }
        return MainManager;
    }());

    return Manager;
}());
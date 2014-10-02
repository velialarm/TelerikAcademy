
//	Module for application control flow

define(['ui'], function(UI) {

    var Controller = (function() {

        var USER_VALID_CHARS =  'qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890_.'.split(''),
            USER_MIN_LENGTH =  6,
            USER_MAX_LENGTH = 40,
            PASSWORD_MIN_LENGTH = 3,
            PASSWORD_MAX_LENGTH = 40;

        var Controller = function(manager) {
           this.manager = manager,
           // this.resourseUrl = resourceUrl;
            this.refreshTime = 10000;
        };

        Controller.prototype.getUsername = function() {
            return sessionStorage.getItem('username');
        };

        Controller.prototype.setUsername = function(username) {
            sessionStorage.setItem('username', username);
        };

        Controller.prototype.getSessionKey = function(){
            return sessionStorage.getItem('sesionKey');
        };

        Controller.prototype.setSessionKey = function(sessionAuthKey){
            return sessionStorage.setItem('sesionKey', sessionAuthKey);
        };

        Controller.prototype.clearUserData = function() {
            sessionStorage.clear();
        };

        Controller.prototype.isLoggedIn = function() {
            return this.getUsername() != null;
        };

        Controller.prototype.loadMainView = function() {
            var self = this;

            $.when(
                $.get('template/main.html', function(data) {
                    $('#post-content').html(data);
                    //$('.username-box').html(self.getUsername());
                    //self.updateMainView();
//                    setInterval(function() {
//                        self.updateMainView();
//                    }, self.refreshTime);
                }));
        };

        Controller.prototype.updateMainView = function() {
            var _this = this;
//            HttpRequester.getJSON(this.resourseUrl)
//                .then(function(data) {
//                    var chatBoxHtml = UI.buildMainView(data, _this.showLastMessagesCount);
//                    $('#chatbox').html(chatBoxHtml);
//             });
        };

        Controller.prototype.loadLoginForm = function() {
            $('#register-content').load('template/login.html');
        };
        Controller.prototype.clearLoginForm = function() {
            $('#register-content').html = '';
        };

        Controller.prototype.loadLogoutForm = function() {
            $('#register-content').load('template/logout.html');
        };
        Controller.prototype.clearLogoutForm = function() {
            $('#register-content').html = '';
        };

        Controller.prototype.loadPostForm = function() {
            $('#writer-content').load('template/post.html');
        };
        Controller.prototype.clearPostForm = function() {
            $('#register-content').html = '';
        };

        Controller.prototype.setEventHandler = function() {
            var self = this,
                mainWrapper = $('#wrapper');
//LOGIN
            mainWrapper.on('click', '#btn-login', function() {
                var $loginInput = $('#inp-username'),
                    $passwordInput = $('#inp-password'),
                    username = $loginInput.val(),
                    passworrd = $passwordInput.val(),
                    isValidUsername = _isUsernameCorrect(username),
                    isValidPassLength = _validatePasswordLength(passworrd);

                if (isValidUsername && isValidPassLength) {
                    //login user and save session key
                    var _self = self;
                    var sessKey = self.manager.login(username,passworrd);
                    self.setSessionKey(sessKey);
                    self.setUsername(username);
                }
                if(!isValidUsername){
                    // TODO  show user error message
                    console.log("invalid username")
                }
                if(!isValidPassLength){
                    // TODO show password error message
                    console.log("invalid password length");
                }
            });

//REGISTER
            mainWrapper.on('click', '#btn-reg-register', function() {
                var $loginInput = $('#inp-reg-username'),
                    $passwordInput = $('#inp-reg-password'),
                    username = $loginInput.val(),
                    passworrd = $passwordInput.val(),
                    isValidUsername = _isUsernameCorrect(username),
                    isValidPassLength = _validatePasswordLength(passworrd);

                if (isValidUsername && isValidPassLength) {
                    //register user and save session key
                    console.log('register Contrl...');
                    var success = self.manager.register(username,passworrd);
                    if(success){
                        self.setUsername(username);
                        self.setSessionKey(sessionKey);
                    }
                }
                if(!isValidUsername){
                    // TODO  show user error message
                    console.log("invalid username")
                }
                if(!isValidPassLength){
                    // TODO show password error message
                    console.log("invalid password length");
                }
            });

//LOGOUT
            mainWrapper.on('click', '#btn-logout', function() {
                var exit = confirm("Are you sure you want to end the session?"); //TODO attach popup
                if (exit === true) {
                    var sessionKey =  self.getSessionKey();
                    var data = self.manager.logout(sessionKey);
                    self.clearUserData();
                }
            });

 // FETCH POST
            mainWrapper.on('click', '#btn-search', function() {
                var $userPost = $('#inp-usr-search'),
                    $searchText = $('#inp-pattern-search'),
                    userPosting = $userPost.val(),
                    searchPosting = $searchText.val(),
                    options = {
                        username: userPosting,
                        pattern: searchPosting
                    },
                    result = self.manager.getPosts(options);
                //TODO call handlebars with result

            });

   // ADD POST
            mainWrapper.on('click', '#btn-post', function() {
                var $titlePost = $('#post-title'),
                    $bodyText = $('#body-post'),
                    title = $titlePost.val(),
                    body = $bodyText.val(),
                    result = self.manager.createPost(title, body);
                //TODO call handlebars with result

            });
        };




// --------------------------------------------------

        function _isUsernameCorrect(username) {
            if (!username ||
                username.length < USER_MIN_LENGTH ||
                USER_MAX_LENGTH < username.length) {
                return false;
            }
            for (var i = 0, len = username.length; i < len; i += 1) {
                var ch = username[i];
                if (USER_VALID_CHARS.indexOf(ch) < 0) {
                    return false;
                }
            }
            return true;
        }

        function _validatePasswordLength(password){
            if (!password ||
                password.length < PASSWORD_MIN_LENGTH ||
                PASSWORD_MAX_LENGTH < password.length) {
                return false;
            }
            return true;
        }

        function _isPostValid(post) {
            if (!post.title || (typeof post.title !== 'string')) {
                return false;
            }
            if (!post.body || (typeof post.body !== 'string')) {
                return false;
            }
            return true;
        }

        return Controller;
    }());

    return Controller;
});
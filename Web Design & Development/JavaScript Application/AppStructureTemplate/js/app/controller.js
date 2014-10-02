define(['http-requester', 'ui'], function(HttpRequester, UI) {

    var Controller = (function() {
        var Controller = function(resourceUrl) {
            this.resourseUrl = resourceUrl;
            this.refreshTime = 5000;
        };

        Controller.prototype.getUsername = function() {
            return sessionStorage.getItem('username');
        };

        Controller.prototype.setUsername = function(username) {
            sessionStorage.setItem('username', username);
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
                    $('#wrapper').html(data);
                    $('.username-box').html(self.getUsername());
                    self.updateMainView();
                    setInterval(function() {
                        self.updateMainView();
                    }, self.refreshTime);
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
            $('#wrapper').load('template/login.html');
        };

        Controller.prototype.setEventHandler = function() {
            var self = this,
                mainWrapper = $('#wrapper');

            mainWrapper.on('click', '#btn-login', function() {
                var $loginInput = $('#inp-username'),
                    username = $loginInput.val(),
                    isValidUsername = _isUsernameCorrect(username);

                if (isValidUsername) {
                    self.setUsername(username);
                    console.log("username is valid..." + username);
                }
                else {
                    // TODO  show error message
                    console.log("invalid username")
                }
            });
//
//            mainWrapper.on('click', '#exit-btn', function() {
//                var exit = confirm("Are you sure you want to end the session?");
//                if (exit === true) {
//                    self.clearUserData();
//                    window.location = '#/login';
//                }
//            });
//
//            mainWrapper.on('click', '#submitmsg', function() {
//                var $messageInput = $('#usermsg'),
//                    enteredMessage = $messageInput.val().trim(),
//                    postBy = self.getUsername();
//
//                if (enteredMessage) {
//                    HttpRequester.postJSON(self.resourseUrl, {
//                        user: postBy,
//                        text: enteredMessage
//                    })
//                        .then(function() {
//                            $messageInput.val('');
//                            var postHtml = UI.buildMessage(postBy, enteredMessage);
//                            $('#chatbox').prepend(postHtml);
//                            $messageInput.removeClass('error-validation');
//                        }, function() {
//                            $messageInput.addClass('error-validation');
//                        });
//                }
//                else {
//                    $messageInput.addClass('error-validation');
//                }
//            });
        };

        function _isUsernameCorrect(username, minLength, maxLenght) {
            var MIN_LENGHT = minLength || 3,
                MAX_LENGHT = maxLenght || 20,
                isValidUsername = username && typeof username == 'string' &&
                username.length >= MIN_LENGHT && username.length <= MAX_LENGHT;
            return isValidUsername;
        }

        return Controller;
    }());

    return Controller;
});
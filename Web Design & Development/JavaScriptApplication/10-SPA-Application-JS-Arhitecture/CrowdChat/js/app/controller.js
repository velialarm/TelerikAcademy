define(['http-requester', 'ui'], function(HttpRequester, UI) {

    var Controller = (function() {
        var Controller = function(resourceUrl) {
            this.resourseUrl = resourceUrl;
            this.refreshTime = 4000;
            this.showLastMessagesCount = 200;
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

        Controller.prototype.loadChatBox = function() {
            var _this = this;

            $.when(
                $.get('template/chat.html', function(data) {
                    $('#wrapper').html(data);
                    $('.username-box').html(_this.getUsername());
                    _this.updateMainView();
                    setInterval(function() {
                        _this.updateMainView();
                    }, _this.refreshTime);
                }));
        };

        Controller.prototype.updateMainView = function() {
            var _this = this;
            HttpRequester.getJSON(this.resourseUrl)
                .then(function(data) {
                    var chatBoxHtml = UI.buildChatBox(data, _this.showLastMessagesCount);
                    $('#chatbox').html(chatBoxHtml);
                });
        };

        Controller.prototype.loadLoginForm = function() {
            $('#wrapper').load('template/login.html');
        };

        Controller.prototype.setEventHandler = function() {
            var self = this,
                $wrapper = $('#wrapper');

            $wrapper.on('click', '#login-btn', function() {
                var $loginInput = $('#login-name'),
                    username = $loginInput.val(),
                    isValidUsername = _isUsernameCorrect(username);

                if (isValidUsername) {
                    self.setUsername(username);
                    $loginInput.removeClass('error-validation');
                    window.location = '#/chat';
                }
                else {
                    $loginInput.addClass('error-validation');
                }
            });

            $wrapper.on('click', '#exit-btn', function() {
                var exit = confirm("Are you sure you want to end the session?");
                if (exit === true) {
                    self.clearUserData();
                    window.location = '#/login';
                }
            });

            $wrapper.on('click', '#submitmsg', function() {
                var $messageInput = $('#usermsg'),
                    enteredMessage = $messageInput.val().trim(),
                    postBy = self.getUsername();

                if (enteredMessage) {
                    HttpRequester.postJSON(self.resourseUrl, {
                        user: postBy,
                        text: enteredMessage
                    })
                        .then(function() {
                            $messageInput.val('');
                            var postHtml = UI.buildMessage(postBy, enteredMessage);
                            $('#chatbox').prepend(postHtml);
                            $messageInput.removeClass('error-validation');
                        }, function() {
                            $messageInput.addClass('error-validation');
                        });
                }
                else {
                    $messageInput.addClass('error-validation');
                }
            });
        };

        function _isUsernameCorrect(username) {
            var isValidUsername = username && typeof username == 'string' &&
                username.length >= 4 && username.length <= 20;
            return isValidUsername;
        }

        return Controller;
    }());

    return Controller;
});
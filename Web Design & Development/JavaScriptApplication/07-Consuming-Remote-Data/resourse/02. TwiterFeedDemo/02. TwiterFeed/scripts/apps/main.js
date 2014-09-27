require(['jquery', 'oauth'], function ($) {

    function getAuthPromise() {
        OAuth.initialize('CziAuC3ZsmDC0hUGDtv-Mo8eIZM');
        var authPromise = OAuth.popup('twitter', {
            cache: true
        });

        return authPromise;
    }

    $('#authorize').on('click', function () {
        getAuthPromise()
        .done(function () {
            console.log('Authenticated succesfully. Your login authorization has been cached.');
        })
        .fail(function (err) {
            console.log(err);
        });
    })

    $('#get-user').on('click', function () {
        var username = $('#username').val(),
            messageCount = parseInt($('#count').val());
        requestUrl = 'https://api.twitter.com/1.1/statuses/user_timeline.json?count=' + messageCount + '&screen_name=' + username;
        getAuthPromise()
        .done(function (result) {
            result.get(requestUrl)
            .done(function (response) {
                console.log('User messages recieved succesfully.');
                console.log(response);
            })
            .fail(function (error) {
                console.log(error);
            });
        })
    });
});
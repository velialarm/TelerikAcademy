(function () {
    require.config({
        paths: {
            'jquery': 'https://code.jquery.com/jquery-2.1.1.min',
            'handlebars': 'https://cdnjs.cloudflare.com/ajax/libs/handlebars.js/2.0.0-alpha.4/handlebars.min'
        }
    });
    require(['run'], function (run) {
        run.run();
    })
}());
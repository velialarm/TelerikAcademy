'use strict';
define(['jquery','handlebars'], function ($,Handlebars) {
    var $successMsg, $errorMsg, template;
    $(function () {
        $successMsg = $('.messages .success');
        $errorMsg = $('.messages .error');

        var source = $('#template').html();
        template = Handlebars.compile(source);
    });

    function showSuccessMessage(msg) {
        $successMsg.html(msg).show().fadeOut(2000);
    };

    function showStudents(data) {
        $('#students-container').html(template({
            rows: data.students
        }))
    };

    function showError(err) {
        console.log('Error: ' + JSON.stringify(err));
        $errorMsg.html('Error: ' + err.status + ' (' + err.statusText + ')').show().fadeOut(2000);
    };

    function attachHandlers(handlerAdd, handlerRemove) {
        $('#btn-add-student').on('click', function () {
            var name = $('#tb-name').val();
            var grade = $('#tb-grade').val();
            handlerAdd(name, grade);
        });

        $('#btn-remove-student').on('click', function () {
            var id = $('#tb-id').val();
            handlerRemove(id);
        });
    }

    return {
        attachHandlers: attachHandlers,
        showSuccessMessage: showSuccessMessage,
        showError: showError,
        showStudents: showStudents
    }
});
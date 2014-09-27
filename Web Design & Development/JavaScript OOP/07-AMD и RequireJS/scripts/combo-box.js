'use strict';
define(['jquery', 'handlebars'], function () {
    var ComboBox = function (people) {
        function render(template) {
            var $container = $('<div class="comboBox-control" />');
            var compiledTemplate = Handlebars.compile(template);

            people.forEach(function (person) {
                $(compiledTemplate(person)).appendTo($container);
            });

            var collapsedClass = 'collapsed';
            var selectedClass = 'selected';
            var visibleClass = 'visible';

            $container.children().first().addClass(selectedClass);
            $container.addClass(collapsedClass);

            $container.on('click', '.combo-box', function () {
                var $this = $(this);

                if ($container.hasClass(collapsedClass)) {
                    $container.children().addClass(visibleClass);
                    $container.removeClass(collapsedClass)
                } else {
                    $container.children().removeClass(visibleClass);
                    $container.find('.' + selectedClass).removeClass(selectedClass);
                    $this.addClass(selectedClass);
                    $container.addClass(collapsedClass);
                }
            });
            return $container;
        }

        return {
            render: render
        };
    };

    return {
        ComboBox: ComboBox
    }
});

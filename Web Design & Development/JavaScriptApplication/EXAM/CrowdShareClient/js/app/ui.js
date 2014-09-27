
//Module for generating UI

define(function() {
    var UI = (function() {
    	
        var div = document.createElement('div'),
            span = document.createElement('span'),
            strong = document.createElement('strong');
//
//        div.className = 'msgln';
//        div.appendChild(strong);
//        div.appendChild(span);

        function buildMessage(postBy, postText) {

            return div.cloneNode(true);
        }

        function buildMainView(data) {
            var docFragment = document.createDocumentFragment();

            return docFragment;
        }

        return {
            buildMessage: buildMessage,
            buildMainView: buildMainView
        };
    }());

    return UI;
});
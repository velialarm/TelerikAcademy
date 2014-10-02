define(['http-requester'], function(HttpRequester) {

    var DataManager = (function() {

        function DataManager(resourceUrl){
            this.resourseUrl = resourceUrl;
        }

        DataManager.prototype.getSomeData = function(){
            var self = this;
            return HttpRequester.getJson(self.resourceUrl + '/someElse').then(function(data){
                //TODO
            });
        };

        return DataManager;

    }());
    return DataManager;
});
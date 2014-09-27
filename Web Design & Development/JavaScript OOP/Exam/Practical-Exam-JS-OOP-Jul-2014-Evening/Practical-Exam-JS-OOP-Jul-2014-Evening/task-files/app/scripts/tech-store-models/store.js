define(function(){
    var Store;

    Store = (function(){
        function Store(titleStore){
            this.titleStore = titleStore;
            this._items = [];
        };

        Store.prototype.addItem = function(item){
            this._items.push(item);
            return this;
        };

        //returns a collection of all items,
        // sorted lexicographically by the name of the items
        Store.prototype.getAll= function(){
            return sortStore(this._items,'title');
        };

        //returns a collection of only the items in stock that have type 'smart-phone',
        // sorted lexicographically by the name of the items
        Store.prototype.getSmartPhones = function(){
            var result = [];
            this._items.forEach(function(element){
              if(element.type == 'smart-phone'){
                  result.push(element);
              }
            });
            return sortStore(result,'title');
        };
        //returns a collection of only the items in stock that have type either 'smart-phone' or 'tablet',
        // sorted lexicographically by the name of the items
        Store.prototype.getMobiles = function(){
            var result = [];
            this._items.forEach(function(element){
                if(element.type == 'smart-phone' || element.type == 'tablet'){
                    result.push(element);
                }
            });
            return sortStore(result,'title');
        };
        Store.prototype.getComputers = function (){
            var result = [];
            this._items.forEach(function(element){
                if(element.type == 'pc' || element.type == 'notebook'){
                    result.push(element);
                }
            });
            return sortStore(result,'title');
        };

        Store.prototype.filterItemsByType = function(filterType){
            var result = [];
            this._items.forEach(function(element){
                if(element.type == filterType){
                    result.push(element);
                }
            });
            return sortStore(result,'title');
        };

        // returns a collection of only the items in stock that have a name containing partOfName,
        // sorted lexicographically by the name of the items. The search should be performed case insensitive
        Store.prototype.filterItemsByName = function(title){
            var result = [];
            this._items.forEach(function(element){
                var text = element.title;
                if(text != undefined){
                    if(text.toUpperCase().indexOf(title.toUpperCase()) > 0){
                        result.push(element);
                    }
                }
            });
            return sortStore(result,'title');
        };

        //returns a collection of only the items that have a price from the price range in the options parameter,
        // sorted ascending by the price of the items
        Store.prototype.filterItemsByPrice = function(options){
            var result = [];
            if(options != undefined){
                var minValue = options.min || 0;
                var maxValue = options.max || -1;
                this._items.forEach(function(element){
                    if(element.price >  minValue && (maxValue != -1 ? element.price < maxValue : true )){
                        result.push(element);
                    }
                });
                return sortStore(result,'price');
            }else{
                return sortStore(this._items,'price');
            }
        };

        // returns an associative array that have as keys the types, that are of items in stock in the store,
        // and values that are equal to the number of items with this type
        Store.prototype.countItemsByType = function(){
            var arr = {
                type:0,
                title:0,
                price:0
            };
            this._items.forEach(function(element){
                if(element.type != undefined){
                    arr['type']++;
                }
                if(element.title != undefined){
                    arr['title']++;
                }
                if(element.price != undefined){
                    arr['price']++;
                }
            });
            return arr;
        };

        function sortStore(items, sortBy){
            items.sort(function(first, second){
                a = first[sortBy] != undefined ? first[sortBy].toUpperCase : first[sortBy];
                b = second[sortBy] != undefined ? second[sortBy].toUpperCase : second[sortBy];
                return a - b;
            })
            return items.slice();
        };

        return Store;
    }());

    return Store;
});
define([],function(){
    var Item;

    Item = function () {
        var types = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];
        function Item(type, title, price) {
            if(containType(type, types)){
                this.type = type;
            }
            if(checkLengthTitle(title)){
                this.title = title;
            }
            this.price = decimalPrecision(price);
        };

        function checkLengthTitle(title){
            var titleLength = title.length;
            if(titleLength > 6 && titleLength < 40){
                return true;
            }else{
                return false;
            }
        }
        function containType(type, types) {
            for(var i= 0, len = type.length; i < len ; i++){
                if(types[i] === type){
                    return true;
                }
            }
            return false;
        }
        function decimalPrecision(price){
            return parseFloat(Math.round(price * 100) / 100).toFixed(2);
            //return (parseFloat(price.toPrecision(2)));
        }
        return Item;
    }();

    return Item;
});
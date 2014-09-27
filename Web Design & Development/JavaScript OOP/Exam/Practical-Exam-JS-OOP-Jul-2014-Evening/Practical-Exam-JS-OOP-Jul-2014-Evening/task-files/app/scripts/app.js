(function() {
    'use strict';
    require(['tech-store-models/store', 'tech-store-models/item'], function(Store, Item) {
        var store;
        try {
            var testStore = new Store([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
            console.error("Doesn't check if store name is string!");
        } catch (err) {
            console.log("Check if store name is string!");
        }
        try {
            var testStore2 = new Store('in');
            console.error("Doesn't check for store name length!");
        } catch (err) {
            console.log("Check for store name length!");
        }
        store = new Store('Telerik Academy Store');
        store.addItem(new Item('accessory', 'Academy Headphones', 55.9))
            .addItem(new Item('smart-phone', 'Academy Mobile', 888.9))
            .addItem(new Item('notebook', 'Academy Note Enterprise', 2888.9))
            .addItem(new Item('accessory', 'Speakers', 154.9))
            .addItem(new Item('pc', 'The Academy', 999.9))
            .addItem(new Item('notebook', 'Academy Note Light', 888.9))
            .addItem(new Item('smart-phone', 'Academy Mobile+', 1588.9))
            .addItem(new Item('tablet', 'Academy Mobile++', 1888.9))
            .addItem(new Item('notebook', 'Academy Note Ultramate', 3999.9))
            .addItem(new Item('pc', 'The Academy Enterprise', 1999.9))
            .addItem(new Item('pc', 'The Academy Ultimate', 2999.9))
            .addItem(new Item('tablet', 'The Academy Mobile ++--', 2888.8))
            .addItem(new Item('smart-phone', 'Super Giga Mega Cool SmartPhone', 10.9))
            .addItem(new Item('accessory', 'Useless accessory for your notebook', 99.9))
            .addItem(new Item('pc', 'PC Kifla', 8999.9))
            .addItem(new Item('notebook', 'Notebook Kifla', 9999.9))
            .addItem(new Item('tablet', 'Tablet Kifla', 7999.9))
            .addItem(new Item('smart-phone', 'iKifla', 16999.9))
            .addItem(new Item('accessory', 'Kifla accessory #1', 299.9))
            .addItem(new Item('accessory', 'Kifla accessory #2', 699.9))
            .addItem(new Item('accessory', 'Kifla accessory #3', 199.9))
            .addItem(new Item('accessory', 'Kifla accessory #4', 299.9))
            .addItem(new Item('accessory', 'Kifla accessory #5', 399.9))
            .addItem(new Item('accessory', 'Kifla accessory #6', 299.9))
            .addItem(new Item('accessory', 'Kifla accessory #7', 799.9));
 
        try {
            testStore.addItem(new Item('invalid-phone', 'iKifla', 16999.9));
            console.error("Doesn't check for item type!");
        } catch (err) {
            console.log("Check for item type!");
        }
        try {
            testStore.addItem(new Item('notebook', 'sn', 16999.9));
            console.error("Doesn't check for item name length!");
        } catch (err) {
            console.log("Check for item name length!");
        }
        try {
            testStore.addItem(new Item('tablet', [1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 16999.9));
            console.error("Doesn't check if store name is string!");
        } catch (err) {
            console.log("Check if item name is string!");
        }
        try {
            var testAccessories = store.filterItemsByType('accessorys');
            console.error("Doesn't check if filterType is valid!");
        } catch (err) {
            console.log("Check if filterType is valid!");
        }
 
        function showItems(items, title) {
            function padRight(str, len) {
				if(str != undefined){
					if (typeof str !== 'string') {
                    str = str.toString();
                }
                len = len || 35;
                return str + Array(len + 1 - str.length).join(' ');
				}
                
            }
            console.warn(title);
            items.forEach(function(item) {
                var name = item.title || item.title;
                var price = item.price || item._price;
                var type = item.type || item._type;
                console.log(padRight(name), padRight(type, 12), padRight(price, 10));
            });
            console.log(Array(40).join('*'));
 
            console.log(items.length);
 
        }
        /* returns all items */
        var allItems = store.getAll();
        showItems(allItems, 'returns all items ');
 
        /*  returns 4 items (type = 'smart-phone') */
        var smartPhones = store.getSmartPhones();
        showItems(smartPhones, "returns 4 items (type = 'smart-phone')");
 
        /* returns 7 items (type = 'smart-phone' or 'tablet' */
        var mobiles = store.getMobiles();
        showItems(mobiles, "returns 7 items (type = 'smart-phone' or 'tablet'");
 
        /* returns 8 items (type = 'pc' or 'notebook' */
        var computers = store.getComputers();
        showItems(computers, "returns 8 items (type = 'pc' or 'notebook'");
 
        /* returns all items, sorted ascending by price */
        var filteredByPrice = store.filterItemsByPrice();
        showItems(filteredByPrice, 'returns all items, sorted ascending by price');
 
        /* returns only the items with price greater than 999.0, sorted ascending by price */
        var filteredByMinPrice = store.filterItemsByPrice({
            min: 999
        });
        showItems(filteredByMinPrice, "returns only the items with price greater than 999.0, sorted ascending by price");
 
        /* returns only the items with price lesser than 3999.0, sorted ascending by price */
        var filteredByMaxPrice = store.filterItemsByPrice({
            max: 3999
        });
        showItems(filteredByMaxPrice, "returns only the items with price lesser than 3999.0, sorted ascending by price");
 
        /* returns only the items with price greater than 999 and lesser than 3999.0 , sorted ascending by price */
        var filteredByPriceRange = store.filterItemsByPrice({
            min: 999,
            max: 3999
        });
        showItems(filteredByPriceRange, "returns only the items with price greater than 999 and lesser than 3999.0 , sorted ascending by price");
 
        /* returns 10 items (type = 'accessory' */
        var accessories = store.filterItemsByType('accessory');
        showItems(accessories, "returns 10 items (type = 'accessory' ");
 
        /* returns 5 items, that have the word 'note' in their name. The search is case-insensitive */
        var itemsWithNoteInName = store.filterItemsByName('note');
        showItems(itemsWithNoteInName, "returns 5 items, that have the word 'note' in their name. The search is case-insensitive");
 
 
        /* returns an associative array. The value of each key is one of the types, and the value is the number of items with the type */
        console.log(store.countItemsByType());
 
        var testStore3 = new Store("Just for testing");
 
        var smartPhonesTest = testStore3.getSmartPhones();
        showItems(smartPhonesTest, "getSmartPhones with empty store should return empty array");
 
        var mobilesTest = testStore3.getMobiles();
        showItems(mobilesTest, "getMobiles with empty store should return empty array");
 
        var computersTest = testStore3.getComputers();
        showItems(computersTest, "getComputers with empty store should return empty array");
 
        var noNameTest = testStore3.filterItemsByName('note');
        showItems(noNameTest, "filterItemsByName with empty store should return empty array");
 
        //should be empty
        console.log(testStore3.countItemsByType());
 
    });
}());
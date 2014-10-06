
var mongoose = require('mongoose');

var dbString = 'mongodb://localhost:27017/MongoChat';

module.exports = function(){

    mongoose.connect(dbString);
    var db = mongoose.connection;

    db.once('open', function(err){
        if(err){
            console.log(err);
        }

        console.log('MongoDB database up and running...');
    });

    db.on('error', function(err){
        console.log(err);
    })

    return db;
}

var mongoose = require('mongoose');

var userSchema = mongoose.Schema({
    user: { type: String, require: true, unique: true },
    pass: { type: String, require: true }
});

var User = mongoose.model('User', userSchema);

module.exports = function(){

}
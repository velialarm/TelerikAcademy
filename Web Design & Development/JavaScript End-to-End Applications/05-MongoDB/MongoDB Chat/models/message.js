var mongoose = require('mongoose');
var userSchema = mongoose.model('User').schema;

module.exports.init = function(){

    var messageSchema = mongoose.Schema({
        from: [userSchema],
        to: [userSchema],
        text: {type: String, required: true }
    });

    var Message = mongoose.model('Message', messageSchema);
}
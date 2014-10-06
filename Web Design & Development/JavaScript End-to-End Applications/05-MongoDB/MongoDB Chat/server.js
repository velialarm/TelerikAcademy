var express = require('express');
var mongoose = require('./config/mongoose');
var chat = require('./controllers/chat-db');

var server = express();


//inserts a new user records into the DB

chat.registerUser({user: 'DonchoMinkov', pass: '123456q'});

//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
});
//returns an array with all messages between two users
chatDb.getMessages({
    with: 'DonchoMinkov',
    and: 'NikolayKostov
});





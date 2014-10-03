var express = require('express');

var port = 7777;
var server = express();

server.get('/test', function(err, request){
	if(err){
		//todo
	}
	request.send('<h1>Hello world </h1><p>Test a? </p>');
});

server.get('/', function(err, request){
	if(err){
		//todo
	}
	request.send('<h1>Hello world</h1>');
});

server.listen(port);

console.log('Server is running on port ' +port);

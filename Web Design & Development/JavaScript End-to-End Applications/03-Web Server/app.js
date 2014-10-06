//Create file upload web site with NodeJS. You should have the option to upload
//a file and be given an unique URL for its download. Use GUID.
//You are not allowed to use ExpressJS

var formidable = require('formidable');
var http = require('http');
var fs = require('fs');

var port = 9876;
var uploadDirectory = "upload";

http.createServer(function(req, res){
	
	if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
		var form = new formidable.IncomingForm();
		
		form.uploadDir = uploadDirectory;
		form.multiples = true;
		form.keepExtensions = true;
		
		form.parse(req, function (err, fields, files) {
			if (err) {
				console.log('Error when upload: \n'+err);
			} else {
				res.writeHead(200, {'content-type': 'text/text'});
				res.write('Files was uploaded... ');
				res.end();
			}
		});
		return;
	}
	fs.readFile('index.html', function (err, data) {
		if (err) {
			console.log(err);
		}
		res.writeHead(200, {'content-type': 'text/html'});
		res.end(data);
	});
	
	
}).listen(port);

console.log('Server is listening on port ' + port);
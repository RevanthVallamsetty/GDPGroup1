var http=require('http');

var fs=require('fs');

function onRequest(request,response){
    response.writeHead(200,{'Content-Type':'html'});
	fs.readFile('./index.html',null,function(err,data){
		if(err){
			response.writeHead(404);
			response.writeHead('file not found !');
		}
		else{
			response.write(data);
		}
		response.end();	
	});
}
http.createServer(onRequest).listen(3000);
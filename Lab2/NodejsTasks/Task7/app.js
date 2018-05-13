var fs = require('fs');
var express = require('express');
var bodyParser = require('body-parser');

var app = express();
app.use(express.urlencoded());

app.post('/postvalue', function (req, res) {
    var value = req.param('value', null);
    fs.writeFile('static/data/value.txt', value, function (err) {
        if (err) {
            console.log('Error writing value to file...');
        }
    });
    res.writeHead(200);
    res.end();
});

app.get('/', function (req, res) {
    fs.readFile('static/html/index.html', 'utf8', function (err, data) {
        if (err) {
            console.log('Could not find or open file for reading\n');
        } else {
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.end(data);
        }
    });
});

app.get('/getvalue', function (req, res) {
    fs.readFile('static/data/value.txt', 'utf8', function (err, data) {
        if (err) {
            console.log('Could not find or open file for reading\n');
        } else {
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.end(data);
        }
    });
});

var server = app.listen(8080, function () {
    var host = server.address().address;
    var port = server.address().port;
    console.log('Example app listening at http://%s:%s', host, port);
});
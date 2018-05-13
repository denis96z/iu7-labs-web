var express = require('express')
var fs = require('fs')

var app = express();

app.get('/', function (req, res) {
    fs.readFile('static/html/index.html', 'utf8', function (err, data) {
        if (err) {
            console.log('could not read "index.html"');
        } else {
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.end(data);
        }
    });
});

app.get('/info', function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/html' });
    res.end('Lab2');
});

app.get('/home', function (req, res) {
    fs.readFile('static/html/home.html', 'utf8', function (err, data) {
        if (err) {
            console.log('could not read "home.html"');
        } else {
            res.writeHead(200, { 'Content-Type': 'text/html' });
            res.end(data);
        }
    });
});

var server = app.listen(8080);

var express = require('express')
var fs = require('fs')

var app = express();
app.use(express.static('static/html'));
app.use(express.static('static/img'));

var server = app.listen(8080);
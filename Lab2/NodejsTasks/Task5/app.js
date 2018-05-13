var express = require('express')
var fs = require('fs')

var app = express();

app.get('/:name', function (req, res, next) {
    var options = {
        root: 'static/html',
        dotfiles: 'deny',
        headers: {
            'x-timestamp': Date.now(),
            'x-sent': true
        }
    };

    var fileName = req.params.name;
    var regExp = new RegExp('\\w*[.]\\w+');
    if (!regExp.exec(fileName)) {
        fileName += '.html';
    }

    res.sendFile(fileName, options, function (err) {
        if (err) {
            console.log(err);
        } else {
            console.log('Sent: ', fileName);
        }
    });
});

var server = app.listen(8080);

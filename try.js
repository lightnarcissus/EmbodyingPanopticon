
var page = require('webpage').create();
page.open('http://github.com/', function() {
  page.render('github.png');
  phantom.exit();
});

page.onLoadFinished = function(status) {
  console.log('Status: ' + status);
  // Do other things here...
};

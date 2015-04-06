var gulp = require('gulp');
var changelog = require('conventional-changelog');
var fs = require('fs');

gulp.task('changelog', function() {
  var pkg = JSON.parse(fs.readFileSync('./version.json', 'utf-8'));
  
  try {
	  fs.unlinkSync('./CHANGELOG.md'); //deletes existing file if exists to avoid pre-pending
  } catch(e){}   
  
  return changelog({
    repository: 'https://github.com/eganj/Compost.NET',
    version: pkg.NuGetVersion,
    file: './CHANGELOG.md'
  }, function(err, log) {
    fs.writeFileSync('./CHANGELOG.md', log);
  });
});
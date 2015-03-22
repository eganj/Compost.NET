var gulp = require('gulp');
var changelog = require('conventional-changelog');
var fs = require('fs');

gulp.task('changelog', function() {

  var pkg = JSON.parse(fs.readFileSync('./version.json', 'utf-8'));


  return changelog({
    repository: 'https://github.com/eganj/Compost.NET',
    version: pkg.NuGetVersion,
    file: './CHANGELOG.md'
  }, function(err, log) {
      console.log("Uh oh... " + err);
    fs.writeFileSync('./CHANGELOG.md', log);
  });
});
var gulp = require('gulp');
var changelog = require('conventional-changelog');
var fs = require('fs');

gulp.task('changelog', function() {
  var pkg = JSON.parse(fs.readFileSync('./version.json', 'utf-8'));
  
  try {
	  fs.unlinkSync('./CHANGELOG.md'); //deletes existing file if exists to avoid pre-pending
  } catch(e){}
  
  // write version to a separate file for the next step for publishing to GitHub.
  // this makes it easier to read the value into the batch file.
  fs.writeFileSync('./release_version.txt', pkg.NuGetVersion);
  
  return changelog({
    repository: 'https://github.com/eganj/Compost.NET',
    version: pkg.NuGetVersion,
    file: './CHANGELOG.md'
  }, function(err, log) {
    fs.writeFileSync('./CHANGELOG.md', log);
  });
});
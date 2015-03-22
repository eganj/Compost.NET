set /p TAG=Please enter the git tag that is being released: 

:: Update the version
GitVersion -updateassemblyinfo true > version.json

:: Build
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %msBuildDir%\MSBuild.exe  Compost.NET.sln /p:Configuration=Release 

:: Generate the changelog
:: gulp step consumes version.json and creates release_version.txt
gulp changelog

:: Publish to GitHub releases
set /p API_KEY=< GitHubApiKey.txt
set /p VERSION=< release_version.txt  
GithubReleaseCreator_1.1.0\GithubReleaseCreator.exe --username %API_KEY% --owner "eganj" --repo "compost.net" --tag %TAG% --name %VERSION% --filedesc "CHANGELOG.md" -assetfiles "bin\Release\Compost.dll,bin\Release\Compost.pdb,bin\Release\Compost.XML" --verbose

:: Publish to nuget
nuget pack ./src/Compost/Compost.csproj -Prop Configuration=Release
nuget push ./Compost.nupkg

pause
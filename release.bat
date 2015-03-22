set /p TAG=Please enter the git tag for this release: 

:: Publish to GitHub releases
set /p API_KEY=< GitHubApiKey.txt
set /p VERSION=< release_version.txt  
set WORKING_DIR=%~dp0
GithubReleaseCreator_1.1.0\GithubReleaseCreator.exe --username %API_KEY% --owner "eganj" --repo "compost.net" --tag %TAG% --name %VERSION% --filedesc "CHANGELOG.md" --assetfiles "%WORKING_DIR%bin\Release\Compost.dll,%WORKING_DIR%bin\Release\Compost.pdb,%WORKING_DIR%bin\Release\Compost.XML" --verbose

:: Publish to nuget
set ASSEMBLY_VERSION=%TAG:v=%.0
nuget pack ./src/Compost/Compost.csproj -Prop Configuration=Release
nuget push ./Compost.%ASSEMBLY_VERSION%.nupkg
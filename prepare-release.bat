:: Update the version
GitVersion -updateassemblyinfo true > version.json

:: Build
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %msBuildDir%\MSBuild.exe  Compost.NET.sln /p:Configuration=Release 

:: Generate the changelog
:: changelog step consumes version.json and creates release_version.txt
gulp changelog
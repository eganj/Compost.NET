nuget setApiKey %NUGET_API_KEY%
nuget pack ./src/Compost/Compost.csproj -Prop Configuration=Release
nuget push ./Compost.nupkg
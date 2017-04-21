cd %1
dotnet pack --no-build --configuration %2
move /Y %1\bin\Debug\*.nupkg %nugetDir%
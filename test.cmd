@echo off
dotnet test .\tests\Common\Common.csproj --no-build -v m
dotnet test .\tests\Data\Data.csproj --no-build -v m
dotnet test .\tests\Data.Providers\Data.Providers.csproj --no-build -v m
dotnet test .\tests\Generators\Generators.csproj --no-build -v m

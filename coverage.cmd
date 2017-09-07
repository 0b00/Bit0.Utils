@echo off

SET dotnet="dotnet.exe" 
SET opencover="%USERPROFILE%\.nuget\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe"
SET reportgenerator="%USERPROFILE%\.nuget\packages\ReportGenerator\2.5.2\tools\ReportGenerator.exe"
 
SET targetargs="test Generators.csproj" 
SET filter="+[*]* -[xunit*]*" 
::SET filter="+[*]InMemoryDatabaseAspNetCore.* -[.Model]* -[InMemory.Test]* -[.Startup]* -[.Test]* -[xunit.*]* -[FluentAssertions]* -[crypto]*" 
SET coveragefile=Coverage.xml  
SET coveragedir=Coverage
 
REM Run code coverage analysis  
::%opencover% -mergeoutput -oldStyle -target:%dotnet% -output:%coveragefile% -targetargs:%targetargs% -filter:%filter% -targetdir:%cd%\tests\Generators\ -searchdirs:%cd%\tests\Generators\bin\Debug\netcoreapp1.1\
::-skipautoprops -hideskipped:All
 
REM Generate the report  
::%reportgenerator% -targetdir:%coveragedir% -reporttypes:Html;Badges -reports:%coveragefile% -verbosity:Error
 
REM Open the report  
::start "report" "%coveragedir%\index.htm"
%opencover% "-target:dotnet.exe" -targetargs:test -register:user -filter:"+[*]* -[xunit*]*" -output:coverage.xml -oldStyle -skipautoprops -returntargetcode -showunvisited -log:All
@echo off

SET dotnet="dotnet.exe" 
SET opencover="%USERPROFILE%\.nuget\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe"
SET reportgenerator="%USERPROFILE%\.nuget\packages\ReportGenerator\3.0.0\tools\ReportGenerator.exe"
SET coveralls="%USERPROFILE%\.nuget\packages\coveralls.net\0.7.0\tools\csmacnz.Coveralls.exe"
 
SET targetargs="test Generators.csproj" 
SET filter="+[Bit0*]* -[xunit*]* -[Bit0.Utils.Tests*]*" 
::SET filter="+[*]InMemoryDatabaseAspNetCore.* -[.Model]* -[InMemory.Test]* -[.Startup]* -[.Test]* -[xunit.*]* -[FluentAssertions]* -[crypto]*" 

SET reporttypes=Html;Badges
::SET reporttypes=Html;Badges;HtmlSummary;HtmlChart;PngChart;XML

SET datetime=%date%_%time::=.%

SET coverageroot=%~dp0\Coverage
SET historyroot=%coverageroot%\History
SET coveragedir=%historyroot%\Coverage
SET historydir=%historyroot%\Report
SET reportsdir=%coverageroot%\Reports
SET reportdir=%reportsdir%\%datetime%

SET coveragefile=%coveragedir%\%datetime%.xml

IF NOT EXIST %coveragedir% mkdir %coveragedir%
IF NOT EXIST %historydir% mkdir %historydir%
IF NOT EXIST %reportsdir% mkdir %reportsdir%
 
REM Run code coverage analysis  
::%opencover% -mergeoutput -oldStyle -target:%dotnet% -output:%coveragefile% -targetargs:%targetargs% -filter:%filter% -targetdir:%cd%\tests\Generators\ -searchdirs:%cd%\tests\Generators\bin\Debug\netcoreapp1.1\
::-skipautoprops -hideskipped:All
%opencover% "-target:%dotnet%" -targetargs:test -register:user -filter:%filter% -output:%coveragefile% -oldStyle -skipautoprops -returntargetcode -showunvisited -log:Error -skipautoprops
 
REM Generate the report  
%reportgenerator% -targetdir:%reportdir% -reporttypes:%reporttypes% -reports:%coveragefile% -historydir:"%historydir%" -verbosity:Error

copy %coveragefile% cover.xml
::%coveralls% --opencover -i cover.xml --repoToken %coverallsToken%
del cover.xml

REM Open the report  
start "report" "%reportdir%\index.htm"

REM Run xUnit tests
REM ---------------
mkdir xUnit_Results
..\packages\xunit.runner.console.2.2.0\tools\xunit.console ..\tests\bin\Debug\LamedalCore.Test.exe -html xUnit_Results\xUnit_Results.html
pause
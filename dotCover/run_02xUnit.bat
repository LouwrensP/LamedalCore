echo Run xUnit tests
echo ---------------
echo .
echo Change this bat file to point to the exe of dll that need to be tested.
pause
echo -------------------------------
mkdir xUnit_Results
..\packages\xunit.runner.console.2.2.0\tools\xunit.console ..\tests\bin\Debug\LamedalCore.Test.exe -html xUnit_Results\xUnit_Results.html
pause
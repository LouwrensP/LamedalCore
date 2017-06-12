echo Install required nuget packages!
echo -------------------------------
echo .
echo Download nuget.exe from https://dist.nuget.org/index.html and save in this folder (dotcover folder)
pause

nuget Install JetBrains.dotCover.CommandLineTools -Version 2017.1.20170428.83814 -OutputDirectory ..\packages
nuget Install xunit.runner.console -Version 2.2.0 -OutputDirectory ..\packages
nuget Install ReportGenerator -Version 2.5.8 -OutputDirectory ..\packages
pause
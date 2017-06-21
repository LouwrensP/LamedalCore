echo Run dotCover analysis
echo ---------------------
echo .
echo Please edit run_dotCover.xml and run_dotCover_xml.xml to ensure the settings are corect. 
pause

rem ..\packages\JetBrains.dotCover.CommandLineTools.2017.1.20170428.83814\tools\dotcover help analyse run_dotCoverSample.xml

..\packages\JetBrains.dotCover.CommandLineTools.2017.1.20170428.83814\tools\dotcover analyse run_dotCover.xml
..\packages\JetBrains.dotCover.CommandLineTools.2017.1.20170428.83814\tools\dotcover analyse run_dotCover_xml.xml
pause
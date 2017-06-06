REM Create reports
..\packages\ReportGenerator.2.5.8\tools\ReportGenerator.exe "-reports:dotCover_Results\dotCover_Results.xml" "-reporttypes:Badges" "-targetdir:./"
..\packages\ReportGenerator.2.5.8\tools\ReportGenerator.exe "-reports:dotCover_Results\dotCover_Results.xml" "-reporttypes:Badges;Html;HTMLSummary;MHTML" "-targetdir:dotCover_Reports"
pause

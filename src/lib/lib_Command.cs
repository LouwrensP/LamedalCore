using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Node_Action)]
    public sealed class lib_Command
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Run a command</summary>
        /// <param name="strCmd">The string command.</param>
        /// <param name="strArgs">The string arguments.</param>
        /// <param name="strFolder">The string folderOrFile.</param>
        /// <param name="waitForExit">if set to <c>true</c> [wait for exit].</param>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        public void Execute(string strCmd, string strArgs = "", string strFolder = "", bool waitForExit = false)
        {
            Console.WriteLine(" ->" + strCmd + " " + strArgs + " (" + strFolder + ")");

            if (strArgs == "" && strFolder == "" && strCmd.Contains("http"))
            {
                Process.Start("explorer.exe", strCmd);
                return;
            }

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = strCmd;
            startInfo.Arguments = strArgs;
            if (strFolder != "") startInfo.WorkingDirectory = strFolder;
            // System.Environment.CurrentDirectory = @"..\..\..";
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            if (waitForExit)
            {
                process.StandardInput.Flush();
                process.WaitForExit();
                Console.WriteLine(process.StandardOutput.ReadToEnd());
            }
        }

        /// <summary>Open explorer window for the folderOrFile specified. If none provided the application folderOrFile will be opened.</summary>
        /// <param name="folderOrFile">The folderOrFile.</param>
        /// <param name="waitForExit">if set to <c>true</c> [wait for exit].</param>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        public void Execute_Explorer(string folderOrFile = "", bool waitForExit = false)
        {
            // Default values
            string folder = folderOrFile;
            string file = folderOrFile;
            if (folder == "")
            {
                folder = _lamed.lib.IO.Folder.Path_Application();
                file = folder;
            }
            else
            {
                if (_lamed.lib.IO.File.Exists(folder))  // The folderOrFile parameter is a file -> calculate the folder 
                {
                    file = folder;
                    folder = _lamed.lib.IO.Parts.Folder(file);
                }
            }
            file = file.Replace("/", @"\");
            folder = folder.Replace("/", @"\");
            Execute("explorer.exe", file, folder,waitForExit);
        }

        /// <summary>Open notepad for the document specified.</summary>
        /// <param name="document">The document.</param>
        /// <param name="folder">The folderOrFile.</param>
        /// <param name="waitForExit">if set to <c>true</c> [wait for exit].</param>
        [Test_IgnoreCoverage(enTestIgnore.FrontendCode)]
        public void Execute_Notepad(string document, string folder = "", bool waitForExit = false)
        {
            if (folder == "") folder = _lamed.lib.IO.Folder.Path_Application();
            _lamed.lib.Command.Execute("Notepad.exe", document, folder,waitForExit);
        }

        /// <summary>Sleeps the specified milli seconds.</summary>
        /// <param name="milliSeconds">The milli seconds.</param>
        public void Sleep(int milliSeconds)
        {
            Task.Delay(milliSeconds).Wait();
        }

    }
}

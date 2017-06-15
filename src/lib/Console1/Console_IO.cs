using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;
using static System.String;

namespace LamedalCore.lib.Console1
{
    public sealed class Console_IO
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>
        /// Provide introduction message abouts this project.
        /// </summary>
        /// <returns></returns>
        public string About_()
        {
            var about = 
" _        _______  _______  _______  ______   _______  _".NL()+        
"( \\      (  ___  )(       )(  ____ \\(  __  \\ (  ___  )( \\".NL()+       
"| (      | (   ) || () () || (    \\/| (  \\  )| (   ) || (".NL()+       
"| |      | (___) || || || || (__    | |   ) || (___) || | _____".NL()+ 
"| |      |  ___  || |(_)| ||  __)   | |   | ||  ___  || |(_____)".NL()+
"| |      | (   ) || |   | || (      | |   ) || (   ) || |".NL()+       
"| (____/\\| )   ( || )   ( || (____/\\| (__/  )| )   ( || (____/\\".NL()+ 
"(_______/|/     \\||/     \\|(_______/(______/ |/     \\|(_______/".NL()+ 
"".NL()+                                                                
" _       _________ ______".NL()+    
"( \\      \\__   __/(  ___ \\".NL()+   
"| (         ) (   | (   ) )".NL()+  
"| |         | |   | (__/ /".NL()+   
"| |         | |   |  __ (".NL()+    
"| |         | |   | (  \\ \\".NL()+   
"| (____/\\___) (___| )___) )_".NL()+ 
"(_______/\\_______/|/ \\___/(_)";
            return about;
        }

        /// <summary>
        /// Shows  a hello world message
        /// </summary>
        /// <returns></returns>
        public string About_HelloWorld_()
        {
            //Cell test;

            var hello = "Hello, I am LamedaL. I am your helper library for open source cross platform applications.";
            return hello;
        }

        /// <summary>Shows a message abouts the Lamedal library.</summary>
        public void About_WriteLine()
        {
            var about = About_();
            Console.WriteLine(about);
        }

        /// <summary>Shows a Hello World console message.</summary>
        public void About_HelloWorld_WriteLine()
        {
            var hello = About_HelloWorld_();
            Console.WriteLine(hello);
        }

        /// <summary>Reads the line and show the default value</summary>
        /// <param name="question">The question.</param>
        /// <param name="defaultValue">The defaultValue.</param>
        [Test_IgnoreCoverage(enCode_TestIgnore.FrontendCode)]
        public void ReadLine(string question, ref string defaultValue)
        {
            //var info = defaultValue.GetType().GetTypeInfo();
            //if (question.zContains_All("{", "}")) question = question.zFormat(defaultValue);
            Console.Write(question + " [" + defaultValue +"]");
            var readLn = Console.ReadLine();
            if (readLn != "") defaultValue = readLn;
        }

        /// <summary>Menu from the in array optional array.</summary>
        /// <param name="menuItems">The in array optional array</param>
        /// <returns>int</returns>
        [Test_IgnoreCoverage(enCode_TestIgnore.FrontendCode)]
        public int Menu_Interactive(params string[] menuItems)
        {
            // Check parameters
            if (TestCode1==false) if (menuItems.Length > Console.WindowHeight) throw new Exception("Too many items in the array to display");

            bool loopComplete = false;
            var cursorBottom = 0;
            int selectedItem = 0;
            int cursorTop = 0;
            if (TestCode1 == false)
            {
                Console.CursorVisible = false;
                cursorTop = Console.CursorTop;
            }
            // Drawing phase
            while (!loopComplete)
            {//This for loop prints the array out
                if (TestCode1 == false) System.Console.SetCursorPosition(0, cursorTop);  // Reset the cursor to the top of the screen
                for (int ii = 0; ii < menuItems.Length; ii++)
                {
                    if (ii == selectedItem)
                         WriteLine_HighLight(menuItems[ii], true);  // This section is what highlights the selected item
                    else WriteLine_HighLight(menuItems[ii]);        // This section is what prints unselected items
                }
                if (TestCode1 == false) cursorBottom = System.Console.CursorTop;

                ConsoleKeyInfo key;
                if (TestCode1)
                {
                    // Allow testing code to run this method
                    key = new ConsoleKeyInfo(' ', ConsoleKey.Enter, false, false, false);
                }
                else key = System.Console.ReadKey(true);

                Menu_ReadKey1(key, menuItems.Length, ref selectedItem, ref loopComplete);
            }
            if (TestCode1 == false)
            {
                System.Console.SetCursorPosition(0, cursorBottom); // Set the cursor just after the menu so that the program can continue after the menu
                System.Console.CursorVisible = true;
            }
            TestCode1 = false;

            return selectedItem + 1;
        }
        public static bool TestCode1 = false;

        [Test_IgnoreCoverage(enCode_TestIgnore.FrontendCode)]
        public void Menu_ReadKey1(ConsoleKeyInfo consoleKeyInfo, int menuItemsCount, ref int selectedItem, ref bool loopComplete)
        {
            switch (consoleKeyInfo.Key)
            {
                //react to input
                case ConsoleKey.UpArrow:
                    if (selectedItem > 0) selectedItem--;
                    else selectedItem = (menuItemsCount - 1);
                    break;

                case ConsoleKey.DownArrow:
                    if (selectedItem < (menuItemsCount - 1)) selectedItem++;
                    else selectedItem = 0;
                    break;

                case ConsoleKey.Enter:
                    loopComplete = true;
                    break;
            }
        }

        /// <summary>Writes the line to the console with a highlight if applicable.</summary>
        /// <param name="line">The line.</param>
        /// <param name="highlight">if set to <c>true</c> [highlight].</param>
        public void WriteLine_HighLight(string line, bool highlight = false)
        {
            if (highlight)
            {
                System.Console.BackgroundColor = ConsoleColor.Gray;
                System.Console.ForegroundColor = ConsoleColor.Black;
            }
            System.Console.WriteLine("-" + line);

            if (highlight) System.Console.ResetColor();
        }

        /// <summary>Formats the values to table format.</summary>
        /// <param name="reset">if set to <c>true</c> [reset].</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public string Table_FormatStr(bool reset = false, params string[] values)
        {
            var result = "";

            // Safety checks
            var test = FormatStr(values.Length - 1);
            if (_formatStr.Contains(test) == false && reset == false) reset = Table_FormatReset(out result);
            // Format header -> add extra space in for header values
            var valueList = (reset) ? values.Select(x => " " + x + " ").ToArray() : values.ToArray();

            if (reset)
            {
                // Calculate the widths & build the format string
                _formatStr = "";
                int ii = 0;
                foreach (var val in valueList)
                {
                    _formatStr += FormatStr(ii, val.Length);
                    ii++;
                }
                _formatStr += "|";
            }

            // Print the value out
            result += Format(_formatStr, valueList);

            // Add line for headings
            if (reset)
            {
                var line = Environment.NewLine;
                for (int ii = 0; ii < result.Length; ii++)
                {
                    line += "-";
                }
                result += line;
            }

            return result;
        }

        [Test_IgnoreCoverage(enCode_TestIgnore.FrontendCode)]
        private bool Table_FormatReset(out string result)
        {
            result = Environment.NewLine; // This is an auto reset. Add extra line
            var reset = true;
            return reset;
        }

        private string _formatStr = "";

        /// <summary>
        /// Create the format string
        /// </summary>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string FormatStr(int index, int length = 0)
        {
            var result = "|{" + index + ",";
            if (length == 0) return result;

            result += "-" + length + "}";
            return result;
        }
    }
}

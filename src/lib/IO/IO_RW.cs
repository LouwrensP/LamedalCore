using System;
using System.IO;
using System.Linq;
using System.Reflection;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.IO
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action)]
    public sealed class IO_RW
    {
        private readonly IO_ _io = LamedalCore_.Instance.lib.IO;

        /// <summary>Files the append.</summary>
        /// <param name="pathAndFile">The path and file.</param>
        /// <param name="txt">The text.</param>
        /// <param name="threadSafeObject">The thread safe object. </param>
        public void File_Append(string pathAndFile, string txt, object threadSafeObject = null)
        {
            if (threadSafeObject == null) File.AppendAllText(pathAndFile, txt);
            else
            {
                lock (threadSafeObject)
                {
                    File.AppendAllText(pathAndFile, txt);
                }
            }
        }

        /// <summary>Write to file name</summary>
        /// <param name="pathAndFile">The path and file.</param>
        /// <param name="txt">The text.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public void File_Write(string pathAndFile, string txt, bool overwrite)
        {
            File_Write(pathAndFile, txt, overwrite ? enIO_WriteAction.OverWriteFile : enIO_WriteAction.WriteFile);
        }

        /// <summary>Write to file name</summary>
        /// <param name="pathAndFile">The path and file.</param>
        /// <param name="lines">The text.</param>
        /// <param name="overwrite">if set to <c>true</c> [overwrite].</param>
        public void File_Write(string pathAndFile, string[] lines, bool overwrite)
        {
            File_Write(pathAndFile, lines, overwrite ? enIO_WriteAction.OverWriteFile : enIO_WriteAction.WriteFile);
        }

        /// <summary>Write to file name</summary>
        /// <param name="pathAndFile">The path and file.</param>
        /// <param name="txt">The text.</param>
        /// <param name="writeAction">The write action.</param>
        public void File_Write(string pathAndFile, string txt, enIO_WriteAction writeAction = enIO_WriteAction.WriteFile)
        {
            if (writeAction == enIO_WriteAction.OverWriteFile)
            {
                File.WriteAllText(pathAndFile, txt);
                return;
            }

            bool fileExist = _io.File.Exists(pathAndFile);
            if (writeAction == enIO_WriteAction.WriteFile)
            {
                if (fileExist)
                {
                    var ex = new ArgumentException("Error! Can not write to file because it already exists.", nameof(writeAction));
                }
                else File.WriteAllText(pathAndFile, txt);
            } else if (writeAction == enIO_WriteAction.AppendFile)
            {
                if (_io.File.Exists(pathAndFile)) txt = "".NL() + txt; // Add extra space into file
                File.AppendAllText(pathAndFile, txt);
            }
        }

        /// <summary>Write to file name</summary>
        /// <param name="pathAndFile">The path and file.</param>
        /// <param name="lines">The lines.</param>
        /// <param name="writeAction">The write action.</param>
        public void File_Write(string pathAndFile, string[] lines, enIO_WriteAction writeAction = enIO_WriteAction.WriteFile)
        {
            var txt = lines.zTo_Str("".NL());
            File_Write(pathAndFile, txt, writeAction);
        }

        /// <summary>Read the contents of the file.</summary>
        /// <param name="pathAndFile">The path and file.</param>
        /// <param name="errorIfNoExist">if set to <c>true</c> [error if no exist].</param>
        /// <returns></returns>
        public string File_Read2Str(string pathAndFile, bool errorIfNoExist = true)
        {
            string result;
            if (errorIfNoExist == false)
            {
                if (_io.File.Exists(pathAndFile) == false) return "";   // File does not exists & this is ok
            }
            try
            {
                result = File.ReadAllText(pathAndFile);
            }
            catch (Exception ex)
            {
                
                var msg = _io.Parts._Format2Slash(ex.Message);
                throw new FileNotFoundException(msg, ex);
            }
            return result;
        }

        public string[] File_Read2StrArray(string pathAndFile)
        {
            var Return = File.ReadAllLines(pathAndFile);
            return Return;
        }

    }
}

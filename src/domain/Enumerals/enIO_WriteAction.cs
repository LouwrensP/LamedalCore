namespace LamedalCore.domain.Enumerals
{
    public enum enIO_WriteAction
    {
        /// <summary>The write file if it does not exist</summary>
        WriteFile,
        /// <summary>Write the file if it does not exist. Over write file if it exist</summary>
        OverWriteFile,
        /// <summary>Write the file if it does not exist. Append to the file if it exist.</summary>
        AppendFile
    }
}
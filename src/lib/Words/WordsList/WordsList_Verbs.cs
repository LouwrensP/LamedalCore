using System.Collections.Generic;

namespace LamedalCore.lib.Words.WordsList
{
    public sealed class WordsList_Verbs
    {
        private static List<string> _list;
        public static List<string> VerbsList_Create()
        {
           if (_list != null) return _list;
           _list = new List<string>();


            #region a-c
              _list.Add("Add");
              _list.Add("act");
              _list.Add("Apply");
              _list.Add("Approve->status");
              _list.Add("Assemble");
              _list.Add("Assert->status");
              _list.Add("Assign");
              _list.Add("Attach");
              _list.Add("Authorize");
              _list.Add("Backup->data");
              _list.Add("Block->security");
              _list.Add("Build");
              _list.Add("Calculate");
              _list.Add("Cancel");
              _list.Add("Check");
              _list.Add("Classify");
              _list.Add("Clear");
              _list.Add("Close");
              _list.Add("Collect");
              _list.Add("Compare->data");
              _list.Add("compete");
              _list.Add("Complete->status");
              _list.Add("Compress->data");
              _list.Add("Compile");
              _list.Add("Compose");
              _list.Add("Compute");
              _list.Add("Confirm->status");
              _list.Add("Construct");
              _list.Add("Word_FromAbbreviation->data");
              _list.Add("Copy");
              _list.Add("Correct");
              _list.Add("Create");
            #endregion

            #region d-i
              _list.Add("DateStamp");
              _list.Add("DateTimeStamp");
              _list.Add("Debug->Diagnostic");
              _list.Add("Delete");
              _list.Add("Deny->status");
              _list.Add("Direct");
              _list.Add("Divide");
              _list.Add("Disable->status");
              _list.Add("Edit->data");
              _list.Add("Enable->status");
              _list.Add("Enter");
              _list.Add("Execute");
              _list.Add("Exit");
              _list.Add("Export->data");
              _list.Add("Find");
              _list.Add("Format");
              _list.Add("Generate");
              _list.Add("Get");
              _list.Add("Grand->security");
              _list.Add("Group->data");
              _list.Add("Help");
              _list.Add("Hide");
              _list.Add("Implement");
              _list.Add("Import->data");
              _list.Add("Inform");
              _list.Add("Initiate");
              _list.Add("Initialize->data");
              _list.Add("Insert->data");
              _list.Add("Inspect");
              _list.Add("Install->status");
              _list.Add("Investigate");
              _list.Add("Issue");
              _list.Add("Itemize");
            #endregion

            #region j-p
              _list.Add("Join");
              _list.Add("Load->data");
              _list.Add("Locate->data");
              _list.Add("Lock");
              _list.Add("Maintain");
              _list.Add("Make");
              _list.Add("Manage");
              _list.Add("Match->data");
              _list.Add("Measure->Diagnostic");
              _list.Add("Merge->data");
              _list.Add("Mix");
              _list.Add("Move");
              _list.Add("Multiply");
              _list.Add("New");
              _list.Add("Notify");
              _list.Add("Obtain");
              _list.Add("Observe");
              _list.Add("Open");
              _list.Add("Perform");
              _list.Add("Ping");
              _list.Add("Post");
              _list.Add("Prepare");
              _list.Add("Protect->security");
              _list.Add("Publish->data");
              _list.Add("Puch");
              _list.Add("Purchase");
            #endregion

            #region q-s
              _list.Add("Receive");
              _list.Add("Recommend");
              _list.Add("Reconstruct");
              _list.Add("Redo");
              _list.Add("Release");
              _list.Add("Remove");
              _list.Add("Rename");
              _list.Add("Render");
              _list.Add("Repare->Diagnostic");
              _list.Add("Replace");
              _list.Add("Request");
              _list.Add("Require");
              _list.Add("Reset");
              _list.Add("Resolve->Diagnostic");
              _list.Add("Restart->status");
              _list.Add("Restore->data");
              _list.Add("Revoke->security");
              _list.Add("Run");
              _list.Add("Save->data");
              _list.Add("Scan");
              _list.Add("Search");
              _list.Add("Select");
              _list.Add("Set");
              _list.Add("Setup");
              _list.Add("Show");
              _list.Add("Skip");
              _list.Add("Stalls");
              _list.Add("Sort");
              _list.Add("Split");
              _list.Add("Start->status");
              _list.Add("Stop->status");
              _list.Add("Study");
              _list.Add("Submit->status");
              _list.Add("Subtract");
              _list.Add("Summarize");
              _list.Add("Sync->data");
            #endregion

            #region t-z
              _list.Add("Tabulate");
              _list.Add("Talk");
              _list.Add("Test->Diagnostic");
              _list.Add("Trace->Diagnostic");
              _list.Add("Unblock->security");
              _list.Add("Uninstall->status");
              _list.Add("Unprotect->security");
              _list.Add("Update->data");
              _list.Add("Use");
              _list.Add("Verify");
              _list.Add("Wait->status");
              _list.Add("Walk");
              _list.Add("Write");
            #endregion

            _list.Sort();
            return _list;
        }
    }
}
            
//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ControlError.cs
// Creater:  Xue.wenlong
// Date:  2010-04-19
// Resume:
// ----------------------------------------------------------------

namespace SEP.Model.Utility
{
    /// <summary>
    /// </summary>
    public class ControlError
    {
        private string _ControlID;
        private string _ErrorMessage;
        public ControlError(string controlID, string message)
        {
            _ControlID = controlID;
            _ErrorMessage = message;
        }

        public string ErrorControlID
        {
            set { _ControlID = value; }
            get { return _ControlID; }
        }

        public string ErrorMessage
        {
            set { _ErrorMessage = value; }
            get { return _ErrorMessage; }
        }
    }
}
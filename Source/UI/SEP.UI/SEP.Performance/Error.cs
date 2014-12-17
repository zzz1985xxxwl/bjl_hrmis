//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: Error.cs
// Creater:  Xue.wenlong
// Date:  2009-11-19
// Resume:
// ----------------------------------------------------------------

namespace SEP.Performance
{
    /// <summary>
    /// </summary>
    public class Error
    {
        private string _ControlID;
        private string _ErrorMessage;
        public Error(string controlID, string message)
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

    public class HtmlModal
    {
        private string _Html;
        public HtmlModal(string html)
        {
            _Html = html;
        }

        public string Html
        {
            set { _Html = value; }
            get { return _Html; }
        }
    }
}
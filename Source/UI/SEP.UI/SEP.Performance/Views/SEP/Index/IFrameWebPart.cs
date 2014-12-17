//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IFrameWebPart.cs
// Creater:  Xue.wenlong
// Date:  2009-11-04
// Resume:
// ----------------------------------------------------------------

using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

namespace SEP.Performance.Views.SEP.Index
{
    /// <summary>
    /// </summary>
    public class IFrameWebPart : WebPart
    {
        private string _Url;

        [Personalizable(true)]
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }

        protected override void CreateChildControls()
        {
            Controls.Clear();
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerHtml =
                "<iframe frameborder=\"0\" scrolling=\"no\"  onload=\"autoHight(this,300);\" style=\"border: 0pt none ; margin: 0pt; padding: 0pt; overflow: hidden; width: 100%;min-height:100px; \"  src=\"" +
                Url + "\"></iframe>";
            div.Attributes.Add("style", "width:100%;");
            Controls.Add(div);
            ChildControlsCreated = true;
        }
    }
}
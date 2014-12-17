using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ColorPicker.Web.UI
{
    public class ColorPicker : HiddenField
    {
        private int _ColorPickerID;

        public int PickerID
        {
            get { return (int) ViewState[_ColorPickerID.ToString()]; }

            set
            {
                _ColorPickerID = value;

                ViewState[_ColorPickerID.ToString()] = value;
            }
        }

        public string ScriptPath
        {
            get
            {
                if (ViewState["ColorPickerCSS"] == null)
                {
                    ViewState["ColorPickerCSS"] = "";
                }
                return ViewState["ColorPickerCSS"].ToString();
            }
            set { ViewState["ColorPickerCSS"] = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            String link1 =
                string.Format(
                    "<link type=\"text/css\" rel=\"stylesheet\" href='{0}css/colorpicker.css'></link>",
                    ScriptPath);
            String link2 =
                string.Format(
                    "<link type=\"text/css\" rel=\"stylesheet\" media='screen' href='{0}css/layout.css'></link>",
                    ScriptPath);
            AddCssLink(link1, "colorpicker");
            AddCssLink(link2, "layout");
        }

        private void AddCssLink(string link, string cssLinkID)
        {
            LiteralControl cssLink = new LiteralControl(link);
            cssLink.ID = cssLinkID;
            HtmlHead pageHead = Page.Header;
            if (pageHead.FindControl(cssLinkID) == null)
            {
                pageHead.Controls.Add(cssLink);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            ClientScriptManager scripts = Page.ClientScript;
            if (!scripts.IsClientScriptIncludeRegistered("jquery"))
            {
                scripts.RegisterClientScriptInclude("jquery", Page.ResolveClientUrl(ScriptPath + "js/jquery.js"));
            }
            if (!scripts.IsClientScriptIncludeRegistered("colorpicker"))
            {
                scripts.RegisterClientScriptInclude("colorpicker",
                                                    Page.ResolveClientUrl(ScriptPath + "js/colorpicker.js"));
            }
            if (!scripts.IsClientScriptIncludeRegistered("eye"))
            {
                scripts.RegisterClientScriptInclude("eye", Page.ResolveClientUrl(ScriptPath + "js/eye.js"));
            }
            if (!scripts.IsClientScriptIncludeRegistered("utils"))
            {
                scripts.RegisterClientScriptInclude("utils", Page.ResolveClientUrl(ScriptPath + "js/utils.js"));
            }
            StringBuilder script = new StringBuilder();
            script.AppendLine("<script type=\"text/javascript\">(function($){");
            script.AppendLine("var initLayout = function() {");
            script.AppendLine(string.Format("$('#colorSelector{0}').ColorPicker(", PickerID));
            script.AppendLine("{onShow: function (colpkr) {");
            script.AppendLine("$(colpkr).fadeIn(500);");
            script.AppendLine("return false;");
            script.AppendLine("},");
            script.AppendLine("onBeforeShow: function(){");
            script.AppendLine("$(this).ColorPickerSetColor(this.childNodes[0].style.backgroundColor);");
            script.AppendLine("},");
            script.AppendLine("onHide: function (colpkr) {");
            script.AppendLine("$(colpkr).fadeOut(500);");
            script.AppendLine("return false;");
            script.AppendLine("},");
            script.AppendLine("onChange: function (hsb, hex, rgb) {");
            script.AppendLine(
                string.Format("$('#colorSelector{0} div').css('backgroundColor', '#' + hex);", PickerID));
            script.AppendLine(
                string.Format("$('#colorSelectorInner{0} div').css('backgroundColor', '#' + hex);", PickerID));
            script.AppendLine(string.Format("$('#{0}').val('#'+hex);", ID));
            script.AppendLine("}});};	EYE.register(initLayout, 'init');})(jQuery)</script>");
            if (!scripts.IsStartupScriptRegistered(typeof(ColorPicker), "register" + PickerID))
            {
                scripts.RegisterStartupScript(typeof(ColorPicker), "register" + PickerID, script.ToString());
            }

        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            writer.Write(
                string.Format(
                    "<div id=\"colorSelector{0}\" class=\"ColorSelectorM\"><div id=\"colorSelectorInner{0}\"  style=\"background-color: {1}\" class=\"ColorSelectorDivM\"></div></div>",
                    PickerID, Value));
        }
    }
}
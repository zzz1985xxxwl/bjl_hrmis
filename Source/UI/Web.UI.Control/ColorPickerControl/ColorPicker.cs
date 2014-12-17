using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ColorPickerControl
{
    public class ColorPicker : WebControl
    {
        private static int count = 0;//add by wsl for the gridview
        #region Public Properties

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("#CCCCCC")]
        [Localizable(true)]
        public string Color
        {
            get
            {
                String s = (String)ViewState["Color"];
                return ((s == null) ? "#CCCCCC" : s);
            }

            set
            {
                ViewState["Color"] = value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string TargetControlID
        {
            get
            {
                String s = (String)ViewState["TargetControlID"];
                return (s ?? "");
            }

            set
            {
                ViewState["TargetControlID"] = value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("false")]
        [Localizable(true)]
        public bool ReadOnly
        {
            get
            {
                if (ViewState["ReadOnly"] == null)
                {
                    ViewState["ReadOnly"] = false;
                }
                bool b = (Boolean) ViewState["ReadOnly"];
                return b;
            }

            set
            {
                ViewState["ReadOnly"] = value;
            }
        }

        #endregion

        #region Web.Control implementation

        protected override void OnInit(EventArgs e)
        {
            base.OnPreRender(e);
            // Javascript
            string colorFunctions = Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker), "ColorPickerControl.Javascript.ColorPicker.js");
            Page.ClientScript.RegisterClientScriptInclude("ColorPicker.js", colorFunctions);

            //Images
            string script = string.Format(@"
            var colorPicker = new ColorPicker();
            colorPicker.FormWidgetAmountSliderHandleImage = '{0}';
            colorPicker.TabRightActiveImage = '{1}';
            colorPicker.TabRightInactiveImage = '{2}';
            colorPicker.TabLeftActiveImage = '{3}';
            colorPicker.TabLeftInactiveImage = '{4}';            
            ", Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker), "ColorPickerControl.Images.SliderHandle.gif")
             , Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker), "ColorPickerControl.Images.TabRightActive.gif")
             , Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker), "ColorPickerControl.Images.TabRightInactive.gif")
             , Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker), "ColorPickerControl.Images.TabLeftActive.gif")
             , Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker), "ColorPickerControl.Images.TabLeftInactive.gif")
             );

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "InitColorPicker", script, true);

            // CSS            
            bool linkIncluded = false;
            foreach (Control c in Page.Header.Controls)
            {
                if (c.ID == "ControlPickerStyle")
                {
                    linkIncluded = true;
                }
            }
            if (!linkIncluded)
            {
                HtmlGenericControl csslink = new HtmlGenericControl("link");
                //csslink.ID = "ColorPickerStyle";
                csslink.Attributes.Add("href", Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker), "ColorPickerControl.Styles.ColorPicker.css"));
                csslink.Attributes.Add("type", "text/css");
                csslink.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(csslink);
            }
            count = 0;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Page != null && Page.IsPostBack)
            {
                Color = Page.Request.Form[ColorInputControlClientName];
            }
            base.OnLoad(e);
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            TextBox tb = (TextBox)FindControl(TargetControlID);
            Table table = new Table();
            table.Rows.Add(new TableRow());
            table.Rows[0].Cells.Add(new TableCell());
            table.Rows[0].Cells.Add(new TableCell());
            //HtmlInputText txt = new HtmlInputText();
            HtmlInputImage btnHidden = new HtmlInputImage();
            HtmlInputImage btnShow = new HtmlInputImage();
            //txt.ID = "txt" + ColorInputControlClientId;
            btnShow.ID = "btnShow" + ColorInputControlClientId;
            btnHidden.ID = "btnHidden" + ColorInputControlClientId;
            //txt.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, Color);
            //txt.Size = 4;
            //txt.Value = Color;
            //txt.MaxLength = 15;
            //txt.Name = ColorInputControlClientName;
            //txt.Attributes.Add("class","input1");
            //table.Rows[0].Cells[0].Controls.Add(txt);
            //modify by wsl
            btnHidden.Src =
                Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker),
                                                    ReadOnly
                                                        ? "ColorPickerControl.Images.ColorPickerIcon_ReadOnly.gif"
                                                        : "ColorPickerControl.Images.ColorPickerIcon.gif");
            btnHidden.Attributes.CssStyle.Add(HtmlTextWriterStyle.Display, "none");
            table.Rows[0].Cells[0].Controls.Add(btnHidden);
            table.Rows[0].Cells[0].Attributes.CssStyle.Add(HtmlTextWriterStyle.Position, "relative");
            //add by wsl
            btnShow.Src = Page.ClientScript.GetWebResourceUrl(typeof(ColorPicker),
                                                              ReadOnly
                                                                  ? "ColorPickerControl.Images.ColorPickerIcon_ReadOnly.gif"
                                                                  : "ColorPickerControl.Images.ColorPickerIcon.gif");
            if (!ReadOnly)
            {
                btnShow.Attributes.Add("onclick",
                                       string.Format(
                                           "colorPicker.ShowColorPicker('{0}','{1}','{2}');return false;",
                                           btnHidden.ClientID, btnShow.ClientID, tb.ClientID));
            }
            else
            {
                btnShow.Attributes.Add("onclick", "return false;");
            }
            btnShow.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, tb.Text.Trim());
            table.Rows[0].Cells[1].Controls.Add(btnShow);
            //Ö»¶Á

            table.RenderControl(output);
            count++;
        }

        #endregion

        #region Public static methods

        public static System.Drawing.Color StringToColor(string colorString)
        {
            System.Drawing.Color color;
            if (colorString[0] == '#' && colorString.Length < 8)
            {
                string s = colorString.Substring(1);
                while (s.Length != 6)
                {
                    s = string.Concat("0", s);
                }
                int red = Convert.ToInt32(s.Substring(0, 2), 16);
                int green = Convert.ToInt32(s.Substring(2, 2), 16);
                int blue = Convert.ToInt32(s.Substring(4, 2), 16);
                color = System.Drawing.Color.FromArgb(red, green, blue);
            }
            else
            {
                color = System.Drawing.Color.FromName(colorString);
            }
            return color;
        }
        public static string ColorToString(System.Drawing.Color color)
        {
            string result;
            if (color.IsKnownColor || color.IsNamedColor || color.IsSystemColor)
            {
                result = color.Name;
            }
            else
            {
                result = string.Concat("#", color.ToArgb().ToString("X").Substring(2));
            }
            return result;
        }

        #endregion

        #region Private properties

        private string ColorInputControlClientId
        {
            get { return string.Concat(ID, "_input" + count); }//modify by wsl
        }

        private string ColorInputControlClientName
        {
            get { return string.Concat(ID, "_input").Replace("_", "$"); }
        }

        #endregion
    }
}

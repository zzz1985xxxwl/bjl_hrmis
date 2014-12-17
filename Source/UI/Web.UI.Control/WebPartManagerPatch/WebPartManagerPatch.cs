using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace WebPartManagerPatch
{
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(System.Security.Permissions.SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class WebPartManagerPatch : WebPartManager
    {
        protected override void RegisterClientScript()
        {
            if (CheckRenderClientScript())
            {
                // System.Web.UI.ScriptManager is localized in the reference System.Web.Extensions            
                System.Web.UI.ScriptManager.RegisterClientScriptResource(
                    this,
                    typeof(WebPartManager),
                    "WebParts.js");
                System.Web.UI.ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    ID + "_Script",
                    Script,
                    true);
            }
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            System.Web.UI.WebControls.Panel dragPanel = new System.Web.UI.WebControls.Panel();
            dragPanel.ID = string.Format("{0}___Drag", ClientID);
            dragPanel.Style.Add("display", "none");
            dragPanel.Style.Add("position", "absolute");
            dragPanel.Style.Add("z-index", "32000");
            dragPanel.Style.Add("filter", "alpha(opacity=75)");
            dragPanel.RenderControl(writer);
        }

        /// <summary>
        /// Property related to the client side scripts 
        /// </summary>
        private string Script
        {
            get
            {
                System.Web.UI.WebControls.WebColorConverter colorConverter = new System.Web.UI.WebControls.WebColorConverter();
                string _clientScript = string.Format(
                    "__wpm = new WebPartManager();{0}" +
                    "__wpm.overlayContainerElement = document.getElementById('{2}___Drag');{0}" +
                    "__wpm.personalizationScopeShared = {1};{0}" +
                    "var zoneElement;{0}var zoneObject;{0}",
                    System.Environment.NewLine,
                    Personalization.CanEnterSharedScope.ToString().ToLower(),
                    ClientID);
                foreach (WebPartZone z in Zones)
                {
                    bool verticalOrientation = (z.LayoutOrientation == System.Web.UI.WebControls.Orientation.Vertical);
                    bool allowLayoutChange = DisplayMode.Name != BrowseDisplayMode.Name && z.AllowLayoutChange;
                    string dragHighlightColor = colorConverter.ConvertToString(z.DragHighlightColor);
                    _clientScript += string.Format(
                        "zoneElement = document.getElementById('{1}');if (zoneElement != null) {{zoneObject = __wpm.AddZone(zoneElement, '{2}', {3}, {4}, '{5}');{0}",
                        System.Environment.NewLine,
                        z.ClientID,
                        z.UniqueID,
                        verticalOrientation.ToString().ToLower(),
                        allowLayoutChange.ToString().ToLower(),
                        dragHighlightColor);
                    foreach (WebPart p in z.WebParts)
                    {
                        bool allowZoneChange = allowLayoutChange && p.AllowZoneChange;
                        _clientScript += string.Format(
                            "    zoneObject.AddWebPart(document.getElementById('WebPart_{1}'), document.getElementById('WebPartTitle_{1}'), {2});{0}",
                            System.Environment.NewLine,
                            p.ID,
                            allowZoneChange.ToString().ToLower());
                    }
                    _clientScript += "}";
                }
                foreach (WebPartZone z in Zones)
                {
                    string itemStyle = z.MenuVerbStyle.GetStyleAttributes(null).Value;
                    string itemHoverStyle = z.MenuVerbHoverStyle.GetStyleAttributes(null).Value;
                    string labelHoverColor = colorConverter.ConvertToString(z.MenuLabelHoverStyle.ForeColor);
                    if (z.WebPartVerbRenderMode == WebPartVerbRenderMode.Menu)
                    {
                        foreach (WebPart p in z.WebParts)
                        {
                            string verbMenuScript = string.Format(
                                "var menuWebPart_{0}Verbs = new WebPartMenu(document.getElementById('WebPart_{0}Verbs'), document.getElementById('WebPart_{0}VerbsPopup'), document.getElementById('WebPart_{0}VerbsMenu'));{1}" +
                                "menuWebPart_{0}Verbs.itemStyle = '{3};';{1}" +
                                "menuWebPart_{0}Verbs.itemHoverStyle = '{4}';{1}" +
                                "menuWebPart_{0}Verbs.labelHoverColor = '{5}';{1}" +
                                "menuWebPart_{0}Verbs.labelHoverClassName = '{2}__Menu_1';{1}{1}",
                                p.ID,
                                System.Environment.NewLine,
                                z.ID,
                                itemStyle,
                                itemHoverStyle,
                                labelHoverColor);
                            _clientScript += verbMenuScript;
                        }
                    }
                }
                return _clientScript;
            }
        }
    }
}

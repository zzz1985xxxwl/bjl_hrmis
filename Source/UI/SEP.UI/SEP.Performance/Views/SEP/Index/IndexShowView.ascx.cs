using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Indexs;

namespace SEP.Performance.Views.SEP.Index
{
    public partial class IndexShowView : UserControl
    {
        private WebPartManager _WebPartManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            //修正小界面关闭按钮
            try
            {
                new IndexEditPresenter(IndexEditView1,LoginUser);
                Account account = (Account) Session[SessionKeys.LOGININFO];
                FormsAuthentication.SetAuthCookie(account.Id.ToString(), true);
                _WebPartManager = WebPartManager1;
                _WebPartManager.DisplayMode = WebPartManager.DesignDisplayMode;
                _WebPartManager.WebPartClosed += (_WebPartManager_WebPartClosed);

                #region 常用工具            

                IndexEditView1._AddView = AddView;

                #endregion

                AddEmptyPage();
            }
            catch
            {
                Response.Redirect("../../Login.aspx");
            }
        }

        private Account _LoginUser;
        public Account LoginUser
        {
            set { _LoginUser = value; }
            get { return _LoginUser; }
        }

        private void AddEmptyPage()
        {
            if (_WebPartManager.WebParts.Count < 1)
            {
                EmptyPage.Visible = true;
                EmptyPage.Style["display"] = "block";
                webPartTable.Style["display"] = "none";
            }
            else
            {
                EmptyPage.Visible = false;
                EmptyPage.Style["display"] = "none";
                webPartTable.Style["display"] = "block";
            }
        }

        private void _WebPartManager_WebPartClosed(object sender, WebPartEventArgs e)
        {
            _WebPartManager.DeleteWebPart(e.WebPart);
            AddEmptyPage();
        }

        #region add webpart

        /// <summary>
        /// 把自定义控件加入页面
        /// </summary>
        /// <param name="url">自定义控件的地址</param>
        /// <param name="id">控件ID，由于是动态生成的，所以页面上要有一个该View的ID，只要各个ID不同就可以了</param>
        /// <param name="title">webpart左上角的标题</param>
        /// <param name="zone">放在哪个zone中，webpartzone1或webpartzone2，1大，2小</param>
        private void AddWebPart(string url, string id, string title, WebPartZoneBase zone)
        {
            Control webUserControl = LoadControl("../../../Views/" + url);
            webUserControl.ID = id;
            GenericWebPart webPart = _WebPartManager.CreateWebPart(webUserControl);
            webPart.Title = title;
            //webPart.TitleIconImageUrl = "../../../Pages/image/icon09.jpg";
            _WebPartManager.AddWebPart(webPart, zone, 0);
            AddEmptyPage();
        }

        /// <summary>
        /// 把自定义控件加入页面
        /// </summary>
        /// <param name="url">自定义控件的地址</param>
        /// <param name="id">控件ID，由于是动态生成的，所以页面上要有一个该View的ID，只要各个ID不同就可以了</param>
        /// <param name="title">webpart左上角的标题</param>
        /// <param name="zone">放在哪个zone中，webpartzone1或webpartzone2，1大，2小</param>
        private void AddIFrameWebPart(string url, string id, string title, WebPartZoneBase zone)
        {
            IFrameWebPart webPart = new IFrameWebPart();
            webPart.Url = string.Format("../../{0}", url);
            webPart.ID = id;
            webPart.Title = title;
            _WebPartManager.AddWebPart(webPart, zone, 0);
            AddEmptyPage();
        }

        #region 常用工具

        protected void AddView(string url, string id, string title, int zone, bool isIFrame)
        {
            WebPartZone webPartZone;
            if (zone == 1)
            {
                webPartZone = WebPartZone1;
            }
            else
            {
                webPartZone = WebPartZone2;
            }
            if(isIFrame)
            {
                AddIFrameWebPart(url, id, title, webPartZone);
            }
            else
            {
                AddWebPart(url, id, title, webPartZone);
            }
           
        }

        #endregion

        #endregion

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EmptyPage.Style["display"] = "none";
            mpeEdit.Show();
        }
    }
}
//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ApplicationSearch.cs
// ������: wangyueqi
// ��������: 2009-6-1
// ����: ApplicationSearch �б�
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class ApplicationSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A509))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            }
            ApplicationSearchPresenter applicationSearchPresenter =
                new ApplicationSearchPresenter(ApplicationSearchView1, LoginUser);
            applicationSearchPresenter.Initialize(Page.IsPostBack);
            ApplicationSearchView1.btnViewClick += ToDetailPage;

        }
        public void ToDetailPage(string info)
        {
            string id=info.Split(';')[0];
            string type = info.Split(';')[1];
            switch(type)
            {
                case "Leave":
                    Response.Redirect("../LeaveRequestPages/LeaveRequestDetail.aspx?LeaveRequestID=" + SecurityUtil.DECEncrypt(id), false);
                    break;
                case "Out":
                    Response.Redirect("../OutApplicationPages/OutApplicationDetail.aspx?PKID=" + SecurityUtil.DECEncrypt(id), false);
                    break;
                case "OverWork":
                    Response.Redirect("../OverWorkPages/OverWorkDetail.aspx?PKID=" + SecurityUtil.DECEncrypt(id), false);
                    break;
                default:
                    break;
            }

        }
    }
}

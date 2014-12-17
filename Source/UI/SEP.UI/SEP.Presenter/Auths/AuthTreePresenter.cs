
using System;
using System.Collections.Generic;

using SEP.Model;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IAuths;

namespace SEP.Presenter.Auths
{
    public class AuthTreePresenter : BasePresenter
    {
        private IAuthTreeView _ItsView;

        public AuthTreePresenter(IAuthTreeView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
        }

        public void SetAuthTreeDataSrc()
        {
            List<Auth> sepAuths = null;

            if (LoginUser == null)
                return;

            sepAuths = LoginUser.FindAuthsByType(AuthType.SEP);

            _ItsView.rptAccountManageDataSrc = FindAuthById(sepAuths, Powers.A01);
            _ItsView.rptDeptManageDataSrc = FindAuthById(sepAuths, Powers.A02);
            _ItsView.rptBulletinsManageDataSrc = FindAuthById(sepAuths, Powers.A03);
            _ItsView.rptGoalMangeDataSrc = FindAuthById(sepAuths, Powers.A04);
            _ItsView.rptCompanuManageDataSrc = FindAuthById(sepAuths, Powers.A05);
            _ItsView.rptServiceManageDataSrc = FindAuthById(sepAuths, Powers.A06);
            SetPersonalManageAuth();
        }
        private void SetPersonalManageAuth()
        {
            List<Auth> authList = new List<Auth>();
            Auth auth;
            auth = new Auth(0, "系统设置");
            auth.NavigateUrl = "../AccountPages/SetPersonalConfig.aspx";
            authList.Add(auth);
            auth = new Auth(0, "修改密码");
            auth.NavigateUrl = "../AccountPages/ChangePassword.aspx";
            authList.Add(auth);

            _ItsView.rptPersonalManageDataSrc = authList;
        }

        private List<Auth> FindAuthById(List<Auth> auths, int id)
        {
            foreach (Auth auth in auths)
            {
                if (auth.Id == id)
                    return auth.ChildAuths;
            }

            return null;
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}

using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeAdjustRest;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.EmployeeAdjustRestPages
{
    public partial class EmployeeAdjustRestDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A404))
            {
                throw new ApplicationException("没有权限访问");
            }
            DetailEmployeeAdjustRestPresenter thePresenter =
                new DetailEmployeeAdjustRestPresenter(EmployeeAdjustRestView1,
                                                      SecurityUtil.DECDecrypt(
                                                          Request.QueryString[ConstParameters.EmployeeId]));
            thePresenter.InitView();
        }
    }
}

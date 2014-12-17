using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Views.Employee;
using SEP.HRMIS.Presenter;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmployeeContractUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A402) || Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401)))
            {
                throw new ApplicationException("没有权限访问");
            }
            IEmployeeContractView EmployeeContractView1 = (EmployeeContractView)ContractWithConditionView1.FindControl("EmployeeContractView1");
            
            EmployeeContractUpdatePresenter presenter = new EmployeeContractUpdatePresenter(EmployeeContractView1);
            EmployeeContractView1.btnOKClick += presenter.UpdateContractEvent;
            EmployeeContractView1.btnCancelClick += presenter.CancleEvent;
            presenter.ToContractListPage += ToContractListPage;
            
            presenter.InitView(SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]),
                                    SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.ContractId]), Page.IsPostBack);
        }

        private void ToContractListPage(object sender, EventArgs e)
        {
            if (Request.QueryString["From"] == "Search")
            {
                Response.Redirect("EmployeeContractSearch.aspx");
            }
            else
            {
                 Response.Redirect("EmployeeContractList.aspx?" + ConstParameters.EmployeeId + "=" +
                  Request.QueryString[ConstParameters.EmployeeId]);
            }   
        }
    }
}

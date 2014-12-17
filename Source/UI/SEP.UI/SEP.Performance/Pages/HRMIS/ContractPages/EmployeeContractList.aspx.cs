using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmployeeContractList : BasePage
    {
        private EmployeeContractListPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A402) || Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401)))
            {
                throw new ApplicationException("没有权限访问");
            }
            presenter = new EmployeeContractListPresenter(EmployeeContractListView1);
            EmployeeContractListView1.ContractDeleteEvent += presenter.DeleteContractEvent;
            EmployeeContractListView1.ContractAddEvent += presenter.AddContractEvent;
            EmployeeContractListView1.ContractEditEvent += presenter.UpdateContractEvent;
            EmployeeContractListView1.ContractDetailEvent += presenter.DetailContractEvent;
            EmployeeContractListView1.ContractDownLoadEvent += presenter.ContractDownLoadEvent;
            EmployeeContractListView1.IsDownLoadEnable += presenter.IsDownEnable;
            presenter.ToContractAddPage += ToContractAddPage;
            presenter.ToContractUpdatePage += ToContractUpdatePage;
            presenter.ToContractDeletePage += ToContractDeletePage;
            presenter.ToContractDetailPage += ToContractDetailPage;
            if (!IsPostBack)
            {
                presenter.InitView(SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]));
            }

        }

        private void ToContractAddPage(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeContractAdd.aspx?" + ConstParameters.EmployeeId + "=" +
                              Request.QueryString[ConstParameters.EmployeeId]);
        }

        private void ToContractUpdatePage(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeContractUpdate.aspx?" + ConstParameters.EmployeeId + "=" +
                              Request.QueryString[ConstParameters.EmployeeId] + "&" + ConstParameters.ContractId + "=" +
                              SecurityUtil.DECEncrypt(presenter.ContractID.ToString()));
        }
        private void ToContractDeletePage(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeContractDelete.aspx?" + ConstParameters.EmployeeId + "=" +
                              Request.QueryString[ConstParameters.EmployeeId] + "&" + ConstParameters.ContractId + "=" +
                              SecurityUtil.DECEncrypt(presenter.ContractID.ToString()));
        }
        private void ToContractDetailPage(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeContractDetail.aspx?" + ConstParameters.EmployeeId + "=" +
                              Request.QueryString[ConstParameters.EmployeeId] + "&" + ConstParameters.ContractId + "=" +
                              SecurityUtil.DECEncrypt(presenter.ContractID.ToString()));
        }
    }
}


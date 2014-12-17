using System;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.Model;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;


namespace SEP.Performance.Pages
{
    public partial class EmployeeContractSearch  : BasePage
    {
        private List<Contract> _ContractList;
        private SearchContractListPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A402))
            {
                throw new ApplicationException("没有权限访问");
            }
            presenter = new SearchContractListPresenter(ContractSearchView1, LoginUser);
            ContractSearchView1.searchEvent+=presenter.SearchEvent;
            presenter.InitView(Page.IsPostBack);
            presenter.ToContractUpdatePage += ToContractUpdatePage;
            presenter.ToContractDeletePage += ToContractDeletePage;
        }

        protected void btnExportServer_Click(object sender, EventArgs e)
        {
            Export("application/ms-excel", "合同表.xls");
        }

        private void Export(string FileType, string FileName)
        {
            //设置回应状态
            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition",
                                  "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8));
            Response.ContentType = FileType;
            EnableViewState = false;

            List<Contract> theContractSearch = SearchContract();
            ContractCollection theContracts = new ContractCollection();
            theContracts.TheContracts = theContractSearch;
            StringWriter theExcel = theContracts.ExportContractSearchToExcel();
            Response.Write(theExcel.ToString());
            Response.End();
            theExcel.Close();
        }

        private List<Contract> SearchContract()
        {
            new SearchContractListPresenter(ContractSearchView1, LoginUser).SearchEvent(this, null);
            _ContractList = ContractSearchView1.contracts;
            return _ContractList;
        }

        private void ToContractUpdatePage(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeContractUpdate.aspx?" + ConstParameters.EmployeeId + "=" +
                              SecurityUtil.DECEncrypt(presenter.EmployeeID.ToString()) + "&" + ConstParameters.ContractId + "=" +
                              SecurityUtil.DECEncrypt(presenter.ContractID.ToString())+"&From=Search");
        }

        private void ToContractDeletePage(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeContractDelete.aspx?" + ConstParameters.EmployeeId + "=" +
                              SecurityUtil.DECEncrypt(presenter.EmployeeID.ToString()) + "&" + ConstParameters.ContractId + "=" +
                              SecurityUtil.DECEncrypt(presenter.ContractID.ToString())+"&From=Search");
        }
    }
}

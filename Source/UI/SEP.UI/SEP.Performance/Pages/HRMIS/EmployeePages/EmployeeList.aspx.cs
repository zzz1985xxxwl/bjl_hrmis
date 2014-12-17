using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmployeeList : BasePage
    {
        private EmployeeListPresenter presenter;
        private List<Employee> _EmployeeList;
        private IVacationFacade _IVacationFacade = InstanceFactory.CreateVacationFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        public INationalityFacade _ItsNationalityFacade = InstanceFactory.CreateNationalityFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401))
            {
                throw new ApplicationException("没有权限访问");
            }

            if (Request.Cookies["EmployeeListShowPattern"] == null)
            {
                HttpCookie httpCookie = new HttpCookie("EmployeeListShowPattern", "List");
                Response.Cookies.Add(httpCookie);
            }
            presenter = new EmployeeListPresenter(EmployeeListView1, EmployeeCardView1, LoginUser);
            presenter._ToVacationUpdatePageEvent = (ToVacationUpdatePage);
            //查询之后,委托给p层ExecutEvent和卡片view层btnSearch_Click方法共同完成
            EmployeeListView1._ToButtonSearch += presenter.InitLetter;
            EmployeeListView1._ToButtonSearch += EmployeeCardView1.btnSearch_Click;
            EmployeeListView1._ToButtonSearch += EmployeeTableView1.btnSearch_Click;
            EmployeeListView1._ChangeShowPattern += EmployeeCardView1.btnSearch_Click;
            EmployeeListView1._ChangeShowPattern += EmployeeTableView1.btnSearch_Click;
            EmployeeCardView1.ViewVacation += presenter.ViewVacationEvent;
            EmployeeTableView1.ViewVacation += presenter.ViewVacationEvent;
            EmployeeCardView1.ContractEvent += presenter.ContractManageEvent;
            EmployeeTableView1.ContractEvent += presenter.ContractManageEvent;
            //字母查询之后,委托给p层LetterEvent和卡片view层Letter_Search方法共同完成
            LetterSearchView1._LetterSearch += presenter.ExecutEvent;
            LetterSearchView1._LetterSearch += EmployeeCardView1.Letter_Search;
            LetterSearchView1._LetterSearch += EmployeeTableView1.Letter_Search;
            presenter.ToContractListPage += ToContractListPage;
            presenter.InitView(Page.IsPostBack);
            if (!IsPostBack)
            {
                presenter.InitLetter();
            }
            //EmployeeListView1.ExportClientClick = "document.getElementById('" + btnExportServer.ClientID + "').click();";
        }

        private void ToVacationUpdatePage()
        {
            Response.Redirect("EmployeeUpdate.aspx?" + ConstParameters.EmployeeId + "=" +
                              SecurityUtil.DECEncrypt(presenter.EmployeeId.ToString()) + "&" +
                              ConstParameters.EmployeeVacationOperation + "=" + SecurityUtil.DECEncrypt(4.ToString()));
        }

        private void ToContractListPage(object sender, EventArgs e)
        {
            Response.Redirect("../ContractPages/EmployeeContractList.aspx?" + ConstParameters.EmployeeId + "=" +
                              SecurityUtil.DECEncrypt(presenter.EmployeeId.ToString()));
        }

        protected void btnExportServer_Click(object sender, EventArgs e)
        {
            Export("application/ms-excel", "员工表"
                                           + ".xls");
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

            List<Employee> theEmployeeSearch = SearchEmployee();
            List<Vacation> theVacation = SearchVacation();
            EmployeeCollection theEmployees = new EmployeeCollection();
            theEmployees.TheEmployees = theEmployeeSearch;
            theEmployees.TheVocation = theVacation;
            StringWriter theExcel = theEmployees.ExportEmployeeSearchToExcel();
            Response.Write(theExcel.ToString());
            Response.End();
            theExcel.Close();
        }

        private List<Employee> SearchEmployee()
        {
            _EmployeeList = Session["Employess"] as List<Employee>;
            foreach (Employee emplyee in _EmployeeList)
            {
                Employee e = _IEmployeeFacade.GetEmployeeByAccountID(emplyee.Account.Id);
                emplyee.EmployeeDetails =e.EmployeeDetails;
                emplyee.Account = e.Account;
                emplyee.EmployeeContracts = _IEmployeeContractFacade.GetEmployeeContractByAccountID(emplyee.Account.Id);
            }
            return _EmployeeList;
        }

        private List<Vacation> SearchVacation()
        {
            List<Vacation> vacations = new List<Vacation>();
            foreach (Employee emplyee in _EmployeeList)
            {
                vacations.Add(_IVacationFacade.GetLastVacationByAccountID(emplyee.Account.Id));
                if (emplyee.EmployeeDetails != null)
                {
                    if (emplyee.EmployeeDetails.CountryNationality != null &&
                        emplyee.EmployeeDetails.CountryNationality.ParameterID != 0)
                    {
                        emplyee.EmployeeDetails.CountryNationality =
                            _ItsNationalityFacade.GetNationalityByPkid(
                                emplyee.EmployeeDetails.CountryNationality.ParameterID);
                    }
                }
            }
            return vacations;
        }
    }
}
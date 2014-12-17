using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class PrintReimbursePresenter
    {
        private readonly IPrintReimburseView _IPrintReimburseView;
        //private int _EmployeeID;
        private readonly int _ReimburseID;
        private readonly Account _LoginUser;
        //private IGetReimburse _IGetReimburse = new GetReimburse();
        private readonly IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();
        public PrintReimbursePresenter(int reimburseID, Account loginUser, IPrintReimburseView iPrintReimburseView)
        {
            _LoginUser = loginUser;
            _ReimburseID = reimburseID;
            _IPrintReimburseView = iPrintReimburseView;
        }

        public void Init(bool isPostBack)
        {
            AttachViewEvent();
            if (!isPostBack)
            {
                Employee employee = _IReimburseFacade.GetEmployeeReimburseByEmployeeID(_LoginUser.Id);
                hrmisModel.Reimburse reimburse = employee.FindReimburseByReimburseID(_ReimburseID);

                if (reimburse.ReimburseStatus == ReimburseStatusEnum.Reimbursing)
                {
                    employee.Account.Name = _LoginUser.Name;
                    _IPrintReimburseView.Employee = employee;

                    _IPrintReimburseView.Reimburse = reimburse;

                    if (reimburse.ReimburseCategoriesEnum == ReimburseCategoriesEnum.TravelReimburse)
                    {
                        _IPrintReimburseView.Title = "差旅费报销单";
                        _IPrintReimburseView.Destinations = reimburse.Destinations;
                        //_IPrintReimburseView.CustomerName = reimburse.CustomerName;
                        _IPrintReimburseView.ProjectName = reimburse.ProjectName;
                    }
                    else
                    {
                        _IPrintReimburseView.Title = "非差旅费报销单";
                    }

                    _IPrintReimburseView.DepartmentName = reimburse.Department.DepartmentName;


                    _IPrintReimburseView.PaperCount = reimburse.PaperCount.ToString();
                    _IPrintReimburseView.ConsumeDate = reimburse.ConsumeDateFrom + " -- " +
                                                       reimburse.ConsumeDateTo;



                    //// 公司名称
                    //_IPrintReimburseView.CompanyName =
                    //    BllInstance.DepartmentBllInstance.GetDepartmentById(
                    //        employee.EmployeeDetails.Work.Company.DepartmentID, _LoginUser).DepartmentName;
                    _IPrintReimburseView.ReimburseItemSource = reimburse.ReimburseItems;
                }
                //// CEO
                //Account accountCeo = _IReimburseFacade.IsCEOElectricName(reimburse);
                //if (accountCeo != null)
                //{
                //    byte[] ElectricNameCeo = BllInstance.AccountBllInstance.GetElectronIdiographByAccountID(accountCeo);
                //    string usbkeyCeo = BllInstance.AccountBllInstance.GetAccountById(
                //        accountCeo.Id).UsbKey;
                //    if (usbkeyCeo != null && ElectricNameCeo != null)
                //    {
                //        _IPrintReimburseView.CEOElectricName = BindElectricName(ElectricNameCeo, usbkeyCeo);
                //    }
                //}
                //// 财务
                //Account accountFinance = _IReimburseFacade.IsFinanceElectricName(reimburse);
                //if (accountFinance != null)
                //{
                //    byte[] ElectricNameFinance = BllInstance.AccountBllInstance.GetElectronIdiographByAccountID(accountFinance);
                //    string usbkeyFinance = BllInstance.AccountBllInstance.GetAccountById(
                //        accountFinance.Id).UsbKey;
                //    if (usbkeyFinance != null && ElectricNameFinance != null)
                //    {
                //        _IPrintReimburseView.FinanceElectricName = BindElectricName(ElectricNameFinance, usbkeyFinance);
                //    }
                //}
                //// 部门领导
                //Account accountDepartmentLeader = _IReimburseFacade.IsDepartmentLeaderElectricName(reimburse);
                //if (accountDepartmentLeader != null)
                //{
                //    byte[] ElectricNameDepartmentLeader = BllInstance.AccountBllInstance.GetElectronIdiographByAccountID(accountDepartmentLeader);
                //    string usbkeyDepartmentLeader = BllInstance.AccountBllInstance.GetAccountById(
                //        accountDepartmentLeader.Id).UsbKey;
                //    if (usbkeyDepartmentLeader != null && ElectricNameDepartmentLeader != null)
                //    {
                //        _IPrintReimburseView.DepartmentLeaderElectricName = BindElectricName(ElectricNameDepartmentLeader, usbkeyDepartmentLeader);
                //    }
                //}
                //_IPrintReimburseView.RecipientsElectricName = SecurityUtil.SymmetricDecryptStream(BllInstance.AccountBllInstance.GetElectronIdiographByAccountID(_LoginUser), BllInstance.AccountBllInstance.GetAccountById(
                //                         _LoginUser.Id).UsbKey); 
            }
        }

        //private static byte[] BindElectricName(byte[] ElectricName, string usbkey)
        //{
        //    try
        //    {
        //        return SecurityUtil.SymmetricDecryptStream(ElectricName, usbkey);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        private static void AttachViewEvent()
        {
        }

    }
}

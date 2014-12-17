using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeContractDeletePresenter
    {
        private readonly IEmployeeContractView _View;
        private IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        private IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private IApplyAssessConditionFacade _IApplyAssessConditionFacade = InstanceFactory.CreateApplyAssessConditionFacade();
        private IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private int _EmployeeId, _ContractId;

        public EmployeeContractDeletePresenter(IEmployeeContractView view)
        {
            _View = view;
        }

        public void InitView(string employeeId, string ContractId, bool isPostBack)
        {
            _View.ResultMessage = string.Empty;
            _View.SetReadonly = true;
            if (!int.TryParse(employeeId, out _EmployeeId))
            {
                _View.ResultMessage = "初始错误";
                return;
            }
            _View.EmployeeId = _EmployeeId.ToString();
            if (!int.TryParse(ContractId, out _ContractId))
            {
                _View.ResultMessage = "初始错误";
                return;
            }
            if (!isPostBack)
            {
                _View.ContractTypeSource = _IContractTypeFacade.GetContractTypeByCondition(-1, string.Empty);
                Contract conta = _IEmployeeContractFacade.GetEmployeeContractByContractId(_ContractId);
                if (conta == null)
                {
                    _View.ResultMessage = "<span class='fontred'>当前合同已不存在</span>";
                    return;
                }
                _View.ContractStartTime = conta.StartDate.ToShortDateString();
                _View.ContractEndTime = conta.EndDate.ToShortDateString();
                _View.ContractTypeId = conta.ContractType.ContractTypeID.ToString();
                _View.Attachment = conta.Attachment;
                _View.Remark = conta.Remark;
                _View.ConditionSource =
                    _IApplyAssessConditionFacade.GetApplyAssessConditionByEmployeeContractID(_ContractId);
                Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(_EmployeeId);
                _View.Title = "删除" + employee.Account.Name + "的合同";
            }
            InitEmployeeContractTypeList();
        }

        public EventHandler ToContractListPage;
        public void DeleteContractEvent(object sender, EventArgs eventArgs)
        {
            try
            {
                _IEmployeeContractFacade.DeleteEmployeeContract(_ContractId, _EmployeeId);
                ToContractListPage(sender, null);
            }
            catch (Exception ex)
            {
                _View.ResultMessage = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        public void CancleEvent(object sender, EventArgs eventArgs)
        {
            ToContractListPage(sender, null);
        }
        private void InitEmployeeContractTypeList()
        {
            _View.EmployeeContractBookMarkList = _IEmployeeContractFacade.GetRealEmployeeContractBookMarkByContractID(_ContractId);
        }

        #region user for tests

        public IContractTypeFacade SetGetContractType
        {
            set
            {
                _IContractTypeFacade = value;
            }
        }

        public IEmployeeFacade SetEmployee
        {
            set
            {
                _IEmployeeFacade = value;
            }
        }


        #endregion
    }
}
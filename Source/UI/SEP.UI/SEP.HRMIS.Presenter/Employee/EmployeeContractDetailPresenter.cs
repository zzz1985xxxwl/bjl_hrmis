using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class EmployeeContractDetailPresenter
    {
        private readonly IEmployeeContractView _View;
        private IContractTypeFacade _IContractTypeFacade = InstanceFactory.CreateContractTypeFacade();
        private readonly IEmployeeContractFacade _IEmployeeContractFacade = InstanceFactory.CreateEmployeeContractFacade();
        private readonly IApplyAssessConditionFacade _IApplyAssessConditionFacade = InstanceFactory.CreateApplyAssessConditionFacade();
        private readonly IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
        private int _ContractId;

        public EmployeeContractDetailPresenter(IEmployeeContractView view)
        {
            _View = view;
        }

        public void InitView(string ContractId, bool isPostBack)
        {
            _View.ResultMessage = string.Empty;
            _View.SetReadonly = true;
            if (!int.TryParse(ContractId, out _ContractId))
            {
                _View.ResultMessage = "��ʼ����";
                return;
            }
            if (!isPostBack)
            {
                _View.ContractTypeSource = _IContractTypeFacade.GetContractTypeByCondition(-1, string.Empty);
                Contract conta = _IEmployeeContractFacade.GetEmployeeContractByContractId(_ContractId);
                if (conta == null)
                {
                    _View.ResultMessage = "<span class='fontred'>��ǰ��ͬ�Ѳ�����</span>";
                    return;
                }
                _View.ContractStartTime = conta.StartDate.ToShortDateString();
                _View.ContractEndTime = conta.EndDate.ToShortDateString();
                _View.ContractTypeId = conta.ContractType.ContractTypeID.ToString();
                _View.Attachment = conta.Attachment;
                _View.Remark = conta.Remark;
                _View.ConditionSource = _IApplyAssessConditionFacade.GetApplyAssessConditionByEmployeeContractID(_ContractId);
                Employee employee = _IEmployeeFacade.GetEmployeeBasicInfoByAccountID(conta.EmployeeID);
                _View.Title = employee.Account.Name + "�ĺ�ͬ��ϸ��Ϣ";
            }
            InitEmployeeContractTypeList();
        }

        public EventHandler ToContractListPage;
        public void DetailContractEvent(object sender, EventArgs eventArgs)
        {
            ToContractListPage(sender, null);
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



        #endregion
    }
}
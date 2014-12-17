//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ShowVacationPresenter.cs
// ������: ���h��
// ��������: 2008-06-18
// ����: ShowVacationPresenter
// ----------------------------------------------------------------


using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ShowVacationPresenter
    {
        private readonly IVacationBaseView _IVacationBaseView;
        private IVacationFacade _IVacationFacade = InstanceFactory.CreateVacationFacade();
        public ShowVacationPresenter(IVacationBaseView view)
        {
            _IVacationBaseView = view;
        }
     
        public void InitVacation(Employee employee, bool isPostBack)
        {
            if (!isPostBack)
            {
                Vacation vacation = _IVacationFacade.GetLastVacationByAccountID(employee.Account.Id);
                if (vacation!=null)
                {
                    _IVacationBaseView.EmployeeID = vacation.Employee.Account.Id.ToString();
                    _IVacationBaseView.EmployeeName = vacation.Employee.Account.Name;
                    _IVacationBaseView.VacationID = vacation.VacationID.ToString();
                    _IVacationBaseView.SurplusDayNum = vacation.SurplusDayNum.ToString();
                    _IVacationBaseView.UsedDayNum = vacation.UsedDayNum.ToString();
                    _IVacationBaseView.Remark = vacation.Remark;
                    _IVacationBaseView.VacationDayNum = vacation.VacationDayNum.ToString();
                    _IVacationBaseView.VacationEndDate = vacation.VacationEndDate.ToShortDateString();
                    _IVacationBaseView.VacationStartDate = vacation.VacationStartDate.ToShortDateString();
                }
            }

        }

        #region ������
        public IVacationFacade MockGetVacation
        {
            set { _IVacationFacade = value; }
        }
        #endregion
    }
}

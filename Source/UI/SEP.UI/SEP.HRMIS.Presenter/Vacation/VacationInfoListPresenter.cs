using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class VacationInfoListPresenter
    {
        private readonly IVacationInfoListView _ItsView;
        private readonly IVacationFacade _IVacationFacade = InstanceFactory.CreateVacationFacade();
        private readonly IVacationBaseView _VacationBaseView;
        private readonly  IEmployeeAttendanceFacade _IEmployeeAttendanceFacade = InstanceFactory.CreateEmployeeAttendanceFacade();

        public VacationInfoListPresenter(IVacationInfoListView view,IVacationBaseView vacationView ,bool isPostBack)
        {
            _ItsView = view;
            _VacationBaseView = vacationView;
            AttachViewEvent();
            InitInfoList(isPostBack);
            InitVacationView();
        }
        /// <summary>
        /// ≤‚ ‘”√
        /// </summary>
        public VacationInfoListPresenter(IVacationInfoListView view, IVacationBaseView vacationView, bool isPostBack,
            IVacationFacade mockIVacationFacade, IEmployeeAttendanceFacade mockIEmployeeAttendanceFacade)
        {
            _IVacationFacade = mockIVacationFacade;
            _IEmployeeAttendanceFacade = mockIEmployeeAttendanceFacade;
            _ItsView = view;
            _VacationBaseView = vacationView;
            AttachViewEvent();
            InitInfoList(isPostBack);
            InitVacationView();
        }
        public void AttachViewEvent()
        {
            _ItsView.InitVacationDetailEvent += InitVacationDetailEvent;
            _ItsView.AddEvent += AddEvent;
            _ItsView.DeleteEvent += DeleteEvent;
            _ItsView.UpdateEvent += UpdateEvent;
        }

        private void InitInfoList(bool isPostBack)
        {
            if (!isPostBack)
            {
                _ItsView.VacationList = _IVacationFacade.GetVacationByAccountID(_ItsView.Employee.Account.Id);
            }
        }
        private void InitVacationView()
        {
            _VacationBaseView.EmployeeID = _ItsView.Employee.Account.Id.ToString();
            _VacationBaseView.EmployeeName = _ItsView.Employee.Account.Name;
            //œ‘ æ £”‡µ˜–›
            _VacationBaseView.AdjustRestVisible = true;
            _VacationBaseView.AdjustRestRemainedDays = _IEmployeeAttendanceFacade.GetAdjustRestRemainedDaysByEmployeeID(_ItsView.Employee.Account.Id).ToString();
        }
        public void UpdateEvent(object sender, EventArgs e)
        {
            if (VacationBasePresenter.Validation(_VacationBaseView))
            {
                Vacation vacation =
                   new Vacation(Convert.ToInt32(_VacationBaseView.VacationID), _ItsView.Employee,
                                      Convert.ToDecimal(_VacationBaseView.VacationDayNum),
                                      Convert.ToDateTime(_VacationBaseView.VacationStartDate),
                                      Convert.ToDateTime(_VacationBaseView.VacationEndDate),
                                      Convert.ToDecimal(_VacationBaseView.UsedDayNum),
                                      Convert.ToDecimal(_VacationBaseView.SurplusDayNum),
                                      _VacationBaseView.Remark);
                _IVacationFacade.UpdateVacation(vacation);
                _ItsView.VacationList = _IVacationFacade.GetVacationByAccountID(_ItsView.Employee.Account.Id);
            }
        }

        public void DeleteEvent(object sender, CommandEventArgs e)
        {
            _IVacationFacade.DeleteVacation(Convert.ToInt32(e.CommandArgument));
            _ItsView.VacationList = _IVacationFacade.GetVacationByAccountID(_ItsView.Employee.Account.Id);
        }

        public void AddEvent(object sender, EventArgs e)
        {
            if (VacationBasePresenter.Validation(_VacationBaseView))
            {
                Vacation vacation =
                    new Vacation(0, _ItsView.Employee,
                                       Convert.ToDecimal(_VacationBaseView.VacationDayNum),
                                       Convert.ToDateTime(_VacationBaseView.VacationStartDate),
                                       Convert.ToDateTime(_VacationBaseView.VacationEndDate),
                                       Convert.ToDecimal(_VacationBaseView.UsedDayNum),
                                       Convert.ToDecimal(_VacationBaseView.SurplusDayNum),
                                       _VacationBaseView.Remark);
                _IVacationFacade.AddVacation(vacation);
                _ItsView.VacationList = _IVacationFacade.GetVacationByAccountID(_ItsView.Employee.Account.Id);
            }
        }

        public void InitVacationDetailEvent(object sender, CommandEventArgs e)
        {
            if(e==null)
            {
                InitVacation();
            }
            else
            {
                BindVacation(_IVacationFacade.GetVacationByVacationID((Convert.ToInt32(e.CommandArgument))));
            } 
        }

        //private Vacation FindVacationById(int id)
        //{
        //    if (_ItsView.VacationList != null)
        //    {
        //        foreach (Vacation va in _ItsView.VacationList)
        //        {
        //            if (va.HashCode.Equals(id))
        //            {
        //                return va;
        //            }
        //        }
        //    }
        //    return null;
        //}

        private void BindVacation(Vacation vacation)
        {
            _VacationBaseView.VacationID = vacation.VacationID.ToString();
            _VacationBaseView.SurplusDayNum = vacation.SurplusDayNum.ToString();
            _VacationBaseView.UsedDayNum = vacation.UsedDayNum.ToString();
            _VacationBaseView.Remark = vacation.Remark;
            _VacationBaseView.VacationDayNum = vacation.VacationDayNum.ToString();
            _VacationBaseView.VacationEndDate = vacation.VacationEndDate.ToShortDateString();
            _VacationBaseView.VacationStartDate = vacation.VacationStartDate.ToShortDateString();
        }
        private void InitVacation()
        {
            _VacationBaseView.SurplusDayNum = "";
            _VacationBaseView.UsedDayNum = "";
            _VacationBaseView.Remark = "";
            _VacationBaseView.VacationDayNum = "";
            _VacationBaseView.VacationEndDate = "";
            _VacationBaseView.VacationStartDate = "";
        }
    }
}

using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public abstract class LeaveRequestPresenterBase
    {
        protected abstract void AttachViewEvent();
        protected abstract void SetBtnStatus();
        protected abstract void InitPresenter();

        private readonly ILeaveRequestTypeFacade _ILeaveRequestTypeFacade = InstanceFactory.CreateLeaveRequestTypeFacade();
        private readonly IVacationFacade _IVacationFacade = InstanceFactory.CreateVacationFacade();

        protected readonly ILeaveRequestInfoView _ItsView;
        public LeaveRequestPresenterBase(ILeaveRequestInfoView view)
        {
            _ItsView = view;
        }

        public void InitView(bool isPagePostBack)
        {
            _ItsView.ddlAbsentTypeSelected += ddlAbsentTypeSelected;
            AttachViewEvent();

            _ItsView.ResultMessage = string.Empty;

            if (!isPagePostBack)
            {
                _ItsView.AnnualLeave = null;
                _ItsView.RemarkMessage = string.Empty;
                _ItsView.TypeMessage = string.Empty;
                GetAllLeaveRequestType();
                InitPresenter();
                SetBtnStatus();
            }
        }

        private void GetAllLeaveRequestType()
        {
            _ItsView.LeaveRequestTypeSource = _ILeaveRequestTypeFacade.GetAllLeaveRequestType();
        }

        public void ddlAbsentTypeSelected(object source, EventArgs e)
        {
            _ItsView.AnnualLeave = null;
            try
            {
                if (_ItsView.LeaveRequestType.LeaveRequestTypeID == -1)
                {
                    _ItsView.LeaveRequestType = new LeaveRequestType(-1, "", "",
                        LegalHoliday.UnInclude, RestDay.UnInclude, 0);
                    return;
                }
                _ItsView.LeaveRequestType =
                    _ILeaveRequestTypeFacade.GetLeaveRequestTypeByPkid(
                        Convert.ToInt32(_ItsView.LeaveRequestType.LeaveRequestTypeID));

                if ((_ItsView.LeaveRequestType != null)
                    && (_ItsView.LeaveRequestType.LeaveRequestTypeID == ((int)LeaveRequestTypeEnum.AnnualLeave)))
                {
                    CalculateAnnualLeave();
                }
            }
            catch (ApplicationException ae)
            {
                _ItsView.ResultMessage =  ae.Message;
            }
        }

        private void CalculateAnnualLeave()
        {
            decimal costTime = 0;
            //读取年假信息
            Vacation vacation = _IVacationFacade.GetLastVacationByAccountID(Convert.ToInt32(_ItsView.EmployeeID));
            if (vacation != null)
            {
                costTime = vacation.SurplusDayNum * 8;
            }
            if (_ItsView.AnnualLeave == null)
            {
                _ItsView.AnnualLeave = costTime;
            }
            else
            {
                _ItsView.AnnualLeave = costTime - _ItsView.AnnualLeave;
            }
        }

        private string _EmployeeName;
        public string EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }

        private int _LeaveRequestID;
        public int LeaveRequestID
        {
            get
            {
                return _LeaveRequestID;
            }
            set
            {
                _LeaveRequestID = value;
            }
        }

        /// <summary>
        /// 删除rowIndex行
        /// </summary>
        /// <param name="rowIndex"></param>
        protected void LeaveRequestItemForDeleteEvent(string rowIndex)
        {
            List<LeaveRequestItem> items = _ItsView.LeaveRequestItemList;
            if (rowIndex == "0" && items.Count == 1)
            {
                items[0].FromDate = DateTime.Now.Date;
                items[0].ToDate = DateTime.Now.Date;
            }
            else
            {
                items.RemoveAt(Convert.ToInt32(rowIndex));
            }
            _ItsView.LeaveRequestItemList = items;
        }

        /// <summary>
        /// 在rowIndex下新增空行
        /// </summary>
        /// <param name="rowIndex"></param>
        protected void LeaveRequestItemForAddAtEvent(string rowIndex)
        {
            List<LeaveRequestItem> items = new List<LeaveRequestItem>();
            for (int i = 0; i < _ItsView.LeaveRequestItemList.Count; i++)
            {
                items.Add(_ItsView.LeaveRequestItemList[i]);
                if (Convert.ToInt32(rowIndex) == i)
                {
                    LeaveRequestUtility.AddNullItem(items);
                }
            }
            _ItsView.LeaveRequestItemList = items;
        }
    }
}

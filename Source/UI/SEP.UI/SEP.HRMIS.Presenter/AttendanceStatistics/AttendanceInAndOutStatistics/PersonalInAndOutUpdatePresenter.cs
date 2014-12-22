//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: PersonalInAndOutUpdatePresenter.cs
// ������: ����
// ��������: 2008-10-21
// ����: ���˿��������޸�
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter
{
    public class PersonalInAndOutUpdatePresenter : PresenterCore.BasePresenter
    {
        private readonly IPersonalInAndOutView _View;
        private readonly PersonalInAndOutUtilityPresenter _Utility;
        //note colbert 2
        //private readonly IAttendanceOutInRecord _GetRecord = new AttendanceOutInRecord();
        //private UpdateAttendanceInOutRecord _Update;

        public PersonalInAndOutUpdatePresenter(IPersonalInAndOutView view, Account loginUser)
            : base(loginUser)
        {
            _View = view;
            _Utility = new PersonalInAndOutUtilityPresenter(_View, loginUser);
            AttachViewEvent();
        }

        public void InitView(string id)
        {
            _Utility.InitTheViewToDefault();
            _View.OperationTitle = "�޸Ĵ򿨼�¼";
            _View.OperationType = "Update";
            _View.SetReadOnly = true;
            _View.SetReasonReadOnly = true;
            _Utility.DataBind(id, _View.EmployeeId);
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += UpdateEvent;
        }

        public void UpdateEvent()
        {
            if (!_Utility.Validate())
            {
                return;
            }
            Employee employee = InstanceFactory.AttendanceInOutRecordFacade().GetEmployeeInAndOutRecordByEmployeeId(Convert.ToInt32(_View.EmployeeId), LoginUser);
            AttendanceInAndOutRecord oldRecord = employee.EmployeeAttendance.FindInAndOutRecordByRecordId(Convert.ToInt32(_View.RecordId));

            #region �ռ�log �п��ڵľ�����
            AttendanceInAndOutRecordLog log = new AttendanceInAndOutRecordLog();
            log.EmployeeID = Convert.ToInt32(_View.EmployeeId);
            log.EmployeeName = _View.EmployeeName;
            log.OldIOStatus = oldRecord.IOStatus;
            log.OldIOTime = oldRecord.IOTime;
            DateTime oldDate = oldRecord.IOTime;
            log.OperateReason = _View.Reason;
            log.Operator = LoginUser.Name;
            #endregion
            //תΪ������
            _Utility.CompleteTheObject(oldRecord);
            oldRecord.OperateStatus = OutInRecordOperateStatusEnum.ModifyByOperator;
            //������־ ,�ռ�������������
            log.NewIOStatus = oldRecord.IOStatus;
            log.NewIOTime = oldRecord.IOTime;
            log.OperateStatus = oldRecord.OperateStatus;
            log.OperateTime = oldRecord.OperateTime;



            try
            {
                InstanceFactory.AttendanceInOutRecordFacade().UpdateAttendanceInOutRecord(
                    Convert.ToInt32(_View.EmployeeId), oldRecord, oldDate, log, LoginUser);

                _View.ActionSuccess = true;
            }
            catch (ApplicationException ae)
            {
                _View.Message = ae.Message;
            }
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}

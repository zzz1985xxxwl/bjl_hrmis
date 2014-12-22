using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// �޸İ��
    /// </summary>
    public class UpdatePlanDuty : Transaction
    {
        
        private readonly IPlanDutyDal _DalRull = new PlanDutyDal();
        private readonly PlanDutyTable _PlanDutyTable;
        private string _RepeatAccountList = string.Empty; 
        /// <summary>
        /// �޸İ�𣬹��캯��
        /// </summary>
        public UpdatePlanDuty(PlanDutyTable planDutyTable)
        {
            _PlanDutyTable = planDutyTable;

        }
        /// <summary>
        /// ������
        /// </summary>
        public UpdatePlanDuty(PlanDutyTable planDutyTable, IPlanDutyDal ruleMock)
        {
            _PlanDutyTable = planDutyTable;
            _DalRull = ruleMock;
        }
        /// <summary>
        /// �޸�ʱ�鿴������¼�Ƿ���ڣ����ж��Ƿ�������
        /// </summary>
        protected override void Validation()
        {
            if (_DalRull.GetPlanDutyTableByPkid(_PlanDutyTable.PlanDutyTableID) == null)
            {
                throw new ApplicationException("���Ű������");
                BllUtility.ThrowException(BllExceptionConst._DutyClass_Not_Exist);
            }
            if (_DalRull.CountPlanDutyByPlanDutyDiffPkid(_PlanDutyTable.PlanDutyTableID, _PlanDutyTable.PlanDutyTableName) > 0)
            {
                throw new ApplicationException("���Ű�������ظ�");
            }
            for (int i = 0; i < _PlanDutyTable.PlanDutyAccountList.Count; i++)
            {
                if (_DalRull.GetPlanDutyDetailByAccountIDAndPlanDutyID(_PlanDutyTable.PlanDutyTableID, _PlanDutyTable.PlanDutyAccountList[i].Id, _PlanDutyTable.FromTime,
                                                    _PlanDutyTable.ToTime) > 0)
                {
                    _RepeatAccountList = _RepeatAccountList + BllInstance.AccountBllInstance.GetAccountById(_PlanDutyTable.PlanDutyAccountList[i].Id).Name + ",";
                }
            }
            if (_RepeatAccountList != string.Empty)
            {
                throw new ApplicationException(_RepeatAccountList + "��ʱ������Ѵ����Ű�");
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _DalRull.UpdatePlanDutyTable(_PlanDutyTable, _PlanDutyTable.PlanDutyAccountList);
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}

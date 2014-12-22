using System.Collections.Generic;
using System.Transactions;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Reimburse
{
    /// <summary>
    /// ����������
    /// </summary>
    public class AddReimburse : Transaction
    {
        /// <summary>
        /// �����๤��
        /// </summary>
        private static IReimburse _DalReimburse = new ReimburseDal();
        private static IEmployee _DalEmployee = new EmployeeDal();
        private Employee _EmployeeReimburse;
        private readonly int _EmployeeID;
        private readonly HRMISModel.Reimburse _Reimburse;

        //private Account _LoginUser;

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <returns></returns>
        public AddReimburse(int employeeID, HRMISModel.Reimburse reimburse)
        {
            _EmployeeID = employeeID;
            _Reimburse = reimburse;
            SetEmployeeReimburse();
        }
        /// <summary>
        /// ����������
        /// </summary>
        public AddReimburse(int employeeID, HRMISModel.Reimburse reimburse, IReimburse iReimburseMock, IEmployee iEmployee)
        {
            _DalReimburse = iReimburseMock;
            _DalEmployee = iEmployee;
            _EmployeeID = employeeID;
            _Reimburse = reimburse;
            SetEmployeeReimburse();
        }
        private void SetEmployeeReimburse()
        {
            _EmployeeReimburse = _DalEmployee.GetEmployeeByAccountID(_EmployeeID);
            _EmployeeReimburse.Reimburses = new List<HRMISModel.Reimburse>();
            _EmployeeReimburse.Reimburses.Add(_Reimburse);
        }

        protected override void Validation()
        {

        }
        // ������������Ϣ

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (_EmployeeReimburse.Reimburses[0].ReimburseStatus == ReimburseStatusEnum.Reimbursing)
                    {
                        _EmployeeReimburse.Reimburses[0].ReimburseFlows = new List<ReimburseFlow>();
                        _EmployeeReimburse.Reimburses[0].ReimburseFlows.Add(
                            new ReimburseFlow(_EmployeeReimburse, System.DateTime.Now, _EmployeeReimburse.Reimburses[0].ReimburseStatus));
                    }
                    _DalReimburse.InsertEmployeeReimburse(_EmployeeReimburse);
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}

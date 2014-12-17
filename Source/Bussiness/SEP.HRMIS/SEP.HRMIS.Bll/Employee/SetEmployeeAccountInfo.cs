using SEP.HRMIS.Model;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 加载SEP的信息
    /// </summary>
    public class LoadSEPInfo
    {
        /// <summary>
        /// 为employee填充account的信息，其中包括account中的dept
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="employee"></param>
        /// <param name="_IAccountBll"></param>
        /// <returns></returns>
        /// <param name="_IDepartmentBll"></param>
        public static Employee SetEmployeeAccountInfo(int accountID, Employee employee, IAccountBll _IAccountBll,
                                                      IDepartmentBll _IDepartmentBll)
        {
            PositionGrade grade=null;
            if (employee.Account != null && employee.Account.Position != null &&
                       employee.Account.Position.Grade != null)
            {
                 grade = employee.Account.Position.Grade;
            }
            employee.Account = _IAccountBll.GetAccountById(accountID);
            if(grade!=null)
            {
                employee.Account.Position.Grade = grade;
            }
            employee.Account.Dept = _IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null);

            return employee;
        }

        ///<summary>
        ///</summary>
        ///<param name="accountID"></param>
        ///<param name="employee"></param>
        ///<param name="_IAccountBll"></param>
        ///<param name="_IDepartmentBll"></param>
        ///<param name="_IPositionBll"></param>
        ///<returns></returns>
        public static Employee SetEmployeeAccountInfo(int accountID, Employee employee, IAccountBll _IAccountBll,
                                                      IDepartmentBll _IDepartmentBll, IPositionBll _IPositionBll)
        {
            int gradeID=-1;
            if (employee.Account.Position != null && employee.Account.Position.Grade != null)
            {
                gradeID = employee.Account.Position.Grade.Id;
            }

            employee.Account = _IAccountBll.GetAccountById(accountID);
            if (employee.Account.Position != null)
            {
                employee.Account.Position = _IPositionBll.GetPositionById(employee.Account.Position.Id, null);

                employee.Account.Position.Grade =
                    _IPositionBll.GetPositionGradeById(gradeID, null);
            }
            employee.Account.Dept = _IDepartmentBll.GetDepartmentById(employee.Account.Dept.Id, null);

            return employee;
        }
    }
}
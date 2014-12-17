using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    public class GetDutyClass
    {
        private readonly IPlanDutyDal _DalRull = DalFactory.DataAccess.CreatePlanDutyDal();

        public List<DutyClass> GetDutyClassByCondition(int id, string ruleName)
        {
            return _DalRull.GetDutyClassByCondition(id, ruleName);
        }

        public DutyClass GetDutyClassByPkid(int pkid)
        {
            return _DalRull.GetDutyClassByPkid(pkid);
        }
    }
}

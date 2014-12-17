using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.Model.Positions;

namespace SEP.HRMIS.Logic
{
    public class PositionLogic
    {
        public static List<Position> GetPositionByCompanyID(int companyID)
        {
            return PositionDA.GetPositionByCompanyID(companyID).Select(PositionEntity.Convert).ToList();
        }
    }
}

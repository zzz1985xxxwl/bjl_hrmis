using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class AssessActivityPaperDA
    {
        public static List<AssessActivityPaperEntity> GetByAssessActivityIDs(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return new List<AssessActivityPaperEntity>();
            }
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                   @"select * from TAssessActivityPaper  with(nolock) 
where AssessActivityID in (";
                for (var i = 0; i < ids.Count; i++)
                {
                    dataOperator.CommandText += "@AssessActivityID" + i + ",";
                    dataOperator.SetParameter("@AssessActivityID" + i, ids[i], SqlDbType.Int);
                }
                dataOperator.CommandText = dataOperator.CommandText.TrimEnd(',') + ")";
                return dataOperator.ExecuteEntityList<AssessActivityPaperEntity>();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.DataAccess
{
    public class AssessActivityItemDA
    {
        public static List<AssessActivityItemEntity> GetByAssessActivityIDs(List<int> ids)
        {
            if(ids==null||ids.Count==0)
            {
                return new List<AssessActivityItemEntity>();
            }
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                   @"select a.*,c.PKID as AssessActivityID from TAssessActivityItem as a  with(nolock) 
inner join TAssessActivityPaper as b with(nolock)
on a.AssessActivityPaperID=b.PKID
inner join TAssessActivity as c with(nolock)
on c.PKID=b.AssessActivityID WHERE c.PKID in (";
                for (var i = 0; i < ids.Count; i++)
                {
                    dataOperator.CommandText += "@AssessActivityID" + i + ",";
                    dataOperator.SetParameter("@AssessActivityID" + i, ids[i], SqlDbType.Int);
                }
                dataOperator.CommandText = dataOperator.CommandText.TrimEnd(',') + ")";
                return dataOperator.ExecuteEntityList<AssessActivityItemEntity>();
            }
        }
    }
}

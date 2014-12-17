using System;
using System.Collections.Generic;
using System.Data;
using Framework.Common.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.DataAccess
{
    public class AssessActiveityDA
    {
        public static List<AssessActivityEntity> GetAnnualAssessActivityByCondition(AssessCharacterType assessCharacterType, AssessStatus status, DateTime?
          hrSubmitTimeFrom, DateTime? hrSubmitTimeTo, int finishStatus, DateTime? scopeFrom, DateTime? scopeTo)
        {
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"SELECT A.*
	FROM TAssessActivity A with(nolock)  
	WHERE A.AssessCharacter=8
        and A.PKID in (
				SELECT distinct AssessActivityID FROM TAssessActivityPaper C with(nolock) 
				WHERE  1=1 ";
                if (hrSubmitTimeFrom != null)
                {
                    dataOperator.CommandText += " and c.SubmitTime>=@HRSubmitTimeFrom";
                    dataOperator.SetParameter("@HRSubmitTimeFrom", hrSubmitTimeFrom.GetValueOrDefault().Date, SqlDbType.DateTime);
                }
                if (hrSubmitTimeTo != null)
                {
                    dataOperator.CommandText += " and c.SubmitTime<@HRSubmitTimeTo";
                    dataOperator.SetParameter("@HRSubmitTimeTo", hrSubmitTimeTo.Value.AddDays(1).Date, SqlDbType.DateTime);
                }
                dataOperator.CommandText += " )";
                if ((int)assessCharacterType != -1)
                {
                    dataOperator.CommandText += "  AND  A.AssessCharacter=@AssessCharacter";
                    dataOperator.SetParameter("@AssessCharacter", assessCharacterType, SqlDbType.Int);
                }
                if ((int)status != -1)
                {
                    dataOperator.CommandText += "  AND  A.AssessStatus=@AssessStatus";
                    dataOperator.SetParameter("@AssessStatus", status, SqlDbType.Int);
                }
                if (finishStatus != -1)
                {
                    if (finishStatus == 0)
                    {
                        dataOperator.CommandText += " and  A.AssessStatus not in (6,7)";
                    }
                    else
                    {
                        dataOperator.CommandText += " and  A.AssessStatus in (6,7)";
                    }
                }
                if (scopeFrom != null)
                {
                    dataOperator.CommandText += "  AND  A.ScopeFrom>=@ScopeFrom";
                    dataOperator.SetParameter("@ScopeFrom", scopeFrom.GetValueOrDefault().Date, SqlDbType.DateTime);
                }
                if (scopeTo != null)
                {
                    dataOperator.CommandText += "  AND  A.ScopeTo<@ScopeTo";
                    dataOperator.SetParameter("@ScopeTo", scopeTo.Value.AddDays(1).Date, SqlDbType.DateTime);
                }
                dataOperator.CommandText += " ORDER BY A.PKID DESC ";
                return dataOperator.ExecuteEntityList<AssessActivityEntity>();
            }
        }


        public static List<AssessActivityEntity> GetAssessActivityByEmployeeStatus(int EmployeeID, AssessStatus Status)
        {
            using (var dataOperator = new DataOperator(SqlHelper.HrmisConnectionString))
            {
                dataOperator.CommandText =
                    @"  Select  PKID,AssessEmployeeID,AssessCharacter,AssessStatus,ScopeFrom,ScopeTo,
                 PersonalGoal,Reason,AssessProposerName,Intention,HRConfirmerName,
                 PersonalExpectedFinish,ManagerExpectedFinish,PaperName,Score,EmployeeDept,Responsibility,
				 DiyProcess,NextStepIndex,IfEmployeeVisible
        FROM  TAssessActivity
        WHERE AssessStatus=@AssessStatus
        ";
                dataOperator.SetParameter("@AssessStatus", (int)Status, SqlDbType.Int);
                if (EmployeeID >0 )
                {
                    dataOperator.CommandText += " and AssessEmployeeID=@EmployeeID";
                    dataOperator.SetParameter("@EmployeeID", EmployeeID, SqlDbType.Int);
                }

                dataOperator.CommandText += " ORDER BY PKID DESC ";
                return dataOperator.ExecuteEntityList<AssessActivityEntity>();
            }
        }
    }
}

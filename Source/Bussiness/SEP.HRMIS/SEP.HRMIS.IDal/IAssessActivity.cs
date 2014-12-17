//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IAssessActivity.cs
// 创建者: wang.shali
// 创建日期: 2008-05-19
// 概述: 考评活动IDal的接口
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IAssessActivity
    {
        AssessActivity GetAssessActivityById(int id);
        int CountOpeningAssessActivityByAccountId(int accountId, AssessCharacterType assessCharacterType);
        int InsertAssessActivity(AssessActivity obj);

        string GetIntentionByCharacter(AssessCharacterType assessCharacterType);
        List<AssessActivity> GetAssessActivityByEmployee(int accountId);
        List<AssessActivity> GetAssessActivityByEmployeeStatus(int accountId, AssessStatus status);
        List<AssessActivity> GetAssessActivityByManagerName(string managerName);
        List<AssessActivity> GetAssessActivityHistoryByEmployeeName(string managerName);

        List<AssessActivity> GetAssessActivityByCondition(AssessCharacterType assessCharacterType,
                                                          AssessStatus status, DateTime? hrSubmitTimeFrom,
                                                          DateTime? hrSubmitTimeTo, int finishStatus,
                                                          DateTime? scopeFrom, DateTime? scopeTo);
        List<AssessActivity> GetAnnualAssessActivityByCondition(AssessCharacterType assessCharacterType,
                                                  AssessStatus status, DateTime? hrSubmitTimeFrom,
                                                  DateTime? hrSubmitTimeTo, int finishStatus,
                                                  DateTime? scopeFrom, DateTime? scopeTo);
        List<AssessActivity> GetContractAssessActivityByCondition(AssessCharacterType assessCharacterType,
                                                          AssessStatus status, DateTime? hrSubmitTimeFrom,
                                                          DateTime? hrSubmitTimeTo, int finishStatus,
                                                          DateTime? scopeFrom, DateTime? scopeTo);

        int UpdateAssessActivity(AssessActivity _AssessActivity);
        int UpdateAssessActivityEmployeeVisible(int assessActivityID, bool ifEmployeeVisible);
        int UpdateAssessActivityPaper(SubmitInfo submitInfo, int assessActivityID);

        // add by liudan 2009-09-03
        void DeleteAssessActivity(int assessActivityID);
    }
}

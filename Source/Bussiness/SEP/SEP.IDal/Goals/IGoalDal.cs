//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IGoalDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 目标持久层接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Goals;

namespace SEP.IDal.Goals
{
    /// <summary>
    /// 目标持久层接口
    /// </summary>
    public interface IGoalDal
    {
        int InsertPersonalGoal(PersonalGoal obj);
        int InsertTeamGoal(TeamGoal obj);
        int InsertCompanyGoal(CompanyGoal obj);
        int UpdatePersonalGoal(PersonalGoal obj);
        int UpdateTeamGoal(TeamGoal obj);
        int UpdateCompanyGoal(CompanyGoal obj);

        int GetPersonalGoalCountByTitle(int hostID , string title );
        int GetPersonalGoalCountByTitleDiffPKID(int _PKID, int hostID, string title);
        int GetTeamGoalCountByTitle(int hostID, string title);
        int GetTeamGoalCountByTitleDiffPKID(int _PKID, int hostID, string title);
        int GetCompanyGoalCountByTitle(string title);
        int GetCompanyGoalCountByTitleDiffPKID(int _PKID, string title);
        

        Goal GetGoalByPKID(int pkid);
        List<CompanyGoal> GetCompanyGoal();
        List<PersonalGoal> GetPersonalGoalBySetHostID(int setHostID);
        List<TeamGoal> GetTeamGoalBySetHostID(int setHostID);
        CompanyGoal GetLastCompanyGoal();
        PersonalGoal GetLastPersonalGoalBySetHostID(int setHostID);
        TeamGoal GetLastTeamGoalBySetHostID(int setHostID);

        int DeleteGoalByPKID(int pkid);
        int DeletePersonalGoalBySetHostID(int setHostID);
        int DeleteTeamGoalBySetHostID(int setHostID);
    }
}

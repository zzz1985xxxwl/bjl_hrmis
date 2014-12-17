//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IGoalBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 目标业务接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Goals;

namespace SEP.IBll.Goals
{
    /// <summary>
    /// 目标业务接口
    /// </summary>
    public interface IGoalBll
    {
        void CreateCompanyGoal(CompanyGoal companyGoal, Account loginUser);
        void UpdateCompanyGoal(CompanyGoal companyGoal, Account loginUser);


        void CreateTeamGoal(TeamGoal teamGoal, Account loginUser);
        void UpdateTeamGoal(TeamGoal teamGoal, Account loginUser);


        void CreatePersonalGoal(PersonalGoal personalGoal, Account loginUser);
        void UpdatePersonalGoal(PersonalGoal personalGoal, Account loginUser);


        void DeleteGoal(int goalId, Account loginUser);
        void DeletePersonalGoalBySetHostId(int setHostId, Account loginUser);
        void DeleteTeamGoalBySetHostId(int setHostId, Account loginUser);



        Goal GetGoalByPKID(int pkid, Account loginUser);

        List<CompanyGoal> GetCompanyGoal(Account loginUser);

        List<PersonalGoal> GetPersonalGoalBySetHostID(int setHostId, Account loginUser);

        List<TeamGoal> GetTeamGoalBySetHostID(int setHostId, Account loginUser);

        CompanyGoal GetLastCompanyGoal(Account loginUser);

        PersonalGoal GetLastPersonalGoalBySetHostID(int setHostId, Account loginUser);

        TeamGoal GetLastTeamGoalBySetHostID(int setHostId, Account loginUser);
    }
}

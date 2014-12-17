//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: GoalBll.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 目标业务实现
// ----------------------------------------------------------------
using SEP.Bll.Goals;
using SEP.IBll.Goals;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Goals;
using SEP.IDal;

namespace SEP.Bll
{
    internal class GoalBll : IGoalBll
    {
        #region IGoalBll 成员

        public void CreateCompanyGoal(CompanyGoal companyGoal, Account loginUser)
        {
            AddCompanyGoal addCompanyGoal = new AddCompanyGoal(companyGoal, loginUser);
            addCompanyGoal.Excute();
        }

        public void UpdateCompanyGoal(CompanyGoal companyGoal, Account loginUser)
        {
            UpdateCompanyGoal updateCompanyGoal = new UpdateCompanyGoal(companyGoal, loginUser);
            updateCompanyGoal.Excute();
        }

        public void CreateTeamGoal(TeamGoal teamGoal, Account loginUser)
        {
            AddTeamGoal addTeamGoal = new AddTeamGoal(teamGoal, loginUser);
            addTeamGoal.Excute();
        }

        public void UpdateTeamGoal(TeamGoal teamGoal, Account loginUser)
        {
            UpdateTeamGoal updateTeamGoal = new UpdateTeamGoal(teamGoal, loginUser);
            updateTeamGoal.Excute();
        }

        public void CreatePersonalGoal(PersonalGoal personalGoal, Account loginUser)
        {
            AddPersonalGoal addPersonalGoal = new AddPersonalGoal(personalGoal, loginUser);
            addPersonalGoal.Excute();
        }

        public void UpdatePersonalGoal(PersonalGoal personalGoal, Account loginUser)
        {
            UpdatePersonalGoal updatePersonalGoal = new UpdatePersonalGoal(personalGoal, loginUser);
            updatePersonalGoal.Excute();
        }

        public void DeleteGoal(int goalId, Account loginUser)
        {
            DeleteGoal deleteGoal = new DeleteGoal(goalId, loginUser);
            deleteGoal.Excute();
        }

        public void DeletePersonalGoalBySetHostId(int setHostId, Account loginUser)
        {
            DeletePersonalGoalBySetHostID deleteGoalBySetHostId = new DeletePersonalGoalBySetHostID(setHostId, loginUser);
            deleteGoalBySetHostId.Excute();
        }

        public void DeleteTeamGoalBySetHostId(int setHostId, Account loginUser)
        {
            DeleteTeamGoalBySetHostID deleteGoalBySetHostId = new DeleteTeamGoalBySetHostID(setHostId, loginUser);
            deleteGoalBySetHostId.Excute();
        }

        public Goal GetGoalByPKID(int pkid, Account loginUser)
        {
            return DalInstance.GoalDalInstance.GetGoalByPKID(pkid);
        }

        public List<CompanyGoal> GetCompanyGoal(Account loginUser)
        {
            return DalInstance.GoalDalInstance.GetCompanyGoal();
        }

        public List<PersonalGoal> GetPersonalGoalBySetHostID(int setHostId, Account loginUser)
        {
            return DalInstance.GoalDalInstance.GetPersonalGoalBySetHostID(setHostId);
        }

        public List<TeamGoal> GetTeamGoalBySetHostID(int setHostID, Account loginUser)
        {
            return DalInstance.GoalDalInstance.GetTeamGoalBySetHostID(setHostID);
        }

        public CompanyGoal GetLastCompanyGoal(Account loginUser)
        {
            return DalInstance.GoalDalInstance.GetLastCompanyGoal();
        }

        public PersonalGoal GetLastPersonalGoalBySetHostID(int setHostID, Account loginUser)
        {
            return DalInstance.GoalDalInstance.GetLastPersonalGoalBySetHostID(setHostID);
        }

        public TeamGoal GetLastTeamGoalBySetHostID(int setHostID, Account loginUser)
        {
            return DalInstance.GoalDalInstance.GetLastTeamGoalBySetHostID(setHostID);
        }

        #endregion
    }
}

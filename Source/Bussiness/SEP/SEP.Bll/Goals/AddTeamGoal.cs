//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddTeamGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 增加团队目标
// ----------------------------------------------------------------
using SEP.Model;
using SEP.Model.Goals;
using SEP.Model.Accounts;
using SEP.IDal;

namespace SEP.Bll.Goals
{
    public class AddTeamGoal : Transaction
    {
        private Account _LoginUser;
        private TeamGoal _TeamGoal;

        public AddTeamGoal(TeamGoal teamGoal, Account loginUser)
        {
            _TeamGoal = teamGoal;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.InsertTeamGoal(_TeamGoal);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        protected override void Validation()
        {
            if(_TeamGoal.Dept.Leader.Id != _LoginUser.Dept.Leader.Id)
            {
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            }
            //团队目标中同一目标主人ID下标题不能重名
            if (DalInstance.GoalDalInstance.GetTeamGoalCountByTitle(_TeamGoal.Dept.Id, _TeamGoal.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._DepartmentGoal_Title_Repeat);
            }
        }
    }
}

//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdateTeamGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 修改团队目标
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Goals;

namespace SEP.Bll.Goals
{
    public class UpdateTeamGoal : Transaction
    {
        private Account _LoginUser;
        private readonly TeamGoal _TeamGoal;


        public UpdateTeamGoal(TeamGoal teamGoal, Account loginUser)
        {
            _TeamGoal = teamGoal;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.UpdateTeamGoal(_TeamGoal);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        protected override void Validation()
        {
            if (_TeamGoal.Dept.Leader.Id != _LoginUser.Id)
            {
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            }

            //是否存在该目标
            if (DalInstance.GoalDalInstance.GetGoalByPKID(_TeamGoal.Id) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Goal_NotExist);
            }

            //团队目标中同一目标主人ID下标题不能重名
            if (DalInstance.GoalDalInstance.GetTeamGoalCountByTitleDiffPKID(_TeamGoal.Id,
                _TeamGoal.Dept.Id, _TeamGoal.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._DepartmentGoal_Title_Repeat);
            }
        }
    }
}

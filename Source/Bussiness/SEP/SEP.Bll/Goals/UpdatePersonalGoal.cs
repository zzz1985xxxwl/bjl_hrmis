//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdatePersonalGoal.cs
// 创建者: colbert
// 创建日期: 2009-09-22
// 概述: 修改个人目标
// ----------------------------------------------------------------
using System;

using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Goals;

namespace SEP.Bll.Goals
{
    public class UpdatePersonalGoal : Transaction
    {
        private Account _LoginUser;
        private readonly PersonalGoal _PersonalGoal;

        public UpdatePersonalGoal(PersonalGoal personalGoal, Account loginUser)
        {
            _PersonalGoal = personalGoal;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.UpdatePersonalGoal(_PersonalGoal);
            }
            catch (Exception)
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
            
        }
        protected override void Validation()
        {
            if (_PersonalGoal.Account.Id != _LoginUser.Id)
            {
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            }

            //是否存在该目标
            if (DalInstance.GoalDalInstance.GetGoalByPKID(_PersonalGoal.Id) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Goal_NotExist);
            }
            //个人目标中同一目标主人ID下标题不能重名
            if (DalInstance.GoalDalInstance.GetPersonalGoalCountByTitleDiffPKID(_PersonalGoal.Id, _PersonalGoal.Account.Id, _PersonalGoal.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._PersonalGoal_Title_Repeat);
            }
        }
    }
}

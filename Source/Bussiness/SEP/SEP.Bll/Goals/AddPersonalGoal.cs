//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddPersonalGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 增加个人目标
// ----------------------------------------------------------------
using SEP.Model;
using SEP.Model.Goals;
using SEP.Model.Accounts;
using SEP.IDal;

namespace SEP.Bll.Goals
{
    public class AddPersonalGoal : Transaction
    {
        private Account _LoginUser;
        private PersonalGoal _PersonalGoal;

        public AddPersonalGoal(PersonalGoal personalGoal, Account loginUser)
        {
            _PersonalGoal = personalGoal;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.InsertPersonalGoal(_PersonalGoal);
            }
            catch
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
            //个人目标中同一目标主人ID下标题不能重名
            if (DalInstance.GoalDalInstance.GetPersonalGoalCountByTitle(_PersonalGoal.Account.Id, _PersonalGoal.Title)> 0)
            {
                throw MessageKeys.AppException(MessageKeys._PersonalGoal_Title_Repeat);
            }
        }
    }
}

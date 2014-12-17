//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeleteGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 通过PKID删除目标
// ----------------------------------------------------------------
using SEP.Model;
using SEP.Model.Accounts;
using SEP.IDal;

namespace SEP.Bll.Goals
{
    public class DeleteGoal: Transaction
    {
        private Account _LoginUser;
        private int _GoalId;

        public DeleteGoal(int goalId, Account loginUser)
        {
            _GoalId = goalId;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.DeleteGoalByPKID(_GoalId);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        protected override void Validation()
        {
            //if(!Powers.HasAuth(_LoginUser.Auths, Powers.A401))
            //    throw MessageKeys.AppException(MessageKeys._NoAuth);
                
            //该目标是否存在
            if (DalInstance.GoalDalInstance.GetGoalByPKID(_GoalId) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Goal_NotExist);
            }
        }
    }
}

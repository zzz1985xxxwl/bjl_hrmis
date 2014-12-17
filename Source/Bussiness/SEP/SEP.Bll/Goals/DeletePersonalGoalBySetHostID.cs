//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeletePersonalGoalBySetHostID.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 通过SetHostID删除个人目标
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Bll.Goals
{
    public class DeletePersonalGoalBySetHostID : Transaction
    {
        private Account _LoginUser;
        private readonly int _HostID;

        public DeletePersonalGoalBySetHostID(int hostID, Account loginUser)
        {
            _HostID = hostID;
            _LoginUser = loginUser;
        }
        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.DeletePersonalGoalBySetHostID(_HostID);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            if(_LoginUser.Id != _HostID)
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //该个人的目标是否存在
            if (DalInstance.GoalDalInstance.GetPersonalGoalBySetHostID(_HostID).Count == 0)
            {
                throw MessageKeys.AppException(MessageKeys._PersonalGoal_NotExist);
            }
        }
    }
}


//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeleteTeamGoalBySetHostID.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 通过SetHostID删除团队目标
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.Bll.Goals
{
    public class DeleteTeamGoalBySetHostID : Transaction
    {
        private Account _LoginUser;
        private readonly int _HostID;

        public DeleteTeamGoalBySetHostID(int hostID, Account loginUser)
        {
            _HostID = hostID;
            _LoginUser = loginUser;
        }
        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.DeleteTeamGoalBySetHostID(_HostID);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            Department dept = DalInstance.DeptDalInstance.GetDepartmentById(_HostID);
            if(dept != null && _LoginUser.Id != dept.Leader.Id)
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            if (dept == null && !Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A401))
                throw MessageKeys.AppException(MessageKeys._NoAuth);


            //该团队的目标是否存在
            if (DalInstance.GoalDalInstance.GetTeamGoalBySetHostID(_HostID).Count == 0)
            {
                throw MessageKeys.AppException(MessageKeys._DepartmentGoal_NotExist);
            }
        }
    }
}

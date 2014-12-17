//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdateCompanyGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 修改公司目标
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Goals;

namespace SEP.Bll.Goals
{
    public class UpdateCompanyGoal : Transaction
    {
        private Account _LoginUser;
        private readonly CompanyGoal _CompanyGoal;

        public UpdateCompanyGoal(CompanyGoal companyGoal, Account loginUser)
        {
            _CompanyGoal = companyGoal;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.UpdateCompanyGoal(_CompanyGoal);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        protected override void Validation()
        {
            //验证权限
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A401))
            {
                throw MessageKeys.AppException(MessageKeys._NoAuth);
            }

            //是否存在该目标
            if (DalInstance.GoalDalInstance.GetGoalByPKID(_CompanyGoal.Id) == null)
            {
                throw MessageKeys.AppException(MessageKeys._Goal_NotExist);
            }
            //公司目标中标题不能重名
            if (DalInstance.GoalDalInstance.GetCompanyGoalCountByTitleDiffPKID(_CompanyGoal.Id, _CompanyGoal.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._CompanyGoal_Title_Repeat);
            }
        }
    }
}

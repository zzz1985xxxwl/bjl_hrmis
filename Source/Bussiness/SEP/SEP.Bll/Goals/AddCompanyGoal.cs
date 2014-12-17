//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddCompanyGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 增加公司目标
// ----------------------------------------------------------------
using SEP.Model;
using SEP.Model.Goals;
using SEP.Model.Accounts;
using SEP.IDal;

namespace SEP.Bll.Goals
{
    public class AddCompanyGoal : Transaction
    {
        private Account _LoginUser;
        private CompanyGoal _CompanyGoal;


        public AddCompanyGoal(CompanyGoal companyGoal, Account loginUser)
        {
            _CompanyGoal = companyGoal;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.GoalDalInstance.InsertCompanyGoal(_CompanyGoal);
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

            //公司目标中标题不能重名
            if (DalInstance.GoalDalInstance.GetCompanyGoalCountByTitle(_CompanyGoal.Title) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._CompanyGoal_Title_Repeat);
            }
        }
    }
}

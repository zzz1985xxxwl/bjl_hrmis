//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateEmployeeProxy.cs
// 创建者: 倪豪
// 创建日期: 2008-11-11
// 概述: 修改员工的代理类,在不改变原来类代码的前提下，处理一些
//       非事务性的工作
// ----------------------------------------------------------------

using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 更新员工信息
    /// </summary>
    public class UpdateEmployeeProxy : UpdateEmployee, ITranscationProxy
    {
        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        public UpdateEmployeeProxy(Employee employee, Account operatoraccount)
            : base(employee, operatoraccount)
        {
        }

        protected override void ExcuteSelf()
        {
            BeforeTranscation();
            base.ExcuteSelf();
            AfterTranscation();
        }
        #region ITranscationProxy 成员


        /// <summary>
        /// 定义该Transcation处理之前要做的工作,验证权限之类的工作可以在这里处理
        /// </summary>
        public void BeforeTranscation()
        {
        }

        /// <summary>
        /// 定义该Transcation成功后要做的工作，记录日志之类的工作可以在这里处理
        /// </summary>
        public void AfterTranscation()
        {
            //todo noted by wsl transfer waiting for modify
            //MailFilter.DisableDimissionEmployeeCache();
            EmployeeCache.DisableEmployeeCache();
        }
        #endregion
    }
}
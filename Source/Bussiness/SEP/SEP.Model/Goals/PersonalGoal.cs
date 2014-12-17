//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: PersonalGoal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 个人目标
// ----------------------------------------------------------------
using System;
using SEP.Model.Accounts;

namespace SEP.Model.Goals
{
    /// <summary>
    /// 个人目标
    /// </summary>
    [Serializable]
    public class PersonalGoal : Goal
    {
        private Account _Account;

        public Account Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
            }
        }

        public PersonalGoal(int id, string title, string content, DateTime setTime,
            Account account)
            : base(id, title, content, setTime)
        {
            _Account = account;
        }
    }
}
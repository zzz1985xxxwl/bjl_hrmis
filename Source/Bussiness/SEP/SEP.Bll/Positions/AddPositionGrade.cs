//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddPositionGrade.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 新增职位等级
// ----------------------------------------------------------------
using System;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.Bll.Positions
{
    internal class AddPositionGrade : Transaction
    {
        private Account _LoginUser;
        private PositionGrade _PositionGrade;

        public AddPositionGrade(PositionGrade PositionGrade, Account loginUser)
        {
            _PositionGrade = PositionGrade;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.InsertPositionGrade(_PositionGrade);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        
        protected override void Validation()
        {
            if(String.IsNullOrEmpty(_PositionGrade.Name))
            {
                throw MessageKeys.AppException(MessageKeys._PositionGrade_NameIsEmpty);
            }

            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A203))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            PositionGrade grade = DalInstance.PositionDalInstance.GetPositionGradeByName(_PositionGrade.Name);
            if (grade != null&&grade.Name == _PositionGrade.Name)
            {
                throw MessageKeys.AppException(MessageKeys._PositionGrade_Name_Repeat);
            }
        }
    }
}

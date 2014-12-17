//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdatePositionGrade.cs
// 创建者: yyb
// 创建日期: 2009-02-22
// 概述: 修改职位等级
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;
namespace SEP.Bll.Positions
{
    internal class UpdatePositionGrade : Transaction
    {
        private Account _LoginUser;
        private readonly PositionGrade _PositionGrade;

        public UpdatePositionGrade(PositionGrade PositionGrade, Account loginUser)
        {
            _PositionGrade = PositionGrade;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.UpdatePositionGrade(_PositionGrade);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        /// <summary>
        /// 修改职位层级有效性判断：
        /// 1、修改的职位层级已经存在
        /// 2、职位层级不能与已有的其他职位层级重名
        /// 3、职位层级在使用中
        /// </summary>
        protected override void Validation()
        {
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A203))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            PositionGrade grade = DalInstance.PositionDalInstance.GetPositionGradeByName(_PositionGrade.Name);
            if (grade != null && grade.Id != _PositionGrade.Id)
            {
                throw MessageKeys.AppException(MessageKeys._PositionGrade_Name_Repeat);
            }
        }
    }
}

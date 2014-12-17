//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeletePositionGrade.cs
// 创建者: Colbert
// 创建日期: 2009-02-22
// 概述: 删除职位等级
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.Bll.Positions
{
    internal class DeletePositionGrade : Transaction
    {
        private Account _LoginUser;
        private int _PositionGradeId;

        public DeletePositionGrade(int PositionGradeId, Account loginUser)
        {
            _PositionGradeId = PositionGradeId;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.DeletePositionGrade(_PositionGradeId);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A203))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //List<Position> positions = DalInstance.PositionDalInstance.GetPositionByGradeId(_PositionGradeId);
            //if (positions != null && positions.Count != 0)
            //    throw MessageKeys.AppException(MessageKeys._PositionGrade_HasPosition);
        }
    }
}

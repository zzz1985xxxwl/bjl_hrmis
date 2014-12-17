//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdatePosition.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 修改职位
// ----------------------------------------------------------------

using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.Bll.Positions
{
    internal class UpdatePosition : Transaction
    {
        private Account _LoginUser;
        private readonly Position _Position;

        public UpdatePosition(Position position, Account loginUser)
        {
            _Position = position;
            _LoginUser = loginUser;
        }

        /// <summary>
        /// 调用下层的修改职位的方法
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.UpdatePosition(_Position);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A202))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            Position position = DalInstance.PositionDalInstance.GetPositionByName(_Position.Name);
            if (position != null && position.Id != _Position.Id)
            {
                throw MessageKeys.AppException(MessageKeys._Position_Name_Repeat);
            }
        }
    }
}

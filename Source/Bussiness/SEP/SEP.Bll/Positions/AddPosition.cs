//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AddPosition.cs
// 创建者: colbert
// 创建日期: 2009-02-22
// 概述: 新增职位
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Positions;
using SEP.Model.Accounts;

namespace SEP.Bll.Positions
{
    internal class AddPosition : Transaction
    {
        private Account _LoginUser;
        private Position _Position;
    
        public AddPosition(Position postion, Account loginUser)
        {
            _Position = postion;
            _LoginUser = loginUser;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.InsertPosition(_Position);        
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
            if (position != null)
            {
                throw MessageKeys.AppException(MessageKeys._Position_Name_Repeat);
            }
        }
    }
}

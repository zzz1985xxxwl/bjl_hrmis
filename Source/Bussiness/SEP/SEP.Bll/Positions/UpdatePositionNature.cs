//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdatePositionNature.cs
// 创建者: yyb
// 创建日期: 2010-8-10
// 概述: 修改岗位性质
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Positions;

namespace SEP.Bll.Positions
{
    internal class UpdatePositionNature : Transaction
    {
        private readonly PositionNature _PositionNature;

        public UpdatePositionNature(PositionNature PositionNature)
        {
            _PositionNature = PositionNature;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.UpdatePositionNature(_PositionNature);
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
            if (DalInstance.PositionDalInstance.CountPositionNatureByNameDiffPKID(_PositionNature.Pkid, _PositionNature.Name) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._PositionNature_Name_Repeat);
            }
        }
    }
}
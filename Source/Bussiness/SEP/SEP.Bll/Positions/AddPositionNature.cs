//----------------------------------------------------------------
// Copyright (C) 2000-2010 Shixin Corporation
// All rights reserved.
// 文件名: AddPositionGrade.cs
// 创建者: yyb
// 创建日期: 2010-8-10
// 概述: 新增岗位性质
// ----------------------------------------------------------------
using System;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Positions;

namespace SEP.Bll.Positions
{
    internal class AddPositionNature : Transaction
    {
        private readonly PositionNature _PositionNature;

        public AddPositionNature(PositionNature PositionGrade)
        {
            _PositionNature = PositionGrade;
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.PositionDalInstance.InsertPositionNature(_PositionNature);
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            if (String.IsNullOrEmpty(_PositionNature.Name))
            {
                throw MessageKeys.AppException(MessageKeys._Position_NameIsEmpty);
            }

            if (DalInstance.PositionDalInstance.CountPositionNatureByNameDiffPKID(-1, _PositionNature.Name) > 0)
            {
                throw MessageKeys.AppException(MessageKeys._PositionNature_Name_Repeat);
            }
        }
    }
}

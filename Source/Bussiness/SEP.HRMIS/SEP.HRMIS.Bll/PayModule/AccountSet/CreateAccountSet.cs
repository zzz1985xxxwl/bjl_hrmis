//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CreateAccountSet.cs
// 创建者: wang.shali
// 创建日期: 2008-12
// 概述: 新增帐套
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    public class CreateAccountSet:Transaction
    {
        private IAccountSet _DalAccountSet = new AccountSetDal();
        private string _AccountSetName;
        private string _Description;
        private int _AccountSetID;
        private List<AccountSetItem> _AccountSetItems;
        public int AccountSetID
        {
            get { return _AccountSetID; }
        }
        public CreateAccountSet(string accountSetName, string description, List<AccountSetItem> accountSetItems)
        {
            _AccountSetName = accountSetName;
            _Description = description;
            _AccountSetItems = accountSetItems;
        }
        #region for unit test
        private Model.PayModule.AccountSet _AccountSetTest;
        public Model.PayModule.AccountSet AccountSetForTest
        {
            get { return _AccountSetTest; }
        }
        public CreateAccountSet(string accountSetName, string description, List<AccountSetItem> accountSetItems, IAccountSet iMockAccountSet)
        {
            _AccountSetName = accountSetName;
            _Description = description;
            _AccountSetItems = accountSetItems;
            _DalAccountSet = iMockAccountSet;
        }
        #endregion
        protected override void Validation()
        {
            //判断是否有重名
            if (_DalAccountSet.CountAccountSetByNameDiffPKID(0, _AccountSetName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSetName_Repeat);
            }
            if (_AccountSetItems == null)
            {
                _AccountSetItems = new List<AccountSetItem>();
            }
            foreach (AccountSetItem item in _AccountSetItems)
            {
                //判断Para是否实例化
                if (item.AccountSetPara == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSetPara_IsNull);
                }
                //判断Para的字段属性是否实例化
                if (item.AccountSetPara.FieldAttribute == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSetPara_FieldAttribute_IsNull);
                }
                //判断计算类型的字段是否已填写公式
                if (item.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.CalculateField.Id &&
                    string.IsNullOrEmpty(item.CalculateFormula))
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSet_CalculateFormula_IsNull);
                }
                //判断绑定值类型的字段是否已填写绑定值
                if (item.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.BindField.Id && item.AccountSetPara.BindItem.Id == BindItemEnum.NoBindItem.Id)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSet_BindItem_IsNull);
                }
                //判断para是否存在
                if (_DalAccountSet.GetAccountSetParaByPKID(item.AccountSetPara.AccountSetParaID) == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSetPara_IsNotExist);
                }
            }
            //判断是否有重复的Para被定义
            for (int i = 0; i < _AccountSetItems.Count; i++)
            {
                for (int j = i + 1; j < _AccountSetItems.Count; j++)
                {
                    if (_AccountSetItems[i].AccountSetPara.AccountSetParaID ==
                        _AccountSetItems[j].AccountSetPara.AccountSetParaID)
                    {
                        BllUtility.ThrowException(
                            BllExceptionConst._AccountSet_UseRepeatPara);
                    }
                }
            }
            //判断表达式是否正确
            try
            {
                MakeAccountSet().CheckItemListValidation();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _AccountSetID = _DalAccountSet.InsertWholeAccountSet(MakeAccountSet());
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        private Model.PayModule.AccountSet MakeAccountSet()
        {
            Model.PayModule.AccountSet retAccountSet = new Model.PayModule.AccountSet(0, _AccountSetName);
            retAccountSet.Description = _Description;
            retAccountSet.Items = new List<AccountSetItem>();
            if(_AccountSetItems!=null)
            {
                foreach (AccountSetItem item in _AccountSetItems)
                {
                     retAccountSet.Items.Add(item);
                }
            }
            _AccountSetTest = retAccountSet;
            return retAccountSet;
        }
     }
}

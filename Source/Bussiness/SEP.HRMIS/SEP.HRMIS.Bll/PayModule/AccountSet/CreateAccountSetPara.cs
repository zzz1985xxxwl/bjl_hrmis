//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CreateAccountSetPara.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �������ײ���
// ----------------------------------------------------------------


using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.SqlServerDal.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    /// <summary>
    /// �������������
    /// </summary>
    public class CreateAccountSetPara : Transaction
    {
        private static IAccountSet _DalAccountSet = new AccountSetDal();
        private readonly string _AccountSetParaName;
        private readonly FieldAttributeEnum _FieldAttributes;
        private readonly BindItemEnum _BindItem;
        private readonly MantissaRoundEnum _MantissaRoundEnum;
        private readonly string _Description;
        private int _AccountSetParaID;
        private readonly bool _IsVisibleToEmployee;
        private readonly bool _IsVisibleWhenZero;
        /// <summary>
        /// �������pkid
        /// </summary>
        public int AccountSetParaID
        {
            get { return _AccountSetParaID; }
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public CreateAccountSetPara(string accountSetParaName, FieldAttributeEnum fieldAttributes,
                                    BindItemEnum bindItem, MantissaRoundEnum mantissaRoundEnum, string description,
                                    bool isVisibleToEmployee, bool isVisibleWhenZero)
        {
            _AccountSetParaName = accountSetParaName;
            _FieldAttributes = fieldAttributes;
            _IsVisibleToEmployee = isVisibleToEmployee;
            _IsVisibleWhenZero = isVisibleWhenZero;
            _BindItem = bindItem;
            _MantissaRoundEnum = mantissaRoundEnum;
            _Description = description;
        }

        #region for unit test
        private AccountSetPara _AccountSetParaTest;
        /// <summary>
        /// for test 
        /// </summary>
        public AccountSetPara AccountSetParaForTest
        {
            get { return _AccountSetParaTest; }
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        public CreateAccountSetPara(string accountSetParaName, FieldAttributeEnum fieldAttributes,
                                    BindItemEnum bindItem, MantissaRoundEnum mantissaRoundEnum, string description, 
            bool isVisibleToEmployee, bool isVisibleWhenZero, IAccountSet iMockAccountSet)
        {
            _AccountSetParaName = accountSetParaName;
            _FieldAttributes = fieldAttributes;
            _BindItem = bindItem;
            _MantissaRoundEnum = mantissaRoundEnum;
            _Description = description;
            _DalAccountSet = iMockAccountSet;
            _IsVisibleToEmployee = isVisibleToEmployee;
            _IsVisibleWhenZero = isVisibleWhenZero;
        }
        #endregion

        protected override void Validation()
        {
            //�ж��Ƿ�������
            if (_DalAccountSet.CountAccountSetParaByNameDiffPKID(0, _AccountSetParaName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSetParaName_Repeat);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                _AccountSetParaID = _DalAccountSet.InsertAccountSetPara(MakeAccountSetPara());
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
        private AccountSetPara MakeAccountSetPara()
        {
            AccountSetPara retAccountSetPara = new AccountSetPara(0, _AccountSetParaName);
            retAccountSetPara.BindItem = _BindItem;
            retAccountSetPara.FieldAttribute = _FieldAttributes;
            retAccountSetPara.MantissaRound = _MantissaRoundEnum;
            retAccountSetPara.Description = _Description;
            retAccountSetPara.IsVisibleToEmployee = _IsVisibleToEmployee;
            retAccountSetPara.IsVisibleWhenZero = _IsVisibleWhenZero;
            _AccountSetParaTest = retAccountSetPara;
            return retAccountSetPara;
        }
    }
}
//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAccountSet.cs
// ������: wang.shali
// ��������: 2008-12
// ����: �޸�����
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Bll.PayModule.AccountSet
{
    public class UpdateAccountSet : Transaction
    {
        private static IAccountSet _DalAccountSet = PayModuleDataAccess.CreateAccountSet();
        private static IEmployeeAccountSet _DalEmployeeAccountSet = PayModuleDataAccess.CreateEmployeeAccountSet();
        private string _AccountSetName;
        private string _Description;
        private string _OperatorName;
        private int _AccountSetID;
        private bool _IsAccountSetChanged;
        private List<AccountSetItem> _AccountSetItems;
        private Model.PayModule.AccountSet _OldAccountSet;
        public UpdateAccountSet(int accountSetID, string accountSetName, string description, List<AccountSetItem> accountSetItems, string operatorName)
        {
            _OperatorName = operatorName;
            _AccountSetID = accountSetID;
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
        private List<EmployeeSalary> _EmployeeSalaryListTest;
        public List<EmployeeSalary> EmployeeSalaryListTest
        {
            get { return _EmployeeSalaryListTest; }
        }
        public UpdateAccountSet(int accountSetID, string accountSetName, string description, List<AccountSetItem> accountSetItems, string operatorName,
            IAccountSet iMockAccountSet, IEmployeeAccountSet iMockEmployeeAccountSet)
        {
            _OperatorName = operatorName;
            _AccountSetID = accountSetID;
            _AccountSetName = accountSetName;
            _Description = description;
            _AccountSetItems = accountSetItems;
            _DalAccountSet = iMockAccountSet;
            _DalEmployeeAccountSet = iMockEmployeeAccountSet;
        }
        #endregion
        protected override void Validation()
        {
            //�ж��Ƿ��������
            _OldAccountSet = _DalAccountSet.GetWholeAccountSetByPKID(_AccountSetID);
            if (_OldAccountSet == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSet_IsNotExist);
            }
            //�ж��Ƿ�����
            if (_DalAccountSet.CountAccountSetByNameDiffPKID(_AccountSetID, _AccountSetName) > 0)
            {
                BllUtility.ThrowException(BllExceptionConst._AccountSetName_Repeat);
            }
            //�ж�Items�Ƿ�ʵ����
            if (_AccountSetItems == null)
            {
                _AccountSetItems = new List<AccountSetItem>();
            }
            foreach (AccountSetItem item in _AccountSetItems)
            {
                //�ж�Para�Ƿ�ʵ����
                if (item.AccountSetPara == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSetPara_IsNull);
                }
                //�ж�Para���ֶ������Ƿ�ʵ����
                if (item.AccountSetPara.FieldAttribute == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSetPara_FieldAttribute_IsNull);
                }
                //�жϼ������͵��ֶ��Ƿ�����д��ʽ
                if (item.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.CalculateField.Id && string.IsNullOrEmpty(item.CalculateFormula))
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSet_CalculateFormula_IsNull);
                }
                //�жϰ�ֵ���͵��ֶ��Ƿ�����д��ֵ
                if (item.AccountSetPara.FieldAttribute.Id == FieldAttributeEnum.BindField.Id && item.AccountSetPara.BindItem.Id == BindItemEnum.NoBindItem.Id)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSet_BindItem_IsNull);
                }
                //�ж�para�Ƿ����
                if (_DalAccountSet.GetAccountSetParaByPKID(item.AccountSetPara.AccountSetParaID) == null)
                {
                    BllUtility.ThrowException(BllExceptionConst._AccountSetPara_IsNotExist);
                }
            }
            //�ж��Ƿ����ظ���Para������
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
            //�жϱ��ʽ�Ƿ���ȷ
            try
            {
                MakeAccountSet().CheckItemListValidation();
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                //{
                    _DalAccountSet.UpdateWholeAccountSet(MakeAccountSet());
                    List<EmployeeSalary> employeeSalarys =
                        _DalEmployeeAccountSet.GetEmployeeAccountSetByAccountSetID(_AccountSetID);
                    MergeAccountSetItem(employeeSalarys);
                    if (_IsAccountSetChanged)
                    {
                        UpdateEmployeeAccountSetAfterMerge(employeeSalarys);
                    }
                //    ts.Complete();
                //}
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private void UpdateEmployeeAccountSetAfterMerge(List<EmployeeSalary> employeeSalarys)
        {
            if (employeeSalarys == null || employeeSalarys.Count == 0)
            {
                return;
            }
            foreach (EmployeeSalary salary in employeeSalarys)
            {
                UpdateEmployeeAccountSet updateEmployeeAccountSet =
                    new UpdateEmployeeAccountSet(salary.Employee.Account.Id, salary.AccountSet, _OperatorName, DateTime.Now,
                                                 salary.AccountSet.Description + "��" + DateTime.Now.ToShortDateString() +
                                                 _OperatorName + "�޸����ײ�����ϵͳ�Զ�������ʷ��", _DalAccountSet,
                                                 _DalEmployeeAccountSet);
                updateEmployeeAccountSet.Excute();
            }
        }
        /// <summary>
        /// �ȽϾ����׺������׵����ݣ�ÿ���˵����׽��ж�ɾ�ٲ�
        /// </summary>
        /// <param name="employeeSalarys">Ա�������б�</param>
        private void MergeAccountSetItem(List<EmployeeSalary> employeeSalarys)
        {
            if (employeeSalarys == null || employeeSalarys.Count == 0)
            {
                return;
            }
            //����������ֱ��޸ģ�����Ҫ����Ա�����ף�����¼��ʷ
            if (_AccountSetName != _OldAccountSet.AccountSetName)
            {
                _IsAccountSetChanged = true;
            }
            //employeeSalarys����Ҫ���Ƴ�����
            for (int i = 0; i < _OldAccountSet.Items.Count; i++)
            {
                if (!IsAccountSetInList(_OldAccountSet.Items[i], _AccountSetItems))
                {
                    _IsAccountSetChanged = true;
                    //���item�Ѳ����µ������У���ÿ���˵�������Ҫȥ��item
                    foreach (EmployeeSalary salary in employeeSalarys)
                    {
                        RemoveEmployeeAccountSetItemByAccountSetItemID(salary.AccountSet.Items,
                                                                       _OldAccountSet.Items[i].AccountSetPara.
                                                                           AccountSetParaID);
                    }
                }
            }
            //employeeSalarys����Ҫ��������
            for (int i = 0; i < _AccountSetItems.Count; i++)
            {
                if (!IsAccountSetInList(_AccountSetItems[i], _OldAccountSet.Items))
                {
                    _IsAccountSetChanged = true;
                    //���item������û�У��������У���ÿ���˵�����Ҫ�����µ�item
                    foreach (EmployeeSalary salary in employeeSalarys)
                    {
                        AddEmployeeAccountSetItemWithNewAccountSetItem(salary.AccountSet.Items,
                                                                       _AccountSetItems[i]);
                    }
                }
                else
                {
                    //Calculate�Ƿ������޸�
                    if (IsAccountSetChanged(_AccountSetItems[i], _OldAccountSet.Items))
                    {
                        _IsAccountSetChanged = true;
                        foreach (EmployeeSalary salary in employeeSalarys)
                        {
                            UpdateEmployeeAccountSetItemWithNewAccountSetItem(salary.AccountSet.Items,
                                                                              _AccountSetItems[i]);
                        }
                    }
                }
            }
            foreach (EmployeeSalary salary in employeeSalarys)
            {
                salary.AccountSet.AccountSetName = _AccountSetName;
                salary.AccountSet.Description = _Description;
            }
            _EmployeeSalaryListTest = employeeSalarys;
        }

        /// <summary>
        /// �������������������Ƿ�ı�
        /// </summary>
        /// <param name="item"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        private bool IsAccountSetChanged(AccountSetItem item, List<AccountSetItem> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (item.AccountSetPara.AccountSetParaID == items[i].AccountSetPara.AccountSetParaID)
                {
                    if (item.AccountSetPara.FieldAttribute.Id == items[i].AccountSetPara.FieldAttribute.Id
                        && item.AccountSetPara.BindItem.Id == items[i].AccountSetPara.BindItem.Id
                        && item.AccountSetPara.MantissaRound.Id == items[i].AccountSetPara.MantissaRound.Id
                        && item.CalculateFormula == items[i].CalculateFormula)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ����Ա������
        /// </summary>
        /// <param name="items"></param>
        /// <param name="item"></param>
        private void UpdateEmployeeAccountSetItemWithNewAccountSetItem(List<AccountSetItem> items, AccountSetItem item)
        {
            foreach (AccountSetItem employeeSetItem in items)
            {
                if(employeeSetItem.AccountSetPara.AccountSetParaID==item.AccountSetPara.AccountSetParaID)
                {
                    employeeSetItem.AccountSetPara = item.AccountSetPara;
                    employeeSetItem.CalculateFormula = item.CalculateFormula;
                }
            }
        }

        /// <summary>
        /// �ж�accountSetItems���Ƿ���item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="accountSetItems"></param>
        /// <returns></returns>
        private static bool IsAccountSetInList(AccountSetItem item, List<AccountSetItem> accountSetItems)
        {
            for (int i = 0; i < accountSetItems.Count; i++)
            {
                if (item.AccountSetPara.AccountSetParaID == accountSetItems[i].AccountSetPara.AccountSetParaID)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// ���accountSetItems��������newItem
        /// </summary>
        /// <param name="accountSetItems"></param>
        /// <param name="newItem"></param>
        private static void AddEmployeeAccountSetItemWithNewAccountSetItem(List<AccountSetItem> accountSetItems, AccountSetItem newItem)
        {
            AccountSetItem newitem =
                new AccountSetItem(newItem.AccountSetItemID, newItem.AccountSetPara, newItem.CalculateFormula);
            accountSetItems.Add(newitem);
        }

        /// <summary>
        /// ɾ��accountSetItems��accountSetParaΪID��������
        /// </summary>
        /// <param name="accountSetItems"></param>
        /// <param name="paraId"></param>
        private static void RemoveEmployeeAccountSetItemByAccountSetItemID(List<AccountSetItem> accountSetItems, int paraId)
        {
            for (int i = 0; i < accountSetItems.Count; i++)
            {
                if (accountSetItems[i].AccountSetPara.AccountSetParaID == paraId)
                {
                    accountSetItems.RemoveAt(i);
                    i--;
                }
            }
        }


        private Model.PayModule.AccountSet MakeAccountSet()
        {
            Model.PayModule.AccountSet retAccountSet = new Model.PayModule.AccountSet(0, _AccountSetName);
            retAccountSet.Description = _Description;
            retAccountSet.Items = new List<AccountSetItem>();
            if (_AccountSetItems != null)
            {
                foreach (AccountSetItem item in _AccountSetItems)
                {
                    retAccountSet.Items.Add(item);
                }
            }
            retAccountSet.AccountSetID = _AccountSetID;
            _AccountSetTest = retAccountSet;
            return retAccountSet;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Transactions;
using SEP.HRMIS.Bll.PayModule.AccountSet;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Utility;
using ModelPayModule = SEP.HRMIS.Model.PayModule;
namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    /// <summary>
    /// excel����Ա���������Լ��̶�ֵ
    /// </summary>
    public class ImportEmployeeAccountSet: Transaction
    {
        private readonly Account _Operator;
        private readonly string _FilePath;
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private const string EmployeeAccount_DataString = "Excel����Ա������";
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="_operator"></param>
        public ImportEmployeeAccountSet(string filePath, Account _operator)
        {
            _Operator = _operator;
            _FilePath = filePath;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            DataSet ds = LoadDataFromExcel(_FilePath.Trim());
            InsertUpdateEmployeeAccountSet(ds);
        }
        /// <summary>
        /// ����Ա��������
        /// </summary>
        /// <param name="ds"></param>
        private void InsertUpdateEmployeeAccountSet(DataSet ds)
        {
            int indexAccountSetName = GetDataSetColumnIndex(ds, "��������");
            int indexEmployeeName = GetDataSetColumnIndex(ds, "Ա������");
            if (indexEmployeeName == -1)
            {
                throw new Exception("�޷��ҵ�Ա�������У�����excel��");
            }
            //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            //{
                ToInsertUpdateEmployeeAccountSet(ds, indexAccountSetName, indexEmployeeName);
            //    ts.Complete();
            //}
        }

        /// <summary>
        /// ���columnName��excel�е���Index
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        private static int GetDataSetColumnIndex(DataSet ds, string columnName)
        {
            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
            {
                if (ds.Tables[0].Columns[j].ColumnName.Trim() == columnName)
                {
                    return j;
                }
            }
            return -1;
        }
        /// <summary>
        /// ��ʼ����Ա��������
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="indexAccountSetName"></param>
        /// <param name="indexEmployeeName"></param>
        private void ToInsertUpdateEmployeeAccountSet(DataSet ds, int indexAccountSetName, int indexEmployeeName)
        {
            List<Account> allAccount = _IAccountBll.GetAllAccount();
            allAccount = Tools.RemoteUnAuthAccount(allAccount, AuthType.HRMIS, _Operator, HrmisPowers.A604);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ModelPayModule.AccountSet accountSet = null;
                //��û�е�ǰ�˺�
                Account account =
                    _IAccountBll.GetAccountByName(ds.Tables[0].Rows[i][indexEmployeeName].ToString().Trim());
                if (account == null || !Tools.ContainsAccountById(allAccount, account.Id))
                {
                    continue;
                }
                //��ǰ�˺���û�й����ף���������accountSet���ϵ�ǰ���ף��Ա����
                bool IsEmployeeHaveAccountSet = false;
                EmployeeSalary employeeSalary =
                    new GetEmployeeAccountSet().GetEmployeeAccountSetByEmployeeID(account.Id);
                if (employeeSalary != null && employeeSalary.AccountSet != null)
                {
                    accountSet = employeeSalary.AccountSet;
                    IsEmployeeHaveAccountSet = true;
                }
                //excel�Ƿ������������У����������Ҫȷ���Ƿ�Ҫ��������
                if (indexAccountSetName != -1)
                {
                    ModelPayModule.AccountSet accountSetInExcel =
                        new GetAccountSet().GetAccountSetByName(
                            ds.Tables[0].Rows[i][indexAccountSetName].ToString().Trim());
                    if (accountSetInExcel != null)
                    {
                        //���accountSet�ǿգ���accountSetInExcel��ֵ��accountSet
                        if (accountSet == null)
                        {
                            accountSet = new GetAccountSet().GetWholeAccountSetByPKID(accountSetInExcel.AccountSetID);
                        }
                            //���accountSet���ǿգ��Ƿ��accountSetInExcel������һ�£������һ�£���Ҫ����accountSet,������AccountSet��Ϣ������Merge������ԭ�еĹ̶�ֵ��Ϣ
                        else if (accountSetInExcel.AccountSetID != accountSet.AccountSetID)
                        {
                            accountSet = new GetAccountSet().GetWholeAccountSetByPKID(accountSetInExcel.AccountSetID);
                            if (employeeSalary != null && employeeSalary.AccountSet != null)
                            {
                                //AccountSet��Ϣ������Merge������ԭ�еĹ̶�ֵ��Ϣ
                                MergeAccountSetData(accountSet, employeeSalary.AccountSet);
                            }
                        }
                    }
                }
                if (accountSet == null)
                {
                    continue;
                }

                BindAccountSetData(ds, i, accountSet);
                if (IsEmployeeHaveAccountSet)
                {
                    new UpdateEmployeeAccountSet(account.Id, accountSet, _Operator.Name,
                                                 DateTime.Now,
                                                 EmployeeAccount_DataString).Excute();
                }
                else
                {
                    new CreateEmployeeAccountSet(account.Id, accountSet, _Operator.Name,
                                                 DateTime.Now,
                                                 EmployeeAccount_DataString).Excute();
                }
            }
        }

        private static void MergeAccountSetData(Model.PayModule.AccountSet accountSet, Model.PayModule.AccountSet employeeSalaryAccountSet)
        {
            foreach (AccountSetItem employeeSalaryAccountSetItem in employeeSalaryAccountSet.Items)
            {
                foreach (AccountSetItem accountSetItem in accountSet.Items)
                {
                    if (employeeSalaryAccountSetItem.AccountSetPara.AccountSetParaID ==
                        accountSetItem.AccountSetPara.AccountSetParaID)
                    {
                        accountSetItem.CalculateResult = employeeSalaryAccountSetItem.CalculateResult;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// ��excel�����ݰ󶨵�AccountSet��
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="indexRow"></param>
        /// <param name="accountSet"></param>
        private static void BindAccountSetData(DataSet ds, int indexRow, ModelPayModule.AccountSet accountSet)
        {
            if (accountSet.Items == null)
            {
                return;
            }
            foreach (AccountSetItem item in accountSet.Items)
            {
                if (item.AccountSetPara.FieldAttribute.Id != FieldAttributeEnum.FixedField.Id)
                {
                    continue;
                }
                int indexAccountSetParaName = GetDataSetColumnIndex(ds, item.AccountSetPara.AccountSetParaName);
                if (indexAccountSetParaName == -1)
                {
                    continue;
                }
                decimal data;
                if (decimal.TryParse(ds.Tables[0].Rows[indexRow][indexAccountSetParaName].ToString().Trim(), out data))
                {
                    item.CalculateResult = data;
                }
            }
        }
        /// <summary>
        /// ����Excel 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static DataSet LoadDataFromExcel(string filePath)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 5.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM [EmployeeAccountSet$]";//���Ǹ���Sheet���ƣ�����sheet2���ȵ� 

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                throw new Exception("Excel���ݻ�ȡʧ��!ʧ��ԭ��" + err.Message);
            }
        }

    }
}

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
    /// excel导入员工工资套以及固定值
    /// </summary>
    public class ImportEmployeeAccountSet: Transaction
    {
        private readonly Account _Operator;
        private readonly string _FilePath;
        private readonly IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private const string EmployeeAccount_DataString = "Excel导入员工帐套";
        /// <summary>
        /// 构造函数
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
        /// 更新员工的帐套
        /// </summary>
        /// <param name="ds"></param>
        private void InsertUpdateEmployeeAccountSet(DataSet ds)
        {
            int indexAccountSetName = GetDataSetColumnIndex(ds, "帐套名称");
            int indexEmployeeName = GetDataSetColumnIndex(ds, "员工姓名");
            if (indexEmployeeName == -1)
            {
                throw new Exception("无法找到员工姓名列，请检查excel！");
            }
            //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            //{
                ToInsertUpdateEmployeeAccountSet(ds, indexAccountSetName, indexEmployeeName);
            //    ts.Complete();
            //}
        }

        /// <summary>
        /// 获得columnName在excel中的列Index
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
        /// 开始更新员工的帐套
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
                //有没有当前账号
                Account account =
                    _IAccountBll.GetAccountByName(ds.Tables[0].Rows[i][indexEmployeeName].ToString().Trim());
                if (account == null || !Tools.ContainsAccountById(allAccount, account.Id))
                {
                    continue;
                }
                //当前账号有没有工资套，如果有则给accountSet赋上当前帐套，以便更新
                bool IsEmployeeHaveAccountSet = false;
                EmployeeSalary employeeSalary =
                    new GetEmployeeAccountSet().GetEmployeeAccountSetByEmployeeID(account.Id);
                if (employeeSalary != null && employeeSalary.AccountSet != null)
                {
                    accountSet = employeeSalary.AccountSet;
                    IsEmployeeHaveAccountSet = true;
                }
                //excel是否有帐套名称列，如果有则需要确定是否要更新帐套
                if (indexAccountSetName != -1)
                {
                    ModelPayModule.AccountSet accountSetInExcel =
                        new GetAccountSet().GetAccountSetByName(
                            ds.Tables[0].Rows[i][indexAccountSetName].ToString().Trim());
                    if (accountSetInExcel != null)
                    {
                        //如果accountSet是空，则将accountSetInExcel赋值给accountSet
                        if (accountSet == null)
                        {
                            accountSet = new GetAccountSet().GetWholeAccountSetByPKID(accountSetInExcel.AccountSetID);
                        }
                            //如果accountSet不是空，是否和accountSetInExcel的帐套一致，如果不一致，则要覆盖accountSet,并且做AccountSet信息的数据Merge，保留原有的固定值信息
                        else if (accountSetInExcel.AccountSetID != accountSet.AccountSetID)
                        {
                            accountSet = new GetAccountSet().GetWholeAccountSetByPKID(accountSetInExcel.AccountSetID);
                            if (employeeSalary != null && employeeSalary.AccountSet != null)
                            {
                                //AccountSet信息的数据Merge，保留原有的固定值信息
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
        /// 将excel的数据绑定到AccountSet上
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
        /// 加载Excel 
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
                String sql = "SELECT * FROM [EmployeeAccountSet$]";//可是更改Sheet名称，比如sheet2，等等 

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                throw new Exception("Excel数据获取失败!失败原因：" + err.Message);
            }
        }

    }
}

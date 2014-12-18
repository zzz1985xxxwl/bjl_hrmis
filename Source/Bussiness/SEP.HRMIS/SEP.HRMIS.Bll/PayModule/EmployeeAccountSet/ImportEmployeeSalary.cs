//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ImportEmployeeSalary.cs
// Creater:  Xue.wenlong
// Date:  2008-12-30
// Resume:����Ա������
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.PayModule.EmployeeAccountSet
{
    public class ImportEmployeeSalary : Transaction
    {
        private readonly GetEmployeeAccountSet _IGetEmployeeAccountSet = new GetEmployeeAccountSet();
        private readonly IEmployeeSalary _DalEmployeeSalary = PayModuleDataAccess.CreateEmployeeSarary();
        private readonly string _FilePath;
        private readonly string _BackAccountsName;
        private const string _NameColumn = "Ա������";
        private const string _RemarkName = "��ע";
        private readonly DateTime _SalaryTime;
        private List<EmployeeSalary> _EmployeeSalaryList;
        private readonly int _CompanyId;

        public ImportEmployeeSalary(string filePath, DateTime dt, string backAcountsName, int companyId)
        {
            _FilePath = filePath;
            _BackAccountsName = backAcountsName;
            _SalaryTime = dt;
            _CompanyId = companyId;
        }

        protected override void Validation()
        {
            if (!File.Exists(_FilePath))
            {
                BllUtility.ThrowException(BllExceptionConst._Upload_Failed);
            }
        }

        protected override void ExcuteSelf()
        {
            string strConn;
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _FilePath +
                      ";Extended Properties=\"Excel 8.0;IMEX=1;\"";
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                string sheetName = FirstSheetName(conn);
                OleDbDataAdapter oada = new OleDbDataAdapter("select * from [" + sheetName + "]", strConn);
                DataSet ds = new DataSet();
                oada.Fill(ds);
                Import(ds.Tables[0]);
            }
        }


        private void Import(DataTable dt)
        {
            _EmployeeSalaryList =
                _IGetEmployeeAccountSet.GetEmployeeSalaryByCondition(string.Empty, _SalaryTime, -1, -1, -1,
                                                                     EmployeeTypeEnum.All,_CompanyId);
            InitSalary();
            if (_EmployeeSalaryList != null && _EmployeeSalaryList.Count > 0)
            {
                ValueItemsAndSave(_EmployeeSalaryList, dt);
            }
        }


        /// <summary>
        /// ��ֵ�����棬��dt�е�ֵ��ֵ��salary
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="dt"></param>
        private void ValueItemsAndSave(IEnumerable<EmployeeSalary> salary, DataTable dt)
        {
            foreach (EmployeeSalary employeeSalary in salary)
            {
                //Ա��������dt�е��к�
                int employeeRow = GetEmployeeRow(dt, employeeSalary.Employee.Account.Name);
                //��Ա�������������������һ��
                if (employeeRow == -1)
                {
                    continue;
                }
                EmployeeSalaryHistory salaryHistory = employeeSalary.EmployeeSalaryHistoryList[0];

                //��ֵ��ע
                string description = GetItem(dt, employeeRow, _RemarkName);
                if (description != "EmptyNull")
                {
                    salaryHistory.Description = description;
                }

                if (salaryHistory.EmployeeAccountSet.Items != null)
                {
                    //��һ����¼��ֵ
                    ValueItemInOneRow(dt, salaryHistory, employeeRow); 
                } 
                //���������Ϣ
                SaveEmployeeSalary(employeeSalary.Employee.Account.Id, salaryHistory);
            }
        }

        /// <summary>
        /// ������Ϣ
        /// </summary>
        private void SaveEmployeeSalary(int employeeID, EmployeeSalaryHistory salary)
        {
            _DalEmployeeSalary.ImportEmployeeSalaryHistory(employeeID, salary);
        }

        /// <summary>
        /// ����dt�еĵ�employeeRow�У���dt�еĸ��е�ֵ��ֵ��salaryHistory
        /// </summary>
        private static void ValueItemInOneRow(DataTable dt, EmployeeSalaryHistory salaryHistory, int employeeRow)
        {
            for (int i = 0; i < salaryHistory.EmployeeAccountSet.Items.Count; i++)
            {
                AccountSetItem item = salaryHistory.EmployeeAccountSet.Items[i];
                string answer = GetItem(dt, employeeRow, item.AccountSetPara.AccountSetParaName);
                if (answer != "EmptyNull")
                {
                    if (string.IsNullOrEmpty(answer))
                    {
                        item.CalculateResult = 0;
                    }
                    else
                    {
                        decimal tempdecimal;
                        if (!Decimal.TryParse(answer, out tempdecimal))
                        {
                            throw new ApplicationException(string.Format("���ݣ�{0} ����С��", answer));
                        }
                        else
                        {
                            item.CalculateResult = Convert.ToDecimal(answer);
                        }
                    }
                }
            }
           
        }

        /// <summary>
        /// ���û�м�¼���ʼ��
        /// </summary>
        private void InitSalary()
        {
            if (_EmployeeSalaryList == null || _EmployeeSalaryList.Count == 0)
            {
                new InitialEmployeeSalary(_SalaryTime, _BackAccountsName, string.Empty, _CompanyId,-1).Excute();
                _EmployeeSalaryList =
                    _IGetEmployeeAccountSet.GetEmployeeSalaryByCondition(string.Empty, _SalaryTime, -1, -1, -1,
                                                                         EmployeeTypeEnum.All,_CompanyId);
            }
        }

        /// <summary>
        /// Ա��������dt�е��к�
        /// </summary>
        private static int GetEmployeeRow(DataTable dt, string employeeName)
        {
            int j = GetColumnIndex(dt, _NameColumn);
            if (j == -1)
            {
                BllUtility.ThrowException(BllExceptionConst._WithOut_EmployeeName);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][j].ToString() == employeeName)
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// �õ�ĳ�е�һ��Ԫ��
        /// </summary>
        /// <param name="dt">Ҫ���ĸ�������</param>
        /// <param name="rowID">�ڼ����ң���0��ʼ</param>
        /// <param name="columnName">����</param>
        /// <returns>���ظñ��ָ��������ָ���е����ݣ����򷵻�EmptyNull</returns>
        private static string GetItem(DataTable dt, int rowID, string columnName)
        {
            int j = GetColumnIndex(dt, columnName);
            if (j != -1)
            {
                return dt.Rows[rowID][j].ToString();
            }
            else
            {
                return "EmptyNull";
            }
        }

        /// <summary>
        /// �õ��к�
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>û���򷵻�-1</returns>
        /// <param name="columnName">����</param>
        private static int GetColumnIndex(DataTable dt, string columnName)
        {
            int j = -1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == columnName)
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        /// <summary>
        /// �õ���һ������������������������1���״�
        /// </summary>
        private static string FirstSheetName(OleDbConnection conn)
        {
            DataTable sheetNames = conn.GetOleDbSchemaTable
                (OleDbSchemaGuid.Tables, new object[] {null, null, null, "TABLE"});
            if (sheetNames.Rows.Count != 1)
            {
                BllUtility.ThrowException(BllExceptionConst._Sheet_Count_NotOne);
            }
            return sheetNames.Rows[0][2].ToString();
        }
    }
}
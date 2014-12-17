//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ImportEmployeeWelfare.cs
// Creater:  Xue.wenlong
// Date:  2009-9-27
// Resume:导入福利信息
// ----------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 
    /// </summary>
    public class ImportEmployeeWelfare : Transaction
    {
        private readonly IEmployeeWelfare _DalEmployeeWelfare = DalFactory.DataAccess.CreateEmployeeWelfare();
        private readonly string _FilePath;
        private const string _NameColumn = "姓名";
        private readonly Account _Operator;

        ///<summary>
        ///</summary>
        public ImportEmployeeWelfare(string filePath, Account account)
        {
            _FilePath = filePath;
            _Operator = account;
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
            strConn = ImportUtility.GetstrConn(_FilePath);
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                string sheetName = ImportUtility.FirstSheetName(conn);
                OleDbDataAdapter oada = new OleDbDataAdapter("select * from [" + sheetName + "]", strConn);
                DataSet ds = new DataSet();
                oada.Fill(ds);
                Import(ds.Tables[0]);
            }
        }


        private void Import(DataTable dt)
        {
            List<EmployeeWelfare> employeeWelfarelist = new List<EmployeeWelfare>();
            List<Employee> employeeList =
                new GetEmployee().GetEmployeeBasicInfoByBasicCondition("", EmployeeTypeEnum.All,
                                                                       -1, -1,
                                                                       true, -1);
            employeeList =
                HrmisUtility.RemoteUnAuthEmployee(employeeList, AuthType.HRMIS, _Operator, HrmisPowers.A605);
            if (employeeList != null)
            {
                foreach (Employee employee in employeeList)
                {
                    EmployeeWelfare welfare =
                        _DalEmployeeWelfare.GetEmployeeWelfareByAccountID(employee.Account.Id);
                    if (welfare == null)
                    {
                        welfare = EmployeeWelfare.EmptyWelfare();
                    }
                    welfare.Owner = employee.Account;
                    employeeWelfarelist.Add(welfare);
                }
            }
            ValueItemsAndSave(employeeWelfarelist, dt);
        }


        /// <summary>
        /// 赋值并保存，将dt中的值赋值给salary
        /// </summary>
        private void ValueItemsAndSave(IEnumerable<EmployeeWelfare> employeeWelfare, DataTable dt)
        {
            foreach (EmployeeWelfare welfare in employeeWelfare)
            {
                //员工姓名在dt中的列号
                int employeeRow = ImportUtility.GetEmployeeRow(dt, welfare.Owner.Name, _NameColumn);
                //该员工不存在则继续查找下一个
                if (employeeRow == -1)
                {
                    continue;
                }
                ValueItemInOneRow(employeeRow, dt, welfare);
            }
        }

        private void ValueItemInOneRow(int rowindex, DataTable dt, EmployeeWelfare welfare)
        {
            SocialSecurityTypeEnum socialSecurityType = welfare.SocialSecurity.Type;
            decimal? socialBase = welfare.SocialSecurity.Base;
            decimal? yangLaoBase = welfare.SocialSecurity.YangLaoBase;
            decimal? shiYeBase = welfare.SocialSecurity.ShiYeBase;
            decimal? yiLiaoBase = welfare.SocialSecurity.YiLiaoBase;
            DateTime? socialYM = welfare.SocialSecurity.EffectiveYearMonth;
            string fundAccount = welfare.AccumulationFund.Account;
            DateTime? fundYM = welfare.AccumulationFund.EffectiveYearMonth;
            decimal? fundBase = welfare.AccumulationFund.Base;
            string operationName = _Operator.Name;
            string supplyAccount = welfare.AccumulationFund.SupplyAccount;
            decimal? supplyBase = welfare.AccumulationFund.SupplyBase;

            string SsocialSecurityType = ImportUtility.GetItem(dt, rowindex, EmployeeWelfare.ConstParemeter.SocialType);
            if (SsocialSecurityType != ImportUtility.EmptyNull)
            {
                socialSecurityType = ConvertToSocialSecurityTypeEnum(SsocialSecurityType);
            }

            socialBase = GetDecimal(dt, rowindex, socialBase, EmployeeWelfare.ConstParemeter.SocialBase);
            yangLaoBase = GetDecimal(dt, rowindex, yangLaoBase, EmployeeWelfare.ConstParemeter.YangLaoBase);
            shiYeBase = GetDecimal(dt, rowindex, shiYeBase, EmployeeWelfare.ConstParemeter.ShiYeBase);
            yiLiaoBase = GetDecimal(dt, rowindex, yiLiaoBase, EmployeeWelfare.ConstParemeter.YiLiaoBase);
            socialYM = GetYM(dt, rowindex, socialYM, EmployeeWelfare.ConstParemeter.SocialYM);
            fundAccount = GetString(dt, rowindex, fundAccount, EmployeeWelfare.ConstParemeter.FundAccount);
            fundYM = GetYM(dt, rowindex, fundYM, EmployeeWelfare.ConstParemeter.FundYM);
            fundBase = GetDecimal(dt, rowindex, fundBase, EmployeeWelfare.ConstParemeter.FundBase);
            supplyAccount = GetString(dt, rowindex, supplyAccount, EmployeeWelfare.ConstParemeter.SupplyAccount);
            supplyBase = GetDecimal(dt, rowindex, supplyBase, EmployeeWelfare.ConstParemeter.SupplyBase);

            SaveEmployeeWelfare saveEmployeeWelfare =
                new SaveEmployeeWelfare(welfare.Owner.Id, socialSecurityType, socialBase, socialYM, fundAccount,
                                        fundYM, fundBase, operationName,
                                        supplyAccount, supplyBase, yangLaoBase, shiYeBase, yiLiaoBase);
            saveEmployeeWelfare.Excute();
        }

        private static string GetString(DataTable dt, int rowindex, string ret, string columnnanme)
        {
            string SS = ImportUtility.GetItem(dt, rowindex, columnnanme);
            if (SS != ImportUtility.EmptyNull)
            {
                ret = SS;
            }
            return ret;
        }

        private static DateTime? GetYM(DataTable dt, int rowindex, DateTime? ret, string columnname)
        {
            string SYM = ImportUtility.GetItem(dt, rowindex, columnname);
            if (SYM != ImportUtility.EmptyNull)
            {
                ret = ConvertToDateTime(SYM);
            }
            return ret;
        }

        private static decimal? GetDecimal(DataTable dt, int rowindex, decimal? ret, string columnname)
        {
            string SD = ImportUtility.GetItem(dt, rowindex, columnname);
            if (SD != ImportUtility.EmptyNull)
            {
                ret = ConvertToDecimal(SD);
            }
            return ret;
        }

        private static decimal? ConvertToDecimal(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                decimal temp;
                if (!decimal.TryParse(s, out temp))
                {
                    throw new ApplicationException(string.Format("数据：{0} 格式错误", s));
                }
            }
            return EmployeeWelfare.ConvertToDecimal(s);
        }

        private static SocialSecurityTypeEnum ConvertToSocialSecurityTypeEnum(string s)
        {
            if(!string.IsNullOrEmpty(s))
            {
                if (SocialSecurityTypeEnum.GetByName(s) == null)
                {
                    throw new ApplicationException(string.Format("数据：{0} 不是有效的社保类型", s));
                }
            }
            return SocialSecurityTypeEnum.GetByName(s);
           
        }

        private static DateTime? ConvertToDateTime(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                DateTime temp;
                if (!DateTime.TryParse(s, out temp))
                {
                    throw new ApplicationException(string.Format("数据：{0} 格式错误", s));
                }
            }
            return EmployeeWelfare.ConvertToDateTime(s);
        }
    }
}
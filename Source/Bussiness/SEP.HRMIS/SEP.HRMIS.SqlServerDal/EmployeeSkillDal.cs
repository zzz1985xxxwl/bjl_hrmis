//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillDal.cs
// 创建者: 刘丹
// 创建日期: 2008-10-17
// 概述: 实现IEmployeeSkill
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using SEP.HRMIS.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal
{
    public class EmployeeSkillDal : IEmployeeSkill
    {
        private readonly EmployeeDal _EmployeeDal = new EmployeeDal();

        #region const
        private const string _PKID = "@PKID";
        private const string _AccountID = "@AccountID";
        private const string _SkillID = "@SkillID";
        private const string _SkillName = "@SkillName";
        private const string _SkillRank = "@SkillRank";
        private const string _Score = "@Score";
        private const string _Remark = "@Remark";

        private const string _DBPKID = "PKID";
        //private const string _DBAccountID = "EmployeeID";
        private const string _DBSkillID = "SkillID";
        private const string _DBSkillName = "SkillName";
        private const string _DBSkillRank = "SkillRank";
        private const string _DBSkillTypeName = "SkillTypeName";
        private const string _DBSkillTypeId = "SkillTypeId";
        private const string _DbCount = "Counts";
        private const string _DbScore = "Score";
        private const string _DbRemark = "Remark";
        private readonly int _retVal = -1;

        private const string _DbError = "数据库访问错误!";
        #endregion

        public void InsertEmployeeSkill(Employee employeeSkill)
        {
            if (employeeSkill.EmployeeSkills == null)
            {
                employeeSkill.EmployeeSkills = new List<EmployeeSkill>();
            }
            try
            {
                foreach (EmployeeSkill skill in employeeSkill.EmployeeSkills)
                {
                    skill.EmpSkillID = EmployeeSkillInsert(employeeSkill.Account.Id, skill);
                }
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public void UpdateEmployeeSkill(Employee employeeSkill)
        {
            if (employeeSkill.EmployeeSkills == null)
            {
                employeeSkill.EmployeeSkills = new List<EmployeeSkill>();
            }
            try
            {
                DeleteEmployeeSkill(employeeSkill.Account.Id);
                InsertEmployeeSkill(employeeSkill);
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        private void DeleteEmployeeSkill(int accountID)
        {
            try
            {
                EmployeeSkillDelete(accountID);
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public Employee GetEmployeeSkillByAccountID(int accountID, string skillName, int skillTypeID,
                                                     SkillLevelEnum skillLevel)
        {
            Employee employee = _EmployeeDal.GetEmployeeBasicInfoByAccountID(accountID);

            employee.EmployeeSkills = GetEmployeeSkills(accountID, skillName, skillTypeID,
                                                        skillLevel);
            return employee;
        }

        public int CountEmployeeSkillBySkillID(int skillID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SkillID, SqlDbType.Int).Value = skillID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountEmployeeSkillBySkillID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        private static int EmployeeSkillInsert(int employeeId, EmployeeSkill skill)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = employeeId;
            cmd.Parameters.Add(_SkillName, SqlDbType.NVarChar, 100).Value = skill.Skill.SkillName;
            cmd.Parameters.Add(_SkillID, SqlDbType.Int).Value = skill.Skill.SkillID;
            cmd.Parameters.Add(_SkillRank, SqlDbType.Int).Value = skill.SkillLevel;
            cmd.Parameters.Add(_Score, SqlDbType.Decimal).Value = skill.Score;
            cmd.Parameters.Add(_Remark, SqlDbType.Text).Value = skill.Remark;
            SqlHelper.ExecuteNonQueryReturnPKID("EmployeeSkillInsert", cmd, out pkid);
            return pkid;
        }

        private static void EmployeeSkillDelete(int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            SqlHelper.ExecuteNonQuery("DeleteEmployeeSkillByAccountID", cmd);
        }

        private static void Log(Employee employeeSkill)
        {
            string logFilePath = HttpContext.Current.Server.MapPath("~/Log");
            if (!Directory.Exists(logFilePath))
            {
                Directory.CreateDirectory(logFilePath);
            }

            var sbError = new StringBuilder();
            sbError.Append("更新技能 accountID：" + employeeSkill.Account.Id + Environment.NewLine);
            sbError.Append("技能：" + Framework.Common.JsonHelper.ObjectToJson(employeeSkill.EmployeeSkills) + Environment.NewLine);
            sbError.Append("time：" + DateTime.Now + Environment.NewLine);
            sbError.Append("==============================================================");

            // 将错误记录到日志中
            string logFile = Path.Combine(logFilePath, DateTime.Now.ToString("yyyyMMdd") + ".log");
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(logFile, true);
                writer.WriteLine(sbError.ToString());
            }
            catch
            {
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        private static List<EmployeeSkill> GetEmployeeSkills(int accountID, string skillName, int skillTypeID,
                                                     SkillLevelEnum skillLevel)
        {
            List<EmployeeSkill> skills = new List<EmployeeSkill>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            cmd.Parameters.Add(_SkillName, SqlDbType.NVarChar, 100).Value = skillName;
            cmd.Parameters.Add(_SkillID, SqlDbType.Int).Value = skillTypeID;
            cmd.Parameters.Add(_SkillRank, SqlDbType.Int).Value = skillLevel;
            using (
     SqlDataReader sdr =
         SqlHelper.ExecuteReader("GetEmployeeSkillByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    SkillType type = new SkillType(Convert.ToInt32(sdr[_DBSkillTypeId]), sdr[_DBSkillTypeName].ToString());
                    Skill skill = new Skill(Convert.ToInt32(sdr[_DBSkillID]), sdr[_DBSkillName].ToString(), type);
                    EmployeeSkill employeeSkill =
                        new EmployeeSkill(skill, (SkillLevelEnum)(sdr[_DBSkillRank]));
                    employeeSkill.EmpSkillID = Convert.ToInt32(sdr[_DBPKID]);
                    employeeSkill.Score = Convert.ToDecimal(sdr[_DbScore]);
                    employeeSkill.Remark = sdr[_DbRemark].ToString();
                    skills.Add(employeeSkill);
                }
            }
            return skills;
        }
    }
}

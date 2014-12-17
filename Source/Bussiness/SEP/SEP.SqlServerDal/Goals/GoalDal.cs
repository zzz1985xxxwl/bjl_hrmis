//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: GoalDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 目标持久层实现
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.IDal.Goals;
using SEP.Model.Accounts;
using SEP.Model.Goals;
using SEP.Model.Departments;

namespace SEP.SqlServerDal
{
    public class GoalDal : IGoalDal
    {
        private readonly int _retVal = -1;
        private const string _GoalID = "@PKID";
        private const string _SetHostID = "@SetHostID";
        private const string _SetHostName = "@SetHostName";
        private const string _Title = "@Title";
        private const string _Content = "@Content";
        private const string _SetTime = "@SetTime";
        private const string _GoalType = "@GoalType";
        private const string _DbGoalID = "PKID";
        private const string _DbSetHostID = "SetHostID";
        private const string _DbSetHostName = "SetHostName";
        private const string _DbTitle = "Title";
        private const string _DbContent = "Content";
        private const string _DbSetTime = "SetTime";
        private const string _DbGoalType = "GoalType";
        private const string _DbCount = "Counts";

        /// <summary>
        /// 新增个人目标
        /// </summary>
        /// <param name="personalGoal"></param>
        /// <returns></returns>
        public int InsertPersonalGoal(PersonalGoal personalGoal)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = personalGoal.Account.Id;
            cmd.Parameters.Add(_SetHostName, SqlDbType.NVarChar, 50).Value = personalGoal.Account.Name;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = personalGoal.Title;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = personalGoal.Content;
            cmd.Parameters.Add(_SetTime, SqlDbType.DateTime).Value = personalGoal.SetTime;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.PersonalGoal);

            SqlHelper.ExecuteNonQueryReturnPKID("GoalInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 新增团队目标
        /// </summary>
        /// <param name="teamGoal"></param>
        /// <returns></returns>
        public int InsertTeamGoal(TeamGoal teamGoal)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = teamGoal.Dept.Id;
            cmd.Parameters.Add(_SetHostName, SqlDbType.NVarChar, 50).Value = teamGoal.Dept.Name;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = teamGoal.Title;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = teamGoal.Content;
            cmd.Parameters.Add(_SetTime, SqlDbType.DateTime).Value = teamGoal.SetTime;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.TeamGoal);

            SqlHelper.ExecuteNonQueryReturnPKID("GoalInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 新增公司目标
        /// </summary>
        /// <param name="companyGoal"></param>
        /// <returns></returns>
        public int InsertCompanyGoal(CompanyGoal companyGoal)
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = 0;
            cmd.Parameters.Add(_SetHostName, SqlDbType.NVarChar, 50).Value = "";
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = companyGoal.Title;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = companyGoal.Content;
            cmd.Parameters.Add(_SetTime, SqlDbType.DateTime).Value = companyGoal.SetTime;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.CompanyGoal);

            SqlHelper.ExecuteNonQueryReturnPKID("GoalInsert", cmd, out pkid);
            return pkid;
        }

        /// <summary>
        /// 更新个人目标
        /// </summary>
        /// <param name="personalGoal"></param>
        /// <returns></returns>
        public int UpdatePersonalGoal(PersonalGoal personalGoal)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = personalGoal.Id;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = personalGoal.Account.Id;
            cmd.Parameters.Add(_SetHostName, SqlDbType.NVarChar, 50).Value = personalGoal.Account.Name;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = personalGoal.Title;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = personalGoal.Content;
            cmd.Parameters.Add(_SetTime, SqlDbType.DateTime).Value = personalGoal.SetTime;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.PersonalGoal);

            return SqlHelper.ExecuteNonQuery("GoalUpdate", cmd);
        }

        /// <summary>
        /// 更新公司目标
        /// </summary>
        /// <param name="teamGoal"></param>
        /// <returns></returns>
        public int UpdateTeamGoal(TeamGoal teamGoal)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = teamGoal.Id;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = teamGoal.Dept.Id;
            cmd.Parameters.Add(_SetHostName, SqlDbType.NVarChar, 50).Value = teamGoal.Dept.Name;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = teamGoal.Title;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = teamGoal.Content;
            cmd.Parameters.Add(_SetTime, SqlDbType.DateTime).Value = teamGoal.SetTime;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.TeamGoal);

            return SqlHelper.ExecuteNonQuery("GoalUpdate", cmd);
        }

        /// <summary>
        /// 更新公司目标
        /// </summary>
        /// <param name="companyGoal"></param>
        /// <returns></returns>
        public int UpdateCompanyGoal(CompanyGoal companyGoal)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = companyGoal.Id;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = 0;
            cmd.Parameters.Add(_SetHostName, SqlDbType.NVarChar, 50).Value = "";
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = companyGoal.Title;
            cmd.Parameters.Add(_Content, SqlDbType.Text).Value = companyGoal.Content;
            cmd.Parameters.Add(_SetTime, SqlDbType.DateTime).Value = companyGoal.SetTime;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.CompanyGoal);

            return SqlHelper.ExecuteNonQuery("GoalUpdate", cmd);
        }

        /// <summary>
        /// 新增时查找同一个员工中同标题的个人目标
        /// </summary>
        /// <param name="hostID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetPersonalGoalCountByTitle(int hostID, string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.PersonalGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalCountByTitle", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        /// <summary>
        /// 修改时查找同一个员工中同标题的个人目标
        /// </summary>
        /// <param name="pKID"></param>
        /// <param name="hostID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetPersonalGoalCountByTitleDiffPKID(int pKID, int hostID, string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = pKID;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.PersonalGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalCountByTitleDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }

        /// <summary>
        /// 新增时查找同一个部门中同标题的团队目标
        /// </summary>
        /// <param name="hostID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetTeamGoalCountByTitle(int hostID, string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.TeamGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalCountByTitle", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
        /// <summary>
        /// 修改时查找同一个部门中同标题的团队目标
        /// </summary>
        /// <param name="pKID"></param>
        /// <param name="hostID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetTeamGoalCountByTitleDiffPKID(int pKID, int hostID, string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = pKID;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.TeamGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalCountByTitleDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
        /// <summary>
        /// 新增时查找公司中同标题的公司目标
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetCompanyGoalCountByTitle(string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = 0;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.CompanyGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalCountByTitle", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
        /// <summary>
        /// 修改时查找公司中同标题的公司目标
        /// </summary>
        /// <param name="pKID"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetCompanyGoalCountByTitleDiffPKID(int pKID, string title)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = pKID;
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = 0;
            cmd.Parameters.Add(_Title, SqlDbType.NVarChar, 50).Value = title;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.CompanyGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalCountByTitleDiffPKID", cmd))
            {
                while (sdr.Read())
                {
                    return Convert.ToInt32(sdr[_DbCount]);
                }
            }
            return _retVal;
        }
        /// <summary>
        /// 根据PKID删除目标
        /// </summary>
        /// <param name="goalID"></param>
        /// <returns></returns>
        public int DeleteGoalByPKID(int goalID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = goalID;
            return SqlHelper.ExecuteNonQuery("DeleteGoalByPKID", cmd);

        }
        /// <summary>
        /// 删除全部的公司目标
        /// </summary>
        /// <returns></returns>
        //public int DeleteCompanyGoalBySetHostID()
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = -1;
        //    cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.CompanyGoal);
        //    return SqlHelper.ExecuteNonQuery("DeleteGoalBySetHostID", cmd);
        //}

        /// <summary>
        /// 根据员工ID删除全部的个人目标
        /// </summary>
        /// <param name="setHostID"></param>
        /// <returns></returns>
        public int DeletePersonalGoalBySetHostID(int setHostID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = setHostID;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.PersonalGoal);
            return SqlHelper.ExecuteNonQuery("DeleteGoalBySetHostID", cmd);
        }
        /// <summary>
        /// 根据部门ID删除全部的团队目标
        /// </summary>
        /// <param name="setHostID"></param>
        /// <returns></returns>
        public int DeleteTeamGoalBySetHostID(int setHostID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = setHostID;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.TeamGoal);
            return SqlHelper.ExecuteNonQuery("DeleteGoalBySetHostID", cmd);
        }
        /// <summary>
        /// 根据PKID查找目标
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public Goal GetGoalByPKID(int pkid)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_GoalID, SqlDbType.Int).Value = pkid;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalByPKID", cmd))
            {
                while (sdr.Read())
                {
                    int goalID = Convert.ToInt32(sdr[_DbGoalID]);
                    string title = sdr[_DbTitle].ToString();
                    string content = sdr[_DbContent].ToString();
                    DateTime setTime = Convert.ToDateTime(sdr[_DbSetTime]);
                    int setHostID = Convert.ToInt32(sdr[_DbSetHostID]);
                    string setHostName = sdr[_DbSetHostName].ToString();

                    switch ((GoalType)sdr[_DbGoalType])
                    {
                        case GoalType.PersonalGoal:
                            Account employee = new Account();
                            employee.Name = setHostName;
                            employee.Id = setHostID;
                            PersonalGoal personalGoal = 
                                new PersonalGoal(goalID,title ,content, setTime, employee);
                            return personalGoal;
                        case GoalType.TeamGoal:
                            Department department = new Department(setHostID, setHostName);
                            TeamGoal teamGoal =
                                new TeamGoal(goalID, title, content, setTime, department);
                            return teamGoal;
                        case GoalType.CompanyGoal:
                            CompanyGoal companyGoal =
                                new CompanyGoal(goalID, title, content, setTime);
                            return companyGoal;
                    }
                }
            }
            return null;
        }
        public List<CompanyGoal> GetCompanyGoal()
        {
            List<CompanyGoal> companyGoalList = new List<CompanyGoal>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = 0;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.CompanyGoal);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalBySetHostID", cmd))
            {
                while (sdr.Read())
                {
                    int goalID = Convert.ToInt32(sdr[_DbGoalID]);
                    string title = sdr[_DbTitle].ToString();
                    string content = sdr[_DbContent].ToString();
                    DateTime setTime = Convert.ToDateTime(sdr[_DbSetTime]);

                    CompanyGoal companyGoal =
                        new CompanyGoal(goalID, title, content, setTime);
                    companyGoalList.Add(companyGoal);
                }
            }
            return companyGoalList;
        }
        public List<PersonalGoal> GetPersonalGoalBySetHostID(int hostID)
        {
            List<PersonalGoal> personalGoalList = new List<PersonalGoal>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.PersonalGoal);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalBySetHostID", cmd))
            {
                while (sdr.Read())
                {
                    int goalID = Convert.ToInt32(sdr[_DbGoalID]);
                    string title = sdr[_DbTitle].ToString();
                    string content = sdr[_DbContent].ToString();
                    DateTime setTime = Convert.ToDateTime(sdr[_DbSetTime]);
                    int setHostID = Convert.ToInt32(sdr[_DbSetHostID]);
                    string setHostName = sdr[_DbSetHostName].ToString();

                    Account employee = new Account();
                    employee.Name = setHostName;
                    employee.Id = setHostID;
                    PersonalGoal personalGoal =
                        new PersonalGoal(goalID, title, content, setTime, employee);

                    personalGoalList.Add(personalGoal);
                }
            }
            return personalGoalList;
        }
        public List<TeamGoal> GetTeamGoalBySetHostID(int hostID)
        {
            List<TeamGoal> teamGoalList = new List<TeamGoal>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.TeamGoal);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetGoalBySetHostID", cmd))
            {
                while (sdr.Read())
                {
                    int goalID = Convert.ToInt32(sdr[_DbGoalID]);
                    string title = sdr[_DbTitle].ToString();
                    string content = sdr[_DbContent].ToString();
                    DateTime setTime = Convert.ToDateTime(sdr[_DbSetTime]);
                    int setHostID = Convert.ToInt32(sdr[_DbSetHostID]);
                    string setHostName = sdr[_DbSetHostName].ToString();

                    Department department = new Department(setHostID, setHostName);
                    TeamGoal teamGoal =
                        new TeamGoal(goalID, title, content, setTime, department);
                    teamGoalList.Add(teamGoal);
                }
            }
            return teamGoalList;
        }
        public CompanyGoal GetLastCompanyGoal()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = 0;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.CompanyGoal);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastGoalBySetHostID", cmd))
            {
                while (sdr.Read())
                {
                    int goalID = Convert.ToInt32(sdr[_DbGoalID]);
                    string title = sdr[_DbTitle].ToString();
                    string content = sdr[_DbContent].ToString();
                    DateTime setTime = Convert.ToDateTime(sdr[_DbSetTime]);

                    CompanyGoal companyGoal =
                        new CompanyGoal(goalID, title, content, setTime);
                    return companyGoal;
                }
            }
            return null;
        }
        public PersonalGoal GetLastPersonalGoalBySetHostID(int hostID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.PersonalGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastGoalBySetHostID", cmd))
            {
                while (sdr.Read())
                {
                    int goalID = Convert.ToInt32(sdr[_DbGoalID]);
                    string title = sdr[_DbTitle].ToString();
                    string content = sdr[_DbContent].ToString();
                    DateTime setTime = Convert.ToDateTime(sdr[_DbSetTime]);
                    int setHostID = Convert.ToInt32(sdr[_DbSetHostID]);
                    string setHostName = sdr[_DbSetHostName].ToString();

                    Account employee = new Account();
                    employee.Name = setHostName;
                    employee.Id = setHostID;
                    PersonalGoal personalGoal =
                        new PersonalGoal(goalID, title, content, setTime, employee);
                    return personalGoal;
                }
            }
            return null;
        }
        public TeamGoal GetLastTeamGoalBySetHostID(int hostID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_SetHostID, SqlDbType.Int).Value = hostID;
            cmd.Parameters.Add(_GoalType, SqlDbType.Int).Value = Convert.ToInt32(GoalType.TeamGoal);

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLastGoalBySetHostID", cmd))
            {
                while (sdr.Read())
                {
                    int goalID = Convert.ToInt32(sdr[_DbGoalID]);
                    string title = sdr[_DbTitle].ToString();
                    string content = sdr[_DbContent].ToString();
                    DateTime setTime = Convert.ToDateTime(sdr[_DbSetTime]);
                    int setHostID = Convert.ToInt32(sdr[_DbSetHostID]);
                    string setHostName = sdr[_DbSetHostName].ToString();

                    Department department = new Department(setHostID, setHostName);
                    TeamGoal teamGoal =
                        new TeamGoal(goalID, title, content, setTime, department);
                    return teamGoal;
                }
            }
            return null;
        }

    }
}

//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContactDA.cs
// 创建者: Emma，张珍
// 创建日期: 2008-12-01
// 概述: 电话本数据库访问类
// ----------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlClient;
using ComService.IDALayer;
using ComService.ServiceModels;

namespace ComService.DALayer.Impls.SqlServer
{
    public class ContactDA : IContactDA
    {
        #region 私有常量

        private const string param_LinkmanId  = "@LinkmanId";
        private const string param_SysNo      = "@SysNo";
        private const string param_UserId     = "@UserId";
        private const string param_ComapnyId = "@ComapnyId";
        private const string param_Name       = "@Name";
        private const string param_IndexKey   = "@IndexKey";
        private const string param_IsExternal = "@IsExternal";

        private const string field_LinkmanId  = "LinkmanId";
        //private const string field_SysNo      = "SysNo";
        //private const string field_UserId     = "UserId";
        private const string field_Name       = "Name";
        //private const string field_IndexKey   = "IndexKey";
        //private const string field_ComapnyId = "ComapnyId";

        private const string param_DetailId   = "@DetailId";
        private const string param_Type       = "@Type";
        private const string param_Value      = "@Value";
        private const string param_IsDefault  = "@IsDefault";

        private const string field_DetailId   = "DetailId";
        private const string field_Type       = "Type";
        private const string field_Value      = "Value";
        private const string field_IsDefault  = "IsDefault";

        private const string param_ReturnValue = "@ReturnValue";
        private const string _DbError = "数据库访问错误";

        #endregion

        #region IContactDA 成员

        public void AddLinkman(string sysNo, int userId,int companyId, Linkman linkman)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(param_SysNo,     SqlDbType.NVarChar, 255   ).Value = sysNo;
                cmd.Parameters.Add(param_UserId,    SqlDbType.Int             ).Value = userId;
                cmd.Parameters.Add(param_ComapnyId, SqlDbType.Int).Value = companyId;
                cmd.Parameters.Add(param_LinkmanId, SqlDbType.UniqueIdentifier).Value = linkman.Id;
                cmd.Parameters.Add(param_Name,      SqlDbType.NVarChar, 255   ).Value = linkman.Name;
                if (String.IsNullOrEmpty(linkman.IndexKey))
                    cmd.Parameters.Add(param_IndexKey, SqlDbType.Char, 1).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(param_IndexKey, SqlDbType.Char, 1).Value = linkman.IndexKey;

                SqlParameter sqlParam = new SqlParameter(param_ReturnValue, SqlDbType.Int);
                sqlParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(sqlParam);

                if (linkman.Details.Count > 0)
                {
                    foreach (LinkmanDetail linkmanDetail in linkman.Details)
                    {
                        AddLinkmanDetail(linkman.Id, linkmanDetail);
                    }
                }
                SqlHelper.ExecuteNonQuery("InsertLinkman", cmd);
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }
        }

        public void UpdateLinkman(Linkman linkman)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(param_LinkmanId,    SqlDbType.UniqueIdentifier).Value = linkman.Id;
                cmd.Parameters.Add(param_Name,         SqlDbType.NVarChar, 255).Value = linkman.Name;
                if (String.IsNullOrEmpty(linkman.IndexKey))
                    cmd.Parameters.Add(param_IndexKey, SqlDbType.Char, 1).Value = DBNull.Value;
                else
                    cmd.Parameters.Add(param_IndexKey, SqlDbType.Char, 1).Value = linkman.IndexKey;

                SqlParameter sqlParam = new SqlParameter(param_ReturnValue, SqlDbType.Int);
                sqlParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(sqlParam);

                if (linkman.Details != null)
                {
                    foreach (LinkmanDetail linkmanDetail in linkman.Details)
                    {
                        UpdateLinkmanDetail(linkmanDetail);
                    }
                }
                SqlHelper.ExecuteNonQuery("UpdateLinkman", cmd);
            }
            catch
            {
                throw new ApplicationException(_DbError);
            }

        }

        public void DeleteLinkman(Guid linkmanId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(param_LinkmanId, SqlDbType.UniqueIdentifier).Value = linkmanId;

            SqlParameter sqlParam = new SqlParameter(param_ReturnValue, SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(sqlParam);
            
            SqlHelper.ExecuteNonQuery("DeleteLinkman", cmd);
        }

        public void AddLinkmanDetail(Guid linkmanId, LinkmanDetail linkmanDetail)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(param_LinkmanId, SqlDbType.UniqueIdentifier).Value = linkmanId;
            cmd.Parameters.Add(param_DetailId,  SqlDbType.UniqueIdentifier).Value = linkmanDetail.Id;
            cmd.Parameters.Add(param_Type,      SqlDbType.Int).Value = linkmanDetail.Type;

            if (String.IsNullOrEmpty(linkmanDetail.Value))
                cmd.Parameters.Add(param_Value, SqlDbType.NVarChar, 255).Value = DBNull.Value;
            else
                cmd.Parameters.Add(param_Value, SqlDbType.NVarChar, 255).Value = linkmanDetail.Value;

            cmd.Parameters.Add(param_IsDefault, SqlDbType.Bit).Value = linkmanDetail.IsDefault;

            SqlParameter sqlParam = new SqlParameter(param_ReturnValue, SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(sqlParam);

            SqlHelper.ExecuteNonQuery("InsertLinkmanDetail", cmd);
        }

        public void UpdateLinkmanDetail(LinkmanDetail linkmanDetail)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(param_DetailId,  SqlDbType.UniqueIdentifier).Value = linkmanDetail.Id;
            cmd.Parameters.Add(param_Type,      SqlDbType.Int).Value = (Int32)linkmanDetail.Type;
            if (String.IsNullOrEmpty(linkmanDetail.Value))
                cmd.Parameters.Add(param_Value, SqlDbType.NVarChar, 255).Value = DBNull.Value;
            else
                cmd.Parameters.Add(param_Value, SqlDbType.NVarChar, 255).Value = linkmanDetail.Value;

            cmd.Parameters.Add(param_IsDefault, SqlDbType.Bit).Value = linkmanDetail.IsDefault;

            SqlParameter sqlParam = new SqlParameter(param_ReturnValue, SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(sqlParam);

            SqlHelper.ExecuteNonQuery("UpdateLinkmanDetail", cmd);
        }

        public void DeleteLinkmanDetail(Guid linkmanDetailId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(param_DetailId, SqlDbType.UniqueIdentifier).Value = linkmanDetailId;

            SqlParameter sqlParam = new SqlParameter(param_ReturnValue, SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(sqlParam);

            SqlHelper.ExecuteNonQuery("DeleteLinkmanDetail", cmd);
        }

        public void DeleteContact(string sysNo, int userId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(param_SysNo,  SqlDbType.NVarChar, 255).Value = sysNo;
            cmd.Parameters.Add(param_UserId, SqlDbType.Int).Value = userId;

            SqlParameter sqlParam = new SqlParameter(param_ReturnValue, SqlDbType.Int);
            sqlParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(sqlParam);

            SqlHelper.ExecuteNonQuery("DeleteContact", cmd);
        }

        public Contact GetAllLinkmans(string sysNo, int userId,int companyId, bool isExternal)
        {
            return GetLinkmansByCondition(sysNo, userId, null, null, companyId, isExternal);
        }

        public Contact GetLinkmansByName(string sysNo, int userId, string name, int companyId, bool isExternal)
        {
            return GetLinkmansByCondition(sysNo, userId, name, null, companyId, isExternal);
        }

        public Contact GetAllLinkmansByIndexKey(string sysNo, int userId, int companyId, string indexKey, bool isExternal)
        {
            return GetLinkmansByCondition(sysNo, userId, null, indexKey, companyId, isExternal);
        }

        public Contact GetLinkman(string sysNo, int userId, int companyId, Guid linkmanId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(param_LinkmanId, SqlDbType.UniqueIdentifier).Value = linkmanId;

            Contact contact = new Contact(sysNo,userId);
            Linkman linkman = null;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLinkman", cmd))
            {
                while (sdr.Read())
                {
                    if (linkman == null)
                    {
                        linkman = new Linkman(linkmanId);
                        linkman.Name = sdr[field_Name].ToString();

                        contact.Linkmans.Add(linkman);
                    }

                    if(sdr[field_DetailId] == DBNull.Value || sdr[field_DetailId] == null)
                        continue;

                    LinkmanDetail detail = new LinkmanDetail((Guid)sdr[field_DetailId], (InfoType)sdr[field_Type]);
                    detail.IsDefault = (bool)sdr[field_IsDefault];
                    detail.Value = sdr[field_Value] == DBNull.Value ? null : sdr[field_Value].ToString();

                    linkman.Details.Add(detail);
                }
            }
            return contact;
        }

        #endregion

        private Contact GetLinkmansByCondition(string sysNo, int userId, string name, string indexKey, int companyId, bool isExternal)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(param_SysNo, SqlDbType.NVarChar, 255).Value = sysNo;
            cmd.Parameters.Add(param_UserId, SqlDbType.Int).Value = userId;
            cmd.Parameters.Add(param_ComapnyId, SqlDbType.Int).Value = companyId;
            cmd.Parameters.Add(param_IsExternal, SqlDbType.Bit).Value = isExternal;

            if (String.IsNullOrEmpty(name))
            {
                cmd.Parameters.Add(param_Name, SqlDbType.NVarChar, 255).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(param_Name, SqlDbType.NVarChar, 255).Value = name;
            }

            if (String.IsNullOrEmpty(indexKey))
            {
                cmd.Parameters.Add(param_IndexKey, SqlDbType.Char, 1).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(param_IndexKey, SqlDbType.Char, 1).Value = indexKey;
            }

            Contact contact = new Contact(sysNo, userId);
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetLinkmansByCondition", cmd))
            {
                while (sdr.Read())
                {
                    Guid linkmanId = (Guid)sdr[field_LinkmanId];
                    Linkman linkman;

                    if (!contact.Contains(linkmanId))
                    {
                        linkman = new Linkman(linkmanId);
                        contact.Linkmans.Add(linkman);
                    }
                    else
                    {
                        linkman = contact.GetLinkmanById(linkmanId);
                    }

                    linkman.Name = sdr[field_Name].ToString();

                    if(!isExternal)
                        continue;

                    if (sdr[field_DetailId] == DBNull.Value || sdr[field_DetailId] == null)
                        continue;

                    LinkmanDetail detail = new LinkmanDetail((Guid)sdr[field_DetailId], (InfoType)sdr[field_Type]);
                    detail.IsDefault = (bool)sdr[field_IsDefault];
                    detail.Value = sdr[field_Value].ToString();

                    linkman.Details.Add(detail);
                }
            }
            return contact;
        }
    }
}

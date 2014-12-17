//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: FileCargo.cs
// 创建者: 杨俞彬
// 创建日期: 2008-08-26
// 概述: 档案,包括劳动手册类的文档都存于此
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 档案
    /// </summary>
    [Serializable]
    public class FileCargo
    {
        private FileCargoName _Name;
        private string _Remark;
        private string _File;
        private int _FileCargoID;
        private Account _Account;

        /// <summary>
        /// 档案构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="remark"></param>
        public FileCargo(FileCargoName name, string remark)
        {
            FileCargoID = GetHashCode();
            _Name = name;
            _Remark = remark;
        }

        /// <summary>
        /// 档案构造函数
        /// </summary>
        public FileCargo(int fileCargoID ,FileCargoName name, string remark,string file,Account account)
        {
            _Name = name;
            _Remark = remark;
            File = file;
            Account = account;
            FileCargoID = fileCargoID;
        }

        /// <summary>
        /// 档案资料
        /// </summary>
        public FileCargoName Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value; 
            }
        }

        /// <summary>
        /// 档案资料备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }
        /// <summary>
        /// 档案存放路径
        /// </summary>
        public string File
        {
            get { return _File; }
            set { _File = value; }
        }
        /// <summary>
        /// 档案所有人
        /// </summary>
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
        }
        /// <summary>
        /// id
        /// </summary>
        public int FileCargoID
        {
            get { return _FileCargoID; }
            set { _FileCargoID = value; }
        }

        /// <summary>
        /// 是否可以下载
        /// </summary>
        public bool CanDownLoad
        {
            get
            {
                return System.IO.File.Exists(File);
            }
           
        }
        #region 方法
        /// <summary>
        /// 重写Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            FileCargo anOtherObj = obj as FileCargo;
            if (anOtherObj == null)
            {
                return false;
            }
            return _Name.Equals(anOtherObj._Name) &&
                   _Remark.Equals(anOtherObj._Remark);
        }
      


        #endregion
    }
}

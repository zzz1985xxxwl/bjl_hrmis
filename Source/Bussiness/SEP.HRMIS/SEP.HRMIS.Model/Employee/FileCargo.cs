//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: FileCargo.cs
// ������: �����
// ��������: 2008-08-26
// ����: ����,�����Ͷ��ֲ�����ĵ������ڴ�
// ----------------------------------------------------------------

using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ����
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
        /// �������캯��
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
        /// �������캯��
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
        /// ��������
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
        /// �������ϱ�ע
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
        /// �������·��
        /// </summary>
        public string File
        {
            get { return _File; }
            set { _File = value; }
        }
        /// <summary>
        /// ����������
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
        /// �Ƿ��������
        /// </summary>
        public bool CanDownLoad
        {
            get
            {
                return System.IO.File.Exists(File);
            }
           
        }
        #region ����
        /// <summary>
        /// ��дEquals
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

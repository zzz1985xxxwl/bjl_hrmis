//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ContractType.cs
// ������: Ѧ����
// ��������: 2008-11-17
// ����: ��ͬ����
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��ͬ����
    /// </summary>
    [Serializable]
    public class ContractType 
    {
        private byte[] _ContractTemplate;
        private int _ContractTypeID;
        private string _ContractTypeName;
        /// <summary>
        /// ��ͬ���캯��
        /// </summary>
        /// <param name="contractTypeID"></param>
        /// <param name="contractTypeName"></param>
        public ContractType(int contractTypeID, string contractTypeName)
        {
            _ContractTypeID = contractTypeID;
            _ContractTypeName = contractTypeName;
        }
        /// <summary>
        /// ��ͬ���캯��
        /// </summary>
        /// <param name="contractTypeID"></param>
        /// <param name="contractTypeName"></param>
        /// <param name="contractTemplate"></param>
        public ContractType(int contractTypeID, string contractTypeName,byte[] contractTemplate):this(contractTypeID,contractTypeName)
        {
            _ContractTemplate = contractTemplate;
        }

        /// <summary>
        /// ��ͬģ��ID
        /// </summary>
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }

        /// <summary>
        /// ��ͬģ������
        /// </summary>
        public string ContractTypeName
        {
            get { return _ContractTypeName; }
            set { _ContractTypeName = value;}
        }
        /// <summary>
        /// ��ͬģ��
        /// </summary>
        public byte[] ContractTemplate
        {
            get { return _ContractTemplate; }
            set { _ContractTemplate = value; }
        }
        /// <summary>
        /// �ж��Ƿ���ģ��
        /// </summary>
        public bool HasTemplate
        {
            get { return _ContractTemplate==null?false:true; }
        }

    }
}
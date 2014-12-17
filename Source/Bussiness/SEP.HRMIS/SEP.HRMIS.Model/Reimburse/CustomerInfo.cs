//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CustomerInfo.cs
// ������: ����
// ��������: 2009-08-14
// ����: �ͻ���Ϣ
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// �ͻ���Ϣ
    /// </summary>
     [Serializable]
    public class CustomerInfo
    {
        private int _CustomerInfoId;
        private string _CompanyName;

        ///<summary>
        ///</summary>
        ///<param name="customerInfoId"></param>
        ///<param name="companyName"></param>
        public CustomerInfo(int customerInfoId,string companyName)
        {
            _CustomerInfoId = customerInfoId;
            _CompanyName = companyName;
        }

         /// <summary>
         /// ��˾����
         /// </summary>
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        ///<summary>
        ///</summary>
        public int CustomerInfoId
        {
            get { return _CustomerInfoId; }
            set { _CustomerInfoId = value; }
        }
    }
}

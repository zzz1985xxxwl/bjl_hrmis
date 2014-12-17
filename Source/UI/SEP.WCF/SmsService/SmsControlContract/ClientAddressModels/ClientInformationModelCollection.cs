//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ClientInformationModelCollection.cs
// ������: �ߺ�
// ��������: 2008-12-1
// ����: ����ͻ����󼯺ϵ��࣬����Ҫͨ�Ŵ���
// ----------------------------------------------------------------
using System.Collections.Generic;
using SmsControlContract.ClientAddressModels;
using System;

namespace SmsControlContract.ClientAddressModels
{
    public class ClientInformationModelCollection
    {
        private List<ClientInformationModel> _TheClientAddresses;

        public ClientInformationModelCollection(List<ClientInformationModel> theClientAddresses)
        {
            _TheClientAddresses = theClientAddresses;
        }

        public List<ClientInformationModel> TheClientAddresses
        {
            get { return _TheClientAddresses; }
            set { _TheClientAddresses = value; }
        }

        /// <summary>
        /// ����HrmisId��ȡ����
        /// </summary>
        public List<ClientInformationModel> GetClientAddressByHrmisId(string hrmisId)
        {
            return _TheClientAddresses.FindAll(new TheSameHrmisId(hrmisId).WithTheSameHrmisId);
        }

        /// <summary>
        /// ����HrmisId��ȡ����
        /// </summary>
        public List<ClientInformationModel> GetClientAddressByHrmisIdDiffPkid(string hrmisId,int exceptPkid)
        {
            return _TheClientAddresses.FindAll(new TheSameHrmisId(hrmisId, exceptPkid).WithTheSameHrmisIdDiffPkid); 
        }
    }

    public class TheSameHrmisId
    {
        private readonly string _HrmisId;
        private readonly int _Pkid;
        private readonly bool _EnableDiffPkid;

        public TheSameHrmisId(string hrmisId)
        {
            _HrmisId = hrmisId;
        }

        public TheSameHrmisId(string hrmisId,int pkid)
        {
            _HrmisId = hrmisId;
            _Pkid = pkid;
            _EnableDiffPkid = true;
        } 

        public bool WithTheSameHrmisId(ClientInformationModel theModel)
        {
            if (theModel.HrmisId.Equals(_HrmisId))
            {
                return true;
            }
            return false;
        }

        public bool WithTheSameHrmisIdDiffPkid(ClientInformationModel theModel)
        {
            if (!_EnableDiffPkid)
            {
                throw new ApplicationException("�����ʹ�÷�ʽ");
            }

            if (theModel.HrmisId.Equals(_HrmisId) && _Pkid != theModel.Pkid)
            {
                return true;
            }
            return false;
        }
    }
}
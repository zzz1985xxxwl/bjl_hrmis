//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ClientInformationModelCollection.cs
// 创建者: 倪豪
// 创建日期: 2008-12-1
// 概述: 管理客户对象集合的类，不需要通信传输
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
        /// 根据HrmisId获取对象
        /// </summary>
        public List<ClientInformationModel> GetClientAddressByHrmisId(string hrmisId)
        {
            return _TheClientAddresses.FindAll(new TheSameHrmisId(hrmisId).WithTheSameHrmisId);
        }

        /// <summary>
        /// 根据HrmisId获取对象
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
                throw new ApplicationException("错误的使用方式");
            }

            if (theModel.HrmisId.Equals(_HrmisId) && _Pkid != theModel.Pkid)
            {
                return true;
            }
            return false;
        }
    }
}
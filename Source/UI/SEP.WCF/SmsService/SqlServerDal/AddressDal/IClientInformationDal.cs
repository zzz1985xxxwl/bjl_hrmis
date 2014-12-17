//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IAddressDal.cs
// 创建者: 倪豪
// 创建日期: 2008-11-24
// 概述: 该类描述了如何存取客户信息的接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SmsControlContract.ClientAddressModels;

namespace SqlServerDal.AddressDal
{
    public interface IClientInformationDal
    {
        /// <summary>
        /// 获取所有的客户信息
        /// </summary>
        /// <returns></returns>
        List<ClientInformationModel> GetAllClientInfomationModel();
        /// <summary>
        /// 根据Id获取对象
        /// </summary>
        ClientInformationModel GetClientInformationById(int pkid);
        /// <summary>
        /// 创建新的客户信息
        /// </summary>
        void InsertClientInfomationModel(ClientInformationModel aClientAddressModel);
        /// <summary>
        /// 修改客户信息
        /// </summary>
        void UpdateClientInfomationModel(ClientInformationModel theClientAddress);
    }
}
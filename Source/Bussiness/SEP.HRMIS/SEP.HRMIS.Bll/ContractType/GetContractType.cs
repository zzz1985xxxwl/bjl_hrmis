//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetContractType.cs
// 创建者: 张燕
// 创建日期: 2008-05-21
// 概述: 新增参数
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class GetContractType 
    {
        private static IContractType _dalContractType = DalFactory.DataAccess.CreateContractType();
        private static IContract _dalContract = DalFactory.DataAccess.CreateContract();
        private static IContractBookMark _dalContractBookMark = DalFactory.DataAccess.CreateContractBookMark();

        public GetContractType()
        {
        }

        public GetContractType(IContractType mockParameter)
        {
            _dalContractType = mockParameter;
        }

        public ContractType GetContractTypeByPKID(int pkid)
        {
            return _dalContractType.GetContractTypeByPkid(pkid);
        }

        public List<ContractType> GetContractTypeByCondition(int pkid, string name)
        {
            return _dalContractType.GetContractTypeByCondition(pkid, name);
        }

        public List<ContractBookMark> GetContractBookMarkByContractTypeID(int contractTypeID)
        {
            return _dalContractBookMark.GetContractBookMarkByContractTypeID(contractTypeID);
        }

        public ContractType GetContractTypeByContractID(int ContractID)
        {
            Contract ct = _dalContract.GetEmployeeContractByContractId(ContractID);
            if (ct == null)
            {
                return null;
            }
            return _dalContractType.GetContractTypeByPkid(ct.ContractType.ContractTypeID);
        }
    }
}

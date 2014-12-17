using System;
using System.Collections.Generic;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.DbRestrictLayer
{
    public class ClientInformationDbRestrictLayer
    {
        private readonly IClientInformationDal _TheDal;

        public ClientInformationDbRestrictLayer(IClientInformationDal theDal)
        {
            _TheDal = theDal;
        }

        public void AddAnObject(ClientInformationModel aNewObject)
        {
            List<ClientInformationModel> hrmisIdRepresentObj = 
                new ClientInformationModelCollection(_TheDal.GetAllClientInfomationModel()).GetClientAddressByHrmisId(aNewObject.HrmisId);
            if(hrmisIdRepresentObj.Count >0)
            {
                throw new ApplicationException("待新增的对象的HrmisId与系统中已有的重复");
            }

            _TheDal.InsertClientInfomationModel(aNewObject);
        }

        public void UpdateTheObject(ClientInformationModel theObject)
        {
            if(theObject == null)
            {
                throw new ApplicationException("待更新的对象为空");
            }

            ClientInformationModel idRepresentObj = _TheDal.GetClientInformationById(theObject.Pkid);
            if (idRepresentObj == null)
            {
                throw new ApplicationException("无法找到该Id标记的对象");
            }

            List<ClientInformationModel> hrmisIdRepresentObj = 
                new ClientInformationModelCollection(_TheDal.GetAllClientInfomationModel()).GetClientAddressByHrmisIdDiffPkid(theObject.HrmisId, theObject.Pkid);
            if (hrmisIdRepresentObj.Count >0)
            {
                throw new ApplicationException("待修改的对象的HrmisId与系统中已有的重复");
            }

            _TheDal.UpdateClientInfomationModel(theObject);
        }
    }
}
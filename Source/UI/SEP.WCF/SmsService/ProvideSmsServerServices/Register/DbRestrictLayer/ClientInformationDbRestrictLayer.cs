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
                throw new ApplicationException("�������Ķ����HrmisId��ϵͳ�����е��ظ�");
            }

            _TheDal.InsertClientInfomationModel(aNewObject);
        }

        public void UpdateTheObject(ClientInformationModel theObject)
        {
            if(theObject == null)
            {
                throw new ApplicationException("�����µĶ���Ϊ��");
            }

            ClientInformationModel idRepresentObj = _TheDal.GetClientInformationById(theObject.Pkid);
            if (idRepresentObj == null)
            {
                throw new ApplicationException("�޷��ҵ���Id��ǵĶ���");
            }

            List<ClientInformationModel> hrmisIdRepresentObj = 
                new ClientInformationModelCollection(_TheDal.GetAllClientInfomationModel()).GetClientAddressByHrmisIdDiffPkid(theObject.HrmisId, theObject.Pkid);
            if (hrmisIdRepresentObj.Count >0)
            {
                throw new ApplicationException("���޸ĵĶ����HrmisId��ϵͳ�����е��ظ�");
            }

            _TheDal.UpdateClientInfomationModel(theObject);
        }
    }
}
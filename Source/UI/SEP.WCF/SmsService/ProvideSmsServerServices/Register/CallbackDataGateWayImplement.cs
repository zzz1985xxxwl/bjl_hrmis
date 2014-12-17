using System.Collections.Generic;
using ProvideSmsServerServices.BoardCast;
using SmsControlContract.ClientAddressModels;
using SmsDataContract;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register
{
    public class CallbackDataGateWayImplement : ICallbackDataGateWay
    {
        private readonly IClientInformationDal _TheDal;
        private readonly ISingleSmsClientContract _TheSingleClientProxy;

        public CallbackDataGateWayImplement(IClientInformationDal theDal, ISingleSmsClientContract theClientProxy)
        {
            _TheDal = theDal;
            _TheSingleClientProxy = theClientProxy;
        }

        public void OnReceivedMessages(List<ReceiveMessageDataModel> messagesTobeSended)
        {
            foreach (ClientInformationModel cam in _TheDal.GetAllClientInfomationModel())
            {
                foreach (string address in cam.GetBoardCastAddress())
                {
                    try
                    {
                        _TheSingleClientProxy.ReceiveTheMessages(messagesTobeSended, address);
                    }
                    //该地址出现问题了
                    catch
                    {
                        cam.CloseTheAddress(address);
                        _TheDal.UpdateClientInfomationModel(cam);
                    }
                }
            }
        }

        public void OnSendFailedMessages(SendMessageDataModel failedMessage)
        {
            foreach (ClientInformationModel cam in _TheDal.GetAllClientInfomationModel())
            {
                if (cam.HrmisId.Equals(failedMessage.HrmisId))
                {
                    foreach (string address in cam.GetBoardCastAddress())
                    {
                        try
                        {
                            _TheSingleClientProxy.SendFailedMessages(failedMessage, address);
                        }
                        catch
                        {
                            cam.CloseTheAddress(address);
                            _TheDal.UpdateClientInfomationModel(cam);
                        }
                    }
                }
            }
        }

        public void OnStopServer()
        {
            foreach (ClientInformationModel cam in _TheDal.GetAllClientInfomationModel())
            {
                foreach (string address in cam.GetBoardCastAddress())
                {
                    try
                    {
                        _TheSingleClientProxy.TheServiceStatusChanged(false, address);
                    }
                    //该地址出现问题了
                    catch
                    {
                        cam.CloseTheAddress(address);
                        _TheDal.UpdateClientInfomationModel(cam);
                    }
                }
            }
        }
    }
}
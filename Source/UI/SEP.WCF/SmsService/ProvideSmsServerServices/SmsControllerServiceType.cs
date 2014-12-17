//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SmsControllerServiceType.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ������ṩ�Ŀ��Ʒ���
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ServiceModel;
using Logs;
using MachineDll;
using ProvideSmsServerServices.BoardCast;
using ProvideSmsServerServices.Register;
using SmsControlContract;
using SmsControlContract.ClientAddressModels;
using SmsDataContract;
using SqlServerDal.AddressDal;
using ProvideSmsServerServices.Register.ForControll;

namespace ProvideSmsServerServices
{
    public class SmsControllerServiceType : ISmsControllerContract
    {
        private readonly TheMachineController theController = new TheMachineController();
        private readonly IClientInformationDal _AddressDal = new SqlServerImplClientInformation();
        private readonly ISingleSmsClientContract _ClientProxy = new SingleSmsClientContractImplement();

        public bool GetPortStatus()
        {
            try
            {
                return theController.GetPortStatus();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void StartConnection()
        {
            try
            {
                theController.StartConnection();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void StopConnection()
        {
            try
            {
                theController.StopConnection();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public bool GetWorkThreadStatus()
        {
            try
            {
                return theController.GetWorkThreadStatus();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void StartTheSmsThread()
        {
            try
            {
                theController.StartTheSmsThread();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void StopTheSmsThread()
        {
            try
            {
                theController.StopTheSmsThread();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public bool TestMachine()
        {
            try
            {
                return theController.TestMachine();

            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public string SendCommand(string commandText, int waitReplayMillionSeconds)
        {
            try
            {
                return theController.SendCommand(commandText, waitReplayMillionSeconds);
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void ReceiveAllMessage()
        {
            try
            {
                theController.ReceiveAllMessage();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void SendSearchMoneyMessage()
        {
            try
            {
                theController.SendSearchMoneyMessage();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public List<ReceiveMessageDataModel> GetLogsForReceiveMessages()
        {
            try
            {
                return theController.GetLogsForReceiveMessages();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public List<SendMessageDataModel> GetLogsForWaitSendMessages()
        {
            try
            {
                return theController.GetLogsForWaitSendMessages();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public List<SendMessageDataModel> GetLogsForSuccesssSendMessages()
        {
            try
            {
                return theController.GetLogsForSuccesssSendMessages();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public List<SendMessageDataModel> GetLogsForFailedSendMessages()
        {
            try
            {
                return theController.GetLogsForFailedSendMessages();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public bool SendAMessage(SendMessageDataModel aMessage)
        {
            try
            {
                return theController.SendAMessage(aMessage);
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public bool GetTheBoardStatus()
        {
            try
            {
                return theController.TheEventHasHandler;
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void SetTheBoardStatus(bool status)
        {
            try
            {
                ClientBroadcast.SetTheBoardStatus(status);
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void DelieveAMessage(SendMessageDataModel aMessage)
        {
            try
            {
                ObjectSource.GetMessageBox.EnqueueWaitMessage(aMessage);
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public ClientInformationModel GetClientAddressModelById(int id)
        {
            try
            {
                return _AddressDal.GetClientInformationById(id);
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public List<ClientInformationModel> GetAllClientAddressModel()
        {
            try
            {
                return _AddressDal.GetAllClientInfomationModel();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void ClearAllReceivedMessages()
        {
            try
            {
                theController.ClearAllReceivedMessages();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void ClearAllSendMessages()
        {
            try
            {
                theController.ClearAllSendMessages();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public List<ListenAddressModel> GetListenAddressModelsByClientId(int clientInformationId)
        {
            try
            {
                return _AddressDal.GetClientInformationById(clientInformationId).TheAddressModelCollcetion;
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void ActiveTheClientInformation(int clientInformationId)
        {
            try
            {
                new ActiveTheClientInformationProxy(clientInformationId, _ClientProxy, _AddressDal).Excute();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void DisableTheClientInformation(int clientInformationId)
        {
            try
            {
                new DisableTheClientInformationProxy(clientInformationId, _ClientProxy, _AddressDal).Excute();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void ActiveTheListenAddress(int clientInformationid, int listenAddressId)
        {
            try
            {
                new ActiveTheListenAddressProxy(clientInformationid, listenAddressId, _ClientProxy, _AddressDal).Excute();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void DisableTheListenAddress(int clientInformationid, int listenAddressId)
        {
            try
            {
                new DisableTheListenAddressProxy(clientInformationid, listenAddressId, _ClientProxy, _AddressDal).Excute();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void AddActivedClientInformation(string hrmisId, string companyDescription)
        {
            try
            {
                new AddActivedClientInformation(hrmisId, companyDescription, _AddressDal);
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        public void DescriptClientInformation(int clientInformationId, string description)
        {
            try
            {
                new DescriptClientInformation(clientInformationId, description, _AddressDal).Excute();
            }
            catch (ApplicationException ae)
            {
                throw new FaultException(ae.Message);
            }
        }

        /// <summary>
        /// ÿ���һ��ʱ�䣬����������һ�Σ�������ϵ�ͻ���
        /// </summary>
        public void ClearBlockMessages()
        {
            new ClearBlockMessages(_ClientProxy, _AddressDal).Excute();
        }

        /// <summary>
        /// �ڼ����˿�֮ǰ��
        /// </summary>
        public void BeforeHostStart()
        {
            try
            {
                StartConnection();
                StartTheSmsThread();
                SetTheBoardStatus(true);
            }
            catch (Exception ae)
            {
                GetLogInstance.GetInstance.DoWriteEventLog(string.Format("�����������߳���㲥��ʱ��ʧ�ܣ�ʧ��ԭ���ǣ�{0}", ae.Message),EventType.Warning);
            }
        }

        public void BeforeHostStopped()
        {
            try
            {
                ClientBroadcast.StopTheServer();
                StopTheSmsThread();
                StopConnection();
            }
            catch (Exception ae)
            {
                GetLogInstance.GetInstance.DoWriteEventLog(string.Format("�ڹرն����߳���㲥��ʱ��ʧ�ܣ�ʧ��ԭ���ǣ�{0}", ae.Message), EventType.Warning);
            }
        }
     
    }
}
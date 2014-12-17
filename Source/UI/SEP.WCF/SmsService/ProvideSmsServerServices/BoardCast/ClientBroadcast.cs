//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ClientBroadcast.cs
// ������: �ߺ�
// ��������: 2008-12-2
// ����: ��ͻ��˹㲥�����ģ������Ҫ���ԣ�
//       �����滻CallbackDataGateWayImplement
//       ΪCallbackDataGateWayImplement_ForTest��
//       ԭ������CallbackDataGateWayImplement_ForTest�в鿴
// ----------------------------------------------------------------
using MachineDll;
using ProvideSmsServerServices.Register;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.BoardCast
{
    public class ClientBroadcast
    {
        private static readonly ICallbackDataGateWay _TheGateWay = new CallbackDataGateWayImplement(new SqlServerImplClientInformation(), new SingleSmsClientContractImplement());
        //new CallbackDataGateWayImplement_ForTest();

        public static void SetTheBoardStatus(bool status)
        {
            if(status)
            {
                StartBroadCastTheMeesages();
            }
            else
            {
                StopBroadCastTheMeesages();
            }
        }

        public static void StopTheServer()
        {
            StopBroadCastTheMeesages();
            _TheGateWay.OnStopServer();
        }

        private static void StartBroadCastTheMeesages()
        {
            //��ֹ��ΰ�
            ObjectSource.GetSmsMachine.ClearEventHandler();

            ObjectSource.GetSmsMachine.ReceivedMessage += new BoardCastReceivedMessage(_TheGateWay).BoardCastNow;
            ObjectSource.GetSmsMachine.SendMessageFailed += new BoardCastSendFailedMessage(_TheGateWay).BoardCastNow;
        }

        private static void StopBroadCastTheMeesages()
        {
            ObjectSource.GetSmsMachine.ClearEventHandler();
        }
    }
}
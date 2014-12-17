//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ClientBroadcast.cs
// 创建者: 倪豪
// 创建日期: 2008-12-2
// 概述: 向客户端广播的中心，如果需要测试，
//       可以替换CallbackDataGateWayImplement
//       为CallbackDataGateWayImplement_ForTest，
//       原因请在CallbackDataGateWayImplement_ForTest中查看
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
            //防止多次绑定
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
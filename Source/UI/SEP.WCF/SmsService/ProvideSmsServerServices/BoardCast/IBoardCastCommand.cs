//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: IBoardCastCommand.cs
// 创建者: 倪豪
// 创建日期: 2008-12-2
// 概述: 可以广播的Command
// ----------------------------------------------------------------
using System;

namespace ProvideSmsServerServices.BoardCast
{
    public interface IBoardCastCommand
    {
        void BoardCastNow(object sender,EventArgs e);
    }
}
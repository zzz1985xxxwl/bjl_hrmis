//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IBoardCastCommand.cs
// ������: �ߺ�
// ��������: 2008-12-2
// ����: ���Թ㲥��Command
// ----------------------------------------------------------------
using System;

namespace ProvideSmsServerServices.BoardCast
{
    public interface IBoardCastCommand
    {
        void BoardCastNow(object sender,EventArgs e);
    }
}
//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IWelfareView.cs
// ������: ���޾�
// ��������: 2008-09-11
// ����: AddWelfareView��Ҫʵ�ֵĽӿ�
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
    public interface IWelfareView
    {
        /// <summary>
        /// �ù�����
        /// </summary>
        string WorkTypeMsg { get; set;}
        string WorkType { get;set;}

        Dictionary<string, string> WorkTypeSource { set;}

        string ResidentDate { get; set;}
        string ResidentMsg{ set;}
        string ResidentOrg { get; set;}

    }
}

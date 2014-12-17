//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IPersonalInAndOutInfoView.cs
// ������: ����
// ��������: 2008-10-20
// ����: ���˿���������ͼ����
// ----------------------------------------------------------------

namespace SEP.HRMIS.Presenter
{
    public interface IPersonalInAndOutInfoView
    {
        /// <summary>
        /// ���ڹ����б����
        /// </summary>
        IPersonalInAndOutListView InAndOutListView { get;}

        /// <summary>
        /// ���ڹ������
        /// </summary>
        IPersonalInAndOutView InAndOutView { get;}

        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool InAndOutViewVisible { set;}
    }
}

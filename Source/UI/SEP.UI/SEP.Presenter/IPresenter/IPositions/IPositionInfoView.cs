//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: IPositionInfoView.cs
// ������: ����
// ��������: 2008-06-24
// ����: ��ְ̨λ�ܽ����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------
namespace SEP.Presenter.IPresenter.IPositions
{
    public interface IPositionInfoView
    {
        /// <summary>
        /// �����
        /// </summary>
        IPositionListView PositionListView{ get; set;}

        /// <summary>
        /// С����
        /// </summary>
        IPositionView PositionView{ get; set;}

        /// <summary>
        /// С�����Ƿ�ɼ�
        /// </summary>
        bool PositionViewVisible{ get; set;}

        string divMPEPositionClientID { get; }
    }

}

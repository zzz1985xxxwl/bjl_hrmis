//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ISkillInfoView.cs
// ������: ZZ
// ��������: 2008-11-07
// ����: �����ܽ���ӿ�
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter;

namespace SEP.HRMIS.Presenter
{
    public interface ISkillInfoView
    {
        ISkillSearchView SkillSearchView { get; set;}
        
        ISkillView SkillView { get; set;}

        bool ShowSkillViewVisible { get;set;}

    }
}

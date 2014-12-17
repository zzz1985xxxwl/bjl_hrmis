//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ISkillTypeInfoView.cs
// ������: ����
// ��������: 2008-11-06
// ����: �������͵��ܽ����ViewҪʵ�ֵĽӿ�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter
{
   public interface ISkillTypeInfoView
    {
       /// <summary>
       /// �����
       /// </summary>
       ISkillTypeListView SkillTypeListView { get; set;}
       /// <summary>
       /// С����
       /// </summary>
       ISkillTypeView SkillTypeView { get; set;}

       bool ShowSkillTypeViewVisible { get;set;}

    }
}

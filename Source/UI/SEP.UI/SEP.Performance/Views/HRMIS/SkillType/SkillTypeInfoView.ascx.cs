//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SkillTypeInfoView.ascx.cs
// ������: ZZ
// ��������: 2008-11-10
// ����: �������͵��ܽ���
// ----------------------------------------------------------------
using System;
using SEP.HRMIS.Presenter;


namespace SEP.Performance.Views.SkillType
{
    public partial class SkillTypeInfoView : System.Web.UI.UserControl,ISkillTypeInfoView
    {
       
        public ISkillTypeListView SkillTypeListView
        {
            get { return SkillTypeListView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public ISkillTypeView SkillTypeView
        {
            get { return SkillTypeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public bool ShowSkillTypeViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
            set
            {
                if (value)
                {
                    mpeSkillType.Show();
                }
                else
                {
                    mpeSkillType.Hide();
                }
            }
        }
    }
}
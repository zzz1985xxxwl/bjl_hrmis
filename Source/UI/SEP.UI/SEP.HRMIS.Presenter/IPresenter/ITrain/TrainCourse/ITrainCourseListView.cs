//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: IChooseSkillView.cs
// ������: ZZ
// ��������: 2008-11-13
// ����: IChooseSkillView
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface ITrainCourseListView
    {
        List<Course> Course { get; set;}

        bool SetVisisle { get; set;}

        /// <summary>
        ///�����γ��¼�
        /// </summary>
        event DelegateID BtnFinishEvent;
        event DelegateNoParameter DataBind; 
    }
}

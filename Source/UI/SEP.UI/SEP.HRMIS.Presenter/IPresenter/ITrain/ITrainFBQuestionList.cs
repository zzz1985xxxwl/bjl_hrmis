//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ITrainFBQuestionList.cs
// ������: ����
// ��������: 2008-11-14
// ����: ITrainFBQuestionList
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain
{
    public interface ITrainFBQuestionList
    {
        string TrainQuesID { get; set;}

        string TrainQuestion { get; set;}

        string SearchMessage { get; set;}

        //string TrainQuestionMessage { set; get;}

        List<TrainFBQuestion> TrainQuestions { set; get;}

        string TrainQuestionType { get; set;}

        List<TrainFBQuesType> TrainQuestionTypes { get; set;}
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter btnSearchClick;

        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event EventHandler BtnAddEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event CommandEventHandler BtnUpdateEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event CommandEventHandler BtnDeleteEvent;

        /// <summary>
        /// �鿴�������
        /// </summary>
        event CommandEventHandler BtnDetailEvent;
    }
}

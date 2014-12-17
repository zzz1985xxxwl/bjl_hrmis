using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentListView
    {
        string Message { set; get;}

        List<Department> Departments { set; get;}
        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateID BtnAddEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;
        /// <summary>
        /// �鿴�����¼�
        /// </summary>
        event DelegateID BtnDetailEvent;
        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter BtnSearchEvent;
    }
}

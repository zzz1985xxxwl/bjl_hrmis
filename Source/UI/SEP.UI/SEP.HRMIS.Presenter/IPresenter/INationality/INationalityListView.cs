using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.INationality
{
    public interface INationalityListView
    {
        string NationalityName { get; }

        string Message { set; get;}
        List<Nationality> Nationalitys { set; get;}
        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
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
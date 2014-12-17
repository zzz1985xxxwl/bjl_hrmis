using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews
{
    public interface IFileCargoView
    {
        /// <summary>
        /// ����
        /// </summary>
        string Title { get; set;}
        /// <summary>
        /// ��ʶ
        /// </summary>
        string Id { get; set;}
        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}
        /// <summary>
        /// ѡ��ĵ�������
        /// </summary>
        string FileCargoName { get; set;}
        /// <summary>
        /// ��ע
        /// </summary>
        string Remark { get; set;}
        /// <summary>
        /// �ļ���ַ
        /// </summary>
        string File { get; set;}

        int AccountID{ get; set;}
        /// <summary>
        /// �������͵�����Դ 
        /// </summary>
        List<FileCargoName> FileCargoNameSource { set; get;}

        /// <summary>
        /// ȷ����ť�¼�
        /// </summary>
        event DelegateNoParameter BtnActionEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter BtnCancelEvent;
    }
}
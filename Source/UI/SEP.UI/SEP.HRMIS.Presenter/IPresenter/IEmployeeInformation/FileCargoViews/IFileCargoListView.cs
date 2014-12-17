using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.FileCargoViews
{
    public interface IFileCargoListView
    {
        ///// <summary>
        ///// ����������Դ,��Session��أ��뽫�˽���������ȡ����
        ///// </summary>
        //List<FileCargo> FileCargoDataSource { get; set;}

        /// <summary>
        /// �����Ľ�����ʾ����Session�޹أ��뽫�˿�������Ŀؼ�������Դ
        /// ����ͬTitle�������ֶ�һ��
        /// </summary>
        List<FileCargo> FileCargoDataView { get; set;}
        /// <summary>
        /// ����ѧϰ������ť
        /// </summary>
        event DelegateNoParameter BtnAddFileCargoEvent;
        bool BtnAddFileCargoVisible { get; set;}

        int AccountID{ get; set;}
        /// <summary>
        /// �޸�ѧϰ������ť
        /// </summary>
        event DelegateID BtnUpdateFileCargoEvent;
        bool BtnUpdateFileCargoVisible { get; set;}
        /// <summary>
        /// ɾ��ѧϰ������ť
        /// </summary>
        event DelegateID BtnDeleteFileCargoEvent;
        bool BtnDeleteFileCargoVisible { get; set;}

        /// <summary>
        /// 
        /// </summary>
        event DelegateNoParameter GetFileList;
    }
}

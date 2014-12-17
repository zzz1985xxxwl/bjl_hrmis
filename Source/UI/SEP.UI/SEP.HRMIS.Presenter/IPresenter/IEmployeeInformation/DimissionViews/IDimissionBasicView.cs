using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews
{
    public interface IDimissionBasicView
    {
        /// <summary>
        /// ��ְ����
        /// </summary>
        string DimissionDate { get; set;}
        string DimissionDateMessage { get; set;}
        /// <summary>
        /// ���ò�����׼
        /// </summary>
        string DimissionMonth { get; set;}
        string DimissionMonthMessage { get; set;}
        /// <summary>
        /// ��ְ����
        /// </summary>
        string DimissionType { get; set;}
        /// <summary>
        /// ��ְԭ������
        /// </summary>
        string DimissionReasonType { get; set;}
        string DimissionReasonTypeMessage { get; set;}
        List<DimissionReasonType> DimissionReasonTypeSource { get; set;}
        bool DimissionReasonTypeEnable { get; set;}
        /// <summary>
        /// ����ԭ��
        /// </summary>
        string DimissionOtherReason { get; set;}
        bool DimissionOtherReasonVisible { get; set;}
        ///// <summary>
        ///// ����������Դ,��Session��أ��뽫�˽���������ȡ����
        ///// </summary>
        //List<FileCargo> FileCargoDataSource { get; set;}
        ///// <summary>
        ///// �����Ľ�����ʾ����Session�޹أ��뽫�˿�������Ŀؼ�������Դ
        ///// ����ͬTitle�������ֶ�һ��
        ///// </summary>
        //List<FileCargo> FileCargoDataView { get; set;}
        ///// <summary>
        ///// ����ѧϰ������ť
        ///// </summary>
        //event DelegateNoParameter BtnAddFileCargoEvent;
        //bool BtnAddFileCargoVisible { get; set;}
        ///// <summary>
        ///// �޸�ѧϰ������ť
        ///// </summary>
        //event DelegateID BtnUpdateFileCargoEvent;
        //bool BtnUpdateFileCargoVisible { get; set;}
        ///// <summary>
        ///// ɾ��ѧϰ������ť
        ///// </summary>
        //event DelegateID BtnDeleteFileCargoEvent;
        //bool BtnDeleteFileCargoVisible { get; set;}
        /// <summary>
        /// ѡ����ְԭ�����͸ı���¼�
        /// </summary>
        event DelegateNoParameter SelectDimissionReasonTypeChange;
    }
}
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.INationality
{
    public interface INationalityView
    {
        string Message { get;set;}
        string NameMsg { get;set;}
        string NationalityID { get; set; }
        string NationalityName { get; set;}
        string NationalityDescription { get; set;}

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// ȡ����ť�¼�
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;
        /// <summary>
        /// �������
        /// </summary>
        string OperationTitle { set; get;}
        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}
        /// <summary>
        /// ȷ�ϰ�ť��ʾ���ַ�
        /// </summary>
        string ActionButtonTxt { get; set;}
        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}

        bool SetReadonly { set; }
    }
}

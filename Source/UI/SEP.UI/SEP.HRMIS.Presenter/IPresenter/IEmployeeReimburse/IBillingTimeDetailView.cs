using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IBillingTimeDetailView
    {
        /// <summary>
        /// ��ʾ�ײ��һЩ��Ϣ
        /// </summary>
        string Message { set;}

        /// <summary>
        /// ����ʱ��ı�����Ϣ
        /// </summary>
        string ReimburseID { set; get;}

        /// <summary>
        /// ����ʱ��ı�����Ϣ
        /// </summary>
        string BillingTimeMessage { set;}

        /// <summary>
        /// ����ʱ��
        /// </summary>
        string BillingTime { set; get;}

        /// <summary>
        /// ��������;�������޸ģ���ϸ
        /// </summary>
        string OperationTitle { set; get;}

        /// <summary>
        /// ȷ�ϰ�ť�¼�
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;

        /// <summary>
        /// �����Ƿ�ɹ�
        /// </summary>
        bool ActionSuccess { get; set;}

        /// <summary>
        /// ��������
        /// </summary>
        string OperationType { get; set;}
    }
}

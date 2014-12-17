
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentView
    {
        string OperatorID { get; set;}
        string Operator { get; set;}
        string Message { set;}
        string DepNameMsg { set;}
        string LeaderNameMsg { set;}
        string ParentID{ get; set;}
        string DepartmentID { get; set; }
        string DepartmentName { get; set;}
        string LeaderName { get; set;}

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

        string CancelButtonClientEvent { set; }
    }
}

using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Adjusts;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Positions;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface IWorkInfoView
    {
        /// <summary>
        /// ְλ
        /// </summary>
        string Position { set;}
        /// <summary>
        /// �Ž�������
        /// </summary>
        string DoorCardNO { get;set;}
        /// <summary>
        /// ��Ṥ��
        /// </summary>
        string SocietyWorkAge { get;set;}
        /// <summary>
        /// ��Ṥ������������Ͳ��ԣ�������Ϣ
        /// </summary>
        string SocietyWorkAgeMessage { get;set;}
        /// <summary>
        /// Ƹ�ø�λ
        /// </summary>
        string ContractPosition { get; set;}
        /// <summary>
        /// ������˾
        /// </summary>
        string Company { get;set;}
        string CompanyMessage { get; set;}
        /// <summary>
        /// ����
        /// </summary>
        string Department { set;}
        int DepartmentID { get; set;}
        /// <summary>
        /// ���Ÿ�����
        /// </summary>
        string DepartmentLeader { get;set; }
        /// <summary>
        /// ��ְʱ��
        /// </summary>
        string ComeDate { get; set;}
        string ComeDateMessage { get; set;}
        /// <summary>
        /// ˾��
        /// </summary>
        string WorkAge{ get; set;}
        /// <summary>
        /// ����ְ��
        /// </summary>
        string Responsibility { get; set;}
        /// <summary>
        /// �����ڵ�����
        /// </summary>
        string ProbationEndDate { get; set;}
        string ProbationEndDateMessage { get; set;}

        /// <summary>
        /// ��������ʼ��
        /// </summary>
        string ProbationStartDate { get; set;}
        string ProbationStartDateMessage { get; set;}
        /// <summary>
        /// ��ͬ��ʼ��
        /// </summary>
        string ContractStartDate { get; set;}
        bool ContractStartDateEnable { get; set;}
        /// <summary>
        /// �º�ͬ��ʼ��
        /// </summary>
        string NewContractStartDate { get; set;}
        bool NewContractStartDateEnable { get; set;}
        /// <summary>
        /// ��ͬ������
        /// </summary>
        string ContractEndDate { get; set;}
        bool ContractEndDateEnable { get; set;}
        /// <summary>
        /// ��ͬ��Ϣ������Դ
        /// </summary>
        List<Contract> EmployeeContract { get; set;}
        /// <summary>
        /// ��ͬ��Ϣ��Session�����ں�ͬ��Ϣ����
        /// </summary>
        List<Contract> EmployeeContractDataSource { get; set;}
        /// <summary>
        /// ������˾������Դ
        /// </summary>
        List<Department> CompanySource { get;set;}
        /// <summary>
        /// �����ص�
        /// </summary>
        string WorkPlace{ get; set;}

        /// <summary>
        /// �������
        /// </summary>
        List<DiyProcess> LeaveRequestProcess { get; set;}
        int leaveProcessId { get; set;}
        string LeaveProcessString { set;}

        /// <summary>
        /// �����������
        /// </summary>
        List<DiyProcess> OutProcess { get; set;}
        int outProcessId { get; set;}
        string OutProcessString { set;}

        /// <summary>
        /// ����Ӱ�����
        /// </summary>
        List<DiyProcess> OverTimeProcess { get; set;}
        int OverTimeProcessId { get; set;}
        string OverTimeString { set;}

        /// <summary>
        /// ��������
        /// </summary>
        List<DiyProcess> AssessProcess { get; set;}
        int AssessProcessId { get; set;}
        string AssessProcessString { set;}

        /// <summary>
        /// ���¸�����
        /// </summary>
        List<DiyProcess> HRPrincipalProcess { get; set;}
        int HRPrincipalProcessId { get; set;}
        string HRPrincipalProcessString { set;}

        ///// <summary>
        ///// ��������
        ///// </summary>
        //List<DiyProcess> ReimburseProcess { get; set;}
        //int ReimburseProcessId { get; set;}
        //string ReimburseProcessString { set;}
        /// <summary>
        /// ��ѵ��������
        /// </summary>
        List<DiyProcess> TraineeApplicationProcess{ get; set;}
        int TraineeApplicationProcessId { get; set;}
        string TraineeApplicationString { set;}

        /// <summary>
        /// �Զ������̸ı�ʱ��ʾ�����
        /// </summary>
        int AccountIdForProcess { get; set;}

        event DelegateNoParameter FatherSelectChangeEvent;
        event DelegateReturnString ContractDownLoadEvent;
        event DelegateReturnBool IsDownLoadEnable;

        /// <summary>
        /// �Զ�������ѡ���¼�
        /// </summary>
        event DelegateID DiyProcessSelectChangeEvent;
        bool ContractManageVisible { set;}

        /// <summary>
        /// ְλ�ȼ�
        /// </summary>
        List<PositionGrade> PositionGradeSource { set;}

        string PositionGradeId { get;set;}

        /// <summary>
        /// ���ݹ�������Դ
        /// </summary>
        List<AdjustRule> AdjustRuleSource { set;}
        int AdjustRuleID{ get; set;}

        List<AssessTemplateItem> AssessActivityItemList { get; set;}

        List<PrincipalShip> PrincipalShipSource { set;}
        string PrincipalShipId { get;set;}
    }
}
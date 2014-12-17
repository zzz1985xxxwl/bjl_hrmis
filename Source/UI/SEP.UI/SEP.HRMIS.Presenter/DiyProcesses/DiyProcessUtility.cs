using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessUtility
    {
        //public const string _SuccessImage =
        //    "&nbsp;&nbsp;&nbsp;<img src='../../image/cg.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";
        //public const string _ErrorImage =
        //    "&nbsp;&nbsp;&nbsp;<img src='../../image/icon03.jpg' align='absmiddle'' />&nbsp;&nbsp;&nbsp;";

        public const string _IsEmpty = "����Ϊ��";
        public const string _ItemNone = " ÿ������Ĳ��������������Ͳ���Ϊ��";
        public const string _OperatorNone = " �����˲���Ϊ��";
        public const string _ItemMoreThanOne = " ������������һ������";
        public const string _ItemMoreThanTwo = " ��������������������";
        public const string _ItemOnlyOne = " ����������ֻ��һ������";
        public const string _WrongStatus = " ��������";
        public const string _ReviewStatus = " �ύ��������һ������Ϊ���";
        public const string _CancelReviewStatus = " ȡ����������һ������Ϊ���";
        public const string _SummarizeCommmentNotLase = " �ս�����ֻ�������һ������";

        /// <summary>
        /// ΪdiyStepList�����һ����ӿյ�item�DiyStepIDΪ-1
        /// </summary>
        /// <param name="diyProcessTypeID"></param>
        /// <param name="diyStepList"></param>
        /// <returns></returns>
        public static List<DiyStep> AddNullItem(int diyProcessTypeID,List<DiyStep> diyStepList)
        {
            switch (diyProcessTypeID)
            {
                //�������
                case 0:
                    DiyStep item1 = new DiyStep(-1, "�ύ", OperatorType.YourSelf, 0);
                    item1.IfSystem = true;
                    diyStepList.Add(item1);
                    DiyStep item2 = new DiyStep(-1, "���", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item2);
                    DiyStep item3 = new DiyStep(-1, "ȡ��", OperatorType.YourSelf, 0);
                    item3.IfSystem = true;
                    diyStepList.Add(item3);
                    DiyStep item4 = new DiyStep(-1, "���", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item4);
                    break;
                //�����������
                case 1:
                    DiyStep item11 = new DiyStep(-1, "�ύ", OperatorType.YourSelf, 0);
                    item11.IfSystem = true;
                    diyStepList.Add(item11);
                    DiyStep item12 = new DiyStep(-1, "���", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item12);
                    break;
                //�Ӱ���������
                case 2:
                    DiyStep item21 = new DiyStep(-1, "�ύ", OperatorType.YourSelf, 0);
                    item21.IfSystem = true;
                    diyStepList.Add(item21);
                    DiyStep item22 = new DiyStep(-1, "���", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item22);
                    break;
                //�������� ������Դ����->��������->��������->����->�ս�����
                case 3:
                    DiyStep item31 = new DiyStep(-1, "������Դ����", OperatorType.Others, 0);
                    diyStepList.Add(item31);
                    DiyStep item32 = new DiyStep(-1, "��������", OperatorType.YourSelf, 0);
                    diyStepList.Add(item32);
                    DiyStep item33 = new DiyStep(-1, "��������", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item33);
                    DiyStep item34 = new DiyStep(-1, "����", OperatorType.GrandDepartmentLeader, 0);
                    diyStepList.Add(item34);
                    DiyStep item35 = new DiyStep(-1, "�ս�����", OperatorType.Others, 0);
                    diyStepList.Add(item35);
                    break;
                //���¸�����
                case 4:
                    DiyStep item41 = new DiyStep(-1, "����", OperatorType.YourSelf, 0);
                    item41.IfSystem = true;
                    diyStepList.Add(item41);
                    break;
                //��������
                case 5:
                    DiyStep item51 = new DiyStep(-1, "���", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item51);
                    break;

                //��ѵ��������
                case 6:
                    DiyStep item61 = new DiyStep(-1, "�ύ", OperatorType.YourSelf, 0);
                    item61.IfSystem = true;
                    diyStepList.Add(item61);
                    DiyStep item62 = new DiyStep(-1, "���", OperatorType.DepartmentLeader, 0);
                    diyStepList.Add(item62);
                    break;

                    //����
                default:
                    DiyStep item5 = new DiyStep(-1, "", OperatorType.YourSelf, 0);
                    diyStepList.Add(item5);
                    break;

            }
            return diyStepList;
        }

        public static Dictionary<string, string> GetProcessTypeSource()
        {
            return ProcessType.GetProcessType();
        }

        public static Dictionary<string, string> GetAllProcessType()
        {
            return ProcessType.GetAllProcessType();
        }

        public static Dictionary<string, string> GetSystemStatusSource(int processTypeID)
        {
            Dictionary<string, string> statusSource = new Dictionary<string, string>();
            //0 �������; 1 �����������; 2 �Ӱ���������; 3 ��������; 4 ���¸�����
            switch(processTypeID)
            {
                case 0:
                    //�ύ->���->ȡ��->���
                    statusSource.Add("0", "�ύ");
                    statusSource.Add("1", "���");
                    statusSource.Add("2", "ȡ��");
                    statusSource.Add("3", "���");
                    break;
                case 1:
                    //�ύ->���
                    statusSource.Add("0", "�ύ");
                    statusSource.Add("1", "���");
                    statusSource.Add("2", "���Ըĵ���");
                    break;
                case 2:
                    //�ύ->��ˣ����ύֻ���Ǳ��˲���������ַ���˺Ϳ��Ըĵ���
                    statusSource.Add("0", "�ύ");
                    statusSource.Add("1", "���");
                    statusSource.Add("2", "���Ըĵ���");
                    break;
                case 3:
                    //��������->��������->��������->����
                    statusSource.Add("0", "������Դ����");
                    statusSource.Add("1", "��������");
                    statusSource.Add("2", "��������");
                    statusSource.Add("3", "����");
                    statusSource.Add("4", "�ս�����");
                    break;
                case 4:
                    //����
                    statusSource.Add("0", "����");
                    break;
                case 5:
                    //��������
                    statusSource.Add("0", "���");
                    statusSource.Add("1", "�����쵼����ǩ��");
                    statusSource.Add("2", "�������ǩ��");
                    statusSource.Add("3", "CEO����ǩ��");
                    break;
                case 6:
                    //��ѵ��������
                    statusSource.Add("0", "�ύ");
                    statusSource.Add("1", "���");
                    break;
            }
            return statusSource;
        }

        public static Dictionary<string, string> GetStatusSource(int processTypeID)
        {
            Dictionary<string, string> statusSource = new Dictionary<string, string>();
            //0 �������; 1 �����������; 2 �Ӱ���������; 3 ��������; 4 ���¸�����
            switch (processTypeID)
            {
                case 0:
                    //�ύ->���->ȡ��->���
                    statusSource.Add("1", "���");
                    break;
                case 1:
                    //�ύ->���
                    statusSource.Add("1", "���");
                    statusSource.Add("2", "���Ըĵ���");
                    break;
                case 2:
                    //�ύ->��ˣ����ύֻ���Ǳ��˲���������ַ���˺Ϳ��Ըĵ���
                    statusSource.Add("1", "���");
                    statusSource.Add("2", "���Ըĵ���");
                    break;
                case 3:
                    //��������->��������->��������->����
                    statusSource.Add("0", "������Դ����");
                    statusSource.Add("1", "��������");
                    statusSource.Add("2", "��������");
                    statusSource.Add("3", "����");
                    statusSource.Add("4", "�ս�����");
                    break;
                case 4:
                    //����
                    statusSource.Add("0", "����");
                    break;
                case 5:
                    //��������
                    statusSource.Add("0", "���");
                    statusSource.Add("1", "�����쵼����ǩ��");
                    statusSource.Add("2", "�������ǩ��");
                    statusSource.Add("3", "CEO����ǩ��");
                    break;
                case 6:
                    //��ѵ��������
                    statusSource.Add("1", "���");
                    break;
            }
            return statusSource;
        }

        public static Dictionary<string, string> GetOperatorSource()
        {
            return OperatorType.GetOperatorType();
        }
    }
}

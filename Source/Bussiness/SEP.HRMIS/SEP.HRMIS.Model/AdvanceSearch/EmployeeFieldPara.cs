using System;
using System.Collections.Generic;
using AdvancedCondition;
using AdvancedCondition.Enums;
using SEPModel = SEP.Model;

namespace SEP.HRMIS.Model.AdvanceSearch
{
    /// <summary>
    /// �����ֶ�
    /// </summary>
    public class EmployeeFieldPara : FieldParaBase
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldName"></param>
        /// <param name="abbreviations"></param>
        /// <param name="fieldKey"></param>
        public EmployeeFieldPara(int id, string fieldName, string[] abbreviations, string fieldKey)
            : base(id, fieldName, abbreviations, fieldKey)
        {
        }

        private static List<SEPModel.Departments.Department> _DepartmentTreeDataSource;
        /// <summary>
        /// �������ͽṹ�����ڲ�������ɸѡ
        /// </summary>
        public static List<SEPModel.Departments.Department> DepartmentTreeDataSource
        {
            get { return _DepartmentTreeDataSource; }
            set { _DepartmentTreeDataSource = value; }
        }

        /// <summary>
        /// �������ͽṹ�����ڲ�������ɸѡ
        /// </summary>
        public static Tree DepartmentTree
        {
            get
            {
                Tree departmentTree = new Tree(-9999);
                if (_DepartmentTreeDataSource != null)
                {
                    Utility.ConvertDepartmentToTree(departmentTree, _DepartmentTreeDataSource);
                }
                return departmentTree;
            }
        }

        #region ע�⣬��Щ�ֶ��������ӣ���ΪID�������ۼӣ������ظ�

        #region ��ѯ�ֶ�Name
        /// <summary>
        /// Ա������
        /// </summary>
        public static EmployeeFieldPara Name =
            new EmployeeFieldPara(1, "Ա������", "ygxm|yuangongxingming|Ա������|xm|xingming|����".Split('|'), "Name");
        /// <summary>
        /// ��ʼ�� Ա������ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Name()
        {
            return new SearchField(Name,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�EnglishName
        /// <summary>
        /// Ӣ����
        /// </summary>
        public static EmployeeFieldPara EnglishName =
            new EmployeeFieldPara(2, "Ӣ����", "ywm|yingwenming|Ӣ����".Split('|'), "EnglishName");
        /// <summary>
        /// ��ʼ�� Ӣ���� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EnglishName()
        {
            return new SearchField(EnglishName,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�School
        /// <summary>
        /// ��ҵԺУ
        /// </summary>
        public static EmployeeFieldPara School =
            new EmployeeFieldPara(3, "��ҵԺУ", "byyx|biyeyuanxiao|��ҵԺУ".Split('|'), "School");
        /// <summary>
        /// ��ʼ�� ��ҵԺУ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_School()
        {
            return new SearchField(School,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�FamilyAddress
        /// <summary>
        /// ��ͥסַ
        /// </summary>
        public static EmployeeFieldPara FamilyAddress =
            new EmployeeFieldPara(4, "��ͥסַ", "jtzz|jiatingzhuzhi|��ͥסַ|zz|zhuzhi|סַ".Split('|'), "FamilyAddress");
        /// <summary>
        /// ��ʼ����ͥסַ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_FamilyAddress()
        {
            return new SearchField(FamilyAddress,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�PostCode
        /// <summary>
        /// ��ͥ�ʱ�
        /// </summary>
        public static EmployeeFieldPara PostCode =
            new EmployeeFieldPara(5, "��ͥ�ʱ�", "jtyb|jiatingyoubian|��ͥ�ʱ�|�ʱ�|youbian|yb".Split('|'), "PostCode");
        /// <summary>
        /// ��ʼ�� ��ͥ�ʱ� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PostCode()
        {
            return new SearchField(PostCode,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�FamilyPhone
        /// <summary>
        /// ��ͥ�绰
        /// </summary>
        public static EmployeeFieldPara FamilyPhone =
            new EmployeeFieldPara(6, "��ͥ�绰", "jtdh|jiatingdianhua|��ͥ�绰|�绰|dianhua|dh".Split('|'), "FamilyPhone");
        /// <summary>
        /// ��ʼ�� ��ͥ�ʱ� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_FamilyPhone()
        {
            return new SearchField(FamilyPhone,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�ComeDate
        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public static EmployeeFieldPara ComeDate =
            new EmployeeFieldPara(7, "��ְʱ��", "rzsj|ruzhishijian|��ְʱ��".Split('|'), "ComeDate");
        /// <summary>
        /// ��ʼ�� ��ְʱ�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ComeDate()
        {
            return new SearchField(ComeDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�LeaveDate
        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public static EmployeeFieldPara LeaveDate =
            new EmployeeFieldPara(8, "��ְʱ��", "lzsj|lizhishijian|��ְʱ��".Split('|'), "LeaveDate");
        /// <summary>
        /// ��ʼ�� ��ְʱ�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_LeaveDate()
        {
            return new SearchField(LeaveDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Height
        /// <summary>
        /// ���
        /// </summary>
        public static EmployeeFieldPara Height =
            new EmployeeFieldPara(9, "���", "sg|shengao|���".Split('|'), "Height");
        /// <summary>
        /// ��ʼ�� ��� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Height()
        {
            return new SearchField(Height,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Weight
        /// <summary>
        /// ����
        /// </summary>
        public static EmployeeFieldPara Weight =
            new EmployeeFieldPara(10, "����", "tz|tizhong|����".Split('|'), "Weight");
        /// <summary>
        /// ��ʼ�� ���� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Weight()
        {
            return new SearchField(Weight,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�EmployeeType
        /// <summary>
        /// Ա������
        /// </summary>
        public static EmployeeFieldPara EmployeeType =
            new EmployeeFieldPara(11, "Ա������", "yglx|yuangongleixing|Ա������".Split('|'), "EmployeeType");
        /// <summary>
        /// ��ʼ�� Ա������ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EmployeeType()
        {
            return new SearchField(EmployeeType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Department
        /// <summary>
        /// ��������
        /// </summary>
        public static EmployeeFieldPara Department =
            new EmployeeFieldPara(12, "��������", "bm|bumen|suoshubumen|ssbm|����|��������".Split('|'), "Department");
        /// <summary>
        /// ��ʼ�� �������� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Department()
        {
            return new SearchField(Department,
                                   new TreeActiveEnumField(EnumCompareType.FuzzyMatchIncludeChild, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Position
        /// <summary>
        /// ְλ
        /// </summary>
        public static EmployeeFieldPara Position =
            new EmployeeFieldPara(13, "ְλ", "zw|zhiwei|ְλ".Split('|'), "Position");
        /// <summary>
        /// ��ʼ�� ְλ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Position()
        {
            return new SearchField(Position,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }


        #endregion



        #region ��ѯ�ֶ�MobileNum

        /// <summary>
        /// �ֻ�����
        /// </summary>
        public static EmployeeFieldPara MobileNum =
            new EmployeeFieldPara(14, "�ֻ�����", "sjhm|shoujihaoma|�ֻ�����".Split('|'), "MobileNum");
        /// <summary>
        /// ��ʼ�� �ֻ����� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_MobileNum()
        {
            return new SearchField(MobileNum,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Company

        /// <summary>
        /// ������˾
        /// </summary>
        public static EmployeeFieldPara Company =
            new EmployeeFieldPara(15, "������˾", "ssgs|suoshugongsi|������˾|��˾|gs|gongsi".Split('|'), "Company");
        /// <summary>
        /// ��ʼ�� ������˾ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Company()
        {
            return new SearchField(Company,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Num

        /// <summary>
        /// ����
        /// </summary>
        public static EmployeeFieldPara Num =
            new EmployeeFieldPara(16, "����", "gh|gonghao|����".Split('|'), "Num");
        /// <summary>
        /// ��ʼ�� ���� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Num()
        {
            return new SearchField(Num,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�LoginName

        /// <summary>
        /// ��¼��
        /// </summary>
        public static EmployeeFieldPara LoginName =
            new EmployeeFieldPara(17, "��¼��", "dlm|dengluming|��¼��".Split('|'), "LoginName");
        /// <summary>
        /// ��ʼ�� ��¼�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_LoginName()
        {
            return new SearchField(LoginName,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Email

        /// <summary>
        /// Email
        /// </summary>
        public static EmployeeFieldPara Email =
            new EmployeeFieldPara(18, "Email", "Email|email|EMAIL".Split('|'), "Email");
        /// <summary>
        /// ��ʼ�� Email ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Email()
        {
            return new SearchField(Email,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Email2

        /// <summary>
        /// Email2
        /// </summary>
        public static EmployeeFieldPara Email2 =
            new EmployeeFieldPara(19, "Email2", "Email2|email2|EMAIL2".Split('|'), "Email2");
        /// <summary>
        /// ��ʼ�� Email2 ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Email2()
        {
            return new SearchField(Email2,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Gender
        /// <summary>
        /// �Ա�
        /// </summary>
        public static EmployeeFieldPara Gender =
            new EmployeeFieldPara(20, "�Ա�", "xb|xingbie|�Ա�".Split('|'), "Gender");
        /// <summary>
        /// ��ʼ�� �Ա� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Gender()
        {
            return new SearchField(Gender,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� CountryNationality
        /// <summary>
        /// ����
        /// </summary>
        public static EmployeeFieldPara CountryNationality =
            new EmployeeFieldPara(21, "����", "gj|guoji|����".Split('|'), "CountryNationality");
        /// <summary>
        /// ��ʼ�� ���� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_CountryNationality()
        {
            return new SearchField(CountryNationality,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Nationality
        /// <summary>
        /// ����
        /// </summary>
        public static EmployeeFieldPara Nationality =
            new EmployeeFieldPara(22, "����", "mz|mingzu|����".Split('|'), "Nationality");
        /// <summary>
        /// ��ʼ�� ���� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Nationality()
        {
            return new SearchField(Nationality,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Birthday
        /// <summary>
        /// ��������
        /// </summary>
        public static EmployeeFieldPara Birthday =
            new EmployeeFieldPara(23, "��������", "csny|chushengnianyue|��������".Split('|'), "Birthday");
        /// <summary>
        /// ��ʼ�� �������� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Birthday()
        {
            return new SearchField(Birthday,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� PoliticalAffiliation
        /// <summary>
        /// ������ò
        /// </summary>
        public static EmployeeFieldPara PoliticalAffiliation =
            new EmployeeFieldPara(24, "������ò", "zzmm|zhengzhimianmao|������ò".Split('|'), "PoliticalAffiliation");
        /// <summary>
        /// ��ʼ�� ������ò ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PoliticalAffiliation()
        {
            return new SearchField(PoliticalAffiliation,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� NativePlace
        /// <summary>
        /// ����
        /// </summary>
        public static EmployeeFieldPara NativePlace =
            new EmployeeFieldPara(25, "����", "jg|jiguan|����".Split('|'), "NativePlace");
        /// <summary>
        /// ��ʼ�� ���� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_NativePlace()
        {
            return new SearchField(NativePlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� MaritalStatus
        /// <summary>
        /// ����״��
        /// </summary>
        public static EmployeeFieldPara MaritalStatus =
            new EmployeeFieldPara(26, "����״��", "hyzk|hunyinzhuangkuang|����״��".Split('|'), "MaritalStatus");
        /// <summary>
        /// ��ʼ�� ����״�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_MaritalStatus()
        {
            return new SearchField(MaritalStatus,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� PhysicalConditions
        /// <summary>
        /// ����״��
        /// </summary>
        public static EmployeeFieldPara PhysicalConditions =
            new EmployeeFieldPara(27, "����״��", "jkzk|jiankangzhuangkuang|����״��".Split('|'), "PhysicalConditions");
        /// <summary>
        /// ��ʼ�� ����״�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PhysicalConditions()
        {
            return new SearchField(PhysicalConditions,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� IDCard
        /// <summary>
        /// ֤������ 
        /// </summary>
        public static EmployeeFieldPara IDCardNo =
            new EmployeeFieldPara(28, "֤������", "zjhm|zhengjianhaoma|֤������".Split('|'), "IDCardNo");
        /// <summary>
        /// ��ʼ�� ֤������  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_IDCardNo()
        {
            return new SearchField(IDCardNo,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� IDCardDueDate
        /// <summary>
        /// ֤����Ч�� 
        /// </summary>
        public static EmployeeFieldPara IDCardDueDate =
            new EmployeeFieldPara(29, "֤����Ч��", "zjyxq|zhengjianyouxiaoqi|֤����Ч��".Split('|'), "IDCardDueDate");
        /// <summary>
        /// ��ʼ�� ֤����Ч��  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_IDCardDueDate()
        {
            return new SearchField(IDCardDueDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� GraduateTime
        /// <summary>
        /// ��ҵʱ�� 
        /// </summary>
        public static EmployeeFieldPara GraduateTime =
            new EmployeeFieldPara(30, "��ҵʱ��", "bysj|biyeshijian|��ҵʱ��".Split('|'), "GraduateTime");
        /// <summary>
        /// ��ʼ�� ��ҵʱ��  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_GraduateTime()
        {
            return new SearchField(GraduateTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� EducationalBackground
        /// <summary>
        /// �Ļ��̶�  
        /// </summary>
        public static EmployeeFieldPara EducationalBackground =
            new EmployeeFieldPara(31, "�Ļ��̶�", "whcd|wenhuachengdu|�Ļ��̶�".Split('|'), "EducationalBackground");
        /// <summary>
        /// ��ʼ�� �Ļ��̶�   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EducationalBackground()
        {
            return new SearchField(EducationalBackground,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Major
        /// <summary>
        /// רҵ  
        /// </summary>
        public static EmployeeFieldPara Major =
            new EmployeeFieldPara(32, "רҵ", "zy|zhuanye|רҵ".Split('|'), "Major");
        /// <summary>
        /// ��ʼ�� רҵ   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Major()
        {
            return new SearchField(Major,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Leader
        /// <summary>
        /// ���Ÿ�����  
        /// </summary>
        public static EmployeeFieldPara Leader =
            new EmployeeFieldPara(33, "���Ÿ�����", "bmfzr|bumenfuzeren|���Ÿ�����".Split('|'), "Leader");
        /// <summary>
        /// ��ʼ�� ���Ÿ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Leader()
        {
            return new SearchField(Leader,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DoorCardNo
        /// <summary>
        /// �Ž�������  
        /// </summary>
        public static EmployeeFieldPara DoorCardNo =
            new EmployeeFieldPara(35, "�Ž�������", "mjkkh|menjinkakahao|�Ž�������".Split('|'), "DoorCardNo");
        /// <summary>
        /// ��ʼ�� �Ž�������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DoorCardNo()
        {
            return new SearchField(DoorCardNo,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� SocietyWorkAge
        /// <summary>
        /// ��Ṥ��(��)  
        /// </summary>
        public static EmployeeFieldPara SocietyWorkAge =
            new EmployeeFieldPara(36, "��Ṥ��(��)", "shgl|shehuigonglin|��Ṥ��(��)".Split('|'), "SocietyWorkAge");
        /// <summary>
        /// ��ʼ�� �Ž�������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_SocietyWorkAge()
        {
            return new SearchField(SocietyWorkAge,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ� WorkPlace
        /// <summary>
        /// �����ص�
        /// </summary>
        public static EmployeeFieldPara WorkPlace =
            new EmployeeFieldPara(37, "�����ص�", "gzdd|gongzuodidian|�����ص�".Split('|'), "WorkPlace");
        /// <summary>
        /// ��ʼ�� �����ص�   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkPlace()
        {
            return new SearchField(WorkPlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DiyProcessLeaveRequest
        /// <summary>
        /// �������
        /// </summary>
        public static EmployeeFieldPara DiyProcessLeaveRequest =
            new EmployeeFieldPara(38, "�������", "qjlc|qingjialiucheng|�������".Split('|'), "DiyProcessLeaveRequest");
        /// <summary>
        /// ��ʼ�� �������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessLeaveRequest()
        {
            return new SearchField(DiyProcessLeaveRequest,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DiyProcessApplicationTypeOut
        /// <summary>
        /// �����������
        /// </summary>
        public static EmployeeFieldPara DiyProcessApplicationTypeOut =
            new EmployeeFieldPara(39, "�����������", "wcsqliuchen|waichushenqingliucheng|�����������".Split('|'), "DiyProcessApplicationTypeOut");
        /// <summary>
        /// ��ʼ�� �����������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessApplicationTypeOut()
        {
            return new SearchField(DiyProcessApplicationTypeOut,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DiyProcessApplicationTypeOverTime
        /// <summary>
        /// �Ӱ���������
        /// </summary>
        public static EmployeeFieldPara DiyProcessApplicationTypeOverTime =
            new EmployeeFieldPara(40, "�Ӱ���������", "jiabanshengqingliucheng|jbsqlc|�Ӱ���������".Split('|'), "DiyProcessApplicationTypeOverTime");
        /// <summary>
        /// ��ʼ�� �Ӱ���������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessApplicationTypeOverTime()
        {
            return new SearchField(DiyProcessApplicationTypeOverTime,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DiyProcessAssess
        /// <summary>
        /// ��Ч��������
        /// </summary>
        public static EmployeeFieldPara DiyProcessAssess =
            new EmployeeFieldPara(41, "��Ч��������", "jxkhlc|jixiaokaoheliucheng|��Ч��������".Split('|'), "DiyProcessAssess");
        /// <summary>
        /// ��ʼ�� �Ӱ���������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessAssess()
        {
            return new SearchField(DiyProcessAssess,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DiyProcessTraineeApplication
        /// <summary>
        /// ��ѵ��������
        /// </summary>
        public static EmployeeFieldPara DiyProcessTraineeApplication =
            new EmployeeFieldPara(42, "��ѵ��������", "pxsqlc|peixunshenqingliucheng|��ѵ��������".Split('|'), "DiyProcessTraineeApplication");
        /// <summary>
        /// ��ʼ�� ��ѵ��������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessTraineeApplication()
        {
            return new SearchField(DiyProcessTraineeApplication,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DiyProcessHRPrincipal
        /// <summary>
        /// ���¸�����
        /// </summary>
        public static EmployeeFieldPara DiyProcessHRPrincipal =
            new EmployeeFieldPara(43, "���¸�����", "rsfzr|renshifuzeren|���¸�����".Split('|'), "DiyProcessHRPrincipal");
        /// <summary>
        /// ��ʼ�� ��ѵ��������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessHRPrincipal()
        {
            return new SearchField(DiyProcessHRPrincipal,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Responsibility
        /// <summary>
        /// ����ְ��
        /// </summary>
        public static EmployeeFieldPara Responsibility =
            new EmployeeFieldPara(44, "����ְ��", "gzzz|gongzuozhize|����ְ��".Split('|'), "Responsibility");
        /// <summary>
        /// ��ʼ�� ����ְ��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Responsibility()
        {
            return new SearchField(Responsibility,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ProbationTime
        /// <summary>
        /// �����ڵ�����
        /// </summary>
        public static EmployeeFieldPara ProbationTime =
            new EmployeeFieldPara(45, "�����ڵ�����", "syqdqr|shiyongqidaoqiri|�����ڵ�����".Split('|'), "ProbationTime");
        /// <summary>
        /// ��ʼ�� �����ڵ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ProbationTime()
        {
            return new SearchField(ProbationTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� WorkType
        /// <summary>
        /// �ù�����
        /// </summary>
        public static EmployeeFieldPara WorkType =
            new EmployeeFieldPara(46, "�ù�����", "ygxz|yonggongxingzhi|�ù�����".Split('|'), "WorkType");
        /// <summary>
        /// ��ʼ�� �ù�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkType()
        {
            return new SearchField(WorkType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ResidencePermits
        /// <summary>
        /// ��ס֤������
        /// </summary>
        public static EmployeeFieldPara ResidencePermits =
            new EmployeeFieldPara(47, "��ס֤������", "jzzdqr|juzhuzhengdaoqiri|��ס֤������".Split('|'), "ResidencePermits");
        /// <summary>
        /// ��ʼ�� ��ס֤������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ResidencePermits()
        {
            return new SearchField(ResidencePermits,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ResidencePermitsOrgnaization
        /// <summary>
        /// ��ס֤�������
        /// </summary>
        public static EmployeeFieldPara ResidencePermitsOrgnaization =
            new EmployeeFieldPara(48, "��ס֤�������", "jzzbljg|juzhuzhengbanlijigou|��ס֤�������".Split('|'), "ResidencePermitsOrgnaization");
        /// <summary>
        /// ��ʼ�� ��ס֤�������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ResidencePermitsOrgnaization()
        {
            return new SearchField(ResidencePermitsOrgnaization,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� EmployeeWelfareDescription
        /// <summary>
        /// �������� 
        /// </summary>
        public static EmployeeFieldPara EmployeeWelfareDescription =
            new EmployeeFieldPara(49, "��������", "flms|fulimiaoshu|��������".Split('|'), "EmployeeWelfareDescription");
        /// <summary>
        /// ��ʼ�� ��������    ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EmployeeWelfareDescription()
        {
            return new SearchField(EmployeeWelfareDescription,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� SalaryCardNo
        /// <summary>
        /// ���ʿ��ʺ� 
        /// </summary>
        public static EmployeeFieldPara SalaryCardNo =
            new EmployeeFieldPara(50, "���ʿ��ʺ�", "gzkzh|gongzikazhanghao|���ʿ��ʺ�".Split('|'), "SalaryCardNo");
        /// <summary>
        /// ��ʼ�� ��������    ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_SalaryCardNo()
        {
            return new SearchField(SalaryCardNo,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� AccumulationFundAccount
        /// <summary>
        /// �������ʺ� 
        /// </summary>
        public static EmployeeFieldPara AccumulationFundAccount =
            new EmployeeFieldPara(51, "�������ʺ�", "gjjzh|gongjijinzhanghao|�������ʺ�".Split('|'), "AccumulationFundAccount");
        /// <summary>
        /// ��ʼ�� �������� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AccumulationFundAccount()
        {
            return new SearchField(AccumulationFundAccount,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� AccumulationFundSupplyAccount
        /// <summary>
        /// ���乫�����ʺ� 
        /// </summary>
        public static EmployeeFieldPara AccumulationFundSupplyAccount =
            new EmployeeFieldPara(52, "���乫�����ʺ�", "bcgjjzh|buchonggongjijinzhanghao|���乫�����ʺ�".Split('|'), "AccumulationFundSupplyAccount");
        /// <summary>
        /// ��ʼ�� ���乫�����ʺ� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AccumulationFundSupplyAccount()
        {
            return new SearchField(AccumulationFundSupplyAccount,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� WorkTitle
        /// <summary>
        /// ְ�� 
        /// </summary>
        public static EmployeeFieldPara WorkTitle =
            new EmployeeFieldPara(53, "ְ��", "zc|zhicheng|ְ��".Split('|'), "WorkTitle");
        /// <summary>
        /// ��ʼ�� ְ�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkTitle()
        {
            return new SearchField(WorkTitle,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ForeignLanguageAbility
        /// <summary>
        /// �������� 
        /// </summary>
        public static EmployeeFieldPara ForeignLanguageAbility =
            new EmployeeFieldPara(54, "��������", "wynl|waiyunengli|��������".Split('|'), "ForeignLanguageAbility");
        /// <summary>
        /// ��ʼ�� �������� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ForeignLanguageAbility()
        {
            return new SearchField(ForeignLanguageAbility,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Certificates
        /// <summary>
        /// ֤�� 
        /// </summary>
        public static EmployeeFieldPara Certificates =
            new EmployeeFieldPara(55, "֤��", "zs|zhengshu|֤��".Split('|'), "Certificates");
        /// <summary>
        /// ��ʼ�� ֤�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Certificates()
        {
            return new SearchField(Certificates,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� RPRAddress
        /// <summary>
        /// ���ڵ�ַ  
        /// </summary>
        public static EmployeeFieldPara RPRAddress =
            new EmployeeFieldPara(56, "���ڵ�ַ", "hkdz|hukoudizhi|���ڵ�ַ".Split('|'), "RPRAddress");
        /// <summary>
        /// ��ʼ�� ���ڵ�ַ  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_RPRAddress()
        {
            return new SearchField(RPRAddress,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� PRPPostCode
        /// <summary>
        /// �����ʱ�
        /// </summary>
        public static EmployeeFieldPara PRPPostCode =
            new EmployeeFieldPara(57, "�����ʱ�", "hkyb|hukouyoubian|�����ʱ�|�ʱ�|youbian|yb".Split('|'), "PRPPostCode");
        /// <summary>
        /// ��ʼ�� �����ʱ�  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PRPPostCode()
        {
            return new SearchField(PRPPostCode,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� PRPPostCode
        /// <summary>
        /// ������������
        /// </summary>
        public static EmployeeFieldPara PRPArea =
            new EmployeeFieldPara(58, "������������", "hkssqy|hukousuoshuquyu|������������".Split('|'), "PRPArea");
        /// <summary>
        /// ��ʼ�� ������������  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PRPArea()
        {
            return new SearchField(PRPArea,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� PRPStreet
        /// <summary>
        /// ���������ֵ�
        /// </summary>
        public static EmployeeFieldPara PRPStreet =
            new EmployeeFieldPara(59, "���������ֵ�", "hkssjd|hukousuoshujiedao|���������ֵ�".Split('|'), "PRPStreet");
        /// <summary>
        /// ��ʼ�� ���������ֵ�  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PRPStreet()
        {
            return new SearchField(PRPStreet,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� RecordPlace
        /// <summary>
        /// �������ڵ�
        /// </summary>
        public static EmployeeFieldPara RecordPlace =
            new EmployeeFieldPara(60, "�������ڵ�", "daszd|dangansuozaidi|�������ڵ�".Split('|'), "RecordPlace");
        /// <summary>
        /// ��ʼ�� �������ڵ�  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_RecordPlace()
        {
            return new SearchField(RecordPlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� EmergencyContacts
        /// <summary>
        /// ������ϵ��
        /// </summary>
        public static EmployeeFieldPara EmergencyContacts =
            new EmployeeFieldPara(61, "������ϵ��", "jjlxr|jinjilianxiren|������ϵ��".Split('|'), "EmergencyContacts");
        /// <summary>
        /// ��ʼ�� ������ϵ��  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EmergencyContacts()
        {
            return new SearchField(EmergencyContacts,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ChildName
        /// <summary>
        /// ��������
        /// </summary>
        public static EmployeeFieldPara ChildName =
            new EmployeeFieldPara(62, "��������", "hzmz|haizimingzi|��������".Split('|'), "ChildNameShow");
        /// <summary>
        /// ��ʼ�� ��������  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ChildName()
        {
            return new SearchField(ChildName,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ChildBirthday
        /// <summary>
        /// ���ӳ�������
        /// </summary>
        public static EmployeeFieldPara ChildBirthday =
            new EmployeeFieldPara(63, "���ӳ�������", "hzcsny|haizichushengnianyue|���ӳ�������".Split('|'), "ChildBirthdayShow");
        /// <summary>
        /// ��ʼ�� ���ӳ�������  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ChildBirthday()
        {
            return new SearchField(ChildBirthday,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DimissionType
        /// <summary>
        /// ��ְ����
        /// </summary>
        public static EmployeeFieldPara DimissionType =
            new EmployeeFieldPara(64, "��ְ����", "lzlx|lizhileixing|��ְ����".Split('|'), "DimissionType");
        /// <summary>
        /// ��ʼ�� ��ְ����  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DimissionType()
        {
            return new SearchField(DimissionType,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� NewDimissionMonth
        /// <summary>
        /// ���ò�����׼
        /// </summary>
        public static EmployeeFieldPara NewDimissionMonth =
            new EmployeeFieldPara(65, "���ò�����׼", "jjbcbz|jingjibuchangbiaozhun|���ò�����׼".Split('|'), "NewDimissionMonth");
        /// <summary>
        /// ��ʼ�� ���ò�����׼  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_NewDimissionMonth()
        {
            return new SearchField(NewDimissionMonth,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� DimissionReasonType
        /// <summary>
        /// ��ְԭ��
        /// </summary>
        public static EmployeeFieldPara DimissionReasonType =
            new EmployeeFieldPara(66, "��ְԭ��", "lzyy|lzyy|��ְԭ��".Split('|'), "DimissionReasonType");
        /// <summary>
        /// ��ʼ�� ��ְԭ��  ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DimissionReasonType()
        {
            return new SearchField(DimissionReasonType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� AnnualMaintainDays
        /// <summary>
        /// ʣ�����
        /// </summary>
        public static EmployeeFieldPara AnnualMaintainDays =
            new EmployeeFieldPara(68, "ʣ�����", "synj|shengyunianjia|ʣ�����".Split('|'), "AnnualMaintainDays");
        /// <summary>
        /// ��ʼ�� ʣ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AnnualMaintainDays()
        {
            return new SearchField(AnnualMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� AdjustMaintainDays
        /// <summary>
        /// ʣ�����
        /// </summary>
        public static EmployeeFieldPara AdjustMaintainDays =
            new EmployeeFieldPara(69, "ʣ�����", "shengyutiaoxiu|sytx|ʣ�����".Split('|'), "AdjustMaintainDays");
        /// <summary>
        /// ��ʼ�� ʣ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AdjustMaintainDays()
        {
            return new SearchField(AdjustMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Age
        /// <summary>
        /// ����
        /// </summary>
        public static EmployeeFieldPara Age =
            new EmployeeFieldPara(70, "����", "nianling|nl|����".Split('|'), "Age");
        /// <summary>
        /// ��ʼ�� ����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Age()
        {
            return new SearchField(Age,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� WorkAgeDecaiml
        /// <summary>
        /// ˾��
        /// </summary>
        public static EmployeeFieldPara WorkAgeDecaiml =
            new EmployeeFieldPara(71, "˾��", "siling|sl|˾��".Split('|'), "WorkAgeString");
        /// <summary>
        /// ��ʼ�� ˾��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkAgeDecaiml()
        {
            return new SearchField(WorkAgeDecaiml,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ProbationStartTime
        /// <summary>
        /// ��������ʼ��
        /// </summary>
        public static EmployeeFieldPara ProbationStartTime =
            new EmployeeFieldPara(72, "��������ʼ��", "siyongqiqishiri|syqqsr|��������ʼ��".Split('|'), "ProbationStartTime");
        /// <summary>
        /// ��ʼ�� ˾��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ProbationStartTime()
        {
            return new SearchField(ProbationStartTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� PositionGrade
        /// <summary>
        /// ְ��
        /// </summary>
        public static EmployeeFieldPara PositionGrade =
            new EmployeeFieldPara(73, "ְ��", "zhiji|zj|ְ��".Split('|'), "PositionGrade");
        /// <summary>
        /// ��ʼ�� ְ��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PositionGrade()
        {
            return new SearchField(PositionGrade,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Skill
        /// <summary>
        /// ����
        /// </summary>
        public static EmployeeFieldPara Skill =
            new EmployeeFieldPara(74, "����", "jineng|jn|����".Split('|'), "Skill");
        /// <summary>
        /// ��ʼ�� ����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Skill()
        {
            return new SearchField(Skill,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }


        #endregion

        /// <summary>
        /// ְϵ
        /// </summary>
        public static EmployeeFieldPara Grades =
          new EmployeeFieldPara(75, "ְϵ", "zx|zhixi|ְϵ".Split('|'), "Grades");

        /// <summary>
        /// ְϵ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Grades()
        {
            return new SearchField(Grades,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ÿ����һ����ѯ�ֶΣ���Ҫά��
        /// <summary>
        /// �жϸ����ֶ��Ƿ���������
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool IsNeedCondition(SearchField searchField, Employee employee)
        {
            #region TextField

            if (searchField.FieldParaBase.Id == ChildName.Id)
            {
                bool breturn1 =
                    ((TextField)searchField.ConditionField).DoCompare(new EmployeeStringValue(employee).ChildName);
                bool breturn2 =
                    ((TextField)searchField.ConditionField).DoCompare(new EmployeeStringValue(employee).ChildName2);
                return breturn1 || breturn2;
            }

            if (searchField.FieldParaBase.Id == DimissionType.Id
                || searchField.FieldParaBase.Id == EmergencyContacts.Id
                || searchField.FieldParaBase.Id == RecordPlace.Id
                || searchField.FieldParaBase.Id == PRPStreet.Id
                || searchField.FieldParaBase.Id == PRPArea.Id
                || searchField.FieldParaBase.Id == PRPPostCode.Id
                || searchField.FieldParaBase.Id == RPRAddress.Id
                || searchField.FieldParaBase.Id == Certificates.Id
                || searchField.FieldParaBase.Id == ForeignLanguageAbility.Id
                || searchField.FieldParaBase.Id == WorkTitle.Id
                || searchField.FieldParaBase.Id == AccumulationFundSupplyAccount.Id
                || searchField.FieldParaBase.Id == AccumulationFundAccount.Id
                || searchField.FieldParaBase.Id == SalaryCardNo.Id
                || searchField.FieldParaBase.Id == EmployeeWelfareDescription.Id
                || searchField.FieldParaBase.Id == ResidencePermitsOrgnaization.Id
                || searchField.FieldParaBase.Id == Responsibility.Id
                || searchField.FieldParaBase.Id == WorkPlace.Id
                || searchField.FieldParaBase.Id == DoorCardNo.Id
                || searchField.FieldParaBase.Id == Leader.Id
                || searchField.FieldParaBase.Id == Major.Id
                || searchField.FieldParaBase.Id == IDCardNo.Id
                || searchField.FieldParaBase.Id == PhysicalConditions.Id
                || searchField.FieldParaBase.Id == NativePlace.Id
                || searchField.FieldParaBase.Id == Nationality.Id
                || searchField.FieldParaBase.Id == LoginName.Id
                || searchField.FieldParaBase.Id == Name.Id
                || searchField.FieldParaBase.Id == EnglishName.Id
                || searchField.FieldParaBase.Id == School.Id
                || searchField.FieldParaBase.Id == FamilyAddress.Id
                || searchField.FieldParaBase.Id == PostCode.Id
                || searchField.FieldParaBase.Id == FamilyPhone.Id
                || searchField.FieldParaBase.Id == MobileNum.Id
                || searchField.FieldParaBase.Id == Email.Id
                || searchField.FieldParaBase.Id == Email2.Id)
            {
                return ((TextField)searchField.ConditionField).DoCompare(GetSearchFieldValue(employee, searchField));
            }

            #endregion

            #region DateTimeField

            DateTime dtTryParseTemp;
            if (searchField.FieldParaBase.Id == ChildBirthday.Id
                || searchField.FieldParaBase.Id == ResidencePermits.Id
                || searchField.FieldParaBase.Id == ProbationTime.Id
                || searchField.FieldParaBase.Id == GraduateTime.Id
                || searchField.FieldParaBase.Id == IDCardDueDate.Id
                || searchField.FieldParaBase.Id == Birthday.Id
                || searchField.FieldParaBase.Id == ComeDate.Id
                || searchField.FieldParaBase.Id == LeaveDate.Id
                || searchField.FieldParaBase.Id == ProbationStartTime.Id)
            {
                return ((DateTimeField)searchField.ConditionField).DoCompare(
                    DateTime.TryParse(GetSearchFieldValue(employee, searchField), out dtTryParseTemp)
                        ? dtTryParseTemp
                        : new DateTime?());
            }

            #endregion

            #region NumField

            decimal dTryParseTemp;
            if (searchField.FieldParaBase.Id == NewDimissionMonth.Id
                || searchField.FieldParaBase.Id == SocietyWorkAge.Id
                || searchField.FieldParaBase.Id == Num.Id
                || searchField.FieldParaBase.Id == Height.Id
                || searchField.FieldParaBase.Id == Weight.Id
                || searchField.FieldParaBase.Id == AnnualMaintainDays.Id
                || searchField.FieldParaBase.Id == AdjustMaintainDays.Id
                || searchField.FieldParaBase.Id == Age.Id)
            {
                return ((NumField)searchField.ConditionField).DoCompare(
                    decimal.TryParse(GetSearchFieldValue(employee, searchField), out dTryParseTemp)
                        ? dTryParseTemp
                        : new decimal?());
            }
            if (searchField.FieldParaBase.Id == WorkAgeDecaiml.Id)
            {
                return ((NumField)searchField.ConditionField).DoCompare(
                    decimal.TryParse(new EmployeeStringValue(employee).WorkAgeDecaiml, out dTryParseTemp)
                        ? dTryParseTemp
                        : new decimal?());
            }

            #endregion

            #region StaticEnumField

            if (searchField.FieldParaBase.Id == DimissionReasonType.Id
                || searchField.FieldParaBase.Id == WorkType.Id
                || searchField.FieldParaBase.Id == EducationalBackground.Id
                || searchField.FieldParaBase.Id == MaritalStatus.Id
                || searchField.FieldParaBase.Id == PoliticalAffiliation.Id
                || searchField.FieldParaBase.Id == Gender.Id
                || searchField.FieldParaBase.Id == EmployeeType.Id
                || searchField.FieldParaBase.Id == PositionGrade.Id)
            {
                return
                    ((StaticEnumField)searchField.ConditionField).DoCompare(GetSearchFieldValue(employee, searchField));
            }

            #endregion

            #region ActiveEnumField

            if (searchField.FieldParaBase.Id == DiyProcessHRPrincipal.Id
                || searchField.FieldParaBase.Id == DiyProcessTraineeApplication.Id
                || searchField.FieldParaBase.Id == DiyProcessAssess.Id
                || searchField.FieldParaBase.Id == DiyProcessApplicationTypeOverTime.Id
                || searchField.FieldParaBase.Id == DiyProcessApplicationTypeOut.Id
                || searchField.FieldParaBase.Id == DiyProcessLeaveRequest.Id
                || searchField.FieldParaBase.Id == CountryNationality.Id
                || searchField.FieldParaBase.Id == Position.Id
                || searchField.FieldParaBase.Id == Company.Id
                || searchField.FieldParaBase.Id == Grades.Id)
            {
                return
                    ((ActiveEnumField)searchField.ConditionField).DoCompare(GetSearchFieldValue(employee, searchField));
            }
            if (searchField.FieldParaBase.Id == Skill.Id)
            {
                string skills = GetSearchFieldValue(employee, searchField);
                if (string.IsNullOrEmpty(skills))
                {
                    return ((ActiveEnumField)searchField.ConditionField).DoCompare(null);
                }
                else
                {
                    foreach (string skill in skills.Split(';'))
                    {
                        if (((ActiveEnumField)searchField.ConditionField).DoCompare(skill))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }

            #endregion

            #region TreeActiveEnumField

            if (searchField.FieldParaBase.Id == Department.Id)
            {
                return
                    employee != null && employee.Account != null && employee.Account.Dept != null &&
                    employee.Account.Dept.Name != null
                        ? ((TreeActiveEnumField)searchField.ConditionField).DoCompare(DepartmentTree,
                                                                                       employee.Account.Dept.Id)
                        : ((TreeActiveEnumField)searchField.ConditionField).DoCompare(null);
            }

            #endregion

            return true; //�Ҳ�������Ϊ��ѯ������Ч��ֱ��ͨ������
        }

        /// <summary>
        /// �������е�EmployeeSearchField
        /// </summary>
        /// <returns></returns>
        public static List<SearchField> GetAllEmployeeSearchField()
        {
            List<SearchField> EmployeeSearchFieldSource = new List<SearchField>();

            #region Account��Ϣ

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Num());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Name());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_LoginName());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Department());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Position());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Grades());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_MobileNum());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Email());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Email2());
            //��Ч��
            //�Ƿ���HRMISϵͳ��Ա

            #endregion

            #region ������Ϣҳ

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_EmployeeType());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Gender());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_EnglishName());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_CountryNationality());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_NativePlace());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Birthday());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Age());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_PoliticalAffiliation());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Nationality());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_MaritalStatus());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_PhysicalConditions());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Height());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Weight());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_IDCardNo());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_IDCardDueDate());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_School());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_GraduateTime());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_EducationalBackground());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Major());

            #endregion

            #region ������Ϣҳ

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ComeDate());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Leader());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Company());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_PositionGrade());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DoorCardNo());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_WorkAgeDecaiml());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_SocietyWorkAge());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_WorkPlace());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DiyProcessLeaveRequest());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DiyProcessApplicationTypeOverTime());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DiyProcessApplicationTypeOut());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DiyProcessAssess());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DiyProcessTraineeApplication());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DiyProcessHRPrincipal());
            //EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Responsibility());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ProbationStartTime());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ProbationTime());
            #endregion

            #region ����ҳ

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_WorkType());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ResidencePermits());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ResidencePermitsOrgnaization());
            //EmployeeSearchFieldSource.Add(InitEmployeeSearchField_EmployeeWelfareDescription());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_SalaryCardNo());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AccumulationFundAccount());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AccumulationFundSupplyAccount());

            #endregion

            #region ����ҳ
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_WorkTitle());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ForeignLanguageAbility());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Certificates());
            #endregion

            #region ��ͥ��Ϣҳ

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_FamilyAddress());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_PostCode());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_FamilyPhone());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_RPRAddress());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_RecordPlace());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_PRPPostCode());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_PRPArea());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_PRPStreet());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_EmergencyContacts());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ChildName());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ChildBirthday());

            #endregion

            #region ��ְ��Ϣҳ

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_LeaveDate());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DimissionType());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DimissionReasonType());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_NewDimissionMonth());

            #endregion

            #region ����ͳ��

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AnnualMaintainDays());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AdjustMaintainDays());

            #endregion

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Skill());

            return EmployeeSearchFieldSource;
        }
        /// <summary>
        /// ���searchField��ֵ
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="searchField"></param>
        /// <returns></returns>
        public static string GetSearchFieldValue(Employee employee, SearchField searchField)
        {
            if (searchField == null)
            {
                return string.Empty;
            }

            #region TextField
            if (searchField.FieldParaBase.Id == Email.Id)
            {
                return
                    new EmployeeStringValue(employee).Email;
            }

            if (searchField.FieldParaBase.Id == Email2.Id)
            {
                return
                    new EmployeeStringValue(employee).Email2;
            }

            if (searchField.FieldParaBase.Id == WorkAgeDecaiml.Id)
            {
                return
                    new EmployeeStringValue(employee).WorkAgeString;
            }

            if (searchField.FieldParaBase.Id == DimissionType.Id)
            {
                return new EmployeeStringValue(employee).DimissionType;
            }

            if (searchField.FieldParaBase.Id == ChildName.Id)
            {
                return new EmployeeStringValue(employee).ChildNameShow;
            }

            if (searchField.FieldParaBase.Id == EmergencyContacts.Id)
            {
                return new EmployeeStringValue(employee).EmergencyContacts;
            }

            if (searchField.FieldParaBase.Id == RecordPlace.Id)
            {
                return new EmployeeStringValue(employee).RecordPlace;
            }

            if (searchField.FieldParaBase.Id == PRPStreet.Id)
            {
                return new EmployeeStringValue(employee).PRPStreet;
            }

            if (searchField.FieldParaBase.Id == PRPArea.Id)
            {
                return new EmployeeStringValue(employee).PRPArea;
            }

            if (searchField.FieldParaBase.Id == PRPPostCode.Id)
            {
                return new EmployeeStringValue(employee).PRPPostCode;
            }

            if (searchField.FieldParaBase.Id == RPRAddress.Id)
            {
                return new EmployeeStringValue(employee).RPRAddress;
            }

            if (searchField.FieldParaBase.Id == Certificates.Id)
            {
                return new EmployeeStringValue(employee).Certificates;
            }

            if (searchField.FieldParaBase.Id == ForeignLanguageAbility.Id)
            {
                return new EmployeeStringValue(employee).ForeignLanguageAbility;
            }

            if (searchField.FieldParaBase.Id == WorkTitle.Id)
            {
                return new EmployeeStringValue(employee).WorkTitle;
            }

            if (searchField.FieldParaBase.Id == AccumulationFundSupplyAccount.Id)
            {
                return new EmployeeStringValue(employee).AccumulationFundSupplyAccount;
            }

            if (searchField.FieldParaBase.Id == AccumulationFundAccount.Id)
            {
                return new EmployeeStringValue(employee).AccumulationFundAccount;
            }

            if (searchField.FieldParaBase.Id == SalaryCardNo.Id)
            {
                return new EmployeeStringValue(employee).SalaryCardNo;
            }

            if (searchField.FieldParaBase.Id == EmployeeWelfareDescription.Id)
            {
                return new EmployeeStringValue(employee).EmployeeWelfareDescription;
            }

            if (searchField.FieldParaBase.Id == ResidencePermitsOrgnaization.Id)
            {
                return new EmployeeStringValue(employee).ResidencePermitsOrgnaization;
            }

            if (searchField.FieldParaBase.Id == Responsibility.Id)
            {
                return new EmployeeStringValue(employee).Responsibility;
            }

            if (searchField.FieldParaBase.Id == WorkPlace.Id)
            {
                return new EmployeeStringValue(employee).WorkPlace;
            }

            if (searchField.FieldParaBase.Id == DoorCardNo.Id)
            {
                return new EmployeeStringValue(employee).DoorCardNo;
            }

            if (searchField.FieldParaBase.Id == Leader.Id)
            {
                return new EmployeeStringValue(employee).Leader;
            }

            if (searchField.FieldParaBase.Id == Major.Id)
            {
                return new EmployeeStringValue(employee).Major;
            }

            if (searchField.FieldParaBase.Id == IDCardNo.Id)
            {
                return new EmployeeStringValue(employee).IDCardNo;
            }

            if (searchField.FieldParaBase.Id == PhysicalConditions.Id)
            {
                return new EmployeeStringValue(employee).PhysicalConditions;
            }

            if (searchField.FieldParaBase.Id == NativePlace.Id)
            {
                return new EmployeeStringValue(employee).NativePlace;
            }

            if (searchField.FieldParaBase.Id == Nationality.Id)
            {
                return new EmployeeStringValue(employee).Nationality;
            }

            if (searchField.FieldParaBase.Id == LoginName.Id)
            {
                return new EmployeeStringValue(employee).LoginName;
            }

            if (searchField.FieldParaBase.Id == Name.Id)
            {
                return new EmployeeStringValue(employee).Name;
            }
            if (searchField.FieldParaBase.Id == EnglishName.Id)
            {
                return new EmployeeStringValue(employee).EnglishName;
            }
            if (searchField.FieldParaBase.Id == School.Id)
            {
                return new EmployeeStringValue(employee).School;
            }
            if (searchField.FieldParaBase.Id == FamilyAddress.Id)
            {
                return new EmployeeStringValue(employee).FamilyAddress;
            }
            if (searchField.FieldParaBase.Id == PostCode.Id)
            {
                return new EmployeeStringValue(employee).PostCode;
            }
            if (searchField.FieldParaBase.Id == FamilyPhone.Id)
            {
                return new EmployeeStringValue(employee).FamilyPhone;
            }
            if (searchField.FieldParaBase.Id == MobileNum.Id)
            {
                return new EmployeeStringValue(employee).MobileNum;
            }

            #endregion

            #region DateTimeField
            if (searchField.FieldParaBase.Id == ProbationStartTime.Id)
            {
                return
                    new EmployeeStringValue(employee).ProbationStartTime;
            }
            if (searchField.FieldParaBase.Id == ChildBirthday.Id)
            {
                return
                    new EmployeeStringValue(employee).ChildBirthdayShow;
            }

            if (searchField.FieldParaBase.Id == ResidencePermits.Id)
            {
                return
                    new EmployeeStringValue(employee).ResidencePermits;


            }

            if (searchField.FieldParaBase.Id == ProbationTime.Id)
            {
                return
                    new EmployeeStringValue(employee).ProbationTime;


            }

            if (searchField.FieldParaBase.Id == GraduateTime.Id)
            {
                return
                    new EmployeeStringValue(employee).GraduateTime;


            }

            if (searchField.FieldParaBase.Id == IDCardDueDate.Id)
            {
                return
                    new EmployeeStringValue(employee).IDCardDueDate;


            }

            if (searchField.FieldParaBase.Id == Birthday.Id)
            {
                return
                    new EmployeeStringValue(employee).Birthday;


            }

            if (searchField.FieldParaBase.Id == ComeDate.Id)
            {
                return
                    new EmployeeStringValue(employee).ComeDate;


            }

            if (searchField.FieldParaBase.Id == LeaveDate.Id)
            {
                return
                    new EmployeeStringValue(employee).LeaveDate;


            }

            #endregion

            #region NumField

            if (searchField.FieldParaBase.Id == Age.Id)
            {
                return
                    new EmployeeStringValue(employee).Age;
            }
            if (searchField.FieldParaBase.Id == NewDimissionMonth.Id)
            {
                return
                    new EmployeeStringValue(employee).NewDimissionMonth;
            }

            if (searchField.FieldParaBase.Id == SocietyWorkAge.Id)
            {
                return
                    new EmployeeStringValue(employee).SocietyWorkAge;


            }

            if (searchField.FieldParaBase.Id == Num.Id)
            {
                return
                    new EmployeeStringValue(employee).Num;


            }

            if (searchField.FieldParaBase.Id == Height.Id)
            {
                return
                    new EmployeeStringValue(employee).Height;


            }

            if (searchField.FieldParaBase.Id == Weight.Id)
            {
                return
                    new EmployeeStringValue(employee).Weight;


            }

            if (searchField.FieldParaBase.Id == AnnualMaintainDays.Id)
            {
                return
                    new EmployeeStringValue(employee).AnnualMaintainDays;


            }

            if (searchField.FieldParaBase.Id == AdjustMaintainDays.Id)
            {
                return
                    new EmployeeStringValue(employee).AdjustMaintainDays;


            }

            #endregion

            #region StaticEnumField

            if (searchField.FieldParaBase.Id == PositionGrade.Id)
            {
                return new EmployeeStringValue(employee).PositionGrade;
            }

            if (searchField.FieldParaBase.Id == DimissionReasonType.Id)
            {
                return new EmployeeStringValue(employee).DimissionReasonType;
            }

            if (searchField.FieldParaBase.Id == WorkType.Id)
            {
                return new EmployeeStringValue(employee).WorkType;
            }

            if (searchField.FieldParaBase.Id == EducationalBackground.Id)
            {
                return new EmployeeStringValue(employee).EducationalBackground;
            }

            if (searchField.FieldParaBase.Id == MaritalStatus.Id)
            {
                return new EmployeeStringValue(employee).MaritalStatus;
            }

            if (searchField.FieldParaBase.Id == PoliticalAffiliation.Id)
            {
                return new EmployeeStringValue(employee).PoliticalAffiliation;
            }

            if (searchField.FieldParaBase.Id == Gender.Id)
            {
                return new EmployeeStringValue(employee).Gender;
            }

            if (searchField.FieldParaBase.Id == EmployeeType.Id)
            {
                return new EmployeeStringValue(employee).EmployeeType;
            }

            #endregion

            #region ActiveEnumField

            if (searchField.FieldParaBase.Id == Skill.Id)
            {
                return new EmployeeStringValue(employee).Skill;
            }

            if (searchField.FieldParaBase.Id == DiyProcessHRPrincipal.Id)
            {
                return new EmployeeStringValue(employee).DiyProcessHRPrincipal;
            }

            if (searchField.FieldParaBase.Id == DiyProcessTraineeApplication.Id)
            {
                return new EmployeeStringValue(employee).DiyProcessTraineeApplication;
            }

            if (searchField.FieldParaBase.Id == DiyProcessAssess.Id)
            {
                return new EmployeeStringValue(employee).DiyProcessAssess;
            }

            if (searchField.FieldParaBase.Id == DiyProcessApplicationTypeOverTime.Id)
            {
                return new EmployeeStringValue(employee).DiyProcessApplicationTypeOverTime;
            }

            if (searchField.FieldParaBase.Id == DiyProcessApplicationTypeOut.Id)
            {
                return new EmployeeStringValue(employee).DiyProcessApplicationTypeOut;
            }

            if (searchField.FieldParaBase.Id == DiyProcessLeaveRequest.Id)
            {
                return new EmployeeStringValue(employee).DiyProcessLeaveRequest;
            }

            if (searchField.FieldParaBase.Id == CountryNationality.Id)
            {
                return new EmployeeStringValue(employee).CountryNationality;
            }

            if (searchField.FieldParaBase.Id == Position.Id)
            {
                return new EmployeeStringValue(employee).Position;
            }
            if (searchField.FieldParaBase.Id == Grades.Id)
            {
                return new EmployeeStringValue(employee).Grades;
            }
            if (searchField.FieldParaBase.Id == Company.Id)
            {
                return new EmployeeStringValue(employee).Company;
            }

            #endregion

            #region TreeActiveEnumField

            if (searchField.FieldParaBase.Id == Department.Id)
            {
                return new EmployeeStringValue(employee).Department;
            }

            #endregion

            return string.Empty;
        }

        #endregion
        #region �����Ż�
        public const string EmployeeBasicInfoPart = "EmployeeBasicInfoPart";
        public const string EmployeeWelfarePart = "EmployeeWelfarePart";
        public const string DiyProcessPart = "DiyProcessPart";
        public const string CountryNationalityPart = "CountryNationalityPart";
        public const string VacationPart = "VacationPart";
        public const string AdjustPart = "AdjustPart";
        public const string SkillPart = "SkillPart";
        /// <summary>
        /// �Ƿ����Ա��������Ϣ
        /// </summary>
        /// <param name="searchFieldList"></param>
        /// <returns></returns>
        /// <param name="partConst"></param>
        public static List<SearchField> GetPartSearchFieldList(List<SearchField> searchFieldList, string partConst)
        {
            List<SearchField> ret = new List<SearchField>();
            foreach (SearchField field in searchFieldList)
            {
                //�Ƿ����Ա��������Ϣ
                if (field.FieldParaBase.Id == AccumulationFundAccount.Id
                    || field.FieldParaBase.Id == AccumulationFundSupplyAccount.Id)
                {
                    if (EmployeeWelfarePart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //�Ƿ�Ҫ����Ա��������Ϣ
                if (field.FieldParaBase.Id == CountryNationality.Id)
                {
                    if (CountryNationalityPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //�Ƿ�Ҫ����Ա���Զ���������Ϣ
                if (field.FieldParaBase.Id == DiyProcessApplicationTypeOut.Id
                    || field.FieldParaBase.Id == DiyProcessApplicationTypeOverTime.Id
                    || field.FieldParaBase.Id == DiyProcessAssess.Id
                    || field.FieldParaBase.Id == DiyProcessHRPrincipal.Id
                    || field.FieldParaBase.Id == DiyProcessLeaveRequest.Id
                    || field.FieldParaBase.Id == DiyProcessTraineeApplication.Id)
                {
                    if (DiyProcessPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //�Ƿ�Ҫ����Ա�������Ϣ
                if (field.FieldParaBase.Id == AnnualMaintainDays.Id)
                {
                    if (VacationPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //�Ƿ�Ҫ����Ա��������Ϣ
                if (field.FieldParaBase.Id == AdjustMaintainDays.Id)
                {
                    if (AdjustPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //�Ƿ�Ҫ����Ա��������Ϣ
                if (field.FieldParaBase.Id == Skill.Id)
                {
                    if (SkillPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                if (partConst == EmployeeBasicInfoPart)
                {
                    ret.Add(field);
                }
            }
            return ret;
        }
        #endregion

        /// <summary>
        /// ���س�ʼ������ϣ����ʾ����������
        /// </summary>
        /// <returns></returns>
        public static List<SearchField> InitialConditionList()
        {
            List<SearchField> returnList = new List<SearchField>();
            returnList.Add(InitEmployeeSearchField_EmployeeType());
            returnList[0].ConditionField.ConditionExpression =
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.NormalEmployee) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.ProbationEmployee) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.PracticeEmployee) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.RetirementHire) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.WorkEmployee);
            returnList.Add(InitEmployeeSearchField_Department());
            returnList.Add(InitEmployeeSearchField_Position());
            returnList.Add(InitEmployeeSearchField_Name());
            returnList.Add(InitEmployeeSearchField_ComeDate());
            return returnList;
        }
        /// <summary>
        /// ���س�ʼ������ϣ����ʾ��������
        /// </summary>
        /// <returns></returns>
        public static List<SearchField> InitialColList()
        {
            List<SearchField> returnList = new List<SearchField>();
            returnList.Add(InitEmployeeSearchField_EmployeeType());
            returnList.Add(InitEmployeeSearchField_Department());
            returnList.Add(InitEmployeeSearchField_Position());
            returnList.Add(InitEmployeeSearchField_Name());
            returnList.Add(InitEmployeeSearchField_ComeDate());
            return returnList;
        }
    }
}


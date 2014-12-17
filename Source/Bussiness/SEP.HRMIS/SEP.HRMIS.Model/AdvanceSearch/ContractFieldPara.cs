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
    public class ContractFieldPara : FieldParaBase
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fieldName"></param>
        /// <param name="abbreviations"></param>
        /// <param name="fieldKey"></param>
        public ContractFieldPara(int id, string fieldName, string[] abbreviations, string fieldKey)
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
        public static ContractFieldPara Name =
            new ContractFieldPara(1, "Ա������", "ygxm|yuangongxingming|Ա������|xm|xingming|����".Split('|'), "Name");
        /// <summary>
        /// ��ʼ�� Ա������ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Name()
        {
            return new SearchField(Name,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�ComeDate
        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public static ContractFieldPara ComeDate =
            new ContractFieldPara(2, "��ְʱ��", "rzsj|ruzhishijian|��ְʱ��".Split('|'), "ComeDate");
        /// <summary>
        /// ��ʼ�� ��ְʱ�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ComeDate()
        {
            return new SearchField(ComeDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�LeaveDate
        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public static ContractFieldPara LeaveDate =
            new ContractFieldPara(3, "��ְʱ��", "lzsj|lizhishijian|��ְʱ��".Split('|'), "LeaveDate");
        /// <summary>
        /// ��ʼ�� ��ְʱ�� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_LeaveDate()
        {
            return new SearchField(LeaveDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�EmployeeType
        /// <summary>
        /// Ա������
        /// </summary>
        public static ContractFieldPara EmployeeType =
            new ContractFieldPara(4, "Ա������", "yglx|yuangongleixing|Ա������".Split('|'), "EmployeeType");
        /// <summary>
        /// ��ʼ�� Ա������ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_EmployeeType()
        {
            return new SearchField(EmployeeType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Department
        /// <summary>
        /// ��������
        /// </summary>
        public static ContractFieldPara Department =
            new ContractFieldPara(5, "��������", "bm|bumen|suoshubumen|ssbm|����|��������".Split('|'), "Department");
        /// <summary>
        /// ��ʼ�� �������� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Department()
        {
            return new SearchField(Department,
                                   new TreeActiveEnumField(EnumCompareType.FuzzyMatchIncludeChild, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Position
        /// <summary>
        /// ְλ
        /// </summary>
        public static ContractFieldPara Position =
            new ContractFieldPara(6, "ְλ", "zw|zhiwei|ְλ".Split('|'), "Position");
        /// <summary>
        /// ��ʼ�� ְλ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Position()
        {
            return new SearchField(Position,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�MobileNum

        /// <summary>
        /// �ֻ�����
        /// </summary>
        public static ContractFieldPara MobileNum =
            new ContractFieldPara(7, "�ֻ�����", "sjhm|shoujihaoma|�ֻ�����".Split('|'), "MobileNum");
        /// <summary>
        /// ��ʼ�� �ֻ����� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_MobileNum()
        {
            return new SearchField(MobileNum,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Company

        /// <summary>
        /// ������˾
        /// </summary>
        public static ContractFieldPara Company =
            new ContractFieldPara(8, "������˾", "ssgs|suoshugongsi|������˾|��˾|gs|gongsi".Split('|'), "Company");
        /// <summary>
        /// ��ʼ�� ������˾ ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Company()
        {
            return new SearchField(Company,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Num

        /// <summary>
        /// ����
        /// </summary>
        public static ContractFieldPara EmployeeNum =
            new ContractFieldPara(9, "����", "gh|gonghao|����".Split('|'), "EmployeeNum");
        /// <summary>
        /// ��ʼ�� ���� ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_EmployeeNum()
        {
            return new SearchField(EmployeeNum,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Email

        /// <summary>
        /// Email
        /// </summary>
        public static ContractFieldPara Email =
            new ContractFieldPara(10, "Email", "Email|email|EMAIL".Split('|'), "Email");
        /// <summary>
        /// ��ʼ�� Email ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Email()
        {
            return new SearchField(Email,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ�Email2

        /// <summary>
        /// Email2
        /// </summary>
        public static ContractFieldPara Email2 =
            new ContractFieldPara(11, "Email2", "Email2|email2|EMAIL2".Split('|'), "Email2");
        /// <summary>
        /// ��ʼ�� Email2 ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Email2()
        {
            return new SearchField(Email,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� Leader
        /// <summary>
        /// ���Ÿ�����  
        /// </summary>
        public static ContractFieldPara Leader =
            new ContractFieldPara(12, "���Ÿ�����", "bmfzr|bumenfuzeren|���Ÿ�����".Split('|'), "Leader");
        /// <summary>
        /// ��ʼ�� ���Ÿ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Leader()
        {
            return new SearchField(Leader,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� SocietyWorkAge
        /// <summary>
        /// ��Ṥ��(��)  
        /// </summary>
        public static ContractFieldPara SocietyWorkAge =
            new ContractFieldPara(13, "��Ṥ��(��)", "shgl|shehuigonglin|��Ṥ��(��)".Split('|'), "SocietyWorkAge");
        /// <summary>
        /// ��ʼ�� �Ž�������   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_SocietyWorkAge()
        {
            return new SearchField(SocietyWorkAge,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region ��ѯ�ֶ� WorkPlace
        /// <summary>
        /// �����ص�
        /// </summary>
        public static ContractFieldPara WorkPlace =
            new ContractFieldPara(14, "�����ص�", "gzdd|gongzuodidian|�����ص�".Split('|'), "WorkPlace");
        /// <summary>
        /// ��ʼ�� �����ص�   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_WorkPlace()
        {
            return new SearchField(WorkPlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ProbationTime
        /// <summary>
        /// �����ڵ�����
        /// </summary>
        public static ContractFieldPara ProbationTime =
            new ContractFieldPara(15, "�����ڵ�����", "syqdqr|shiyongqidaoqiri|�����ڵ�����".Split('|'), "ProbationTime");
        /// <summary>
        /// ��ʼ�� �����ڵ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ProbationTime()
        {
            return new SearchField(ProbationTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� WorkType
        /// <summary>
        /// �ù�����
        /// </summary>
        public static ContractFieldPara WorkType =
            new ContractFieldPara(16, "�ù�����", "ygxz|yonggongxingzhi|�ù�����".Split('|'), "WorkType");
        /// <summary>
        /// ��ʼ�� �ù�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_WorkType()
        {
            return new SearchField(WorkType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� AnnualMaintainDays
        /// <summary>
        /// ʣ�����
        /// </summary>
        public static ContractFieldPara AnnualMaintainDays =
            new ContractFieldPara(17, "ʣ�����", "synj|shengyunianjia|ʣ�����".Split('|'), "AnnualMaintainDays");
        /// <summary>
        /// ��ʼ�� ʣ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_AnnualMaintainDays()
        {
            return new SearchField(AnnualMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� AdjustMaintainDays
        /// <summary>
        /// ʣ�����
        /// </summary>
        public static ContractFieldPara AdjustMaintainDays =
            new ContractFieldPara(18, "ʣ�����", "shengyutiaoxiu|sytx|ʣ�����".Split('|'), "AdjustMaintainDays");
        /// <summary>
        /// ��ʼ�� ʣ�����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_AdjustMaintainDays()
        {
            return new SearchField(AdjustMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� WorkAgeDecaiml
        /// <summary>
        /// ˾��
        /// </summary>
        public static ContractFieldPara WorkAgeDecaiml =
            new ContractFieldPara(19, "˾��", "siling|sl|˾��".Split('|'), "WorkAgeString");
        /// <summary>
        /// ��ʼ�� ˾��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_WorkAgeDecaiml()
        {
            return new SearchField(WorkAgeDecaiml,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� PositionGrade
        /// <summary>
        /// ְ��
        /// </summary>
        public static ContractFieldPara PositionGrade =
            new ContractFieldPara(20, "ְ��", "zhiji|zj|ְ��".Split('|'), "PositionGrade");
        /// <summary>
        /// ��ʼ�� ְ��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_PositionGrade()
        {
            return new SearchField(PositionGrade,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ContractType
        /// <summary>
        /// ��ͬ����
        /// </summary>
        public static ContractFieldPara ContractType =
            new ContractFieldPara(21, "��ͬ����", "hetongleixing|htlx|��ͬ����".Split('|'), "ContractType");
        /// <summary>
        /// ��ʼ�� ��ͬ����   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractType()
        {
            return new SearchField(ContractType,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ContractStartTime
        /// <summary>
        /// ��ͬ��ʼʱ��
        /// </summary>
        public static ContractFieldPara ContractStartTime =
            new ContractFieldPara(22, "��ͬ��ʼʱ��", "hetongkaishishijian|htkssj|��ͬ��ʼʱ��".Split('|'), "ContractStartTime");
        /// <summary>
        /// ��ʼ�� ��ͬ��ʼʱ��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractStartTime()
        {
            return new SearchField(ContractStartTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region ��ѯ�ֶ� ContractEndTime
        /// <summary>
        /// ��ͬ����ʱ��
        /// </summary>
        public static ContractFieldPara ContractEndTime =
            new ContractFieldPara(23, "��ͬ����ʱ��", "hetongjieshushijian|htjssj|��ͬ����ʱ��".Split('|'), "ContractEndTime");
        /// <summary>
        /// ��ʼ�� ��ͬ��ʼʱ��   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractEndTime()
        {
            return new SearchField(ContractEndTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion
        #region ��ѯ�ֶ� ContractNum
        /// <summary>
        /// ��ͬ���
        /// </summary>
        public static ContractFieldPara ContractNum =
            new ContractFieldPara(24, "��ͬ���", "hetongbianhao|htbh|��ͬ���".Split('|'), "ContractNum");
        /// <summary>
        /// ��ʼ�� ��ͬ���   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractNum()
        {
            return new SearchField(ContractNum,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion
        #region ��ѯ�ֶ� Remark
        /// <summary>
        /// ��ע
        /// </summary>
        public static ContractFieldPara Remark =
            new ContractFieldPara(25, "��ע", "beizhu|bz|��ע".Split('|'), "Remark");
        /// <summary>
        /// ��ʼ�� ��ע   ��Ϣ
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Remark()
        {
            return new SearchField(Remark,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #endregion

        #region ÿ����һ����ѯ�ֶΣ���Ҫά��
        /// <summary>
        /// �жϸ����ֶ��Ƿ���������
        /// </summary>
        /// <param name="searchField"></param>
        /// <param name="contract"></param>
        /// <returns></returns>
        public static bool IsNeedCondition(SearchField searchField, Contract contract)
        {
            #region TextField

            if (searchField.FieldParaBase.Id == WorkPlace.Id
                || searchField.FieldParaBase.Id == Leader.Id
                || searchField.FieldParaBase.Id == Name.Id
                || searchField.FieldParaBase.Id == MobileNum.Id
                || searchField.FieldParaBase.Id == Remark.Id)
            {
                return ((TextField)searchField.ConditionField).DoCompare(GetSearchFieldValue(contract, searchField));
            }

            #endregion

            #region DateTimeField

            DateTime dtTryParseTemp;
            if (searchField.FieldParaBase.Id == ProbationTime.Id
                || searchField.FieldParaBase.Id == ComeDate.Id
                || searchField.FieldParaBase.Id == LeaveDate.Id
                || searchField.FieldParaBase.Id == ContractEndTime.Id
                || searchField.FieldParaBase.Id == ContractStartTime.Id)
            {
                return ((DateTimeField)searchField.ConditionField).DoCompare(
                    DateTime.TryParse(GetSearchFieldValue(contract, searchField), out dtTryParseTemp)
                        ? dtTryParseTemp
                        : new DateTime?());
            }

            #endregion

            #region NumField

            decimal dTryParseTemp;
            if (searchField.FieldParaBase.Id == SocietyWorkAge.Id
                || searchField.FieldParaBase.Id == EmployeeNum.Id
                || searchField.FieldParaBase.Id == AnnualMaintainDays.Id
                || searchField.FieldParaBase.Id == AdjustMaintainDays.Id
                || searchField.FieldParaBase.Id == ContractNum.Id)
            {
                return ((NumField)searchField.ConditionField).DoCompare(
                    decimal.TryParse(GetSearchFieldValue(contract, searchField), out dTryParseTemp)
                        ? dTryParseTemp
                        : new decimal?());
            }
            if (searchField.FieldParaBase.Id == WorkAgeDecaiml.Id)
            {
                return ((NumField)searchField.ConditionField).DoCompare(
                    decimal.TryParse(new ContractStringValue(contract).WorkAgeDecaiml, out dTryParseTemp)
                        ? dTryParseTemp
                        : new decimal?());
            }
            #endregion

            #region StaticEnumField

            if (searchField.FieldParaBase.Id == WorkType.Id
                || searchField.FieldParaBase.Id == EmployeeType.Id
                || searchField.FieldParaBase.Id == PositionGrade.Id)
            {
                return
                    ((StaticEnumField)searchField.ConditionField).DoCompare(GetSearchFieldValue(contract, searchField));
            }

            #endregion

            #region ActiveEnumField

            if (searchField.FieldParaBase.Id == Position.Id
                || searchField.FieldParaBase.Id == Company.Id
                || searchField.FieldParaBase.Id == ContractType.Id)
            {
                return
                    ((ActiveEnumField)searchField.ConditionField).DoCompare(GetSearchFieldValue(contract, searchField));
            }
            #endregion

            #region TreeActiveEnumField

            if (searchField.FieldParaBase.Id == Department.Id)
            {
                return
                    contract != null && contract.Employee.Account != null && contract.Employee.Account.Dept != null &&
                    contract.Employee.Account.Dept.Name != null
                        ? ((TreeActiveEnumField)searchField.ConditionField).DoCompare(DepartmentTree,
                                                                                       contract.Employee.Account.Dept.Id)
                        : ((TreeActiveEnumField)searchField.ConditionField).DoCompare(null);
            }

            #endregion

            return true; //�Ҳ�������Ϊ��ѯ������Ч��ֱ��ͨ������
        }

        /// <summary>
        /// �������е�ContractSearchField
        /// </summary>
        /// <returns></returns>
        public static List<SearchField> GetAllContractSearchField()
        {
            List<SearchField> ContractSearchFieldSource = new List<SearchField>();
            #region ��ͬ��Ϣ
            ContractSearchFieldSource.Add(InitContractSearchField_EmployeeNum());
            ContractSearchFieldSource.Add(InitContractSearchField_Name());
            ContractSearchFieldSource.Add(InitContractSearchField_Company());
            ContractSearchFieldSource.Add(InitContractSearchField_Department());
            ContractSearchFieldSource.Add(InitContractSearchField_ContractNum());
            ContractSearchFieldSource.Add(InitContractSearchField_ContractType());
            ContractSearchFieldSource.Add(InitContractSearchField_ContractStartTime());
            ContractSearchFieldSource.Add(InitContractSearchField_ContractEndTime());
            ContractSearchFieldSource.Add(InitContractSearchField_Remark());
            #endregion

            #region Ա����Ϣ
            ContractSearchFieldSource.Add(InitContractSearchField_Position());
            ContractSearchFieldSource.Add(InitContractSearchField_MobileNum());

            ContractSearchFieldSource.Add(InitContractSearchField_EmployeeType());

            ContractSearchFieldSource.Add(InitContractSearchField_ComeDate());
            ContractSearchFieldSource.Add(InitContractSearchField_Leader());
            ContractSearchFieldSource.Add(InitContractSearchField_WorkAgeDecaiml());
            ContractSearchFieldSource.Add(InitContractSearchField_SocietyWorkAge());
            ContractSearchFieldSource.Add(InitContractSearchField_WorkPlace());
            ContractSearchFieldSource.Add(InitContractSearchField_ProbationTime());

            ContractSearchFieldSource.Add(InitContractSearchField_WorkType());

            ContractSearchFieldSource.Add(InitContractSearchField_LeaveDate());

            ContractSearchFieldSource.Add(InitContractSearchField_AnnualMaintainDays());
            ContractSearchFieldSource.Add(InitContractSearchField_AdjustMaintainDays());
            #endregion

            return ContractSearchFieldSource;
        }
        /// <summary>
        /// ���searchField��ֵ
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="searchField"></param>
        /// <returns></returns>
        public static string GetSearchFieldValue(Contract contract, SearchField searchField)
        {
            if (searchField == null)
            {
                return string.Empty;
            }

            #region TextField

            if (searchField.FieldParaBase.Id == Remark.Id)
            {
                return
                    new ContractStringValue(contract).Remark;
            }

            if (searchField.FieldParaBase.Id == WorkAgeDecaiml.Id)
            {
                return
                    new ContractStringValue(contract).WorkAgeString;
            }

            if (searchField.FieldParaBase.Id == WorkPlace.Id)
            {
                return new ContractStringValue(contract).WorkPlace;
            }

            if (searchField.FieldParaBase.Id == Leader.Id)
            {
                return new ContractStringValue(contract).Leader;
            }

            if (searchField.FieldParaBase.Id == Name.Id)
            {
                return new ContractStringValue(contract).Name;
            }
            if (searchField.FieldParaBase.Id == MobileNum.Id)
            {
                return new ContractStringValue(contract).MobileNum;
            }

            #endregion

            #region DateTimeField


            if (searchField.FieldParaBase.Id == ContractEndTime.Id)
            {
                return
                    new ContractStringValue(contract).ContractEndTime;
            }

            if (searchField.FieldParaBase.Id == ContractStartTime.Id)
            {
                return
                    new ContractStringValue(contract).ContractStartTime;
            }

            if (searchField.FieldParaBase.Id == ProbationTime.Id)
            {
                return
                    new ContractStringValue(contract).ProbationTime;


            }

            if (searchField.FieldParaBase.Id == ComeDate.Id)
            {
                return
                    new ContractStringValue(contract).ComeDate;


            }

            if (searchField.FieldParaBase.Id == LeaveDate.Id)
            {
                return
                    new ContractStringValue(contract).LeaveDate;


            }

            #endregion

            #region NumField

            if (searchField.FieldParaBase.Id == ContractNum.Id)
            {
                return
                    new ContractStringValue(contract).SocietyWorkAge;
            }

            if (searchField.FieldParaBase.Id == SocietyWorkAge.Id)
            {
                return
                    new ContractStringValue(contract).SocietyWorkAge;
            }

            if (searchField.FieldParaBase.Id == EmployeeNum.Id)
            {
                return
                    new ContractStringValue(contract).EmployeeNum;
            }

            if (searchField.FieldParaBase.Id == AnnualMaintainDays.Id)
            {
                return
                    new ContractStringValue(contract).AnnualMaintainDays;
            }

            if (searchField.FieldParaBase.Id == AdjustMaintainDays.Id)
            {
                return
                    new ContractStringValue(contract).AdjustMaintainDays;
            }

            #endregion

            #region StaticEnumField

            if (searchField.FieldParaBase.Id == EmployeeType.Id)
            {
                return new ContractStringValue(contract).EmployeeType;
            }

            #endregion

            #region ActiveEnumField

            if (searchField.FieldParaBase.Id == Position.Id)
            {
                return new ContractStringValue(contract).Position;
            }

            if (searchField.FieldParaBase.Id == Company.Id)
            {
                return new ContractStringValue(contract).Company;
            }

            if (searchField.FieldParaBase.Id == ContractType.Id)
            {
                return new ContractStringValue(contract).ContractType;
            }

            #endregion

            #region TreeActiveEnumField

            if (searchField.FieldParaBase.Id == Department.Id)
            {
                return new ContractStringValue(contract).Department;
            }

            #endregion

            return string.Empty;
        }

        #endregion

        #region �����Ż�
        public const string ContractBasicInfoPart = "ContractBasicInfoPart";
        public const string EmployeeBasicInfoPart = "EmployeeBasicInfoPart";
        public const string VacationPart = "VacationPart";
        public const string AdjustPart = "AdjustPart";
        /// <summary>
        /// �Ƿ���partConst�ıȽ��ֶ�
        /// </summary>
        /// <param name="searchFieldList"></param>
        /// <returns></returns>
        /// <param name="partConst"></param>
        public static List<SearchField> GetPartSearchFieldList(List<SearchField> searchFieldList, string partConst)
        {
            List<SearchField> ret = new List<SearchField>();
            foreach (SearchField field in searchFieldList)
            {
                //�Ƿ���Ա�������Ϣ��Ҫ�Ƚ�
                if (field.FieldParaBase.Id == AnnualMaintainDays.Id)
                {
                    if (VacationPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //�Ƿ���Ա��������Ϣ��Ҫ�Ƚ�
                if (field.FieldParaBase.Id == AdjustMaintainDays.Id)
                {
                    if (AdjustPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //�Ƿ���Ա��������Ϣ��Ҫ�Ƚ�
                if (field.FieldParaBase.Id == EmployeeNum.Id
                    || field.FieldParaBase.Id == Name.Id
                    || field.FieldParaBase.Id == Department.Id
                    || field.FieldParaBase.Id == Position.Id
                    || field.FieldParaBase.Id == MobileNum.Id
                    || field.FieldParaBase.Id == EmployeeType.Id
                    || field.FieldParaBase.Id == ComeDate.Id
                    || field.FieldParaBase.Id == Leader.Id
                    || field.FieldParaBase.Id == Company.Id
                    || field.FieldParaBase.Id == WorkAgeDecaiml.Id
                    || field.FieldParaBase.Id == SocietyWorkAge.Id
                    || field.FieldParaBase.Id == WorkPlace.Id
                    || field.FieldParaBase.Id == ProbationTime.Id
                    || field.FieldParaBase.Id == WorkType.Id
                    || field.FieldParaBase.Id == LeaveDate.Id)
                {
                    if (EmployeeBasicInfoPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                if (partConst == ContractBasicInfoPart)
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
            returnList.Add(InitContractSearchField_EmployeeType());
            returnList[0].ConditionField.ConditionExpression =
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.NormalEmployee) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.ProbationEmployee) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.PracticeEmployee) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.RetirementHire) + ";" +
                EmployeeTypeUtility.EmployeeTypeDisplay(EmployeeTypeEnum.WorkEmployee);
            returnList.Add(InitContractSearchField_Department());
            returnList.Add(InitContractSearchField_Position());
            returnList.Add(InitContractSearchField_Name());
            returnList.Add(InitContractSearchField_ComeDate());
            return returnList;
        }
        /// <summary>
        /// ���س�ʼ������ϣ����ʾ��������
        /// </summary>
        /// <returns></returns>
        public static List<SearchField> InitialColList()
        {
            List<SearchField> returnList = new List<SearchField>();
            returnList.Add(InitContractSearchField_ContractType());
            returnList.Add(InitContractSearchField_ContractStartTime());
            returnList.Add(InitContractSearchField_ContractEndTime());
            returnList.Add(InitContractSearchField_Company());
            returnList.Add(InitContractSearchField_Name());
            returnList.Add(InitContractSearchField_Remark());
            return returnList;
        }

    }
}

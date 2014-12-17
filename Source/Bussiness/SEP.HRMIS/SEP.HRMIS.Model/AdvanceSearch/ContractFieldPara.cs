using System;
using System.Collections.Generic;
using AdvancedCondition;
using AdvancedCondition.Enums;
using SEPModel = SEP.Model;

namespace SEP.HRMIS.Model.AdvanceSearch
{
    /// <summary>
    /// 搜索字段
    /// </summary>
    public class ContractFieldPara : FieldParaBase
    {
        /// <summary>
        /// 构造函数
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
        /// 部门树型结构，用于部门数据筛选
        /// </summary>
        public static List<SEPModel.Departments.Department> DepartmentTreeDataSource
        {
            get { return _DepartmentTreeDataSource; }
            set { _DepartmentTreeDataSource = value; }
        }

        /// <summary>
        /// 部门树型结构，用于部门数据筛选
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

        #region 注意，这些字段依次增加，因为ID会依次累加，不可重复

        #region 查询字段Name
        /// <summary>
        /// 员工姓名
        /// </summary>
        public static ContractFieldPara Name =
            new ContractFieldPara(1, "员工姓名", "ygxm|yuangongxingming|员工姓名|xm|xingming|姓名".Split('|'), "Name");
        /// <summary>
        /// 初始化 员工姓名 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Name()
        {
            return new SearchField(Name,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段ComeDate
        /// <summary>
        /// 入职时间
        /// </summary>
        public static ContractFieldPara ComeDate =
            new ContractFieldPara(2, "入职时间", "rzsj|ruzhishijian|入职时间".Split('|'), "ComeDate");
        /// <summary>
        /// 初始化 入职时间 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ComeDate()
        {
            return new SearchField(ComeDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段LeaveDate
        /// <summary>
        /// 离职时间
        /// </summary>
        public static ContractFieldPara LeaveDate =
            new ContractFieldPara(3, "离职时间", "lzsj|lizhishijian|离职时间".Split('|'), "LeaveDate");
        /// <summary>
        /// 初始化 离职时间 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_LeaveDate()
        {
            return new SearchField(LeaveDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段EmployeeType
        /// <summary>
        /// 员工类型
        /// </summary>
        public static ContractFieldPara EmployeeType =
            new ContractFieldPara(4, "员工类型", "yglx|yuangongleixing|员工类型".Split('|'), "EmployeeType");
        /// <summary>
        /// 初始化 员工类型 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_EmployeeType()
        {
            return new SearchField(EmployeeType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Department
        /// <summary>
        /// 所属部门
        /// </summary>
        public static ContractFieldPara Department =
            new ContractFieldPara(5, "所属部门", "bm|bumen|suoshubumen|ssbm|部门|所属部门".Split('|'), "Department");
        /// <summary>
        /// 初始化 所属部门 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Department()
        {
            return new SearchField(Department,
                                   new TreeActiveEnumField(EnumCompareType.FuzzyMatchIncludeChild, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Position
        /// <summary>
        /// 职位
        /// </summary>
        public static ContractFieldPara Position =
            new ContractFieldPara(6, "职位", "zw|zhiwei|职位".Split('|'), "Position");
        /// <summary>
        /// 初始化 职位 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Position()
        {
            return new SearchField(Position,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段MobileNum

        /// <summary>
        /// 手机号码
        /// </summary>
        public static ContractFieldPara MobileNum =
            new ContractFieldPara(7, "手机号码", "sjhm|shoujihaoma|手机号码".Split('|'), "MobileNum");
        /// <summary>
        /// 初始化 手机号码 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_MobileNum()
        {
            return new SearchField(MobileNum,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Company

        /// <summary>
        /// 所属公司
        /// </summary>
        public static ContractFieldPara Company =
            new ContractFieldPara(8, "所属公司", "ssgs|suoshugongsi|所属公司|公司|gs|gongsi".Split('|'), "Company");
        /// <summary>
        /// 初始化 所属公司 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Company()
        {
            return new SearchField(Company,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Num

        /// <summary>
        /// 工号
        /// </summary>
        public static ContractFieldPara EmployeeNum =
            new ContractFieldPara(9, "工号", "gh|gonghao|工号".Split('|'), "EmployeeNum");
        /// <summary>
        /// 初始化 工号 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_EmployeeNum()
        {
            return new SearchField(EmployeeNum,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Email

        /// <summary>
        /// Email
        /// </summary>
        public static ContractFieldPara Email =
            new ContractFieldPara(10, "Email", "Email|email|EMAIL".Split('|'), "Email");
        /// <summary>
        /// 初始化 Email 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Email()
        {
            return new SearchField(Email,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Email2

        /// <summary>
        /// Email2
        /// </summary>
        public static ContractFieldPara Email2 =
            new ContractFieldPara(11, "Email2", "Email2|email2|EMAIL2".Split('|'), "Email2");
        /// <summary>
        /// 初始化 Email2 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Email2()
        {
            return new SearchField(Email,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Leader
        /// <summary>
        /// 部门负责人  
        /// </summary>
        public static ContractFieldPara Leader =
            new ContractFieldPara(12, "部门负责人", "bmfzr|bumenfuzeren|部门负责人".Split('|'), "Leader");
        /// <summary>
        /// 初始化 部门负责人   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Leader()
        {
            return new SearchField(Leader,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 SocietyWorkAge
        /// <summary>
        /// 社会工龄(天)  
        /// </summary>
        public static ContractFieldPara SocietyWorkAge =
            new ContractFieldPara(13, "社会工龄(天)", "shgl|shehuigonglin|社会工龄(天)".Split('|'), "SocietyWorkAge");
        /// <summary>
        /// 初始化 门禁卡卡号   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_SocietyWorkAge()
        {
            return new SearchField(SocietyWorkAge,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段 WorkPlace
        /// <summary>
        /// 工作地点
        /// </summary>
        public static ContractFieldPara WorkPlace =
            new ContractFieldPara(14, "工作地点", "gzdd|gongzuodidian|工作地点".Split('|'), "WorkPlace");
        /// <summary>
        /// 初始化 工作地点   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_WorkPlace()
        {
            return new SearchField(WorkPlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ProbationTime
        /// <summary>
        /// 试用期到期日
        /// </summary>
        public static ContractFieldPara ProbationTime =
            new ContractFieldPara(15, "试用期到期日", "syqdqr|shiyongqidaoqiri|试用期到期日".Split('|'), "ProbationTime");
        /// <summary>
        /// 初始化 试用期到期日   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ProbationTime()
        {
            return new SearchField(ProbationTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 WorkType
        /// <summary>
        /// 用工性质
        /// </summary>
        public static ContractFieldPara WorkType =
            new ContractFieldPara(16, "用工性质", "ygxz|yonggongxingzhi|用工性质".Split('|'), "WorkType");
        /// <summary>
        /// 初始化 用工性质   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_WorkType()
        {
            return new SearchField(WorkType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 AnnualMaintainDays
        /// <summary>
        /// 剩余年假
        /// </summary>
        public static ContractFieldPara AnnualMaintainDays =
            new ContractFieldPara(17, "剩余年假", "synj|shengyunianjia|剩余年假".Split('|'), "AnnualMaintainDays");
        /// <summary>
        /// 初始化 剩余年假   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_AnnualMaintainDays()
        {
            return new SearchField(AnnualMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 AdjustMaintainDays
        /// <summary>
        /// 剩余调休
        /// </summary>
        public static ContractFieldPara AdjustMaintainDays =
            new ContractFieldPara(18, "剩余调休", "shengyutiaoxiu|sytx|剩余调休".Split('|'), "AdjustMaintainDays");
        /// <summary>
        /// 初始化 剩余调休   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_AdjustMaintainDays()
        {
            return new SearchField(AdjustMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 WorkAgeDecaiml
        /// <summary>
        /// 司龄
        /// </summary>
        public static ContractFieldPara WorkAgeDecaiml =
            new ContractFieldPara(19, "司龄", "siling|sl|司龄".Split('|'), "WorkAgeString");
        /// <summary>
        /// 初始化 司龄   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_WorkAgeDecaiml()
        {
            return new SearchField(WorkAgeDecaiml,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 PositionGrade
        /// <summary>
        /// 职级
        /// </summary>
        public static ContractFieldPara PositionGrade =
            new ContractFieldPara(20, "职级", "zhiji|zj|职级".Split('|'), "PositionGrade");
        /// <summary>
        /// 初始化 职级   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_PositionGrade()
        {
            return new SearchField(PositionGrade,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ContractType
        /// <summary>
        /// 合同类型
        /// </summary>
        public static ContractFieldPara ContractType =
            new ContractFieldPara(21, "合同类型", "hetongleixing|htlx|合同类型".Split('|'), "ContractType");
        /// <summary>
        /// 初始化 合同类型   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractType()
        {
            return new SearchField(ContractType,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ContractStartTime
        /// <summary>
        /// 合同开始时间
        /// </summary>
        public static ContractFieldPara ContractStartTime =
            new ContractFieldPara(22, "合同开始时间", "hetongkaishishijian|htkssj|合同开始时间".Split('|'), "ContractStartTime");
        /// <summary>
        /// 初始化 合同开始时间   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractStartTime()
        {
            return new SearchField(ContractStartTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ContractEndTime
        /// <summary>
        /// 合同结束时间
        /// </summary>
        public static ContractFieldPara ContractEndTime =
            new ContractFieldPara(23, "合同结束时间", "hetongjieshushijian|htjssj|合同结束时间".Split('|'), "ContractEndTime");
        /// <summary>
        /// 初始化 合同开始时间   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractEndTime()
        {
            return new SearchField(ContractEndTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion
        #region 查询字段 ContractNum
        /// <summary>
        /// 合同编号
        /// </summary>
        public static ContractFieldPara ContractNum =
            new ContractFieldPara(24, "合同编号", "hetongbianhao|htbh|合同编号".Split('|'), "ContractNum");
        /// <summary>
        /// 初始化 合同编号   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_ContractNum()
        {
            return new SearchField(ContractNum,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion
        #region 查询字段 Remark
        /// <summary>
        /// 备注
        /// </summary>
        public static ContractFieldPara Remark =
            new ContractFieldPara(25, "备注", "beizhu|bz|备注".Split('|'), "Remark");
        /// <summary>
        /// 初始化 备注   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitContractSearchField_Remark()
        {
            return new SearchField(Remark,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #endregion

        #region 每新增一个查询字段，都要维护
        /// <summary>
        /// 判断各类字段是否满足条件
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

            return true; //找不到则认为查询条件无效，直接通过过滤
        }

        /// <summary>
        /// 返回所有的ContractSearchField
        /// </summary>
        /// <returns></returns>
        public static List<SearchField> GetAllContractSearchField()
        {
            List<SearchField> ContractSearchFieldSource = new List<SearchField>();
            #region 合同信息
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

            #region 员工信息
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
        /// 获得searchField的值
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

        #region 检索优化
        public const string ContractBasicInfoPart = "ContractBasicInfoPart";
        public const string EmployeeBasicInfoPart = "EmployeeBasicInfoPart";
        public const string VacationPart = "VacationPart";
        public const string AdjustPart = "AdjustPart";
        /// <summary>
        /// 是否有partConst的比较字段
        /// </summary>
        /// <param name="searchFieldList"></param>
        /// <returns></returns>
        /// <param name="partConst"></param>
        public static List<SearchField> GetPartSearchFieldList(List<SearchField> searchFieldList, string partConst)
        {
            List<SearchField> ret = new List<SearchField>();
            foreach (SearchField field in searchFieldList)
            {
                //是否有员工年假信息需要比较
                if (field.FieldParaBase.Id == AnnualMaintainDays.Id)
                {
                    if (VacationPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //是否有员工调休信息需要比较
                if (field.FieldParaBase.Id == AdjustMaintainDays.Id)
                {
                    if (AdjustPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //是否有员工个人信息需要比较
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
        /// 返回初始化界面希望显示的条件内容
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
        /// 返回初始化界面希望显示的列内容
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

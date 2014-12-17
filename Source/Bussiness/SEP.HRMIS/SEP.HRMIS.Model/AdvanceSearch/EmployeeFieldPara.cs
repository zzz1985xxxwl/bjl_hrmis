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
    public class EmployeeFieldPara : FieldParaBase
    {
        /// <summary>
        /// 构造函数
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
        public static EmployeeFieldPara Name =
            new EmployeeFieldPara(1, "员工姓名", "ygxm|yuangongxingming|员工姓名|xm|xingming|姓名".Split('|'), "Name");
        /// <summary>
        /// 初始化 员工姓名 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Name()
        {
            return new SearchField(Name,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段EnglishName
        /// <summary>
        /// 英文名
        /// </summary>
        public static EmployeeFieldPara EnglishName =
            new EmployeeFieldPara(2, "英文名", "ywm|yingwenming|英文名".Split('|'), "EnglishName");
        /// <summary>
        /// 初始化 英文名 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EnglishName()
        {
            return new SearchField(EnglishName,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段School
        /// <summary>
        /// 毕业院校
        /// </summary>
        public static EmployeeFieldPara School =
            new EmployeeFieldPara(3, "毕业院校", "byyx|biyeyuanxiao|毕业院校".Split('|'), "School");
        /// <summary>
        /// 初始化 毕业院校 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_School()
        {
            return new SearchField(School,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段FamilyAddress
        /// <summary>
        /// 家庭住址
        /// </summary>
        public static EmployeeFieldPara FamilyAddress =
            new EmployeeFieldPara(4, "家庭住址", "jtzz|jiatingzhuzhi|家庭住址|zz|zhuzhi|住址".Split('|'), "FamilyAddress");
        /// <summary>
        /// 初始化家庭住址信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_FamilyAddress()
        {
            return new SearchField(FamilyAddress,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段PostCode
        /// <summary>
        /// 家庭邮编
        /// </summary>
        public static EmployeeFieldPara PostCode =
            new EmployeeFieldPara(5, "家庭邮编", "jtyb|jiatingyoubian|家庭邮编|邮编|youbian|yb".Split('|'), "PostCode");
        /// <summary>
        /// 初始化 家庭邮编 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PostCode()
        {
            return new SearchField(PostCode,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段FamilyPhone
        /// <summary>
        /// 家庭电话
        /// </summary>
        public static EmployeeFieldPara FamilyPhone =
            new EmployeeFieldPara(6, "家庭电话", "jtdh|jiatingdianhua|家庭电话|电话|dianhua|dh".Split('|'), "FamilyPhone");
        /// <summary>
        /// 初始化 家庭邮编 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_FamilyPhone()
        {
            return new SearchField(FamilyPhone,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段ComeDate
        /// <summary>
        /// 入职时间
        /// </summary>
        public static EmployeeFieldPara ComeDate =
            new EmployeeFieldPara(7, "入职时间", "rzsj|ruzhishijian|入职时间".Split('|'), "ComeDate");
        /// <summary>
        /// 初始化 入职时间 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ComeDate()
        {
            return new SearchField(ComeDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段LeaveDate
        /// <summary>
        /// 离职时间
        /// </summary>
        public static EmployeeFieldPara LeaveDate =
            new EmployeeFieldPara(8, "离职时间", "lzsj|lizhishijian|离职时间".Split('|'), "LeaveDate");
        /// <summary>
        /// 初始化 离职时间 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_LeaveDate()
        {
            return new SearchField(LeaveDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Height
        /// <summary>
        /// 身高
        /// </summary>
        public static EmployeeFieldPara Height =
            new EmployeeFieldPara(9, "身高", "sg|shengao|身高".Split('|'), "Height");
        /// <summary>
        /// 初始化 身高 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Height()
        {
            return new SearchField(Height,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Weight
        /// <summary>
        /// 体重
        /// </summary>
        public static EmployeeFieldPara Weight =
            new EmployeeFieldPara(10, "体重", "tz|tizhong|体重".Split('|'), "Weight");
        /// <summary>
        /// 初始化 体重 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Weight()
        {
            return new SearchField(Weight,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段EmployeeType
        /// <summary>
        /// 员工类型
        /// </summary>
        public static EmployeeFieldPara EmployeeType =
            new EmployeeFieldPara(11, "员工类型", "yglx|yuangongleixing|员工类型".Split('|'), "EmployeeType");
        /// <summary>
        /// 初始化 员工类型 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EmployeeType()
        {
            return new SearchField(EmployeeType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Department
        /// <summary>
        /// 所属部门
        /// </summary>
        public static EmployeeFieldPara Department =
            new EmployeeFieldPara(12, "所属部门", "bm|bumen|suoshubumen|ssbm|部门|所属部门".Split('|'), "Department");
        /// <summary>
        /// 初始化 所属部门 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Department()
        {
            return new SearchField(Department,
                                   new TreeActiveEnumField(EnumCompareType.FuzzyMatchIncludeChild, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Position
        /// <summary>
        /// 职位
        /// </summary>
        public static EmployeeFieldPara Position =
            new EmployeeFieldPara(13, "职位", "zw|zhiwei|职位".Split('|'), "Position");
        /// <summary>
        /// 初始化 职位 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Position()
        {
            return new SearchField(Position,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }


        #endregion



        #region 查询字段MobileNum

        /// <summary>
        /// 手机号码
        /// </summary>
        public static EmployeeFieldPara MobileNum =
            new EmployeeFieldPara(14, "手机号码", "sjhm|shoujihaoma|手机号码".Split('|'), "MobileNum");
        /// <summary>
        /// 初始化 手机号码 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_MobileNum()
        {
            return new SearchField(MobileNum,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Company

        /// <summary>
        /// 所属公司
        /// </summary>
        public static EmployeeFieldPara Company =
            new EmployeeFieldPara(15, "所属公司", "ssgs|suoshugongsi|所属公司|公司|gs|gongsi".Split('|'), "Company");
        /// <summary>
        /// 初始化 所属公司 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Company()
        {
            return new SearchField(Company,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Num

        /// <summary>
        /// 工号
        /// </summary>
        public static EmployeeFieldPara Num =
            new EmployeeFieldPara(16, "工号", "gh|gonghao|工号".Split('|'), "Num");
        /// <summary>
        /// 初始化 工号 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Num()
        {
            return new SearchField(Num,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段LoginName

        /// <summary>
        /// 登录名
        /// </summary>
        public static EmployeeFieldPara LoginName =
            new EmployeeFieldPara(17, "登录名", "dlm|dengluming|登录名".Split('|'), "LoginName");
        /// <summary>
        /// 初始化 登录名 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_LoginName()
        {
            return new SearchField(LoginName,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Email

        /// <summary>
        /// Email
        /// </summary>
        public static EmployeeFieldPara Email =
            new EmployeeFieldPara(18, "Email", "Email|email|EMAIL".Split('|'), "Email");
        /// <summary>
        /// 初始化 Email 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Email()
        {
            return new SearchField(Email,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段Email2

        /// <summary>
        /// Email2
        /// </summary>
        public static EmployeeFieldPara Email2 =
            new EmployeeFieldPara(19, "Email2", "Email2|email2|EMAIL2".Split('|'), "Email2");
        /// <summary>
        /// 初始化 Email2 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Email2()
        {
            return new SearchField(Email2,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Gender
        /// <summary>
        /// 性别
        /// </summary>
        public static EmployeeFieldPara Gender =
            new EmployeeFieldPara(20, "性别", "xb|xingbie|性别".Split('|'), "Gender");
        /// <summary>
        /// 初始化 性别 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Gender()
        {
            return new SearchField(Gender,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 CountryNationality
        /// <summary>
        /// 国籍
        /// </summary>
        public static EmployeeFieldPara CountryNationality =
            new EmployeeFieldPara(21, "国籍", "gj|guoji|国籍".Split('|'), "CountryNationality");
        /// <summary>
        /// 初始化 国籍 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_CountryNationality()
        {
            return new SearchField(CountryNationality,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Nationality
        /// <summary>
        /// 民族
        /// </summary>
        public static EmployeeFieldPara Nationality =
            new EmployeeFieldPara(22, "民族", "mz|mingzu|民族".Split('|'), "Nationality");
        /// <summary>
        /// 初始化 民族 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Nationality()
        {
            return new SearchField(Nationality,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Birthday
        /// <summary>
        /// 出生年月
        /// </summary>
        public static EmployeeFieldPara Birthday =
            new EmployeeFieldPara(23, "出生年月", "csny|chushengnianyue|出生年月".Split('|'), "Birthday");
        /// <summary>
        /// 初始化 出生年月 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Birthday()
        {
            return new SearchField(Birthday,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 PoliticalAffiliation
        /// <summary>
        /// 政治面貌
        /// </summary>
        public static EmployeeFieldPara PoliticalAffiliation =
            new EmployeeFieldPara(24, "政治面貌", "zzmm|zhengzhimianmao|政治面貌".Split('|'), "PoliticalAffiliation");
        /// <summary>
        /// 初始化 政治面貌 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PoliticalAffiliation()
        {
            return new SearchField(PoliticalAffiliation,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 NativePlace
        /// <summary>
        /// 籍贯
        /// </summary>
        public static EmployeeFieldPara NativePlace =
            new EmployeeFieldPara(25, "籍贯", "jg|jiguan|籍贯".Split('|'), "NativePlace");
        /// <summary>
        /// 初始化 籍贯 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_NativePlace()
        {
            return new SearchField(NativePlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 MaritalStatus
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public static EmployeeFieldPara MaritalStatus =
            new EmployeeFieldPara(26, "婚姻状况", "hyzk|hunyinzhuangkuang|婚姻状况".Split('|'), "MaritalStatus");
        /// <summary>
        /// 初始化 婚姻状况 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_MaritalStatus()
        {
            return new SearchField(MaritalStatus,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 PhysicalConditions
        /// <summary>
        /// 健康状况
        /// </summary>
        public static EmployeeFieldPara PhysicalConditions =
            new EmployeeFieldPara(27, "健康状况", "jkzk|jiankangzhuangkuang|健康状况".Split('|'), "PhysicalConditions");
        /// <summary>
        /// 初始化 健康状况 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PhysicalConditions()
        {
            return new SearchField(PhysicalConditions,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 IDCard
        /// <summary>
        /// 证件号码 
        /// </summary>
        public static EmployeeFieldPara IDCardNo =
            new EmployeeFieldPara(28, "证件号码", "zjhm|zhengjianhaoma|证件号码".Split('|'), "IDCardNo");
        /// <summary>
        /// 初始化 证件号码  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_IDCardNo()
        {
            return new SearchField(IDCardNo,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 IDCardDueDate
        /// <summary>
        /// 证件有效期 
        /// </summary>
        public static EmployeeFieldPara IDCardDueDate =
            new EmployeeFieldPara(29, "证件有效期", "zjyxq|zhengjianyouxiaoqi|证件有效期".Split('|'), "IDCardDueDate");
        /// <summary>
        /// 初始化 证件有效期  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_IDCardDueDate()
        {
            return new SearchField(IDCardDueDate,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 GraduateTime
        /// <summary>
        /// 毕业时间 
        /// </summary>
        public static EmployeeFieldPara GraduateTime =
            new EmployeeFieldPara(30, "毕业时间", "bysj|biyeshijian|毕业时间".Split('|'), "GraduateTime");
        /// <summary>
        /// 初始化 毕业时间  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_GraduateTime()
        {
            return new SearchField(GraduateTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 EducationalBackground
        /// <summary>
        /// 文化程度  
        /// </summary>
        public static EmployeeFieldPara EducationalBackground =
            new EmployeeFieldPara(31, "文化程度", "whcd|wenhuachengdu|文化程度".Split('|'), "EducationalBackground");
        /// <summary>
        /// 初始化 文化程度   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EducationalBackground()
        {
            return new SearchField(EducationalBackground,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Major
        /// <summary>
        /// 专业  
        /// </summary>
        public static EmployeeFieldPara Major =
            new EmployeeFieldPara(32, "专业", "zy|zhuanye|专业".Split('|'), "Major");
        /// <summary>
        /// 初始化 专业   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Major()
        {
            return new SearchField(Major,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Leader
        /// <summary>
        /// 部门负责人  
        /// </summary>
        public static EmployeeFieldPara Leader =
            new EmployeeFieldPara(33, "部门负责人", "bmfzr|bumenfuzeren|部门负责人".Split('|'), "Leader");
        /// <summary>
        /// 初始化 部门负责人   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Leader()
        {
            return new SearchField(Leader,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DoorCardNo
        /// <summary>
        /// 门禁卡卡号  
        /// </summary>
        public static EmployeeFieldPara DoorCardNo =
            new EmployeeFieldPara(35, "门禁卡卡号", "mjkkh|menjinkakahao|门禁卡卡号".Split('|'), "DoorCardNo");
        /// <summary>
        /// 初始化 门禁卡卡号   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DoorCardNo()
        {
            return new SearchField(DoorCardNo,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 SocietyWorkAge
        /// <summary>
        /// 社会工龄(天)  
        /// </summary>
        public static EmployeeFieldPara SocietyWorkAge =
            new EmployeeFieldPara(36, "社会工龄(天)", "shgl|shehuigonglin|社会工龄(天)".Split('|'), "SocietyWorkAge");
        /// <summary>
        /// 初始化 门禁卡卡号   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_SocietyWorkAge()
        {
            return new SearchField(SocietyWorkAge,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }
        #endregion

        #region 查询字段 WorkPlace
        /// <summary>
        /// 工作地点
        /// </summary>
        public static EmployeeFieldPara WorkPlace =
            new EmployeeFieldPara(37, "工作地点", "gzdd|gongzuodidian|工作地点".Split('|'), "WorkPlace");
        /// <summary>
        /// 初始化 工作地点   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkPlace()
        {
            return new SearchField(WorkPlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DiyProcessLeaveRequest
        /// <summary>
        /// 请假流程
        /// </summary>
        public static EmployeeFieldPara DiyProcessLeaveRequest =
            new EmployeeFieldPara(38, "请假流程", "qjlc|qingjialiucheng|请假流程".Split('|'), "DiyProcessLeaveRequest");
        /// <summary>
        /// 初始化 请假流程   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessLeaveRequest()
        {
            return new SearchField(DiyProcessLeaveRequest,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DiyProcessApplicationTypeOut
        /// <summary>
        /// 外出申请流程
        /// </summary>
        public static EmployeeFieldPara DiyProcessApplicationTypeOut =
            new EmployeeFieldPara(39, "外出申请流程", "wcsqliuchen|waichushenqingliucheng|外出申请流程".Split('|'), "DiyProcessApplicationTypeOut");
        /// <summary>
        /// 初始化 外出申请流程   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessApplicationTypeOut()
        {
            return new SearchField(DiyProcessApplicationTypeOut,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DiyProcessApplicationTypeOverTime
        /// <summary>
        /// 加班申请流程
        /// </summary>
        public static EmployeeFieldPara DiyProcessApplicationTypeOverTime =
            new EmployeeFieldPara(40, "加班申请流程", "jiabanshengqingliucheng|jbsqlc|加班申请流程".Split('|'), "DiyProcessApplicationTypeOverTime");
        /// <summary>
        /// 初始化 加班申请流程   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessApplicationTypeOverTime()
        {
            return new SearchField(DiyProcessApplicationTypeOverTime,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DiyProcessAssess
        /// <summary>
        /// 绩效考核流程
        /// </summary>
        public static EmployeeFieldPara DiyProcessAssess =
            new EmployeeFieldPara(41, "绩效考核流程", "jxkhlc|jixiaokaoheliucheng|绩效考核流程".Split('|'), "DiyProcessAssess");
        /// <summary>
        /// 初始化 加班申请流程   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessAssess()
        {
            return new SearchField(DiyProcessAssess,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DiyProcessTraineeApplication
        /// <summary>
        /// 培训申请流程
        /// </summary>
        public static EmployeeFieldPara DiyProcessTraineeApplication =
            new EmployeeFieldPara(42, "培训申请流程", "pxsqlc|peixunshenqingliucheng|培训申请流程".Split('|'), "DiyProcessTraineeApplication");
        /// <summary>
        /// 初始化 培训申请流程   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessTraineeApplication()
        {
            return new SearchField(DiyProcessTraineeApplication,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DiyProcessHRPrincipal
        /// <summary>
        /// 人事负责人
        /// </summary>
        public static EmployeeFieldPara DiyProcessHRPrincipal =
            new EmployeeFieldPara(43, "人事负责人", "rsfzr|renshifuzeren|人事负责人".Split('|'), "DiyProcessHRPrincipal");
        /// <summary>
        /// 初始化 培训申请流程   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DiyProcessHRPrincipal()
        {
            return new SearchField(DiyProcessHRPrincipal,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Responsibility
        /// <summary>
        /// 工作职责
        /// </summary>
        public static EmployeeFieldPara Responsibility =
            new EmployeeFieldPara(44, "工作职责", "gzzz|gongzuozhize|工作职责".Split('|'), "Responsibility");
        /// <summary>
        /// 初始化 工作职责   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Responsibility()
        {
            return new SearchField(Responsibility,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ProbationTime
        /// <summary>
        /// 试用期到期日
        /// </summary>
        public static EmployeeFieldPara ProbationTime =
            new EmployeeFieldPara(45, "试用期到期日", "syqdqr|shiyongqidaoqiri|试用期到期日".Split('|'), "ProbationTime");
        /// <summary>
        /// 初始化 试用期到期日   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ProbationTime()
        {
            return new SearchField(ProbationTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 WorkType
        /// <summary>
        /// 用工性质
        /// </summary>
        public static EmployeeFieldPara WorkType =
            new EmployeeFieldPara(46, "用工性质", "ygxz|yonggongxingzhi|用工性质".Split('|'), "WorkType");
        /// <summary>
        /// 初始化 用工性质   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkType()
        {
            return new SearchField(WorkType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ResidencePermits
        /// <summary>
        /// 居住证到期日
        /// </summary>
        public static EmployeeFieldPara ResidencePermits =
            new EmployeeFieldPara(47, "居住证到期日", "jzzdqr|juzhuzhengdaoqiri|居住证到期日".Split('|'), "ResidencePermits");
        /// <summary>
        /// 初始化 居住证到期日   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ResidencePermits()
        {
            return new SearchField(ResidencePermits,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ResidencePermitsOrgnaization
        /// <summary>
        /// 居住证办理机构
        /// </summary>
        public static EmployeeFieldPara ResidencePermitsOrgnaization =
            new EmployeeFieldPara(48, "居住证办理机构", "jzzbljg|juzhuzhengbanlijigou|居住证办理机构".Split('|'), "ResidencePermitsOrgnaization");
        /// <summary>
        /// 初始化 居住证办理机构   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ResidencePermitsOrgnaization()
        {
            return new SearchField(ResidencePermitsOrgnaization,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 EmployeeWelfareDescription
        /// <summary>
        /// 福利描述 
        /// </summary>
        public static EmployeeFieldPara EmployeeWelfareDescription =
            new EmployeeFieldPara(49, "福利描述", "flms|fulimiaoshu|福利描述".Split('|'), "EmployeeWelfareDescription");
        /// <summary>
        /// 初始化 福利描述    信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EmployeeWelfareDescription()
        {
            return new SearchField(EmployeeWelfareDescription,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 SalaryCardNo
        /// <summary>
        /// 工资卡帐号 
        /// </summary>
        public static EmployeeFieldPara SalaryCardNo =
            new EmployeeFieldPara(50, "工资卡帐号", "gzkzh|gongzikazhanghao|工资卡帐号".Split('|'), "SalaryCardNo");
        /// <summary>
        /// 初始化 福利描述    信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_SalaryCardNo()
        {
            return new SearchField(SalaryCardNo,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 AccumulationFundAccount
        /// <summary>
        /// 公积金帐号 
        /// </summary>
        public static EmployeeFieldPara AccumulationFundAccount =
            new EmployeeFieldPara(51, "公积金帐号", "gjjzh|gongjijinzhanghao|公积金帐号".Split('|'), "AccumulationFundAccount");
        /// <summary>
        /// 初始化 福利描述 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AccumulationFundAccount()
        {
            return new SearchField(AccumulationFundAccount,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 AccumulationFundSupplyAccount
        /// <summary>
        /// 补充公积金帐号 
        /// </summary>
        public static EmployeeFieldPara AccumulationFundSupplyAccount =
            new EmployeeFieldPara(52, "补充公积金帐号", "bcgjjzh|buchonggongjijinzhanghao|补充公积金帐号".Split('|'), "AccumulationFundSupplyAccount");
        /// <summary>
        /// 初始化 补充公积金帐号 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AccumulationFundSupplyAccount()
        {
            return new SearchField(AccumulationFundSupplyAccount,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 WorkTitle
        /// <summary>
        /// 职称 
        /// </summary>
        public static EmployeeFieldPara WorkTitle =
            new EmployeeFieldPara(53, "职称", "zc|zhicheng|职称".Split('|'), "WorkTitle");
        /// <summary>
        /// 初始化 职称 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkTitle()
        {
            return new SearchField(WorkTitle,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ForeignLanguageAbility
        /// <summary>
        /// 外语能力 
        /// </summary>
        public static EmployeeFieldPara ForeignLanguageAbility =
            new EmployeeFieldPara(54, "外语能力", "wynl|waiyunengli|外语能力".Split('|'), "ForeignLanguageAbility");
        /// <summary>
        /// 初始化 外语能力 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ForeignLanguageAbility()
        {
            return new SearchField(ForeignLanguageAbility,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Certificates
        /// <summary>
        /// 证书 
        /// </summary>
        public static EmployeeFieldPara Certificates =
            new EmployeeFieldPara(55, "证书", "zs|zhengshu|证书".Split('|'), "Certificates");
        /// <summary>
        /// 初始化 证书 信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Certificates()
        {
            return new SearchField(Certificates,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 RPRAddress
        /// <summary>
        /// 户口地址  
        /// </summary>
        public static EmployeeFieldPara RPRAddress =
            new EmployeeFieldPara(56, "户口地址", "hkdz|hukoudizhi|户口地址".Split('|'), "RPRAddress");
        /// <summary>
        /// 初始化 户口地址  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_RPRAddress()
        {
            return new SearchField(RPRAddress,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 PRPPostCode
        /// <summary>
        /// 户口邮编
        /// </summary>
        public static EmployeeFieldPara PRPPostCode =
            new EmployeeFieldPara(57, "户口邮编", "hkyb|hukouyoubian|户口邮编|邮编|youbian|yb".Split('|'), "PRPPostCode");
        /// <summary>
        /// 初始化 户口邮编  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PRPPostCode()
        {
            return new SearchField(PRPPostCode,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 PRPPostCode
        /// <summary>
        /// 户口所属区域
        /// </summary>
        public static EmployeeFieldPara PRPArea =
            new EmployeeFieldPara(58, "户口所属区域", "hkssqy|hukousuoshuquyu|户口所属区域".Split('|'), "PRPArea");
        /// <summary>
        /// 初始化 户口所属区域  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PRPArea()
        {
            return new SearchField(PRPArea,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 PRPStreet
        /// <summary>
        /// 户口所属街道
        /// </summary>
        public static EmployeeFieldPara PRPStreet =
            new EmployeeFieldPara(59, "户口所属街道", "hkssjd|hukousuoshujiedao|户口所属街道".Split('|'), "PRPStreet");
        /// <summary>
        /// 初始化 户口所属街道  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PRPStreet()
        {
            return new SearchField(PRPStreet,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 RecordPlace
        /// <summary>
        /// 档案所在地
        /// </summary>
        public static EmployeeFieldPara RecordPlace =
            new EmployeeFieldPara(60, "档案所在地", "daszd|dangansuozaidi|档案所在地".Split('|'), "RecordPlace");
        /// <summary>
        /// 初始化 档案所在地  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_RecordPlace()
        {
            return new SearchField(RecordPlace,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 EmergencyContacts
        /// <summary>
        /// 紧急联系人
        /// </summary>
        public static EmployeeFieldPara EmergencyContacts =
            new EmployeeFieldPara(61, "紧急联系人", "jjlxr|jinjilianxiren|紧急联系人".Split('|'), "EmergencyContacts");
        /// <summary>
        /// 初始化 紧急联系人  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_EmergencyContacts()
        {
            return new SearchField(EmergencyContacts,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ChildName
        /// <summary>
        /// 孩子姓名
        /// </summary>
        public static EmployeeFieldPara ChildName =
            new EmployeeFieldPara(62, "孩子姓名", "hzmz|haizimingzi|孩子姓名".Split('|'), "ChildNameShow");
        /// <summary>
        /// 初始化 孩子姓名  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ChildName()
        {
            return new SearchField(ChildName,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ChildBirthday
        /// <summary>
        /// 孩子出生年月
        /// </summary>
        public static EmployeeFieldPara ChildBirthday =
            new EmployeeFieldPara(63, "孩子出生年月", "hzcsny|haizichushengnianyue|孩子出生年月".Split('|'), "ChildBirthdayShow");
        /// <summary>
        /// 初始化 孩子出生年月  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ChildBirthday()
        {
            return new SearchField(ChildBirthday,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DimissionType
        /// <summary>
        /// 离职类型
        /// </summary>
        public static EmployeeFieldPara DimissionType =
            new EmployeeFieldPara(64, "离职类型", "lzlx|lizhileixing|离职类型".Split('|'), "DimissionType");
        /// <summary>
        /// 初始化 离职类型  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DimissionType()
        {
            return new SearchField(DimissionType,
                                   new TextField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 NewDimissionMonth
        /// <summary>
        /// 经济补偿标准
        /// </summary>
        public static EmployeeFieldPara NewDimissionMonth =
            new EmployeeFieldPara(65, "经济补偿标准", "jjbcbz|jingjibuchangbiaozhun|经济补偿标准".Split('|'), "NewDimissionMonth");
        /// <summary>
        /// 初始化 经济补偿标准  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_NewDimissionMonth()
        {
            return new SearchField(NewDimissionMonth,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 DimissionReasonType
        /// <summary>
        /// 离职原因
        /// </summary>
        public static EmployeeFieldPara DimissionReasonType =
            new EmployeeFieldPara(66, "离职原因", "lzyy|lzyy|离职原因".Split('|'), "DimissionReasonType");
        /// <summary>
        /// 初始化 离职原因  信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_DimissionReasonType()
        {
            return new SearchField(DimissionReasonType,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 AnnualMaintainDays
        /// <summary>
        /// 剩余年假
        /// </summary>
        public static EmployeeFieldPara AnnualMaintainDays =
            new EmployeeFieldPara(68, "剩余年假", "synj|shengyunianjia|剩余年假".Split('|'), "AnnualMaintainDays");
        /// <summary>
        /// 初始化 剩余年假   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AnnualMaintainDays()
        {
            return new SearchField(AnnualMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 AdjustMaintainDays
        /// <summary>
        /// 剩余调休
        /// </summary>
        public static EmployeeFieldPara AdjustMaintainDays =
            new EmployeeFieldPara(69, "剩余调休", "shengyutiaoxiu|sytx|剩余调休".Split('|'), "AdjustMaintainDays");
        /// <summary>
        /// 初始化 剩余调休   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_AdjustMaintainDays()
        {
            return new SearchField(AdjustMaintainDays,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Age
        /// <summary>
        /// 年龄
        /// </summary>
        public static EmployeeFieldPara Age =
            new EmployeeFieldPara(70, "年龄", "nianling|nl|年龄".Split('|'), "Age");
        /// <summary>
        /// 初始化 年龄   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Age()
        {
            return new SearchField(Age,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 WorkAgeDecaiml
        /// <summary>
        /// 司龄
        /// </summary>
        public static EmployeeFieldPara WorkAgeDecaiml =
            new EmployeeFieldPara(71, "司龄", "siling|sl|司龄".Split('|'), "WorkAgeString");
        /// <summary>
        /// 初始化 司龄   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_WorkAgeDecaiml()
        {
            return new SearchField(WorkAgeDecaiml,
                                   new NumField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 ProbationStartTime
        /// <summary>
        /// 试用期起始日
        /// </summary>
        public static EmployeeFieldPara ProbationStartTime =
            new EmployeeFieldPara(72, "试用期起始日", "siyongqiqishiri|syqqsr|试用期起始日".Split('|'), "ProbationStartTime");
        /// <summary>
        /// 初始化 司龄   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_ProbationStartTime()
        {
            return new SearchField(ProbationStartTime,
                                   new DateTimeField(EnumCompareType.InScope, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 PositionGrade
        /// <summary>
        /// 职级
        /// </summary>
        public static EmployeeFieldPara PositionGrade =
            new EmployeeFieldPara(73, "职级", "zhiji|zj|职级".Split('|'), "PositionGrade");
        /// <summary>
        /// 初始化 职级   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_PositionGrade()
        {
            return new SearchField(PositionGrade,
                                   new StaticEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 查询字段 Skill
        /// <summary>
        /// 技能
        /// </summary>
        public static EmployeeFieldPara Skill =
            new EmployeeFieldPara(74, "技能", "jineng|jn|技能".Split('|'), "Skill");
        /// <summary>
        /// 初始化 技能   信息
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Skill()
        {
            return new SearchField(Skill,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }


        #endregion

        /// <summary>
        /// 职系
        /// </summary>
        public static EmployeeFieldPara Grades =
          new EmployeeFieldPara(75, "职系", "zx|zhixi|职系".Split('|'), "Grades");

        /// <summary>
        /// 职系
        /// </summary>
        /// <returns></returns>
        public static SearchField InitEmployeeSearchField_Grades()
        {
            return new SearchField(Grades,
                                   new ActiveEnumField(EnumCompareType.FuzzyMatch, "", false, EnumCollectedType.And));
        }

        #endregion

        #region 每新增一个查询字段，都要维护
        /// <summary>
        /// 判断各类字段是否满足条件
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

            return true; //找不到则认为查询条件无效，直接通过过滤
        }

        /// <summary>
        /// 返回所有的EmployeeSearchField
        /// </summary>
        /// <returns></returns>
        public static List<SearchField> GetAllEmployeeSearchField()
        {
            List<SearchField> EmployeeSearchFieldSource = new List<SearchField>();

            #region Account信息

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Num());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Name());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_LoginName());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Department());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Position());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Grades());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_MobileNum());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Email());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Email2());
            //有效性
            //是否是HRMIS系统成员

            #endregion

            #region 基本信息页

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

            #region 工作信息页

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

            #region 福利页

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_WorkType());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ResidencePermits());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ResidencePermitsOrgnaization());
            //EmployeeSearchFieldSource.Add(InitEmployeeSearchField_EmployeeWelfareDescription());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_SalaryCardNo());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AccumulationFundAccount());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AccumulationFundSupplyAccount());

            #endregion

            #region 简历页
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_WorkTitle());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_ForeignLanguageAbility());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Certificates());
            #endregion

            #region 家庭信息页

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

            #region 离职信息页

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_LeaveDate());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DimissionType());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_DimissionReasonType());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_NewDimissionMonth());

            #endregion

            #region 考勤统计

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AnnualMaintainDays());
            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_AdjustMaintainDays());

            #endregion

            EmployeeSearchFieldSource.Add(InitEmployeeSearchField_Skill());

            return EmployeeSearchFieldSource;
        }
        /// <summary>
        /// 获得searchField的值
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
        #region 检索优化
        public const string EmployeeBasicInfoPart = "EmployeeBasicInfoPart";
        public const string EmployeeWelfarePart = "EmployeeWelfarePart";
        public const string DiyProcessPart = "DiyProcessPart";
        public const string CountryNationalityPart = "CountryNationalityPart";
        public const string VacationPart = "VacationPart";
        public const string AdjustPart = "AdjustPart";
        public const string SkillPart = "SkillPart";
        /// <summary>
        /// 是否加载员工福利信息
        /// </summary>
        /// <param name="searchFieldList"></param>
        /// <returns></returns>
        /// <param name="partConst"></param>
        public static List<SearchField> GetPartSearchFieldList(List<SearchField> searchFieldList, string partConst)
        {
            List<SearchField> ret = new List<SearchField>();
            foreach (SearchField field in searchFieldList)
            {
                //是否加载员工福利信息
                if (field.FieldParaBase.Id == AccumulationFundAccount.Id
                    || field.FieldParaBase.Id == AccumulationFundSupplyAccount.Id)
                {
                    if (EmployeeWelfarePart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //是否要加载员工国籍信息
                if (field.FieldParaBase.Id == CountryNationality.Id)
                {
                    if (CountryNationalityPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //是否要加载员工自定义流程信息
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
                //是否要加载员工年假信息
                if (field.FieldParaBase.Id == AnnualMaintainDays.Id)
                {
                    if (VacationPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //是否要加载员工调休信息
                if (field.FieldParaBase.Id == AdjustMaintainDays.Id)
                {
                    if (AdjustPart == partConst)
                    {
                        ret.Add(field);
                    }
                    continue;
                }
                //是否要加载员工技能信息
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
        /// 返回初始化界面希望显示的条件内容
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
        /// 返回初始化界面希望显示的列内容
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


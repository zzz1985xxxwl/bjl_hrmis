using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation
{
    public interface IBasicInfoView
    {   
        /// <summary>
        /// 中文名
        /// <summary>
        string EmployeeName { get; set;}
        /// <summary>
        /// 部门
        /// <summary>
        string DepartmentName { set;}
        /// <summary>
        /// 职位
        /// <summary>
        string PositionName { set;}
        /// <summary>
        /// 邮箱地址
        /// <summary>
        string Email1 { get; set;}
        /// <summary>
        /// 邮箱地址2
        /// </summary>
        string Email2 { get; set;}
        /// <summary>
        /// 籍贯
        /// </summary>
        string NativePlace { get; set;}
        string NativePlaceMessage { get;set;}
        /// <summary>
        /// 生日
        /// </summary>
        string BirthDay { get; set;}
        string BirthDayMessage { get;set;}
        /// <summary>
        /// 员工类型
        /// </summary>
        string EmployeeType { get; set;}
        string EmployeeTypeMessage { get;set;}
        /// <summary>
        /// 登录名
        /// </summary>
        string AccountName { get; set;}
        /// <summary>
        /// 英文名
        /// </summary>
        string EnglishName { get; set;}
        /// <summary>
        /// 性别
        /// </summary>
        string Gender { get; set;}
        string GenderMessage { get; set;}
        /// <summary>
        /// 民族
        /// </summary>
        string Nationality { get; set;}
        string NationalityMessage { get; set;}
        /// <summary>
        /// 婚姻状况
        /// </summary>
        string MaritalStatus { get; set;}
        string MaritalStatusMessage { get; set;}
        /// <summary>
        /// 身高
        /// </summary>
        string Height { get; set;}
        string HeightMessage { get; set;}
        /// <summary>
        /// 体重
        /// </summary>
        string Weight { get; set;}
        string WeightMessage { get; set;}
        /// <summary>
        /// 联系电话
        /// </summary>
        string Phone { get; set;}
        /// <summary>
        /// 健康状况
        /// </summary>
        string PhysicalCondition { get; set;}
        string PhysicalConditionMessage { get; set;}
        /// <summary>
        /// 政治面貌所选项id
        /// </summary>
        string PoliticalAffiliation { get; set;}
        string PoliticalAffiliationMessage { get; set;}
        /// <summary>
        /// 身份证号
        /// </summary>
        string IDNo { get; set;}
        string IDNoMessage { get; set;}
        /// <summary>
        /// 身份证有效期
        /// </summary>
        string IDDueDate { get; set;}
        string IDDueDateMessage { get; set;}
        /// <summary>
        /// 文化程度
        /// </summary>
        string EducationalBackground { get; set;}
        string EducationalBackgroundMessage { get; set;}
        /// <summary>
        /// 学校
        /// </summary>
        string School { get; set;}
        string SchoolMessage { get; set;}
        /// <summary>
        /// 专业
        /// </summary>
        string Major { get; set;}
        string MajorMessage { get; set;}
        /// <summary>
        /// 毕业时间
        /// </summary>
        string GraduateDate { get; set;}
        string GraduateDateMessage { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        byte[] Photo { get; set;}

        /// <summary>
        /// 修改照片  
        /// </summary>
        string PhotoHref{ get; set;}
        /// <summary>
        /// 员工类型数据源
        /// </summary>
        Dictionary<string, string> EmployeeTypeSource { get; set;}
        /// <summary>
        /// 性别数据源
        /// </summary>
        List<Gender> GenderSource { get; set;}
        /// <summary>
        /// 政治面貌数据源
        /// </summary>
        List<PoliticalAffiliation> PoliticalAffiliationSource { get; set;}
        /// <summary>
        /// 教育背景数据源
        /// </summary>
        List<EducationalBackground> EducationalBackgroundSource { get; set;}
        /// <summary>
        /// 婚姻状况数据源
        /// </summary>
        List<MaritalStatus> MaritalStatusSource { get; set;}
        /// <summary>
        /// 国籍所选项id
        /// </summary>
        string CountryNationality { get; set;}
        string CountryNationalityMessage { get; set;}
        List<Nationality> CountryNationalitySource{ get; set;}

    }
}

//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: IAddEmployeeView.cs
// 创建者: 倪豪
// 创建日期: 2008-06-16
// 概述: AddEmployeeView需要实现的接口
// 修改：刘丹
// 修改日期：2008-09-02
// 概述：增加员工的详细信息
// ----------------------------------------------------------------

using System.Collections.Generic;


namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface IAddEmployeeView
    {
        //string Message { get;set;}
        //string Title { get; set;}

        //中文名
        string EmployeeName { get; set;}
        string EmployeeNameMessage { get;set;}

        //邮箱地址
        string Email1{ get; set;}
        string Email1Message { get;set;}

        /// <summary>
        /// 籍贯
        /// </summary>
        string NativePlace { get; set;}
        string NativePlaceMessage { get;set;}

        //出生日期
        string BirthDay { get; set;}
        string BirthDayMessage { get;set;}


        //string ResidencePermit { get; set;}
        //string ResidencePermitMessage { get;set;}

        /// <summary>
        /// 员工状态
        /// </summary>
        string EmployeeType{ get; set;}
        string EmployeeTypeMessage { get;set;}

        /// <summary>
        ///登录名
        /// </summary>
        string AccountName { get; set;}
        string AccountNameMessage { get; set;}

        /// <summary>
        /// 邮箱地址2
        /// </summary>
        string Email2 { get; set;}
        string Email2Message { get; set;}

        string GraduateDate { get; set;}

        ///界面绑定的显示源
        Dictionary<string, string> EmployeeTypeSource { get;set;}
        //List<Position> PositionSource { get;set;}
        //List<Department> DepartmentSource { get;set;}


        Dictionary<int, string> EmployeeGenderSource { get; set;}
        Dictionary<int, string> PoliticalAffiliationSource { get; set;}
        Dictionary<int, string> PhysicalConditionSource { get; set;}
        Dictionary<int, string> EducationBackgroudSource { get; set;}

        //界面的按钮设置
        //string ActionButtonTxt { get;set;}
        //bool ActionButtonVisable { get;set;}
        //bool ActionButtonEnable{ get; set;}

        //event EventHandler ActionButtonEvent;
        //event EventHandler CancelButtonEvent;

        //EmployeeDetails
        /// <summary>
        /// 英文名
        /// </summary>
        string EnglishName { get; set;}

        /// <summary>
        /// 性别
        /// </summary>
        int EmployeeGenderID { get; set;}
        string GenderMessage { get; set;}

       /// <summary>
       /// 民族
       /// </summary>
        string Nationality { get; set;}
        string NationalityMessage { get; set;}

        /// <summary>
        /// 婚姻状况
        /// </summary>
        bool MaritalStatus { get; set;}
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
        string PhoneMessage { get; set;}

        /// <summary>
        /// 健康状况
        /// </summary>
        string PhysicalCondition { get; set;}
        string PhysicalConditionMessage { get; set;}

        /// <summary>
        /// 政治面貌所选项id
        /// </summary>
        int PoliticalAffiId { get; set;}
        string PoliticalMessage { get; set;}

        /// <summary>
        /// 照片
        /// </summary>
        byte[] photo { get; set;}

        //IDCard
        /// <summary>
        /// 身份证号
        /// </summary>
        string IDNo { get; set;}
        string IDNoMessage { get; set;}

        /// <summary>
        /// 身份证有效期
        /// </summary>
        string IdDueDate { get; set;}
        string IDDueDateMessage { get; set;}

        //教育
        /// <summary>
        /// 文化程度
        /// </summary>
        int EducationalBackground { get; set;}
        string EduMessage{ get; set;}

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
        /// 工号
        /// </summary>
        string EmployeeID { get; set;}
    }


}

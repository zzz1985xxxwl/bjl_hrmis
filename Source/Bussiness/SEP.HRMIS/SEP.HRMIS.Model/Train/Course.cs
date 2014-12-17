//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Course.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-05
// 概述: 培训课程
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// 培训课程
    ///</summary>
    public class Course
    {
        private int _CourseID;
        private string _CourseName;
        private Account _Coordinator;
        private TrainScopeEnum _Scope;
        private TrainStatusEnum _Status;
        private string _Trainer;
        private DateTime _ExpectST;
        private DateTime _ExpectET;
        private DateTime _ActualST;
        private DateTime _ActualET;
        private decimal _ExpectHour;
        private decimal _ActualHour;
        private decimal _ExpectCost;
        private decimal _ActualCost;
        private string _TrainPlace;
        private FeedBackPaper _FeedBackPaper;
        private List<Skill> _Skill;
        private List<Employee> _Employee;
        private TrainFBResult _TrainFBResult;
        private int _HasCertification;

        /// <summary>
        /// 
        /// </summary>
        public Course()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="coordinator"></param>
        /// <param name="scope"></param>
        /// <param name="status"></param>
        /// <param name="trainer"></param>
        public Course(string courseName, Account coordinator, TrainScopeEnum scope, TrainStatusEnum status, string trainer)
        {
            _Trainer = trainer;
            _Status = status;
            _Scope = scope;
            _Coordinator = coordinator;
            _CourseName = courseName;
        }

        ///<summary>
        /// 培训课程ID
        ///</summary>
        public int CourseID
        {
            get { return _CourseID; }
            set { _CourseID = value; }
        }

        ///<summary>
        /// 培训课程名称
        ///</summary>
        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; }
        }

        ///<summary>
        /// 负责人
        ///</summary>
        public Account Coordinator
        {
            get { return _Coordinator; }
            set { _Coordinator = value; }
        }

        ///<summary>
        /// 培训范围
        ///</summary>
        public TrainScopeEnum Scope
        {
            get { return _Scope; }
            set { _Scope = value; }
        }

        ///<summary>
        /// 培训状态
        ///</summary>
        public TrainStatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        ///<summary>
        /// 培训老师
        ///</summary>
        public string Trainer
        {
            get { return _Trainer; }
            set { _Trainer = value; }
        }

        ///<summary>
        /// 计划开始时间
        ///</summary>
        public DateTime ExpectST
        {
            get { return _ExpectST; }
            set { _ExpectST = value; }
        }

        ///<summary>
        /// 计划结束时间
        ///</summary>
        public DateTime ExpectET
        {
            get { return _ExpectET; }
            set { _ExpectET = value; }
        }

        ///<summary>
        /// 计划开始时间
        ///</summary>
        public DateTime ActualST
        {
            get { return _ActualST; }
            set { _ActualST = value; }
        }

        ///<summary>
        /// 计划结束时间
        ///</summary>
        public DateTime ActualET
        {
            get { return _ActualET; }
            set { _ActualET = value; }
        }

        ///<summary>
        /// 计划课时
        ///</summary>
        public decimal ExpectHour
        {
            get { return _ExpectHour; }
            set { _ExpectHour = value; }
        }

        ///<summary>
        /// 实际课时
        ///</summary>
        public decimal ActualHour
        {
            get { return _ActualHour; }
            set { _ActualHour = value; }
        }

        ///<summary>
        /// 计划成本
        ///</summary>
        public decimal ExpectCost
        {
            get { return _ExpectCost; }
            set { _ExpectCost = value; }
        }

        ///<summary>
        /// 实际成本
        ///</summary>
        public decimal ActualCost
        {
            get { return _ActualCost; }
            set { _ActualCost = value; }
        }

        ///<summary>
        ///</summary>
        public List<Skill> Skill
        {
            get { return _Skill; }
            set { _Skill = value; }
        }

        ///<summary>
        ///</summary>
        public List<Employee> Employee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }

        ///<summary>
        /// 培训反馈结果
        ///</summary>
        public TrainFBResult TrainFBResult
        {
            get { return _TrainFBResult; }
            set { _TrainFBResult = value; }
        }

        /// <summary>
        /// 培训地点
        /// </summary>
        public string TrainPlace
        {
            get { return _TrainPlace; }
            set { _TrainPlace = value; }
        }

        /// <summary>
        /// 课程反馈表
        /// </summary>
        public FeedBackPaper CourseFeedBackPaper
        {
            get { return _FeedBackPaper; }
            set { _FeedBackPaper = value; }
        }

        /// <summary>
        /// 是否有证书
        /// </summary>
        public int HasCertification
        {
            get { return _HasCertification; }
            set { _HasCertification = value; }
        }

        /// <summary>
        /// 是否让证书名称可填
        /// </summary>
        public bool CertifactionDisplay
        {
            get
            {
                return _Scope.Equals(TrainScopeEnum.OutsideTrain)&&_HasCertification.Equals(1);
            }
        }
    }
}
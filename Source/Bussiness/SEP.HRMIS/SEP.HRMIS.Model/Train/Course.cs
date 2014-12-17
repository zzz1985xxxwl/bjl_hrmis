//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: Course.cs
// ������: ���޾�
// ��������: 2008-11-05
// ����: ��ѵ�γ�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// ��ѵ�γ�
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
        /// ��ѵ�γ�ID
        ///</summary>
        public int CourseID
        {
            get { return _CourseID; }
            set { _CourseID = value; }
        }

        ///<summary>
        /// ��ѵ�γ�����
        ///</summary>
        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; }
        }

        ///<summary>
        /// ������
        ///</summary>
        public Account Coordinator
        {
            get { return _Coordinator; }
            set { _Coordinator = value; }
        }

        ///<summary>
        /// ��ѵ��Χ
        ///</summary>
        public TrainScopeEnum Scope
        {
            get { return _Scope; }
            set { _Scope = value; }
        }

        ///<summary>
        /// ��ѵ״̬
        ///</summary>
        public TrainStatusEnum Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        ///<summary>
        /// ��ѵ��ʦ
        ///</summary>
        public string Trainer
        {
            get { return _Trainer; }
            set { _Trainer = value; }
        }

        ///<summary>
        /// �ƻ���ʼʱ��
        ///</summary>
        public DateTime ExpectST
        {
            get { return _ExpectST; }
            set { _ExpectST = value; }
        }

        ///<summary>
        /// �ƻ�����ʱ��
        ///</summary>
        public DateTime ExpectET
        {
            get { return _ExpectET; }
            set { _ExpectET = value; }
        }

        ///<summary>
        /// �ƻ���ʼʱ��
        ///</summary>
        public DateTime ActualST
        {
            get { return _ActualST; }
            set { _ActualST = value; }
        }

        ///<summary>
        /// �ƻ�����ʱ��
        ///</summary>
        public DateTime ActualET
        {
            get { return _ActualET; }
            set { _ActualET = value; }
        }

        ///<summary>
        /// �ƻ���ʱ
        ///</summary>
        public decimal ExpectHour
        {
            get { return _ExpectHour; }
            set { _ExpectHour = value; }
        }

        ///<summary>
        /// ʵ�ʿ�ʱ
        ///</summary>
        public decimal ActualHour
        {
            get { return _ActualHour; }
            set { _ActualHour = value; }
        }

        ///<summary>
        /// �ƻ��ɱ�
        ///</summary>
        public decimal ExpectCost
        {
            get { return _ExpectCost; }
            set { _ExpectCost = value; }
        }

        ///<summary>
        /// ʵ�ʳɱ�
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
        /// ��ѵ�������
        ///</summary>
        public TrainFBResult TrainFBResult
        {
            get { return _TrainFBResult; }
            set { _TrainFBResult = value; }
        }

        /// <summary>
        /// ��ѵ�ص�
        /// </summary>
        public string TrainPlace
        {
            get { return _TrainPlace; }
            set { _TrainPlace = value; }
        }

        /// <summary>
        /// �γ̷�����
        /// </summary>
        public FeedBackPaper CourseFeedBackPaper
        {
            get { return _FeedBackPaper; }
            set { _FeedBackPaper = value; }
        }

        /// <summary>
        /// �Ƿ���֤��
        /// </summary>
        public int HasCertification
        {
            get { return _HasCertification; }
            set { _HasCertification = value; }
        }

        /// <summary>
        /// �Ƿ���֤�����ƿ���
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
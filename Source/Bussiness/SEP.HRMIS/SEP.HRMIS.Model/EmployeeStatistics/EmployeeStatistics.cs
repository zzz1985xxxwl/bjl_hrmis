//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeStatistics.cs
// 创建者: yyb
// 创建日期: 2008-11-14
// 概述: 员工统计
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class EmployeeStatistics
    {
        #region 私有变量

        private readonly List<Employee> _EmployeeList;
        private int _TotalCount;

        #region 性别统计
        private int _ManCount;
        private int _WomenCount;
        #endregion

        #region 用工性质统计
        private int _ContractCount;
        private int _ExternalContractCount;
        private int _ResidenceContractCount;
        private int _PracticerCount;
        private int _PartTimerCount;
        private int _WorkContractCount;
        #endregion

        #region 学历统计
        private int _XiaoXueCount;
        private int _ChuZhongCount;
        private int _ZhongZhuanCount;
        private int _JiXiaoCount;
        private int _GaoZhongCount;
        private int _DaZhuanCount;
        private int _BenKeCount;
        private int _ShuoShiCount;
        private int _BoShiCount;
        #endregion

        #region 年龄统计
        private int _Age0to20Count;
        private int _Age21to25Count;
        private int _Age26to30Count;
        private int _Age31to35Count;
        private int _Age36to40Count;
        private int _Age41to45Count;
        private int _Age46to50Count;
        private int _Age51to55Count;
        private int _Age56to60Count;
        private int _Age61Count;
        #endregion

        #region 工龄统计
        private int _WorkAge0to1Count;
        private int _WorkAge1to3Count;
        private int _WorkAge3to5Count;
        private int _WorkAge5to8Count;
        private int _WorkAge8Count;
        #endregion

        #endregion

        public EmployeeStatistics(List<Employee> employeeList)
        {
            _EmployeeList = employeeList;
        }

        #region 属性

        /// <summary>
        /// 总人数
        /// </summary>
        public int TotalCount
        {
            get
            {
                int count = 0;
                for (int i = 0; i < _EmployeeList.Count; i++)
                {
                    count++;
                }
                _TotalCount = count;
                return _TotalCount;
            }
            set { _TotalCount = value; }
        }

        /// <summary>
        /// 男性总数
        /// </summary>
        public int ManCount
        {
            get { return _ManCount; }
            set { _ManCount = value; }
        }

        /// <summary>
        /// 女性总数
        /// </summary>
        public int WomenCount
        {
            get { return _WomenCount; }
            set { _WomenCount = value; }
        }

        /// <summary>
        /// 合同工
        /// </summary>
        public int ContractCount
        {
            get { return _ContractCount; }
            set { _ContractCount = value; }
        }

        /// <summary>
        /// 外劳力合同工
        /// </summary>
        public int ExternalContractCount
        {
            get { return _ExternalContractCount; }
            set { _ExternalContractCount = value; }
        }

        /// <summary>
        /// 居住证合同工
        /// </summary>
        public int ResidenceContractCount
        {
            get { return _ResidenceContractCount; }
            set { _ResidenceContractCount = value; }
        }

        /// <summary>
        /// 实习生
        /// </summary>
        public int PracticerCount
        {
            get { return _PracticerCount; }
            set { _PracticerCount = value; }
        }

        /// <summary>
        /// 兼职
        /// </summary>
        public int PartTimerCount
        {
            get { return _PartTimerCount; }
            set { _PartTimerCount = value; }
        }

        /// <summary>
        /// 劳务工
        /// </summary>
        public int WorkContractCount
        {
            get { return _WorkContractCount; }
            set { _WorkContractCount = value; }
        }

        /// <summary>
        /// 小学
        /// </summary>
        public int XiaoXueCount
        {
            get { return _XiaoXueCount; }
            set { _XiaoXueCount = value; }
        }

        /// <summary>
        /// 初中
        /// </summary>
        public int ChuZhongCount
        {
            get { return _ChuZhongCount; }
            set { _ChuZhongCount = value; }
        }

        /// <summary>
        /// 中专
        /// </summary>
        public int ZhongZhuanCount
        {
            get { return _ZhongZhuanCount; }
            set { _ZhongZhuanCount = value; }
        }

        /// <summary>
        /// 技校
        /// </summary>
        public int JiXiaoCount
        {
            get { return _JiXiaoCount; }
            set { _JiXiaoCount = value; }
        }

        /// <summary>
        /// 高中
        /// </summary>
        public int GaoZhongCount
        {
            get { return _GaoZhongCount; }
            set { _GaoZhongCount = value; }
        }

        /// <summary>
        /// 大专
        /// </summary>
        public int DaZhuanCount
        {
            get { return _DaZhuanCount; }
            set { _DaZhuanCount = value; }
        }

        /// <summary>
        /// 本科
        /// </summary>
        public int BenKeCount
        {
            get { return _BenKeCount; }
            set { _BenKeCount = value; }
        }

        /// <summary>
        /// 硕士
        /// </summary>
        public int ShuoShiCount
        {
            get { return _ShuoShiCount; }
            set { _ShuoShiCount = value; }
        }

        /// <summary>
        /// 博士
        /// </summary>
        public int BoShiCount
        {
            get { return _BoShiCount; }
            set { _BoShiCount = value; }
        }

        public int Age0to20Count
        {
            get { return _Age0to20Count; }
            set { _Age0to20Count = value; }
        }

        public int Age21to25Count
        {
            get { return _Age21to25Count; }
            set { _Age21to25Count = value; }
        }

        public int Age26to30Count
        {
            get { return _Age26to30Count; }
            set { _Age26to30Count = value; }
        }

        public int Age31to35Count
        {
            get { return _Age31to35Count; }
            set { _Age31to35Count = value; }
        }

        public int Age36to40Count
        {
            get { return _Age36to40Count; }
            set { _Age36to40Count = value; }
        }

        public int Age41to45Count
        {
            get { return _Age41to45Count; }
            set { _Age41to45Count = value; }
        }

        public int Age46to50Count
        {
            get { return _Age46to50Count; }
            set { _Age46to50Count = value; }
        }

        public int Age51to55Count
        {
            get { return _Age51to55Count; }
            set { _Age51to55Count = value; }
        }

        public int Age56to60Count
        {
            get { return _Age56to60Count; }
            set { _Age56to60Count = value; }
        }

        public int Age61Count
        {
            get { return _Age61Count; }
            set { _Age61Count = value; }
        }

        public int WorkAge0to1Count
        {
            get { return _WorkAge0to1Count; }
            set { _WorkAge0to1Count = value; }
        }

        public int WorkAge1to3Count
        {
            get { return _WorkAge1to3Count; }
            set { _WorkAge1to3Count = value; }
        }

        public int WorkAge3to5Count
        {
            get { return _WorkAge3to5Count; }
            set { _WorkAge3to5Count = value; }
        }

        public int WorkAge5to8Count
        {
            get { return _WorkAge5to8Count; }
            set { _WorkAge5to8Count = value; }
        }

        public int WorkAge8Count
        {
            get { return _WorkAge8Count; }
            set { _WorkAge8Count = value; }
        }

        #endregion

        #region 方法

        public void GenderStatistics()
        {
            ManCount = 0;
            WomenCount = 0;
            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                if (_EmployeeList[i].EmployeeDetails == null
                    || _EmployeeList[i].EmployeeDetails.Gender == null)
                {
                    ManCount++;
                    continue;
                }
                if (_EmployeeList[i].EmployeeDetails.Gender.Id == Gender.Woman.Id)
                {
                    WomenCount++;
                }
                else
                {
                    ManCount++;
                }
            }
        }

        public void WorkTypeStatistics()
        {
            ContractCount = 0;
            ExternalContractCount = 0;
            ResidenceContractCount = 0;
            PracticerCount = 0;
            PartTimerCount = 0;
            WorkContractCount = 0;

            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                if (_EmployeeList[i].EmployeeDetails == null
                    || _EmployeeList[i].EmployeeDetails.Work == null
                    || _EmployeeList[i].EmployeeDetails.Work.WorkType == null)
                {
                    ContractCount++;
                    continue;
                }
                switch (_EmployeeList[i].EmployeeDetails.Work.WorkType.Id)
                {
                    case 1:
                        ContractCount++;
                        break;
                    case 2:
                        ExternalContractCount++;
                        break;
                    case 3:
                        ResidenceContractCount++;
                        break;
                    case 4:
                        ContractCount++;
                        break;
                    case 5:
                        PartTimerCount++;
                        break;
                    case 6:
                        WorkContractCount++;
                        break;
                }
            }
        }

        public void EducationalBackgroundStatistics()
        {
            XiaoXueCount = 0;
            ChuZhongCount = 0;
            ZhongZhuanCount = 0;
            JiXiaoCount = 0;
            GaoZhongCount = 0;
            DaZhuanCount = 0;
            BenKeCount = 0;
            ShuoShiCount = 0;
            BoShiCount = 0;

            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                if (_EmployeeList[i].EmployeeDetails == null
                    || _EmployeeList[i].EmployeeDetails.Education == null
                    || _EmployeeList[i].EmployeeDetails.Education.EducationalBackground == null)
                {
                    GaoZhongCount++;
                    continue;
                }
                switch (_EmployeeList[i].EmployeeDetails.Education.EducationalBackground.Id)
                {
                    case 1:
                        XiaoXueCount++;
                        break;
                    case 2:
                        ChuZhongCount++;
                        break;
                    case 3:
                        ZhongZhuanCount++;
                        break;
                    case 4:
                        JiXiaoCount++;
                        break;
                    case 5:
                        GaoZhongCount++;
                        break;
                    case 6:
                        DaZhuanCount++;
                        break;
                    case 7:
                        BenKeCount++;
                        break;
                    case 8:
                        ShuoShiCount++;
                        break;
                    case 9:
                        BoShiCount++;
                        break;
                }
            }
        }

        public void AgeStatistics()
        {
            Age0to20Count = 0;
            Age21to25Count = 0;
            Age26to30Count = 0;
            Age31to35Count = 0;
            Age36to40Count = 0;
            Age41to45Count = 0;
            Age46to50Count = 0;
            Age51to55Count = 0;
            Age56to60Count = 0;
            Age61Count = 0;

            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                if (_EmployeeList[i].EmployeeDetails == null)
                {
                    Age26to30Count++;
                    continue;
                }
                if (_EmployeeList[i].EmployeeDetails.Age <= 20)
                {
                    Age0to20Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 25)
                {
                    Age21to25Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 30)
                {
                    Age26to30Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 35)
                {
                    Age31to35Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 40)
                {
                    Age36to40Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 45)
                {
                    Age41to45Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 50)
                {
                    Age46to50Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 55)
                {
                    Age51to55Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Age <= 60)
                {
                    Age56to60Count++;
                }
                else
                {
                    Age61Count++;
                }
            }
        }

        public void WorkAgeStatistics()
        {
            WorkAge0to1Count = 0;
            WorkAge1to3Count = 0;
            WorkAge3to5Count = 0;
            WorkAge5to8Count = 0;
            WorkAge8Count = 0;

            for (int i = 0; i < _EmployeeList.Count; i++)
            {
                if (_EmployeeList[i].EmployeeDetails == null
                    || _EmployeeList[i].EmployeeDetails.Work == null)
                {
                    WorkAge0to1Count++;
                    continue;
                }
                if (_EmployeeList[i].EmployeeDetails.Work.WorkAgeDecaiml <= 1)
                {
                    WorkAge0to1Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Work.WorkAgeDecaiml <= 3)
                {
                    WorkAge1to3Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Work.WorkAgeDecaiml <= 5)
                {
                    WorkAge3to5Count++;
                }
                else if (_EmployeeList[i].EmployeeDetails.Work.WorkAgeDecaiml <= 8)
                {
                    WorkAge5to8Count++;
                }
                else
                {
                    WorkAge8Count++;
                }
            }
        }

        #endregion
    }
}
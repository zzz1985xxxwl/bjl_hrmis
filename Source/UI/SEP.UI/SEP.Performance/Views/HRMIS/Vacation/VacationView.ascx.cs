//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: VacationView.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-1
// 概述: 员工tap页中的界面
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance
{
    public partial class VacationView : UserControl, IVacationView
    {
        public string SocietyWorkAge
        {
            set
            {
                lblSocietyWorkAge.Text = value;
            }
            get
            {
                return lblSocietyWorkAge.Text;
            }
        }
        public Employee Employee
        {
            get
            {
                return VacationInfoListView1.Employee;
            }
            set
            {
             
                VacationUsedDetailsView1.Employee = value;
                VacationInfoListView1.Employee = value;
                //VacationShowView1.Employee = value;
            }
        }

        public List<Vacation> VacationList
        {
            get { return VacationInfoListView1.VacationList; }
        }

        public bool IsBack
        {
            set 
            {
                if (value)
                {
                   
                   // ShowDetail.Visible = false;
                    ShowSocietyWorkAge.Visible = true;
                }
                else
                {
                    VacationInfoListView1.ReadOnly = true;
                   // ShowDetail.Visible = true;
                    ShowSocietyWorkAge.Visible = false;
                }
            }
        }
    }
}
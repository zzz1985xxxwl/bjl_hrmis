//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DimissionBasicView.ascx.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 离职信息的基本信息界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.DimissionViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.DimissionInformation
{
    public partial class DimissionBasicView : UserControl, IDimissionBasicView
    {
        public event DelegateNoParameter SelectDimissionReasonTypeChange;


        protected void RBList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectDimissionReasonTypeChange();
        }

        #region IDimissionBasicView 成员

        public string DimissionDate
        {
            get
            {
                return txtStartDate.Text.Trim();
            }
            set
            {
                txtStartDate.Text = value;
            }
        }

        public string DimissionDateMessage
        {
            get
            {
                return lblDataMessage.Text;
            }
            set
            {
                lblDataMessage.Text = value;
            }
        }

        public string DimissionMonth
        {
            get
            {
                return txtDimissionMonth.Text.Trim();
            }
            set
            {
                txtDimissionMonth.Text = value;
            }
        }

        public string DimissionMonthMessage
        {
            get
            {
                return lblMonthMessage.Text.Trim();
            }
            set
            {
                lblMonthMessage.Text = value;
            }
        }

          public string DimissionType
        {
            get
            {
                return txtDimissionType.Text.Trim();
            }
            set
            {
                txtDimissionType.Text = value;
            }
        }

        public string DimissionReasonType
        {
            get
            {
                return RBList1.SelectedValue;
            }
            set
            {
                RBList1.SelectedValue = value;
            }
        }

        public string DimissionReasonTypeMessage
        {
            get
            {
                return lblReseanTypeMessage.Text;
            }
            set
            {
                lblReseanTypeMessage.Text = value;
            }
        }

        public List<DimissionReasonType> DimissionReasonTypeSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                foreach(DimissionReasonType drt in value)
                {
                    RBList1.Items.Add(new ListItem(drt.Name,drt.Id.ToString()));
                }
            }
        }

        public bool DimissionReasonTypeEnable
        {
            get
            {
                return RBList1.Enabled;
            }
            set
            {
                RBList1.Enabled = value;
            }
        }
        
        public string DimissionOtherReason
        {
            get
            {
                return txtDimissionReason.Text.Trim();
            }
            set
            {
                txtDimissionReason.Text = value;
            }
        }
  
        public bool DimissionOtherReasonVisible
        {
            get
            {
                return trDimissionReason.Visible;
            }
            set
            {
                trDimissionReason.Visible = value;
            }
        }

 

        //public List<FileCargo> FileCargoDataView
        //{
        //    get
        //    {
        //        throw new Exception("The method or operation is not implemented.");
        //    }
        //    set
        //    {
              
        //        DimissionInfoGV.DataSource = value;
        //        DimissionInfoGV.DataBind();
        //        if(value!=null&&value.Count!=0)
        //        {
        //            tbfileCargo.Visible = true;
        //        }
        //        else
        //        {
        //            tbfileCargo.Visible = false;
        //        }
        //    }
        //}
        
        //public bool BtnAddFileCargoVisible
        //{
        //    get
        //    {
        //        return btnAddInfo.Visible;
        //    }
        //    set
        //    {
        //        btnAddInfo.Visible = value;
        //    }
        //}

        //public bool BtnUpdateFileCargoVisible
        //{
        //    get
        //    {
        //        return DimissionInfoGV.Columns[4].Visible;
        //    }
        //    set
        //    {
        //        DimissionInfoGV.Columns[4].Visible = value;
        //    }
        //}

        //public bool BtnDeleteFileCargoVisible
        //{
        //    get
        //    {
        //        return DimissionInfoGV.Columns[5].Visible;
        //    }
        //    set
        //    {
        //        DimissionInfoGV.Columns[5].Visible = value;
        //    }
        //}
        
        #endregion
    }
}
//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ManageVacationView.cs
// ������: ���h��
// ��������: 2008-06-05
// ����: �������
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;

namespace SEP.Performance
{
    public partial class ManageVacationView : UserControl, IVacationBaseView
    {
        private string _ResultMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            ResultMessage = "";
            ValidateDayNum = "";
            ValidateStartDate = "";
            ValidateUsedDayNum = "";

            txtVacationDayNum.Attributes.Add("onblur", Page.GetPostBackEventReference(txtVacationDayNum));
            txtUsedDayNum.Attributes.Add("onblur", Page.GetPostBackEventReference(txtUsedDayNum));
            txtVacationStartDate.Attributes.Add("onchange", Page.GetPostBackEventReference(txtVacationStartDate));
        }


        public bool AdjustRestVisible
        {
            set { AdjustVisible.Visible = value; }
            get { return AdjustVisible.Visible; }
        }

        #region

        public string EmployeeID
        {
            get { return lblEmployeeID.Text; }
            set { lblEmployeeID.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public string VacationID
        {
            get { return lblID.Text; }
            set { lblID.Text = value; }
        }

        public string SurplusDayNum
        {
            get { return txtSurplusDayNum.Text.Trim(); }
            set { txtSurplusDayNum.Text = value; }
        }

        public string UsedDayNum
        {
            get { return txtUsedDayNum.Text.Trim(); }
            set { txtUsedDayNum.Text = value; }
        }

        public string Remark
        {
            get { return txtRemark.Text.Trim(); }
            set { txtRemark.Text = value; }
        }

        public string VacationDayNum
        {
            get { return txtVacationDayNum.Text.Trim(); }
            set { txtVacationDayNum.Text = value; }
        }

        public string VacationEndDate
        {
            get { return txtVacationEndDate.Text.Trim(); }
            set { txtVacationEndDate.Text = value; }
        }

        public string VacationStartDate
        {
            get { return txtVacationStartDate.Text.Trim(); }
            set { txtVacationStartDate.Text = value; }
        }

        public string ResultMessage
        {
            get { return _ResultMessage; }
            set { _ResultMessage = value; }
        }

        public string ValidateDayNum
        {
            get { return lblValidateDayNum.Text.Trim(); }
            set { lblValidateDayNum.Text = value; }
        }

        public string ValidateStartDate
        {
            get { return lblValidateStartDay.Text.Trim(); }
            set { lblValidateStartDay.Text = value; }
        }

        public string ValidateUsedDayNum
        {
            get { return lblValidateUsedDayNum.Text.Trim(); }
            set { lblValidateUsedDayNum.Text = value; }
        }

        public string AdjustRestRemainedDays
        {
            get { return txtAdjustRest.Text.Trim(); }
            set { txtAdjustRest.Text = value; }
        }

        #endregion

        public bool IsEdit
        {
            set
            {
                txtVacationDayNum.ReadOnly = !value;
                txtUsedDayNum.ReadOnly = !value;
                txtRemark.ReadOnly = !value;
                txtVacationStartDate.ReadOnly = !value;
                txtVacationEndDate.ReadOnly = !value;
            }
        }


        protected void txtVacationDayNum_TextChanged(object sender, EventArgs e)
        {
            ComputeSurplusDayNum();
        }


        protected void txtUsedDayNum_TextChanged(object sender, EventArgs e)
        {
            ComputeSurplusDayNum();
        }

        protected void txtVacationStartDate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VacationEndDate))
            {
                ComputeVacationEndDate(true);
            }
        }

        private bool ComputeVacationEndDate(bool calcute)
        {
            ValidateStartDate = "";
            if (String.IsNullOrEmpty(VacationStartDate))
            {
                VacationEndDate = "";
                return true;
            }
            DateTime startTime;
            if (!DateTime.TryParse(VacationStartDate, out startTime))
            {
                ValidateStartDate = "��ٿ�ʼ���ڸ�ʽ����ȷ��";
                return false;
            }
            if (calcute)
            {
                VacationEndDate = startTime.AddYears(1).AddDays(-1).ToShortDateString();
            }
            return true;
        }

        private bool ComputeSurplusDayNum()
        {
            ValidateDayNum = "";
            ValidateUsedDayNum = "";
            if ((String.IsNullOrEmpty(VacationDayNum)) || (String.IsNullOrEmpty(UsedDayNum)))
            {
                SurplusDayNum = "";
                return true;
            }
            decimal vacationDayNum;
            decimal usedDayNum;
            if (!decimal.TryParse(VacationDayNum, out vacationDayNum) ||
                vacationDayNum < 0 ||
                vacationDayNum > 366)
            {
                ValidateDayNum = "�����������Ϊ���ڵ���0��С�ڵ���366�����֣�";
                return false;
            }
            if (!decimal.TryParse(UsedDayNum, out usedDayNum) ||
                usedDayNum < 0 ||
                usedDayNum > vacationDayNum)
            {
                ValidateUsedDayNum = "���������������Ϊ���ڵ���0��С�ڵ�����������������֣�";
                return false;
            }
            SurplusDayNum = (vacationDayNum - usedDayNum).ToString();
            return true;
        }

        public bool ViewValidation
        {
            get { return ComputeVacationEndDate(false) && ComputeSurplusDayNum(); }
            set { }
        }

        /// <summary>
        /// �ж��Ƿ��г�����Ϣ
        /// </summary>
        public bool IsError
        {
            get { return !string.IsNullOrEmpty(ResultMessage + ValidateDayNum + ValidateStartDate + ValidateUsedDayNum); }
        }

        ///// <summary>
        ///// ����ȷ��ȡ����ť�Ŀɼ���
        ///// </summary>
        //public bool ButtonVisible
        //{
        //    set { Button.Visible = value; }
        //}
        //public EventHandler btnCancleClickEvent;
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    btnCancleClickEvent(sender, e);
        //}
    }
}
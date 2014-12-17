//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeBasicView.ascx.cs
// 创建者: 倪豪
// 创建日期: 2008-10-2
// 概述: 员工信息基本界面的view
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;

namespace SEP.Performance.Views.EmployeeInformation.BasicInformation
{
    public partial class EmployeeBasicView : System.Web.UI.UserControl, IBasicInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //为了使上传照片按钮加入到trigger中，所以把UpdateEmployeePhoto加入到EmployeeBasicView中，
            //然后做以下修改，原UpdateEmployeePhoto无效

            //UpdateEmployeePhoto1.BindPhoto = BindPhoto;
            ResultMessage = "";
            tbResultMessage.Visible = string.IsNullOrEmpty(ResultMessage) ? false : true;
        }

        #region Photo
         
        public byte[] Photo
        {
            get
            {
                return PhotoArray;
            }
            set
            {
                PhotoArray = value;
                if (value != null)
                {
                    imgPhoto.ImageUrl = "../../../../Pages/HRMIS/EmployeePages/EmployeePhotoResponse.aspx?PhotoSessionName=" + PhotoSessionName;
                }
            } 
        }

        /// <summary>
        /// 用于控制点照片控件的链接，触发的事件
        /// </summary>
        public string PhotoHref
        {
            get { return PhotoLink.HRef; }
            set { PhotoLink.HRef = value; }
        }

        private void BindPhoto()
        {
            if (!string.IsNullOrEmpty(ResultMessage))
            {
                mpePhoto.Show();
            }
            else
            {
                imgPhoto.ImageUrl = "../../../../Pages/HRMIS/EmployeePages/EmployeePhotoResponse.aspx?PhotoSessionName=" + PhotoSessionName;
            }
        }
       

        private string ResultMessage
        {
            get { return lbResultMessage.Text.Trim(); }
            set
            {
                lbResultMessage.Text = value;
                tbResultMessage.Visible = string.IsNullOrEmpty(ResultMessage) ? false : true;
            }
        }
        /// <summary>
        /// SessionName
        /// </summary>
        private string PhotoSessionName
        {
            get
            {
                if(ViewState["PhotoViewStateName"] == null)
                {
                    Guid guid = Guid.NewGuid();
                    ViewState["PhotoViewStateName"] = guid.ToString();
                }
                return ViewState["PhotoViewStateName"].ToString();     
            }
        }
        private byte[] PhotoArray
        {
            get { return Session[PhotoSessionName] as byte[]; }
            set { Session[PhotoSessionName] = value; }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validition())
            {
                //获得图象并把图象转换为byte[] 
                HttpPostedFile upPhoto = UpPhoto.PostedFile;
                int upPhotoLength = upPhoto.ContentLength;
                PhotoArray = new Byte[upPhotoLength];
                Stream PhotoStream = upPhoto.InputStream;
                PhotoStream.Read(PhotoArray, 0, upPhotoLength);
            }
            else
            {
                ResultMessage = "请检查文件大小和格式";
            }
            BindPhoto();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }
        private bool Validition()
        {
            return CheckFileSize() && CheckFileType();
        }

        private bool CheckFileType()
        {
            string fileContentType = UpPhoto.PostedFile.ContentType;
            switch (fileContentType)
            {
                case "image/bmp":
                    return true;
                case "image/gif":
                    return true;
                case "image/pjpeg":
                    return true;
                case "image/jpg":
                    return true;
                default:
                    return false;
            }
        }

        private bool CheckFileSize()
        {
            if (UpPhoto.PostedFile.ContentLength > 1048576)
            { return false; }
            else
            { return true; }
        }

        #endregion

        public string EmployeeName
        {
            get
            {
                return lblEmployeeName.Text;
            }
            set
            {
                lblEmployeeName.Text = value;
            }
        }

        public string DepartmentName
        {
            set { lblDepartmentName.Text = value; }
        }

        public string PositionName
        {
            set { lblPositionName.Text = value; }
        }

        public string Email1
        {
            get
            {
                return lblMail1.Text;
            }
            set
            {
                lblMail1.Text = value;
            }
        }

        public string Email2
        {
            get
            {
                return lblMail2.Text;
            }
            set
            {
                lblMail2.Text = value;
            }
        }

        public string NativePlace
        {
            get { return txtNativePlace.Text; }
            set { txtNativePlace.Text = value; }
        }

        public string NativePlaceMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgNativePlace.Text = value; }
        }

        public string BirthDay
        {
            get
            {
                return txtBirthday.Text;
            }
            set
            {
                txtBirthday.Text = value;
            }
        }

        public string BirthDayMessage
        {
            get
            {
                return MsgBirthday.Text;
            }
            set
            {
                MsgBirthday.Text =  value;
            }
        }

        public string EmployeeType
        {
            get
            {
                return ddlEmployeeType.SelectedItem.Value;
            }
            set
            {
                ddlEmployeeType.SelectedValue = value;
            }
        }

        public string EmployeeTypeMessage
        {
            get
            {
                return MsgBirthday.Text;
            }
            set
            {
                MsgEmployeeType.Text =  value;
            }
        }

        public string AccountName
        {
            get
            {
                return txtAccountName.Text;
            }
            set
            {
                txtAccountName.Text = value;
            }
        }

        public string EnglishName
        {
            get { return txtEngName.Text; }
            set { txtEngName.Text = value; }
        }
        
        public string Gender
        {
            get
            {
                return genderRadio.SelectedValue; 
            }
            set
            {
                genderRadio.SelectedValue = value;
            }
        }

        public string GenderMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgGender.Text = value; }
        }

        public string Nationality
        {
            get { return txtNationality.Text; }
            set { txtNationality.Text = value; }
        }

        public string NationalityMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgNationality.Text = value; }
        }

        public string MaritalStatus
        {
            get
            {
                return ddlMarital.SelectedValue;
            }
            set
            {
                ddlMarital.SelectedValue = value;
            }
        }

        public string MaritalStatusMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgMarital.Text = value; }
        }

        public string Height
        {
            get { return txtHeight.Text; }
            set { txtHeight.Text = value; }
        }

        public string HeightMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgHeight.Text = value; }
        }

        public string Weight
        {
            get { return txtWeight.Text; }
            set { txtWeight.Text = value; }
        }

        public string WeightMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgWeight.Text = value; }
        }

        public string Phone
        {
            get { return lblPhone.Text; }
            set { lblPhone.Text = value; }
        }

        public string PhysicalCondition
        {
            get { return txtPhysical.Text; }
            set { txtPhysical.Text = value; }
        }

        public string PhysicalConditionMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgPhysical.Text = value; }
        }

        public string PoliticalAffiliation
        {
            get
            {
                return ddlPolictial.SelectedValue;
            }
            set
            {
                ddlPolictial.SelectedValue = value;
            }
        }

        public string PoliticalAffiliationMessage
        {
            get
            {
                return MsgPolitical.Text;
            }
            set
            {
                MsgPolitical.Text = value;
            }
        }

        public string IDNo
        {
            get { return txtIDNo.Text; }
            set { txtIDNo.Text = value; }
        }

        public string IDNoMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgIDNo.Text = value; }
        }
        
        public string IDDueDate
        {
            get
            {
                return txtIDDueDate.Text;
            }
            set
            {
                txtIDDueDate.Text = value;
            }
        }

        public string IDDueDateMessage
        {
            get
            {
                return MsgDueDate.Text;
            }
            set
            {
                MsgDueDate.Text = value;
            }
        }

        public string EducationalBackground
        {
            get
            {
                return ddlEdu.SelectedValue;
            }
            set
            {
                ddlEdu.SelectedValue = value;
            }
        }

        public string EducationalBackgroundMessage
        {
            get
            {
                return MsgEdu.Text;
            }
            set
            {
                MsgEdu.Text = value;
            }
        }

        public string School
        {
            get { return txtSchool.Text; }
            set { txtSchool.Text = value; }
        }

        public string SchoolMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgSchool.Text = value; }
        }

        public string Major
        {
            get { return txtMajor.Text; }
            set { txtMajor.Text = value; }
        }

        public string MajorMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgMajor.Text = value; }
        }
        
        public string GraduateDate
        {
            get { return txtGrudateDate.Text; }
            set { txtGrudateDate.Text = value; }
        }

        public string GraduateDateMessage
        {
            get { return MsgGrudateDate.Text; }
            set { MsgGrudateDate.Text = value; }
        }

        public string CountryNationality
        {
            get { return ddlCountryNationality.SelectedValue; }
            set { ddlCountryNationality.SelectedValue = value; }
        }

        public string CountryNationalityMessage
        {
            get { throw new NotImplementedException(); }
            set { MsgCountryNationality.Text = value; }
        }

        public List<Nationality> CountryNationalitySource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                foreach (Nationality ms in value)
                {
                    ddlCountryNationality.Items.Add(new ListItem(ms.Name, ms.ParameterID.ToString()));
                }
            }
        }

        public Dictionary<string, string> EmployeeTypeSource
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlEmployeeType.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlEmployeeType.Items.Add(item);
                }

            }
        }
        public List<Gender> GenderSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                foreach(Gender g in value)
                {
                    genderRadio.Items.Add(new ListItem(g.Name,g.Id.ToString()));
                }
            }
        }

        public List<PoliticalAffiliation> PoliticalAffiliationSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                foreach (PoliticalAffiliation pa in value)
                {
                   ddlPolictial.Items.Add(new ListItem(pa.Name, pa.Id.ToString()));
                }
            }
        }

        public List<EducationalBackground> EducationalBackgroundSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                foreach (EducationalBackground eb in value)
                {
                   ddlEdu.Items.Add(new ListItem(eb.Name, eb.Id.ToString()));
                }
            }
        }

        public List<MaritalStatus> MaritalStatusSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                foreach (MaritalStatus ms in value)
                {
                    ddlMarital.Items.Add(new ListItem(ms.Name, ms.Id.ToString()));
                }
            }
        }
    }
}
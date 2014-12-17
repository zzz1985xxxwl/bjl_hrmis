using System;
using System.IO;
using System.Web;
using System.Web.UI;
using SEP.Presenter;
using SEP.Presenter.IPresenter.IAccounts;

namespace SEP.Performance.Views.SEP.Accounts
{
    public partial class PersonalConfigView : UserControl, IPersonalConfigView
    {
        #region IPersonalConfigView ��Ա
        protected void Page_Load(object sender, EventArgs e)
        {
            //Ϊ��ʹ�ϴ���Ƭ��ť���뵽trigger�У����԰�UpdateEmployeePhoto���뵽EmployeeBasicView�У�
            //Ȼ���������޸ģ�ԭUpdateEmployeePhoto��Ч

            //UpdateEmployeePhoto1.BindPhoto = BindPhoto;
            SmallResultMessage = "";
            divSmallResultMessage.Visible = string.IsNullOrEmpty(SmallResultMessage) ? false : true;
        }
        public string Message
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    divMessage.Style["display"] = "none";
                }
                else
                {
                    divMessage.Style["display"] = "block";
                    lbResultMessage.Text = value;
                }
            }
        }

        public bool AcceptEmail
        {
            get
            {
                return Convert.ToBoolean(rbEmail.SelectedIndex);
            }
            set
            {
                rbEmail.SelectedIndex = Convert.ToInt32(value);
            }
        }

        public bool AcceptSMS
        {
            get
            {
                return Convert.ToBoolean(rbSMS.SelectedIndex);
            }
            set
            {
                rbSMS.SelectedIndex = Convert.ToInt32(value);
            }
        }

        public bool ValidateUsbKey
        {
            get
            {
                return Convert.ToBoolean(rbUsbKey.SelectedIndex);
            }
            set
            {
                //btnChangeUsbKey.Visible = value;
                //lbElectricName.Visible = value;
                //imgPhoto.Visible = value;
                //MsgElectricName.Visible = value;
                rbUsbKey.SelectedIndex = Convert.ToInt32(value);
            }
        }


        public int UsbKeyCount
        {
            get
            {
                if (String.IsNullOrEmpty(lbUsbKeyCount.Value))
                {
                    return 0;
                }

                return Convert.ToInt32(lbUsbKeyCount.Value.Trim());
            }
        }

        public string UsbKey
        {
            get
            {
                return lbUsbKey.Value;
            }
        }



        public string UsbKeyMsg
        {
            set
            {
                lbUsbKeyMsg.Text = value;
            }
        }

        public string ElectricNameMsg
        {
            set { lbElectricNameMsg.Text = value; }
        }


        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;
        public event DelegateNoParameter ChangeButtonEvent;

        #endregion;

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
                    imgPhoto.ImageUrl = "../../../Pages/SEP/AccountPages/ElectricNameResponse.aspx?PhotoSessionName=" + PhotoSessionName;
                }
            }
        }

        /// <summary>
        /// ���ڿ��Ƶ���Ƭ�ؼ������ӣ��������¼�
        /// </summary>
        public string PhotoHref
        {
            get { return PhotoLink.HRef; }
            set { PhotoLink.HRef = value; }
        }

        private void BindPhoto()
        {
            if (!string.IsNullOrEmpty(SmallResultMessage))
            {
                mpePhoto.Show();
            }
            else
            {
                imgPhoto.ImageUrl = "../../../Pages/SEP/AccountPages/ElectricNameResponse.aspx?PhotoSessionName=" + PhotoSessionName;
            }
        }


        //private string ResultMessage
        //{
        //    get { return lbResultMessage.Text.Trim(); }
        //    set
        //    {
        //        lbResultMessage.Text = value;
        //        tbMessage.Visible = string.IsNullOrEmpty(ResultMessage) ? false : true;
        //    }
        //}

        private string SmallResultMessage
        {
            get { return lbSmallResultMessage.Text.Trim(); }
            set
            {
                lbSmallResultMessage.Text = value;
                divSmallResultMessage.Visible = string.IsNullOrEmpty(SmallResultMessage) ? false : true;
            }
        }
        /// <summary>
        /// SessionName
        /// </summary>
        private string PhotoSessionName
        {
            get
            {
                if (ViewState["PhotoViewStateName"] == null)
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
                //���ͼ�󲢰�ͼ��ת��Ϊbyte[] 
                HttpPostedFile upPhoto = UpPhoto.PostedFile;
                int upPhotoLength = upPhoto.ContentLength;
                PhotoArray = new Byte[upPhotoLength];
                Stream PhotoStream = upPhoto.InputStream;
                PhotoStream.Read(PhotoArray, 0, upPhotoLength);
            }
            else
            {
                SmallResultMessage = "�����ļ���С�͸�ʽ";
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

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ActionButtonEvent != null)
                ActionButtonEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelButtonEvent != null)
                CancelButtonEvent();
        }

        protected void btnChangeUsbKey_Click(object sender, EventArgs e)
        {
            if(ChangeButtonEvent != null)
                ChangeButtonEvent();
        }

        protected void rbUsbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnChangeUsbKey.Visible = ValidateUsbKey;
            //lbElectricName.Visible = ValidateUsbKey;
            //imgPhoto.Visible = ValidateUsbKey;
            //MsgElectricName.Visible = ValidateUsbKey;
        }
    }
}
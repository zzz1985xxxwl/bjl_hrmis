using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Views.HRMIS.AssessManagement
{
    public partial class AddTemplateItemView : UserControl, IAddTemplateItemView
    {
        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (String.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        /// <summary>
        /// 当判断所填写的问题描述为空时,把消息附给相应的label显示
        /// </summary>
        public string QestionNullMessage
        {
            set { lblNullMessage.Text = value; }
        }

        public string Question
        {
            get { return txtQuestion.Text.Trim(); }
            set { txtQuestion.Text = value; }
        }

        public int AssessTemplateItemType
        {
            get { return ddlItemType.SelectedIndex; }
            set
            {
                ddlItemType.SelectedIndex = value;
                DisplayType();
            }
        }

        public void rbItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayType();
        }

        private void DisplayType()
        {
            switch (ddlItemType.SelectedIndex)
            {
                case 0:
                    PanelOption.Style["display"] = "block";
                    PanelDaFen.Style["display"] = "None";
                    PanelFamula.Style["display"] = "None";
                    break;
                case 2:
                    PanelOption.Style["display"] = "None";
                    PanelDaFen.Style["display"] = "block";
                    PanelFamula.Style["display"] = "None";
                    break;
                case 3:
                    PanelOption.Style["display"] = "None";
                    PanelDaFen.Style["display"] = "None";
                    PanelFamula.Style["display"] = "block";
                    break;
                default:
                    PanelOption.Style["display"] = "None";
                    PanelDaFen.Style["display"] = "None";
                    PanelFamula.Style["display"] = "None";
                    break;
            }
        }

        public OperateType ItemOperateType
        {
            get
            {
                if (chkItemType.Checked)
                {
                    return OperateType.HR;
                }
                else
                {
                    return OperateType.NotHR;
                }
            }
            set
            {
                if (value == OperateType.HR)
                {
                    chkItemType.Checked = true;
                }
                else
                {
                    chkItemType.Checked = false;
                }
            }
        }


        public Dictionary<string, string> ClassficationSource
        {
            set
            {
                listClassfication.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listClassfication.Items.Add(item);
                }
            }
        }

        public string ClassficationId
        {
            get { return listClassfication.SelectedValue; }
            set { listClassfication.SelectedValue = value; }
        }

        public string Option5
        {
            get { return txtOption5.Text.Trim(); }
            set { txtOption5.Text = value; }
        }

        public string Option4
        {
            get { return txtOption4.Text.Trim(); }
            set { txtOption4.Text = value; }
        }

        public string Option3
        {
            get { return txtOption3.Text.Trim(); }
            set { txtOption3.Text = value; }
        }

        public string Option2
        {
            get { return txtOption2.Text.Trim(); }
            set { txtOption2.Text = value; }
        }

        public string Option1
        {
            get { return txtOption1.Text.Trim(); }
            set { txtOption1.Text = value; }
        }

        public string ItemMessage5
        {
            set { lblOptionMessage5.Text = value; }
        }

        public string ItemMessage4
        {
            set { lblOptionMessage4.Text = value; }
        }

        public string ItemMessage3
        {
            set { lblOptionMessage3.Text = value; }
        }

        public string ItemMessage2
        {
            set { lblOptionMessage2.Text = value; }
        }

        public string ItemMessage1
        {
            set { lblOptionMessage1.Text = value; }
        }


        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        public string PageTitle
        {
            set { lblTilte.Text = value; }
        }

        public bool ReadOnly
        {
            set
            {
                txtQuestion.ReadOnly = value;
                txtOption5.ReadOnly = value;
                txtOption4.ReadOnly = value;
                txtOption3.ReadOnly = value;
                txtOption2.ReadOnly = value;
                txtOption1.ReadOnly = value;
                txtDescription.ReadOnly = value;
                listClassfication.Enabled = !value;
                chkItemType.Enabled = !value;
            }
        }

        #region 打分项

        public string MaxRange
        {
            get { return txtMax.Text.Trim(); }
            set { txtMax.Text=value; }
        }

        public string MinRange
        {
            get { return txtMin.Text.Trim(); }
            set { txtMin.Text = value; }
        }

        public string RangeError
        {
            set { lbMinMaxError.Text = value; }
        }

        #endregion

        #region 公式

        public string Formula
        {
            get { return txtFormula.Text; }
            set { txtFormula.Text = value; }
        }

        public string FormulaError
        {
            set { lblFormula.Text = value; }
        }

        public string FormulaSummary
        {
            get
            {
                List<AssessBindItemEnum> enums = AssessBindItemEnum.GetAllAssessBindItemEnum();
                string f="";
                foreach (AssessBindItemEnum itemEnum in enums)
                {
                    f = string.Format("{2}A{0}{1}；&nbsp;", itemEnum.ID, itemEnum.Name, f);
                }
                return f;           
            }
        }
        #endregion

        public EventHandler btnOkClickEvent;

        protected void btnOk_Click(object sender, EventArgs e)
        {
            btnOkClickEvent(sender, e);
        }

        public EventHandler btnCancleClickEvent;

        protected void btnCancle_Click1(object sender, EventArgs e)
        {
            btnCancleClickEvent(sender, e);
        }
    }
}
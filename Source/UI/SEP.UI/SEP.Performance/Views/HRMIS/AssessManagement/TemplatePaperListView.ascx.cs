using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.Model.Positions;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AssessManagement
{
    public partial class TemplatePaperListView : UserControl, ITemplatePaperListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvPaperlist, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grvPaperlist.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        private List<AssessTemplatePaper> _Papers;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (BtnSearchEvent != null)
                BtnSearchEvent();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (BtnAddEvent != null)
                BtnAddEvent();
        }

        protected void btnModify_Command(object sender, CommandEventArgs e)
        {
            if (BtnUpdateEvent != null)
                BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            if (BtnUpdateEvent != null)
                BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void tbnCopy_Command(object sender, CommandEventArgs e)
        {
            if (BtnCopyEvent != null)
                BtnCopyEvent(e.CommandArgument.ToString());
        }

        protected void grvPaperlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvPaperlist.PageIndex = e.NewPageIndex;
            if (BtnUpdateEvent != null)
                BtnSearchEvent();
        }

        protected void grvPaperlist_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    if (BtnDetailEvent != null)
                        BtnDetailEvent(e.CommandArgument.ToString());
                    break;
                default:
                    break;
            }
        }
        
        protected void gvPaperlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {              
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        #region ITemplatePaperListView ��Ա

        public string TemplatePaperName
        {
            get
            {
                return txtPaperName.Text.Trim();
            }
            set
            {
                txtPaperName.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public List<AssessTemplatePaper> AssessTemplatePapers
        {
            get
            {
                return _Papers;
            }
            set
            {
                _Papers = value;
                grvPaperlist.DataSource = value;
                grvPaperlist.DataBind();
                if (_Papers == null || _Papers.Count == 0)
                {
                    tbPaperList.Style["display"] = "none";
                }
                else
                {
                    tbPaperList.Style["display"] = "block";

                }
                lblMessage.Text = "<span class=\"font14b\">���鵽 <span class=\"fontred\">" 
                                   + value.Count+"</span> ����¼</span>";
            }
        }
        public event DelegateNoParameter BtnSearchEvent;
        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnCopyEvent;
        public AssessTemplatePaper SessionCopyPaper
        {
            get
            {
                return Session[SessionKeys.SESSIONCOPYPAPER] as AssessTemplatePaper;
            }
            set
            {
                Session[SessionKeys.SESSIONCOPYPAPER] = value;
            }
        }

        #endregion

        #region ����
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void Export()
        {
            string FileName = "��Ч���˱�" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day +
                              DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond +
                              ".xls";
            GC.Collect();
            Application excel = new Application();

            _Workbook xBk = excel.Workbooks.Add(HttpContext.Current.Request.PhysicalApplicationPath +
                                         @"\Pages\HRMIS\Template\empty2003Excel.xls");
            _Worksheet xSt = (_Worksheet)xBk.ActiveSheet;
            xSt.Name = "��Ч���˱�";
            TemplateBuildStringWriter(excel);
            ExcelExportUtility.OutputExcelByTemplocation(Server, Response, excel, xBk, xSt, FileName);
        }

        /// <summary>
        /// ���ɱ�����
        /// </summary>
        private void TemplateBuildStringWriter(_Application excel)
        {
            //���ɱ�ͷ
            TemplateBuildHead(excel);
            //��������
            TemplateBuildBody(excel);
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void TemplateBuildBody(_Application excel)
        {
            List<AssessTemplatePaper> itsSource =
                InstanceFactory.CreateAssessManagementFacade().GetTemplatePapersAllInfoByPaperName(TemplatePaperName);
            int j = 0;
            for (int k = 0; k < itsSource.Count; k++)
            {
                for (int i = 0; i < itsSource[k].ItsAssessTemplateItems.Count; i++)
                {
                    excel.Cells[j + 2 + i, 1] = itsSource[k].PaperName;
                    excel.Cells[j + 2 + i, 2] = itsSource[k].PositionList != null
                                                    ? PositionNames(itsSource[k].PositionList)
                                                    : "";
                    excel.Cells[j + 2 + i, 3] = itsSource[k].ItsAssessTemplateItems[i].Question;
                    excel.Cells[j + 2 + i, 4] = itsSource[k].ItsAssessTemplateItems[i].Weight;
                    excel.Cells[j + 2 + i, 5] = itsSource[k].ItsAssessTemplateItems[i].Description;
                }
                j = j + itsSource[k].ItsAssessTemplateItems.Count;
            }
        }

        /// <summary>
        /// ���ɱ�ͷ
        /// </summary>
        private static void TemplateBuildHead( _Application excel)
        {
            excel.Cells[1, 1] = "���˱���";
            excel.Cells[1, 2] = "��λ";
            excel.Cells[1, 3] = "��Чָ��";
            excel.Cells[1, 4] = "Ȩ��";
            excel.Cells[1, 5] = "��Чָ������˵��";
        }

        private static string PositionNames(List<Position> positions)
        {
            string ret = "";
            foreach (Position item in positions)
            {
                ret += string.IsNullOrEmpty(ret) ? item.Name : (item.Name + ", ");
            }
            return ret;
        }
        #endregion

        protected void btnInport_Click(object sender, EventArgs e)
        {
            Import();
        }
        private void Import()
        {
            string uploadFileLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(uploadFileLocation))
            {
                Directory.CreateDirectory(uploadFileLocation);
            }
            HttpPostedFile hpf = fuExcel.PostedFile;
            if (hpf != null)
            {
                string filename = Path.GetFileName(hpf.FileName);
                string fileExt = Path.GetExtension(hpf.FileName);
                string filePath = uploadFileLocation + "\\Ա������.xls";
                if (Validation(filename, fileExt))
                {
                    hpf.SaveAs(filePath);
                    if (ImportEvent != null)
                    {
                        ImportEvent(filePath);
                    }
                }
            }
        }

        public event DelegateID ImportEvent;
        private bool Validation(string filename, string fileExt)
        {
            if (!string.IsNullOrEmpty(filename.Trim()))
            {
                if (fileExt == ".xls" || fileExt == ".xlsx")
                {
                    return true;
                }
                lblMessage.Text = "<span class='fontred'>������ļ���ʽ����</span>";
                return false;
            }
            lblMessage.Text = "<span class='fontred'>û��Ҫ������ļ�</span>";
            return false;
        }
    }
}






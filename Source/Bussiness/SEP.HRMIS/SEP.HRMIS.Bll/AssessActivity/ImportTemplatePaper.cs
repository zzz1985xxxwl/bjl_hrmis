using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Model.Positions;
using ModelPayModule = SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Bll.AssessActivity
{
    public class ImportTemplatePaper: Transaction
    {
        private int FailCount = 0;
        private string FailMessage = string.Empty;
        private string PaperNull = string.Empty;
        private string ItemNull = string.Empty;
        private string PositionNull = string.Empty;
        public string ResultMessage = string.Empty;
        private readonly string _FilePath;
        /// <summary>
        /// ���캯��
        /// </summary>
        public ImportTemplatePaper(string filePath)
        {
            _FilePath = filePath;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            DataSet ds = LoadDataFromExcel(_FilePath.Trim());
            InsertTemplatePaper(ds);
        }
        /// <summary>
        /// ����Ա��������
        /// </summary>
        /// <param name="ds"></param>
        private void InsertTemplatePaper(DataSet ds)
        {
            List<AssessTemplatePaper> papers = new List<AssessTemplatePaper>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AssessTemplatePaper paper =
                    AssessTemplatePaper.FindByName(ds.Tables[0].Rows[i]["���˱���"].ToString(), papers);
                if (paper == null)
                {
                    paper =
                        new AssessTemplatePaper(0, ds.Tables[0].Rows[i]["���˱���"].ToString(),
                                                new List<AssessTemplateItem>());
                    paper.PositionList = new List<Position>();
                    if (!string.IsNullOrEmpty(paper.PaperName))
                    {
                        papers.Add(paper);
                    }
                }
                string[] positions = ds.Tables[0].Rows[i]["��λ"].ToString().Split(',');
                foreach (string s in positions)
                {
                    if (string.IsNullOrEmpty(s.Trim()))
                    {
                        continue;
                    }
                    Position position = AssessTemplatePaper.FindPositionByPositionName(s.Trim(), papers);
                    if (position == null)
                    {
                        position = new Position();
                        position.Name = s.Trim();
                        if (!string.IsNullOrEmpty(position.Name))
                        {
                            paper.PositionList.Add(position);
                        }
                    }
                }
                AssessTemplateItem item =
                    AssessTemplatePaper.FindItemByItemName(ds.Tables[0].Rows[i]["��Чָ��"].ToString(), papers);
                if (item == null)
                {
                    item = new AssessTemplateItem(0, ds.Tables[0].Rows[i]["��Чָ��"].ToString(), new OperateType());
                    if (!string.IsNullOrEmpty(item.Question))
                    {
                        paper.ItsAssessTemplateItems.Add(item);
                    }
                }
                decimal d_try;
                decimal.TryParse(ds.Tables[0].Rows[i]["Ȩ��"].ToString(), out d_try);
                item.Weight = d_try;
                item.Description = ds.Tables[0].Rows[i]["��Чָ������˵��"].ToString();
            }
            ToImportIntoDB(papers);
        }

        private void ToImportIntoDB(List<AssessTemplatePaper> papers)
        {
            for (int i = 0; i < papers.Count; i++)
            {
                if (string.IsNullOrEmpty(papers[i].PaperName))
                {
                    continue;
                }
                AssessTemplatePaper paper = new GetAssessManagement().GetAssessTempletPaperByName(papers[i].PaperName);
                if (paper == null)
                {
                    PaperNull += string.IsNullOrEmpty(PaperNull) ? papers[i].PaperName :( ";" + papers[i].PaperName);
                    paper = papers[i];
                }
                paper.PositionList = papers[i].PositionList;
                paper.ItsAssessTemplateItems = papers[i].ItsAssessTemplateItems;
                for (int j = 0; j < paper.PositionList.Count; j++)
                {
                    if (string.IsNullOrEmpty(paper.PositionList[j].Name))
                    {
                        continue;
                    }
                    Position p =
                        BllInstance.PositionBllInstance.GetPositionByName(paper.PositionList[j].Name, null);
                    if (p == null)
                    {
                        PositionNull += string.IsNullOrEmpty(PositionNull)
                                            ? paper.PositionList[j].Name
                                            : (";" + paper.PositionList[j].Name);

                        Account account = new Account(-9, "admin", "admin");
                        account.Auths = new List<Auth>();
                        Auth auth = new Auth(Powers.A202, "");
                        auth.Type = AuthType.SEP;
                        account.Auths.Add(auth);
                        paper.PositionList[j].Description = "";
                        BllInstance.PositionBllInstance.CreatePosition(paper.PositionList[j], account);
                        p = paper.PositionList[j];
                    }
                    paper.PositionList[j] = p;
                }
                for (int j = 0; j < paper.ItsAssessTemplateItems.Count; j++)
                {
                    if (string.IsNullOrEmpty(paper.ItsAssessTemplateItems[j].Question))
                    {
                        continue;
                    }
                    AssessTemplateItem item =  new GetAssessManagement().GetTemplateItemByName(paper.ItsAssessTemplateItems[j].Question);
                    if (item == null)
                    {
                        ItemNull += string.IsNullOrEmpty(ItemNull)
                                        ? paper.ItsAssessTemplateItems[j].Question
                                        : (";" + paper.ItsAssessTemplateItems[j].Question);
                        paper.ItsAssessTemplateItems[j].AssessTemplateItemType = AssessTemplateItemType.Score;
                        paper.ItsAssessTemplateItems[j].Option = "0/100";
                        paper.ItsAssessTemplateItems[j].Classfication = ItemClassficationEmnu.Performance;
                        paper.ItsAssessTemplateItems[j].ItsOperateType = OperateType.NotHR;
                        new InsertAssessItem(paper.ItsAssessTemplateItems[j]).Excute();
                        item = paper.ItsAssessTemplateItems[j];
                    }
                    else
                    {
                        if (item.Description != paper.ItsAssessTemplateItems[j].Description)
                        {
                            item.Description = paper.ItsAssessTemplateItems[j].Description;
                            new UpdateAssessItem(item).Excute();
                        }
                    }
                    item.Weight = paper.ItsAssessTemplateItems[j].Weight;
                    paper.ItsAssessTemplateItems[j] = item;
                }
                try
                {
                    if (paper.AssessTemplatePaperID == 0)
                    {
                        new InsertAssessPaper(paper).Excute();
                    }
                    else
                    {
                        new UpdateAssessPaper(paper).Excute();
                    }
                }
                catch(Exception ex)
                {
                    FailMessage += string.IsNullOrEmpty(FailMessage) ? "" : "<br />";
                    FailMessage += paper.PaperName + "����ʧ�ܣ�" + ex.Message;
                    FailCount++;
                }
            }
            ResultMessage = "�ɹ�����" + (papers.Count - FailCount) + "����¼��" + FailCount + "ʧ�ܡ�<br />";
            ResultMessage += string.IsNullOrEmpty(FailMessage) ? "" : (FailMessage) + "<br />";
            ResultMessage += string.IsNullOrEmpty(PaperNull) ? "" : (PaperNull + " ���˱����ڣ�ϵͳ���Զ�����<br />");
            ResultMessage += string.IsNullOrEmpty(PositionNull) ? "" : (PositionNull + " ���ְλ�����ڣ�ϵͳ���Զ�����<br />");
            ResultMessage += string.IsNullOrEmpty(ItemNull) ? "" : (ItemNull + " ��������ڣ�ϵͳ���Զ�����<br />");
        }

        /// <summary>
        /// ����Excel 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private static DataSet LoadDataFromExcel(string filePath)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 5.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM [��Ч���˱�$]";//���Ǹ���Sheet���ƣ�����sheet2���ȵ� 

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "Sheet1");
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                throw new Exception("Excel���ݻ�ȡʧ��!ʧ��ԭ��" + err.Message);
            }
        }

    }
}

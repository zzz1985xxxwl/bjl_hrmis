using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class MyReimburse : BasePage
    {
        private ReimbursingListPresenter reimbursingListPresenter;
        //private ReimburseHistoryListPresenter reimburseHistoryListPresenter;
        //private ReimburseConfirmListPresenter reimburseConfirmListPresenter;
        //private ReimburseConfirmHistoryListPresenter reimburseConfirmHistoryListPresenter; 
        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad(IsPostBack);
        }

        private void PageLoad(bool ispostback)
        {
            // 我的报销单
            reimbursingListPresenter = new ReimbursingListPresenter(LoginUser, ReimbursingListView1);
            reimbursingListPresenter.btnAddClick += Add_Command;
            reimbursingListPresenter.btnUpdateClick += Update_Command;
            reimbursingListPresenter.btnDeleteClick += Delete_Command;
            reimbursingListPresenter.btnViewClick += Detail_Command;
            reimbursingListPresenter.Init(ispostback);
            // 报销单历史
            //reimburseHistoryListPresenter =
            //    new ReimburseHistoryListPresenter(LoginUser.Id, ReimburseHistoryListView1);
            //reimburseHistoryListPresenter.btnViewClick += Detail_Command;
            //reimburseHistoryListPresenter.Init(IsPostBack);
            // 待审核的报销单
            //reimburseConfirmListPresenter = new ReimburseConfirmListPresenter(LoginUser, ReimburseConfirmListView1);
            //reimburseConfirmListPresenter.btnViewClick += Detail_Command;
            //reimburseConfirmListPresenter.btnUpdateClick += Update_Command;
            //reimburseConfirmListPresenter.Init(ispostback);

            //// 我审核的报销单历史
            //reimburseConfirmHistoryListPresenter =
            //    new ReimburseConfirmHistoryListPresenter(LoginUser.Id, ReimburseConfirmHistoryListView1);
            //reimburseConfirmHistoryListPresenter.btnViewClick += Detail_Command;
            //reimburseConfirmHistoryListPresenter.Init(ispostback);

            ShowMessage();

            //ReimburseConfirmListView1.UpdateView += UpdatePanel;
            ReimbursingListView1.UpdateView += UpdatePanel;


        }

        private void ShowMessage()
        {
            lblReimbursingCount.Text = ReimbursingListView1.ListCount.ToString();
            //lblReimburseHistoryCount.Text = ReimburseHistoryListView1.ListCount.ToString();
            //lblReimbursingConfirmCount.Text = ReimburseConfirmListView1.ListCount.ToString();
            //lblReimbursingConfirmListCount.Text = ReimburseConfirmHistoryListView1.ListCount.ToString();
        }

        private void Add_Command(object sender, EventArgs e)
        {
            Response.Redirect("ReimburseAdd.aspx", false);
        }
        private void Update_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ReimburseUpdate.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }
        private void Delete_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ReimburseDelete.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }
        private void Detail_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ReimburseDetail.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        private void UpdatePanel()
        {
            PageLoad(false);
            UpdatePanel1.Update();
        }

    }
}

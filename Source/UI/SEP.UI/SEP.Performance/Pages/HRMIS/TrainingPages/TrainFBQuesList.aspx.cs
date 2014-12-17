using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.Train;
using SEP.Model;
using ShiXin.Security;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class TrainFBQuesList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A804))
            {
                throw new ApplicationException("没有权限访问");
            }
            TrainFBQuestionListPrenseter presenter = new TrainFBQuestionListPrenseter(TrainFBQuestionList1);

            TrainFBQuestionList1.BtnAddEvent += ToAddPage;
            TrainFBQuestionList1.BtnUpdateEvent += ToUpdatePage;
            TrainFBQuestionList1.BtnDeleteEvent += ToDeletePage;
            TrainFBQuestionList1.BtnDetailEvent += ToDetailPage;
            //TrainFBQuestionList1.BtnItemEvent += ToItemPage1;

            presenter.InitView(IsPostBack);
        }

        private void ToAddPage(object sender, EventArgs e)
        {
            Response.Redirect("AddTrainFBQuesAndItem.aspx");
        }

        private void ToUpdatePage(object sender, CommandEventArgs e)
        {
            Response.Redirect("UpdateTrainFBQuesAndItem.aspx?FBQuestioniD=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        private void ToDeletePage(object sender, CommandEventArgs e)
        {
            Response.Redirect("DeleteTrainFBQuesAndItem.aspx?FBQuestioniD=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        private void ToDetailPage(object sender, CommandEventArgs e)
        {
            Response.Redirect("DetailTrainFBQuesAndItem.aspx?FBQuestioniD=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        //private void ToItemPage(object sender, CommandEventArgs e)
        //{
        //     Response.Redirect("TrainFBItemList.aspx?FBQuestioniD=" + iSecurity.EncryptQueryString(e.CommandArgument.ToString()));
        //}

        //private void ToItemPage1(object sender, CommandEventArgs e)
        //{
        //    Response.Redirect("TrainFBItemList.aspx?FBQuestioniD=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        //}
    }
}

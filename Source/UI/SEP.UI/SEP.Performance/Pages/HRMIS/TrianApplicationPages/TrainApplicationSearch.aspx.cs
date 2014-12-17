using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.TrainApplication;

namespace SEP.Performance.Pages.HRMIS.TrianApplicationPages
{
    public partial class TrainApplicationSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A806))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            }
            TrainApplicationSearchPresenter presenter = new TrainApplicationSearchPresenter(SearchTrainApplicationView1,LoginUser);

            //TrainFBQuestionList1.BtnItemEvent += ToItemPage1;

            presenter.Init(IsPostBack);
        }
    }
}

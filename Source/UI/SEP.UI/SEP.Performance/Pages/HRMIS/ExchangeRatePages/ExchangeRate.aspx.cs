using System;
using System.Web.UI.WebControls;
using Framework.Common;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Views;

namespace SEP.Performance.Pages.HRMIS.ExchangeRatePages
{
    public partial class ExchangeRate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A1011))
            {
                throw new ApplicationException("没有权限访问");
            }
            BindDataSource();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvExchangeRate.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvExchangeRate, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataSource();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DialogMessage = string.Empty;
            txtDialogName.Text = string.Empty;
            txtDialogRate.Text = string.Empty;
            txtDialogSymbol.Text = string.Empty;
            txtDialogActiveDate.Text = DateTime.Now.ToString("yyyy-MM");
            hfPKID.Value = string.Empty;
            lblNameMessage.Text = string.Empty;
            lblOperation.Text = "新增汇率信息";
            mpeInfo.Show();
        }

        protected void gvExchangeRate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExchangeRate.PageIndex = e.NewPageIndex;
            BindDataSource();
        }

        protected void gvExchangeRate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    return;
            }
        }

        protected void gvExchangeRate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            DialogMessage = string.Empty;
            hfPKID.Value = e.CommandArgument.ToString();
            lblNameMessage.Text = string.Empty;
            lblRateMessage.Text = string.Empty;
            lblActiveDateMessage.Text = string.Empty;
            lblSymbolMessage.Text = string.Empty;
            lblOperation.Text = "更新汇率信息";
            try
            {
                var entity = ExchangeRateLogic.GetExchangeRateByPKID(Convert.ToInt32(e.CommandArgument));
                txtDialogName.Text = entity.Name;
                txtDialogRate.Text = entity.Rate.ToString();
                txtDialogActiveDate.Text = entity.ActiveDate.ToString("yyyy-MM");
                txtDialogSymbol.Text = entity.Symbol;
                mpeInfo.Show();
            }
            catch (ApplicationException ex)
            {
                lblMessage.Text = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            try
            {
                ExchangeRateLogic.DeleteExchangeRate(Convert.ToInt32(e.CommandArgument));
                BindDataSource();
            }
            catch (ApplicationException ex)
            {
                lblMessage.Text = "<span class='fontred'>" + ex.Message + "</span>";
            }
        }

        private void BindDataSource()
        {
            var source = ExchangeRateLogic.GetExchangeRateByCondition(txtName.Text.Trim(),txtActiveDate.Text.SafeToDateTime());
            gvExchangeRate.DataSource = source;
            gvExchangeRate.DataBind();
            lblMessage.Text = " <span class='font14b'>共查到 </span><span class='fontred'>" + source.Count +
                              "</span><span class='font14b'> 条记录</span>";
        }

        #region 小界面

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (!Valid())
            {
                mpeInfo.Show();
                return;
            }
            try
            {
                ExchangeRateEntity entity = new ExchangeRateEntity
                                                {
                                                    Name = txtDialogName.Text.Trim(),
                                                    Rate = Convert.ToDecimal(txtDialogRate.Text),
                                                    PKID = hfPKID.Value.SafeToInt(),
                                                    ActiveDate = txtDialogActiveDate.Text.SafeToDateTime().GetValueOrDefault(),
                                                    Symbol = txtDialogSymbol.Text.Trim()
                                                };
                if (entity.PKID > 0)
                {
                    ExchangeRateLogic.UpdateExchangeRate(entity);
                }
                else
                {
                    ExchangeRateLogic.InsertExchangeRate(entity);
                }
                mpeInfo.Hide();
                BindDataSource();
            }
            catch (Exception ex)
            {
                DialogMessage = "<span class='fontred'>" + ex.Message + "</span>";
                mpeInfo.Show();
            }
        }

        private string DialogMessage
        {
            set
            {
                lblDialogMessage.Text = value;
                tbMessage.Visible = true;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Visible = false;
                }
            }
        }

        private bool Valid()
        {
            var ans = true;
            decimal temp;
            if (string.IsNullOrEmpty(txtDialogName.Text.Trim()))
            {
                lblNameMessage.Text = "不能为空";
                ans = false;
            }
            if (string.IsNullOrEmpty(txtDialogRate.Text.Trim()))
            {
                lblRateMessage.Text = "不能为空";
                ans = false;
            }
            else if (!decimal.TryParse(txtDialogRate.Text, out temp))
            {
                lblRateMessage.Text = "格式错误";
                ans = false;
            }
            DateTime dt;
            if (string.IsNullOrEmpty(txtDialogActiveDate.Text.Trim()))
            {
                lblActiveDateMessage.Text = "不能为空";
                ans = false;
            }
            else if (!DateTime.TryParse(txtDialogActiveDate.Text, out dt))
            {
                lblActiveDateMessage.Text = "格式错误";
                ans = false;
            }
            if (ans)
            {
                lblNameMessage.Text = string.Empty;
                lblRateMessage.Text = string.Empty;
                lblActiveDateMessage.Text = string.Empty;
            }
            return ans;
        }

        #endregion
    }
}
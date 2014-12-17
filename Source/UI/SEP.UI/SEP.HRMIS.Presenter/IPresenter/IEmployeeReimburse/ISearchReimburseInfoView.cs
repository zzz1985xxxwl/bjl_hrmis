

using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter
{
    public interface ISearchReimburseInfoView
    {
        /// <summary>
        /// 报销列表界面
        /// </summary>
        ISearchReimburseView SearchReimburseView { get;}

        /// <summary>
        /// 记账时间
        /// </summary>
        IBillingTimeDetailView BillingTimeDetailView { get;}

        /// <summary>
        /// 小界面可见
        /// </summary>
        bool BillingTimeDetailViewVisible { set;}

    }
}



using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;

namespace SEP.HRMIS.Presenter
{
    public interface ISearchReimburseInfoView
    {
        /// <summary>
        /// �����б����
        /// </summary>
        ISearchReimburseView SearchReimburseView { get;}

        /// <summary>
        /// ����ʱ��
        /// </summary>
        IBillingTimeDetailView BillingTimeDetailView { get;}

        /// <summary>
        /// С����ɼ�
        /// </summary>
        bool BillingTimeDetailViewVisible { set;}

    }
}

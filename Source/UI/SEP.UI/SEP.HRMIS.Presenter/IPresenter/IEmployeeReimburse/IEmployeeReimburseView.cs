
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IEmployeeReimburseView
    {
        IReimburseView IReimburseView { get; set;}
        IReimburseItemView IReimburseItemView { get; set;}
        /// <summary>
        /// 小界面是否可见
        /// </summary>
        bool ReimburseItemVisiable { get; set;}

        string divMPEReimburseClientID { get; }
    }

    public delegate void DlgReimburseItems(List<ReimburseItem> reimburseItems);
}

using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet
{
    public interface IAccountSetView
    {
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        string AccountSetNameMsg { set; }

        string Message { set; }

        string AccountSetName { get; set;}

        string Description { get; set; }

        string OperationTitle { get; set; }

        bool SetFormReadOnly { set; }

        List<AccountSetItem> AccountSetItemList { get; set; }

        List<AccountSetPara> AccountSetPara { set; }

        event Delegate2Parameter txtAccountSetParaChangedForUpdateEvent;
        event DelegateID txtAccountSetParaChangedForAddEvent;
        event DelegateID lbDeleteItemEvent;
        event DelegateID lbAddNewItemEvent;
        event DelegateID lbUpItemEvent;
        event DelegateID lbDownItemEvent;
        event DelegateNoParameter btnCopyEvent;
        event DelegateNoParameter btnPasteEvent;
        Model.PayModule.AccountSet SessionCopyAccountSet { get; set; }

        bool SetbtnPasteVisible { set; }

        string OperatorName { get; }
    }
}

using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet
{
    public interface IAccountSetParaView
    {
        /// <summary>
        /// 确认按钮事件
        /// </summary>
        event DelegateNoParameter ActionButtonEvent;
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        event DelegateNoParameter CancelButtonEvent;

        string AccountSetParaNameMsg { get; set; }

        string BindItemMsg { get; set; }

        string Message { get; set; }

        string OperationTitle { get; set; }

        string AccountSetParaName { get; set; }

        FieldAttributeEnum SelectedFieldAttribute { get; set; }

        BindItemEnum SelectedBindItem { get; set; }

        string OperationType { get; set; }

        string AccountSetParaID { get; set; }

        string Description { get; set; }

        MantissaRoundEnum SelectedMantissaRound { get; set; }

        List<FieldAttributeEnum> FieldAttributeSource { get; set; }

        List<BindItemEnum> BindItemSource { get; set; }

        List<MantissaRoundEnum> MantissaRoundSource { get; set; }

        bool ActionSuccess { get; set;}

        bool SetReadonly { get; set; }

        string OperatorName { get; }

        bool IsVisibleToEmployee { get; set; }

        bool IsVisibleWhenZero { get; set; }
    }
}
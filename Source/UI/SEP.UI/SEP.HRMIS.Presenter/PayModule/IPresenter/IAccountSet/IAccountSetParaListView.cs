using System.Collections.Generic;
using SEP.HRMIS.Model.PayModule;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet
{
    public interface IAccountSetParaListView
    {
        string AccountSetParaName { set; get;}

        BindItemEnum SelectedBindItem { set; get;}

        FieldAttributeEnum SelectedFieldAttribute { set; get;}

        MantissaRoundEnum SelectedMantissaRound { set; get;}

        string Message { set; get;}

        List<AccountSetPara> AccountSetParaList { set; get;}

        List<FieldAttributeEnum> FieldAttributeSource { get; set; }

        List<BindItemEnum> BindItemSource { get; set; }

        List<MantissaRoundEnum> MantissaRoundSource { get; set; }


        /// <summary>
        /// 查询按钮事件
        /// </summary>
        event DelegateNoParameter btnSearchClick;

        /// <summary>
        /// 新增按钮事件
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// 查看详情界面
        /// </summary>
        event DelegateID BtnDetailEvent;
    }
}

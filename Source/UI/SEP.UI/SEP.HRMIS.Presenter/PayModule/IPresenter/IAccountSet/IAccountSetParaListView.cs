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
        /// ��ѯ��ť�¼�
        /// </summary>
        event DelegateNoParameter btnSearchClick;

        /// <summary>
        /// ������ť�¼�
        /// </summary>
        event DelegateNoParameter BtnAddEvent;
        /// <summary>
        /// �޸İ�ť�¼�
        /// </summary>
        event DelegateID BtnUpdateEvent;
        /// <summary>
        /// ɾ����ť�¼�
        /// </summary>
        event DelegateID BtnDeleteEvent;

        /// <summary>
        /// �鿴�������
        /// </summary>
        event DelegateID BtnDetailEvent;
    }
}


using System.Collections.Generic;
using SEP.Presenter.Indexs;

namespace SEP.Presenter.IPresenter.IIndexs
{
    public interface IIndexEditView
    {
        List<IndexItem> SepToolList{ get; set;}
        List<IndexItem> HrmisToolList { get; set;}
        List<IndexItem> CrmToolList { get; set;}
        List<IndexItem> MyCmmiToolList { get; set;}
    }
}

using System.Collections.Generic;

namespace SEP.HRMIS.Presenter.IPresenter
{
    public interface IFileCargoView
    {
        string FileCargoName { get; set;}
        string Remark { get; set;}

        Dictionary<int, string> FileCargoNameSource { set; get;}

        int FileCargoID { get; set;}

        string Title { get; set;}
        string Id { get; set;}
    }
}

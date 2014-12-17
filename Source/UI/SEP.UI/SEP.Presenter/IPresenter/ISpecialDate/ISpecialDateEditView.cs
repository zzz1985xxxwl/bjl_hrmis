namespace SEP.Presenter.IPresenter.ISpecialDate
{
    public interface ISpecialDateEditView
    {
        string ValidateTitle { set; get;}
        string ResultMessage { set;get; }

        string SpecialDateID { get;set;}
        string SpecialDate { get;set;}
        int IsWork { get;set;}
        string SpecialHeader { get;set;}
        string SpecialDescription { get;set;}
        string SpecialForeColor { get;set;}
        string SpecialBackColor { get;set;}
        bool ActionSuccess { get; set;}

        event DelegateID ActionButtonEvent;
        event DelegateNoParameter CancelButtonEvent;
    }
}

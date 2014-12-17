namespace SEP.HRMIS.Presenter.IPresenter.ITrainApplication
{
    public interface IMyTrainApplicationInfoView
    {
        IMyTrainApplicationView MyTrainApplicationListView { get;}

        ITrainApplicationOperatorView OperationView { get;}

        ITrainApplicationConfirmListView ConfirmListView { get;}

        ITrainApplicationConfirmHistoryView ConfirmHistoryListView { get;}

        bool OperationViewVisible { set;}

        string TrainApplicationConfirmCount { get; set;}

        string MyTrainApplicationCount { get; set;}

        string TrainApplicationConfirmHistoryCount { get; set;}

        string ResultMessage { get; set;}
    }
}

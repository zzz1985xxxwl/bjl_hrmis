using SEP.Model.Accounts;

namespace SEP.Presenter.IPresenter.IPositions
{
    public interface IPositionView
    {
        string Message { set;}
        string PositionMsg { set;}
        //string GradeMsg { set;}
        string Title { set;}
        bool SetReadonly { set; }

        string positionID { get; set; }
        string positionName { get; set;}

        //List<PositionGrade> PositionGradeSource { set;}

        //string PositionGradeId { get;set;}
        //string PositionGradeName { get;set;}

        string OperationType { get; set;}

        event DelegateNoParameter ActionButtonEvent;

        event DelegateNoParameter CancelButtonEvent;

        string CancelButtonClientEvent { set; }

        bool ActionSuccess { get; set;}

        Account Operator { get;}
        string Description { get; set; }
    }
}

using SEP.Model.Positions;
using SEP.Presenter.IPresenter;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Presenter.Positions
{
    internal class PositionDataCollector : IDataCollector<Position>
    {
        private readonly IPositionView _ItsView;

        public PositionDataCollector(IPositionView itsView)
        {
            _ItsView = itsView;
        }

        #region IDataCollector<Position> ≥…‘±

        public void CompleteTheObject(Position theObjectToComplete)
        {
            if (theObjectToComplete != null)
            {
                theObjectToComplete.Name = _ItsView.positionName;
                theObjectToComplete.Description = _ItsView.Description;
                //int levelId;
                //if (int.TryParse(_ItsView.PositionGradeId, out levelId))
                //{
                //    theObjectToComplete.Level = new PositionGrade();
                //    theObjectToComplete.Level.Id = levelId;
                //}
            }
        }

        #endregion
    }
}

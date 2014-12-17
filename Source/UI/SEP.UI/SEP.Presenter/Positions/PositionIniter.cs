using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model.Positions;
using SEP.Presenter.IPresenter;
using SEP.IBll;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Presenter.Positions
{
    internal class PositionIniter : IViewIniter
    {
        private IPositionView _ItsView;

        public PositionIniter(IPositionView itsView)
        {
            _ItsView = itsView;
        }

        //private void BindTypesSource()
        //{
        //    List<PositionGrade> positionGradeSource = BllInstance.PositionBllInstance.GetAllPositionGrade();
        //    if (positionGradeSource != null)
        //    {
        //        _ItsView.PositionGradeSource = positionGradeSource;
        //    }
        //}
        #region IViewIniter ≥…‘±

        public void InitTheViewToDefault()
        {
            _ItsView.Message = string.Empty;
            _ItsView.PositionMsg = string.Empty;
            //_ItsView.GradeMsg = string.Empty;
            _ItsView.positionID = string.Empty;
            _ItsView.positionName = string.Empty;

            //BindTypesSource();
        }

        #endregion
    }
}

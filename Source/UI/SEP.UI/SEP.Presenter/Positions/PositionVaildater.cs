using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model;
using SEP.Presenter.IPresenter.IPositions;

namespace SEP.Presenter.Positions
{
    internal class PositionVaildater
    {
        private readonly IPositionView _ItsView;

        public PositionVaildater(IPositionView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.Message = String.Empty;
            _ItsView.PositionMsg = String.Empty;
            //_ItsView.GradeMsg = String.Empty;

            if (string.IsNullOrEmpty(_ItsView.positionName.Trim()))
            {
                _ItsView.PositionMsg = MessageKeys._Position_NameIsEmpty;
                return false;
            }
            return true;
        }
    }
}

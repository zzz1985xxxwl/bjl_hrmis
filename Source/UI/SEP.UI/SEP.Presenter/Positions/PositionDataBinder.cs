using System;
using System.Collections.Generic;
using System.Text;
using SEP.Model.Accounts;
using SEP.Model.Positions;
using SEP.Presenter.IPresenter.IPositions;
using SEP.IBll;

namespace SEP.Presenter.Positions
{
    internal class PositionDataBinder
    {
        private IPositionView _ItsView;
        private Account _LoginUser;

        public PositionDataBinder(IPositionView itsView, Account loginUser)
        {
            _ItsView = itsView;
            _LoginUser = loginUser;
        }

        public bool DataBind(string positionId)
        {
            int id;
            if (!int.TryParse(positionId, out id))
            {
                return SetViewUnable();
            }

            Position theDataToBind = BllInstance.PositionBllInstance.GetPositionById(id, _LoginUser);
            if (theDataToBind != null)
            {
                _ItsView.positionID = theDataToBind.Id.ToString();
                _ItsView.positionName = theDataToBind.Name;
                _ItsView.Description = theDataToBind.Description;
                //BindTypesSource();
                //if (theDataToBind.Level != null)
                //{
                //?
                //_ItsView.PositionGradeId =
                //    BllInstance.PositionBllInstance.GetPositionGradeById(theDataToBind.Level.Id, _LoginUser).Id.ToString();
                //}
                return true;
            }
            return SetViewUnable();
        }

        private bool SetViewUnable()
        {
            _ItsView.Message = "≥ı ºªØ ß∞‹";
            return false;
        }

        //private void BindTypesSource()
        //{
        //    List<PositionGrade> positionGradeSource = BllInstance.PositionBllInstance.GetAllPositionGrade();
        //    if (positionGradeSource != null)
        //    {
        //        _ItsView.PositionGradeSource = positionGradeSource;
        //    }
        //}
    }
}

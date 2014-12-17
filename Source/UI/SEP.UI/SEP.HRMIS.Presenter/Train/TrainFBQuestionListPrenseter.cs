using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;

namespace SEP.HRMIS.Presenter.Train
{
    public class TrainFBQuestionListPrenseter
    {
        public readonly ITrainFBQuestionList _ItsView;
        private ITrainFacade _ITrainFacade = InstanceFactory.CreateTrainFacade();
        //public IGetTrainFBQuestion _GetTrainFBQuestion = new GetTrainFBQuestion();
        //public IGetTrainQuesType _GetTrainQuesType = new GetTrainFBQuesType();
        private List<TrainFBQuestion> itsSource;

        public TrainFBQuestionListPrenseter(ITrainFBQuestionList itsView)
        {
            _ItsView = itsView;
            AttachViewEvent();
        }
        public void InitView(bool IsPostBack)
        {
            if (!IsPostBack)
            {
                _ItsView.TrainQuestionTypes = _ITrainFacade.GetTrainFBQuesTypeByCondition(-1, string.Empty);
                itsSource = new List<TrainFBQuestion>();
                itsSource =
                    _ITrainFacade.GetFBQuestionByConditon(_ItsView.TrainQuestion, -1);
                _ItsView.TrainQuestions = itsSource;

            }
        }



        private void AttachViewEvent()
        {
            _ItsView.btnSearchClick += FBQuestionDataBind;
        }


        public void FBQuestionDataBind()
        {

            itsSource = new List<TrainFBQuestion>();
            itsSource =
                _ITrainFacade.GetFBQuestionByConditon(_ItsView.TrainQuestion, Convert.ToInt32(_ItsView.TrainQuestionType));
            _ItsView.TrainQuestions = itsSource;
        }

        #region For Test
        public ITrainFacade getType
        {
            set
            {
                _ITrainFacade = value;
            }
        }

        public ITrainFacade getQues
        {
            set
            {
                _ITrainFacade = value;
            }
        }
        #endregion


    }
}

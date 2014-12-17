using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrain;

namespace SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem
{
    public class TrainFBQuesAndItemValidater
    {
        private readonly ITrainFBQuestionAndItemView _ItsView;
        public TrainFBQuesAndItemValidater(ITrainFBQuestionAndItemView view)
        {
            _ItsView = view;
        }
        public bool Vaildate()
        {
            return ValidateName() && ValidateQuesType() && ValidateFBItemsfeild() && ValidateDescriptionRepeate();
        }

        private bool ValidateName()
        {
            if (string.IsNullOrEmpty(_ItsView.FBQuestion))
            {
                _ItsView.FBQuestionMessage = "反馈问题名称不可为空";
                return false;
            }
            _ItsView.FBQuestionMessage = string.Empty;
            return true;
        }

        private bool ValidateQuesType()
        {
            if (string.IsNullOrEmpty(_ItsView.TrainFBQuesType))
            {
                _ItsView.FBQuesTypeMessage = "反馈问题类型不可为空";
                return false;
            }
            _ItsView.FBQuesTypeMessage = string.Empty;
            return true;
        }

        private bool ValidateFBItemsfeild()
        {
            foreach (TrainFBItem item in _ItsView.FBItemList)
            {
                if (string.IsNullOrEmpty(item.Description))
                {
                    _ItsView.ResultMessage = "选项不可为空";
                    return false;
                }
                //if (item.Worth == 0)
                //{
                //    _ItsView.ResultMessage = "分值必须为非0的整数";
                //    return false;
                //}

            }
            return true;
        }

        private bool ValidateDescriptionRepeate()
        {
            if (ValidateFBItemsfeild())
            {
                if (_ItsView.FBItemList.Count != 1)
                {
                    for (int i=0;i<=_ItsView.FBItemList.Count-1;i++)
                    {
                        int j ;
                        for ( j = i+1; j <_ItsView.FBItemList.Count; j++)
                        {
                            if(_ItsView.FBItemList[i].Description == _ItsView.FBItemList[j].Description)
                            {
                                _ItsView.ResultMessage = "选项有重复";
                                return false;
                            }
                            //if (_ItsView.FBItemList[i].Worth == _ItsView.FBItemList[j].Worth)
                            //{
                            //    _ItsView.ResultMessage = "分值有重复";
                            //    return false;
                            //}
                        }
                    }
                }
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse
{
    public interface IMyFeedBackView
    {
        IFeedBackListView CourseStartView { get; set;}

        IFeedBackListView CourseEndView { get; set;}

        string ErrorMessage { set;}
    }
}

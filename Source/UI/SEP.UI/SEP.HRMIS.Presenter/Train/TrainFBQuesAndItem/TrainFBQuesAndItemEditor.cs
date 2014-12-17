using System;
using System.Collections.Generic;
using SEP.HRMIS.Presenter.IPresenter.ITrain;
using SEP.HRMIS.Model;


namespace SEP.HRMIS.Presenter.Train
{
   public class TrainFBQuesAndItemEditor
    {
       private readonly ITrainFBQuestionAndItemView _IFBQuestionAndItemView;
       public TrainFBQuesAndItemEditor(ITrainFBQuestionAndItemView view)
        {
            _IFBQuestionAndItemView = view;
        }

        /// <summary>
        /// 删除rowIndex行
        /// </summary>
        /// <param name="rowIndex"></param>
       public void TrainFBItemForDeleteAtEvent(string rowIndex)
        {
            List<TrainFBItem> items = _IFBQuestionAndItemView.FBItemList;
            if (rowIndex == "0" && items.Count == 1)
            {
                //DiyStep item = new DiyStep(-1, "", OperatorType.YourSelf, 0);
                //items.Add(item);
            }
            else
            {
                items.RemoveAt(Convert.ToInt32(rowIndex));
            }
            _IFBQuestionAndItemView.FBItemList = items;
        }

        /// <summary>
        /// 在rowIndex下新增空行
        /// </summary>
        /// <param name="rowIndex"></param>
       public void TrainFBItemForAddAtEvent(string rowIndex)
        {
            List<TrainFBItem> items = new List<TrainFBItem>();
            for (int i = 0; i < _IFBQuestionAndItemView.FBItemList.Count; i++)
            {
                items.Add(_IFBQuestionAndItemView.FBItemList[i]);
                if (Convert.ToInt32(rowIndex) == i)
                {
                    TrainFBItem item = new TrainFBItem(-1,"",0);
                    items.Add(item);
                }
            }
            _IFBQuestionAndItemView.FBItemList = items;
        }

        /// <summary>
        /// 交换第id行<==>第id-1行
        /// </summary>
        /// <param name="id"></param>
       public void TrainFBItemChangedForUpEvent(string id)
        {
            List<TrainFBItem> items = _IFBQuestionAndItemView.FBItemList;
            int currRow = Convert.ToInt32(id);
            if (currRow == 0)
            {
                return;
            }
            TrainFBItem tempItem = items[currRow - 1];
            items[currRow - 1] = items[currRow];
            items[currRow] = tempItem;
            _IFBQuestionAndItemView.FBItemList = items;
        }

        /// <summary>
        /// 交换第id行<==>第id+1行
        /// </summary>
        /// <param name="id"></param>
       public void TrainFBItemChangedForDownEvent(string id)
        {
            List<TrainFBItem> items = _IFBQuestionAndItemView.FBItemList;
            int currRow = Convert.ToInt32(id);
            if (currRow + 2 == items.Count)
            {
                return;
            }
            TrainFBItem tempItem = items[currRow + 1];
            items[currRow + 1] = items[currRow];
            items[currRow] = tempItem;
            _IFBQuestionAndItemView.FBItemList = items;
        }
    }
}

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem
{
    public class TrainFBQuesAndItemUtility
    {
        public const string _AddOperationTitle = "新增反馈问题";
        public const string _UpdateOperationTitle = "修改反馈问题";
        public const string _DetailOperationTitle = "查看反馈问题";
        public const string _DeleteOperationTitle = "删除反馈问题";
        public const string _InitMessageError = "初始化信息不完整";
        public const string _FBQuesTypeNull = "问题类型不能为空";


        public static List<TrainFBItem> AddNullItem(List<TrainFBItem> trainFBItemLists)
        {
            TrainFBItem item = new TrainFBItem(-1, string.Empty, 0);
            trainFBItemLists.Add(item);
            return trainFBItemLists;

        }

        public static List<TrainFBItem> RemoveNullItem(List<TrainFBItem> trainFBItemLists)
        {
            List<TrainFBItem> ret_TrainFBItemList = new List<TrainFBItem>();
            for (int i = 0; i < trainFBItemLists.Count; i++)
            {
                if (trainFBItemLists[i].FBItemID != 0)
                {
                    ret_TrainFBItemList.Add(trainFBItemLists[i]);
                }
            }
            return ret_TrainFBItemList;
        }

    }
}

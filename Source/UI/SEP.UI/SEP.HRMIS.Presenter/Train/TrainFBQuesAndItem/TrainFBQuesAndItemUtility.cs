using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.Train.TrainFBQuesAndItem
{
    public class TrainFBQuesAndItemUtility
    {
        public const string _AddOperationTitle = "������������";
        public const string _UpdateOperationTitle = "�޸ķ�������";
        public const string _DetailOperationTitle = "�鿴��������";
        public const string _DeleteOperationTitle = "ɾ����������";
        public const string _InitMessageError = "��ʼ����Ϣ������";
        public const string _FBQuesTypeNull = "�������Ͳ���Ϊ��";


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

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;

namespace SEP.HRMIS.Presenter.DiyProcesses
{
    public class DiyProcessEditor
    {
        private readonly IDiyProcessView _IDiyProcessView;
        public DiyProcessEditor(IDiyProcessView view)
        {
            _IDiyProcessView = view;
        }

        /// <summary>
        /// 删除rowIndex行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void DiyStepForDeleteAtEvent(string rowIndex)
        {
            List<DiyStep> items = _IDiyProcessView.DiyStepList;
            if (rowIndex == "0" && items.Count == 1)
            {
                //DiyStep item = new DiyStep(-1, "", OperatorType.YourSelf, 0);
                //items.Add(item);
            }
            else
            {
                items.RemoveAt(Convert.ToInt32(rowIndex));
            }
            _IDiyProcessView.DiyStepList = items;
        }

        /// <summary>
        /// 在rowIndex下新增空行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void DiyStepForAddAtEvent(string rowIndex)
        {
            List<DiyStep> items = new List<DiyStep>();
            for (int i = 0; i < _IDiyProcessView.DiyStepList.Count; i++)
            {
                items.Add(_IDiyProcessView.DiyStepList[i]);
                if (Convert.ToInt32(rowIndex) == i)
                {
                    DiyStep item = new DiyStep(-1, "", OperatorType.YourSelf, 0);
                    items.Add(item);
                }
            }
            _IDiyProcessView.DiyStepList = items;
        }

        /// <summary>
        /// 交换第id行<==>第id-1行
        /// </summary>
        /// <param name="id"></param>
        public void DiyStepChangedForUpEvent(string id)
        {
            List<DiyStep> items = _IDiyProcessView.DiyStepList;
            int currRow = Convert.ToInt32(id);
            if (currRow == 0)
            {
                return;
            }
            DiyStep tempItem = items[currRow - 1];
            items[currRow - 1] = items[currRow];
            items[currRow] = tempItem;
            _IDiyProcessView.DiyStepList = items;
        }

        /// <summary>
        /// 交换第id行<==>第id+1行
        /// </summary>
        /// <param name="id"></param>
        public void DiyStepChangedForDownEvent(string id)
        {
            List<DiyStep> items = _IDiyProcessView.DiyStepList;
            int currRow = Convert.ToInt32(id);
            if (currRow + 1 == items.Count)
            {
                return;
            }
            DiyStep tempItem = items[currRow + 1];
            items[currRow + 1] = items[currRow];
            items[currRow] = tempItem;
            _IDiyProcessView.DiyStepList = items;
        }
    }
}

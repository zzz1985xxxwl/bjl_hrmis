using System;
using System.Collections.Generic;
using System.Text;
using SEP.Presenter.IPresenter.IPositions;
using SEP.Model.Positions;

namespace SEP.Presenter.Positions
{
    internal class PositionGradeEditor
    {
        private readonly IPositionGradeView _ItsView;
        public PositionGradeEditor(IPositionGradeView itsView)
        {
            _ItsView = itsView;
        }

        /// <summary>
        /// 删除rowIndex行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ForDeleteEvent(string rowIndex)
        {
            List<PositionGrade> items = _ItsView.PositionGradeListSrc;
            if (rowIndex == "0" && items.Count == 1)
            {
                items[0].Name = "";
            }
            else
            {
                int index = Convert.ToInt32(rowIndex);

                if (items[index].Id != -1)
                {
                    List<int> temps = _ItsView.DelPositionGradeId;
                    temps.Add(items[index].Id);
                    _ItsView.DelPositionGradeId = temps;
                }
                items.RemoveAt(index);
            }
            _ItsView.PositionGradeListSrc = items;
        }
        /// <summary>
        /// 在rowIndex下新增空行
        /// </summary>
        /// <param name="rowIndex"></param>
        public void ForAddAtEvent(string rowIndex)
        {
            List<PositionGrade> items = new List<PositionGrade>();
            for (int i = 0; i < _ItsView.PositionGradeListSrc.Count; i++)
            {
                items.Add(_ItsView.PositionGradeListSrc[i]);
                if (Convert.ToInt32(rowIndex) == i)
                {
                    PositionGradeDataBinder.AddNullItem(items);
                }
            }
            _ItsView.PositionGradeListSrc = items;
        }
        /// <summary>
        /// 交换第id行<==>第id-1行
        /// </summary>
        /// <param name="id"></param>
        public void ForUpEvent(string id)
        {
            List<PositionGrade> items = _ItsView.PositionGradeListSrc;
            int currRow = Convert.ToInt32(id);
            if (currRow == 0)
            {
                return;
            }
            PositionGrade tempItem = items[currRow - 1];
            items[currRow - 1] = items[currRow];
            items[currRow] = tempItem;
            _ItsView.PositionGradeListSrc = items;
        }
        /// <summary>
        /// 交换第id行<==>第id+1行
        /// </summary>
        /// <param name="id"></param>
        public void ForDownEvent(string id)
        {
            List<PositionGrade> items = _ItsView.PositionGradeListSrc;
            int currRow = Convert.ToInt32(id);
            if (currRow + 1 == items.Count)
            {
                return;
            }
            PositionGrade tempItem = items[currRow + 1];
            items[currRow + 1] = items[currRow];
            items[currRow] = tempItem;
            _ItsView.PositionGradeListSrc = items;
        }
    }
}

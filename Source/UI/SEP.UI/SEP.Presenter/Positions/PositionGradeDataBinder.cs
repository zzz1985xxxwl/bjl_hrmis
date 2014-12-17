using System;
using System.Collections.Generic;
using System.Text;
using SEP.Presenter.IPresenter.IPositions;
using SEP.Model.Positions;
using SEP.IBll;

namespace SEP.Presenter.Positions
{
    internal class PositionGradeDataBinder
    {
        private IPositionGradeView _ItsView;
        public PositionGradeDataBinder(IPositionGradeView itsView)
        {
            _ItsView = itsView;
        }

        public void DataBind()
        {
            try
            {
                List<PositionGrade> positionGrades = BllInstance.PositionBllInstance.GetAllPositionGrade();
                if (positionGrades.Count == 0)
                {
                    _ItsView.PositionGradeListSrc = AddNullItem(new List<PositionGrade>());
                }
                else
                {
                    _ItsView.PositionGradeListSrc = positionGrades;
                }
            }
            catch
            {
                _ItsView.Message = "��ʼ����Ϣʧ��";
            }
        }

        /// <summary>
        /// ΪpositionGrades�����һ����ӿյ�item�positionGradesΪ-1
        /// </summary>
        /// <param name="positionGrades"></param>
        /// <returns></returns>
        public static List<PositionGrade> AddNullItem(List<PositionGrade> positionGrades)
        {
            PositionGrade item = new PositionGrade();
            item.Id = -1;// 100000 + cardPropertyEnumValueList.Count;
            item.Name = "";
            positionGrades.Add(item);
            return positionGrades;
        }
        /// <summary>
        /// �Ƴ�positionGrades�еĿ����NameΪ�յ�����
        /// </summary>
        /// <param name="positionGrades"></param>
        /// <returns></returns>
        public static List<PositionGrade> RemoveNullItem(List<PositionGrade> positionGrades)
        {
            List<PositionGrade> ret_CardPropertyParaItem = new List<PositionGrade>();
            for (int i = 0; i < positionGrades.Count; i++)
            {
                if (positionGrades[i].Name != "")
                {
                    ret_CardPropertyParaItem.Add(positionGrades[i]);
                }
            }
            return ret_CardPropertyParaItem;
        }
    }
}

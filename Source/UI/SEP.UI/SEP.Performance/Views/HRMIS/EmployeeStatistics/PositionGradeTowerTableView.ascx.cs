using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class PositionGradeTowerTableView : UserControl, IPositionGradeTowerTableView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<PositionGradeStatistics> PositionGradeList
        {
            set
            {
                string chartFileName = Guid.NewGuid() + ".png";
                DrawPyramid.PyramidDataStruct[] pyramidDataStruct = new DrawPyramid.PyramidDataStruct[value.Count];
                for(int i=0;i<value.Count;i++)
                {
                    pyramidDataStruct[i].DataUnit = "��";
                    pyramidDataStruct[i].DataName = "ְ��" + value[i].PositionGrade.Name;
                    pyramidDataStruct[i].DataValue = value[i].Employees.Count;
                }
                DrawPyramid pyramid = new DrawPyramid();
                pyramid.Title = "ְ��㼶����";
                pyramid.TitleLocalX = 138;
                pyramid.TitleLocalY = 23;
                pyramid.Draw(pyramidDataStruct, chartFileName);
                Session[SessionKeys.EmployeeStaticsPositionGradeTowerTable] = chartFileName;
                imgPositionGradeTower.ImageUrl = "../../../Pages/image/imageZedGraph/" + chartFileName;

            }
        }
    }
}
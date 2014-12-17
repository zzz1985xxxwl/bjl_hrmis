using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using ZedGraph;
using ZedGraph.Web;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class ComeAndLeaveBarChartView : UserControl, IComeAndLeaveBarChartView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ZedGraphWeb1.RenderGraph += OnRenderGraph1;
        }

        private void OnRenderGraph1(ZedGraphWeb zgw, Graphics g, MasterPane masterPane)
        {
            try
            {
                GraphPane myPane = masterPane[0];
                BindDataForChart(myPane);
                SetDisplayForChart(myPane);
                masterPane.AxisChange(g);
            }
            catch
            {
            }
        }

        private void SetDisplayForChart(GraphPane myPane)
        {
            // Set the title and axis labels
            myPane.Title.Text = "\n进入离开人数";
            myPane.YAxis.Title.Text = "人数";
            myPane.XAxis.Title.Text = "月份";

            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 26f;
            myPane.Title.FontSpec.Family = "宋体";
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.XAxis.Title.FontSpec.Size = 22f;
            myPane.XAxis.Title.FontSpec.Family = "宋体";
            myPane.YAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 22f;
            myPane.YAxis.Title.FontSpec.Family = "宋体";

            BarItem BarItem = (BarItem) (myPane.CurveList[0]);
            BarItem.Bar.IsShowValue = true;
            BarItem.Bar.Fill = new Fill(Color.FromArgb(209, 253, 217), Color.FromArgb(7, 252, 11), 90f);
            BarItem.Bar.Border.Color = Color.FromArgb(128, 205, 131);
            BarItem = (BarItem) (myPane.CurveList[1]);
            BarItem.Bar.IsShowValue = true;
            BarItem.Bar.Fill = new Fill(Color.FromArgb(253, 229, 193), Color.FromArgb(253, 152, 0), 90f);
            BarItem.Bar.Border.Color = Color.FromArgb(248, 187, 107);

            //设置数据项说明位置
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.06f, 0.15f, CoordType.PaneFraction,
                                                  AlignH.Left, AlignV.Top);
            myPane.Legend.FontSpec.Size = 22f;
            myPane.Legend.FontSpec.Family = "宋体";
            myPane.Legend.FontSpec.Fill = new Fill(Color.Transparent);
            myPane.Legend.Border.Color = Color.Transparent;
        }

        private void BindDataForChart(GraphPane myPane)
        {
            //绑定数据

            string[] dateTime = new string[EmployeeComeAndLeaveList.Count];
            double[] comeCount = new double[EmployeeComeAndLeaveList.Count];
            double[] leaveCount = new double[EmployeeComeAndLeaveList.Count];
            for (int i = 0; i < EmployeeComeAndLeaveList.Count; i++)
            {
                dateTime[i] = EmployeeComeAndLeaveList[i].Year + "/" + EmployeeComeAndLeaveList[i].Month;
                comeCount[i] = EmployeeComeAndLeaveList[i].Entry;
                leaveCount[i] = EmployeeComeAndLeaveList[i].Dimission;
            }

            myPane.AddBar("进入人数", null, comeCount, Color.DimGray);
            myPane.AddBar("离开人数", null, leaveCount, Color.DarkSalmon);

            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.XAxis.Scale.TextLabels = dateTime;

            myPane.XAxis.Type = AxisType.Text;

            myPane.BarSettings.Type = BarType.Cluster;

            myPane.BarSettings.Base = BarBase.X;
        }

        private List<EmployeeComeAndLeave> _EmployeeComeAndLeaveList;

        public List<EmployeeComeAndLeave> EmployeeComeAndLeaveList
        {
            get { return _EmployeeComeAndLeaveList; }
            set
            {
                _EmployeeComeAndLeaveList = value;
                ZedGraphWeb1.FileName = Guid.NewGuid().ToString();
                Session[SessionKeys.EmployeeStaticsComeAndLeaveBarChart] = ZedGraphWeb1.FileName + ".png";
            }
        }
    }
}
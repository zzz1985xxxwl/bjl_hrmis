using System;
using System.Collections.Generic;
using System.Drawing;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using ZedGraph.Web;
using ZedGraph;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class LeaveRateLineChartView : System.Web.UI.UserControl, ILeaveRateLineChartView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        override protected void OnInit(EventArgs e)
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
            ZedGraphWeb1.RenderGraph += this.OnRenderGraph1;
        }
        private void OnRenderGraph1(ZedGraphWeb zgw, Graphics g, MasterPane masterPane)
        {
            try
            {
                // Get the GraphPane so we can work with it
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
            // Set the titles and axis labels
            myPane.Title.Text = "\n离职率";
            myPane.XAxis.Title.Text = "月份";
            myPane.YAxis.Title.Text = "离职率";

            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 26f;
            myPane.Title.FontSpec.Family = "宋体";
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.XAxis.Title.FontSpec.Size = 22f;
            myPane.XAxis.Title.FontSpec.Family = "宋体";
            myPane.YAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 22f;
            myPane.YAxis.Title.FontSpec.Family = "宋体";

            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            // Fill the area under the curve with a white-red gradient at 45 degrees
            LineItem myCurve = (LineItem)myPane.CurveList[0];
            myCurve.Line.Fill = new Fill(Color.White, Color.Transparent, 45F);
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            myCurve.IsShowValue = true;
            myCurve.IsPercent = true;
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);


            //设置数据项说明位置
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.06f, 0.15f, CoordType.PaneFraction,
                           AlignH.Left, AlignV.Top);
            myPane.Legend.FontSpec.Size = 22f;
            myPane.Legend.FontSpec.Family = "宋体";
            myPane.Legend.FontSpec.Fill = new Fill(Color.Transparent);
            myPane.Legend.Border.Color = Color.Transparent;
        }

        // Fill the axis background with a color gradient

        private void BindDataForChart(GraphPane myPane)
        {
            //绑定数据

            PointPairList list = new PointPairList();

            foreach (EmployeeComeAndLeave employeeComeAndLeave in EmployeeComeAndLeaveList)
            {
                double x = new XDate(employeeComeAndLeave.Year, employeeComeAndLeave.Month, 1);
                double y = (double)employeeComeAndLeave.DimissionRate;
                list.Add(x,y);
            }

            myPane.AddCurve("离职率", list, Color.Blue,
                                                SymbolType.Circle);

            // Set the XAxis to date type
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.CrossAuto = true;
        }

        private List<EmployeeComeAndLeave> _EmployeeComeAndLeaveList;
        public List<EmployeeComeAndLeave> EmployeeComeAndLeaveList
        {
            get { return _EmployeeComeAndLeaveList; }
            set
            {
                _EmployeeComeAndLeaveList = value;
                ZedGraphWeb1.FileName = Guid.NewGuid().ToString();
                Session[SessionKeys.EmployeeStaticsLeaveRateLineChart] = ZedGraphWeb1.FileName + ".png";
            }
        }
    }
}
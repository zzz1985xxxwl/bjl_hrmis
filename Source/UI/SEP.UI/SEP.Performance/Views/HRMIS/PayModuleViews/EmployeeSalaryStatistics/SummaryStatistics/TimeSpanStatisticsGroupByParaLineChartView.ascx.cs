using System;
using System.Data;
using System.Drawing;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using ZedGraph;
using ZedGraph.Web;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.SummaryStatistics
{
    public partial class TimeSpanStatisticsGroupByParaLineChartView : System.Web.UI.UserControl, ITimeSpanStatisticsGroupByParaLineChartView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private DataTable _gvTimeSpanStatisticsGroupByParaSource;
        public DataTable gvTimeSpanStatisticsGroupByParaSource
        {
            get { return _gvTimeSpanStatisticsGroupByParaSource; }
            set
            {
                _gvTimeSpanStatisticsGroupByParaSource = value; 
                if (value == null || value.Rows.Count == 0)
                {
                    divChart.Style["display"] = "none";
                }
                else
                {
                    ZedGraphWeb1.FileName = Guid.NewGuid().ToString();
                    Session[SessionKeys.TimeSpanStatisticsGroupByParaLineChartFileNameAndExp] = ZedGraphWeb1.FileName + ".png";
                    divChart.Style["display"] = "block";
                }
            }
        }
        override protected void OnInit(EventArgs e)
        {
            divChart.Style["display"] = "none";
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
            myPane.Title.Text = "\n按月统计帐套参数";
            myPane.XAxis.Title.Text = "月份";
            myPane.YAxis.Title.Text = "统计结果";

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
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);


            //设置数据项说明位置
            myPane.Legend.Position = LegendPos.Right;
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

            int rowCount = gvTimeSpanStatisticsGroupByParaSource.Rows.Count;
            int colCount = gvTimeSpanStatisticsGroupByParaSource.Columns.Count - 1;
            //绑定数据
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            //  对于C#的随机数，没什么好说的 
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < rowCount; i++)
            {
                PointPairList list = new PointPairList();

                for (int j = 0; j < colCount; j++)
                {
                    double x =
                        new XDate(Convert.ToDateTime(gvTimeSpanStatisticsGroupByParaSource.Columns[j + 1].ColumnName));
                    double y = Convert.ToDouble(gvTimeSpanStatisticsGroupByParaSource.Rows[i][j + 1]);
                    list.Add(x, y);
                }
                myPane.AddCurve(gvTimeSpanStatisticsGroupByParaSource.Rows[i][0].ToString(), list,
                                ViewUtility.GetRandomColor(RandomNum_First, RandomNum_Sencond),
                                SymbolType.Circle);
            }
            // Set the XAxis to date type
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.CrossAuto = true;
        }

    }
}
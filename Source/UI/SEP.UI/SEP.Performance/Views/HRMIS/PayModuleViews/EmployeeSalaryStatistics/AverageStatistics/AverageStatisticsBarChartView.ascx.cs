using System;
using System.Data;
using System.Drawing;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using ZedGraph;
using ZedGraph.Web;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeSalaryStatistics.AverageStatistics
{
    public partial class AverageStatisticsBarChartView : System.Web.UI.UserControl, IAverageStatisticsBarChartView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable _gvAverageStatisticsSource;
        public DataTable gvAverageStatisticsSource
        {
            get { return _gvAverageStatisticsSource; }
            set
            {
                _gvAverageStatisticsSource = value;
                if (value == null || value.Rows.Count == 0)
                {
                    divChart.Style["display"] = "none";
                }
                else
                {
                    //iZedGraphWeb1.ImageUrl = "../../../Pages/image/imageZedGraph/" + ZedGraphWeb1.FileName + ".png";
                    ZedGraphWeb1.FileName = Guid.NewGuid().ToString();
                    Session[SessionKeys.AverageStatisticsBarChartFileNameAndExp] = ZedGraphWeb1.FileName + ".png";
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
            myPane.Title.Text = "\n人均统计";
            myPane.YAxis.Title.Text = "均值";
            myPane.XAxis.Title.Text = "部门";

            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 26f;
            myPane.Title.FontSpec.Family = "宋体";
            myPane.XAxis.Title.FontSpec.IsBold = false;
            myPane.XAxis.Title.FontSpec.Size = 22f;
            myPane.XAxis.Title.FontSpec.Family = "宋体";
            myPane.YAxis.Title.FontSpec.IsBold = false;
            myPane.YAxis.Title.FontSpec.Size = 22f;
            myPane.YAxis.Title.FontSpec.Family = "宋体";

            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            //  对于C#的随机数，没什么好说的 
            System.Threading.Thread.Sleep(RandomNum_First.Next(50));
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < myPane.CurveList.Count; i++)
            {
                Color color = ViewUtility.GetRandomColor(RandomNum_First, RandomNum_Sencond);
                BarItem BarItem = (BarItem)(myPane.CurveList[i]);
                BarItem.Bar.Fill = new Fill(Color.White, color, 90f);
                BarItem.Bar.Border.Color = color;
            }

            //设置数据项说明位置
            myPane.Legend.Position = LegendPos.Right;
            myPane.Legend.Location = new Location(0.06f, 0.15f, CoordType.PaneFraction,
                           AlignH.Left, AlignV.Top);
            myPane.Legend.FontSpec.Size = 22f;
            myPane.Legend.FontSpec.Family = "宋体";
            myPane.Legend.FontSpec.Fill = new Fill(Color.Transparent);
            myPane.Legend.Border.Color = Color.Transparent;


        }

        private void BindDataForChart(GraphPane myPane)
        {
            int rowCount = gvAverageStatisticsSource.Rows.Count;
            int colCount = 1;
            //绑定数据
            string[] xDepartments = new string[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                xDepartments[i] = gvAverageStatisticsSource.Rows[i][0].ToString();
            }
            double[][] datas =
                new double[colCount][];

            datas[0] = new double[rowCount];
            for (int j = 0; j < rowCount; j++)
            {
                datas[0][j] = Convert.ToDouble(gvAverageStatisticsSource.Rows[j][3]);
            }
            myPane.AddBar(gvAverageStatisticsSource.Columns[3].ColumnName, null, datas[0], Color.DimGray);

            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.XAxis.Scale.TextLabels = xDepartments;

            myPane.XAxis.Type = AxisType.Text;

            myPane.BarSettings.Type = BarType.Cluster;

            myPane.BarSettings.Base = BarBase.X;
        }
    }
}  

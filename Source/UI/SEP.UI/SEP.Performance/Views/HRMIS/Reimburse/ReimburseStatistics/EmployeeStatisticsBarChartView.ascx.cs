using System;
using System.Data;
using System.Drawing;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using ZedGraph;
using ZedGraph.Web;

namespace SEP.Performance.Views.HRMIS.Reimburse.ReimburseStatistics
{
    public partial class EmployeeStatisticsBarChartView : System.Web.UI.UserControl, IEmployeeStatisticsBarChartView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private DataTable _gvEmployeeStatisticsSource;
        public DataTable gvEmployeeStatisticsSource
        {
            get { return _gvEmployeeStatisticsSource; }
            set
            {
                _gvEmployeeStatisticsSource = value;

                if (value == null || value.Rows.Count == 0)
                {
                    divChart.Style["display"] = "none";
                }
                else
                {
                    ZedGraphWeb1.FileName = Guid.NewGuid().ToString();
                    Session[SessionKeys.EmployeeReimburseStatisticsBarChart] = ZedGraphWeb1.FileName + ".png";
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
            myPane.Title.Text = "\n按员工统计报销";
            myPane.YAxis.Title.Text = "统计结果";
            myPane.XAxis.Title.Text = "员工";

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
            int rowCount = gvEmployeeStatisticsSource.Rows.Count - 1;//排除总计
            int colCount = gvEmployeeStatisticsSource.Columns.Count - 2;
            //绑定数据
            string[] xDepartments = new string[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                xDepartments[i] = gvEmployeeStatisticsSource.Rows[i][0].ToString();
            }
            double[][] datas = new double[colCount][];
            for (int i = 0; i < colCount; i++)
            {
                datas[i] = new double[rowCount];
                for (int j = 0; j < rowCount; j++)
                {
                    datas[i][j] = Convert.ToDouble(gvEmployeeStatisticsSource.Rows[j][i + 1]);//排除部门人数列
                }
                myPane.AddBar(gvEmployeeStatisticsSource.Columns[i + 1].ColumnName, null, datas[i], Color.DimGray);
            }

            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.XAxis.Scale.TextLabels = xDepartments;

            myPane.XAxis.Type = AxisType.Text;

            myPane.BarSettings.Type = BarType.Cluster;

            myPane.BarSettings.Base = BarBase.X;

        }
    }
}
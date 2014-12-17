using System;
using System.Drawing;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using ZedGraph;
using ZedGraph.Web;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class GenderPieChartView : UserControl, IGenderPieChartView
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
            zgwGenderChart.RenderGraph += OnRenderzgwGenderChart;
        }

        private void OnRenderzgwGenderChart(ZedGraphWeb zgw, Graphics g, MasterPane masterPane)
        {
            try
            {
                GraphPane myPane = masterPane[0];
                BindDataForChart(myPane);
                SetDisplayForChart(myPane);

                masterPane.AxisChange();
            }
            catch
            {
            }
        }

        private void SetDisplayForChart(GraphPane myPane)
        {
            myPane.Border.Color = ColorTranslator.FromHtml("#000000");
            //设置标题
            myPane.Title.Text = "\n性别构成";
            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 22f;
            myPane.Title.FontSpec.Family = "宋体";


            //设置背景色，渐变，按照45度从Color.White渐变到Color.Goldenrod
            // No fill for the axis background
            myPane.Chart.Fill.IsVisible = false;

            //设置数据项说明位置
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.95f, 0.5f, CoordType.PaneFraction,
                                                  AlignH.Right, AlignV.Center);
            myPane.Legend.FontSpec.Size = 18f;
            myPane.Legend.FontSpec.Family = "宋体";
            myPane.Legend.IsHStack = false;
            myPane.Legend.FontSpec.Fill = new Fill(Color.Transparent);
            myPane.Legend.Border.Color = Color.Transparent;

            foreach (CurveItem item in myPane.CurveList)
            {
                PieItem eachPie = (PieItem) item;
                eachPie.LabelDetail.FontSpec.Size = 20f;
                eachPie.LabelDetail.FontSpec.Family = "宋体";
                eachPie.LabelDetail.FontSpec.Border.IsVisible = false;
                eachPie.LabelDetail.FontSpec.Fill = new Fill(Color.Transparent);
                eachPie.LabelType = PieLabelType.None;
                eachPie.Label.Text = eachPie.Label.Text + " " + eachPie.Value + "人";
            }
        }

        private void BindDataForChart(GraphPane myPane)
        {
            //绑定数据
            myPane.AddPieSlice(EmployeeStatistics.ManCount, Color.FromArgb(14, 144, 206),
                               Color.FromArgb(16, 98, 154), Color.FromArgb(12, 200, 255), 0, "男");
            myPane.AddPieSlice(EmployeeStatistics.WomenCount, Color.FromArgb(252, 210, 2),
                               Color.FromArgb(198, 165, 4), Color.FromArgb(249, 221, 81), 0, "女");
        }

        private global::SEP.HRMIS.Model.EmployeeStatistics _employeeStatistics;

        public global::SEP.HRMIS.Model.EmployeeStatistics EmployeeStatistics
        {
            get { return _employeeStatistics; }
            set
            {
                _employeeStatistics = value;
                zgwGenderChart.FileName = Guid.NewGuid().ToString();
                Session[SessionKeys.EmployeeStaticsGenderPieChart] = zgwGenderChart.FileName + ".png";
            }
        }
    }
}
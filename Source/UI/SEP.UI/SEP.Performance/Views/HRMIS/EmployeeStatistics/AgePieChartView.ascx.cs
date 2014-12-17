using System;
using System.Drawing;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using ZedGraph;
using ZedGraph.Web;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class AgePieChartView : UserControl, IAgePieChartView
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
            zgwAgePie.RenderGraph += OnRenderzgwAgePie;
        }

        private void OnRenderzgwAgePie(ZedGraphWeb zgw, Graphics g, MasterPane masterPane)
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
            myPane.Title.Text = "\n年龄构成";
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
            myPane.AddPieSlice(EmployeeStatistics.Age0to20Count, Color.FromArgb(14, 144, 206),
                               Color.FromArgb(16, 98, 154), Color.FromArgb(12, 200, 255), 0, "20岁以下");
            myPane.AddPieSlice(EmployeeStatistics.Age21to25Count, Color.FromArgb(5, 209, 22), Color.FromArgb(5, 146, 15),
                               Color.FromArgb(5, 255, 30), 0, "21-25岁");
            myPane.AddPieSlice(EmployeeStatistics.Age26to30Count, Color.FromArgb(176, 222, 9),
                               Color.FromArgb(127, 157, 11), Color.FromArgb(200, 225, 109), 0, "26-30岁");
            myPane.AddPieSlice(EmployeeStatistics.Age31to35Count, Color.FromArgb(248, 255, 1),
                               Color.FromArgb(183, 201, 5), Color.FromArgb(241, 245, 5), 0, "31-35岁");
            myPane.AddPieSlice(EmployeeStatistics.Age36to40Count, Color.FromArgb(252, 210, 2),
                               Color.FromArgb(198, 165, 4), Color.FromArgb(249, 221, 81), 0, "36-40岁");
            myPane.AddPieSlice(EmployeeStatistics.Age41to45Count, Color.FromArgb(255, 159, 6),
                               Color.FromArgb(210, 131, 1), Color.FromArgb(251, 185, 77), 0, "41-45岁");
            myPane.AddPieSlice(EmployeeStatistics.Age46to50Count, Color.FromArgb(255, 101, 1),
                               Color.FromArgb(212, 84, 1), Color.FromArgb(250, 158, 99), 0, "46-50岁");
            myPane.AddPieSlice(EmployeeStatistics.Age51to55Count, Color.FromArgb(255, 15, 0), Color.FromArgb(203, 13, 3),
                               Color.FromArgb(249, 124, 117), 0, "51-55岁");
            myPane.AddPieSlice(EmployeeStatistics.Age56to60Count, Color.FromArgb(226, 109, 255),
                               Color.FromArgb(171, 12, 211), Color.FromArgb(233, 170, 248), 0, "56-60岁");
            myPane.AddPieSlice(EmployeeStatistics.Age61Count, Color.FromArgb(166, 226, 243),
                               Color.FromArgb(84, 198, 230), Color.FromArgb(178, 227, 241), 0, "60岁以上");
        }

        private global::SEP.HRMIS.Model.EmployeeStatistics _employeeStatistics;

        public global::SEP.HRMIS.Model.EmployeeStatistics EmployeeStatistics
        {
            get { return _employeeStatistics; }
            set
            {
                _employeeStatistics = value;
                zgwAgePie.FileName = Guid.NewGuid().ToString();
                Session[SessionKeys.EmployeeStaticsAgePieChart] = zgwAgePie.FileName + ".png";
            }
        }
    }
}
using System;
using System.Drawing;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using ZedGraph;
using ZedGraph.Web;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class WorkTypePieChartView : UserControl, IWorkTypePieChartView
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
            zgwWorkTypePie.RenderGraph += OnRenderzgwWorkTypePie;
        }

        private void OnRenderzgwWorkTypePie(ZedGraphWeb zgw, Graphics g, MasterPane masterPane)
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
            //���ñ���
            myPane.Title.Text = "\n�ù����ʹ���";
            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 22f;
            myPane.Title.FontSpec.Family = "����";


            //���ñ���ɫ�����䣬����45�ȴ�Color.White���䵽Color.Goldenrod
            // No fill for the axis background
            myPane.Chart.Fill.IsVisible = false;

            //����������˵��λ��
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.98f, 0.5f, CoordType.PaneFraction,
                                                  AlignH.Right, AlignV.Center);
            myPane.Legend.FontSpec.Size = 18f;
            myPane.Legend.FontSpec.Family = "����";
            myPane.Legend.IsHStack = false;
            myPane.Legend.FontSpec.Fill = new Fill(Color.Transparent);
            myPane.Legend.Border.Color = Color.Transparent;


            foreach (CurveItem item in myPane.CurveList)
            {
                PieItem eachPie = (PieItem) item;
                eachPie.LabelDetail.FontSpec.Size = 20f;
                eachPie.LabelDetail.FontSpec.Family = "����";
                eachPie.LabelDetail.FontSpec.Border.IsVisible = false;
                eachPie.LabelDetail.FontSpec.Fill = new Fill(Color.Transparent);
                eachPie.LabelType = PieLabelType.None;
                eachPie.Label.Text = eachPie.Label.Text + " " + eachPie.Value + "��";
            }
        }

        private void BindDataForChart(GraphPane myPane)
        {
            //������
            myPane.AddPieSlice(EmployeeStatistics.ContractCount, Color.FromArgb(14, 144, 206),
                               Color.FromArgb(16, 98, 154), Color.FromArgb(12, 200, 255), 0, "��ͬ��");
            myPane.AddPieSlice(EmployeeStatistics.ExternalContractCount, Color.FromArgb(5, 209, 22),
                               Color.FromArgb(5, 146, 15),
                               Color.FromArgb(5, 255, 30), 0, "��������ͬ��");
            myPane.AddPieSlice(EmployeeStatistics.ResidenceContractCount, Color.FromArgb(176, 222, 9),
                               Color.FromArgb(127, 157, 11), Color.FromArgb(200, 225, 109), 0, "��ס֤��ͬ��");
            myPane.AddPieSlice(EmployeeStatistics.PartTimerCount, Color.FromArgb(226, 109, 255),
                               Color.FromArgb(171, 12, 211), Color.FromArgb(233, 170, 248), 0, "��ְ");
            myPane.AddPieSlice(EmployeeStatistics.WorkContractCount, Color.FromArgb(166, 226, 243),
                               Color.FromArgb(84, 198, 230), Color.FromArgb(178, 227, 241), 0, "����");
            myPane.AddPieSlice(EmployeeStatistics.PracticerCount, Color.FromArgb(255, 159, 6),
                               Color.FromArgb(210, 131, 1), Color.FromArgb(251, 185, 77), 0, "ʵϰ��");
        }

        private global::SEP.HRMIS.Model.EmployeeStatistics _employeeStatistics;

        public global::SEP.HRMIS.Model.EmployeeStatistics EmployeeStatistics
        {
            get { return _employeeStatistics; }
            set
            {
                _employeeStatistics = value;
                zgwWorkTypePie.FileName = Guid.NewGuid().ToString();
                Session[SessionKeys.EmployeeStaticsWorkTypePieChart] = zgwWorkTypePie.FileName + ".png";
            }
        }
    }
}
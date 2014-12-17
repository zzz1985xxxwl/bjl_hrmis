using System;
using System.Drawing;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using ZedGraph;
using ZedGraph.Web;
using HRMISModel = SEP.HRMIS.Model;


namespace SEP.Performance.Views.EmployeeStatistics
{
    public partial class EduBgPieChartView : UserControl, IEduBgPieChartView
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
            zgwEduBgPie.RenderGraph += OnRenderzgwEducationalBackgroundPie;
        }

        private void OnRenderzgwEducationalBackgroundPie(ZedGraphWeb zgw, Graphics g, MasterPane masterPane)
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
            myPane.Title.Text = "\n�Ļ��̶ȹ���";
            myPane.Title.FontSpec.IsBold = false;
            myPane.Title.FontSpec.Size = 22f;
            myPane.Title.FontSpec.Family = "����";


            //���ñ���ɫ�����䣬����45�ȴ�Color.White���䵽Color.Goldenrod
            // No fill for the axis background
            myPane.Chart.Fill.IsVisible = false;

            //����������˵��λ��
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.95f, 0.5f, CoordType.PaneFraction,
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

            // Sum up the pie values                                                               
            //CurveList curves = myPane.CurveList;
            //double total = 0;
            //for (int x = 0; x < curves.Count; x++)
            //    total += ((PieItem)curves[x]).Value;


            ////��ͼƬ�м���text�����ݸ�������
            //TextObj text = new TextObj("������\n" + total,
            //               0.15F, 0.8F, CoordType.PaneFraction);
            //text.Location.AlignH = AlignH.Center;
            //text.Location.AlignV = AlignV.Bottom;
            //text.FontSpec.Family = "����";
            //text.FontSpec.Size = 20f;
            //text.FontSpec.Border.IsVisible = true;
            //text.FontSpec.Fill = new Fill(Color.White, Color.FromArgb(255, 100, 100), 45F);
            //text.FontSpec.StringAlignment = StringAlignment.Center;
            //myPane.GraphObjList.Add(text);

            ////��ͼƬ�м���text�����ñ���
            //TextObj text2 = new TextObj(text);
            //text2.FontSpec.Fill = new Fill(Color.Black);
            //text2.Location.X += 0.008f;
            //text2.Location.Y += 0.01f;
            //myPane.GraphObjList.Add(text2);
        }

        private void BindDataForChart(GraphPane myPane)
        {
            //������
            myPane.AddPieSlice(EmployeeStatistics.XiaoXueCount, Color.FromArgb(14, 144, 206),
                               Color.FromArgb(16, 98, 154), Color.FromArgb(12, 200, 255), 0, "Сѧ");
            myPane.AddPieSlice(EmployeeStatistics.ChuZhongCount, Color.FromArgb(255, 15, 0), Color.FromArgb(203, 13, 3),
                               Color.FromArgb(249, 124, 117), 0, "����");
            myPane.AddPieSlice(EmployeeStatistics.ZhongZhuanCount, Color.FromArgb(166, 226, 243),
                               Color.FromArgb(84, 198, 230), Color.FromArgb(178, 227, 241), 0, "��ר");
            myPane.AddPieSlice(EmployeeStatistics.JiXiaoCount, Color.FromArgb(255, 101, 1),
                               Color.FromArgb(212, 84, 1), Color.FromArgb(250, 158, 99), 0, "��У");
            myPane.AddPieSlice(EmployeeStatistics.GaoZhongCount, Color.FromArgb(5, 209, 22), Color.FromArgb(5, 146, 15),
                               Color.FromArgb(5, 255, 30), 0, "����");
            myPane.AddPieSlice(EmployeeStatistics.DaZhuanCount, Color.FromArgb(226, 109, 255),
                               Color.FromArgb(171, 12, 211), Color.FromArgb(233, 170, 248), 0, "��ר");
            myPane.AddPieSlice(EmployeeStatistics.BenKeCount, Color.FromArgb(248, 255, 1),
                               Color.FromArgb(183, 201, 5), Color.FromArgb(241, 245, 5), 0, "����");
            myPane.AddPieSlice(EmployeeStatistics.ShuoShiCount, Color.FromArgb(255, 159, 6),
                               Color.FromArgb(210, 131, 1), Color.FromArgb(251, 185, 77), 0, "˶ʿ");
            myPane.AddPieSlice(EmployeeStatistics.BoShiCount, Color.FromArgb(252, 210, 2),
                               Color.FromArgb(198, 165, 4), Color.FromArgb(249, 221, 81), 0, "��ʿ");
        }

        private global::SEP.HRMIS.Model.EmployeeStatistics _employeeStatistics;

        public global::SEP.HRMIS.Model.EmployeeStatistics EmployeeStatistics
        {
            get { return _employeeStatistics; }
            set
            {
                _employeeStatistics = value;
                zgwEduBgPie.FileName = Guid.NewGuid().ToString();
                Session[SessionKeys.EmployeeStaticsEduBgPieChart] = zgwEduBgPie.FileName + ".png";
            }
        }
    }
}
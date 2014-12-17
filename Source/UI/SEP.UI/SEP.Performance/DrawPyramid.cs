using System;
using System.Drawing;
using System.Web;

namespace SEP.Performance
{
    public class DrawPyramid
    {
        private readonly string[] _Color =
            new string[]
                {
                    "#0e90ce", "#05d116", "#b0de09", "#f8ff01", "#fcd202", "#ff9f06", "#ff6501", "#ff0f00", "#e26dff",
                    "#a6e2f3",
                };
        public struct PyramidDataStruct
        {
            public string DataUnit;
            public double DataValue;
            public string DataName;
        }

        private int _ItemHeight = 25;
        public int ItemHeight
        {
            set { _ItemHeight = value; }
            get { return _ItemHeight; }
        }
        private double _ItemWidthRate = 0.7;
        public double ItemWidthRate
        {
            set { _ItemWidthRate = value; }
            get { return _ItemWidthRate; }
        }
        private int _Width = 370;
        public int Width
        {
            set { _Width = value; }
            get { return _Width; }
        }

        private int _Height = 250;
        public int Height
        {
            set { _Height = value; }
            get { return _Height; }
        }

        private string _Title;
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        private float _TitleFontSize = 11;
        public float TitleFontSize
        {
            set { _TitleFontSize = value; }
            get { return _TitleFontSize; }
        }
        private float _TitleLocalX;
        public float TitleLocalX
        {
            set { _TitleLocalX = value; }
            get { return _TitleLocalX; }
        }
        private float _TitleLocalY;
        public float TitleLocalY
        {
            set { _TitleLocalY = value; }
            get { return _TitleLocalY; }
        }
        private float _DataFontSize = 9;
        public float DataFontSize
        {
            set { _DataFontSize = value; }
            get { return _DataFontSize; }
        }
        private Color _BorderColor = Color.Black;
        public Color BorderColor
        {
            set { _BorderColor = value; }
            get { return _BorderColor; }
        }
        private Color _BgColor = ColorTranslator.FromHtml("#d9ffb5");
        public Color BgColor
        {
            set { _BgColor = value; }
            get { return _BgColor; }
        }
        public void Draw(PyramidDataStruct[] pyramidData, string chartFileNameAndExp)
        {
            double max = 0;
            foreach (PyramidDataStruct data in pyramidData)
            {
                if (max < data.DataValue)
                {
                    max = data.DataValue;
                }
            }
            //�½�һ��bmpͼƬ 
            float imageHeightMaybe = pyramidData.Length * _ItemHeight + _TitleLocalY + _TitleFontSize + 20;//Ԥ��20���ؿհ״�
            _Height = imageHeightMaybe > _Height ? Convert.ToInt32(imageHeightMaybe) : _Height;//���ͼƬ���Ȳ���
            Image image = new Bitmap(_Width, _Height);
            //�½�һ������ 
            Graphics g = Graphics.FromImage(image);

            //���ø�������ֵ�� 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //���ø�����,���ٶȳ���ƽ���̶� 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //��ջ�������͸������ɫ��� 
            g.Clear(Color.Transparent);
            Brush blackBrush = new SolidBrush(_BorderColor);
            Pen blackPen = new Pen(blackBrush, 1);
            //�߿��ɫ
            g.FillRectangle(new SolidBrush(_BgColor), new Rectangle(0, 0, image.Width - 1, image.Height - 1));
            g.DrawRectangle(blackPen, new Rectangle(0, 0, image.Width - 1, image.Height - 1));
            //ְ��㼶����
            Font f = new Font("����", _TitleFontSize);
            Font ff = new Font("����", _DataFontSize);
            g.DrawString(_Title, f, blackBrush, _TitleLocalX, _TitleLocalY);
            //ְ��㼶item
            int starttop = Convert.ToInt32(_TitleLocalY + _TitleFontSize + (_Height - _TitleLocalY - _TitleFontSize - pyramidData.Length * _ItemHeight) / 2);//ʹ�ý�������ֱ����
            int startleft = 60;//ֵ60 ����б�Ҫ����Ϊ����
            int iColorIndex = 0;
            float maxwidthofItem = Convert.ToInt32(image.Width * _ItemWidthRate);//�������ֵ�Ŀ��
            for (int i = 0; i < pyramidData.Length; i++)
            {
                int itemWidth = max == 0 ? 0 : Convert.ToInt32(maxwidthofItem*pyramidData[i].DataValue/max);
                int itemHeight = _ItemHeight;
                int itemLeft = Convert.ToInt32(maxwidthofItem / 2 + startleft - itemWidth / 2);
                int itemTop = Convert.ToInt32(starttop + i * itemHeight);
                g.DrawString(pyramidData[i].DataName, ff, blackBrush, 15, itemTop + (itemHeight - ff.Size) / 2);//ֵ15 ����б�Ҫ����Ϊ����
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(_Color[iColorIndex])), itemLeft, itemTop, itemWidth, itemHeight);
                g.DrawRectangle(blackPen, itemLeft, itemTop, itemWidth, itemHeight);
                g.DrawString(" " + pyramidData[i].DataValue + pyramidData[i].DataUnit, ff, blackBrush, itemLeft + itemWidth, itemTop + (itemHeight - ff.Size) / 2);
                iColorIndex = iColorIndex + 1 == _Color.Length ? 0 : iColorIndex + 1;
            }
            g.Dispose();

            //����
            string newPath = HttpContext.Current.Request.PhysicalApplicationPath + @"Pages\image\imageZedGraph\" +
                             chartFileNameAndExp;
            image.Save(newPath);//, System.Drawing.Imaging.ImageFormat.Jpeg); 
            image.Dispose();

        }
    }
}

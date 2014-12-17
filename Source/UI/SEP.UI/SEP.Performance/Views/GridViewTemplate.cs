using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEP.Performance.Views
{
    public class GridViewTemplate
    {
        /// <summary>
        /// ����TemplateItem CheckBox��
        /// </summary>
        public class TextBoxTemplate : ITemplate
        {
            private string proName;
            private string _textBoxId;
            private bool _textBoxEnable;
            private int _txxtBoxWidth;

            public string ProName//Ҫ�󶨵�����Դ�ֶ�����
            {
                set { proName = value; }
                get { return proName; }
            }

            /// <summary>
            /// ��textboxid
            /// </summary>
            public string TextBoxId
            {
                set { _textBoxId = value; }
                get { return _textBoxId; }
            }

            /// <summary>
            /// TextBox��Enable���� 
            /// </summary>
            public bool TextBoxEnable
            {
                get { return _textBoxEnable; }
                set { _textBoxEnable = value; }
            }

            public int TextBoxWidth
            {
                get { return _txxtBoxWidth; }
                set { _txxtBoxWidth = value; }
            }

            public void InstantiateIn(Control container)//�ؼ�ʵ���������
            {
                TextBox box1 = new TextBox();
                box1.ID = TextBoxId;
                box1.Width = TextBoxWidth;
                box1.Enabled = TextBoxEnable;
                box1.DataBinding += (hi_DataBinding);//�������ݰ��¼�

                container.Controls.Add(box1);
            }

            void hi_DataBinding(object sender, EventArgs e)
            {
                TextBox hi = (TextBox)sender;
                GridViewRow container = (GridViewRow)hi.NamingContainer;
                //�ؼ�λ��
                //ʹ��DataBinder.Eval������
                //ProName,MyTemplate������.�ڴ���MyTemplateʵ��ʱ,Ϊ�����Ը�ֵ(����Դ�ֶ�)
                hi.Text = DataBinder.Eval(container.DataItem, ProName).ToString();
            }
        }

        /// <summary>
        /// ����TemplateItem Lable��
        /// </summary>
        public class LableTemplate : ITemplate
        {
            private string proName;
            private string _textBoxId;

            public string ProName//Ҫ�󶨵�����Դ�ֶ�����
            {
                set { proName = value; }
                get { return proName; }
            }

            /// <summary>
            /// ��textboxid
            /// </summary>
            public string LableId
            {
                set { _textBoxId = value; }
                get { return _textBoxId; }
            }

            public void InstantiateIn(Control container)//�ؼ�ʵ���������
            {
                Label lable = new Label();
                lable.ID = LableId;
                lable.Width = 80;
                lable.DataBinding += (hi_DataBinding);//�������ݰ��¼�

                container.Controls.Add(lable);
            }

            void hi_DataBinding(object sender, EventArgs e)
            {
                Label hi = (Label)sender;
                GridViewRow container = (GridViewRow)hi.NamingContainer;
                //�ؼ�λ��
                //ʹ��DataBinder.Eval������
                //ProName,MyTemplate������.�ڴ���MyTemplateʵ��ʱ,Ϊ�����Ը�ֵ(����Դ�ֶ�)
                hi.Text = DataBinder.Eval(container.DataItem, ProName).ToString();
            }
        }

        /// <summary>
        /// ����TemplateItem CheckBox��
        /// </summary>
        public class CheckBoxTemplate : ITemplate
        {
            private string _textBoxId;
            private bool _autoPostBack;
            /// <summary>
            /// ��textboxid
            /// </summary>
            public string CheckBoxId
            {
                set { _textBoxId = value; }
                get { return _textBoxId; }
            }

            //�Ƿ�ش�
            public bool AutoPostBack
            {
                set { _autoPostBack = value; }
                get { return _autoPostBack; }
            }

            public void InstantiateIn(Control container)//�ؼ�ʵ���������
            {
                CheckBox checkBox = new CheckBox();
                checkBox.ID = CheckBoxId;
                checkBox.AutoPostBack = AutoPostBack;
                container.Controls.Add(checkBox);
            }
        }
    }
}

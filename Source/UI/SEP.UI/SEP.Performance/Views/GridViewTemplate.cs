using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEP.Performance.Views
{
    public class GridViewTemplate
    {
        /// <summary>
        /// 创建TemplateItem CheckBox项
        /// </summary>
        public class TextBoxTemplate : ITemplate
        {
            private string proName;
            private string _textBoxId;
            private bool _textBoxEnable;
            private int _txxtBoxWidth;

            public string ProName//要绑定的数据源字段名称
            {
                set { proName = value; }
                get { return proName; }
            }

            /// <summary>
            /// 绑定textboxid
            /// </summary>
            public string TextBoxId
            {
                set { _textBoxId = value; }
                get { return _textBoxId; }
            }

            /// <summary>
            /// TextBox的Enable属性 
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

            public void InstantiateIn(Control container)//关键实现这个方法
            {
                TextBox box1 = new TextBox();
                box1.ID = TextBoxId;
                box1.Width = TextBoxWidth;
                box1.Enabled = TextBoxEnable;
                box1.DataBinding += (hi_DataBinding);//创建数据绑定事件

                container.Controls.Add(box1);
            }

            void hi_DataBinding(object sender, EventArgs e)
            {
                TextBox hi = (TextBox)sender;
                GridViewRow container = (GridViewRow)hi.NamingContainer;
                //关键位置
                //使用DataBinder.Eval绑定数据
                //ProName,MyTemplate的属性.在创建MyTemplate实例时,为此属性赋值(数据源字段)
                hi.Text = DataBinder.Eval(container.DataItem, ProName).ToString();
            }
        }

        /// <summary>
        /// 创建TemplateItem Lable项
        /// </summary>
        public class LableTemplate : ITemplate
        {
            private string proName;
            private string _textBoxId;

            public string ProName//要绑定的数据源字段名称
            {
                set { proName = value; }
                get { return proName; }
            }

            /// <summary>
            /// 绑定textboxid
            /// </summary>
            public string LableId
            {
                set { _textBoxId = value; }
                get { return _textBoxId; }
            }

            public void InstantiateIn(Control container)//关键实现这个方法
            {
                Label lable = new Label();
                lable.ID = LableId;
                lable.Width = 80;
                lable.DataBinding += (hi_DataBinding);//创建数据绑定事件

                container.Controls.Add(lable);
            }

            void hi_DataBinding(object sender, EventArgs e)
            {
                Label hi = (Label)sender;
                GridViewRow container = (GridViewRow)hi.NamingContainer;
                //关键位置
                //使用DataBinder.Eval绑定数据
                //ProName,MyTemplate的属性.在创建MyTemplate实例时,为此属性赋值(数据源字段)
                hi.Text = DataBinder.Eval(container.DataItem, ProName).ToString();
            }
        }

        /// <summary>
        /// 创建TemplateItem CheckBox项
        /// </summary>
        public class CheckBoxTemplate : ITemplate
        {
            private string _textBoxId;
            private bool _autoPostBack;
            /// <summary>
            /// 绑定textboxid
            /// </summary>
            public string CheckBoxId
            {
                set { _textBoxId = value; }
                get { return _textBoxId; }
            }

            //是否回传
            public bool AutoPostBack
            {
                set { _autoPostBack = value; }
                get { return _autoPostBack; }
            }

            public void InstantiateIn(Control container)//关键实现这个方法
            {
                CheckBox checkBox = new CheckBox();
                checkBox.ID = CheckBoxId;
                checkBox.AutoPostBack = AutoPostBack;
                container.Controls.Add(checkBox);
            }
        }
    }
}

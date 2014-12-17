using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdvancedCondition;

namespace SEP.Performance.Views
{
    public partial class SetColumnListView : UserControl
    {
        private List<SearchField> _SearchFieldCheckBoxCol = new List<SearchField>();
        public List<SearchField> SearchFieldCheckBoxCol
        {
            get { return _SearchFieldCheckBoxCol; }
            set
            {
                _SearchFieldCheckBoxCol = value;
                AutoGenerateSelectableColumns();
            }
        }

        private List<SearchField> _InitCheckedBoxCol = new List<SearchField>();
        public List<SearchField> InitCheckedBoxCol
        {
            get { return _InitCheckedBoxCol; }
            set { _InitCheckedBoxCol = value; }
        }
        /// <summary>
        /// 自动生成gridview中的列对应的checkbox
        /// </summary>
        private void AutoGenerateSelectableColumns()
        {
            checkboxlist.Controls.Clear();
            List<SearchField> fieldParaList = _SearchFieldCheckBoxCol;
            Table tb = new Table();
            TableRow tr = new TableRow();
            TableCell tc;
            tb.Attributes.Add("width", "100%");
            tb.Rows.Add(tr);
            int xcount = 5;
            for (int i = 0; i < fieldParaList.Count; i++)
            {
                CheckBox aCheckBox = new CheckBox();
                aCheckBox.ID = fieldParaList[i].FieldParaBase.Id.ToString();
                aCheckBox.Text = fieldParaList[i].FieldParaBase.FieldName;
                aCheckBox.Attributes.Add("onclick", "columnHeaderShowOrHide(" + (i + 1) + ", this.checked);columnColShowOrHide(" + (i + 1) + ", this.checked)");
                if (SearchField.IsListContainItem(_InitCheckedBoxCol, fieldParaList[i]))
                {
                    aCheckBox.Checked = true;
                }
                if (tr.Cells.Count == xcount)
                {
                    tr = new TableRow();
                    tb.Rows.Add(tr);
                }
                tc = new TableCell();
                tc.Attributes.Add("width", 100 / xcount + "%");
                tc.Controls.Add(aCheckBox);
                tr.Cells.Add(tc);
            }
            checkboxlist.Controls.Add(tb);
        }

    }
}
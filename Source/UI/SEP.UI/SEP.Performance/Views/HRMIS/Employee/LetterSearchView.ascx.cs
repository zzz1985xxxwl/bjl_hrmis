using System.Web.UI;
using System.Web.UI.WebControls;

namespace SEP.Performance.Views.Employee
{
    public partial class LetterSearchView : UserControl
    {
        public delegate void LetterSearch(string letter);

        public LetterSearch _LetterSearch;
        protected void Letter_Search(object sender, CommandEventArgs e)
        {
            _LetterSearch(e.CommandArgument.ToString());
        }
    }
}
using System;

namespace SEP.Presenter.Indexs
{
    [Serializable]
    public class IndexItem
    {
        private ToolType _ToolType;
        private string _ImgSrc;
        private string _CheckBoxID;
        private string _CheckBoxText;
        private string _ViewLocation;
        private string _ViewName;
        private string _ViewID;
        private int _WebPartLocation;

        public IndexItem(string title, string id, string imgSrc, string viewLocation, int webpartzone)
            : this(title, id, viewLocation, webpartzone)
        {
            _ImgSrc = "../../../Pages/image/" + imgSrc;
        }


        public IndexItem(string title, string id, string viewLocation, int webpartzone)
        {
            _CheckBoxID = "cbx" + id;
            _CheckBoxText = title;
            _ViewLocation = viewLocation;
            _ViewName = title;
            _ViewID = "Drag" + id;
            _WebPartLocation = webpartzone;
        }


        public ToolType ToolType
        {
            get { return _ToolType; }
            set { _ToolType = value; }
        }

        public string ImgSrc
        {
            get { return _ImgSrc; }
            set { _ImgSrc = value; }
        }

        public string CheckBoxID
        {
            get { return _CheckBoxID; }
            set { _CheckBoxID = value; }
        }

        public string CheckBoxText
        {
            get { return _CheckBoxText; }
            set { _CheckBoxText = value; }
        }

        public string ViewLocation
        {
            get { return _ViewLocation; }
            set { _ViewLocation = value; }
        }

        public string ViewName
        {
            get { return _ViewName; }
            set { _ViewName = value; }
        }

        public string ViewID
        {
            get { return _ViewID; }
            set { _ViewID = value; }
        }

        /// <summary>
        /// 0»ò1
        /// </summary>
        public int WebPartLocation
        {
            get { return _WebPartLocation; }
            set { _WebPartLocation = value; }
        }

    }

    public enum ToolType
    {
        Normal = 0,
        Hrmis = 1,
        Crm = 2,
        MyCmmi = 3
    }
}
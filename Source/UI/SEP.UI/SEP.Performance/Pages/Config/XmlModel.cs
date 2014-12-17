using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SEP.Performance.Pages.Config
{
    public class XmlNodeModel
    {
        private string _NodeName;
        private List<XmlNodeAttributesModel> _XmlNodeAttributesModelList;
        public XmlNodeModel(string nodeName)
        {
            _NodeName = nodeName;
        }

        public string NodeName
        {
            get
            {
                return _NodeName;
            }
            set
            {
                _NodeName = value;
            }
        }
        public List<XmlNodeAttributesModel> XmlNodeAttributesModelList
        {
            get
            {
                return _XmlNodeAttributesModelList;
            }
            set
            {
                _XmlNodeAttributesModelList = value;
            }
        }
    }
    public class XmlNodeAttributesModel
    {
        private string _Key;
        private string _Value;
        public XmlNodeAttributesModel(string key, string value)
        {
            _Key = key;
            _Value = value;
        }

        public string Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
            }
        }
        public string Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
    }

}

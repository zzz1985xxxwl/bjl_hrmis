using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEP.Model.Accounts
{
    public class GradesType
    {
        private readonly int _ID;
        private readonly string _Name;

        public GradesType(int id, string name)
        {
            _ID = id;
            _Name = name;
        }
        public static GradesType JiShu = new GradesType(0, "技术类");
        public static GradesType XiaoShou = new GradesType(1, "销售类");
        public static GradesType Guanli = new GradesType(2, "管理类");

        public int ID
        {
            get { return _ID; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public static List<GradesType> GetAll()
        {
            List<GradesType> list = new List<GradesType>();
            list.Add(JiShu);
            list.Add(XiaoShou);
            list.Add(Guanli);
            return list;
        }

    }
}

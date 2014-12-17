using System;
using System.Configuration;
using System.IO;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    public class CreateContractBookMark
    {
        private readonly ContractType _ContractType;
        private readonly string _TempWordLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private static readonly IContractBookMark _ContractBookMark = DalFactory.DataAccess.CreateContractBookMark();
        private readonly string _TempWordName;

        public CreateContractBookMark(ContractType contractType)
        {
            _ContractType = contractType;
            _TempWordName = _TempWordLocation + "\\"+contractType.ContractTypeName+".doc";
            CreateBookMark();
        }

        private void CreateBookMark()
        {
            if(_ContractType.ContractTemplate!=null)
            {
                if (!Directory.Exists(_TempWordLocation))
                {
                    Directory.CreateDirectory(_TempWordLocation);
                }   
                //生成临时word文档
                byte[] bytes = _ContractType.ContractTemplate;
                FileStream fs = new FileStream(_TempWordName, FileMode.Create, FileAccess.Write);
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
                fs.Close();

                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                object nothing = Type.Missing;
                object localPatho = _TempWordName;
                Microsoft.Office.Interop.Word.Document doc =
                app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
                try
                {
                   //将word的书签写入数据库
                    System.Collections.IEnumerator enu = app.ActiveDocument.Bookmarks.GetEnumerator();
                    _ContractBookMark.DeleteContractBookMarkByContractTypeID(_ContractType.ContractTypeID);
                    while (enu.MoveNext())
                    {
                        Microsoft.Office.Interop.Word.Bookmark bk = (Microsoft.Office.Interop.Word.Bookmark)enu.Current;
                        _ContractBookMark.InsertContractBookMark(
                            new ContractBookMark(0, _ContractType.ContractTypeID, bk.Name));

                    }
                }
                finally
                {
                    doc.Close(ref nothing, ref nothing, ref nothing);
                    app.Quit(ref nothing, ref nothing, ref nothing);
                }
              
            }
           
         }
    }
}

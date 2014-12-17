using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.Office.Interop.Word;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.IBll.Accounts;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 导出员工合同Word
    /// </summary>
    public class ExportEmployeeContract
    {
        private readonly int _ContractID;
        private GetContractType _GetContractType = new GetContractType();
        private readonly string _TempWordLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private readonly ContractType _ContractType;
        private GetEmployeeContract _GetEmployeeContract = new GetEmployeeContract();
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private readonly string _TempWordName;
        private readonly string _NewTempWordName;

        /// <summary>
        /// 导出员工合同Word
        /// </summary>
        /// <param name="contractID"></param>
        public ExportEmployeeContract(int contractID)
        {
            _ContractID = contractID;
            _ContractType = _GetContractType.GetContractTypeByContractID(contractID);
            string employeename="";
            try
            {
                employeename  = _IAccountBll.GetAccountById(_GetEmployeeContract.GetEmployeeContractByContractId(contractID).EmployeeID).Name;
            }
            catch {}
            _TempWordName = _TempWordLocation + "\\" + _ContractType.ContractTypeName + "n.doc";
            _NewTempWordName = _TempWordLocation + "\\" + employeename + _ContractType.ContractTypeName + ".doc";
        }

        /// <summary>
        /// 执行导出
        /// </summary>
        /// <returns></returns>
        public string Excute()
        {
            if (_ContractType.ContractTemplate != null)
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

                Application app = new Application();
                object nothing = Type.Missing;
                object localPatho = _TempWordName;
                object NEWlocalPatho = _NewTempWordName;

                Document doc =
                    app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
                try
                {
                    List<EmployeeContractBookMark> employeeContractBookMarkList =
                        _GetEmployeeContract.GetRealEmployeeContractBookMarkByContractID(_ContractID);
                    if (employeeContractBookMarkList != null && employeeContractBookMarkList.Count > 0)
                    {
                        foreach (EmployeeContractBookMark mark in employeeContractBookMarkList)
                        {
                            object name = mark.BookMarkName;
                            if (doc.Bookmarks != null)
                                doc.Bookmarks.get_Item(ref name).Range.Text = mark.BookMarkValue;
                        }
                    }
                    object fileFormat = WdSaveFormat.wdFormatTemplate97;
                    doc.SaveAs(ref NEWlocalPatho, ref fileFormat, ref nothing, ref nothing,
                               ref nothing, ref nothing, ref nothing,
                               ref nothing, ref nothing, ref nothing,
                               ref nothing, ref nothing, ref nothing,
                               ref nothing, ref nothing, ref nothing);
                    return _NewTempWordName;
                }
                finally
                {
                    doc.Close(ref nothing, ref nothing, ref nothing);
                    app.Quit(ref nothing, ref nothing, ref nothing);
                }
            }
            return "";
        }
    }
}
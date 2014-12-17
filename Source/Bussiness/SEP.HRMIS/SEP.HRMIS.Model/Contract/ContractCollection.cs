using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 合同收集器，用于导出
    /// </summary>
    [Serializable]
    public class ContractCollection
    {
        private List<Contract> _TheContracts = new List<Contract>();
        /// <summary>
        /// 要导出的合同列表
        /// </summary>
        public List<Contract> TheContracts
        {
            get { return _TheContracts; }
            set { _TheContracts = value; }
        }
        /// <summary>
        /// 导出成excel
        /// </summary>
        /// <returns></returns>
        public StringWriter ExportContractSearchToExcel()
        {
            StringWriter theMemoryWriter = new StringWriter();
            StringBuilder theTitle = new StringBuilder();
            theTitle.Append("合同ID\t").Append("员工ID\t").Append("员工姓名\t").Append("合同起始日\t").Append("合同到期日\t").Append(
                "合同类型\t").Append("备注\t").Append("附件\t");
            theMemoryWriter.WriteLine(theTitle.ToString());

            foreach (Contract e in _TheContracts)
            {
                theMemoryWriter.WriteLine(e.StatContract());
            }
            return theMemoryWriter;

        }
    }
}

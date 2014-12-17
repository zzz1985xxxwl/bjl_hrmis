using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��ͬ�ռ��������ڵ���
    /// </summary>
    [Serializable]
    public class ContractCollection
    {
        private List<Contract> _TheContracts = new List<Contract>();
        /// <summary>
        /// Ҫ�����ĺ�ͬ�б�
        /// </summary>
        public List<Contract> TheContracts
        {
            get { return _TheContracts; }
            set { _TheContracts = value; }
        }
        /// <summary>
        /// ������excel
        /// </summary>
        /// <returns></returns>
        public StringWriter ExportContractSearchToExcel()
        {
            StringWriter theMemoryWriter = new StringWriter();
            StringBuilder theTitle = new StringBuilder();
            theTitle.Append("��ͬID\t").Append("Ա��ID\t").Append("Ա������\t").Append("��ͬ��ʼ��\t").Append("��ͬ������\t").Append(
                "��ͬ����\t").Append("��ע\t").Append("����\t");
            theMemoryWriter.WriteLine(theTitle.ToString());

            foreach (Contract e in _TheContracts)
            {
                theMemoryWriter.WriteLine(e.StatContract());
            }
            return theMemoryWriter;

        }
    }
}

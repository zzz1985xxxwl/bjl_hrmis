using System.Data;
using System.Data.OleDb;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ������� ��������
    /// </summary>
    public class ImportUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetstrConn(string filePath)
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath +
                   ";Extended Properties=\"Excel 8.0;IMEX=1;\"";
        }

        /// <summary>
        /// Ա��������dt�е��к�
        /// </summary>
        public static int GetEmployeeRow(DataTable dt, string employeeName, string title)
        {
            int j = GetColumnIndex(dt, title);
            if (j == -1)
            {
                BllUtility.ThrowException(BllExceptionConst._WithOut_EmployeeName);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][j].ToString() == employeeName)
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// �õ�ĳ�е�һ��Ԫ��
        /// </summary>
        /// <param name="dt">Ҫ���ĸ�������</param>
        /// <param name="rowID">�ڼ����ң���0��ʼ</param>
        /// <param name="columnName">����</param>
        /// <returns>���ظñ��ָ��������ָ���е����ݣ����򷵻�EmptyNull</returns>
        public static string GetItem(DataTable dt, int rowID, string columnName)
        {
            int j = GetColumnIndex(dt, columnName);
            if (j != -1)
            {
                return dt.Rows[rowID][j].ToString();
            }
            else
            {
                return "EmptyNull";
            }
        }

        /// <summary>
        /// �õ��к�
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>û���򷵻�-1</returns>
        /// <param name="columnName">����</param>
        public static int GetColumnIndex(DataTable dt, string columnName)
        {
            int j = -1;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == columnName)
                {
                    j = i;
                    break;
                }
            }
            return j;
        }

        /// <summary>
        /// �õ���һ������������������������1���״�
        /// </summary>
        public static string FirstSheetName(OleDbConnection conn)
        {
            DataTable sheetNames = conn.GetOleDbSchemaTable
                (OleDbSchemaGuid.Tables, new object[] {null, null, null, "TABLE"});
            if (sheetNames.Rows.Count < 1)
            {
                BllUtility.ThrowException(BllExceptionConst._Sheet_Count_NotOne);
            }
            return sheetNames.Rows[0][2].ToString();
        }

        public const string EmptyNull = "EmptyNull";
    }
}
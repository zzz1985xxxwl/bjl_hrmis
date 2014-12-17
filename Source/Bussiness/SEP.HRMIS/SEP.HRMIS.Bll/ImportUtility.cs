using System.Data;
using System.Data.OleDb;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 导入相关 公共方法
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
        /// 员工姓名在dt中的列号
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
        /// 得到某列的一个元素
        /// </summary>
        /// <param name="dt">要在哪个表中找</param>
        /// <param name="rowID">第几行找，从0开始</param>
        /// <param name="columnName">列名</param>
        /// <returns>返回该表的指定列名，指定行的数据，无则返回EmptyNull</returns>
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
        /// 得到列号
        /// </summary>
        /// <param name="dt"></param>
        /// <returns>没有则返回-1</returns>
        /// <param name="columnName">列名</param>
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
        /// 得到第一个工作表，如果工作表个数不是1则抛错
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
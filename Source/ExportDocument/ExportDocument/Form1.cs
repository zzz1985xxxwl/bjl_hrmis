using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using SEP.HRMIS.Entity;
using System.IO;

namespace ExportDocument
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExportPosition_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "导出中.....";
            DataTable dt = loadData(@"
SELECT * INTO  #test FROM ( select a.PositionID,b.DepartmentName from TPositionDeptRelationShip as a left join TDepartment as b on a.DeptID = b.PKID) as c


SELECT * INTO  #test2 From(
SELECT PositionID,STUFF((SELECT ',' + DepartmentName FROM  #test t0 WHERE t0.PositionID=t1.PositionID FOR XML PATH('')),1, 1, '') AS DepartmentName
 FROM #test t1
 GROUP BY PositionID
 ) as c

SELECT * INTO  #test3 From(
SELECT PositionID,STUFF((SELECT ',' + EmployeeName FROM  TAccount t0 WHERE t0.PositionID=t1.PositionID FOR XML PATH('')),1, 1, '') AS EmployeeName
 FROM TAccount t1
 GROUP BY PositionId
) as c

SELECT * INTO #test4 from (Select a.PositionID,b.Name from TPositionNatureRelationship as a left join TPositionNature as b on a.PositionNatureID = b.PKID) as c
SELECT * INTO  #test5 From(
SELECT PositionID,STUFF((SELECT ',' + Name FROM  #test4 t0 WHERE t0.PositionID=t1.PositionID FOR XML PATH('')),1, 1, '') AS Name
 FROM #test4 t1
 GROUP BY PositionId
) as c

select PositionName as 职位名称, d.Name as 岗位性质 ,PositionDescription as 职位描述 ,Summary as 工作概要,MainDuties as 主要职责,Authority as 权限, b.DepartmentName as 适用部门  ,c.EmployeeName as 适用员工 
from TPosition as a
left join #test2 as b on a.PKID = b.PositionID
left join #test3 as c on a.PKID = c.PositionID
left join #test5 as d on a.PKID = d.PositionID
", "sep");
            MemoryStream s = ExcelUtility.RenderDataTableToExcel(dt) as MemoryStream;
            string file = ExportFile(s, "职位.xls");
            lblMessage.Text = "导出完 文件保存到  " + file;
        }


        private void btnPositionGrade_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "导出中.....";
            DataTable dt = loadData(@"
SELECT  [PositionGradeName]  as  职位等级名称,[PositionGradeDescription] as 职位描述
  FROM [TPositionGrade]
", "sep");
            MemoryStream s = ExcelUtility.RenderDataTableToExcel(dt) as MemoryStream;
            string file = ExportFile(s, "职位等级.xls");
            lblMessage.Text = "导出完 文件保存到  " + file;
        }

        private DataTable loadData(string sql, string type)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionValue(type)))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                return dt;
            }
        }

        public string ExportFile(MemoryStream stream, string name)
        {
            var directory = "c:\\export";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (var fileStream = new FileStream(directory + "\\" + name, FileMode.Create, FileAccess.Write))
            {
                byte[] data = stream.ToArray();
                fileStream.Write(data, 0, data.Length);
                fileStream.Flush();
                data = null;
            }
            return Path.Combine(directory, name);
        }

        public static string GetConnectionValue(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] != null)
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return string.Empty;
        }
    }
}

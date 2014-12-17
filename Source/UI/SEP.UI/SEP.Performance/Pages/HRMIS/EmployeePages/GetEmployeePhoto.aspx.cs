using System;
using System.IO;
using System.Web.UI;
using SEP.HRMIS.IFacede;

namespace SEP.Performance.Pages.HRMIS.EmployeePages
{
    public partial class GetEmployeePhoto : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int accountId = Convert.ToInt32(Request.QueryString["id"]);
            Response.ContentType = "application/octet-stream";
            IEmployeeFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeFacade();
            byte[] photo = _IEmployeeFacade.GetEmployeePhotoByAccountID(accountId);
            if (photo == null)
            {
                photo = getphoto("../../image/photobig.jpg");
            }
            Response.BinaryWrite(photo);
            Response.End();
        }

        public Byte[] getphoto(string photopath)
        {
            string str = Server.MapPath(photopath);
            FileStream file = new FileStream(str, FileMode.Open, FileAccess.Read);
            Byte[] bytBLOBData = new Byte[file.Length];
            file.Read(bytBLOBData, 0, bytBLOBData.Length);
            file.Close();
            return bytBLOBData;
        }
    }
}
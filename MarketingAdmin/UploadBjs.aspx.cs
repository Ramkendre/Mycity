using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;


public partial class UploadBjs : System.Web.UI.Page
{
    private string fileName, filePath = "~/downloadfileBJS/", insertionDate, fileType, month;
    private int year;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        try
        {
            string s = "http://www.myct.in/BJS.aspx/Aug20";
            string[] a = s.Split(new char[]{'/'});
            fileName = uploadfile.PostedFile.FileName;
            fileType = Path.GetExtension(uploadfile.PostedFile.FileName);
            filePath += fileName;
            uploadfile.PostedFile.SaveAs(Server.MapPath(filePath));
            messagelbl.Text = "File Uploaded Successfully.";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

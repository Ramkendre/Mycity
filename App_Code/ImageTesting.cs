using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for ImageTesting
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ImageTesting : System.Web.Services.WebService {
    CommonCode cc = new CommonCode();
    public ImageTesting () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public string InsertImage(string ImageStr)
    {
        string Data = "0";
        try
        {
            if (ImageStr != "" && ImageStr != null)
            {
                int i = 0;
                string sql = "Insert Into [Come2myCityDB].[dbo].[tbl_imagestore]([Image]) values('" + ImageStr + "')";
                i = cc.ExecuteNonQuery(sql);
                Data = "1";
            }
            else
            {
                Data = "0";
            }
        }
        catch (Exception ex)
        { }
        return Data;
        
    }
    
}


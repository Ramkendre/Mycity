using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for NewDrug
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class NewDrug : System.Web.Services.WebService {

    public NewDrug () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }


    [WebMethod(Description = "User Details")]
    public DataSet GetDetails(string MobileNo1, string Password1)
    {
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            try
            {
                {
                    SqlParameter[] par = new SqlParameter[3];
                    par[0] = new SqlParameter("@UserId", MobileNo1);
                    par[1] = new SqlParameter("@Password", Password1);
                    ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "Authenticate", par);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        return ds;
    }
    
}


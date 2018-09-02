using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Ezeehealth
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Ezeehealth : System.Web.Services.WebService {

   
    public Ezeehealth () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public DataSet Datasetvalue(string mobileno, string password)
    {
            DataSet UserDataset = new DataSet();
            //bool login = false;
            string sqlQuery = "execute [Come2myCityDB].[dbo].[Authenticate] @UserId = N'" + mobileno + "',@Password = N'" + password + "'";
            try
            {
                SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(UserDataset);
                //login = true;
            }
            
            catch (Exception ex)
            {
               
            }
            return UserDataset;
    }
    
}


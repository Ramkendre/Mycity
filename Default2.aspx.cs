using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.ApplicationServices;
using System.Data.OleDb;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //string path1 = Application.ExecutablePath;
        //string str = path1.Substring(0, path1.Length - 38);/come2mycity.com/wwwroot/App_Data

        //string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=http:\\www.come2mycity.com\\App_Data\\DBmyctMarathiSMS.accdb;Persist Security Info=True;Jet OLEDB:Database Password=Mahesh";
        string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\eZeeSoft\\Jan 2012\\myct.in_28_12_2012_Work_9AM\\App_Data\\DBmyctMarathiSMS.accdb;Persist Security Info=True;Jet OLEDB:Database Password=Mahesh";
        OleDbConnection con = new OleDbConnection(str);
        con.Open();
        OleDbDataAdapter da = new OleDbDataAdapter("Select * from SendSmsStatus", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Teml");
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
    public void showList()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        con .Open ();
      
    
    }
}

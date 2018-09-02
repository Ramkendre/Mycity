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
using System.Data;
using System.Data.SqlClient;

public partial class MarketingAdmin_EzeeMunicipalCouncil : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindState();
            BindDistrict();
        }
    }
    public void BindState()
    {
        string str = "Select [StateId],[StateName] FROM [Come2myCityDB].[come2mycity].[StateMaster]";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DDLState.DataSource = ds;
        if(ds.Tables[0].Rows.Count>0)
        {
            DDLState.DataTextField = "StateName";
            DDLState.DataValueField = "StateId";
        }
        DDLState.DataBind();
    }
    public void BindDistrict()
    {
        string str = "Select [DistrictId],[DistrictName] FROM [Come2myCityDB].[come2mycity].[DistrictMaster]";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Connection = con;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ddlDistrict.DataSource = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "DistrictId";
        }
        ddlDistrict.DataBind();
    }
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
      
    }


}

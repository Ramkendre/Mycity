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
using System.Data.SqlClient;

public partial class Html_JDemandJob : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    CommonCode cc = new CommonCode();
    JDemandJobBLL objJDemandJobBLL = new JDemandJobBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            fillddlSector();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AddRecord();
    }
    public void fillddlSector()
    {
        DataSet ds = new DataSet();
        string str = "SELECT [ID],[DivisionName] FROM [Come2myCityDB].[come2mycity].[tbl_JDivision]";
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        ddlSector.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlSector.DataValueField = "ID";
            ddlSector.DataTextField = "DivisionName";
        }
        ddlSector.DataBind();
        ddlSector.Items.Add("---Select---");
        ddlSector.SelectedIndex = ddlSector.Items.Count - 1;
        ddlSector.Items[ddlSector.Items.Count - 1].Value = "";


    }
    public void fillddlRole()
    {
        DataSet ds = new DataSet();

        string s = "select [SID],[NameOfQP] FROM [Come2myCityDB].[come2mycity].[tbl_JSubDivision] where DID='" + ddlSector.SelectedValue + "'";

        SqlDataAdapter da = new SqlDataAdapter(s, con);
        da.Fill(ds);
        ddlJRole.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlJRole.DataValueField = "SID";
            ddlJRole.DataTextField = "NameOfQP";
        }
        ddlJRole.DataBind();
        ddlJRole.Items.Add("--Select--");
        ddlJRole.SelectedIndex = ddlJRole.Items.Count - 1;
        ddlJRole.Items[ddlJRole.Items.Count - 1].Value = "";
    }
    public void AddRecord()
    {
        try
        {
            objJDemandJobBLL.Sector1 = Convert.ToString(ddlSector.Text);
            objJDemandJobBLL.JRole1 = Convert.ToString(ddlJRole.Text);
            objJDemandJobBLL.Experience1 = Convert.ToString(rbtnExp.Text);
            objJDemandJobBLL.Salary1 = Convert.ToString(txtSalary.Text);
            objJDemandJobBLL.District1 = Convert.ToString(txtDistrict.Text);
            objJDemandJobBLL.State1 = Convert.ToString(txtState.Text);
            objJDemandJobBLL.Taluka1 = Convert.ToString(txtTaluka.Text);
            objJDemandJobBLL.Date1 = Convert.ToString(txtdate.Text);
            objJDemandJobBLL.IntrestedFor1 = Convert.ToString(txtIntrest.Text);
           
            objJDemandJobBLL.UserId1 = Convert.ToString(Session["User"]);
            string c = DateTime.Now.Date.ToString("yyyy-MM-dd");
            objJDemandJobBLL.EntryDate1 = Convert.ToString(c);




            int Status = objJDemandJobBLL.AddRecordBLL(objJDemandJobBLL);
            if (Status == 1)
            {
                //LoadGrid();
                //Clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event not added Successfully')", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }



    }
    protected void ddlSector_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillddlRole();
    }
}

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
using System.Collections.Generic;

public partial class html_AppRegForm : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        
        {
            LoadData();
            BindProjectList(); 
        }
        
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCountries(string prefixText)
    {
        string conn = ConfigurationManager.AppSettings["ConnectionString"];
        SqlConnection con = new SqlConnection(conn);
        con.Open();
        SqlCommand cmd = new SqlCommand("select mobileNo from EzeeDrugsAppDetail where mobileNo like @mobileNo+'%'", con);
        cmd.Parameters.AddWithValue("@mobileNo", prefixText); 
        SqlDataReader dr = cmd.ExecuteReader();
        //da.Fill(dr);
        List<string> CountryNames = new List<string>();
        while (dr.Read())
        {
            CountryNames.Add(dr["mobileNo"].ToString());
        }
        return CountryNames;
        //for (int i = 0; i < dt.Rows.Count; i++)
        //{
        //    CountryNames.Add(dt.Columns["mobileNo"]..ToString());
        //}
        //return CountryNames;
       
    }



    public void LoadData()
    {
        try
        {
            string Sql = "SELECT EzeeDrugAppId,keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,EntryDate,RefMobileNo FROM EzeeDrugsAppDetail order by EzeeDrugAppId desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    public void BindProjectList()
    {
        string str = "Select [prj_Id],[prj_Name] FROM [Come2myCityDB].[come2mycity].[tblProjectList]";
        DataSet ds = cc.ExecuteDataset(str);
        ddlProjectList.DataSource = ds.Tables[0];
        ddlProjectList.DataTextField = "prj_Name";
        ddlProjectList.DataValueField = "prj_Id";
        ddlProjectList.DataBind();
        ddlProjectList.Items.Insert(0, new ListItem("-Select-", "0"));
        ddlProjectList.SelectedIndex = 0;
        
        
    }
    public void projectwise()
    {
        try
        {
            string Sql = "SELECT EzeeDrugAppId,keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,EntryDate,RefMobileNo FROM EzeeDrugsAppDetail where keyword='" + ddlProjectList.SelectedItem.Text + "' order by EzeeDrugAppId desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;
        //LoadData();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void txtsearch_TextChanged(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();
    //    string sql = "SELECT EzeeDrugAppId,keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,EntryDate,RefMobileNo FROM EzeeDrugsAppDetail where mobileNo like '%"+txtsearch.Text+"'";
    //    ds= cc.ExecuteDataset(sql);
    //    GridView1.DataSource = ds;
    //    GridView1.DataBind();
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string sql = "SELECT EzeeDrugAppId,keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,EntryDate,RefMobileNo FROM EzeeDrugsAppDetail where mobileNo = '" + txtsearch.Text + "' ";
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
    protected void btnsearchBymaxId_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string sql = "SELECT TOP 50 EzeeDrugAppId,keyword,strDevId,strSimSerialNo,firstName,lastName,firmName,mobileNo,address,eMailId,typeOfUse_Id,pincode,EntryDate,RefMobileNo FROM EzeeDrugsAppDetail order by EzeeDrugAppId desc";
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        LoadData();
    }
    protected void ddlProjectList_SelectedIndexChanged(object sender, EventArgs e)
    {
        projectwise();
    }
}

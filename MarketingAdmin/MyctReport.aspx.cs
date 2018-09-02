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

public partial class MarketingAdmin_MyctReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lnkRegUser_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        //LoadGridLogin();

    }

    protected void lnkStaffAbsenty_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        //LoadGridLogin();
    }

    public void count()
    {
        string str = string.Empty;
        // string str = "select sum(EzeeDrugAppId) FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [keyword]='" + txtPName.Text + "' group by EzeeDrugAppId" ;
        // string str = "SELECT COUNT(EzeeDrugAppId) FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] WHERE [keyword]='" + ddlAllProjectName.SelectedValue + "' AND EntryDate LIKE '%" + txtDate.Text.Substring(0,7) + "%'";
        if (ddlAllProjectName.SelectedValue != "0" && txtDate.Text != "")
        {
             str = "select COUNT(*) " +
                       " FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] EDrug INNER JOIN [Come2myCityDB].[come2mycity].[DistrictMaster] DM  ON EDrug.[District] = DM.[DistrictId] " +
                        " where [keyword]='" + ddlAllProjectName.SelectedValue + "' AND EntryDate LIKE '%" + txtDate.Text.Substring(0, 7) + "%'";
        }
        else if (ddlAllProjectName.SelectedValue != "0" && txtDate.Text == "")
        {
            str = "select COUNT(*) " +
                        " FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] EDrug INNER JOIN [Come2myCityDB].[come2mycity].[DistrictMaster] DM  ON EDrug.[District] = DM.[DistrictId] " +
                         " where [keyword]='" + ddlAllProjectName.SelectedValue + "'";
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Select Project Name');", true);
        }
        DataSet ds = new DataSet();
        string st = cc.ExecuteScalar(str);
        lblcount.Text = "All Registered Members Are : '" + st + "'";
    }

    public void LoadData()
    {
        string str = string.Empty;
        // string str = "select [keyword],[strDevId],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[EntryDate],[RefMobileNo],[State],[District],[usertype],[Qualification] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [keyword]='" + txtPName.Text.ToUpper() + "' and EntryDate='"+txtDate.Text+"'";
        // string str = "SELECT [keyword],[strDevId],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[EntryDate],[RefMobileNo],[State],[District],[usertype],[Qualification] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] WHERE [keyword]='" + ddlAllProjectName.SelectedValue + "' AND EntryDate LIKE '%" + txtDate.Text.Substring(0,7) + "%'";
        if (ddlAllProjectName.SelectedValue != "0" && txtDate.Text != "")
        {
            str = "select [keyword],[strDevId],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[EntryDate],[RefMobileNo],DM.[DistrictName],[usertype],[Qualification] " +
                   " FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] EDrug INNER JOIN [Come2myCityDB].[come2mycity].[DistrictMaster] DM  ON EDrug.[District] = DM.[DistrictId] " +
                    " where [keyword]='" + ddlAllProjectName.SelectedValue + "' AND EntryDate LIKE '%" + txtDate.Text.Substring(0, 7) + "%'";
        }
        else if (ddlAllProjectName.SelectedValue != "0" && txtDate.Text == "")
        {
            str = "select [keyword],[strDevId],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[EntryDate],[RefMobileNo],DM.[DistrictName],[usertype],[Qualification] " +
                   " FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] EDrug INNER JOIN [Come2myCityDB].[come2mycity].[DistrictMaster] DM  ON EDrug.[District] = DM.[DistrictId] " +
                    " where [keyword]='" + ddlAllProjectName.SelectedValue + "'";
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Please Select Project Name');", true);
        }
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        LoadData();
        count();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        gvItem.DataBind();

        LoadData();
    }

    public void LoadDataForRefMobNo()
    {
        // string str = "select [keyword],[strDevId],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[EntryDate],[RefMobileNo],[State],[District],[usertype],[Qualification] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + txtRefMobileNo.Text + "' ";
        // string str = "select [keyword],[strDevId],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[EntryDate],[RefMobileNo],[State],[District],[usertype],[Qualification] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + txtRefMobileNo.Text + "' AND [keyword] = '"+ ddlProjectName.SelectedValue +"' ";

        string str = "select [keyword],[strDevId],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[EntryDate],[RefMobileNo],DM.[DistrictName],[usertype],[Qualification] " +
                    " FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] EDrug INNER JOIN [Come2myCityDB].[come2mycity].[DistrictMaster] DM  ON EDrug.[District] = DM.[DistrictId] " +
                     " where [RefMobileNo]='" + txtRefMobileNo.Text + "' AND [keyword] = '" + ddlProjectName.SelectedValue + "' ";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        gvItem2.DataSource = ds.Tables[0];
        gvItem2.DataBind();
    }

    protected void btnSubmit2_Click(object sender, EventArgs e)
    {
        LoadDataForRefMobNo();
    }

    protected void lnksend_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:13355/HTML/ssrsReport.aspx");
    }
}

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
using System.Data.SqlClient;

public partial class MarketingAdmin_PWPAddData : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int result = 0;
        string sql = String.Empty;
        try
        {
            string dt = cc.DateFormatStatus();
            if (btnSubmit.Text == "Submit")
            {                
                if (ddltype.SelectedValue == "1")
                {
                    sql = "insert into [Come2myCityDB].[come2mycity].[PWP_tblSportsNews]([PWP_NHeading],[PWP_NDetails],[PWP_NEntryDate],[PWP_NStatus]) values ('" + txtHeading.Text + "','" + txtDetails.Text + "','" + dt + "','1')";
                }
                else if (ddltype.SelectedValue == "2")
                {
                    sql = "insert into [Come2myCityDB].[come2mycity].[PWP_tblGameInfo]([PWP_GHeading],[PWP_GDetails],[PWP_GEntryDate],[PWP_GStatus]) values ('" + txtHeading.Text + "','" + txtDetails.Text + "','" + dt + "','1')";
                }
                else if (ddltype.SelectedValue == "3")
                {
                    sql = "insert into [Come2myCityDB].[come2mycity].[PWP_tblEvents]([PWP_EHeading],[PWP_EDetails],[PWP_EEntryDate],[PWP_EStatus]) values ('" + txtHeading.Text + "','" + txtDetails.Text + "','" + dt + "','1')";
                }
                result = cc.ExecuteNonQuery(sql);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data saved successfully...!!!')", true);
                }
            }
            else if (btnSubmit.Text == "Modify")
            {
                if (ddltype.SelectedValue == "1")
                {
                    sql = "update [Come2myCityDB].[come2mycity].[PWP_tblSportsNews] set [PWP_NHeading]='" + txtHeading.Text + "',[PWP_NDetails]='" + txtDetails.Text + "',[PWP_NEntryDate]='" + dt + "' where [PWP_NID]='" + lblId.Text + "' ";
                }
                else if (ddltype.SelectedValue == "2")
                {
                    sql = "update [Come2myCityDB].[come2mycity].[PWP_tblGameInfo] set [PWP_GHeading]='" + txtHeading.Text + "',[PWP_GDetails]='" + txtDetails.Text + "',[PWP_GEntryDate]='" + dt + "' where [PWP_GID]='" + lblId.Text + "'";
                }
                else if (ddltype.SelectedValue == "3")
                {
                    sql = "update [Come2myCityDB].[come2mycity].[PWP_tblEvents] set [PWP_EHeading]='" + txtHeading.Text + "',[PWP_EDetails]='" + txtDetails.Text + "',[PWP_EEntryDate]='" + dt + "' where [PWP_EID]='" + lblId.Text + "'";
                }
                result = cc.ExecuteNonQuery(sql);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data updated successfully...!!!')", true);
                }
                btnSubmit.Text = "Submit";
                lblId.Text = "";
            }
            clear();
            LoadGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadGrid()
    {
        string str = "select [PWP_NID],[PWP_NHeading],[PWP_NDetails] from [Come2myCityDB].[come2mycity].[PWP_tblSportsNews]";
        str += "select [PWP_GID],[PWP_GHeading],[PWP_GDetails] from [Come2myCityDB].[come2mycity].[PWP_tblGameInfo]";
        str += "select [PWP_EID],[PWP_EHeading],[PWP_EDetails] from [Come2myCityDB].[come2mycity].[PWP_tblEvents]";

        ds = cc.ExecuteDataset(str);
                
        gvDisp1.DataSource = ds.Tables[0];
        gvDisp1.DataBind();

        gvDisp2.DataSource = ds.Tables[1];
        gvDisp2.DataBind();

        gvDisp3.DataSource = ds.Tables[2];
        gvDisp3.DataBind();
    }

    public void clear()
    {
        ddltype.SelectedIndex = 0;
        txtHeading.Text = "";
        txtDetails.Text = "";
    }
    protected void gvDisp1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDisp1.PageIndex = e.NewPageIndex;
        gvDisp1.DataBind();
    }
    protected void gvDisp1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = Convert.ToString(e.CommandArgument);
        if (e.CommandName == "Modify")
        {
            string sql = "select [PWP_NID],[PWP_NHeading],[PWP_NDetails] from [Come2myCityDB].[come2mycity].[PWP_tblSportsNews] where [PWP_NID]='" + id + "'";
            ds = cc.ExecuteDataset(sql);

            lblId.Text = ds.Tables[0].Rows[0]["PWP_NID"].ToString();
            ddltype.SelectedValue = "1";
            txtHeading.Text = ds.Tables[0].Rows[0]["PWP_NHeading"].ToString();
            txtDetails.Text = ds.Tables[0].Rows[0]["PWP_NDetails"].ToString();

            btnSubmit.Text = "Modify";
        }
    }
    protected void gvDisp2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDisp2.PageIndex = e.NewPageIndex;
        gvDisp2.DataBind();
    }
    protected void gvDisp2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = Convert.ToString(e.CommandArgument);
        if (e.CommandName == "Modify")
        {
            string sql = "select [PWP_GID],[PWP_GHeading],[PWP_GDetails] from [Come2myCityDB].[come2mycity].[PWP_tblGameInfo] where [PWP_GID]='" + id + "'";
            ds = cc.ExecuteDataset(sql);

            lblId.Text = ds.Tables[0].Rows[0]["PWP_GID"].ToString();
            ddltype.SelectedValue = "2";
            txtHeading.Text = ds.Tables[0].Rows[0]["PWP_GHeading"].ToString();
            txtDetails.Text = ds.Tables[0].Rows[0]["PWP_GDetails"].ToString();

            btnSubmit.Text = "Modify";
        }
    }
    protected void gvDisp3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = Convert.ToString(e.CommandArgument);
        if (e.CommandName == "Modify")
        {
            string sql = "select [PWP_EID],[PWP_EHeading],[PWP_EDetails] from [Come2myCityDB].[come2mycity].[PWP_tblEvents] where [PWP_EID]='" + id + "'";
            ds = cc.ExecuteDataset(sql);

            lblId.Text = ds.Tables[0].Rows[0]["PWP_EID"].ToString();
            ddltype.SelectedValue = "3";
            txtHeading.Text = ds.Tables[0].Rows[0]["PWP_EHeading"].ToString();
            txtDetails.Text = ds.Tables[0].Rows[0]["PWP_EDetails"].ToString();

            btnSubmit.Text = "Modify";
        }
    }    
    protected void gvDisp3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDisp3.PageIndex = e.NewPageIndex;
        gvDisp3.DataBind();
    }
}

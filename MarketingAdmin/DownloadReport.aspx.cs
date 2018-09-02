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

public partial class MarketingAdmin_DownloadReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DownloadurlBLL objbaldownload = new DownloadurlBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUrl();
            BindSpecificURL();

        }

    }
    private void BindUrl()
    {
        try
        {
            DataSet ds = objbaldownload.BLLGetAllurl(objbaldownload);
            ddlselectLink.DataTextField = "RequestURL";
            ddlselectLink.DataValueField = "VisitorId";
            ddlselectLink.DataSource = ds.Tables[0];
            ddlselectLink.DataBind();


        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        // GetRecord();
        GetActualRecord1();
    }
    private void GetRecord()
    {
        try
        {
            Label1.Visible = true;
            lblcount.Visible = true;
            string sql = "select count(*) from VisitorIPDetails where RequestURL='" + ddlselectLink.SelectedItem.Text + "'";
            lblcount.Text = cc.ExecuteScalar(sql);
            sql = "select * from VisitorIPDetails where RequestURL='" + ddlselectLink.SelectedItem.Text + "' order by VisitorId desc";
            DataSet ds = cc.ExecuteDataset(sql);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetActualRecord1();
    }


    private void BindSpecificURL()
    {
        try
        {
            DataSet ds = objbaldownload.BLLGetSpecificurl(objbaldownload);
            ddlwanted.DataTextField = "url";
            ddlwanted.DataValueField = "Id";
            ddlwanted.DataSource = ds.Tables[0];
            ddlwanted.DataBind();

        }
        catch (Exception ex)
        { }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        GetActualRecord();

    }

    private void GetActualRecord()
    {
        try
        {
            Label5.Visible = true;
            Label4.Visible = true;
            string value = ddlwanted.SelectedItem.Text;
            objbaldownload.Url = value;
            DataSet ds = objbaldownload.BLLGetDownloadRecord(objbaldownload);
            string counting = Convert.ToString(ds.Tables[0].Rows[0]["counting"]);
            Label5.Text = counting;
            GridView2.DataSource = ds.Tables[1];
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    private void GetActualRecord1()
    {
        try
        {
            Label1.Visible = true;
            lblcount.Visible = true;
            string value = ddlselectLink.SelectedItem.Text;
            objbaldownload.Url = value;
            DataSet ds = objbaldownload.BLLGetDownloadRecord(objbaldownload);
            string counting = Convert.ToString(ds.Tables[0].Rows[0]["counting"]);
            lblcount.Text = counting;
            GridView1.DataSource = ds.Tables[1];
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GetActualRecord();
    }
}

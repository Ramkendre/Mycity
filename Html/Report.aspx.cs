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

public partial class html_Report : System.Web.UI.Page
{
    CommonCode cc=new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvUsershow();
            gvWebsiteReportshow();
        }

    }

    private void gvUsershow()
    {
        
        
        string sysdate = DateTime.Now.ToString("MM/dd/yyyy");
        string mobileno = Convert.ToString(Session["MobileNo"]);
        string sql = "select msgTo,msgDate,sendername,Msg,Flagstatus from ReportData where msgFrom='" + mobileno + "' and msgDate like'" + sysdate + "%' order by Id desc";
        DataSet ds = cc.ExecuteDataset(sql);
        gvUser.DataSource = ds.Tables[0];
        gvUser.DataBind();
    }

    private void gvWebsiteReportshow()
    {
        string sysdate = DateTime.Now.ToString("MM/dd/yyyy");

        string mobileno = Convert.ToString(Session["MobileNo"]);

        string sql = "select SenderMobile,ReceiverMobile, Msg,date,status from smsStoring where SenderMobile='" + mobileno + "' and date = '" + sysdate + "' order by Id desc ";
        DataSet ds = cc.ExecuteDataset(sql);
        gvWebsiteReport.DataSource = ds.Tables[0];
        gvWebsiteReport.DataBind();
    }




    protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUser.PageIndex = e.NewPageIndex;
        gvUsershow();
    }
    protected void gvWebsiteReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvWebsiteReport.PageIndex = e.NewPageIndex;
        gvWebsiteReportshow();


    }
    protected void btnGetRecord_Click(object sender, EventArgs e)
    {

        LongcodeFetchRecord(); 

    }

    private void LongcodeFetchRecord()
    {
        string sysdate = DateTime.Now.ToString("MM/dd/yyyy");
        string mobileno = Convert.ToString(Session["MobileNo"]);
        string sql = "select msgTo,msgDate,sendername,Msg,Flagstatus from ReportData where msgFrom='" + mobileno + "' and msgDate between '" + txtFrmDate.Text + "' and '" + txtTodate.Text + "' order by Id desc";
        DataSet ds = cc.ExecuteDataset(sql);
        gvUser.DataSource = ds.Tables[0];
        gvUser.DataBind();
    }
    protected void btnRecord_Click(object sender, EventArgs e)
    {
        WebsiteFetchRecord();
        
    }

    private void WebsiteFetchRecord()
    {
        //string sysdate = DateTime.Now.ToString("MM/dd/yyyy");
        string mobileno = Convert.ToString(Session["MobileNo"]);
        string sql = "select SenderMobile,ReceiverMobile, Msg,date,status from smsStoring where SenderMobile='" + mobileno + "' and date between '0" +txtFromDate1.Text+ "' and '" + txtTodate1.Text + "' order by Id desc";
        DataSet ds = cc.ExecuteDataset(sql);
        gvWebsiteReport.DataSource = ds.Tables[0];
        gvWebsiteReport.DataBind();
        
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../html/Sendsms.aspx");
    }
    protected void btnBack1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../html/Sendsms.aspx");
    }
}

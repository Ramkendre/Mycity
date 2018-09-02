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

public partial class MarketingAdmin_DARReport : System.Web.UI.Page
{
    LongCodeBLL objBLLLongCode = new LongCodeBLL();
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewLongCodeReport();
        }


    }
    public void ViewLongCodeReport()
    {
        try
        {
            DataSet ds = objBLLLongCode.BLLDARLongCodeReport(objBLLLongCode);
            gvLongCodeReport.DataSource = ds.Tables[0];
            gvLongCodeReport.DataBind();
            lbltotalcount.Text = Convert.ToString(ds.Tables[1].Rows[0]["total"]);

        }
        catch (Exception ex)
        {
        }

    }
    protected void gvLongCodeReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLongCodeReport.PageIndex = e.NewPageIndex;
        ViewLongCodeReport();
    }
    protected void gvLongCodeReport_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=14");
    }

    protected void btnGridtoexcel_Click(object sender, EventArgs e)
    {
        string attachment = "attachment; filename=DailyAttendanceReport.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        HtmlForm frm = new HtmlForm();
        ds = objBLLLongCode.BLLDARLongCodeReport(objBLLLongCode);
        DataGrid grid = new DataGrid();
        grid.DataSource = ds.Tables[0];
        grid.DataBind();
        grid.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }
}

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
using System.Globalization;
using System.Text;
using System.IO;

public partial class MarketingAdmin_LongCodeReport : System.Web.UI.Page
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
    //public void ViewLongCodeReportAll()
    //{
    //    try
    //    {
    //         ds = objBLLLongCode.BLLLongCodeReportAll(objBLLLongCode);
    //        DataGrid dg = new DataGrid();
    //        dg.DataSource = ds.Tables[0];
    //        dg.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //    }

    

    //}
    public void ViewLongCodeReport()
    {
        try
        {
            DataSet ds = objBLLLongCode.BLLLongCodeReport(objBLLLongCode);
            gvLongCodeReport.DataSource = ds.Tables[0];
            gvLongCodeReport.DataBind();
            string sql = "select count(*) from test where Message like '*UVA%' or Message like '*YUVA%' or Message like 'UVA%' or Message like 'YUVA%'";
            lbltotalcount.Text = cc.ExecuteScalar(sql);

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
        string attachment = "attachment; filename=UVAReport.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        // Create a form to contain the grid
        HtmlForm frm = new HtmlForm();
        //gvLongCodeReport.Parent.Controls.Add(frm);
        //frm.Attributes["runat"] = "server";
        //frm.Controls.Add(gvLongCodeReport);
        //frm.RenderControl(htw);
        ds = objBLLLongCode.BLLLongCodeReportAll(objBLLLongCode);
        DataGrid grid = new DataGrid();
        grid.DataSource = ds.Tables[0];
        grid.DataBind();
        grid.RenderControl(htw);
        //gvLongCodeReport.AllowPaging = false;
        //ViewLongCodeReport();
       // gvLongCodeReport.RenderControl(htw);
        
        Response.Write(sw.ToString());
        Response.End();
        //gvLongCodeReport.AllowPaging = true;
        //ViewLongCodeReport();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
}

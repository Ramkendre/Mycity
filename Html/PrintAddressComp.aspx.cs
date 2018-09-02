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
using System.Drawing.Design;
using System.IO;

public partial class html_PrintAddressComp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Datalistclear();
            Datalistshow();
        }
    }

    private void Datalistshow()
    {
        DataTable dt = (DataTable)Session["SelectedRecords"];
        Datalist1.DataSource = dt;
        Datalist1.DataBind();

        //DataSet ds = (DataSet)Session["SelectedRecords"];
        //Datalist1.DataSource = ds;
        //Datalist1.DataBind();
    }

    private void Datalistclear()
    {
        Datalist1.DataSource = null;
        Datalist1.DataBind();
    }
    private void printselection()
    {
        Label2.Text = Session["page"].ToString();
    }

    //-----------------------------------Don't Delete This Function. It Is used to Excel Download File-----------------------------------------------

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=Report.csv");
        //    Response.ContentType = "application/vnd.csv";
        //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        //    Datalist1.RenderControl(htmlWrite);
        //    Response.Write(stringWrite.ToString());
        //    Response.End();

        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}


    }
    
}

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

public partial class MarketingAdmin_DownloadNews : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        { }
        else
        { bindgrid(); }
        
    }
    public void bindgrid()
    {
        try
        {
            string sql = "select NID, NHeading, DONR, LDOA, NInDetail from [Come2myCityDB].[come2mycity].[tblShowNews] where NTopic='Exam' or NTopic='Job' order by NID desc ";
            DataSet ds = cc.ExecuteDataset(sql);

            gvDispNews.DataSource = ds;
            gvDispNews.DataBind();
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void downloadnews_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("NID");
            dt.Columns.Add("News Heading");
            dt.Columns.Add("Date of News Received");
            dt.Columns.Add("Last Date of Application");
            dt.Columns.Add("News In Detail");
            ds.Tables.Add(dt);
           

            foreach (GridViewRow row in gvDispNews.Rows)
            {
                CheckBox cb = row.FindControl("chkNews") as CheckBox;
                if (cb.Checked)
                {
                    ds.Tables[0].Rows.Add(new string[]{row.Cells[0].Text,row.Cells[1].Text,
                row.Cells[2].Text,
                row.Cells[3].Text,
                row.Cells[4].Text});
                }
            }
            GridView gv = new GridView();
            gv.DataSource = ds;
            gv.DataBind();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=News.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gv.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

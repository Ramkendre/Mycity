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

public partial class PopUpFile_KeyDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    int k;
    protected void Page_Load(object sender, EventArgs e)
    {
        k = Convert.ToInt16(Request.QueryString["Key"]);
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        try
        {
            string Sql = "Select KeywordName, KeywordSyntax,KeywordPurpose,KeyDiscip,WebsiteGroup, EntryDate from KeywordInformation where KeyId=" + k + "";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblKeywordName.Text = Convert.ToString(ds.Tables[0].Rows[0]["KeywordName"]);
                lblKeywordSyntax.Text = Convert.ToString(ds.Tables[0].Rows[0]["KeywordSyntax"]);
                lblKeywordPurpose.Text = Convert.ToString(ds.Tables[0].Rows[0]["KeywordPurpose"]);
                lblKeyDiscip.Text = Convert.ToString(ds.Tables[0].Rows[0]["KeyDiscip"]);
                lblEntryDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["EntryDate"]);
                string wg = Convert.ToString(ds.Tables[0].Rows[0]["WebsiteGroup"]);

                if (wg == "1")
                {
                    lblWebsiteGroup.Text = "Myct";
                }
                else if (wg == "2")
                {
                    lblWebsiteGroup.Text = "Udisecce";
                }
                else if (wg == "3")
                {
                    lblWebsiteGroup.Text = "School";
                }
                else if (wg == "4")
                {
                    lblWebsiteGroup.Text = "Android Mobile Apps";
                }
            }
        }
        catch (Exception ex)
        { }
    }
    //-----------------------------------Don't Delete This Function. It Is used to Excel Download File-----------------------------------------------
    //public override void VerifyRenderingInServerForm(Control control)
    //{

    //}
    //protected void btnDownload_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Response.Clear();
    //        Response.AddHeader("content-disposition", "attachment;filename=KeywordReport.doc");
    //        Response.ContentType = "application/vnd.xls";
    //        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    //        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    //        gvItem.RenderControl(htmlWrite);
    //        Response.Write(stringWrite.ToString());
    //        Response.End();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
}

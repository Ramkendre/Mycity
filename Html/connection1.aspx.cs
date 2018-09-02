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

public partial class Html_connection1 : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    BLLConnection1 objBLL = new BLLConnection1();
    protected void Page_Load(object sender, EventArgs e)
    {
        GetRecord();

    }
    private void GetRecord()
    {
        //string newSql = "select top(50)cid,mobileNumber,MIMENumber,p1,recordDate from connection1 where mobilenumber != '' order by cid desc";
        DataSet ds = new DataSet();
        ds = objBLL.BLLGetMiscalRecord();
        allRecordGrid.DataSource = ds.Tables[0];
        allRecordGrid.DataBind();
    }

    protected void allRecordGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        allRecordGrid.PageIndex = e.NewPageIndex;
        GetRecord();
    }
}

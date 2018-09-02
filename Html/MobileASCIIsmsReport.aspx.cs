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

public partial class html_MobileASCIIsmsReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string newSql = "select top(100)* from [Come2myCityDB].[dbo].[longCodeasciiSmsReceve] where receiverMobileNo != '' and senderMobileNo != '' order by id desc";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(newSql);
        allRecordGrid.DataSource = ds.Tables[0];
        allRecordGrid.DataBind();
    }
}

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

public partial class MarketingAdmin_uvajagarReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        string collegecode = txtcode.Text;
        string sql = "select top(50)collegecode.Id as id,collegecode.userid,usrFirstName as Name,collegecode.collegecode,usrMobileNo,usrAddress" +
                    " from collegecode inner join UserMaster " +
                    " on collegecode.userid =UserMaster.usrUserId " +
                     " where  collegecode='" + collegecode + "'" +
        "order by collegecode.Id desc ";
                   
        DataSet ds = cc.ExecuteDataset(sql);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        Label2.Visible = true;
        lblCount.Visible = true;
        sql = "select  count(*)" +
                    " from collegecode inner join UserMaster " +
                    " on collegecode.userid =UserMaster.usrUserId  " +
                    " where  collegecode='" + collegecode + "'";
        lblCount.Text = cc.ExecuteScalar(sql);
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtcode.Text = "";

    }
}

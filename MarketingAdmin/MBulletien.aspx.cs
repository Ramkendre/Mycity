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

public partial class MarketingAdmin_MBulletien : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gvCommitteesshow();
        }

    }

    private void gvCommitteesshow()
    {
        try
        {
           
            string userid = Session["MarketingUser"].ToString();
            if (userid == "6dde8c3d-1895-4904-b332-764f63206fc0")
            {
                string sql = "select Id,Committee_name,hiturl from committeedetail ";
                DataSet ds = cc.ExecuteDataset(sql);
                gvCommittees.DataSource = ds.Tables[0];
                gvCommittees.DataBind();

            }
            else
            {
                string sqlfetch = "select commitee_id from CommitteeRole where userid='" + userid + "'";
                string commitee = cc.ExecuteScalar(sqlfetch);
                string sql = "select Committee_name,hiturl from committeedetail where Id in(" + commitee + ")";
                DataSet ds = cc.ExecuteDataset(sql);
                gvCommittees.DataSource = ds.Tables[0];
                gvCommittees.DataBind();
            }

        }
        catch (Exception ex)
        {
        }
    }
    
}

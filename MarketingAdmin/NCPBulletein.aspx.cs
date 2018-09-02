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

public partial class MarketingAdmin_NCPBulletein : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        gvCommitteesshow();

    }
    private void gvCommitteesshow()
    {
        try
        {

            string userid = Session["MarketingUser"].ToString();

            string role = Session["Roleid"].ToString();
            if (role == "38")
            {
                string commitee = "33,34,35";
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

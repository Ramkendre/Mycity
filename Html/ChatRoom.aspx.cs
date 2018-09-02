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

public partial class html_ChatRoom : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetOnline();
        }

    }
    private void GetOnline()
    {
        string sql = "select usrFirstName+' '+usrLastName as Fullname from DemoOnline right outer join friendrelationmaster on DemoOnline.userid=friendrelationmaster.friendid right outer join usermaster on DemoOnline.userid=usermaster.usrUserid where friendrelationmaster.userid='" + Session["User"] + "' and status='Active'";
        DataSet ds = cc.ExecuteDataset(sql);
        gvUseronline.DataSource = ds.Tables[0];
        gvUseronline.DataBind();
        
    }
}

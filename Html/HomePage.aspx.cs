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

public partial class html_HomePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string UserIdSession = Convert.ToString(Session["User"]);
            if (UserIdSession == "")
            {
                Response.Redirect("../default.aspx");
            }
            else
            {

                if (!IsPostBack)
                {
                    //LoadValue();
                }
            }
        }
        catch (Exception ex)
        { }
    }
}

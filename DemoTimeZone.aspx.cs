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

public partial class DemoTimeZone : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text;
        DateTime date = DateTime.Now;
        date = date.AddHours(9);
        date = date.AddMinutes(90);
        string todaysDate = date.ToString();
        string sql = "insert into demotime(name,localdate)values('" + name + "','" + todaysDate + "')";
        int a = cc.ExecuteNonQuery(sql);

    }

  


}

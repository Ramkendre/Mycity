using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Html_Logout : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "update [Come2myCityDB].[come2mycity].DemoOnline set status='DeActive' where userid='" + Session["User"] + "'";
        int a = cc.ExecuteNonQuery(sql);
        Session["User"] = "";
        SessionContext.Password = "";
        SessionContext.UserFirstName = "";
        Session["UserFirstNameN"] = "";
        SessionContext.UserId = "";
        SessionContext.UserLastName = "";
        Session["UserLastNameN"] = "";
        SessionContext.UserMiddleName = "";
        Session["UserMiddleName"] = "";
        SessionContext.UserMobileNo = "";
        Session["Mobile"] = "";
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();
        
        Response.Redirect("../Default.aspx");
         
        
    }
}

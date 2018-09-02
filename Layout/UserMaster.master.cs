using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout_UserMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string a = Convert.ToString(Session["examname"]);
        string b = Convert.ToString(Session["LoginId"]);
        if (Convert.ToString(Session["LoginId"]) == null || Convert.ToString(Session["LoginId"]) == "")
        {
            Response.Redirect("../UserLogin.aspx");
        }
    }
    protected void MenuItem1_MenuItemClick(object sender, MenuEventArgs e)
    {

        
        if (MenuItem1.SelectedValue.CompareTo("Practice") == 0)
            Response.Redirect("Practice.aspx");

        if (MenuItem1.SelectedValue.CompareTo("Exit") == 0)
        {
                Response.Write("index.aspx");
            
        }
       
        if (MenuItem1.SelectedValue.CompareTo("Exam") == 0)
            Response.Redirect("/Exam.aspx");
       
       
    }
    }


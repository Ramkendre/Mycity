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

public partial class html_Removegroups : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
    int status;
    protected void Page_Load(object sender, EventArgs e)
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
                try
                {

                }
                catch { }
            }
        }


    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ShowFriendList();
    }

    public void ShowFriendList()
    {
        try
        {
            string usrIdSn = Convert.ToString(Session["User"]);
            if (ddlMyFriendGroup.SelectedValue == "0")
            {


            }
            else
            {
                string FNumber = Convert.ToString(ddlMyFriendGroup.SelectedValue);
                string newsql = "SELECT usrMobileNo,usrFirstName+' '+usrLastName as usrFullName,usrAddress,usrDistrict,usrCity,usrPIN FROM FriendRelationMaster inner join UserMaster on " +
                                 " FriendRelationMaster.Friendid=UserMaster.usrUserId where userid='" + Convert.ToString(Session["User"]) + "' and  FR" + FNumber + "='" + ddlMyFriendGroup.SelectedValue + "'";
                DataSet ds = cc.ExecuteDataset(newsql);

                gvAddressBook.DataSource = ds.Tables[0];
                gvAddressBook.DataBind();
            }
        }
        catch (Exception ec)
        {

        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        try
        {
            string FNumber = Convert.ToString(ddlMyFriendGroup.SelectedValue);
            string Sql = "Delete From FriendRelationMaster where userId='" + Convert.ToString(Session["User"]) + "' and FR" + FNumber + "='" + ddlMyFriendGroup.SelectedValue + "' and FR1=1";
            int k = cc.ExecuteNonQuery(Sql);
            if (k >= 1)
            {

                ShowFriendList();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Deleted Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Not Deleted Successfully')", true);
            }
        }
        catch (Exception ex)
        { }
    }


}

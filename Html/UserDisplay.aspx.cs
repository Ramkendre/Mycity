using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Html_UserDisplay : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    public string firstName;
    public string lastName;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // ShowInitialProfile();
        }
    }
    public void ShowInitialProfile()
    {
        try
        {

            urUserRegBLLObj.usrFirstName = Convert.ToString(Session["UserFirstName"]);
            urUserRegBLLObj.usrLastName = Convert.ToString(Session["UserLastName"]);
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            firstName = urUserRegBLLObj.usrFirstName;
            lastName = urUserRegBLLObj.usrLastName;

            urUserRegBLLObj.usrCityId = Convert.ToInt32(Convert.ToString(Session["City"]));
            if (firstName != "" && lastName != "")
            {
                DataTable dtUserList = urUserRegBLLObj.BLLGetUserInitialProfile(urUserRegBLLObj);
                gvDisplayUserProfile.DataSource = dtUserList;
                gvDisplayUserProfile.DataBind();
                ViewState["UserDetail"] = dtUserList;
            }
            else if (firstName != "" && lastName == "")
            {
                DataTable dtUserList = urUserRegBLLObj.BLLGetUserInitialProfileF(urUserRegBLLObj);
                gvDisplayUserProfile.DataSource = dtUserList;
                gvDisplayUserProfile.DataBind();
                ViewState["UserDetail"] = dtUserList;
            }
            else if (firstName == "" && lastName != "")
            {
                DataTable dtUserList = urUserRegBLLObj.BLLGetUserInitialProfileL(urUserRegBLLObj);
                gvDisplayUserProfile.DataSource = dtUserList;
                gvDisplayUserProfile.DataBind();
                ViewState["UserDetail"] = dtUserList;
            }
        }
        catch (Exception ex)
        {
            // throw ex;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFirstName.Text == "" && txtLastName.Text == "")
        {
            gvDisplayUserProfile.DataSource = null;
            gvDisplayUserProfile.DataBind();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Atleast Give Few Characters of First Or/& Last Name to search')", true);
        }
        else if (txtFirstName.Text != "" && txtFirstName.Text.Length < 2)
        {
            gvDisplayUserProfile.DataSource = null;
            gvDisplayUserProfile.DataBind();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Atleast 2 Characters of First  Name to search')", true);
        }
        else if (txtLastName.Text != "" && txtLastName.Text.Length < 2)
        {
            gvDisplayUserProfile.DataSource = null;
            gvDisplayUserProfile.DataBind();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Atleast 2 Characters of  Last Name to search')", true);
        }
        else
        {
            Session["UserFirstName"] = Convert.ToString(txtFirstName.Text);
            Session["UserLastName"] = Convert.ToString(txtLastName.Text);
            ShowInitialProfile();
        }
    }
    protected void gvDisplayUserProfile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string friendid = "";
        CommonCode cc = new CommonCode();
        string recentvisited = "";
        string recentvis;
        try
        {
            if (e.CommandName == "GetAddress")
            {
                if (Convert.ToString(Session["User"]) == "")   //If User Is not logined the show the message
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Sign Up Now to Get Address.')", true);
                }
                else           //If the user is already logined 
                {
                    friendid = Convert.ToString(e.CommandArgument);
                    if (Session["ClkCnt"] == null)
                    {
                        Session["ClkCnt"] = 0;
                    }
                    Session["ClkCnt"] = (int)Session["ClkCnt"] + 1;
                    if (Convert.ToInt32(Session["ClkCnt"]) >= 5)     // If User  Clicks morethan 5 Person profile
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have reached your daily limit of 5.')", true);
                    }
                    else      //If User Clicks lessthan 5 then Show the profile
                    {
                        ////commented by R.S.(double comment)
                        string logId = Convert.ToString(Session["User"]);
                        //For maintaining recent user visited, Session doesnot contain any value
                        if (Session["crProfileVisited"] == null)  // If currProfileVisited is not there
                        {
                            try
                            {
                                string guestAddressF = friendid;
                                string sql1 = "select usrRecentVisitor from usermaster where usruserid='" + friendid + "'";
                                DataSet dset = cc.ExecuteDataset(sql1);
                                foreach (DataRow dr in dset.Tables[0].Rows)
                                {
                                    recentvisited = Convert.ToString(dr["usrRecentVisitor"]);
                                }
                                recentvisited = logId + "," + recentvisited;
                                string sql = "update usermaster set usrRecentVisitor='" + recentvisited + "' where usruserid='" + friendid + "'";
                                string query = cc.ExecuteScalar(sql);


                                DataTable dtRecentListF = urUserRegBLLObj.BLLUserRecentVisitorById(guestAddressF);
                                DataRow dRowRecentListF = dtRecentListF.Rows[0];

                                urUserRegBLLObj.usrRecentVisitor = Convert.ToString(dRowRecentListF["usrRecentVisitor"]);
                                string strecentvisitor = Convert.ToString(urUserRegBLLObj.usrRecentVisitor);
                                string[] recentvisitor = strecentvisitor.Split(',');

                                if (recentvisitor[0] != "")
                                {
                                    string a = recentvisitor[0];
                                    urUserRegBLLObj.usrRecentVisitor1 = a;
                                }
                                else if (recentvisitor[1] != "")
                                {
                                    string b = recentvisitor[1];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + b;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");
                                }
                                else if (recentvisitor[2] != "")
                                {
                                    string c = recentvisitor[2];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + c;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[3] != "")
                                {
                                    string d = recentvisitor[3];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + d;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[4] != "")
                                {
                                    string ee = recentvisitor[4];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + ee;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[5] != "")
                                {
                                    string f = recentvisitor[5];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + f;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[6] != "")
                                {
                                    string g = recentvisitor[6];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + g;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[7] != "")
                                {
                                    string h = recentvisitor[7];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + h;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[8] != "")
                                {
                                    string i = recentvisitor[8];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + i;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else { Response.Write("<script>(alert)('You Not Updated')</script>"); }
                            }
                            catch (Exception ex)
                            {
                            }
                        }


                        Response.Redirect("ViewAddress.aspx?uid=" + friendid);


                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void gvDisplayUserProfile_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDisplayUserProfile.PageIndex = e.NewPageIndex;
        DataTable dtShowUserDetails = (DataTable)ViewState["UserDetail"];
        gvDisplayUserProfile.DataSource = dtShowUserDetails;
        gvDisplayUserProfile.DataBind();
    }

    protected void btnSearchMbl_Click(object sender, EventArgs e)
    {
        if (txtMobileNumber.Text == "")
        {
        }
        else
        {
            string Sql = "select usrUserId,usrFirstName+' '+usrLastName as FullName ,usrMobileNo from UserMaster where usrMobileNo='" + txtMobileNumber.Text + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvMobileNo.DataSource = ds.Tables[0];
            gvMobileNo.DataBind();

        }
    }
    protected void gvMobileNo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string friendid = "";
        CommonCode cc = new CommonCode();
        string recentvisited = "";
        string recentvis;
        try
        {
            if (e.CommandName == "GetAddress")
            {
                if (Convert.ToString(Session["User"]) == "")   //If User Is not logined the show the message
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Sign Up Now to Get Address.')", true);
                }
                else           //If the user is already logined 
                {
                    friendid = Convert.ToString(e.CommandArgument);
                    if (Session["ClkCnt"] == null)
                    {
                        Session["ClkCnt"] = 0;
                    }
                    Session["ClkCnt"] = (int)Session["ClkCnt"] + 1;
                    if (Convert.ToInt32(Session["ClkCnt"]) >= 5)     // If User  Clicks morethan 5 Person profile
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You have reached your daily limit of 5.')", true);
                    }
                    else      //If User Clicks lessthan 5 then Show the profile
                    {
                        ////commented by R.S.(double comment)
                        string logId = Convert.ToString(Session["User"]);
                        //For maintaining recent user visited, Session doesnot contain any value
                        if (Session["crProfileVisited"] == null)  // If currProfileVisited is not there
                        {
                            try
                            {
                                string guestAddressF = friendid;
                                string sql1 = "select usrRecentVisitor from usermaster where usruserid='" + friendid + "'";
                                DataSet dset = cc.ExecuteDataset(sql1);
                                foreach (DataRow dr in dset.Tables[0].Rows)
                                {
                                    recentvisited = Convert.ToString(dr["usrRecentVisitor"]);
                                }
                                recentvisited = logId + "," + recentvisited;
                                string sql = "update usermaster set usrRecentVisitor='" + recentvisited + "' where usruserid='" + friendid + "'";
                                string query = cc.ExecuteScalar(sql);


                                DataTable dtRecentListF = urUserRegBLLObj.BLLUserRecentVisitorById(guestAddressF);
                                DataRow dRowRecentListF = dtRecentListF.Rows[0];

                                urUserRegBLLObj.usrRecentVisitor = Convert.ToString(dRowRecentListF["usrRecentVisitor"]);
                                string strecentvisitor = Convert.ToString(urUserRegBLLObj.usrRecentVisitor);
                                string[] recentvisitor = strecentvisitor.Split(',');

                                if (recentvisitor[0] != "")
                                {
                                    string a = recentvisitor[0];
                                    urUserRegBLLObj.usrRecentVisitor1 = a;
                                }
                                else if (recentvisitor[1] != "")
                                {
                                    string b = recentvisitor[1];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + b;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");
                                }
                                else if (recentvisitor[2] != "")
                                {
                                    string c = recentvisitor[2];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + c;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[3] != "")
                                {
                                    string d = recentvisitor[3];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + d;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[4] != "")
                                {
                                    string ee = recentvisitor[4];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + ee;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[5] != "")
                                {
                                    string f = recentvisitor[5];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + f;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[6] != "")
                                {
                                    string g = recentvisitor[6];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + g;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[7] != "")
                                {
                                    string h = recentvisitor[7];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + h;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else if (recentvisitor[8] != "")
                                {
                                    string i = recentvisitor[8];
                                    urUserRegBLLObj.usrRecentVisitor1 = urUserRegBLLObj.usrRecentVisitor1 + "," + i;
                                    Response.Write("<script>(alert)('You Updated as Recent Visitor')</script>");

                                }
                                else { Response.Write("<script>(alert)('You Not Updated')</script>"); }
                            }
                            catch (Exception ex)
                            {
                            }
                        }


                        Response.Redirect("ViewAddress.aspx?uid=" + friendid);


                    }
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

}

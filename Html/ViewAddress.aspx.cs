using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_ViewAddress : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
   
    public int status;
    public string showMobile;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                
                string userId = Convert.ToString(Request.QueryString["uId"]);
                if (userId != " " && userId != null)
                {
                    ShowContact(userId);
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("../Default.aspx");
            }

        }
    }

    public void ShowContact(string userid)
    {
        try
        {
            urUserRegBLLObj.usrUserId = userid;
            ds = urUserRegBLLObj.BLLGetUserContactInfo(urUserRegBLLObj);

            gvContactDisplay.DataSource = ds.Tables[0];
            gvContactDisplay.DataBind();

            
            showMobile = Convert.ToString(ds.Tables[0].Rows[0]["usrControlMobileNo"]);


        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }

    public int CheckForProfileView()
    {
        try
        {
            urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["user"]);
            string userId = Convert.ToString(Request.QueryString["uId"]);
            urUserRegBLLObj.frnrelFriendId = userId;
            status = urUserRegBLLObj.BLLFriendRelativeIsViewProfile(urUserRegBLLObj);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return status;
    }



    protected void lnbViewProfile_Click(object sender, EventArgs e)
    {
        int showProfile = CheckForProfileView();
        if (showProfile > 0)
        {
            Response.Redirect("~/UI/ViewUserProfile.aspx");
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../html/UserDisplay.aspx");
    }
}

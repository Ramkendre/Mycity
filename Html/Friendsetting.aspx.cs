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

public partial class html_Friendsetting : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    ChangePwdInOnlineExam.ChangePassword onlineexam = new ChangePwdInOnlineExam.ChangePassword();
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
                    if (!IsPostBack)
                    {
                        gvFriendShow1();
                    }
                }
                catch (Exception ex)
                { }
            }
        }
    }
    protected void btnSearchRel_Click(object sender, EventArgs e)
    {
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        urUserRegBLLObj.usrFirstName = Convert.ToString(txtFName.Text);
        urUserRegBLLObj.usrLastName = Convert.ToString(txtLName.Text);
        urUserRegBLLObj.usrMobileNo = Convert.ToString(txtMobileNo.Text);
        DataSet dtFriendRelList = urUserRegBLLObj.DalFienSearchFriend(urUserRegBLLObj);
        gvRemoveFriend.DataSource = dtFriendRelList;
        gvRemoveFriend.DataBind();
        ViewState["RemoveFriend"] = dtFriendRelList;
    }
    protected void gvRemoveFriend_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        if (e.CommandName == "Remove")
        {

            urUserRegBLLObj.frnrelFriendId = Convert.ToString(e.CommandArgument);
            urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);

            status = urUserRegBLLObj.BLLUserFriendRelativeRemove(urUserRegBLLObj);

            if (status == 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Removed')", true);
                urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
                DataSet dtFriendRelList = urUserRegBLLObj.BLLFriendRelativeShowById(urUserRegBLLObj);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Not Removed')", true);
            }

            gvFriendShow1();


        }
        else if (e.CommandName == "Edit")
        {
            string Id = Convert.ToString(e.CommandArgument);

            if (Convert.ToString(e.CommandName) == "Edit")
            {
                Response.Redirect("FriendRelativeupdate.aspx?Id=" + Id);
            }
        }
       


    }

    protected void gvRemoveFriend_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRemoveFriend.PageIndex = e.NewPageIndex;
       
        gvFriendShow1();
    }

    private void gvFriendShow1()
    {
        urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
        //string sql = "select FriRelId,Relation from FriendRelationMaster where userid='" + urUserRegBLLObj.usrUserId + "'";
        string sql = "select usrFirstName+'  '+usrLastname as name, relation,FriRelId from " +
                    "FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId  " +
                    "where userid='" + urUserRegBLLObj.usrUserId + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        gvRemoveFriend.DataSource = ds.Tables[0];
        gvRemoveFriend.DataBind();

    }
    protected void gvRemoveFriend_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_ChangeType : System.Web.UI.Page
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtMobileNo.Text != "")
        {
            string Sql="Select UsrUserId from UserMaster where usrMobileNo='"+txtMobileNo.Text.ToString()+"'";
            string UserId = Convert.ToString(cc.ExecuteScalar(Sql));
            if (UserId == "")
            {
                lblError.Text = "This Mobile no is not exist";
                lblError.Visible = true;
                ViewState["User"]="";
            }
            else
            {
                ShowContact(UserId);
                lblError.Visible = false;
                ViewState["User"]=UserId;
            }
        }
    }
    protected void btnUser_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["User"]) == "")
        {
            lblError.Text = "This Mobile no is not exist";
            lblError.Visible = true;
        }
        else
        {
            string Sql = "Update UserMaster set IsMarketingPerson='N' where UsrUserId='" + Convert.ToString(ViewState["User"]) + "'";
            int i = cc.ExecuteNonQuery(Sql);
            if (i > 0)
            {
                lblError.Text = "This user is now normal User.";
                lblError.Visible = true;
            }
            else
            {

                lblError.Text = "Cant update Record";
                lblError.Visible = true;
            }
        }
    }
    protected void btnMarketing_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(ViewState["User"]) == "")
        {
            lblError.Text = "This Mobile no is not exist";
            lblError.Visible = true;
        }
        else
        {
            string Sql = "Update UserMaster set IsMarketingPerson='Y' where UsrUserId='" + Convert.ToString(ViewState["User"]) + "'";
            int i = cc.ExecuteNonQuery(Sql);
            if (i > 0)
            {
                lblError.Text = "This user is now marketing Person.";
                lblError.Visible = true;
            }
            else
            {

                lblError.Text = "Cant update Record";
                lblError.Visible = true;
            }
        }
    }
}

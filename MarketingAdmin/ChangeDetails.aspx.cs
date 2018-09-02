using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Admin_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtLoginId.Enabled = false;
        if (!IsPostBack)
        {
            //getDetails(); 
        }
        this.Set_Page_Level_Setting();
    }
    protected void Set_Page_Level_Setting()
    {
        //set page heading
        Label lblMainHeading = (Label)Master.FindControl("lblMainHeading");
        if (lblMainHeading != null)
            lblMainHeading.Text = "Update your Details";

     }

    private void getDetails()
    {
        UserBLL user=new UserBLL();
        user.LoginId=Convert.ToString(Session["LoginId"]);
        DataSet ds = user.GetUserDetails(user);
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                CommonCode cc = new CommonCode();
                txtLoginId.Text=Convert.ToString(ds.Tables[0].Rows[0]["LoginId"]);
                txtUserName.Text = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                txtPassword.Text = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["Password"]));
                txtRePassword.Text = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["Password"]));
                txtContactNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ContactNo"]);
                txtAddress.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        UserBLL user = new UserBLL();
        user.LoginId = Convert.ToString(Session["LoginId"]);
        if (txtUserName.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Enter user Name.')", true);
            
        }
        else if (txtPassword.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password should not be blank.')", true);
            
        }
        else if (txtPassword.Text != txtRePassword.Text)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Both Password should be same.')", true);

        }
        else
        {
            try
            {
                CommonCode cc = new CommonCode();
                user.UserName = txtUserName.Text.ToString();
                user.Password = cc.DESEncrypt(txtPassword.Text.ToString());
                user.ContactNo = txtContactNo.Text.ToString();
                user.Address = txtAddress.Text.ToString();
                user.Role = 0;
                user.CompanyId = 0;
                user.DOJ = Convert.ToDateTime("01-Apr-2011");
                int status = user.UpdateOwnDetails(user);
                if (status == 1)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Updated Successfully.')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User  Updated Successfully.')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User  Updated Successfully.')", true);
            }
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/Home.aspx");
    }
}

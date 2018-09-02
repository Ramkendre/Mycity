using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UI_PasswordRecover : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CityBLL cityBLLObj = new CityBLL();
    CommonCode cc = new CommonCode();
    int status;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { }

    }

    protected void btnPasswordRecover_Click(object sender, EventArgs e)
    {
        bool flagCheck = RecoverMyPassword();
        if (flagCheck == true)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Check your mobile for password')", true);
            Response.Redirect("UserRegistration.aspx");
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile No. Not Registered with Us.')", true);
        }
    }

    public bool RecoverMyPassword()
    {
        bool flag = false;
        try
        {
            DataTable dtUserInfoList;
            string mobileNo = txtFPMobileNo.Text;
            urUserRegBLLObj.BLLUserPasswordRecovery(mobileNo, out dtUserInfoList, out status);

            if (status == 0)
            {
                flag = false;
            }
            else
            {
                DataTable dtUserSMSInfoList = dtUserInfoList;
                DataRow dRowUserInfo = dtUserSMSInfoList.Rows[0];
                string myMobileNo = Convert.ToString(dRowUserInfo["usrMobileNo"]);
                string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfo["usrPassword"]));
                string myName = Convert.ToString(dRowUserInfo["usrFullName"]);

                string sendFrom = "Recovery SMS";
                string passwordMessage = "Dear " + myName + ", Your Password For Login is :: " + myPassword + " Thanks Via www.myct.in ";
                int smslength = passwordMessage.Length;
                bool flagmessage1 = cc.TransactionalSMSCountry(sendFrom, myMobileNo, passwordMessage, smslength, 18);

                if (flagmessage1 == true)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password sent Successfully...Password will be devlivered shortly on your registered Mobile No.')", true);
                }
                flag = true;
                txtFPMobileNo.Text = "";
            }
        }
        catch (Exception ex)
        {

        }
        return flag;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

public partial class html_Changepass : System.Web.UI.Page
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

                     }
                 }
                 catch(Exception ex)
                 {}
             }
         }

    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        ChangePassword();
    }

    public void ChangePassword()
    {

        bool flag = false;
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(txtOldPasswod.Text);
            urUserRegBLLObj.usrChangePassword = cc.DESEncrypt(txtConfirmNewPassword.Text);

            status = urUserRegBLLObj.BLLUserRegistrationChangePassword(urUserRegBLLObj);
            if (status > 0)
            {

                List<UserRegistrationBLL> usrInfoList = new List<UserRegistrationBLL>();
                DataTable dtUserInfoList = urUserRegBLLObj.BLLGetUserDetails(urUserRegBLLObj);
                DataRow dRowUserInfoList = dtUserInfoList.Rows[0];

                //string myMobileNo = "91" + Convert.ToString(dRowUserInfoList["usrMobileNo"]);

                string myMobileNo = Convert.ToString(dRowUserInfoList["usrMobileNo"]);
                string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfoList["usrPassword"]));
                string myName = Convert.ToString(dRowUserInfoList["usrFirstName"]);

                // string mPassword = cc.DESDecrypt(urUserRegBLLObj.usrChangePassword);
                int result = onlineexam.UpdatePwd(myMobileNo, Convert.ToString(dRowUserInfoList["usrPassword"]));
                string sendFrom = "COM2MYCT";

                string passwordMessage = "Dear " + myName + ",Your a/c password changed for New Password is: " + myPassword + " " + cc.AddSMS(myMobileNo);


                //  ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password  changed')", true);
                //string msg = "Your New Password is: " + cc.DESDecrypt(urUserRegBLLObj.usrChangePassword);
                flag = cc.SendMessageImp1(sendFrom, myMobileNo, passwordMessage);
                flag = cc.SendMessage1(sendFrom, myMobileNo, passwordMessage);

                if (flag == true)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Changed Successfully...Password will be devlivered shortly on your registered Mobile No.')", true);
                    // System.Windows.Forms.MessageBox.Show("Password Changed Successfully...Password will be devlivered shortly on your registered Mobile No.", "Come2MyCity");
                    // Response.Redirect("MyProfile.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Changed Successfully...Password will be devlivered shortly on your registered Mobile No.')", true);
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Changed Successfully But Message is not sent')", true);
                    // System.Windows.Forms.MessageBox.Show("Password Changed Successfully But Message is not sent", "Come2MyCity");
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Not changed')", true);
                // System.Windows.Forms.MessageBox.Show("Password Not changed", "Come2MyCity");
            }
        }
        catch (Exception ex)
        {
            //throw ex;
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Password Not changed')", true);
    }
}

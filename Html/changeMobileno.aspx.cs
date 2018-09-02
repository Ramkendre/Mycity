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

public partial class html_changeMobileno : System.Web.UI.Page
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
                        lblRegisteredMobileNo.Text = Convert.ToString(Session["Mobile"]);
                    }
                }
                catch (Exception ex)
                { }
            }
        }
    }

    protected void btnNewMobileNoRegister_Click(object sender, EventArgs e)
    {
        ChangeRegisteredMobileNo();
        txtNewMobileNo.Text = "";

    }
    public void ChangeRegisteredMobileNo()
    {
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            urUserRegBLLObj.usrMobileNo = txtNewMobileNo.Text;
            Random rnd = new Random();
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
            string MobileNo = Convert.ToString(txtNewMobileNo.Text);
            if (MobileNo.Length == 10)
            {
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);

                if (status == 0)
                {
                    txtNewMobileNo.Text = "";
                    txtNewMobileNo.Focus();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Given New Mobile Number already registered in come2mycity.com')", true);

                    // System.Windows.Forms.MessageBox.Show("Given New Mobile Number already registered in come2mycity.com", "Come2MyCity");
                }
                else
                {
                    status = urUserRegBLLObj.BLLUserRegisteredMobileNoUpdate(urUserRegBLLObj);
                    Response.Write("<script>alert('Mobile number Changed.Login Again')</script>");
                    if (status > 0)
                    {

                        string senderId = "COM2MYCT";
                        //string myMobileNo = "91" + urUserRegBLLObj.usrMobileNo;
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = Convert.ToString(Session["userName"]);
                        string passwordMessage = "Dear " + myName + ",Password for ur Login with your New Registered Mobile No is:" + myPassword + " " + cc.AddSMS(myMobileNo);

                        cc.SendMessage1(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageImp1(senderId, myMobileNo, passwordMessage);
                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile number Changed.Login Again')", true);
                        Response.Write("<script>alert('Mobile number Changed.Login Again')</script>");
                        // System.Windows.Forms.MessageBox.Show("Mobile number Changed Successfully.Login Again", "Come2MyCity");
                        Response.Redirect("Logout.aspx");
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Mobile number Not changed.')", true);
                        Response.Write("<script>alert('Mobile number Not changed.')</script>");
                        // System.Windows.Forms.MessageBox.Show("Mobile number Not changed.Please try again", "Come2MyCity");
                        txtNewMobileNo.Text = "";

                    }
                }
            }
            else
            {
                Response.Write("<script>alert('please Enter the 10 Disit mobile No..!')</script>");
            }
        }
        catch (Exception ex)
        {
            // throw ex;
        }
    }

}

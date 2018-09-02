using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

public partial class Html_UserRegistration : System.Web.UI.Page
{
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    CityBLL cityBLLObj = new CityBLL();
    CommonCode cc = new CommonCode();
    int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["City"]) == "0")
            {
                Session["City"] = 37;
            }
            cityBLLObj.cityId = Convert.ToInt32(Session["City"]);
            if (Convert.ToString(Request.QueryString["F"]) == "L")
            {
                acdLogin.SelectedIndex = 1;

            }
        }
    }
    private void ImageSave()
    {
        img.ImageUrl = "../images/Administrator Login Panel.jpg";
        string sql = "insert into storeimage(image)values('" + img.ImageUrl + "')";
        int a = cc.ExecuteNonQuery(sql);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (chkAcceptTermCond.Checked == true)
        {
            UserRegistrationIntial();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Accept the Term & Condition ')", true);
        }
    }
    public void UserRegistrationIntial()
    {
        try
        {
            if (txtFirstName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Frist Name..!')", true);
            }
            else if (txtLastName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Last Name..!')", true);
            }
            else if (txtMobileNumber.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter the Mobile No..!')", true);
            }
            else
            {
                urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                urUserRegBLLObj.usrMobileNo = Convert.ToString(txtMobileNumber.Text);
                urUserRegBLLObj.usrAddress = Convert.ToString(txtAddress.Text);
                urUserRegBLLObj.usrFirstName = Convert.ToString(txtFirstName.Text);
                urUserRegBLLObj.usrLastName = Convert.ToString(txtLastName.Text);
                urUserRegBLLObj.usrStateId = Convert.ToInt32(Session["State"]);
                urUserRegBLLObj.usrDistrictId = Convert.ToInt32(Session["District"]);
                urUserRegBLLObj.usrCityId = Convert.ToInt32(Session["City"]);
                urUserRegBLLObj.usrGender = Convert.ToString(rdoGender.SelectedValue);
                urUserRegBLLObj.frnrelGroup = "1";
                cityBLLObj.cityId = Convert.ToInt32(Session["City"]);
                //For Createing Password & Encrypting it

                Random rnd = new Random();
                urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);

                if (status == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User already Exists')", true);
                }
                else
                {
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);

                    if (status > 0)
                    {
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;

                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        int smslength = passwordMessage.Length;
                        cc.TransactionalSMSCountry("Website", myMobileNo, passwordMessage, smslength, 7);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Registration is Successful.Your Password will be delivered shortly on your mobile. Use it to Sign In your account.')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Registration UnSuccessful')", true);
                    }
                }
                ClearAll();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        Autenticateuser();
    }
    public void Autenticateuser()
    {
        try
        {
            DataSet ds = cc.getLoginDetails(txtUserIdentity.Text.ToString(), cc.DESEncrypt(txtPassword.Text.ToString()));

            if (ds.Tables[0].Rows.Count > 0)
            {
                SessionContext.UserId = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                SessionContext.Password = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["Password"]));
                SessionContext.UserMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                SessionContext.UserFirstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                SessionContext.UserMiddleName = Convert.ToString(ds.Tables[0].Rows[0]["MiddleName"]);
                SessionContext.UserLastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                SessionContext.CityId = Convert.ToString(ds.Tables[0].Rows[0]["CityId"]);
                SessionContext.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
                SessionContext.DistrictId = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);
                SessionContext.DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
                SessionContext.StateId = Convert.ToString(ds.Tables[0].Rows[0]["StateId"]);
                SessionContext.StateName = Convert.ToString(ds.Tables[0].Rows[0]["StateName"]);
                Session["User"] = SessionContext.UserId;
                Session["City"] = SessionContext.CityId; /// Changes done by pooja
                Session["Mobile"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                Session["UserFirstNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                Session["UserLastNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                Response.Redirect("../html/HomePage.aspx", false);  /// Changes done by Pooja
            }
            else
            {
                //lblMsg.Text = "Invalid User";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            //lblMsg.Text = "Invalid User";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);
        }
    }
    public void ClearAll()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMobileNumber.Text = "";
        txtAddress.Text = "";
        txtUserIdentity.Text = "";
        txtPassword.Text = "";
    }
    protected void lnkForgorPassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("../html/PasswordRecover.aspx");
    }
}

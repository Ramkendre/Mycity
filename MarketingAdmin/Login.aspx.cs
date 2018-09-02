using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using Microsoft.ApplicationBlocks.Data;

using System.Web.UI;
using System.Web.UI.WebControls;

using System.Windows.Forms;

public partial class MarketingAdmin_Login : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtUserId.Focus();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

        }
    }
    protected void Login_Click(object sender, EventArgs e)
    {

    }
   

    public void Autenticateuser()
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        CommonCode cc = new CommonCode();
        try
        {
            Session["MobileNumber"] = txtUserId.Text;
            ds = cc.getLoginDetails(txtUserId.Text.ToString(), cc.DESEncrypt(txtPassword.Text.ToString()));

            if (Convert.ToString(ds.Tables[0].Rows[0]["IsMarketingPerson"]) == "y" || Convert.ToString(ds.Tables[0].Rows[0]["IsMarketingPerson"]) == "Y")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    SessionContext.UserId = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                    string uid = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                    string sqlfullname = "select usrFirstName+''+usrLastName as FullName from usermaster where usrUserid='" + uid + "'";
                    string FullName = cc.ExecuteScalar(sqlfullname);
                    string sqlcheck = "select MID from MartketingSubuser where Uid1='" + uid + "'";
                    string id = cc.ExecuteScalar(sqlcheck);
                    if (id == "" || id == null)
                    {
                        string sqlexe = "select id from AdminSubMarketingSubUser where friendid='" + uid + "'";
                        string iduser = cc.ExecuteScalar(sqlexe);
                        if (iduser != "")
                        {
                            string sql12 = "select rolename from AdminSubMarketingSubUser where id='" + iduser + "' ";
                            string rolename = cc.ExecuteScalar(sql12);
                            string sql121 = "select RoleName from SubMenuPermission where RoleName='" + rolename + "'";
                            string RoleName = cc.ExecuteScalar(sql121);
                            Session["RoleName"] = RoleName;
                            SessionContext.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);

                            Session["MarketingUser"] = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                            Session["UserFirstNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);

                            Session["UserLastNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);

                            Session["Name"] = FullName;

                            Response.Redirect("../MarketingAdmin/Home.aspx");

                        }
                        else
                        {
                            //Response.Write("<script>alert('You are not member of myctin')</script>");
                        }
                    }
                    else
                    {
                        string sql = "select UseRole from MartketingSubuser where Uid1='" + uid + "'";
                        string Role = cc.ExecuteScalar(sql);
                        string sql1 = "select RoleName from SubMenuPermission where RoleName='" + Role + "'";
                        string RoleName1 = cc.ExecuteScalar(sql1);
                        Session["RoleName"] = RoleName1;

                        SessionContext.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);

                        Session["MarketingUser"] = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                        Session["UserFirstNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);

                        Session["UserLastNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);

                        Session["Name"] = FullName;

                        Response.Redirect("../MarketingAdmin/Home.aspx");
                    }
                }
                else
                {
                    lblMsg.Text = "Invalid User credential";
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('User Name or Password is Incorrect...Please try again')", true);



                }
            }
            else
            {
                lblMsg.Text = "Invalid User credential";
                Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('You Have  Not A Marketing Person')", true);



            }

        }
        catch (Exception ex)
        {
            string m = ex.Message;
            lblMsg.Text = "Invalid User credential";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('You Have  Not A Marketing Person')", true);

        }
    }
    private void Autenticateuser1()
    {
        string Sql = "Select * from MarketingUser1 where UserId='" + txtUserId.Text.ToString() + "' and Password='" + txtPassword.Text.ToString() + "'";
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["RoleName"] = "Administrator";
                    SessionContext.UserId = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                    SessionContext.Password = Convert.ToString(ds.Tables[0].Rows[0]["Password"]);
                    SessionContext.UserMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                    SessionContext.UserFirstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    SessionContext.UserMiddleName = Convert.ToString(ds.Tables[0].Rows[0]["MiddleName"]);
                    SessionContext.UserLastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);

                    SessionContext.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
                    Session["MarketingUser"] = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                    Session["UserFirstNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
                    Session["UserMiddleName"] = Convert.ToString(ds.Tables[0].Rows[0]["MiddleName"]);
                    Session["UserLastNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                    Session["CityNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
                    Session["Mobile"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);

                    Session["Role"] = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
                    Session["RoleId"] = Convert.ToString(ds.Tables[0].Rows[0]["RoleId"]);
                    Session["Name"] = Session["UserFirstNameN"] + " " + Session["UserMiddleName"] + " " + Session["UserLastNameN"];
                    Response.Redirect("../MarketingAdmin/Home.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('User Name or Password is Incorrect...Please try again')", true);




                }

            }

            catch (SqlException ex)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "alert('User Name or Password is Incorrect...Please try again')", true);
                lblMsg.Text = "Invalid User credential";
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void Reset_Click(object sender, EventArgs e)
    {

    }
    protected void Login_Click1(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        try
        {

            if (txtPassword.Text == "ezeesoftindia.com" && txtUserId.Text == "Admin")
            {
                Autenticateuser1();

            }
            //else
            {

                Autenticateuser();
                //Response.Redirect("../DemoHome.aspx");

            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnReset_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        txtPassword.Text = "";
        txtUserId.Text = "";
        lblMsg.Text = "";
    }
}

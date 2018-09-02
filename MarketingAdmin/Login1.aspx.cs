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
using System.Data.SqlClient;

public partial class MarketingAdmin_Login1 : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {

        //string s = cc.DESDecrypt("f+KJn7vqbMk=");// 89226 - 9421904574

        //string ss = cc.DESDecrypt("9Y7Wi+LuePA=");// 88526 - 9422937796

        //string sss = cc.DESDecrypt("axZ+DB4y/Mo=");// 26177 - 9403155083  local hm 

        //  string sujata = cc.DESDecrypt("cMR+3CYmVlg="); // server clustere head 53434-9403444421 


        //  string gf = cc.DESDecrypt("VeKHpxjP4js=");  // local head master  68562-9545467433   scode- 27180110301

        // string hg = cc.DESDecrypt("vWjytIRtu3E=");   // server head master 72657- 9545467433-   scode-27180110301

        // string j = cc.DESDecrypt("SbSvQFXTvdo=");   // server head master 56592- 9423447406

        string h = cc.DESDecrypt("uNXKL7/JloQ=");   // sever 2nd EO 47971- 8087321575
        // string j = cc.DESDecrypt("oX2dbE3iwRw=");   // local hm 64936= 9766306701

        // string j = cc.DESDecrypt("1HqdrhQgKzM=");// local Hm 8087321888  // 39798

        //  string f = cc.DESDecrypt("oX2dbE3iwRw=");//    9766306701  // 64936 hm local

        //  string f = cc.DESDecrypt("blNg2RxvBHE=");//    9421664923  // 55561 hm server

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
                    //string sqlfullname = "select usrFirstName+''+usrLastName as FullName from usermaster where usrUserid='" + uid + "'";
                    //string FullName = cc.ExecuteScalar(sqlfullname);
                    string FullName = Convert.ToString(ds.Tables[0].Rows[0]["FullName"]);
                    string sqlcheck = "select MID from [Come2myCityDB].[come2mycity].[MartketingSubuser] where Uid1='" + uid + "'";
                    // DataSet dd=cc.ExecuteDataset(sqlcheck);

                    string id = cc.ExecuteScalar(sqlcheck);
                    //string roleid=Convert.ToString(dd.Tables[0].Rows[0]["RoeId"]);
                    if (id == "" || id == null)
                    {
                        string sqlexe = "select roleid from [Come2myCityDB].[come2mycity].[AdminSubMarketingSubUser] where friendid='" + uid + "' and  mainrole=1 ";
                        string roleid = cc.ExecuteScalar(sqlexe);
                        if (roleid != "") 
                        {
                            //string sql12 = "select roleid from AdminSubMarketingSubUser where id='" + iduser + "' ";
                            //string roleid = cc.ExecuteScalar(sql12);
                            //string sql121 = "select roleid from SubMenuPermission where RoleName='" + rolename + "'";
                            //string roleid = cc.ExecuteScalar(sql121);
                            Session["RoleId"] = roleid;
                            //Session["RoleName"] = rolename;
                            SessionContext.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);

                            Session["MarketingUser"] = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                            string s8 = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                            Session["UserFirstNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);

                            Session["UserLastNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);

                            Session["Name"] = FullName;

                            Response.Redirect("../MarketingAdmin/Home.aspx");

                        }
                        else
                        {
                            Response.Write("<script>alert('You are not member of myctin')</script>");
                        }
                    }

                    else
                    {
                        string sql = "select RoeId from [Come2myCityDB].[come2mycity].[MartketingSubuser] where Uid1='" + uid + "'";
                        string Role = cc.ExecuteScalar(sql);
                        // string sql1 = "select RoleName from SubMenuPermission where RoleName='" + Role + "'";
                        // string RoleName1 = cc.ExecuteScalar(sql1);
                        Session["RoleId"] = Role;
                        string sql121 = "select RoleName from [Come2myCityDB].[come2mycity].[SubMenuPermission] where roleid='" + Role + "'";
                        string RoleName = cc.ExecuteScalar(sql121);
                        Session["RoleName"] = RoleName;
                        SessionContext.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);

                        Session["MarketingUser"] = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
                        Session["UserFirstNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);

                        Session["UserLastNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);

                        Session["Name"] = FullName;

                        Response.Redirect("~/MarketingAdmin/Home.aspx", false);
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
        string Sql = "Select * from [Come2myCityDB].[come2mycity].[MarketingUser1] where UserId='" + txtUserId.Text.ToString() + "' and Password='" + txtPassword.Text.ToString() + "'";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString()))
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
                    Session["MobileNumber"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
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
            // string DDD = cc.DESDecrypt(txtPassword.Text);
            if ((txtPassword.Text == "abhinavitsoft@011" || txtPassword.Text == "abh15-16@myct" && txtUserId.Text == "Admin"))
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

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;

public partial class Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();
    CTdll.PCommon pc = new CTdll.PCommon();
    CTdll.SessionContext sc = new CTdll.SessionContext();

    string ipAddress, hostName = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //regular
        sc = (CTdll.SessionContext)Session["SC"];
        if (!IsPostBack)
        {
            GetCityDetails();
            ipAddress = IpAddress();
            hostName = Dns.GetHostName();
            Addvisitor();
        }

    }

    private void GetCityDetails()
    {
        try
        {
            ds = (DataSet)Session["Location"];
            if (ds == null)
            {
                Location loc = new Location();
               // ds = loc.getAllLocation();
                ds = loc.GetAllLocation();
                Session["Location"] = ds;
            }
            if (ds.Tables[0] != null)
            {
                ddlState.DataSource = ds.Tables[0];
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Add("--Select--");
                ddlState.Items[ddlState.Items.Count - 1].Value = " ";
                ddlDistrict.Items.Add("--Select--");
                ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
                ddlCity.Items.Add("--Select--");
                ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";

                ddlState.SelectedIndex = ddlState.Items.Count - 1;
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = (DataSet)Session["Location"];
            if (ddlState.SelectedIndex != ddlState.Items.Count - 1)
            {
                if (ds.Tables[1] != null)
                {
                    DataRow[] dr = ds.Tables[1].Select("StateId=" + ddlState.SelectedValue.ToString() + "");
                    ddlDistrict.DataSource = pc.getDataTableFromDataRow(dr);// getDataTable(dr);
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "DistrictId";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Add("--Select--");
                    ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
                }
            }
            else
            {
                ddlCity.Items.Clear();
                ddlDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = (DataSet)Session["Location"];
            if (ddlDistrict.SelectedIndex != ddlState.Items.Count - 1)
            {
                if (ds.Tables[2] != null)
                {
                    DataRow[] dr = ds.Tables[2].Select("DistrictId=" + ddlDistrict.SelectedValue.ToString() + "");
                    ddlCity.DataSource = pc.getDataTableFromDataRow(dr); //getDataTable(dr);
                    ddlCity.DataTextField = "CityName";
                    ddlCity.DataValueField = "CityId";
                    ddlCity.DataBind();
                    ddlCity.Items.Add("--Select--");
                    ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";
                    ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
                }
            }
            else
            {
                ddlCity.Items.Clear();

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            SessionContext.CityId = Convert.ToString(ddlCity.SelectedValue);
            SessionContext.CityName = Convert.ToString(ddlCity.SelectedItem.Text);
            SessionContext.DistrictId = Convert.ToString(ddlDistrict.SelectedValue);
            SessionContext.DistrictName = Convert.ToString(ddlDistrict.SelectedItem.Text);
            SessionContext.StateId = Convert.ToString(ddlState.SelectedValue);
            SessionContext.StateName = Convert.ToString(ddlState.SelectedItem.Text);
            Session["City"] = SessionContext.CityId;
            Session["CityNameN"] = Convert.ToString(ddlCity.SelectedItem.Text);
            //sc.CityId = Convert.ToString(ddlCity.SelectedValue);
            //sc.CityName = Convert.ToString(ddlCity.SelectedItem.Text);
            Session["SC"] = sc;
            Response.Redirect("html/CityInfoPage.aspx", false); ///Changes done by Pooja
        }
        catch (Exception ex)
        {
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        try
        {
            Autenticateuser();
        }
        catch (Exception ex)
        {
        }
    }

    public void Autenticateuser()
    {
        try
        {
            // ds = cc.getLoginDetails(txtUserId.Text.ToString(), cc.DESEncrypt(txtPassword.Text.ToString()));
            CTdll.UserLogin ul = new CTdll.UserLogin();
            sc = ul.getLoggedIn(txtUserId.Text.ToString(), cc.DESEncrypt(txtPassword.Text.ToString()), ConfigurationManager.AppSettings["ConnectionString"], "Login");
            Session["SC"] = sc;
            if (sc != null)
            {
                if (txtUserId.Text.Length == 10)
                {
                    Session["User"] = Convert.ToString(sc.UserId);
                    //Session["MobileNoN"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                    Session["UserFirstNameN"] = Convert.ToString(sc.UserFName);
                    Session["UserLastNameN"] = Convert.ToString(sc.UserLName);
                    Session["UserMiddleName"] = Convert.ToString(sc.UserMName);
                    Session["CityNameN"] = Convert.ToString(sc.CityName);
                    Session["City"] = Convert.ToString(sc.CityId);
                    Session["Mobile"] = Convert.ToString(sc.Mobile);
                    Session["lastLogin"] = Convert.ToString(sc.LastLogin);
                    Session["MobileNo"] = txtUserId.Text.ToString();
                    if (Convert.ToString(sc.UserId).Trim() == "")
                    {
                        lblMsg.Text = "Invalid User";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect ...Please try again')", true);
                    }
                    else
                    {
                        string sql = "select id from [DBCome2myct].[come2mycity].[DemoOnline] where userid='" + sc.UserId + "'";
                        string id = cc.ExecuteScalar(sql);
                        if (id == "" || id == null)
                        {
                            sql = "insert into [DBCome2myct].[come2mycity].[DemoOnline](userid,status)values('" + sc.UserId + "','Active')";
                            int a = cc.ExecuteNonQuery(sql);
                        }
                        else
                        {
                            sql = "update [DBCome2myct].[come2mycity].[DemoOnline] set status='Active' where userid='" + sc.UserId + "'";
                            int a = cc.ExecuteNonQuery(sql);
                        }
                        string hostipadd = HttpContext.Current.Request.UserHostAddress;
                        UserRegistrationBLL userRegBLL = new UserRegistrationBLL();
                        userRegBLL.usrUserId = Convert.ToString(Session["User"]);
                        //userRegBLL.IPAddress = hostipadd;
                        Response.Redirect("html/HomePage.aspx", false); ///changes done by pooja
                    }
                }
                else
                {
                    lblMsg.Text = "10 digit Mobile no";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter the 10 disit mobile No....!')", true);
                }
            }
            else
            {
                lblMsg.Text = "Invalid User";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect ...Please try again')", true);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
            lblMsg.Text = "Invalid User";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Html/UserRegistration.aspx?F=L");
    }

    //---------------------------------

    public void visitorcounter()
    {
        string sql = "select count(*)  from VisitorIPCounter";
        int counter = Convert.ToInt32(cc.ExecuteScalar(sql));
        counter = counter + 100000;
        string counter1 = Convert.ToString(counter);
        lblcounter.Text = "Visitors: " + counter1;
    }

    protected void Addvisitor()
    {
        try
        {
            string Sql = " SELECT  VisitorId,VisitDateTime,NumofVisit FROM VisitorIPCounter  where VisitorID=(select MAX(VisitorID) from VisitorIPCounter where HostName='" + hostName + "'  and  IPAdd ='" + ipAddress + "' )";
            DataSet ds = cc.ExecuteDataset(Sql);

            DateTime dt2 = new DateTime();
            dt2 = System.DateTime.Now;
            dt2 = dt2.AddHours(12.50);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dt1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["VisitDateTime"]);
                // dt1 = Convert.ToDateTime("2013-4-13 2:30:01 AM");
                //  dt2 = Convert.ToDateTime("2013-4-15 3:30:01 AM");   // system data time is = 12/4/2013 6:30:51 PM   in db save 2013-12-04 18:30:51.000
                TimeSpan ts3 = dt2 - dt1;
                int d = ts3.Days;
                d = d * 24;
                int hr = ts3.Hours;
                int min = ts3.Minutes;
                hr = hr + d;
                if (hr < 3)
                {
                    string VisitorId = Convert.ToString(ds.Tables[0].Rows[0]["VisitorId"]);
                    int NumofVisit = Convert.ToInt32(ds.Tables[0].Rows[0]["NumofVisit"]);
                    NumofVisit++;
                    Sql = "update VisitorIPCounter set NumofVisit=" + NumofVisit + " where VisitorId='" + VisitorId + "' ";
                    int status = cc.ExecuteNonQuery(Sql);
                }
                else
                {

                    Sql = "insert into VisitorIPCounter(HostName,VisitDateTime,IPAdd,RequestURL,NumofVisit)" +
                              "values('" + hostName + "','" + dt2 + "','" + ipAddress + "','" + Request.Url.ToString() + "','1')";
                    int status = cc.ExecuteNonQuery(Sql);
                }
            }
            else
            {
                Sql = "insert into VisitorIPCounter(HostName,VisitDateTime,IPAdd,RequestURL,NumofVisit)" +
                             "values('" + hostName + "','" + dt2 + "','" + ipAddress + "','" + Request.Url.ToString() + "','1')";
                int status = cc.ExecuteNonQuery(Sql);
            }

            visitorcounter();
        }
        catch (Exception ex)
        {
        }
    }

    private string IpAddress()
    {
        // string ip = Request.UserHostAddress;
        string strIpAddress;
        strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        return strIpAddress;
    }
}

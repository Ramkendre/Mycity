using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();

    CTdll.PCommon pc = new CTdll.PCommon();
    CTdll.SessionContext sc = new CTdll.SessionContext();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        sc = (CTdll.SessionContext)Session["SC"];
        if (!IsPostBack)
        {
            
            try
            {
                ds = (DataSet)Session["Location"];
                if (ds == null)
                {
                    Location loc = new Location();
                    ds = loc.getAllLocation();
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
            sc.CityId = Convert.ToString(ddlCity.SelectedValue);
            sc.CityName = Convert.ToString(ddlCity.SelectedItem.Text);
            Session["SC"] = sc;
            Response.Redirect("html/CityInfoPage.aspx");
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
            if (sc != null )
            {

                Session["User"] = Convert.ToString(sc.UserId);
                //Session["MobileNoN"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
                Session["UserFirstNameN"] = Convert.ToString(sc.UserFName);
                Session["UserLastNameN"] = Convert.ToString(sc.UserLName);
                Session["UserMiddleName"] = Convert.ToString(sc.UserMName);
                Session["CityNameN"] = Convert.ToString(sc.CityName );
                Session["City"] = Convert.ToString(sc.CityId);
                Session["Mobile"] = Convert.ToString(sc.Mobile);
                Session["lastLogin"] = Convert.ToString(sc.LastLogin);
                if (Convert.ToString(sc.UserId).Trim() == "")
                {
                    lblMsg.Text = "Invalid User";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect ...Please try again')", true);

                }
                else
                {
                    Response.Redirect("html/UserInfo.aspx");
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
}

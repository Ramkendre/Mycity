using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    //DataSet ds = new DataSet();
    //CommonCode cc = new CommonCode();
    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    if (!IsPostBack)
    //    {
    //        try
    //        {
    //            ds = (DataSet)Session["Location"];
    //            if (ds == null)
    //            {
    //                Location loc = new Location();
    //                ds = loc.getAllLocation();
    //                Session["Location"] = ds;
    //            }
    //            if (ds.Tables[0] != null)
    //            {

    //                ddlState.DataSource = ds.Tables[0];
    //                ddlState.DataTextField = "StateName";
    //                ddlState.DataValueField = "StateId";
    //                ddlState.DataBind();
    //                ddlState.Items.Add("--Select--");
    //                ddlState.Items[ddlState.Items.Count - 1].Value = " ";
    //                ddlDistrict.Items.Add("--Select--");
    //                ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
    //                ddlCity.Items.Add("--Select--");
    //                ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";

    //                ddlState.SelectedIndex = ddlState.Items.Count - 1;
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            string msg = ex.Message;
    //        }
    //    }

    //}
    //private DataTable getDataTable(DataRow[] dr1)
    //{

    //    DataTable dt = new DataTable();
    //    dt.Columns.Add("Id", typeof(int));
    //    dt.Columns.Add("Name", typeof(string));
    //    try
    //    {
    //        foreach (DataRow dr in dr1)
    //        {
    //            DataRow ddr = dt.NewRow();
    //            ddr["Id"] = dr[0].ToString();
    //            ddr["Name"] = dr[1].ToString();
    //            dt.Rows.Add(ddr);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //    }
    //    return dt;
    //}

    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        ds = (DataSet)Session["Location"];
    //        if (ddlState.SelectedIndex != ddlState.Items.Count - 1)
    //        {
    //            if (ds.Tables[1] != null)
    //            {
    //                DataRow[] dr = ds.Tables[1].Select("StateId=" + ddlState.SelectedValue.ToString() + "");
    //                ddlDistrict.DataSource = getDataTable(dr);
    //                ddlDistrict.DataTextField = "Name";
    //                ddlDistrict.DataValueField = "Id";
    //                ddlDistrict.DataBind();
    //                ddlDistrict.Items.Add("--Select--");
    //                ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
    //                ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
    //            }
    //        }
    //        else
    //        {
    //            ddlCity.Items.Clear();
    //            ddlDistrict.Items.Clear();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //    }
    //}
    //protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        ds = (DataSet)Session["Location"];
    //        if (ddlDistrict.SelectedIndex != ddlState.Items.Count - 1)
    //        {
    //            if (ds.Tables[2] != null)
    //            {
    //                DataRow[] dr = ds.Tables[2].Select("DistrictId=" + ddlDistrict.SelectedValue.ToString() + "");
    //                ddlCity.DataSource = getDataTable(dr);
    //                ddlCity.DataTextField = "Name";
    //                ddlCity.DataValueField = "Id";
    //                ddlCity.DataBind();
    //                ddlCity.Items.Add("--Select--");
    //                ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";
    //                ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
    //            }
    //        }
    //        else
    //        {
    //            ddlCity.Items.Clear();

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //    }
    //}

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        SessionContext.CityId = Convert.ToString(ddlCity.SelectedValue);
    //        SessionContext.CityName = Convert.ToString(ddlCity.SelectedItem.Text);
    //        SessionContext.DistrictId = Convert.ToString(ddlDistrict.SelectedValue);
    //        SessionContext.DistrictName = Convert.ToString(ddlDistrict.SelectedItem.Text);
    //        SessionContext.StateId = Convert.ToString(ddlState.SelectedValue);
    //        SessionContext.StateName = Convert.ToString(ddlState.SelectedItem.Text);
    //        Session["City"] = SessionContext.CityId;
    //        Session["CityNameN"] = Convert.ToString(ddlCity.SelectedItem.Text);
    //        Response.Redirect("html/CityInfoPage.aspx");
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    //protected void Login_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Autenticateuser();
    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}

    //public void Autenticateuser()
    //{
    //    try
    //    {
    //        ds = cc.getLoginDetails(txtUserId.Text.ToString(), cc.DESEncrypt(txtPassword.Text.ToString()));

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            SessionContext.UserId = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
    //            SessionContext.Password = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["Password"]));
    //            SessionContext.UserMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
    //            SessionContext.UserFirstName = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
    //            SessionContext.UserMiddleName = Convert.ToString(ds.Tables[0].Rows[0]["MiddleName"]);
    //            SessionContext.UserLastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
    //            SessionContext.CityId = Convert.ToString(ds.Tables[0].Rows[0]["CityId"]);
    //            SessionContext.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
    //            SessionContext.DistrictId = Convert.ToString(ds.Tables[0].Rows[0]["DistrictId"]);
    //            SessionContext.DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["DistrictName"]);
    //            SessionContext.StateId = Convert.ToString(ds.Tables[0].Rows[0]["StateId"]);
    //            SessionContext.StateName = Convert.ToString(ds.Tables[0].Rows[0]["StateName"]);
    //            Session["User"] = Convert.ToString(ds.Tables[0].Rows[0]["UserId"]);
    //            //Session["MobileNoN"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
    //            Session["UserFirstNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["FirstName"]);
    //            Session["UserLastNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
    //            Session["UserMiddleName"] = Convert.ToString(ds.Tables[0].Rows[0]["MiddleName"]);
    //            Session["CityNameN"] = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
    //            Session["City"] = Convert.ToString(ds.Tables[0].Rows[0]["CityId"]);
    //            Session["Mobile"] = Convert.ToString(ds.Tables[0].Rows[0]["MobileNo"]);
    //            Response.Redirect("html/UserInfo.aspx");
    //        }
    //        else
    //        {
    //            lblMsg.Text = "Invalide User";
    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);

    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string msg = ex.Message;
    //        lblMsg.Text = "Invalide User";
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User Name or Password is Incorrect...Please try again')", true);
    //    }
    //}
    //protected void Register_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Html/UserRegistration.aspx");
    //}
    
    protected void English_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logcode.aspx");
    }
}

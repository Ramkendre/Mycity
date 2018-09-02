using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class Master_MainMaster : System.Web.UI.MasterPage
{
    DataSet ds = new DataSet();
    CTdll.SessionContext sc = new CTdll.SessionContext();
    CTdll.PCommon pc = new CTdll.PCommon();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        titleName.Text = "Myct In";
        sc = (CTdll.SessionContext)Session["sc"];
        try
        {
            if (!IsPostBack)
            {
                try
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
                    //string UserName = sc.UserId; //Convert.ToString(Session["User"]);
                    string UserName = Convert.ToString(Session["User"]);  /// Changes done by pooja
                    if (UserName != "")
                    {
                        //if (SessionContext.UserMobileNo != "")
                        //if (Convert.ToString(sc.Mobile) != "")
                        if (Convert.ToString(Session["Mobile"]) != "") ///Changes done by pooja
                        {


                            loggedin.Visible = true;
                            pnlMenu.Visible = true;
                            pnlSMenu.Visible = false;
                            fnSetNewControls();
                        }
                        else
                        {

                            pnlMenu.Visible = false;
                            pnlSMenu.Visible = true;
                            loggedin.Visible = false;

                        }
                    }
                    else
                    {
                        SessionContext.UserMobileNo = "";
                        Session["Mobile"] = "";
                        SessionContext.UserMiddleName = "";
                        Session["UserMiddleName"] = "";
                        SessionContext.UserLastName = "";
                        Session["UserLastNameN"] = "";
                        SessionContext.UserFirstName = "";
                        Session["UserFirstNameN"] = "";
                        SessionContext.Password = "";

                        pnlMenu.Visible = false;
                        pnlSMenu.Visible = true;
                        sc.Mobile = "";
                        sc.UserFName = "";
                        sc.UserLName = "";
                        sc.UserMName = "";
                        Session["SC"] = sc;
                    }

                }
                catch (Exception ex)
                {
                    SessionContext.UserMobileNo = "";
                    Session["Mobile"] = "";
                    SessionContext.UserMiddleName = "";
                    Session["UserMiddleName"] = "";
                    SessionContext.UserLastName = "";
                    Session["UserLastNameN"] = "";
                    SessionContext.UserFirstName = "";
                    Session["UserFirstNameN"] = "";
                    SessionContext.Password = "";
                    pnlMenu.Visible = false;
                    pnlSMenu.Visible = true;
                    sc.Mobile = "";
                    sc.UserFName = "";
                    sc.UserLName = "";
                    sc.UserMName = "";
                    Session["SC"] = sc;
                }

                //Test for CitySession

                try
                {
                    //string City = Convert.ToString(sc.CityId);
                    string City = Convert.ToString(Session["City"]); ///Chnges done by pooja
                    string Flag = Convert.ToString(Request.QueryString["Flag"]);
                    if (Flag != "1")
                    {
                        if (City == "")
                        {
                            SessionContext.CityId = "";
                            Session["City"] = "";
                            SessionContext.CityName = "";
                            Session["CityNameN"] = "";
                            SessionContext.DistrictId = "";
                            SessionContext.DistrictName = "";
                            SessionContext.StateId = "";
                            SessionContext.StateName = "";
                            //Response.Redirect("../default.aspx");
                            sc.CityId = "";
                            sc.CityName = "";
                            Session["SC"] = sc;
                        }
                    }
                }
                catch (Exception ex)
                {

                    SessionContext.CityId = "";
                    Session["City"] = "";
                    SessionContext.CityName = "";
                    Session["CityNameN"] = "";
                    SessionContext.DistrictId = "";
                    SessionContext.DistrictName = "";
                    SessionContext.StateId = "";
                    SessionContext.StateName = "";
                    // Response.Redirect("../default.aspx");
                    sc.CityId = "";
                    sc.CityName = "";
                    Session["SC"] = sc;
                }


            }
            ImageLoad();
        }
        catch (Exception ex)
        { }

        //smsactive.ServerClick += new EventHandler(fnSetNewControls_Click);
    }
    private void ImageLoad()
    {
        if (Session["User"].ToString() != "")
        {
            ImageProfile.ImageUrl = "../ImageHandler.ashx?userId=" + Session["User"].ToString() + "";
        }
    }
    public void fnSetNewControls()
    {
        string sql = "select SMS_status from [Come2myCityDB].[come2mycity].[SMSStatus] where userid='" + Session["User"].ToString() + "'";
        string smsstatus = cc.ExecuteScalar(sql);
        if (smsstatus == "Deactive")
        {
            smsactive.Visible = false;
        }
        else
        {
            // Response.Redirect("../html/SendSMS.aspx");

        }
    }

    //protected void fnSetNewControls_Click(object sender, EventArgs e)
    //{
    //    string sql = "select SMS_status from SMSStatus where userid='" + Session["User"].ToString() + "'";
    //    string smsstatus = cc.ExecuteScalar(sql);
    //    if (smsstatus == "Deactive")
    //    {
    //        smsactive.Visible = false;
    //    }
    //    else
    //    {
    //       // Response.Redirect("../html/SendSMS.aspx");

    //    }
    //}
    protected void btnChange_Click(object sender, EventArgs e)
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
            Session["District"] = SessionContext.DistrictId;
            Session["State"] = SessionContext.StateId;
            Response.Redirect("../html/CityInfoPage.aspx", false);
        }
        catch (Exception ex)
        {
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
        ModalPopupExtender1.Show();
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
        ModalPopupExtender1.Show();
    }
    private DataTable getDataTable(DataRow[] dr1)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        try
        {
            foreach (DataRow dr in dr1)
            {
                DataRow ddr = dt.NewRow();
                ddr["Id"] = dr[0].ToString();
                ddr["Name"] = dr[1].ToString();
                dt.Rows.Add(ddr);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        return dt;
    }

    //private void GetOnline()
    //{
    //    string sql = "select  usrFirstName+' '+usrLastName as Fullname from DemoOnline right outer join friendrelationmaster on DemoOnline.userid=friendrelationmaster.friendid right outer join usermaster on DemoOnline.userid=usermaster.usrUserid where friendrelationmaster.userid='" + Session["User"] + "' and status='Active'";
    //    DataSet ds = cc.ExecuteDataset(sql);
    //    gvUseronline.DataSource = ds.Tables[0];
    //    gvUseronline.DataBind();
    //}
    //protected void AutoRefreshTimer_Tick(object sender, EventArgs e)
    //{
    //    //UpdateProgress.Visible = false;
    //    GetOnline();
    //   // UpdateProgress.Visible = true;
    //}
}

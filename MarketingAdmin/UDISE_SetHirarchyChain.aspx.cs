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
using System.Drawing;


public partial class MarketingAdmin_UDISE_SetHirarchyChain : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string initialreference = "", Leader_RoleName = "", Leader_RoleID = "", Leader_UserID = "", Leader_Leader, LeaderNo = "", UserName = "";
    string reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", userid = "";
    string reference_id6 = "", reference_id7 = "", reference_id8 = "", reference_id9 = "", reference_id10 = "", reference_id11 = "";

    string RoleId = "", ReferenceId = "", SelectedValues = "", FullName = "", ShowData = "", ReferenceIdChk = "", ReferenceIdsel = "";
    int Count = 0, Countchk = 0;
    int status;
    protected void Page_Load(object sender, EventArgs e)
    {
        UserName = Convert.ToString(Session["MarketingUser"]);
        if (!IsPostBack)
        {
            LoadGrid();
            getRole();
            PopulateRootLevel();
            TreeDemo();
        }
      

    }

    public void getRole()
    {
        try
        {
            string sql = "select Roleid,RoleName,RoleDescription from submenuPermission where roleid in (14,15,16,17,18,19,20,21,75,76)";
            DataSet ds = cc.ExecuteDataset(sql);


            ddlRoleName.DataSource = ds.Tables[0];
            ddlRoleName.DataTextField = "RoleName";
            ddlRoleName.DataValueField = "Roleid";
            ddlRoleName.DataBind();
            ddlRoleName.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlRoleName.SelectedIndex = 0;


            ddlJoinUserRole.DataSource = ds.Tables[0];
            ddlJoinUserRole.DataTextField = "RoleName";
            ddlJoinUserRole.DataValueField = "Roleid";
            ddlJoinUserRole.DataBind();
            // ddlJoinUserRole.Items.Add("--Select--");
            // ddlJoinUserRole.SelectedIndex = ddlJoinUserRole.Items.Count - 1;
            ddlJoinUserRole.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlReportType.Items[0].Value = "0";
            ddlJoinUserRole.SelectedIndex = 0;


            ddlOldLeaderRole.DataSource = ds.Tables[0];
            ddlOldLeaderRole.DataTextField = "RoleName";
            ddlOldLeaderRole.DataValueField = "Roleid";
            ddlOldLeaderRole.DataBind();
            //  ddlOldLeaderRole.Items.Add("--Select--");
            // ddlOldLeaderRole.SelectedIndex = ddlOldLeaderRole.Items.Count - 1;
            ddlOldLeaderRole.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlReportType.Items[0].Value = "0";
            ddlOldLeaderRole.SelectedIndex = 0;

            ddlNewLeaderRole.DataSource = ds.Tables[0];
            ddlNewLeaderRole.DataTextField = "RoleName";
            ddlNewLeaderRole.DataValueField = "Roleid";
            ddlNewLeaderRole.DataBind();
            // ddlto.Items.Add("--Select--");
            // ddlto.SelectedIndex = ddlto.Items.Count - 1;
            ddlNewLeaderRole.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlReportType.Items[0].Value = "0";
            ddlNewLeaderRole.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadGrid()
    {


        if (UserName == "Admin")
        {
            UserName = "6dde8c3d-1895-4904-b332-764f63206fc0";
        }

        //string Sql = "SELECT distinct(MobileNo),UserMaster.usruserid as id,UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName,AdminSubMarketingSubUser.rolename,UDISE_TotalByRole.TotalReporty,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G " +
        //             "FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
        //             "UDISE_TotalByRole.RoleId=AdminSubMarketingSubUser.roleid where ReportId ='" + USERNAME + "'";

        string Sql = " SELECT distinct(usrmobileno), AdminSubMarketingSubUser.id as ASPID ,treedemo.id as TreeID, UserMaster.usruserid as id,UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName, AdminSubMarketingSubUser.rolename " +
                     " from UserMaster left join  AdminSubMarketingSubUser on  AdminSubMarketingSubUser.friendid=UserMaster.usruserid " +
                     " inner join  TreeDemo on  TreeDemo.userid=UserMaster.usruserid " +
                     " where  TreeDemo.parentid in(select Id from  treedemo where userid ='" + UserName + "' ) and  AdminSubMarketingSubUser.userid='" + UserName + "' ";


        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvlist.DataSource = ds.Tables[0];
            gvlist.DataBind();

            //ddlmain.DataSource = ds.Tables[0];
            //ddlmain.DataTextField = "MobileNo";
            //ddlmain.DataValueField = "id";
            //ddlmain.DataBind();
            //ddlmain.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlmain.SelectedIndex = 0;
        }
    }
    public void FindRoleId()
    {
        string Sql = "Select Roleid from AdminSubMarketingSubUser where friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";
        Count = Convert.ToInt16(cc.ExecuteScalar(Sql));
        if (Count == 14)
        {
            ReferenceId = "reference_id2";
        }
        else if (Count == 15)
        {
            ReferenceId = "reference_id3";
        }
        else if (Count == 16)
        {
            ReferenceId = "reference_id4";
        }
        else if (Count == 17)
        {
            ReferenceId = "reference_id5";
        }
        else if (Count == 18)
        {
            ReferenceId = "reference_id6";
        }
        else if (Count == 19)
        {
            ReferenceId = "reference_id7";
        }
        else if (Count == 20)
        {
            ReferenceId = "reference_id8";
        }
        else if (Count == 21)
        {
            ReferenceId = "reference_id9";
        }
        else if (Count == 75)
        {
            ReferenceId = "reference_id10";
        }
    }
    public void LoadGridByRole()
    {
        try
        {

            int roleid = Convert.ToInt32(Session["RoleId"]);
            Countchk = Convert.ToInt16(ddlRoleName.SelectedValue);           
            if ((roleid < Countchk) && (roleid != Countchk))
            {
                string Sql = " SELECT distinct(usrmobileno), AdminSubMarketingSubUser.id as ASPID ,treedemo.id as TreeID, UserMaster.usruserid as id,UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName, AdminSubMarketingSubUser.rolename " +
              " from UserMaster left join  AdminSubMarketingSubUser on  AdminSubMarketingSubUser.friendid=UserMaster.usruserid " +
              " inner join  TreeDemo on  TreeDemo.userid=UserMaster.usruserid " +
              " where  TreeDemo.parentid in(select Id from  treedemo where userid ='" + ddlmain.SelectedValue + "')";



                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvlist.DataSource = ds.Tables[0];
                    gvlist.DataBind();                  
                    lblError.Text = "";
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Text = "";
                    lblError.Visible = true;
                }

            }
            else
            {
                Response.Write("<script>(alert)('Sorry ...You can't see senior report and Same level.')</script>");
                lblError.Text = "Sorry ...You can't see senior report and Same level.";
                lblError.Visible = true;
            }
        }
        catch (Exception ex)


        { }
    }

    public void LoadMainLeaderByRole()
    {
        try
        {

            int roleid = Convert.ToInt32(Session["RoleId"]);
            Countchk = Convert.ToInt16(ddlRoleName.SelectedValue);
            FindRoleId();
            if ((roleid < Countchk) && (roleid != Countchk ))
            {
                //string Sql = " SELECT distinct(MobileNo),UserMaster.usruserid as id,UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName,AdminSubMarketingSubUser.rolename,UDISE_TotalByRole.TotalReporty,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G" +
                //                                      " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                //                                      " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                //                                      " where AdminSubMarketingSubUser." + ReferenceId + "='" + Convert.ToString(Session["MarketingUser"]) + "' and AdminSubMarketingSubUser.roleid=" + Convert.ToInt16(Countchk) + "";

                //  string Sql = " SELECT distinct(usrmobileno), AdminSubMarketingSubUser.id as ASPID ,treedemo.id as TreeID, UserMaster.usruserid as id,UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName, AdminSubMarketingSubUser.rolename " +
                //" from UserMaster left join  AdminSubMarketingSubUser on  AdminSubMarketingSubUser.friendid=UserMaster.usruserid " +
                //" inner join  TreeDemo on  TreeDemo.userid=UserMaster.usruserid " +
                //" where  TreeDemo.parentid in(select Id from  treedemo where userid ='" + ddlRoleName.SelectedValue + "')";

                string Sql = "   SELECT distinct(usrMobileNo) as MobileNo,UserMaster.usruserid as id  " +
   "  FROM  UserMaster " +
   "  join AdminSubMarketingSubUser on  UserMaster.usrUserId=AdminSubMarketingSubUser.friendid   " +
   " where AdminSubMarketingSubUser." + ReferenceId + "='" + Convert.ToString(Session["MarketingUser"]) + "' and AdminSubMarketingSubUser.roleid=" + Convert.ToInt16(Countchk) + "";



                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //gvlist.DataSource = ds.Tables[0];
                    //gvlist.DataBind();

                    ddlmain.DataSource = ds.Tables[0];
                    ddlmain.DataTextField = "MobileNo";
                    ddlmain.DataValueField = "id";
                    ddlmain.DataBind();
                    // ddlto.Items.Add("--Select--");
                    // ddlto.SelectedIndex = ddlto.Items.Count - 1;
                    ddlmain.Items.Insert(0, new ListItem("--Select--", "0"));
                    //ddlReportType.Items[0].Value = "0";
                    ddlmain.SelectedIndex = 0;
                    lblError.Text = "";
                    lblError.Visible = false;
                }
                else
                {
                    ddlmain.Items.Clear();
                    lblError.Text = "Record Not Found";
                    lblError.Visible = true;
                }
                               
            }
            else
            {
                ddlmain.Items.Clear();
                Response.Write("<script>(alert)('Sorry ...You can't see senior report and Same level.')</script>");
                lblError.Text = "Sorry ...You can't see senior report and Same level.";
                lblError.Visible = true;
            }
        }
        catch (Exception ex)


        { }
    }

    public void getjoinDetails()
    {
        try
        {

            if ((Convert.ToInt32(ddlOldLeaderRole.SelectedValue) < Convert.ToInt32(ddlJoinUserRole.SelectedValue)) && (Convert.ToInt32(ddlOldLeaderRole.SelectedValue) != Convert.ToInt32(ddlJoinUserRole.SelectedValue)))
            {
                string Sql = " SELECT distinct(MobileNo) as Number, UserMaster.usruserid as id " +
                                                                 " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                                                 " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                                                 " where AdminSubMarketingSubUser.userid='" + ddlOldLeader.SelectedValue + "' and AdminSubMarketingSubUser.roleid='" + ddlJoinUserRole.SelectedValue + "'";


                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlJoinUserRoleName.DataSource = ds.Tables[0];
                    ddlJoinUserRoleName.DataTextField = "Number";
                    ddlJoinUserRoleName.DataValueField = "id";
                    ddlJoinUserRoleName.DataBind();
                    ddlJoinUserRoleName.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlJoinUserRoleName.SelectedIndex = 0;
                    //ddlJoinUserRoleName.Items.Add("--Select--");
                    //ddlJoinUserRoleName.SelectedIndex = ddlJoinUserRoleName.Items.Count - 1;
                    lblError.Text = "";
                    lblError.Visible = false;
                }
                else
                {
                    ddlJoinUserRoleName.Items.Clear();
                    lblError.Text = "record Not Found";
                    lblError.Visible = true;
                }
            }
            else
            {
                ddlJoinUserRoleName.Items.Clear();
                Response.Write("<script>(alert)('Sorry ...You can't see senior report and Same level.')</script>");
                lblError.Text = "Sorry ...You can't see senior report and Same level.";
                lblError.Visible = true;
            }
        }
        catch (Exception ex)


        { }
    }

    public void getOfDetails()
    {
        try
        {


            if ((Convert.ToInt32(ddlRoleName.SelectedValue) < Convert.ToInt32(ddlOldLeaderRole.SelectedValue)) && (Convert.ToInt32(ddlRoleName.SelectedValue) != Convert.ToInt32(ddlOldLeaderRole.SelectedValue)))
            {
                string Sql = " SELECT distinct(MobileNo) as Number, UserMaster.usruserid as id " +
                                                                 " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                                                 " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                                                 " where AdminSubMarketingSubUser.userid='" + ddlmain.SelectedValue + "'and AdminSubMarketingSubUser.roleid='" + ddlOldLeaderRole.SelectedValue + "'";


                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlOldLeader.DataSource = ds.Tables[0];
                    ddlOldLeader.DataTextField = "Number";
                    ddlOldLeader.DataValueField = "id";
                    ddlOldLeader.DataBind();
                    //ddlOldLeader.Items.Add("--Select--");
                    //ddlOldLeader.SelectedIndex = ddlOldLeader.Items.Count - 1;
                    ddlOldLeader.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlOldLeader.SelectedIndex = 0;
                    lblError.Text = "";
                    lblError.Visible = false;
                }
                else
                {
                    ddlOldLeader.Items.Clear();
                    lblError.Text = "record Not Found";
                    lblError.Visible = true;
                }
            }
            else
            {
                ddlOldLeader.Items.Clear();
                Response.Write("<script>(alert)('Sorry ...You can't see senior report and Same level.')</script>");
                lblError.Text = "Sorry ...You can't see senior report and Same level.";
                lblError.Visible = true;
            }

        }
        catch (Exception ex)


        { }
    }

    public void getToDetails()
    {
        try
        {

            if ((Convert.ToInt32(ddlRoleName.SelectedValue) < Convert.ToInt32(ddlNewLeaderRole.SelectedValue)) && (Convert.ToInt32(ddlRoleName.SelectedValue) != Convert.ToInt32(ddlNewLeaderRole.SelectedValue)))
            {
                string Sql = " SELECT distinct(MobileNo) as Number, UserMaster.usruserid as id " +
                                                                 " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                                                 " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                                                 " where AdminSubMarketingSubUser.userid='" + ddlmain.SelectedValue + "'and AdminSubMarketingSubUser.roleid='" + ddlOldLeaderRole.SelectedValue + "'";


                DataSet ds = cc.ExecuteDataset(Sql);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    ddlNewLeader.DataSource = ds.Tables[0];
                    ddlNewLeader.DataTextField = "Number";
                    ddlNewLeader.DataValueField = "id";
                    ddlNewLeader.DataBind();
                    //ddlOldLeader.Items.Add("--Select--");
                    //ddlOldLeader.SelectedIndex = ddlOldLeader.Items.Count - 1;
                    ddlNewLeader.Items.Insert(0, new ListItem("--Select--", "0"));
                    ddlNewLeader.SelectedIndex = 0;
                    lblError.Text = "";
                    lblError.Visible = false;
                }
                else
                {
                    ddlNewLeader.Items.Clear();
                    lblError.Text = "record Not Found";
                    lblError.Visible = true;
                }
            }
            else
            {
                ddlNewLeader.Items.Clear();
                Response.Write("<script>(alert)('Sorry ...You can't see senior report and Same level.')</script>");
                lblError.Text = "Sorry ...You can't see senior report and Same level.";
                lblError.Visible = true;
            }


        }
        catch (Exception ex)


        { }
    }



    protected void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlRoleName.SelectedValue == "0")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "14")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "15")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "16")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "17")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "18")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "19")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "20")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "21")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "75")
            {
                LoadMainLeaderByRole();
            }
            else if (ddlRoleName.SelectedValue == "76")
            {
                LoadMainLeaderByRole();
            }
        }
        catch (Exception ex)
        { }
    }

    protected void gvlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvlist.PageIndex = e.NewPageIndex;
        LoadGridByRole();
    }
    public void FindRoleIdref(string UserIdRef)
    {
        string Sql = "Select Roleid from AdminSubMarketingSubUser where userid='" + UserIdRef + "'";
        Count = Convert.ToInt16(cc.ExecuteScalar(Sql));
        if (Count == 14)
        {
            // ReferenceIdChk = "reference_id2";
        }
        else if (Count == 15)
        {
            ReferenceIdChk = "reference_id2";
        }
        else if (Count == 16)
        {
            ReferenceIdChk = "reference_id3";
        }
        else if (Count == 17)
        {
            ReferenceIdChk = "reference_id4";
        }
        else if (Count == 18)
        {
            ReferenceIdChk = "reference_id5";
        }
        else if (Count == 19)
        {
            ReferenceIdChk = "reference_id6";
        }
        else if (Count == 20)
        {
            ReferenceIdChk = "reference_id7";
        }
        else if (Count == 21)
        {
            ReferenceIdChk = "reference_id8";
        }
        else if (Count == 75)
        {
            ReferenceIdChk = "reference_id9";
        }
        else if (Count == 76)
        {
            ReferenceIdChk = "reference_id10";
        }
    }
    string Useridchk = "", MobileNochk = "";
    protected void gvlist_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
           // string Data = gvlist.Cells[4].Text.ToString();          
            string Id = Convert.ToString(e.CommandArgument);
            string SQL = "select userid from TreeDemo where id='" + Id + "' ";
            string Getuserid = cc.ExecuteScalar(SQL); // check subuser exit or not
            string query = "select id from TreeDemo where parentid='" + Id + "' ";
            string Checkid = cc.ExecuteScalar(query); // check subuser exit or not
            if (!(Checkid == null || Checkid == ""))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
                lblError.Text = "This record reference use Other Location";
                lblError.Visible = true;
            }
            else
            {
                string SQl = "delete from TreeDemo where id='" + Id + "' ";
               status = cc.ExecuteNonQuery(SQl); //  Delete record in treedemo
               if (status > 0)
               {
                   SQl = "delete from AdminSubMarketingSubUser where friendid='" + Getuserid + "' and userid='"+Convert.ToString( Session["MarketingUser"]) +"' ";
                   status = cc.ExecuteNonQuery(SQl); // Delete record in Adminsubmarketingsubuser
                   if (status > 0)
                   {
                       LoadGridByRole();
                       Response.Write("<script>(alert)('Record Deleted')</script>");
                       lblError.Text = "Record Deleted";
                       lblError.Visible = true;
                   }
                   else
                   {
                       ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This record reference use Other Location')", true);
                       Response.Write("<script>(alert)('Record Not  Deleted')</script>");
                       lblError.Text = "Record Not Deleted";
                       lblError.Visible = true;
                   }
               }
               else
               {
                   Response.Write("<script>(alert)('Record Not  Deleted')</script>");
                   lblError.Text = "Record Not Deleted";
                   lblError.Visible = true;
               }
                 LoadGridByRole();
               
            }
        }
    }

    public void LoadGridByRoleShow(string RoleId, string Underchk)
    {
        try
        {
            FindRoleId();
            string Sql = " SELECT distinct(MobileNo),UserMaster.usrAutoId,UserMaster.usrFirstName,UserMaster.usrLastName,AdminSubMarketingSubUser.rolename,UDISE_TotalByRole.TotalReporty,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G" +
                                       " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                       " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                       " where AdminSubMarketingSubUser." + ReferenceId + "='" + Convert.ToString(Session["MarketingUser"]) + "' and AdminSubMarketingSubUser." + ReferenceIdChk + "='" + Underchk + "' and AdminSubMarketingSubUser.roleid=" + RoleId + "";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvlist.DataSource = ds.Tables[0];
                gvlist.DataBind();

            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ddlRoleName.SelectedValue = "0";
        LoadGrid();
    }

    public void TreeDemo()
    {
        string Sql = "SELECT userid,roleid,rolename,friendid,doj,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 " +
                     " FROM AdminSubMarketingSubUser where userid ='" + Convert.ToString(Session["MarketingUser"]) + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Secretary = Convert.ToString(ds.Tables[0].Rows[0]["reference_id2"]);
            if (Secretary != "")
            {
                GetData(Secretary);

            }
            string DeptySec = Convert.ToString(ds.Tables[0].Rows[0]["reference_id3"]);
            if (DeptySec != "")
            {
                GetData(DeptySec);

            }
            string DirectorEdu = Convert.ToString(ds.Tables[0].Rows[0]["reference_id4"]);
            if (DirectorEdu != "")
            {
                GetData(DirectorEdu);

            }
            string DeputyDir = Convert.ToString(ds.Tables[0].Rows[0]["reference_id5"]);
            if (DeputyDir != "")
            {
                GetData(DeputyDir);

            }
            string EducationOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id6"]);
            if (EducationOff != "")
            {
                GetData(EducationOff);
            }
            string DeputyOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id7"]);
            if (DeputyOff != "")
            {
                GetData(DeputyOff);

            }
            string BlockOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id8"]);
            if (BlockOff != "")
            {
                GetData(BlockOff);

            }
            string ExtentionOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id9"]);
            if (ExtentionOff != "")
            {
                GetData(ExtentionOff);

            }
            string ClusterHea = Convert.ToString(ds.Tables[0].Rows[0]["reference_id10"]);
            if (ClusterHea != "")
            {
                GetData(ClusterHea);

            }
            string HeadMas = Convert.ToString(ds.Tables[0].Rows[0]["reference_id11"]);
            if (HeadMas != "")
            {
                GetData(HeadMas);

            }
        }
    }

    public void TreeDemoChk(string chkUserId)
    {
        string Sql = "SELECT userid,roleid,rolename,friendid,doj,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 " +
                     " FROM AdminSubMarketingSubUser where userid ='" + chkUserId + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Secretary = Convert.ToString(ds.Tables[0].Rows[0]["reference_id2"]);
            if (Secretary != "")
            {
                GetData(Secretary);

            }
            string DeptySec = Convert.ToString(ds.Tables[0].Rows[0]["reference_id3"]);
            if (DeptySec != "")
            {
                GetData(DeptySec);

            }
            string DirectorEdu = Convert.ToString(ds.Tables[0].Rows[0]["reference_id4"]);
            if (DirectorEdu != "")
            {
                GetData(DirectorEdu);

            }
            string DeputyDir = Convert.ToString(ds.Tables[0].Rows[0]["reference_id5"]);
            if (DeputyDir != "")
            {
                GetData(DeputyDir);

            }
            string EducationOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id6"]);
            if (EducationOff != "")
            {
                GetData(EducationOff);

            }
            string DeputyOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id7"]);
            if (DeputyOff != "")
            {
                GetData(DeputyOff);

            }
            string BlockOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id8"]);
            if (BlockOff != "")
            {
                GetData(BlockOff);

            }
            string ExtentionOff = Convert.ToString(ds.Tables[0].Rows[0]["reference_id9"]);
            if (ExtentionOff != "")
            {
                GetData(ExtentionOff);

            }
            string ClusterHea = Convert.ToString(ds.Tables[0].Rows[0]["reference_id10"]);
            if (ClusterHea != "")
            {
                GetData(ClusterHea);

            }
            string HeadMas = Convert.ToString(ds.Tables[0].Rows[0]["reference_id11"]);
            if (HeadMas != "")
            {
                GetData(HeadMas);

            }
        }
    }

    public void GetData(string UserId)
    {
        FullName = "";
        string Sql = "Select usrFirstName, usrLastName from UserMaster where usrUserId='" + UserId + "'";
        DataSet ds = cc.ExecuteDataset(Sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string FirstName = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
            string LastName = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
            FullName = FirstName + " " + LastName;
        }
    }


    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void ddlNewLeaderRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            getToDetails();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlJoinUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            getjoinDetails();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlOldLeaderRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            getOfDetails();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btncancle_Click(object sender, EventArgs e)
    {
        try
        {
            cancel();
        }
        catch (Exception ex)
        {

        }
    }
    public void cancel()
    {
        ddlOldLeaderRole.SelectedIndex = 0;
        ddlNewLeaderRole.SelectedIndex = 0;
        ddlNewLeader.SelectedIndex = 0;
        ddlRoleName.SelectedIndex = 0;
        ddlOldLeader.SelectedIndex = 0;
        ddlJoinUserRoleName.SelectedIndex = 0;
        ddlJoinUserRole.SelectedIndex = 0;
        ddlmain.SelectedIndex = 0;
        ddlNewLeader.SelectedIndex = ddlNewLeader.Items.Count - 1;
        //ddlto.SelectedIndex = ddlto.Items.Count - 1;
        //ddlRoleName.SelectedIndex = ddlRoleName.Items.Count - 1;
        ddlOldLeader.SelectedIndex = ddlOldLeader.Items.Count - 1;
        //ddlOldLeaderRole.SelectedIndex = ddlOldLeaderRole.Items.Count - 1;
        ddlJoinUserRoleName.SelectedIndex = ddlJoinUserRoleName.Items.Count - 1;
        //ddlJoinUserRole.SelectedIndex = ddlJoinUserRole.Items.Count - 1;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if ((ddlRoleName.SelectedValue == Convert.ToString("0")) || (ddlmain.SelectedValue == Convert.ToString("0")))
            {
                lblError.Text = "Please Select Above Leader Role & Mobile Number";
                lblError.Visible = true;
            }
            else if ((ddlOldLeader.SelectedValue == Convert.ToString("0")) || (ddlOldLeaderRole.SelectedValue == Convert.ToString("0")))
            {
                lblError.Text = "Please Select Old Leader Role & Mobile Number";
                lblError.Visible = true;
            }
            else if ((ddlJoinUserRole.SelectedValue == Convert.ToString("0")) || (ddlJoinUserRoleName.SelectedValue == Convert.ToString("0")))
            {
                lblError.Text = "Please Select Join User Role & Mobile Number";
                lblError.Visible = true;
            }
            else if ((ddlNewLeader.SelectedValue == Convert.ToString("0")) || (ddlNewLeaderRole.SelectedValue == Convert.ToString("0")))
            {
                lblError.Text = "Please Select New Leader Role & Mobile Number";
                lblError.Visible = true;
            }
            else
            {
                lblError.Text = "";
                lblError.Visible = false;
                ReplaceChain();
                Response.Write("<script>(alert)('"+ddlJoinUserRoleName.Text+" is shifted from "+ddlRoleName.Text+" to "+ddlOldLeader.Text +"')</script>");
                lblError.Text = "Record Not Deleted";
                lblError.Visible = true;
                cancel();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlmain_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string Sql = " SELECT distinct(MobileNo) as Number, UserMaster.usruserid as id " +
                                                  " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                                  " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                                  " where AdminSubMarketingSubUser.userid='" + ddlmain.SelectedValue + "'";


            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlOldLeader.DataSource = ds.Tables[0];
                ddlOldLeader.DataTextField = "Number";
                ddlOldLeader.DataValueField = "id";
                ddlOldLeader.DataBind();
                //ddlOldLeader.Items.Add("--Select--");
                //ddlOldLeader.SelectedIndex = ddlOldLeader.Items.Count - 1;
                ddlOldLeader.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlOldLeader.SelectedIndex = 0;

                ddlNewLeader.DataSource = ds.Tables[0];
                ddlNewLeader.DataTextField = "Number";
                ddlNewLeader.DataValueField = "id";
                ddlNewLeader.DataBind();
                //ddlNewLeader.Items.Add("--Select--");
                //ddlNewLeader.SelectedIndex = ddlNewLeader.Items.Count - 1;

                ddlNewLeader.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlNewLeader.SelectedIndex = 0;
            }
            else
            {
                ddlOldLeader.Items.Clear();
                lblError.Text = "record Not Found";
                lblError.Visible = true;
            }
            LoadGridByRole();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlOldLeader_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string Sql = " SELECT distinct(MobileNo) as Number, UserMaster.usruserid as id " +
                                                  " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                                  " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                                  " where AdminSubMarketingSubUser.userid='" + ddlOldLeader.SelectedValue + "'";


            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlJoinUserRoleName.DataSource = ds.Tables[0];
                ddlJoinUserRoleName.DataTextField = "Number";
                ddlJoinUserRoleName.DataValueField = "id";
                ddlJoinUserRoleName.DataBind();
                //ddlJoinUserRoleName.Items.Add("--Select--");
                //ddlJoinUserRoleName.SelectedIndex = ddlJoinUserRoleName.Items.Count - 1;

                ddlJoinUserRoleName.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlJoinUserRoleName.SelectedIndex = 0;
            }
            else
            {
                ddlJoinUserRoleName.Items.Clear();
                lblError.Text = "record Not Found";
                lblError.Visible = true;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void ddlJoinUserRoleName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string Sql = " SELECT distinct(MobileNo) as Number, UserMaster.usruserid as id " +
                                                  " FROM UDISE_TotalByRole inner join UserMaster on UDISE_TotalByRole.UserId=UserMaster.usrUserId join AdminSubMarketingSubUser on " +
                                                  " UDISE_TotalByRole.ReportId=AdminSubMarketingSubUser.userid " +
                                                  " where AdminSubMarketingSubUser.userid='" + ddlJoinUserRoleName.SelectedValue + "'";


            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlNewLeader.DataSource = ds.Tables[0];
                ddlNewLeader.DataTextField = "Number";
                ddlNewLeader.DataValueField = "id";
                ddlNewLeader.DataBind();
                //ddlNewLeader.Items.Add("--Select--");
                //ddlNewLeader.SelectedIndex = ddlNewLeader.Items.Count - 1;

                ddlNewLeader.Items.Insert(0, new ListItem("--Select--", "0"));
                ddlNewLeader.SelectedIndex = 0;
            }
            else
            {
                ddlNewLeader.Items.Clear();
                lblError.Text = "record Not Found";
                lblError.Visible = true;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void ReplaceChain()
    {
        try
        {
            Replace_juniors(ddlOldLeader.SelectedItem.Text, ddlNewLeader.SelectedItem.Text, ddlJoinUserRoleName.SelectedItem.Text);
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    private void Replace_juniors(string LeaderNoOld, string LeaderNoNew, string JoinPersonMobileNo)
    {

        try
        {
            // LeaderNo = LeaderNoOld; // use for common All code
            //string getuserID_Leader = "select usrUserid from usermaster where usrMobileNo='" + LeaderNo + "'";
            //Leader_UserID = cc.ExecuteScalar(getuserID_Leader); // get Leader usruserID
            Leader_UserID = ddlOldLeader.SelectedValue;// get Leader usruserID
            if (Leader_UserID == "Admin")
            {
                string sql = "select MobileNo from Marketinguser1 where UserId='" + UserName + "'";
                string mobileno = cc.ExecuteScalar(sql);
                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                Leader_UserID = cc.ExecuteScalar(sql1);
            }
            else
            {
                info13();
            }
            string JuniorNo_usrID = ddlJoinUserRoleName.SelectedValue;// get  juniour usrUserID
            string LeaderoldNo_usrID = ddlOldLeader.SelectedValue;// get Old Leader usrUserID
            string LeaderNewNo_usrID = ddlNewLeader.SelectedValue;// get New Leader usrUserID

            string date_ofJoin = "", JuniorRoleID = "", JuniorRoleName = "", reference_id1 = "";
            date_ofJoin = DateTime.Now.Date.ToString(); // get current date
            reference_id1 = initialreference; // add Administrator reference 
            JuniorRoleID = ddlJoinUserRole.SelectedValue; // get junior Role ID
            JuniorRoleName = ddlJoinUserRole.SelectedItem.Text;// get junior Role name

            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                //ddlOldLeader.SelectedItem.Text;
                //ddlNewLeader.SelectedItem.Text;
                if (LeaderoldNo_usrID != LeaderNewNo_usrID)
                {
                    // string LeaderoldNo_usrID = LeaderoldNo_usrID;
                    string SQL, qry;

                    string sq1 = "select id from AdminSubMarketingSubUser where userid='" + LeaderoldNo_usrID + "' and  friendid='" + JuniorNo_usrID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' ";
                    string Chk_Assign = cc.ExecuteScalar(sq1); // check juniour is exit or not
                    if ((Chk_Assign != null || Chk_Assign != ""))
                    {

                        string Leader_Leader = ddlmain.SelectedValue;

                        if (reference_id2 == "")
                        {

                            qry = "update AdminSubMarketingSubUser set reference_id1='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "' where   reference_id1='" + reference_id1 + "' ";// and reference_id2='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "' where userid='" + LeaderoldNo_usrID + "' and  reference_id1='" + LeaderNewNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";

                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "' , RplsChainLogDtls='" + UserName + "' where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }
                            }
                        }
                        if (reference_id3 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id2='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' ";// and reference_id3='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + LeaderNewNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";

                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "' , RplsChainLogDtls='" + UserName + "' where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }

                            }
                        }
                        if (reference_id4 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id3='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' ";// and reference_id4='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + LeaderNewNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "' , RplsChainLogDtls='" + UserName + "' where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }
                            }

                        }
                        if (reference_id5 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id4='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' ";// and reference_id5='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + LeaderNewNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "' , RplsChainLogDtls='" + UserName + "' where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }
                            }

                        }
                        if (reference_id6 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id5='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' ";// and  reference_id6='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + LeaderNewNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "', RplsChainLogDtls='" + UserName + "'  where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }

                            }
                        }
                        if (reference_id7 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id6='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' ";//  and reference_id7='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + LeaderNewNo_usrID + "' ";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "', RplsChainLogDtls='" + UserName + "'  where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }
                            }

                        }
                        if (reference_id8 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id7='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' ";// and reference_id8='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + LeaderNewNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "' , RplsChainLogDtls='" + UserName + "' where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }
                            }

                        }
                        if (reference_id9 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id8='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' ";// and  reference_id9='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + LeaderNewNo_usrID + "' ";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "', RplsChainLogDtls='" + UserName + "'  where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }
                            }

                        }
                        if (reference_id10 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id9='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' ";// and reference_id10='" + LeaderoldNo_usrID + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + LeaderNewNo_usrID + "' ";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "', RplsChainLogDtls='" + UserName + "'  where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }
                            }



                        }
                        if (reference_id11 == "")
                        {
                            qry = "update AdminSubMarketingSubUser set reference_id10='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' ";// and reference_id11='" + Convert.ToString(LeaderoldNo_usrID) + "' ";
                            qry = qry + "update AdminSubMarketingSubUser set userid='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where userid='" + LeaderoldNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + LeaderNewNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set leader_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where leader_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update UDISE_TeacherMaster set junior_id='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where junior_id='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + LeaderNewNo_usrID + "', RplsChainLogDtls='" + UserName + "'  where UsrUserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";
                            qry = qry + "update [UDISE_TotalByRole] set ReportId='" + LeaderNewNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where UserId='" + JuniorNo_usrID + "' and MobileNo='" + ddlJoinUserRoleName.SelectedItem.Text + "' and ReportId='" + LeaderoldNo_usrID + "'";


                            status = cc.ExecuteNonQuery(qry);
                            if (status > 0)
                            {
                                string query = "select id from TreeDemo where userid='" + LeaderNewNo_usrID + "' ";
                                string CheckTree = cc.ExecuteScalar(query); // Get Parent Id NewLeader
                                if (!(CheckTree == null || CheckTree == ""))
                                {
                                    string SQl = "update TreeDemo set parentid='" + CheckTree + "' , RplsChainLogDtls='" + UserName + "' where userid='" + JuniorNo_usrID + "'";
                                    status = cc.ExecuteNonQuery(SQl); // Update Oldleader Parentid
                                }

                            }
                        }
                    }
                }

            }

        }
        catch (Exception ex)
        {


        }

    }

    public void clearref()
    {
        reference_id10 = "";
        reference_id11 = "";
        reference_id2 = "";
        reference_id3 = "";
        reference_id4 = "";
        reference_id5 = "";
        reference_id6 = "";
        reference_id7 = "";
        reference_id8 = "";
        reference_id9 = "";
        Leader_RoleName = "";
        Leader_Leader = "";
        Leader_RoleID = "";
        Leader_UserID = "";


    }
    private void info13()
    {
        try
        {


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + ddlOldLeader.SelectedValue + "' and Active='1'";

            DataSet ds1 = cc.ExecuteDataset(Getreference);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                clearref();
                Leader_RoleName = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
                Leader_Leader = Convert.ToString(ds1.Tables[0].Rows[0]["userid"]);
                Leader_RoleID = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
                Leader_UserID = Convert.ToString(ds1.Tables[0].Rows[0]["friendid"]);

                reference_id2 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id2"]);
                if (reference_id2 == "")
                {
                    reference_id2 = Leader_UserID;
                    break;
                }

                reference_id3 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id3"]);
                if (reference_id3 == "")
                {
                    reference_id3 = Leader_UserID;
                    break;
                }

                reference_id4 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id4"]);
                if (reference_id4 == "")
                {
                    reference_id4 = Leader_UserID;
                    break;
                }
                reference_id5 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id5"]);
                if (reference_id5 == "")
                {
                    reference_id5 = Leader_UserID;
                    break;
                }
                reference_id6 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id6"]);
                if (reference_id6 == "")
                {
                    reference_id6 = Leader_UserID;
                    break;
                }
                reference_id7 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id7"]);
                if (reference_id7 == "")
                {
                    reference_id7 = Leader_UserID;
                    break;
                }
                reference_id8 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id8"]);
                if (reference_id8 == "")
                {
                    reference_id8 = Leader_UserID;
                    break;
                }
                reference_id9 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id9"]);
                if (reference_id9 == "")
                {
                    reference_id9 = Leader_UserID;
                    break;
                }
                reference_id10 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id10"]);
                if (reference_id10 == "")
                {
                    reference_id10 = Leader_UserID;
                    break;
                }
                reference_id11 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id11"]);
                if (reference_id11 == "")
                {
                    reference_id11 = Leader_UserID;
                    break;
                }

            }

            initialreference = "6dde8c3d-1895-4904-b332-764f63206fc0";
        }
        catch (Exception ex)
        {


        }
    }
    private void PopulateRootLevel()
    {
        string sql1 = "";
        UserName = Convert.ToString(Session["MarketingUser"]);
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        if (UserName == "Admin")
        {
            sql1 = "select usrMobileNo as FullName,'Contact Person= '+usrFirstName+' '+usrLastName +'Mobile No.= '+usrMobileNo as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster" +
                        " on usrUserId =userid where  parentID=0";
            SqlCommand cmd = new SqlCommand(sql1, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodes(dt, TreeView1.Nodes);
        }
        else
        {
            string query = "select roleid from AdminSubMarketingSubUser where friendid='" + UserName + "' and mainRole=1";
            string roleid = cc.ExecuteScalar(query);
            if (roleid == "2")
            {
                sql1 = "select friendid from AdminSubMarketingSubUser where userid='" + UserName + "'  ";
                DataSet ds = cc.ExecuteDataset(sql1);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string userid = Convert.ToString(dr["friendid"]);
                    sql1 = "select usrMobileNo as FullName,'Contact Person= '+usrFirstName+' '+usrLastName +'Mobile No.= '+usrMobileNo as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster on usrUserId =userid where userid='" + userid + "' and parentID=0";
                    SqlCommand cmd = new SqlCommand(sql1, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    PopulateNodes(dt, TreeView1.Nodes);
                }

            }
            else
            {
                string query1 = "select id from Treedemo where userid='" + UserName + "'";
                string parentid = cc.ExecuteScalar(query1);
                sql1 = "select friendid from AdminSubMarketingSubUser where userid='" + UserName + "' and mainRole=1 ";
                DataSet ds = cc.ExecuteDataset(sql1);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string userid = Convert.ToString(dr["friendid"]);
                    sql1 = "select usrMobileNo as FullName,'Contact Person= '+usrFirstName+' '+usrLastName +'Mobile No.= '+usrMobileNo  as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster on usrUserId =userid where userid='" + userid + "' and parentID='" + parentid + "'";
                    SqlCommand cmd = new SqlCommand(sql1, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    PopulateNodes(dt, TreeView1.Nodes);
                }

            }
        }



    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
    {
        //TreeNode tn = new TreeNode();
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr["FullName"].ToString();
            tn.Value = dr["id"].ToString();
            string name = dr["name"].ToString();

            nodes.Add(tn);
            tn.ToolTip = name;
            //int id = Convert.ToInt32(tn.Value.ToString()); 

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
            //int count = Convert.ToInt32(dr["childnodecount"].ToString());
            //if (count >= 0)
            //{
            //    PopulateSubLevel(id, tn);
            //}

        }



    }
    private void PopulateSubLevel(int parentid, TreeNode parentNode)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string sql12 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name, id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster" +
            " on usrUserId =userid where parentID=@parentID";
        SqlCommand cmd = new SqlCommand(sql12, cn);
        cmd.Parameters.Add("@parentID", SqlDbType.Int).Value = parentid;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        PopulateNodes(dt, parentNode.ChildNodes);


    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(Convert.ToInt32(e.Node.Value), e.Node);
        //PopulateSubLevel(e.Node.Value, e.Node);
    }


    protected void gvlist_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //getting username from particular row
            string username = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "usrmobileno"));
            //identifying the control in gridview
            //raising javascript confirmationbox whenver user clicks on link button 
            ImageButton btnimg = (ImageButton)e.Row.FindControl("ImageButton1");
            btnimg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + username + "')");

        }
    }
}



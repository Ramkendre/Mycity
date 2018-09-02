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

public partial class MarketingAdmin_AddJuniors : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    UDISE_AddSubUser addhm = new UDISE_AddSubUser();
    int status;
    string RoleId = "";
    string usrRole = "";
    string initialreference = "", LeaderRoleId = "", LLeaderNo_usrID = "", Leader_RoleName = "", Leader_RoleID = "", Leader_UserID = "", Leader_Leader;
    string reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", userid = "";
    string reference_id6 = "", reference_id7 = "", reference_id8 = "", reference_id9 = "", reference_id10 = "", reference_id11 = "";
    string UserName = "", LeaderNo, schoolcode = "", schoolName = "", fname = "", lname = "";
    int count = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // gridviewshow();           
            //pnl_grade.Visible = false;
            //gvDataCollectionTotalshow();
            LoadRole();
        }
    }

    private void LoadRole()
    {
        string ID = Convert.ToString(Session["MarketingUser"]);
        if (ID == "Admin")
        {
            string vSQl = "select * from  [Come2myCityDB].[come2mycity].[SubMenuPermission] where UnderRole=1";

            DataSet ds = cc.ExecuteDataset(vSQl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlrole.DataSource = ds.Tables[0];
                ddlrole.DataTextField = "RoleName";
                ddlrole.DataValueField = "Roleid";
                ddlrole.DataBind();
                ddlrole.Items.Add("---Select---");
                ddlrole.SelectedIndex = ddlrole.Items.Count - 1;
                               
            }
        }
        else
        {
            loadItem();
        }


    }
    public void loadItem()
    {

        try
        {
            string vSQl = "select distinct asm.roleid,SubMenuPermission.roleid as id, SubMenuPermission.RoleName from  [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser  asm " +
                             " inner join [Come2myCityDB].[come2mycity].SubMenuPermission on [Come2myCityDB].[come2mycity].SubMenuPermission.Roleid=asm.roleid " +
                             " where friendid='" + Convert.ToString(Session["MarketingUser"]) + "'";
           
            DataSet ds = cc.ExecuteDataset(vSQl);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlrole.DataSource = ds.Tables[0];
                ddlrole.DataTextField = "RoleName";
                ddlrole.DataValueField = "id";
                ddlrole.DataBind();
                ddlrole.Items.Add("---Select---");
                ddlrole.SelectedIndex = ddlrole.Items.Count - 1;
                ddlrole.Items[ddlrole.Items.Count - 1].Value = "";
                string sqlexe = "select roleid from [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser where friendid='" + Convert.ToString(Session["MarketingUser"]) + "' and  mainrole=1 ";
                string roleid = cc.ExecuteScalar(sqlexe);
                ddlrole.SelectedValue = roleid;
                Session["RoleIdUpdate"] = roleid;
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void gvshow()
    {
        string mobileno = txtmobileno.Text;
        string sql = "select usrUserid,usrFirstName+''+usrLastName as FullName,usrMobileNo,usrCity from usermaster where usrMobileNo='" + mobileno + "'";
        DataSet ds = cc.ExecuteDataset(sql);


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string userid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
            Session["frienduserid"] = userid;
            lblName.Text = Convert.ToString(dr["FullName"]);
            lblCelNumber.Text = Convert.ToString(dr["usrMobileNo"]);
            lblCity.Text = Convert.ToString(dr["usrCity"]);
        }


        if (ds.Tables[0] == null)
        {
            //lblName.Visible = true;
            //lblName1.Visible = true;
            //lblCelNumber.Visible = true;
            //lblCelNumber1.Visible = true;
            //lblCity.Visible = true;
            //lblCity1.Visible = true;

            //lblassRole.Visible = true;
            //ddlAssignRole.Visible = true;
            //btnSubmit.Visible = true;
            pnl_grade.Visible = false;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Not found')", true);
            Response.Write("<script>(alert)('Record Not found')</script>");

        }
        else
        {
            pnl_grade.Visible = true;



        }
    }

    private void gvshow1()
    {
        string mobileno = txtmobileno.Text; //= TextBox1.Text;
        string sql = "select usrUserid,usrFirstName+''+usrLastName as FullName,usrMobileNo,usrCity from usermaster where usrMobileNo='" + mobileno + "'";
        DataSet ds = cc.ExecuteDataset(sql);


        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string userid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
            Session["frienduserid"] = userid;
            lblName.Text = Convert.ToString(dr["FullName"]);
            lblCelNumber.Text = Convert.ToString(dr["usrMobileNo"]);
            lblCity.Text = Convert.ToString(dr["usrCity"]);
        }


        if (ds.Tables[0] == null)
        {

            pnl_grade.Visible = false;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Not found')", true);
            Response.Write("<script>(alert)('Record Not found')</script>");

        }
        else
        {
            pnl_grade.Visible = true;



        }
    }






    private void info()
    {
        UserName = Convert.ToString(Session["MarketingUser"]);
        string sql = "select UseRole,RoeId from [Come2myCityDB].[come2mycity].MartketingSubuser where Uid1='" + UserName + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            usrRole = Convert.ToString(ds.Tables[0].Rows[0]["UseRole"]);

            RoleId = Convert.ToString(ds.Tables[0].Rows[0]["RoeId"]);


        }
        initialreference = "6dde8c3d-1895-4904-b332-764f63206fc0";

    }
    private void info12()
    {
        string sqlfetch = "select userid,roleid,rolename,reference_id2,reference_id3,reference_id4,reference_id5 from [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser where friendid='" + UserName + "'";
        DataSet ds1 = cc.ExecuteDataset(sqlfetch);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
            userid = Convert.ToString(ds1.Tables[0].Rows[0]["userid"]);
            RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
            reference_id2 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id2"]);
            if (reference_id2 == "")
            {
                reference_id2 = userid;
                break;
            }

            reference_id3 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id3"]);
            if (reference_id3 == "")
            {
                reference_id3 = userid;
                break;
            }

            reference_id4 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id4"]);
            if (reference_id4 == "")
            {
                reference_id4 = userid;
                break;
            }
            reference_id5 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id5"]);
            if (reference_id5 == "")
            {
                reference_id5 = userid;
                break;
            }



        }

        initialreference = "6dde8c3d-1895-4904-b332-764f63206fc0";
    }
    private void info121()
    {
        string sqlfetch = "select userid,roleid,rolename,reference_id2,reference_id3,reference_id4,reference_id5 from AddSubUserSameLevel where friendid='" + UserName + "'";
        DataSet ds1 = cc.ExecuteDataset(sqlfetch);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            usrRole = Convert.ToString(ds1.Tables[0].Rows[0]["rolename"]);
            userid = Convert.ToString(ds1.Tables[0].Rows[0]["userid"]);
            RoleId = Convert.ToString(ds1.Tables[0].Rows[0]["roleid"]);
            reference_id2 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id2"]);
            if (reference_id2 == "")
            {
                reference_id2 = userid;
                break;
            }

            reference_id3 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id3"]);
            if (reference_id3 == "")
            {
                reference_id3 = userid;
                break;
            }

            reference_id4 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id4"]);
            if (reference_id4 == "")
            {
                reference_id4 = userid;
                break;
            }
            reference_id5 = Convert.ToString(ds1.Tables[0].Rows[0]["reference_id5"]);
            if (reference_id5 == "")
            {
                reference_id5 = userid;
                break;
            }

        }

        initialreference = "6dde8c3d-1895-4904-b332-764f63206fc0";
    }

    private void gridviewshow()
    {
        UserName = Convert.ToString(Session["MarketingUser"]);
        if (UserName == "Admin")
        {
            UserName = "6dde8c3d-1895-4904-b332-764f63206fc0";
        }
        if (UserName == null || UserName == "")
        {
            Response.Redirect("../MarketingAdmin/login.aspx");
        }
        else
        {

            string sql = "select id,friendid,SubMenuPermission.RoleName,usrFirstName+' '+usrLastName as FullName,usrMobileNo,usrCity ,AdminSubMarketingSubUser.Active,AdminSubMarketingSubUser.Mainrole,AdminSubMarketingSubUser.Location from usermaster inner join [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser on usermaster.usrUserid=AdminSubMarketingSubUser.friendid inner join [Come2myCityDB].[come2mycity].SubMenuPermission on AdminSubMarketingSubUser.Roleid=SubMenuPermission.Roleid where AdminSubMarketingSubUser.userid='" + UserName + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvdisplay.DataSource = ds.Tables[0];
                gvdisplay.DataBind();
                gvdisplay.Visible = true;
                gvsubordinat.Visible = false;
            }
            else
            {
                //gvdisplay.DataSource = null;
                gvsubordinat.Visible = false;

            }
            if (ds.Tables[0] == null)
            {

                pnl_grade.Visible = false;

            }
            else
            {
                pnl_grade.Visible = true;



            }
        }
    }
    private void gridviewshow1()
    {
        UserName = Convert.ToString(Session["MarketingUser"]);
        if (UserName == "Admin")
        {
            UserName = "6dde8c3d-1895-4904-b332-764f63206fc0";
        }
        if (UserName == null || UserName == "")
        {
            Response.Redirect("../MarketingAdmin/login.aspx");
        }
        else
        {

            string Roleid = Convert.ToString(Session["RoleIdUpdate"]);
            string Checkref = "";
            //string cref = "select userid from [AdminSubMarketingSubOrdinate] where  [AdminSubMarketingSubOrdinate].friendid='" + UserName + "'";
            //Checkref = cc.ExecuteScalar(cref); // check juniour already assign
            // string sql = "select friendid,SubMenuPermission.RoleName,usrFirstName+''+usrLastName as FullName,usrMobileNo,usrCity ,AdminSubMarketingSubUser.Active from usermaster inner join AdminSubMarketingSubUser on usermaster.usrUserid=AdminSubMarketingSubUser.friendid inner join SubMenuPermission on AdminSubMarketingSubUser.Roleid=SubMenuPermission.Roleid where AdminSubMarketingSubUser.userid='" + Checkref + "' and AdminSubMarketingSubUser.roleid='" + Roleid + "'";
            string sql;
            UserName = Convert.ToString(Session["MarketingUser"]);
            if (UserName == "Admin")
            {
                UserName = "6dde8c3d-1895-4904-b332-764f63206fc0";
                sql = "select id,friendid,SubMenuPermission.RoleName,usrFirstName+' '+usrLastName as FullName,usrMobileNo,usrCity,AdminSubMarketingSubOrdinate.Active,Location from usermaster inner join [Come2myCityDB].[dbo].AdminSubMarketingSubOrdinate on usermaster.usrUserid=AdminSubMarketingSubOrdinate.friendid inner join [Come2myCityDB].[come2mycity].SubMenuPermission on AdminSubMarketingSubOrdinate.Roleid=SubMenuPermission.Roleid where AdminSubMarketingSubOrdinate.userid='" + UserName + "' and AdminSubMarketingSubOrdinate.roleid='" + Roleid + "'";
            }
            else
            {
                //   sql = " select userid, id,friendid,SubMenuPermission.RoleName,usrFirstName+' '+usrLastName as FullName,usrMobileNo,usrCity,AdminSubMarketingSubOrdinate.Active from usermaster inner join AdminSubMarketingSubOrdinate on usermaster.usrUserid=AdminSubMarketingSubOrdinate.friendid inner join SubMenuPermission on AdminSubMarketingSubOrdinate.Roleid=SubMenuPermission.Roleid  " +
                //"where   userid in ( select userid  from AdminSubMarketingSubUser where " +
                // "AdminSubMarketingSubUser.friendid='" + UserName + "' " +
                //   "and AdminSubMarketingSubUser.roleid='" + Roleid + "')";
                sql = "select id,friendid,SubMenuPermission.RoleName,usrFirstName+' '+usrLastName as FullName,usrMobileNo,usrCity,AdminSubMarketingSubOrdinate.Active ,Location from usermaster inner join [Come2myCityDB].[dbo].AdminSubMarketingSubOrdinate on usermaster.usrUserid=AdminSubMarketingSubOrdinate.friendid inner join [Come2myCityDB].[come2mycity].SubMenuPermission on AdminSubMarketingSubOrdinate.Roleid=SubMenuPermission.Roleid where AdminSubMarketingSubOrdinate.Parent='" + UserName + "' and AdminSubMarketingSubOrdinate.roleid='" + Roleid + "'";

            }

            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvsubordinat.DataSource = ds.Tables[0];
                gvsubordinat.DataBind();
                gvsubordinat.Visible = true;
                gvdisplay.Visible = false;
            }
            else
            {
                //gvsubordinat.DataSource = null;
                gvdisplay.Visible = false;

            }
            if (ds.Tables[0] == null)
            {

                pnl_grade.Visible = false;

            }
            else
            {
                pnl_grade.Visible = true;



            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtmobileno.Text == "" || txtmobileno.Text == null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz Enter MobileNo..!!'')", true);
            Response.Write("<script>(alert)('Plz Enter MobileNo..!!')</script>");

        }
        else
        {
            if (rdb1.Checked == true)
            {
                gvdisplay.DataSource = null;
                gvshow();
                gridviewshow();
            }
            else if (rdb2.Checked == true)
            {
                gvdisplay.DataSource = null;
                gvshow1();
                gridviewshow1();
            }

        }

    }

    private void AddNewUser_Sublevel(string JuniorNo, string leader_no)
    {

        try
        {
            LeaderNo = leader_no; // use for common All code
            string getuserID_Leader = "select usrUserid from usermaster where usrMobileNo='" + LeaderNo + "'";
            Leader_UserID = cc.ExecuteScalar(getuserID_Leader); // get Leader usruserID
            if (Leader_UserID == "Admin")
            {
                string sql = "select MobileNo from Marketinguser1 where UserId='" + UserName + "'";
                string mobileno = cc.ExecuteScalar(sql);
                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                Leader_UserID = cc.ExecuteScalar(sql1);
            }
            else
            {
                info_Sublevel();
            }
            string JusrID = "select usruserid from usermaster where usrMobileNo='" + JuniorNo + "'";
            string JuniorNo_usrID = cc.ExecuteScalar(JusrID); // get juniour usrUserID
            string date_ofJoin = "", JuniorRoleID = "", JuniorRoleName = "", reference_id1 = "";
            date_ofJoin = DateTime.Now.Date.ToString(); // get current date
            reference_id1 = initialreference; // add Administrator reference 
            if (Leader_RoleID == "")
            {
                UserName = Convert.ToString(Session["MarketingUser"]);
                if (UserName == "Admin")
                {
                    Leader_RoleID = "1";
                }
            }
            string GetJRoleID = "select Roleid ,RoleName from [Come2myCityDB].[come2mycity].SubMenuPermission where UnderRole='" + Leader_RoleID + "'";
            DataSet ds = cc.ExecuteDataset(GetJRoleID); // get juniour RoleID & Role Name
            if (ds.Tables[0].Rows.Count > 0)
            {
                JuniorRoleID = Convert.ToString(ds.Tables[0].Rows[0]["Roleid"]);
                JuniorRoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            }
            string sql21 = "select id from [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and Active='1' ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                Response.Write("<script>(alert)('This User is already subuser of other, You cannot assign ')</script>");
            }
            else
            {
                string cref = "";
                string Checkref = "";
                if (JuniorRoleID == "76")
                // if (JuniorRoleID == "41")
                {
                    cref = "select friendid from [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and friendid = '" + JuniorNo_usrID + "' and Active='1'";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign
                }
                else
                {
                    cref = "select friendid from [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "'  and friendid = '" + JuniorNo_usrID + "' and Active='1'";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign

                }

                if (!(Checkref == null || Checkref == ""))
                {
                    if (Checkref != JuniorNo_usrID)
                    {
                        string SQL = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "'  where userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                        int a = cc.ExecuteNonQuery(SQL);
                        string qry;
                        int status;
                        if (a == 1)
                        {
                            if (reference_id2 == "")
                            {
                                qry = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set reference_id2='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and  reference_id1='" + reference_id1 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);

                            }
                            if (reference_id3 == "")
                            {
                                qry = "update[Come2myCityDB].[come2mycity]. AdminSubMarketingSubUser set reference_id3='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id4 == "")
                            {
                                qry = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set reference_id4='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + Checkref + "'";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id5 == "")
                            {
                                qry = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set reference_id5='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id6 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id6='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id7 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id7='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id8 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id8='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id9 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id9='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id10 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id10='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id11 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(Checkref) + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                        }
                    }

                }
                else
                {

                    string AddJunior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Location)" +
                          " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','UploadHMLIST','1','" + txtplace.Text + "' )";
                    string exe = cc.ExecuteScalar(AddJunior); // Add Juniour  Under his Leader
                    string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + JuniorNo_usrID + "'";
                    string a = cc.ExecuteScalar(sqlupdate); // allow permission is Marketing person i.e allow go to admin side.

                    string query = "select id from TreeDemo where userid='" + Leader_UserID + "' ";
                    string CheckTree = cc.ExecuteScalar(query); // Get leader ID already add in tree digrame
                    if (!(CheckTree == null || CheckTree == ""))
                    {

                        // string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' and id=" + CheckTree + " ";
                        string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "'";

                        string GetID = cc.ExecuteScalar(check_Available); // check leader ID & Juniour Is already define or Not
                        if (!(GetID == null || GetID == ""))
                        {
                            //alredy Add in tree
                        }
                        else
                        {
                            string Addtree = "insert into TreeDemo(userid,parentid)values('" + JuniorNo_usrID + "','" + CheckTree + "')";
                            string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                        }
                    }
                    else
                    {

                        // if leader not add in tree diagram
                        //string Addtree = "insert into TreeDemo(userid,parentid)values('" + Leader_UserID + "','" + CheckTree + "')";
                        //string b = cc.ExecuteScalar(Addtree);


                    }
                }

                if (JuniorRoleID == "76" || JuniorRoleID == "76")
                // if (JuniorRoleID == "41" || JuniorRoleID == "41")
                {
                    string sql = "select SchoolId from UDISE_SchoolMaster  inner join UDISE_TeacherMaster on UDISE_TeacherMaster.SchoolCode=UDISE_SchoolMaster.SchoolCode   where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' and UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' ";
                    string id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        string Management = "", SchoolType = "", Classes = "";

                        string sql1 = "select SchoolId from UDISE_SchoolMaster  where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' ";
                        string id1 = cc.ExecuteScalar(sql);
                        if (id1 == "" || id1 == null)
                        {
                            sql = "insert into UDISE_SchoolMaster(SchoolCode,SchoolName,Management,SchoolType,Classes) values('" + schoolcode + "','" + schoolName + "','" + Management + "','" + SchoolType + "','" + Classes + "')";
                            int a1 = cc.ExecuteNonQuery(sql);
                        }
                        //string SQLA = "select friendid from AdminSubMarketingSubUser where roleid='" + JuniorRoleID + "' and friendid= '" + Leader_UserID + "' ";
                        //string HM_ID = cc.ExecuteScalar(SQLA);
                        string usrclass = "", section = "";
                        addhm.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, 1);

                    }
                    else
                    {
                        string usrclass = "", section = "";
                        addhm.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, 1);
                    }

                }
                else
                {


                }
            }
        }
        catch (Exception ex)
        {


        }

    }


    private void AddNewUser_Sublevel1(string JuniorNo, string leader_no, string LeaderLeaderNo, int LeaderRoleNo)
    {

        try
        {
            LeaderNo = leader_no; // use for common All code
            string getuserID_Leader = "select usrUserid from usermaster where usrMobileNo='" + LeaderNo + "'";
            Leader_UserID = cc.ExecuteScalar(getuserID_Leader); // get Leader usruserID
            string LeaderNo_usrID = Leader_UserID;// get Leader usruserID
            if (Leader_UserID == "Admin")
            {
                string sql = "select MobileNo from Marketinguser1 where UserId='" + UserName + "'";
                string mobileno = cc.ExecuteScalar(sql);
                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                Leader_UserID = cc.ExecuteScalar(sql1);
            }
            else
            {
                string LLeaderID = "select usruserid , Roleid from usermaster inner join AdminSubMarketingSubUser on UserMaster.usrUserId=AdminSubMarketingSubUser.userid where usrMobileNo='" + LeaderLeaderNo + "' and Roleid=" + LeaderRoleNo + " and Friendid='" + LeaderNo_usrID + "'";
                DataSet ds1 = cc.ExecuteDataset(LLeaderID); // get juniour RoleID & Role Name
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    LLeaderNo_usrID = Convert.ToString(ds1.Tables[0].Rows[0]["usruserid"]);
                    LeaderRoleId = Convert.ToString(ds1.Tables[0].Rows[0]["Roleid"]);
                }

                info_Sublevel1();
            }
            string JusrID = "select usruserid from usermaster where usrMobileNo='" + JuniorNo + "'";
            string JuniorNo_usrID = cc.ExecuteScalar(JusrID); // get juniour usrUserID
            string date_ofJoin = "", JuniorRoleID = "", JuniorRoleName = "", reference_id1 = "";
            date_ofJoin = DateTime.Now.Date.ToString(); // get current date
            reference_id1 = initialreference; // add Administrator reference 

            string GetJRoleID = "select Roleid ,RoleName from SubMenuPermission where UnderRole='" + Leader_RoleID + "'";
            DataSet ds = cc.ExecuteDataset(GetJRoleID); // get juniour RoleID & Role Name
            if (ds.Tables[0].Rows.Count > 0)
            {
                JuniorRoleID = Convert.ToString(ds.Tables[0].Rows[0]["Roleid"]);
                JuniorRoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            }

            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and roleid='" + JuniorRoleID + "' and userid='" + Leader_UserID + "'";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                //Response.Write("<script>(alert)('This User is already subuser of other, You cannot assign ')</script>");
                //string Sql = "select usrMobileNo from UserMaster inner join AdminSubMarketingSubUser as asp on asp.userid=UserMaster.usrUserId where asp.friendid='" + JuniorNo_usrID + "' and asp.Active='1'";
                //string lmobileNo = cc.ExecuteScalar(Sql); // get leader mobile no.
                //if (leader_no != lmobileNo)
                //{
                //    count = count + 1;
                //    lblerror.Visible = true;
                //    lblerror.Text = lblerror.Text + "<br>'" + JuniorNo + "' This User is already subuser under'" + lmobileNo + "'. Error on Rows No " + count + " ";
                //}
            }
            else
            {

                string SqlChkActive = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and Active=1 and Mainrole=1";
                string ChkActive = cc.ExecuteScalar(SqlChkActive); // check juniour already assign
                if (ChkActive == "" || ChkActive == null)
                {

                    string SqlChkActiveRole = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and roleid='" + JuniorRoleID + "'";
                    string ChkActiveRole = cc.ExecuteScalar(SqlChkActiveRole); // check juniour already assign
                    if (ChkActive == "" || ChkActive == null)
                    {
                        string AddJunior = "update AdminSubMarketingSubUser set Mainrole=0 where friendid='" + JuniorNo_usrID + "' ";
                        int Data1 = 0;
                        Data1 = cc.ExecuteNonQuery(AddJunior); // check school code registered or not.
                        if (Data1 >= 1)
                        {
                            Replacereference(JuniorRoleID, JuniorNo_usrID, reference_id1, Leader_UserID); // chnage reference 
                        }
                        string Junior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Mainrole)" +
                                    " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','UploadHMLIST','1','1' )";
                        string exe = cc.ExecuteScalar(Junior); // Add Juniour  Under his Leader

                    }
                    else
                    {
                        string AddJunior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Mainrole)" +
                                        " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','UploadHMLIST','0' ,'0')";
                        string exe = cc.ExecuteScalar(AddJunior); // Add Juniour  Under his Leader
                    }
                }
                else
                {
                    string AddJunior = "update AdminSubMarketingSubUser set Mainrole=0 where friendid='" + JuniorNo_usrID + "' ";
                    int Data1 = 0;
                    Data1 = cc.ExecuteNonQuery(AddJunior); // check school code registered or not.
                    if (Data1 >= 1)
                    {
                        Replacereference(JuniorRoleID, JuniorNo_usrID, reference_id1, Leader_UserID); // chnage reference 
                    }
                    string Junior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Mainrole)" +
                                       " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','UploadHMLIST','1','1' )";
                    string exe = cc.ExecuteScalar(Junior); // Add Juniour  Under his Leader

                }
                string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + JuniorNo_usrID + "'";
                string a = cc.ExecuteScalar(sqlupdate); // allow permission is Marketing person i.e allow go to admin side.

                string query = "select id from TreeDemo where userid='" + Leader_UserID + "' and Roleid=" + LeaderRoleId + "";
                string CheckTree = cc.ExecuteScalar(query); // Get leader ID already add in tree digrame
                if (!(CheckTree == null || CheckTree == ""))
                {
                    LeaderRoleId = "";
                    // string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' and id=" + CheckTree + " ";
                    string check_Available = "select parentid from TreeDemo where userid='" + JuniorNo_usrID + "' and Roleid=" + JuniorRoleID + "";

                    string GetID = cc.ExecuteScalar(check_Available); // check leader ID & Juniour Is already define or Not
                    if (!(GetID == null || GetID == ""))
                    {
                        if (CheckTree == GetID)
                        {
                            //Not 
                        }
                        else
                        {
                            string Addtree = "insert into TreeDemo(userid,parentid,RoleId)values('" + JuniorNo_usrID + "','" + CheckTree + "'," + JuniorRoleID + ")";
                            string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                        }
                    }
                    else
                    {
                        string Addtree = "insert into TreeDemo(userid,parentid,RoleId)values('" + JuniorNo_usrID + "','" + CheckTree + "'," + JuniorRoleID + ")";
                        string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                    }
                }
                else
                {

                    // if leader not add in tree diagram
                    //string Addtree = "insert into TreeDemo(userid,parentid)values('" + Leader_UserID + "','" + CheckTree + "')";
                    //string b = cc.ExecuteScalar(Addtree);


                }

            }
            // if (JuniorRoleID == "15" || JuniorRoleID == "16" || JuniorRoleID == "17" || JuniorRoleID == "18" || JuniorRoleID == "19" || JuniorRoleID == "20" || JuniorRoleID == "21" || JuniorRoleID == "75" || JuniorRoleID == "76")
            if (JuniorRoleID == "76")
            {

                string sql = "select SchoolId from UDISE_SchoolMaster  inner join UDISE_TeacherMaster on UDISE_TeacherMaster.SchoolCode=UDISE_SchoolMaster.SchoolCode   where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' and UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' ";
                string id = cc.ExecuteScalar(sql);// check Hm Registered Or Not
                if (id == "" || id == null)
                {
                    string Management = "", SchoolType = "", Classes = "";
                    string sql1 = "select SchoolId from UDISE_SchoolMaster  where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' ";
                    int Data1 = 0;
                    Data1 = cc.ExecuteScalar1(sql1); // check school code registered or not.
                    if (Data1 != null && Data1 <= 1)
                    {
                        sql = "insert into UDISE_SchoolMaster(SchoolCode,SchoolName,Management,SchoolType,Classes) values('" + schoolcode + "','" + schoolName + "','" + Management + "','" + SchoolType + "','" + Classes + "')";
                        int a1 = cc.ExecuteNonQuery(sql);// insert new school code
                    }
                    string usrclass = "", section = "";
                    addhm.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                    sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(Session["MobileNumber"]) + "' ,Ref_Ways='HMUPloadList' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                    int ad = cc.ExecuteNonQuery(sql);

                }
                else
                {
                    string usrclass = "", section = "";
                    addhm.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                    sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(Session["MobileNumber"]) + "' ,Ref_Ways='HMUPloadList' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                    int ad = cc.ExecuteNonQuery(sql);
                }

            }
            else
            {


            }
        }
        catch (Exception ex)
        {


        }

    }

    public void Replacereference(string JuniorRoleID, string JuniorNo_usrID, string reference_id1, string Leader_UserID)
    {
        try
        {
            string cref = "";
            string Checkref = "";

            cref = "select userid from AdminSubMarketingSubUser where roleid=" + JuniorRoleID + " and   friendid ='" + JuniorNo_usrID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and MainRole=0";
            Checkref = cc.ExecuteScalar(cref); // check juniour already assign
            if (!(Checkref == null || Checkref == ""))
            {

                string JJuniorRole_SQL = "select Roleid from SubMenuPermission  where UnderRole='" + JuniorRoleID + "' ";
                string JJuniorRoleID = cc.ExecuteScalar(JJuniorRole_SQL);// check Hm Registered Or Not

                if (Checkref != Leader_UserID)
                {
                    string qry = "";
                    if (reference_id2 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id1='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and   reference_id1='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);

                    }
                    if (reference_id3 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id2='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and   reference_id1='" + reference_id2 + "' and reference_id2='" + Checkref + "'and roleid='" + JJuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id4 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id3='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) "; // 75 


                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id5 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id4='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'  reference_id4='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))))) "; // 76

                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id6 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and  roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in(select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id5='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and  reference_id5='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in(select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')))) ";


                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id7 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  "; // 21
                        qry = qry + "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75 
                        qry = qry + "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76
                        qry = qry + "update AdminSubMarketingSubUser set reference_id6='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and reference_id6='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole in(select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "'))) ";

                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id8 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id7='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + "update AdminSubMarketingSubUser set reference_id7='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75
                        qry = qry + "update AdminSubMarketingSubUser set reference_id7='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST'  where Mainrole=1 and   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' and roleid in (select Roleid  from SubMenuPermission where UnderRole in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "')) "; // 76


                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id9 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id8='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'  and  reference_id8='" + Checkref + "'  and roleid='" + JJuniorRoleID + "'  ";
                        qry = qry + " update AdminSubMarketingSubUser set reference_id8='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'  and  reference_id8='" + Checkref + "'  and roleid in (select Roleid  from SubMenuPermission where UnderRole='" + JJuniorRoleID + "') "; // 75

                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id10 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id9='" + Leader_UserID + "'  ,Ref_Ways='UploadHMLIST' where  Mainrole=1 and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and reference_id9='" + Checkref + "' and roleid='" + JJuniorRoleID + "'  "; //75
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }
                    if (reference_id11 == "")
                    {
                        qry = "update AdminSubMarketingSubUser set reference_id10='" + Leader_UserID + "' ,Ref_Ways='UploadHMLIST' where Mainrole=1 and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "'  and reference_id10='" + Convert.ToString(Checkref) + "'  and roleid='" + JJuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";
                        //qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and roleid='" + JuniorRoleID + "'  ";

                        status = cc.ExecuteNonQuery(qry);


                    }

                }
            }



        }
        catch (Exception ex)
        {
            throw ex;
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
        // Leader_UserID = "";
        LLeaderNo_usrID = "";
        //LeaderRoleId = "";
    }
    private void info_Sublevel1()
    {
        try
        {


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + Leader_UserID + "' and userid='" + LLeaderNo_usrID + "' and Roleid='" + LeaderRoleId + "'";

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
    private void AddNewUser_Somelevel(string JuniorNo, string L_UserId)
    {

        try
        {

            Leader_UserID = L_UserId; // use for common All code
            string getuserID_Leader = "select usrMobileNo from usermaster where usrUserid='" + Leader_UserID + "'";
            LeaderNo = cc.ExecuteScalar(getuserID_Leader); // get Leader MobileNo  
            if (Leader_UserID == "Admin")
            {
                string sql = "select MobileNo from Marketinguser1 where UserId='" + UserName + "'";
                string mobileno = cc.ExecuteScalar(sql);
                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                Leader_UserID = cc.ExecuteScalar(sql1);
            }
            else
            {
                info_Somelevel();
            }
            string JusrID = "select usruserid from usermaster where usrMobileNo='" + JuniorNo + "'";
            string JuniorNo_usrID = cc.ExecuteScalar(JusrID); // get juniour usrUserID
            string date_ofJoin = "", JuniorRoleID = "", JuniorRoleName = "", reference_id1 = "";
            date_ofJoin = DateTime.Now.Date.ToString(); // get current date
            reference_id1 = initialreference; // add Administrator reference 

            if (Leader_RoleID == "")
            {
                UserName = Convert.ToString(Session["MarketingUser"]);
                if (UserName == "Admin")
                {
                    Leader_RoleID = "0";
                }
            }

            string GetJRoleID = "select Roleid ,RoleName from SubMenuPermission where UnderRole='" + Leader_RoleID + "'";
            DataSet ds = cc.ExecuteDataset(GetJRoleID); // get juniour RoleID & Role Name
            if (ds.Tables[0].Rows.Count > 0)
            {
                JuniorRoleID = Convert.ToString(ds.Tables[0].Rows[0]["Roleid"]);
                JuniorRoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            }
            // string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and userid='" + Leader_Leader + "'  ";

            string sql21 = "select id from AdminSubMarketingSubOrdinate where friendid='" + JuniorNo_usrID + "' and userid='" + Leader_UserID + "'  and Parent='" + UserName + "' and Roleid=" + JuniorRoleID + " ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                Response.Write("<script>(alert)('This User is already subuser of other, You cannot assign ')</script>");
            }
            else
            {

                string cref = "";
                string Checkref = "";
                if (JuniorRoleID == "76")
                //      if (JuniorRoleID == "41")
                {
                    cref = "select friendid from AdminSubMarketingSubOrdinate where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and friendid = '" + JuniorNo_usrID + "' and Active='1'";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign
                }
                else
                {
                    cref = "select friendid from AdminSubMarketingSubOrdinate where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and   friendid = '" + JuniorNo_usrID + "' and Active='1' ";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign

                }

                if (!(Checkref == null || Checkref == ""))
                {
                    if (Checkref != JuniorNo_usrID)
                    {
                        string SQL = "update AdminSubMarketingSubOrdinate set friendid='" + JuniorNo_usrID + "' , Ref_Ways='UpdateHMLIST' , Active='1'   where userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "'  ";
                        int a = cc.ExecuteNonQuery(SQL);
                        string qry;
                        int status;
                        if (a == 1)
                        {
                            if (reference_id2 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id2='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and  reference_id1='" + reference_id1 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);

                            }
                            if (reference_id3 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id3='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id4 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id4='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + Checkref + "' '";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id5 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id5='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id6 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id6='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id7 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id7='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id8 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id8='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id9 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id9='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id10 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id10='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + Checkref + "'";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id11 == "")
                            {
                                qry = "update AdminSubMarketingSubOrdinate set reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(Checkref) + "'  ";
                                qry = qry + "update AdminSubMarketingSubOrdinate set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                        }
                    }


                    else
                    {

                        UserName = Convert.ToString(Session["MarketingUser"]);
                        string AddJunior = "insert into AdminSubMarketingSubOrdinate(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Parent,Location)" +
                               " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','UploadHMLIST','1','" + UserName + "','" + txtplace.Text + "' )";
                        string exe = cc.ExecuteScalar(AddJunior); // Add Juniour  Under his Leader
                        string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + JuniorNo_usrID + "'";
                        string a = cc.ExecuteScalar(sqlupdate); // allow permission is Marketing person i.e allow go to admin side.

                        //string query = "select id from TreeDemo where userid='" + Leader_UserID + "' ";
                        //string CheckTree = cc.ExecuteScalar(query); // Get leader ID already add in tree digrame
                        //if (!(CheckTree == null || CheckTree == ""))
                        //{

                        //    // string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' and id=" + CheckTree + " ";
                        //    string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "'";

                        //    string GetID = cc.ExecuteScalar(check_Available); // check leader ID & Juniour Is already define or Not
                        //    if (!(GetID == null || GetID == ""))
                        //    {
                        //        //alredy Add in tree
                        //    }
                        //    else
                        //    {
                        //        string Addtree = "insert into TreeDemo(userid,parentid)values('" + JuniorNo_usrID + "','" + CheckTree + "')";
                        //        string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                        //    }
                        //}
                        //else
                        //{

                        //    // if leader not add in tree diagram
                        //    //string Addtree = "insert into TreeDemo(userid,parentid)values('" + Leader_UserID + "','" + CheckTree + "')";
                        //    //string b = cc.ExecuteScalar(Addtree);


                        //}
                    }
                }
                if (JuniorRoleID == "76" || JuniorRoleID == "76")
                // if (JuniorRoleID == "41" || JuniorRoleID == "41")
                {
                    string sql = "select SchoolId from UDISE_SchoolMaster  inner join UDISE_TeacherMaster on UDISE_TeacherMaster.SchoolCode=UDISE_SchoolMaster.SchoolCode   where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' and UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' ";
                    string id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        string Management = "", SchoolType = "", Classes = "";

                        string sql1 = "select SchoolId from UDISE_SchoolMaster  where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' ";
                        string id1 = cc.ExecuteScalar(sql);
                        if (id1 == "" || id1 == null)
                        {
                            sql = "insert into UDISE_SchoolMaster(SchoolCode,SchoolName,Management,SchoolType,Classes) values('" + schoolcode + "','" + schoolName + "','" + Management + "','" + SchoolType + "','" + Classes + "')";
                            int a1 = cc.ExecuteNonQuery(sql);
                        }
                        //string SQLA = "select friendid from AdminSubMarketingSubUser where roleid='" + JuniorRoleID + "' and friendid= '" + Leader_UserID + "' ";
                        //string HM_ID = cc.ExecuteScalar(SQLA);
                        string usrclass = "", section = "";
                        addhm.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, 1);

                    }
                    else
                    {
                        string usrclass = "", section = "";
                        addhm.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, 1);
                    }

                }
                else
                {

                    UserName = Convert.ToString(Session["MarketingUser"]);
                    string AddJunior = "insert into AdminSubMarketingSubOrdinate(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Parent,Location)" +
                           " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','AddJunior','1','" + UserName + "','" + txtplace.Text + "' )";
                    string exe = cc.ExecuteScalar(AddJunior); // Add Juniour  Under his Leader
                    string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + JuniorNo_usrID + "'";
                    string a = cc.ExecuteScalar(sqlupdate); // allow permission is Marketing person i.e allow go to admin side.

                }
            }
        }
        catch (Exception ex)
        {


        }

    }
    private void Replace_juniors(string JuniorNoOld, string JuniorNoNew, string leader_no)
    {

        try
        {
            LeaderNo = leader_no; // use for common All code
            string getuserID_Leader = "select usrUserid from usermaster where usrMobileNo='" + LeaderNo + "'";
            Leader_UserID = cc.ExecuteScalar(getuserID_Leader); // get Leader usruserID
            if (Leader_UserID == "Admin")
            {
                string sql = "select MobileNo from Marketinguser1 where UserId='" + UserName + "'";
                string mobileno = cc.ExecuteScalar(sql);
                string sql1 = "select usrUserid from usermaster where usrMobileNo='" + mobileno + "'";
                Leader_UserID = cc.ExecuteScalar(sql1);
            }
            else
            {
                info_Sublevel();
            }
            string JusrID = "select usruserid from usermaster where usrMobileNo='" + JuniorNoNew + "'";
            string JuniorNo_usrID = cc.ExecuteScalar(JusrID); // get juniour usrUserID
            string date_ofJoin = "", JuniorRoleID = "", JuniorRoleName = "", reference_id1 = "";
            date_ofJoin = DateTime.Now.Date.ToString(); // get current date
            reference_id1 = initialreference; // add Administrator reference 

            if (Leader_RoleID == "")
            {
                UserName = Convert.ToString(Session["MarketingUser"]);
                if (UserName == "Admin")
                {
                    Leader_RoleID = "0";
                }
            }
            string GetJRoleID = "select Roleid ,RoleName from SubMenuPermission where UnderRole='" + Leader_RoleID + "'";
            DataSet ds = cc.ExecuteDataset(GetJRoleID); // get juniour RoleID & Role Name
            if (ds.Tables[0].Rows.Count > 0)
            {
                JuniorRoleID = Convert.ToString(ds.Tables[0].Rows[0]["Roleid"]);
                JuniorRoleName = Convert.ToString(ds.Tables[0].Rows[0]["RoleName"]);
            }
            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if ((Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                // Response.Write("<script>(alert)('This User is already subuser of other, You cannot assign ')</script>");
                // addhm.AddSubUser(JuniorNoNew, fname, lname, schoolcode, ClassName, Section, Leader_UserID);


            }
            else
            {

                string cref = "";
                string Checkref = "";
                if (JuniorRoleID == "77")
                {
                    cref = "select friendid from AdminSubMarketingSubUser where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and friendid = '" + JuniorNo_usrID + "' and Active='1' ";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign
                }
                else
                {
                    cref = "select friendid from AdminSubMarketingSubUser where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and   friendid = '" + JuniorNo_usrID + "'";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign

                }
                if (!(Checkref == null || Checkref == ""))
                {
                    if (Checkref != JuniorNo_usrID)
                    {
                        string SQL = "update AdminSubMarketingSubUser set  Active='0'  where  friendid='" + Checkref + "' and  userid='" + Leader_UserID + "'  and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                        SQL = SQL + "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Active='1'  where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                        int a = cc.ExecuteNonQuery(SQL);
                        string qry;
                        int status;
                        if (a == 1)
                        {
                            if (reference_id2 == "")
                            {

                                qry = "update AdminSubMarketingSubUser set reference_id2='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and  reference_id1='" + reference_id1 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);

                            }
                            if (reference_id3 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id3='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id4 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id4='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + Checkref + "'";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id5 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id5='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id6 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id6='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id7 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id7='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id8 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id8='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id9 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id9='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id10 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id10='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id11 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(Checkref) + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                        }
                    }

                }
                else
                {

                    string AddJunior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Active)" +
                           " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','1')";
                    string exe = cc.ExecuteScalar(AddJunior); // Add Juniour  Under his Leader
                    string sqlupdate = "update usermaster set isMarketingPerson='Y' where usrUserid='" + JuniorNo_usrID + "'";
                    string a = cc.ExecuteScalar(sqlupdate); // allow permission is Marketing person i.e allow go to admin side.

                    string query = "select id from TreeDemo where userid='" + Leader_UserID + "' ";
                    string CheckTree = cc.ExecuteScalar(query); // Get leader ID already add in tree digrame
                    if (!(CheckTree == null || CheckTree == ""))
                    {

                        string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' and id=" + CheckTree + " ";
                        string GetID = cc.ExecuteScalar(check_Available); // check leader ID & Juniour Is already define or Not
                        if (!(GetID == null || GetID == ""))
                        {
                            //alredy Add in tree
                        }
                        else
                        {
                            string Addtree = "insert into TreeDemo(userid,parentid)values('" + JuniorNo_usrID + "','" + CheckTree + "')";
                            string b = cc.ExecuteScalar(Addtree); // add new juniour in tree digrame
                        }
                    }
                    else
                    {
                        // if leader not add in tree diagram
                        //string Addtree = "insert into TreeDemo(userid,parentid)values('" + Leader_UserID + "','" + CheckTree + "')";
                        //string b = cc.ExecuteScalar(Addtree);
                    }
                }

                if (Leader_RoleID == "76" || Leader_RoleID == "76")
                {
                    string sql = "select SchoolId from UDISE_SchoolMaster  inner join UDISE_TeacherMaster on UDISE_TeacherMaster.SchoolCode=UDISE_SchoolMaster.SchoolCode   where UDISE_SchoolMaster.SchoolCode='" + schoolcode + "' and UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' ";
                    string id = cc.ExecuteScalar(sql);
                    if (id == "" || id == null)
                    {
                        //string Management = "", SchoolType = "", Classes = "";
                        //sql = "insert into UDISE_SchoolMaster(SchoolCode,SchoolName,Management,SchoolType,Classes) values('" + schoolcode + "','" + schoolName + "','" + Management + "','" + SchoolType + "','" + Classes + "')";
                        //int a1 = cc.ExecuteNonQuery(sql);                      
                    }
                    else
                    {

                        //string SQLA = "select friendid from AdminSubMarketingSubUser where roleid='" + JuniorRoleID + "' and friendid= '" + Leader_UserID + "' ";
                        //string HM_ID = cc.ExecuteScalar(SQLA);
                        string usrclass = "", section = "";
                        //  addhm.AddSubUser(JuniorNo, fname, lname, schoolcode, ClassName, Section, Leader_UserID);

                    }
                }
            }
        }
        catch (Exception ex)
        {


        }

    }
    private void info_Sublevel()
    {
        try
        {


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + Leader_UserID + "'";

            DataSet ds1 = cc.ExecuteDataset(Getreference);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
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


    private void info_Somelevel()
    {
        try
        {


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + Leader_UserID + "'";

            DataSet ds1 = cc.ExecuteDataset(Getreference);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
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



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //AddNewUser();

            if (rdb1.Checked == false && rdb2.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Level)", true);
                Response.Write("<script>(alert)('Please Select Level')</script>");

            }
            else if (ddlrole.SelectedIndex == ddlrole.Items.Count - 1)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Role)", true);
                Response.Write("<script>(alert)('Please Select Role')</script>");

            }

            else if (txtmobileno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz Enter MobileNo..!!'')", true);
                Response.Write("<script>(alert)('Plz Enter MobileNo..!!')</script>");

            }
            else if (lblCelNumber.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not registered in myct..!!'')", true);
                Response.Write("<script>(alert)('Not registered in myct..!!')</script>");

            }
            else
            {
                string LeaderNo = Convert.ToString(Session["MobileNumber"]);
                int Roleid = Convert.ToInt32(Session["RoleIdUpdate"]);
                UserName = Convert.ToString(Session["MarketingUser"]);
                string Subuser = lblCelNumber.Text;
                string SQl = "select usrMobileNo from UserMaster where usrUserId =( select userid from AdminSubMarketingSubUser  " +
                          "  inner join UserMaster on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid " +
                          "  where friendid='" + UserName + "'  and mainrole=1 ) ";
                string LeadeLeadeMobileNO = cc.ExecuteScalar(SQl); // get leaderleaderMobile No.

                if (Subuser != "" && LeaderNo != "" && LeadeLeadeMobileNO != "")
                {
                    // AddNewUser_Sublevel(Subuser, LeaderNo);
                    if (rdb1.Checked == true)
                    {
                        if (txtplace.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Location ,Area,Place..!!'')", true);
                            Response.Write("<script>(alert)('Please Enter Location ,Area,Place..!!')</script>");

                        }
                        else
                        {

                            if (btnSubmit.Text == "Update")
                            {
                                UpdateSubUser(lblId.Text);

                            }
                            else
                            {
                                // AddNewUser_Sublevel(Subuser, LeaderNo); // Old function 
                                AddNewUser_Sublevel1(Subuser, LeaderNo, LeadeLeadeMobileNO, Roleid); //new function 19_oct_13
                                gridviewshow();
                            }

                        }
                    }
                    else if (rdb2.Checked == true)
                    {
                        if (txtplace.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Location ,Area,Place..!!'')", true);
                            Response.Write("<script>(alert)('Please Enter Location ,Area,Place..!!')</script>");

                        }
                        else
                        {

                            UserName = Convert.ToString(Session["MarketingUser"]);
                            if (UserName == "Admin")
                            {
                                UserName = "6dde8c3d-1895-4904-b332-764f63206fc0";
                            }
                            string Sql1 = "Select count(Active) from AdminSubMarketingSubOrdinate where [userid]='" + UserName + "' and Active=1 ";
                            int Data1 = 0;
                            Data1 = cc.ExecuteScalar1(Sql1);
                            if (Data1 != null && Data1 >= 3)
                            {
                                Response.Write("<script>(alert)('can not Subordinate Not More than 3. ')</script>");
                                lblerror.Text = "can not Subordinate Not More than 3. ";
                                lblerror.Visible = true;
                            }
                            else
                            {
                                string sql12 = "select userid  from AdminSubMarketingSubUser inner join UserMaster on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid where usrMobileNo='" + LeaderNo + "'";
                                string id = cc.ExecuteScalar(sql12);
                                UserName = Convert.ToString(Session["MarketingUser"]);
                                if (UserName == "Admin")
                                {
                                    id = "6dde8c3d-1895-4904-b332-764f63206fc0";
                                }
                                if (id != "")
                                {

                                    if (btnSubmit.Text == "Update")
                                    {
                                        UpdateSubOrdinate(lblId.Text);

                                    }
                                    else
                                    {
                                        AddNewUser_Somelevel(Subuser, id);
                                        gridviewshow1();
                                    }


                                }
                                else
                                {


                                }
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("<script>(alert)('Leader Ledaer Not Abailable ')</script>");
                    lblerror.Text = "Leader Ledaer Not Abailable ";
                    lblerror.Visible = true;

                }

            }
            //Response.Redirect("../MarketingAdmin/AddJuniors.aspx");
        }
        catch (Exception ex)
        {
            lblerror.Text = "More Than SubQuery Return....";
        }


    }

    public void UpdateSubOrdinate(string id)
    {
        try
        {

            string Sql = "update AdminSubMarketingSubOrdinate set Location='" + txtplace.Text + "'  where id=" + id + " ";
            int i = cc.ExecuteNonQuery(Sql);
            if (i == 1)
            {
                btnSubmit.Text = "Submit";
                gridviewshow1();
                clear();
                txtmobileno.Enabled = true;
                btnSearch.Enabled = true;
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void UpdateSubUser(string id)
    {
        try
        {

            string Sql = "update AdminSubMarketingSubUser set Location='" + txtplace.Text + "'  where id=" + id + " ";
            int i = cc.ExecuteNonQuery(Sql);
            if (i == 1)
            {
                btnSubmit.Text = "Submit";
                gridviewshow();
                clear();
                txtmobileno.Enabled = true;
                btnSearch.Enabled = true;
            }
        }
        catch (Exception ex)
        {

        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
    protected void gvdisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdisplay.PageIndex = e.NewPageIndex;
        if (rdb1.Checked == true)
        {
            gridviewshow();
        }
        else if (rdb2.Checked == true)
        {
            gridviewshow1();
        }
    }
    protected void rdb1_CheckedChanged(object sender, EventArgs e)
    {
        getmobile.Visible = true;
        clear();
        gridviewshow();


        //selectlevel.Visible = false;

    }

    public void clear()
    {
        txtmobileno.Text = "";
        lblCelNumber.Text = "";
        lblCity.Text = "";
        txtplace.Text = "";

        lblId.Text = "";
        lblName.Text = "";
        lblerror.Text = "";
        lblerror.Visible = false;
    }
    protected void rdb2_CheckedChanged(object sender, EventArgs e)
    {

        getmobile.Visible = true;
        clear();
        gridviewshow1();

        //selectlevel.Visible = false;
    }
    protected void btnSubmitSame_Click(object sender, EventArgs e)
    {
        try
        {


            string LeaderNo = Convert.ToString(Session["MobileNumber"]);
            string Subuser = lblCelNumber.Text;


            if (Subuser != "" && LeaderNo != "")
            {
                string sql12 = "select userid  from AdminSubMarketingSubUser inner join UserMaster on UserMaster.usrUserId=AdminSubMarketingSubUser.friendid where usrMobileNo='" + LeaderNo + "'";
                string id = cc.ExecuteScalar(sql12);
                if (id != "")
                {
                    AddNewUser_Somelevel(Subuser, id);
                }
                else
                {


                }


                // AddNewUser1();
            }
            else
            {
                // Response.Write("<script>(alert)('This User is Not registrered on myct.in. Please first registered on myct.in then add Some Level')</script>");
                Response.Write("<script>(alert)('This User is already subuser of other, You cannot assign ')</script>");
                lblerror.Text = "This User is Not registrered on myct.in. Please first registered on myct.in then add Some Level";
                lblerror.Visible = true;
            }
        }
        catch (Exception ex)
        {
        }
    }







    protected void btnSeachSame_Click(object sender, EventArgs e)
    {
        //if (TextBox1.Text == "" || TextBox1.Text == null)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Plz Enter MobileNo..!!'')", true);
        //    //Response.Write("<script>(alert)('Plz Enter MobileNo..!!')</script>");

        //}
        //else
        //{
        //    gvshow1();
        //    gridviewshow1();
        //}

    }
    protected void gvsubordinat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void gvsubordinat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;

        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSubmit.Text = "Update";
            string sql = " select usrUserid,usrFirstName+''+usrLastName as FullName,usrMobileNo,usrCity,Location from usermaster " +
                   "inner join AdminSubMarketingSubOrdinate on AdminSubMarketingSubOrdinate.friendid= usermaster.usrUserId " +
                   " where AdminSubMarketingSubOrdinate.id=" + Id + "";

            DataSet ds = cc.ExecuteDataset(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string userid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
                Session["frienduserid"] = userid;
                lblName.Text = Convert.ToString(dr["FullName"]);
                lblCelNumber.Text = Convert.ToString(dr["usrMobileNo"]);
                lblCity.Text = Convert.ToString(dr["usrCity"]);
                txtplace.Text = Convert.ToString(dr["Location"]);
                txtmobileno.Text = Convert.ToString(dr["usrMobileNo"]);
                txtmobileno.Enabled = false;
                btnSearch.Enabled = false;

            }

        }
        else if (Convert.ToString(e.CommandName) == "Deactive")
        {
            string Sql = " update AdminSubMarketingSubOrdinate set  Active=0 where AdminSubMarketingSubOrdinate.id=" + Id + " ";
            int i = cc.ExecuteNonQuery(Sql);
            if (i == 1)
            {
                gridviewshow1();
                btnSubmit.Text = "Submit";
            }

        }
        else if (Convert.ToString(e.CommandName) == "Active")
        {
            string Sql = " update AdminSubMarketingSubOrdinate set  Active=1 where AdminSubMarketingSubOrdinate.id=" + Id + " ";
            int i = cc.ExecuteNonQuery(Sql);
            if (i == 1)
            {
                gridviewshow1();
                btnSubmit.Text = "Submit";
            }

        }
    }
    protected void gvdisplay_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            if (Convert.ToString(e.CommandName) == "Modify")
            {
                btnSubmit.Text = "Update";
                string sql = " select usrUserid,usrFirstName+''+usrLastName as FullName,usrMobileNo,usrCity,Location from usermaster " +
                       "inner join AdminSubMarketingSubUser on AdminSubMarketingSubUser.friendid= usermaster.usrUserId " +
                       " where AdminSubMarketingSubUser.id=" + Id + "";

                DataSet ds = cc.ExecuteDataset(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string userid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
                    Session["frienduserid"] = userid;
                    lblName.Text = Convert.ToString(dr["FullName"]);
                    lblCelNumber.Text = Convert.ToString(dr["usrMobileNo"]);
                    lblCity.Text = Convert.ToString(dr["usrCity"]);
                    txtplace.Text = Convert.ToString(dr["Location"]);
                    txtmobileno.Text = Convert.ToString(dr["usrMobileNo"]);
                    txtmobileno.Enabled = false;
                    btnSearch.Enabled = false;

                }

            }
            else
                if (Convert.ToString(e.CommandName) == "Active")
                {

                    string Sql = " update AdminSubMarketingSubUser set  Active=1 where AdminSubMarketingSubUser.id=" + Id + " ";
                    int i = cc.ExecuteNonQuery(Sql);
                    if (i == 1)
                    {
                        gridviewshow();
                        btnSubmit.Text = "Submit";
                    }

                }
            if (Convert.ToString(e.CommandName) == "Deactive")
            {

                string Sql = " update AdminSubMarketingSubUser set  Active=0 where AdminSubMarketingSubUser.id=" + Id + " ";
                int i = cc.ExecuteNonQuery(Sql);
                if (i == 1)
                {
                    gridviewshow();

                }

            }
        }
        catch (Exception ex)
        {


        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
        btnSearch.Enabled = true;
        txtmobileno.Enabled = true;
        btnSubmit.Text = "Submit";
    }
    protected void ddlrole_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlrole.SelectedIndex == ddlrole.Items.Count - 1)
            {

            }
            else
            {
                string sql = "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set mainrole=0 where  friendid='" + Convert.ToString(Session["MarketingUser"]) + "' ";
                sql = sql + "update [Come2myCityDB].[come2mycity].AdminSubMarketingSubUser set mainrole=1 where  friendid='" + Convert.ToString(Session["MarketingUser"]) + "' and roleid='" + Convert.ToString(Session["RoleIdUpdate"]) + "'";
                int i = cc.ExecuteNonQuery(sql);
                if (i >= 1)
                {
                    Session["RoleIdUpdate"] = ddlrole.SelectedValue;
                }

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}






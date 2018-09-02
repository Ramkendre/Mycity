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

public partial class MarketingAdmin_Replcae_Juniors : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    int Status = 0;

    string initialreference = "", Leader_RoleName = "", Leader_RoleID = "", Leader_UserID = "", Leader_Leader;
    string reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", userid = "";
    string reference_id6 = "", reference_id7 = "", reference_id8 = "", reference_id9 = "", reference_id10 = "", reference_id11 = "";
    string UserName = "", LeaderNo, fname = "", lname = "", leaderMobileNo = "", schoolcode = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            

        }
        UserName = Convert.ToString(Session["MarketingUser"]);
       
    }

    private void GetDetailsOldOfficer()
    {
        try
        {
            string sql = "select " +
                        "asm2.rolename as rl,asm2.roleid, U2.usrFirstName+' '+U2.usrLastName as LName, U2.usrMobileNo as LMNo, e2.userid as L2 ," +
                        "asm3.rolename as rj,asm3.roleid, U3.usrFirstName+' '+U3.usrLastName as JName,U3.usrMobileNo as U3MNo,e3.userid as L3 " +
                        "from " +
                        "TreeDemo e2 " +
                        "join UserMaster as U2 on U2.usrUserId=e2.userid " +
                        "join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +

                        "join TreeDemo e3 on e2.id=e3.parentid " +
                        "join UserMaster as U3 on U3.usrUserId=e3.userid " +
                        "join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
                        " where U3.usrMobileNo='" + txtmobileno.Text + "'";

            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string userid = Convert.ToString(ds.Tables[0].Rows[0]["L3"]);
                Session["frienduserid"] = userid;
                lo_fname1.Text = Convert.ToString(ds.Tables[0].Rows[0]["JName"]);
                lo_lname1.Text = Convert.ToString(ds.Tables[0].Rows[0]["LName"]);
                lo_Rolename1.Text = Convert.ToString(ds.Tables[0].Rows[0]["rj"]);
                lblo_lrolename1.Text = Convert.ToString(ds.Tables[0].Rows[0]["rl"]);
                leaderMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["LMNo"]);
                Session["leaderMobileNo"] = leaderMobileNo;
            }
            else
            {
                clear1();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not Existing officer')", true);
                Response.Write("<script>(alert)('Not Existing officer')</script>");
            }

        }
        catch (Exception ex)
        {

        }
    }

    private void GetDetailsNewOfficer()
    {
        try
        {
            string sql = "select " +
                        "asm2.rolename as rl,asm2.roleid, U2.usrFirstName+' '+U2.usrLastName as LName, U2.usrMobileNo as LMNo, e2.userid as L2 ," +
                        "asm3.rolename as rj,asm3.roleid, U3.usrFirstName+' '+U3.usrLastName as JName,U3.usrMobileNo as U3MNo,e3.userid as L3 " +
                        "from " +
                        "TreeDemo e2 " +
                        "join UserMaster as U2 on U2.usrUserId=e2.userid " +
                        "join AdminSubMarketingSubUser as asm2 on asm2.friendid=e2.userid " +

                        "join TreeDemo e3 on e2.id=e3.parentid " +
                        "join UserMaster as U3 on U3.usrUserId=e3.userid " +
                        "join AdminSubMarketingSubUser as asm3 on asm3.friendid=e3.userid " +
                        " where U3.usrMobileNo='" + txtnewmobileno.Text + "'";

            DataSet ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string userid = Convert.ToString(ds.Tables[0].Rows[0]["L3"]);
                Session["frienduserid"] = userid;
                lblnew_Oname1.Text = Convert.ToString(ds.Tables[0].Rows[0]["JName"]);
                lblnew_OLeaderNAme1.Text = Convert.ToString(ds.Tables[0].Rows[0]["LName"]);
                lblnew_ORolename1.Text = Convert.ToString(ds.Tables[0].Rows[0]["rj"]);
                lblnew_OLRolename1.Text = Convert.ToString(ds.Tables[0].Rows[0]["rl"]);
                leaderMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["LMNo"]);
                Session["leaderMobileNo"] = leaderMobileNo;
            }
            else
            {
                sql = "select  usrFirstName+' '+usrLastName as JName,usrMobileNo as U3MNo ,usrUserId as L3 from UserMaster " +
                      " where usrMobileNo='" + txtnewmobileno.Text + "'";

                ds = cc.ExecuteDataset(sql);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string userid = Convert.ToString(ds.Tables[0].Rows[0]["L3"]);
                    Session["frienduserid"] = userid;
                    lblnew_Oname1.Text = Convert.ToString(ds.Tables[0].Rows[0]["JName"]);
                    lblnew_Oname1.Text = "";
                    lblnew_Oname1.Enabled = true;
                    txtlname.Visible = true;
                    lblnew_OLeaderNAme1.Text = "No any Leader";
                    lblnew_ORolename1.Text = "Role Not define";
                    lblnew_OLRolename1.Text = "No any Leader";
                }
                else
                {
                    clear();
                    lblnew_Oname1.Enabled = true;
                    txtlname.Visible = true;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Not registered in myct')", true);
                    Response.Write("<script>(alert)('Not registered in myct')</script>");
                }


            }

        }
        catch (Exception ex)
        {

        }
    }

    public void clear()
    {
        lblnew_OLeaderNAme1.Text = "";
        lblnew_ORolename1.Text = "";
        lblnew_OLRolename1.Text = "";
        lblnew_Oname1.Text = "";



    }

    public void clear1()
    {
        txtmobileno.Text = "";
        lo_Rolename1.Text = "";
        lo_lname1.Text = "";
        lblo_lrolename1.Text = "";
        lo_fname1.Text = "";

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtmobileno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Mobile No.')", true);
                Response.Write("<script>(alert)('Please Enter Mobile No.')</script>");

            }
            else
            {
                GetDetailsOldOfficer();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtnewmobileno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Mobile No.')", true);
                Response.Write("<script>(alert)('Please Enter Mobile No.')</script>");

            }
            else
            {
                GetDetailsNewOfficer();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnreplace_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtnewmobileno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please New Office Enter Mobile No.')", true);
                Response.Write("<script>(alert)('Please Enter New Office Mobile No.')</script>");
            }
            else if (txtmobileno.Text == "" )
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Old Office  Mobile No.')", true);
                Response.Write("<script>(alert)('Please Enter Old Office  Mobile No.')</script>");

            }
            else if (lblnew_Oname1.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter New Officer First Name')", true);
                Response.Write("<script>(alert)('Please Enter New Officer First Name')</script>");

            }
            else
            {

                if (txtnewmobileno.Text != txtmobileno.Text)
                {
                    string JusrOldID = "select usruserid from usermaster where usrMobileNo='" + txtnewmobileno.Text + "'";
                    string JunioroldNo_usrID = cc.ExecuteScalar(JusrOldID); // get Old juniour usrUserID
                    if (!(JunioroldNo_usrID == null || JunioroldNo_usrID == ""))
                    {
                        Replace_juniors(txtmobileno.Text, txtnewmobileno.Text, Convert.ToString(Session["leaderMobileNo"]));
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('New Mobile No. not registered in myct.in ' )", true);
                        //Response.Write("<script>(alert)('New Mobile No. not registered in myct.in')</script>");



                    }

                }
                else
                {

                    int a = Addnew(lblnew_Oname1.Text, txtlname.Text, txtnewmobileno.Text);
                   if (a == 1)
                   {
                       string JusrOldID = "select usruserid from usermaster where usrMobileNo='" + txtnewmobileno.Text + "'";
                       string JunioroldNo_usrID = cc.ExecuteScalar(JusrOldID); // get Old juniour usrUserID
                       if (!(JunioroldNo_usrID == null || JunioroldNo_usrID == ""))
                       {
                           Replace_juniors(txtmobileno.Text, txtnewmobileno.Text, Convert.ToString(Session["leaderMobileNo"]));
                       }
                       else
                       {
                           ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('New Mobile No. not registered in myct.in ' )", true);
                           Response.Write("<script>(alert)('New Mobile No. not registered in myct.in')</script>");

                       }
                   }
                }

            }

        }
        catch (Exception ex)
        {


        }
    }

    public int Addnew(string fname, string lname, string mobileno)
    {
        try
        {
            string userid = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            string pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            string Sql = "insert into usermaster(usrUserId,usrFirstName,usrLastName,usrMobileNo,usrPassword)" +
                     " values('" + userid + "','" + fname + "','" + lname + "','" + mobileno + "','" + pwd + "')";
            int ID = cc.ExecuteNonQuery(Sql);

            return ID;
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
        Leader_UserID = "";


    }


    private void info13()
    {
        try
        {


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + Leader_UserID + "' and Active='1'";

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
                info13();
            }
            string JusrID = "select usruserid from usermaster where usrMobileNo='" + JuniorNoNew + "'";
            string JuniorNo_usrID = cc.ExecuteScalar(JusrID); // get  new juniour usrUserID

            string JusrOldID = "select usruserid from usermaster where usrMobileNo='" + JuniorNoOld + "'";
            string JunioroldNo_usrID = cc.ExecuteScalar(JusrOldID); // get Old juniour usrUserID

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
            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                string SQL = "update AdminSubMarketingSubUser set  Active='0'  where    friendid = '" + JunioroldNo_usrID + "' and userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' ";
                //and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "'  ";
                // SQL = "update AdminSubMarketingSubUser set  Active='0'  where  friendid='" + JuniorNo_usrID + "' and   userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and friendid = '" + JuniorNo_usrID + "' ";

                int a = cc.ExecuteNonQuery(SQL);
                if (a >= 1)
                {
                    if (JunioroldNo_usrID != JuniorNo_usrID)
                    {
                        string Checkref = JunioroldNo_usrID;

                        int a1;
                        string sq1 = "select id from AdminSubMarketingSubUser where userid='" + JuniorNo_usrID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                        string Chk_Assign = cc.ExecuteScalar(sq1); // check juniour is exit or not
                        if ((Chk_Assign == null || Chk_Assign == ""))
                        {
                            SQL = "delete from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "'";
                            SQL = SQL + "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Active='1'  where  friendid = '" + JunioroldNo_usrID + "' and  userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                            a1 = cc.ExecuteNonQuery(SQL);
                        }
                        else
                        {
                            SQL = SQL + "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Active='1'  where  friendid = '" + JunioroldNo_usrID + "' and  userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                            a1 = cc.ExecuteNonQuery(SQL);

                        }

                        //SQL = SQL + "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Active='1'  where  friendid = '" + JunioroldNo_usrID + "' and  userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' ";
                        //a1 = cc.ExecuteNonQuery(SQL);
                        string qry;
                        int status;
                        if (a1 >= 1)
                        {
                            if (reference_id2 == "")
                            {

                                qry = "update AdminSubMarketingSubUser set reference_id2='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + Checkref + "' "; // AdminSubMarketingSubUser  - 1st ref
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and  reference_id1='" + reference_id1 + "'";            // AdminSubMarketingSubUser   - 1st ref

                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";  // UDISE_TeacherMaster  
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";    // UDISE_TeacherMaster  

                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";   // TreeDemo  - 1st ref

                                qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                               

                                status = cc.ExecuteNonQuery(qry);

                            }
                            if (reference_id3 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id3='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id4 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id4='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + Checkref + "'";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id5 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id5='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                 qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id6 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id6='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                 qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                 qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                 qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                 qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                 qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                 qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id7 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id7='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                 qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                 qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                 qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                 qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                 qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                 qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id8 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id8='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                 qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                 qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                 qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                 qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                 qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                 qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id9 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id9='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id10 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id10='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                 qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                 qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                 qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                 qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                 qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                 qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id11 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(Checkref) + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "'";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                qry = qry + "update [UDISE_GetTotalReport] set ReportId='" + JuniorNo_usrID + "' , RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";  // UDISE_GetTotalReport  
                                qry = qry + "update [UDISE_GetTotalReport] set UsrUserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UsrUserId='" + Checkref + "'";   // UDISE_GetTotalReport  


                                qry = qry + "update [UDISE_TotalByRole] set ReportId='" + JuniorNo_usrID + "' ,RplsChainLogDtls='" + UserName + "' where ReportId='" + Checkref + "'";   // UDISE_TotalByRole 
                                qry = qry + "update [UDISE_TotalByRole] set UserId='" + JuniorNo_usrID + "' , MobileNo='" + JuniorNoNew + "', RplsChainLogDtls='" + UserName + "' where UserId='" + Checkref + "'";    // UDISE_TotalByRole 

                                qry = "update AdminSubMarketingSubOrdinate set Parent='" + JuniorNo_usrID + "' where   Parent='" + Checkref + "' ";  // AdminSubMarketingSubOrdinate  
                              
           
                                status = cc.ExecuteNonQuery(qry);


                            }
                        }
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This User is already subuser Other')", true);
                    Response.Write("<script>(alert)('This User is already subuser Other.')</script>");

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

                    string check_Available = "select id from TreeDemo where userid='" + JuniorNo_usrID + "' ";
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


                Replace_juniors(JuniorNoOld, JuniorNoNew, leader_no);

            }

           if (Leader_RoleID == "76" || Leader_RoleID == "76")
           // if (Leader_RoleID == "41" || Leader_RoleID == "41")
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
                    //   udise_addsub.AddSubUser(JuniorNo, fname, lname, schoolcode, ClassName, Section, Leader_UserID);

                }
            }
        }
        catch (Exception ex)
        {


        }

    }


    protected void btncacle_Click(object sender, EventArgs e)
    {
        clear();
        clear1();
        txtnewmobileno.Text = "";
        lblnew_Oname1.Enabled=false;
        txtlname.Visible = false;
        txtlname.Text = "";
       
    }
}

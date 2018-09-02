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

public partial class MarketingAdmin_PushedAttendance : System.Web.UI.Page
{
    //LongCodeBLL objBLLLongCode = new LongCodeBLL();
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    UDISE_AddSubUser UdiseCode = new UDISE_AddSubUser();

    string MobileNo = "", Section = "", Class1 = "", ReceivedDate = "";
    string DateFormat = "";
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();

    string ClassName = "";// Section = "";, schoolcode = "";
    // string HM_MobileNo = "";


    int status;
    string RoleId = "";
    string usrRole = "";
    string initialreference = "", Leader_RoleName = "", Leader_RoleID = "", Leader_UserID = "", Leader_Leader;
    string reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", userid = "";
    string reference_id6 = "", reference_id7 = "", reference_id8 = "", reference_id9 = "", reference_id10 = "", reference_id11 = "";
    string UserName = "", LeaderNo, fname = "", lname = "", usrclass = "", section = "";
    int count = 1;


    string mno = "", fnm = "", lnm = "", schoolcode = "", scode = "", LLeaderNo_usrID = "", LeaderRoleId = "", allcode = "";//, ClassName = "", Section = "";
    string schoolName = "", T_MobileNo = "", T_Fname = "", T_Lname = "", HM_MobileNo = "", Hm_usrID = "";




    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Convert.ToString(System.DateTime.Now);
        if (!IsPostBack)
        {
            LoadGrid();
            // TotalCount();
        }
        DateFormatStatus();
    }

    //--------------------------------------------------------- Date Format--------------------------------------------------------------------------

    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }
    //------------------------------------------------------ Data Bind GridView---------------------------------------------------------------------
    //CONVERT(varchar, shortcode,103)  as shortcode
    public void LoadGrid()
    {
        try//" + Convert.ToString(Session["SchoolCode"]) + " and Message like 'TEA%' or Message like 'Tea%' '27180109801'
        {
            string Sql = "Select Distinct(shortcode),PK,Message,mobile,data,shortcode,FlagStatus  from " +
                          " test inner join UserMaster on UserMaster.usrMobileNo =test.mobile " +
                          " inner join UDISE_TeacherMaster on UDISE_TeacherMaster.junior_id  =UserMaster.usrUserId " +
                          " inner join UDISE_SchoolMaster on UDISE_SchoolMaster.SchoolCode=UDISE_TeacherMaster.SchoolCode " +
                          "  order by PK desc ";
            ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();

            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[4].Text.ToString();
                if (Data == "0")
                {
                    row.Cells[4].Text = "Correct";
                }
                else if (Data == "1")
                {
                    row.Cells[4].Text = "Incorrect";
                }
                else if (Data == "2")
                {
                    row.Cells[4].Text = "Updated";
                }
                else if (Data == "3")
                {
                    row.Cells[4].Text = "Pending";
                }
            }
            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[3].Text.ToString();
                string[] DateFormat1 = Data.Split(' ');
                Data = Convert.ToString(DateFormat1[0]);
                row.Cells[3].Text = Data;
            }
        }
        catch (Exception ex)
        {

        }

    }
    //--------------------------------------------------------- Assign Paging to GridView-----------------------------------------------------------

    protected void gvLongCodeReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadGrid();
    }
    protected void gvLongCodeReport_PageIndexChanged(object sender, EventArgs e)
    {

    }

    //----------------------------------------------- Read Data to A Perticular Line GridView----------------------------------------------------

    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Push")
        {
            //btnSubmit.Text = "Update";
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            string Sql = "Select Message,mobile,shortcode,data,SendDate from test where PK='" + Id + "'";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtMgs.Text = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                lblMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["mobile"]);
                lblDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["shortcode"]);

            }
            catch (Exception ex)
            { }
        }
    }

    //---------------------------------------------------Clear Data----------------------------------------------------------------------------------

    public void Clear()
    {
        txtMgs.Text = "";
        lblDate.Text = "";
        lblId.Text = "";
        lblMobileNo.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    //-------------------------------------------------------------- Send Data to Push To Student Table------------------------------------------------

    protected void btnPushMgs_Click(object sender, EventArgs e)
    {
        KeywordSyntax();
    }

    public void KeywordSyntax()
    {
        ReceivedDate = Convert.ToString(lblDate.Text);
        if (ReceivedDate.Contains('/'))
        {
            string[] date = ReceivedDate.Split(' ');
            string[] dateformate = date[0].Split('/'); //7/24/2013 2:59:39 PM Send SMS format server

            ReceivedDate = dateformate[2] + "-" + dateformate[0] + "-" + dateformate[1];
        }
        MobileNo = Convert.ToString(lblMobileNo.Text);
        string Syntax = Convert.ToString(txtMgs.Text.Trim());
        string[] SplitSyntax = Syntax.Split('*');
        string KeywordType = Convert.ToString(SplitSyntax[0]);
        string Keyword = KeywordType.ToUpper();
        string AttendenceId = Convert.ToString(lblId.Text);

        //--------------------------------------------------------- DAR Keyword ---------------------------------------------------------------------

        if (Keyword == "DAR" || Keyword == "CAR")//DAR*7*A*RB*17*RG*15*PB*15*PG*13
        {
            try
            {
                string UserIdOfTeach = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
                string UserIdTeach = Convert.ToString(cc.ExecuteScalar(UserIdOfTeach));
                if (UserIdTeach == "" || UserIdTeach == null)
                {
                    Response.Write("<script>alert('This User not register.....!')</script>");
                }
                else
                {
                    string ChkSchoolCode = "select SchoolCode from UDISE_TeacherMaster where junior_id='" + UserIdTeach + "' and Active=1";
                    string schoolcode = cc.ExecuteScalar(ChkSchoolCode);
                    if (schoolcode == "" || schoolcode == null)
                    {
                        Response.Write("<script>alert('This School is not register or not teacher.....!')</script>");
                    }
                    else
                    {
                        string Sql = "Select EntryDate from UDISE_StudentPresenty where EntryDate='" + ReceivedDate + "' and Class='" + SplitSyntax[1] + "' and Division='" + SplitSyntax[2] + "' and SchoolCode='" + schoolcode + "'";
                        string Datestr = Convert.ToString(cc.ExecuteScalar(Sql));
                        if (Datestr == "" || Datestr == null)
                        {
                            string Addstudpre = "insert into UDISE_StudentPresenty(usrUserId,Keyword,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls,Present_B,Present_G,Created,ModifyDate)" +
                                                "values('" + UserIdTeach + "','" + Keyword + "','" + schoolcode + "','" + Convert.ToString(ReceivedDate) + "','" + SplitSyntax[1] + "','" + SplitSyntax[2] + "','" + SplitSyntax[4] + "','" +
                                                 SplitSyntax[6] + "','" + SplitSyntax[8] + "','" + SplitSyntax[10] + "','Myct','" + DateFormat + "')";
                            int a = cc.ExecuteNonQuery(Addstudpre);
                            if (a == 1)
                            {
                                string sqlPush = "update test set FlagStatus = 2 where PK = " + Convert.ToInt64(AttendenceId) + "";
                                int F = cc.ExecuteNonQuery(sqlPush);
                                if (F == 1)
                                {
                                    Clear();
                                    LoadGrid();
                                    Response.Write("<script>alert('Message Pushed Added Successfully..!')</script>");
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed Added Successfully'))", true);
                                }
                                else
                                {
                                    Clear();
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Pushed not Added Successfully..!')</script>");
                                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed not Added Successfully'))", true);
                            }
                        }
                        else
                        {
                            string UpdatestudPre = "update UDISE_StudentPresenty set usrUserId='" + UserIdTeach + "',Keyword='" + Keyword + "',RegBoys='" +
                                                    SplitSyntax[4] + "',RegGirls='" + SplitSyntax[6] + "',Present_B='" + SplitSyntax[8] + "',Present_G='" + SplitSyntax[10] + "',ModifyDate='" + DateFormat + "' where EntryDate='" +
                                                    Convert.ToString(ReceivedDate) + "' and Class='" + SplitSyntax[1] + "' and Division='" + SplitSyntax[2] + "' and SchoolCode='" + schoolcode + "'";
                            int a = cc.ExecuteNonQuery(UpdatestudPre);
                            if (a == 1)
                            {
                                string sqlPush = "update test set FlagStatus = 2 where PK = " + Convert.ToInt64(AttendenceId) + "";
                                int F = cc.ExecuteNonQuery(sqlPush);
                                if (F == 1)
                                {
                                    Clear();
                                    LoadGrid();
                                    Response.Write("<script>alert('Message Pushed Updated Successfully..!')</script>");
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed Updated Successfully'))", true);
                                }
                                else
                                {
                                    Clear();
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Message Pushed not Updated Successfully..!')</script>");
                                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed not Updated Successfully'))", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please Check Syntax is proper...?..!')</script>");
                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Check Syntax is proper...?')", true);
            }
        }

        //-------------------------------------------------------------- STAFF Keyword----------------------------------------------------------------

        else if (Keyword == "STAFF")//STAFF*RM*33*RF*33*PM*32*PF*10
        {
            try
            {
                string UserIdOf_Hm = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
                string UserIdTeach = Convert.ToString(cc.ExecuteScalar(UserIdOf_Hm));

                if (UserIdTeach == "" || UserIdTeach == null)
                {
                    Response.Write("<script>alert('This User not register.....!')</script>");
                }
                else
                {
                    string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + UserIdTeach + "' or userid='" + UserIdTeach + "' ";
                    string GetRoleID = cc.ExecuteScalar(sqlcheck);
                    if (GetRoleID == "" || GetRoleID == null)
                    {
                        Response.Write("<script>alert('This user is not Head Master(HM).....!')</script>");
                    }
                    else
                    {
                        if (GetRoleID == "76")
                        {
                            string ChkSchoolCode = "select SchoolCode from UDISE_TeacherMaster where junior_id='" + UserIdTeach + "' and Active=1";
                            string schoolcode = cc.ExecuteScalar(ChkSchoolCode);
                            if (schoolcode == "" || schoolcode == null)
                            {
                                Response.Write("<script>alert('This School is not register or not teacher.....!')</script>");
                            }
                            else
                            {
                                string Sql = "Select EntryDate from UDISE_TeacherPresenty where EntryDate='" + ReceivedDate + "' and usrUserId='" + UserIdTeach + "' and SchoolCode='" + schoolcode + "'";
                                string Datestr = Convert.ToString(cc.ExecuteScalar(Sql));
                                if (Datestr == "" || Datestr == null)
                                {
                                    string AddTechPre = "insert into UDISE_TeacherPresenty(usrUserId,Keyword,SchoolCode,EntryDate,RegMale,RegFemale,Present_M,Present_F,Created,ModifyDate)" +
                                        "values('" + UserIdTeach + "','" + Keyword + "','" + schoolcode + "','" + ReceivedDate + "','" + SplitSyntax[2] + "','" +
                                        SplitSyntax[4] + "','" + SplitSyntax[6] + "','" + SplitSyntax[8] + "','Myct', '" + DateFormat + "')";
                                    int a = cc.ExecuteNonQuery(AddTechPre);
                                    if (a == 1)
                                    {
                                        string sqlPush = "update test set FlagStatus = 2 where PK = " + Convert.ToInt64(AttendenceId) + "";
                                        int F = cc.ExecuteNonQuery(sqlPush);
                                        Clear();
                                        LoadGrid();
                                        Response.Write("<script>alert('Message Pushed Added Successfully..!')</script>");
                                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed Added Successfully'))", true);
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Message Pushed not Added Successfully..!')</script>");
                                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed not Added Successfully'))", true);
                                    }
                                }
                                else
                                {
                                    string UpdateTechPre = "Update UDISE_TeacherPresenty set RegMale='" + SplitSyntax[2] + "',RegFemale='" + SplitSyntax[4] + "',Present_M='" + SplitSyntax[6] + "',Present_F='" + SplitSyntax[8] + "', ModifyDate='" + DateFormat + "' where  usrUserId='" +
                                        UserIdTeach + "' and Keyword='" + Keyword + "' and SchoolCode='" + schoolcode + "' and EntryDate='" + ReceivedDate + "'";
                                    int a = cc.ExecuteNonQuery(UpdateTechPre);
                                    if (a == 1)
                                    {
                                        string sqlPush = "update test set FlagStatus = 2 where PK = " + Convert.ToInt64(AttendenceId) + "";
                                        int F = cc.ExecuteNonQuery(sqlPush);
                                        Clear();
                                        LoadGrid();
                                        Response.Write("<script>alert('Message Pushed Updated Successfully..!')</script>");
                                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed Updated Successfully')", true);
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('Message Pushed not Updated Successfully..!')</script>");
                                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed not Updated Successfully'))", true);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('This user is not Head Master(HM).....!')</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please Check Syntax is proper.....?')</script>");
                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Check Syntax is proper...?')", true);
            }
        }
        else if (Keyword == "TEACHER")//TEACHER*9595886668*VARSHA MANDHARE*10*B
        {
            try
            {
                string UserIdOfTeach = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
                string UserIdTeach = Convert.ToString(cc.ExecuteScalar(UserIdOfTeach));
                if (UserIdTeach == "" || UserIdTeach == null)
                {
                    Response.Write("<script>alert('This user is not register on Myct.....!')</script>");
                }
                else
                {
                    string FindSchoolCode = "Select distinct(Schoolcode) from [AdminSubMarketingSubUser] inner join UDISE_TeacherMaster on " +
                                            "[AdminSubMarketingSubUser].friendid=UDISE_TeacherMaster.junior_id " +
                                            " where roleid=76 and UDISE_TeacherMaster.junior_id='" + UserIdTeach + "'";
                    schoolcode = Convert.ToString(cc.ExecuteScalar(FindSchoolCode));
                    if (schoolcode == "" || schoolcode == null)
                    {
                        Response.Write("<script>alert('The School Code is not register or Not Head Master.....!')</script>");
                    }
                    else
                    {
                        T_MobileNo = Convert.ToString(SplitSyntax[1]);
                        string FullName = Convert.ToString(SplitSyntax[2]);
                        usrclass = Convert.ToString(SplitSyntax[3]);
                        section = Convert.ToString(SplitSyntax[4]);
                        string[] Name = FullName.Split(' ');
                        fname = Convert.ToString(Name[0]);
                        lname = Convert.ToString(Name[1]);
                        Hm_usrID = Convert.ToString(UserIdTeach);

                        string SQL = "select usrmobileno from UserMaster " +
                          " inner join AdminSubMarketingSubUser on AdminSubMarketingSubUser.friendid=UserMaster.usrUserId " +
                          " where AdminSubMarketingSubUser.friendid in (   " +
                          " select userid from AdminSubMarketingSubUser inner join UserMaster on AdminSubMarketingSubUser.friendid=UserMaster.usrUserId " +
                          " where UserMaster.usrMobileNo='" + MobileNo + "' and active=1 and mainrole=1)  ";
                        string LLeadermobileNo = cc.ExecuteScalar(SQL);

                        if (LLeadermobileNo != "")
                        {
                            AddSubUser_EO1(T_MobileNo, fname, lname, MobileNo, LLeadermobileNo, 76);//For Teacher
                        }

                        Clear();

                        string sqlPush = "update test set FlagStatus = 2 where PK = " + Convert.ToInt64(AttendenceId) + "";
                        int F = cc.ExecuteNonQuery(sqlPush);
                        if (F == 1)
                        {
                            Response.Write("<script>alert('Message Pushed Successfully..!')</script>");
                            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Pushed Updated Successfully'))", true);
                        }
                        else
                        {
                            Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please Check Syntax is proper.....?')</script>");
                // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Check Syntax is proper...?')", true);
            }
        }
    }

    //-----------------------------------Create Hirarchy--------------------------------------------------------------------------------------------

    #region CreateHirarchy
    public void AddSubUser_EO1(string EO_Mob, string Fname, string Lname, string leaderno, string LeaderLeaderNo, int LeaderRoleNo)
    {

        urUserRegBLLObj.Customermobileno = EO_Mob;
        fname = Fname;
        lname = Lname;
        status = urUserRegBLLObj.BLLSearchUserExist(urUserRegBLLObj); // Check Mobile register  or Not
        if (status > 0)
        {
            AddNewUser1(EO_Mob, leaderno, LeaderLeaderNo, LeaderRoleNo);

        }
        else
        {
            int Status = Addnew(Fname, Lname, EO_Mob);
            if (Status == 1)
            {
                AddSubUser_EO1(EO_Mob, Fname, Lname, leaderno, LeaderLeaderNo, LeaderRoleNo);
            }
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
    private void AddNewUser1(string JuniorNo, string leader_no, string LeaderLeaderNo, int LeaderRoleNo)
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

                info13();
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

            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and roleid='" + JuniorRoleID + "' and userid='" + Leader_UserID + "' ";
            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                if (JuniorRoleID == "77")
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

                        UdiseCode.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                        sql = "Update UDISE_TeacherMaster set LoginUser='" + MobileNo + "' ,Ref_Ways='PushAdmin' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                        int ad = cc.ExecuteNonQuery(sql);

                    }
                    else
                    {

                        UdiseCode.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                        sql = "Update UDISE_TeacherMaster set LoginUser='" + MobileNo + "' ,Ref_Ways='PushAdmin' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                        int ad = cc.ExecuteNonQuery(sql);
                    }

                }
                else
                {


                }
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
                                    " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','PushAdmin','1','1' )";
                        string exe = cc.ExecuteScalar(Junior); // Add Juniour  Under his Leader

                    }
                    else
                    {
                        string AddJunior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active,Mainrole)" +
                                        " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','PushAdmin','0' ,'0')";
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
                                       " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','PushAdmin','1','1' )";
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
            if (JuniorRoleID == "77")
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

                    UdiseCode.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                    sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(MobileNo) + "' ,Ref_Ways='PushAdmin' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
                    int ad = cc.ExecuteNonQuery(sql);

                }
                else
                {

                    UdiseCode.AddSubUser(JuniorNo, fname, lname, schoolcode, usrclass, section, Leader_UserID, Convert.ToInt32(JuniorRoleID));
                    sql = "Update UDISE_TeacherMaster set LoginUser='" + Convert.ToString(MobileNo) + "' ,Ref_Ways='PushAdmin' where leader_id='" + Convert.ToString(Leader_UserID) + "' and junior_id='" + Convert.ToString(JuniorNo_usrID) + "' and schoolcode='" + schoolcode + "' ";
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
    private void info13()
    {
        try
        {


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + Leader_UserID + "' and userid='" + LLeaderNo_usrID + "' and Roleid='" + LeaderRoleId + "' and  active=1";

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
    #endregion CreateHirarchy
}


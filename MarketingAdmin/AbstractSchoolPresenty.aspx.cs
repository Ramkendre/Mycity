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

public partial class MarketingAdmin_AbstractSchoolPresenty : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds;
    string SchoolCode = "", EntryDate = "", RegBoys = "", RegGirls = "", Present_B = "", Present_G = "", ModifyDate = "", DateFormat = "";


    Udise_ExeCountTotal getcount = new Udise_ExeCountTotal();
    UDISE_message umsg = new UDISE_message();

    string friendid = "", RoleID = "", rolename = "", ReportId = "", UserMobileNo = "";

    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        DateFormatStatus();
        if (!IsPostBack)
        {
            LoadItem();
            // GetRecord();
        }
       
    }

    //----------------------------------------------------------Current Date Format---------------------------------------------------------------------

    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    //----------------------------------------------------------Load Data bind to GridView---------------------------------------------------------------

    public void LoadItem()
    {
        string Sql = "Select SchoolCode,EntryDate,RegBoys,RegGirls,Present_B,Present_G from UDISE_AbstractSchoolPresenty where EntryDate='" + DateFormat + "'";
        DataSet ds2 = cc.ExecuteDataset(Sql);

        gvItem.DataSource = ds2.Tables[0];
        gvItem.DataBind();

        foreach (GridViewRow row in gvItem.Rows)
        {
            string Data = row.Cells[2].Text.ToString();
            Data = cc.DTGet_LocalEvent(Data);
            row.Cells[2].Text = Data;
        }
    }

    //------------------------------------------------------Abstract Button Click Sum of Attendence perticular School-----------------------------------

    protected void btnAbstract_Click(object sender, EventArgs e)
    {
        GetAbstract();
    }


    public void GetAbstract()
    {

        try
        {
            string Sql = "select UDISE_StudentPresenty.SchoolCode,EntryDate, SUM(RegBoys) as RegBoys,SUM(RegGirls)as RegGirls,SUM(Present_B)as Present_B,SUM(Present_G)as Present_G " +
                         "from UDISE_StudentPresenty where UDISE_StudentPresenty.EntryDate='" + DateFormat + "' " +
                         "GROUP BY EntryDate,SchoolCode";
            ds = cc.ExecuteDataset(Sql);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SchoolCode = Convert.ToString(ds.Tables[0].Rows[i]["SchoolCode"]);
                EntryDate = Convert.ToString(ds.Tables[0].Rows[i]["EntryDate"]);
                RegBoys = Convert.ToString(ds.Tables[0].Rows[i]["RegBoys"]);
                RegGirls = Convert.ToString(ds.Tables[0].Rows[i]["RegGirls"]);
                Present_B = Convert.ToString(ds.Tables[0].Rows[i]["Present_B"]);
                Present_G = Convert.ToString(ds.Tables[0].Rows[i]["Present_G"]);

                string AspPreSql = "Select EntryDate from UDISE_AbstractSchoolPresenty where SchoolCode='" + SchoolCode + "' and EntryDate='" + DateFormat + "'";
                string ChkEntry = Convert.ToString(cc.ExecuteScalar(AspPreSql));
                if (ChkEntry == "" || ChkEntry == null)
                {
                    string AddStudPre = "Insert into UDISE_AbstractSchoolPresenty (SchoolCode,EntryDate,RegBoys,RegGirls,Present_B,Present_G)" +
                                        " values('" + SchoolCode + "','" + DateFormat + "','" + RegBoys + "','" + RegGirls + "','" + Present_B + "','" + Present_G + "')";
                    int a = cc.ExecuteNonQuery(AddStudPre);
                    if (a == 1)
                    {

                    }
                }
                else
                {
                    string ChkEntryPre = "Select Sum(RegBoys)as RegBoys,Sum(RegGirls)as RegGirls,Sum(Present_B)as Present_B,Sum(Present_G)as Present_G from UDISE_StudentPresenty where SchoolCode='" + SchoolCode + "' and EntryDate ='" + DateFormat + "'";
                    DataSet ds1 = cc.ExecuteDataset(ChkEntryPre);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        string RegBoys1 = Convert.ToString(ds1.Tables[0].Rows[0]["RegBoys"]);
                        string RegGirls1 = Convert.ToString(ds1.Tables[0].Rows[0]["RegGirls"]);
                        string Present_B1 = Convert.ToString(ds1.Tables[0].Rows[0]["Present_B"]);
                        string Present_G1 = Convert.ToString(ds1.Tables[0].Rows[0]["Present_G"]);

                        string UpdateTotal = "Update UDISE_AbstractSchoolPresenty set RegBoys=" + RegBoys1 + " , RegGirls=" + RegGirls1 + ", Present_B=" + Present_B1 + ",Present_G=" + Present_G1 + "" +
                            " where SchoolCode='" + SchoolCode + "' and EntryDate ='" + DateFormat + "'";
                        int b = cc.ExecuteNonQuery(UpdateTotal);
                        if (b == 1)
                        {
                        }
                    }
                }
            }
            ZeroAttendence();
        }
        catch (Exception ex)
        { }

    }

    public void ZeroAttendence()
    {
        try
        {
            string Sql = "Select distinct(UDISE_TeacherMaster.SchoolCode),UDISE_TeacherMaster.junior_id,UDISE_TeacherMaster.leader_id  from UDISE_TeacherMaster " +
                         "where UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' and " +
                         "UDISE_TeacherMaster.SchoolCode not in(Select UDISE_AbstractSchoolPresenty.SchoolCode from UDISE_AbstractSchoolPresenty) and roleid=76 ";
            DataSet ds3 = cc.ExecuteDataset(Sql);
            for (i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                SchoolCode = Convert.ToString(ds3.Tables[0].Rows[i]["SchoolCode"]);
                string junior_id = Convert.ToString(ds3.Tables[0].Rows[i]["junior_id"]);
                string leader_id = Convert.ToString(ds3.Tables[0].Rows[i]["leader_id"]);

                if ((SchoolCode == "" || SchoolCode == null) && (junior_id == "" || junior_id == null))
                {
                    //Response.Write("<script>alert('Message Pushed Added Successfully..!')</script>");
                }
                else
                {
                    string AspPreSql = "Select EntryDate from UDISE_AbstractSchoolPresenty where SchoolCode='" + SchoolCode + "' and EntryDate='" + DateFormat + "'";
                    string ChkEntry = Convert.ToString(cc.ExecuteScalar(AspPreSql));
                    if (ChkEntry == "" || ChkEntry == null)
                    {
                        string AddStudPre = "Insert into UDISE_AbstractSchoolPresenty (SchoolCode,EntryDate,RegBoys,RegGirls,Present_B,Present_G)" +
                                         " values('" + SchoolCode + "','" + DateFormat + "','0','0','0','0')";
                        int a = cc.ExecuteNonQuery(AddStudPre);
                        if (a == 1)
                        {
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    //-------------------------------------------------Page Index Load Grid----------------------------------------------------------------------------

    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadItem();
    }

    //-----------------------------------------------------Abstract Data transfer to Archive Table on Buttn Click---------------------------------------

    protected void btnTransferArchive_Click(object sender, EventArgs e)
    {
        try
        {
            string SqlChk = "Select Asp_Id from UDISE_ArchiveSchoolPresenty where EntryDate='" + DateFormat + "'";
            ds = cc.ExecuteDataset(SqlChk);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string SqlDeleteData = "Truncate Table UDISE_AbstractSchoolPresenty";
                int status = cc.ExecuteNonQuery(SqlDeleteData);
                if (status == -1)
                {
                    LoadItem();
                    // Response.Write("<script>alert('Data Transfer Successfully')</script>");
                }
            }
            else
            {
                string Sql = "insert into [UDISE_ArchiveSchoolPresenty] (SchoolCode,EntryDate,RegBoys,RegGirls,Present_B,Present_G) " +
                             "select SchoolCode,EntryDate,RegBoys,RegGirls,Present_B,Present_G from UDISE_AbstractSchoolPresenty where EntryDate='" + DateFormat + "'";
                int a = cc.ExecuteNonQuery(Sql);
                if (a != 0)
                {
                    string SqlDeleteData = "Truncate Table UDISE_AbstractSchoolPresenty";
                    int status = cc.ExecuteNonQuery(SqlDeleteData);
                    if (status == -1)
                    {
                        LoadItem();
                        // Response.Write("<script>alert('Data Transfer Successfully')</script>");
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }

    //----------------------------------------------------------Send Message To Head masters-----------------------------------------------------------

    protected void btnSendMgs_Click(object sender, EventArgs e)
    {
        btnSendMgs.Enabled = false;
        getTotal_Hm();

    }

    //-----------------------------------------------------------Send Message To All-------------------------------------------------------------------

    protected void btnSentAll_Click(object sender, EventArgs e)
    {
        btnSentAll.Enabled = false;
        getTotal_Allstage();

    }
    public void getTotal_Hm()
    {
        try
        {
            string UserId = "", ReportId = "", RoleId = "", rolename = "", MobileNo = "", TotalRegBoys = "", TotalRegGirls = "", TotalPresent_B = "", TotlalPresent_G = "";
            string Sql = "Truncate table UDISE_AbstractSchoolPresenty Truncate table UDISE_TotalByRole";
            int status = cc.ExecuteNonQuery(Sql);
            GetAbstract();
            getcount.Exe_PresentyRecord();
            Sql = "select UserId,ReportId,RoleId,rolename,MobileNo,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G from UDISE_TotalByRole where RoleId ='76'";
            DataSet ds = cc.ExecuteDataset(Sql);
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserId = Convert.ToString(ds.Tables[0].Rows[i]["UserId"]);
                ReportId = Convert.ToString(ds.Tables[0].Rows[i]["ReportId"]);
                RoleId = Convert.ToString(ds.Tables[0].Rows[i]["RoleId"]);
                MobileNo = Convert.ToString(ds.Tables[0].Rows[i]["MobileNo"]);
                TotalRegBoys = Convert.ToString(ds.Tables[0].Rows[i]["TotalRegBoys"]);
                TotalRegGirls = Convert.ToString(ds.Tables[0].Rows[i]["TotalRegGirls"]);
                TotalPresent_B = Convert.ToString(ds.Tables[0].Rows[i]["TotalPresent_B"]);
                TotlalPresent_G = Convert.ToString(ds.Tables[0].Rows[i]["TotlalPresent_G"]);
                string sql = "select SchoolCode from UDISE_TeacherMaster where junior_id='" + UserId + "' and Active=1";
                string checkschoolCode = cc.ExecuteScalar(sql); // check hm assign or not.
                if (checkschoolCode != null || checkschoolCode != "")
                {
                    // umsg.sendmessage(ReportId, MobileNo, TotalRegBoys, TotalPresent_B, TotalRegGirls, TotlalPresent_G, checkschoolCode);
                }

            }

        }
        catch (Exception ex)
        {

        }

    }
    public void getTotal_Allstage()
    {
        try
        {
            string UserId = "", ReportId = "", RoleId = "", rolename = "", MobileNo = "", TotalSchool = "", TotalRegBoys = "", TotalRegGirls = "", TotalPresent_B = "", TotlalPresent_G = "";
            string Sql = "Truncate table UDISE_AbstractSchoolPresenty Truncate table UDISE_TotalByRole";
            int status = cc.ExecuteNonQuery(Sql);
            GetAbstract();
            getcount.Exe_PresentyRecord();
            Sql = "select UserId,ReportId,RoleId,rolename,MobileNo,TotalReporty,TotalRegBoys,TotalRegGirls,TotalPresent_B,TotlalPresent_G from UDISE_TotalByRole where  [RoleId] <> 76";
            DataSet ds = cc.ExecuteDataset(Sql);
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserId = Convert.ToString(ds.Tables[0].Rows[i]["UserId"]);
                ReportId = Convert.ToString(ds.Tables[0].Rows[i]["ReportId"]);
                RoleId = Convert.ToString(ds.Tables[0].Rows[i]["RoleId"]);
                MobileNo = Convert.ToString(ds.Tables[0].Rows[i]["MobileNo"]);
                TotalSchool = Convert.ToString(ds.Tables[0].Rows[i]["TotalReporty"]);
                TotalRegBoys = Convert.ToString(ds.Tables[0].Rows[i]["TotalRegBoys"]);
                TotalRegGirls = Convert.ToString(ds.Tables[0].Rows[i]["TotalRegGirls"]);
                TotalPresent_B = Convert.ToString(ds.Tables[0].Rows[i]["TotalPresent_B"]);
                TotlalPresent_G = Convert.ToString(ds.Tables[0].Rows[i]["TotlalPresent_G"]);
                // umsg.sendmessageTo_All(TotalSchool,ReportId, MobileNo, TotalRegBoys, TotalPresent_B, TotalRegGirls, TotlalPresent_G);
            }

        }
        catch (Exception ex)
        {

        }

    }

    public void GetRecord()
    {

        string Sql = "select  ASM.friendid,asm.roleid as RoleID,asm.rolename,ASM.Active,ASM.MainRole, ASM.userid as ReportId,UserMaster.usrMobileNo as UserMobileNo from UserMaster " +
                     "join AdminSubMarketingSubUser  as ASM  on ASM.friendid=UserMaster.usrUserId where roleid in (14,15,16,17,18,19,20,21,75,76)  ";
        // " where roleid='77' or roleid='76'";

        DataSet ds = cc.ExecuteDataset(Sql);
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            friendid = Convert.ToString(ds.Tables[0].Rows[i]["friendid"]);
            RoleID = Convert.ToString(ds.Tables[0].Rows[i]["RoleID"]);
            rolename = Convert.ToString(ds.Tables[0].Rows[i]["rolename"]);
            ReportId = Convert.ToString(ds.Tables[0].Rows[i]["ReportId"]);
            UserMobileNo = Convert.ToString(ds.Tables[0].Rows[i]["UserMobileNo"]);
            string Active = Convert.ToString(ds.Tables[0].Rows[i]["Active"]);
            string MainRole = Convert.ToString(ds.Tables[0].Rows[i]["MainRole"]);

            //Sql = " select  ASM.friendid,asm.roleid as RoleID,asm.rolename, ASM.userid   as ReportId,UserMaster.usrMobileNo as UserMobileNo ,TScode.SchoolCode  from UserMaster " +
            //      " join come2mycity.AdminSubMarketingSubUser  as ASM on ASM.friendid=UserMaster.usrUserId " +
            //      "left join UDISE_TeacherMaster as TScode on TScode.leader_id=ASM.friendid where ASM.friendid='" + TcherID + "'";
            if (RoleID == "14" || RoleID == "15" || RoleID == "16" || RoleID == "17" || RoleID == "18" || RoleID == "19" || RoleID == "20" || RoleID == "21" || RoleID == "75" || RoleID == "76")
            {
                Sql = "select * from UDISE_TeacherMaster where junior_id='" + friendid + "' and  leader_id='" + ReportId + "' and Active=1 and roleid='" + RoleID + "' ";
                DataSet ds1 = cc.ExecuteDataset(Sql);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                    {
                        if (MainRole == "0")
                        {
                        }
                        else
                        {
                            SchoolCode = "";
                            SchoolCode = Convert.ToString(ds1.Tables[0].Rows[j]["SchoolCode"]);

                            string sql = "select *  from  UDISE_GetTotalReport where UsrUserId='" + friendid + "' and  ReportId='" + ReportId + "'  and SchoolCode='" + SchoolCode + "' and roleid='" + RoleID + "' ";
                            string AlreadyAssign = cc.ExecuteScalar(sql);
                            if (AlreadyAssign == "")
                            {
                                string Sql1 = " insert into UDISE_GetTotalReport (UsrUserId,RoleId,rolename,ReportId,MobileNo,SchoolCode,Active,MainRole)" +
                                     " values ('" + friendid + "','" + RoleID + "','" + rolename + "','" + ReportId + "','" + UserMobileNo + "','" + SchoolCode + "','" + Active + "','" + MainRole + "')";
                                int a = cc.ExecuteNonQuery(Sql1);
                            }
                        }
                    }
                }
                else
                {
                    SchoolCode = "";

                    if (RoleID == "76")
                    {

                    }
                    else
                    {
                        string sql = "select *  from  UDISE_GetTotalReport where UsrUserId='" + friendid + "' and  ReportId='" + ReportId + "' and roleid='" + RoleID + "' ";
                        string AlreadyAssign = cc.ExecuteScalar(sql);
                        if (AlreadyAssign == "")
                        {
                            string Sql1 = " insert into UDISE_GetTotalReport (UsrUserId,RoleId,rolename,ReportId,MobileNo,SchoolCode,Active,MainRole)" +
                                   " values ('" + friendid + "','" + RoleID + "','" + rolename + "','" + ReportId + "','" + UserMobileNo + "','" + SchoolCode + "','" + Active + "','" + MainRole + "')";
                            int a = cc.ExecuteNonQuery(Sql1);
                        }
                    }
                }


            }
        }
    }



    protected void GetTotal_Click(object sender, EventArgs e)
    {
        GetRecord();
    }
    protected void btnSentAll_Click1(object sender, EventArgs e)
    {
        getTotal_Allstage();
    }

    //---------------------------------------------------Send The message to Zero Total Attendence to Head Master--------------------------------------

    //protected void btnZeroTotal_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string Sql = "Select distinct(UDISE_TeacherMaster.SchoolCode),UDISE_TeacherMaster.junior_id,UDISE_TeacherMaster.leader_id  from UDISE_TeacherMaster " +
    //                    "where UDISE_TeacherMaster.Class='' and UDISE_TeacherMaster.Section='' and " +
    //                    "UDISE_TeacherMaster.SchoolCode not in(Select UDISE_AbstractSchoolPresenty.SchoolCode from UDISE_AbstractSchoolPresenty where RegBoys!='0'and RegGirls!='0' and Present_B!='0'and Present_G!='0')";
    //        DataSet ds3 = cc.ExecuteDataset(Sql);
    //        for (i = 0; i < ds3.Tables[0].Rows.Count; i++)
    //        {
    //            SchoolCode = Convert.ToString(ds3.Tables[0].Rows[i]["SchoolCode"]);
    //            string junior_id = Convert.ToString(ds3.Tables[0].Rows[i]["junior_id"]);
    //            string leader_id = Convert.ToString(ds3.Tables[0].Rows[i]["leader_id"]);

    //            if ((SchoolCode == "" || SchoolCode == null) && (junior_id == "" || junior_id == null))
    //            { }
    //            else
    //            {
    //                string SqlMobileNo = "Select usrMobileNo from UserMaster where usrUserId='" + junior_id + "'";
    //                string MobileNo = Convert.ToString(cc.ExecuteScalar(SqlMobileNo));
    //                if (MobileNo == "" || MobileNo == null)
    //                { }
    //                else
    //                {
    //                    string TotalRegBoys = "0";
    //                    string TotalPresent_B = "0";
    //                    string TotalRegGirls = "0";
    //                    string TotlalPresent_G = "0";
    //                    umsg.sendmessage(leader_id, MobileNo, TotalRegBoys, TotalPresent_B, TotalRegGirls, TotlalPresent_G, SchoolCode);
    //                }
    //            }
    //        }
    //        LoadItem();
    //    }
    //    catch (Exception ex)
    //    { }
    //    //Response.Write("<script>alert('Zero Attendence Send to Head Master successfully')</script>");
    //}
}

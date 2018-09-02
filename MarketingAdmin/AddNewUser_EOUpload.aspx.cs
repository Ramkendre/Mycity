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
using System.IO;


public partial class MarketingAdmin_AddNewUser_EOUpload : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    UDISE_AddSubUser addhm = new UDISE_AddSubUser();
    int status;
    string RoleId = "";
    string usrRole = "";
    string initialreference = "", Leader_RoleName = "", Leader_RoleID = "", Leader_UserID = "", Leader_Leader;
    string reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", userid = "";
    string reference_id6 = "", reference_id7 = "", reference_id8 = "", reference_id9 = "", reference_id10 = "", reference_id11 = "";
    string UserName = "", LeaderNo, schoolcode = "", schoolName = "", fname = "", lname = "";
    int count = 1;

    string uMobileNo = "", uUsername = "", uUserId = "", uRoleId = "";
    string lMobileNo = "", lUsername = "", lUserId = "", lRoleId = "";
    string llMobileNo = "", llUsername = "", llUserId = "", llRoleId = "";


    string LLeaderNo_usrID = "", LeaderRoleId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            gridviewshow();

        }
        lblerror.Text = "";
        UserName = Convert.ToString(Session["MarketingUser"]);
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            EOFileUpload();

        }
        catch (Exception ex)
        { }

    }



    private void EOFileUpload()
    {
        try
        {
            if (CSVUpload.HasFile)
            {
                string path = "";
                path = Server.MapPath("File_Upload");
                path = path + "\\" + CSVUpload.FileName;
                if (File.Exists(path))
                {
                    File.Delete(path);
                    CSVUpload.SaveAs(path);
                }
                else
                {
                    CSVUpload.SaveAs(path);
                }
                StreamReader sr = new StreamReader(path);
                string line = sr.ReadLine();
                // do
                //{

                while (line != null)
                {

                    line = sr.ReadLine();
                    string HM_MobileNo = "", HM_Fname = "", HM_Lname = "", CH_MobileNo = "", CH_Fname = "";
                    string CH_Lname = "", ExtO_MobileNo = "", ExtO_Fname = "", ExtO_Lname = "", BEO_MobileNo = "", BEO_Fname = "", BEO_Lname = "", DEO_MobileNo = "", DEO_Fname = "";
                    string DEO_Lname = "", EO_MobileNo = "", EO_Fname = "", EO_Lname = "";

                    if (line != null)
                    {
                        string[] ArrLine = line.Split(',');
                        schoolcode = ArrLine[0];

                        if (schoolcode.Length == 11 && schoolcode != "")
                        {
                            schoolName = ArrLine[1];
                            HM_MobileNo = ArrLine[2];
                            HM_Fname = ArrLine[3];
                            HM_Lname = ArrLine[4];
                            CH_MobileNo = ArrLine[5];
                            CH_Fname = ArrLine[6];
                            CH_Lname = ArrLine[7];
                            ExtO_MobileNo = ArrLine[8];
                            ExtO_Fname = ArrLine[9];
                            ExtO_Lname = ArrLine[10];
                            BEO_MobileNo = ArrLine[11];
                            BEO_Fname = ArrLine[12];
                            BEO_Lname = ArrLine[13];
                            DEO_MobileNo = ArrLine[14];
                            DEO_Fname = ArrLine[15];
                            DEO_Lname = ArrLine[16];
                            EO_MobileNo = ArrLine[17];
                            EO_Fname = ArrLine[18];
                            EO_Lname = ArrLine[19];

                            if (EO_MobileNo.Length == 10)
                            {
                                // string Deputy = "9422937796";
                                // string Deputy = "9422937796";

                                //  string Deputy = Convert.ToString(Session["MobileNumber"]);

                                // string SQl="select e2.userid as LeaderuserId,U2.usrMobileNo as LeadermobileNo,U3.usrMobileNo as JuniouruserID, e3.userid  as JuniourmobileNo "+

                                string SQl = "select U2.usrMobileNo as LeadermobileNo " +
                                           " from TreeDemo e2 " +
                                           " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                                           " join TreeDemo e3 on e2.id=e3.parentid " +
                                           " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                                           " where U3.usrMobileNo='" + Convert.ToString(Session["MobileNumber"]) + "'";

                                SQl = SQl + "select U2.usrMobileNo as LLeadermobileNo " +
                                          " from TreeDemo e2 " +
                                          " join UserMaster as U2 on U2.usrUserId=e2.userid " +
                                          " join TreeDemo e3 on e2.id=e3.parentid " +
                                          " join UserMaster as U3 on U3.usrUserId=e3.userid " +
                                          " where U3.usrMobileNo in(" + SQl + ")";

                                string Deputy, Director = "";//= cc.ExecuteScalar(SQl);
                                DataSet ds = cc.ExecuteDataset(SQl);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Deputy = Convert.ToString(ds.Tables[0].Rows[0]["LeadermobileNo"]);
                                    Director = Convert.ToString(ds.Tables[1].Rows[0]["LLeadermobileNo"]);


                                    AddSubUser_EO1(EO_MobileNo, EO_Fname, EO_Lname, Deputy, Director, 17);  //For EO


                                    if (DEO_MobileNo.Length == 10)
                                    {

                                        AddSubUser_EO1(DEO_MobileNo, DEO_Fname, DEO_Lname, EO_MobileNo, Deputy, 18);//For DEO


                                        if (BEO_MobileNo.Length == 10)
                                        {

                                            AddSubUser_EO1(BEO_MobileNo, BEO_Fname, BEO_Lname, DEO_MobileNo, EO_MobileNo, 19);//For BEO

                                            if (ExtO_MobileNo.Length == 10)
                                            {
                                                AddSubUser_EO1(ExtO_MobileNo, ExtO_Fname, ExtO_Lname, BEO_MobileNo, DEO_MobileNo, 20);//For ExtO

                                                if (CH_MobileNo.Length == 10)
                                                {
                                                    AddSubUser_EO1(CH_MobileNo, CH_Fname, CH_Lname, ExtO_MobileNo, BEO_MobileNo, 21);//For CH

                                                    if (HM_MobileNo.Length == 10)
                                                    {

                                                        AddSubUser_EO1(HM_MobileNo, HM_Fname, HM_Lname, CH_MobileNo, ExtO_MobileNo, 75);//For HM

                                                    }
                                                    else
                                                    {
                                                        count = count + 1;
                                                        lblerror.Visible = true;
                                                        lblerror.Text = lblerror.Text + "<br/> Please Enter Head Master 10 digit Mobile No - Error on Rows No " + count + " ";
                                                        break;

                                                    }
                                                }
                                                else
                                                {
                                                    count = count + 1;
                                                    lblerror.Visible = true;
                                                    lblerror.Text = lblerror.Text + "<br/> Please Enter Proper Cluster Head 10 digit Mobile No - Error on Rows No " + count + " ";
                                                    break;

                                                }
                                            }
                                            else
                                            {
                                                count = count + 1;
                                                lblerror.Visible = true;
                                                lblerror.Text = lblerror.Text + "<br/> Please Enter Proper Extension Officer 10 digit Mobile No - Error on Rows No " + count + " ";
                                                break;

                                            }
                                        }
                                        else
                                        {
                                            count = count + 1;
                                            lblerror.Visible = true;
                                            lblerror.Text = lblerror.Text + "<br/> Please Enter Proper BEO.(Block Education Officer) 10 digit Mobile No - Error on Rows No " + count + " ";
                                            break;

                                        }
                                    }
                                    else
                                    {
                                        count = count + 1;
                                        lblerror.Visible = true;
                                        lblerror.Text = lblerror.Text + " <br/>Please Enter Proper Deputy Education Officer 10 digit Mobile No - Error on Rows No " + count + " ";
                                        break;
                                    }
                                }
                                else
                                {
                                    count = count + 1;
                                    lblerror.Visible = true;
                                    lblerror.Text = lblerror.Text + "<br/> Please Enter Proper (Education Officer) 10 digit Mobile No - Error on Rows No " + count + " ";
                                    break;

                                }

                            }
                            else
                            {
                                count = count + 1;
                                lblerror.Visible = true;
                                lblerror.Text = lblerror.Text + "<br/> Please Enter Proper school Code - Error on Rows No " + count + " ";
                                break;
                            }
                        }

                    }
                    else
                    {
                        Response.Write("<script>(alert)('Upload  Head Master Detail Successful.')</script>");

                    }
                    count = count + 1;

                    //} while (line != null);

                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>(alert)('Please Change File Name')</script>");
        }
    }
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
            if ( JuniorRoleID == "76")
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

    private void gridviewshow()
    {
        UserName = Convert.ToString(Session["MarketingUser"]);
        if (UserName == null || UserName == "")
        {
            Response.Redirect("../MarketingAdmin/login.aspx");
        }
        else
        {

            string sql21 = "select Roleid from AdminSubMarketingSubUser where friendid='" + UserName + "' and Active='1'";
            string id1 = cc.ExecuteScalar(sql21);
            if (id1 != "76")
            {
                string sql = "select  friendid,SubMenuPermission.RoleName,usrFirstName+''+usrLastName as FullName,usrMobileNo,usrCity from usermaster inner join AdminSubMarketingSubUser on usermaster.usrUserid=AdminSubMarketingSubUser.friendid inner join SubMenuPermission on AdminSubMarketingSubUser.Roleid=SubMenuPermission.Roleid  where AdminSubMarketingSubUser.userid='" + UserName + "' and AdminSubMarketingSubUser.Active='1'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvView.DataSource = ds.Tables[0];
                gvView.DataBind();
                gvView.Visible = true;
                gvsecond.Visible = false;

            }
            else
            {
                string sql = "select  UDISE_TeacherMaster.SchoolCode,friendid,SubMenuPermission.RoleName,usrFirstName+''+usrLastName as FullName,usrMobileNo,usrCity from usermaster inner join AdminSubMarketingSubUser on usermaster.usrUserid=AdminSubMarketingSubUser.friendid inner join SubMenuPermission on AdminSubMarketingSubUser.Roleid=SubMenuPermission.Roleid   inner join UDISE_TeacherMaster on UDISE_TeacherMaster.junior_id =AdminSubMarketingSubUser.friendid where AdminSubMarketingSubUser.userid='" + UserName + "' and AdminSubMarketingSubUser.Active='1'";
                DataSet ds = cc.ExecuteDataset(sql);
                gvsecond.DataSource = ds.Tables[0];
                gvsecond.DataBind();
                gvsecond.Visible = true;
                gvView.Visible = false;
            }

        }
    }

    protected void btnDownLoad_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/File_Upload/HM_UploadCSVFileFormat.csv");
    }
}

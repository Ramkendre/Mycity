using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for AppsHirarchy
/// </summary>
public class AppsHirarchy
{
    CommonCode cc = new CommonCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    int status;
    string sql, Jr_ID;
    string RoleId = "";
    string usrRole = "";
    string initialreference = "", Leader_RoleName = "", Leader_MobileNo, Leader_RoleID = "", Leader_UserID = "", Leader_Leader;
    string reference_id2 = "", reference_id3 = "", reference_id4 = "", reference_id5 = "", userid = "";
    string reference_id6 = "", reference_id7 = "", reference_id8 = "", reference_id9 = "", reference_id10 = "", reference_id11 = "";
    string UserName = "", LeaderNo, SchoolCode = "", schoolName = "", Fname = "", Lname = "", CurrenctDate = "";
    int count = 1;
    public AppsHirarchy()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void AddSubUser_EO1(string EO_Mob, string Firstname, string Lastname, string leaderno)
    {
        urUserRegBLLObj.Customermobileno = EO_Mob;
        status = urUserRegBLLObj.BLLSearchUserExist(urUserRegBLLObj);
        if (status > 0)
        {
            string getuserID_Leader = "select usrUserid from usermaster where usrMobileNo='" + leaderno + "'";
            Leader_UserID = cc.ExecuteScalar(getuserID_Leader); // get Leader usruserID
            if (Leader_UserID == "")
            {

            }
            else
            {
                string sql = "select id from AdminSubMarketingSubUser where friendid='" + Jr_ID + "' and userid='" + Leader_UserID + "'";
                string AlreadyAssign = cc.ExecuteScalar(sql);
                if (AlreadyAssign == "")
                {
                    AddNewUser1(EO_Mob, leaderno);
                }
                else
                {
                    // already Assign 
                }
            }
        }
        else
        {
            int Status = Addnew(Fname, Lname, EO_Mob);
            if (Status == 1)
            {
                AddSubUser_EO1(EO_Mob, Fname, Lname, leaderno);
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
    private void AddNewUser1(string JuniorNo, string leader_no)
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
            string sql21 = "select id from AdminSubMarketingSubUser where friendid='" + JuniorNo_usrID + "' and userid='" + Leader_UserID + "' ";

            string Chk_AlreadyAssign = cc.ExecuteScalar(sql21); // check juniour already assign
            if (!(Chk_AlreadyAssign == null || Chk_AlreadyAssign == ""))
            {
                //  Response.Write("<script>(alert)('This User is already subuser of other, You cannot assign ')</script>");
            }
            else
            {


                string cref = "";
                string Checkref = "";
                if (JuniorRoleID == "76")
                //      if (JuniorRoleID == "41")
                {
                    cref = "select friendid from AdminSubMarketingSubUser where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and friendid = '" + JuniorNo_usrID + "' and Active='1'";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign
                }
                else
                {
                    cref = "select friendid from AdminSubMarketingSubUser where    userid='" + Leader_UserID + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "' and   friendid = '" + JuniorNo_usrID + "' and Active='1' ";
                    Checkref = cc.ExecuteScalar(cref); // check juniour already assign

                }

                if (!(Checkref == null || Checkref == ""))
                {
                    if (Checkref != JuniorNo_usrID)
                    {
                        string SQL = "update AdminSubMarketingSubUser set friendid='" + JuniorNo_usrID + "' , Ref_Ways='UpdateHMLIST' , Active='1'   where userid='" + Leader_UserID + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(reference_id11) + "'  ";
                        int a = cc.ExecuteNonQuery(SQL);
                        string qry;
                        int status;
                        if (a == 1)
                        {
                            if (reference_id2 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id2='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and  reference_id1='" + reference_id1 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);

                            }
                            if (reference_id3 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id3='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id4 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id4='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + Checkref + "' '";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id5 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id5='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id6 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id6='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id7 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id7='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + Checkref + "' ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id8 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id8='" + JuniorNo_usrID + "' where   reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id9 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id9='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + Checkref + "'  ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id10 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id10='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + Checkref + "'";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "'  ";
                                qry = qry + "update UDISE_TeacherMaster set leader_id='" + JuniorNo_usrID + "' where leader_id='" + Checkref + "'";
                                qry = qry + "update UDISE_TeacherMaster set junior_id='" + JuniorNo_usrID + "' where junior_id='" + Checkref + "'";
                                qry = qry + "update TreeDemo set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "'";

                                status = cc.ExecuteNonQuery(qry);


                            }
                            if (reference_id11 == "")
                            {
                                qry = "update AdminSubMarketingSubUser set reference_id11='" + JuniorNo_usrID + "' where  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "' and reference_id11='" + Convert.ToString(Checkref) + "'  ";
                                qry = qry + "update AdminSubMarketingSubUser set userid='" + JuniorNo_usrID + "' where userid='" + Checkref + "' and  reference_id1='" + reference_id1 + "' and reference_id2='" + reference_id2 + "' and reference_id3='" + reference_id3 + "' and reference_id4='" + reference_id4 + "' and reference_id5='" + reference_id5 + "' and  reference_id6='" + reference_id6 + "' and reference_id7='" + reference_id7 + "' and reference_id8='" + reference_id8 + "' and  reference_id9='" + reference_id9 + "' and reference_id10='" + reference_id10 + "'  ";
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

                    string AddJunior = "insert into AdminSubMarketingSubUser(userid,friendid,doj,roleid,rolename,reference_id1,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11,Ref_Ways,Active)" +
                           " values('" + Leader_UserID + "','" + JuniorNo_usrID + "','" + date_ofJoin + "','" + JuniorRoleID + "','" + JuniorRoleName + "','" + reference_id1 + "','" + reference_id2 + "','" + reference_id3 + "','" + reference_id4 + "','" + reference_id5 + "','" + reference_id6 + "','" + reference_id7 + "','" + reference_id8 + "','" + reference_id9 + "','" + reference_id10 + "','" + reference_id11 + "','ASCIIPage','1' )";
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


            string Getreference = "select userid,roleid,rolename,friendid,reference_id2,reference_id3,reference_id4,reference_id5,reference_id6,reference_id7,reference_id8,reference_id9,reference_id10,reference_id11 from AdminSubMarketingSubUser where friendid='" + Leader_UserID + "'  and Active='1'";

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
}

//public void AddSubUser(string mobile, string fname, string lname, string schoolcode, string usrclass, string section, string Hm_usrID)
//{
//    try
//    {
//        DateTime dt = DateTime.Now; // get current date
//        double d = 5; //add hours in time
//        double m = 48; //add min in time
//        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
//        SystemDate = SystemDate.AddMinutes(m);
//        CurrenctDate = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
//        urUserRegBLLObj.Customermobileno = mobile;
//        Leader_UserID = Hm_usrID;
//        SchoolCode = schoolcode;
//        Fname = fname;
//        Lname = lname;
//        status = urUserRegBLLObj.BLLSearchUserExist(urUserRegBLLObj);
//        if (status > 0)
//        {

//            if (mobile != "" && mobile.Length == 10)
//            {
//                sql = "select usrUserid from usermaster where usrMobileNo='" + Convert.ToString(mobile) + "'";
//                Jr_ID = cc.ExecuteScalar(sql);

//                sql = "select id from AdminSubMarketingSubUser where   friendid='" + Convert.ToString(Jr_ID) + "' and roleid=76 and userid= '" + Convert.ToString(Hm_usrID) + "'";
//                string Check_HMavailable = cc.ExecuteScalar(sql); // check hm assign or not.
//                if (Check_HMavailable != "" || Check_HMavailable != null)
//                {

//                    sql = "select SchoolCode from UDISE_TeacherMaster where junior_id='" + Jr_ID + "' and Active=1";
//                    string checkschoolCode = cc.ExecuteScalar(sql); // check hm assign or not.
//                    if (checkschoolCode != schoolcode &&  checkschoolCode !="")
//                    {
//                        sql = "select id from UDISE_TeacherMaster where junior_id='" + Jr_ID + "' and Class='' and Section='' and Active=1  and  SchoolCode= '" + checkschoolCode + "'";
//                        string HM = cc.ExecuteScalar(sql); //  Get Hm
//                        if (HM != "" || HM != null)
//                        {

//                        }
//                        else
//                        {
//                            sql = "Update UDISE_TeacherMaster set Active=0 ,EntryDate='" + CurrenctDate + "'  where SchoolCode= '" + checkschoolCode + "' and junior_id='" + Jr_ID + "'";
//                            int Teach = cc.ExecuteNonQuery(sql);// update tecaher status
//                            if (Teach == 1)
//                            {

//                            }
//                        }
//                    }
//                    else
//                    {

//                        sql = "select id from UDISE_TeacherMaster where junior_id='" + Jr_ID + "' and SchoolCode= '" + schoolcode + "' and Active=1";
//                        string Check_TecaherAlredyAssign = cc.ExecuteScalar(sql);// check  current teacher or HM assign or not perticular school code
//                        if (Check_TecaherAlredyAssign != "" || Check_TecaherAlredyAssign != null)
//                        {
//                            sql = "select id from UDISE_TeacherMaster where SchoolCode= '" + schoolcode + "' and Class='" + usrclass + "' and Section='" + section + "' and Active=1 ";
//                            string checl_ClassAssign = cc.ExecuteScalar(sql);// check this school code ,class & section already assign or not
//                            if (checl_ClassAssign == "" || checl_ClassAssign == null)
//                            {
//                                sql = "insert into UDISE_TeacherMaster(leader_id,junior_id,SchoolCode,Class,Section,EntryDate,Active)" +
//                                                        "values('" + Leader_UserID + "','" + Jr_ID + "','" + schoolcode + "','" + usrclass + "','" + section + "','" + CurrenctDate + "',1)";
//                                int a = cc.ExecuteNonQuery(sql); // add tecaher or Hm in Tecaher Master

//                                if (a == 1)
//                                {

//                                    string SQL = "select * from usermaster where usrUserid='" + Jr_ID + "'";
//                                    SQL = SQL + "select usrMobileNo  from usermaster where usrUserid='" + Leader_UserID + "'";
//                                    DataSet ds = cc.ExecuteDataset(SQL);
//                                    if (ds.Tables[0].Rows.Count > 0)
//                                    {
//                                        // string sqll = "select usrMobileNo  from usermaster where usrUserid='" + Leader_UserID + "'";
//                                        // string leaderMobileNo = cc.ExecuteScalar(sqll);
//                                        string myMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);
//                                        string myPassword = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));
//                                        string passwordMessage;
//                                        Leader_MobileNo = Convert.ToString(ds.Tables[1].Rows[0]["usrMobileNo"]);
//                                        // string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
//                                        if (section == "" && usrclass == "")
//                                        {
//                                            passwordMessage = "U R Registered as HM for school " + schoolcode + " by " + Leader_MobileNo + " ur login pwd for www.myct.in & www.udisecce.myct.in is " + myPassword + " " + cc.AddSMS(myMobileNo);
//                                        }
//                                        else
//                                        {
//                                            passwordMessage = "U R Registered as Teacher for class " + usrclass + "(" + section + ")of school " + schoolcode + " by " + Leader_MobileNo + " send every day DAR sms on 8378977897. Ur password is " + myPassword + " for " + cc.AddSMS(myMobileNo);
//                                        }
//                                        int smslength = passwordMessage.Length;
//                                       // cc.SendMessageUdiseSMS("UDISE", myMobileNo, passwordMessage, smslength);
//                                    }

//                                }
//                                else
//                                {


//                                }
//                                // AddNewUser(Hm_usrID, Jr_ID);                               
//                                AddSubUser_EO1(mobile, Fname, Lname, Leader_MobileNo);


//                            }
//                            else
//                            {
//                                string chkUserId = "select junior_id from UDISE_TeacherMaster where SchoolCode= '" + schoolcode + "' and Class='" + usrclass + "' and Section='" + section + "'";
//                                string TRUserId = cc.ExecuteScalar(chkUserId); // check this school code ,class & section already assign or not
//                                if (TRUserId == "" || TRUserId == null)
//                                {

//                                }
//                                else
//                                {
//                                    sql = "Update UDISE_TeacherMaster set junior_id='" + Jr_ID + "' , EntryDate='" + CurrenctDate + "', Active=1  where SchoolCode= '" + schoolcode + "' and Class='" + usrclass + "' and Section='" + section + "' ";
//                                    string UpTeach = Convert.ToString(cc.ExecuteNonQuery(sql)); // update class ,section & school code
//                                    if (UpTeach == "" || UpTeach == null)
//                                    {

//                                        string SQL = "select * from usermaster where usrUserid='" + Jr_ID + "'";
//                                        SQL = SQL + "select usrMobileNo  from usermaster where usrUserid='" + Leader_UserID + "'";
//                                        DataSet ds = cc.ExecuteDataset(SQL);
//                                        if (ds.Tables[0].Rows.Count > 0)
//                                        {
//                                            // string sqll = "select usrMobileNo  from usermaster where usrUserid='" + Leader_UserID + "'";
//                                            // string leaderMobileNo = cc.ExecuteScalar(sqll);
//                                            string myMobileNo = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);
//                                            string myPassword = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));
//                                            string passwordMessage;
//                                            Leader_MobileNo = Convert.ToString(ds.Tables[1].Rows[0]["usrMobileNo"]);
//                                            // string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
//                                            if (section == "" && usrclass == "")
//                                            {
//                                                passwordMessage = "U R Registered as HM for school " + schoolcode + " by " + Leader_MobileNo + " ur login pwd for www.myct.in & www.udisecce.myct.in is " + myPassword + " " + cc.AddSMS(myMobileNo);
//                                            }
//                                            else
//                                            {
//                                                passwordMessage = "U R Registered as Teacher for class " + usrclass + "(" + section + ")of school " + schoolcode + " by " + Leader_MobileNo + " send every day DAR sms on 8378977897. Ur password is " + myPassword + " for " + cc.AddSMS(myMobileNo);

//                                             }
//                                            int smslength = passwordMessage.Length;
//                                           // cc.SendMessageUdiseSMS("UDISE", myMobileNo, passwordMessage, smslength);
//                                        }

//                                    }
//                                    else
//                                    {
//                                        //string UDAdmin = "update AdminSubMarketingSubUser set friendid='" + Jr_ID + "' where roleid=41 and friendid='" + TRUserId + "' and reference_id10='"+Leader_UserID+"'";
//                                        //int a = cc.ExecuteNonQuery(UDAdmin);

//                                    }
//                                }
//                            }
//                        }
//                        else
//                        {



//                        }
//                    }

//                }
//                //else
//                //{
//                //    //string Checkschoolcode = "select SchoolCode from UDISE_TeacherMaster where junior_id='" + frndid + "' and SchoolCode= '" + schoolcode + "'";
//                //    //string Scode = cc.ExecuteScalar(Checkschoolcode);
//                //    //if (Scode == "" || Scode == null)
//                //    //{

//                //    //}
//                //    //else
//                //    //{

//                //    sql = "select SchoolCode from UDISE_TeacherMaster where junior_id='" + Jr_ID + "'";
//                //    string schoolcode1 = cc.ExecuteScalar(sql);
//                //    if (schoolcode1 == "" || schoolcode1 == null)
//                //    {
//                //        sql = "select id from UDISE_TeacherMaster where junior_id='" + Jr_ID + "' and SchoolCode= '" + schoolcode + "'";
//                //        string id = cc.ExecuteScalar(sql);
//                //        if (id == "" || id == null)
//                //        {
//                //            sql = "insert into UDISE_TeacherMaster(leader_id,junior_id,SchoolCode,Class,Section)" +
//                //                                    "values('" + Leader_UserID + "','" + Jr_ID + "','" + schoolcode + "','" + usrclass + "','" + section + "')";
//                //            int a = cc.ExecuteNonQuery(sql);
//                //        }
//                //        else
//                //        {
//                //        }
//                //    }
//                //    else
//                //    {
//                //        string chkUserId = "select junior_id from UDISE_TeacherMaster where SchoolCode= '" + schoolcode + "' and Class='" + usrclass + "' and Section='" + section + "'";
//                //        string TRUserId = cc.ExecuteScalar(chkUserId);
//                //        if (TRUserId == "" || TRUserId == null)
//                //        {

//                //        }
//                //        else
//                //        {
//                //            sql = "Update UDISE_TeacherMaster set junior_id='" + Jr_ID + "' where SchoolCode= '" + schoolcode + "' and Class='" + usrclass + "' and Section='" + section + "'";
//                //            string UpTeach = Convert.ToString(cc.ExecuteNonQuery(sql));
//                //            if (UpTeach == "" || UpTeach == null)
//                //            {

//                //            }
//                //            else
//                //            {
//                //                string UDAdmin = "update AdminSubMarketingSubUser set friendid='" + Jr_ID + "' where roleid=77 and friendid='" + TRUserId + "'";
//                //                int a = cc.ExecuteNonQuery(UDAdmin);
//                //            }
//                //        }
//                //    }
//                //}
//                // }
//            }
//            else
//            {
//                //int Status = Addnew(fname, lname, mobile);
//                //if (Status == 1)
//                //{
//                //    AddSubUser(mobile, fname, lname, schoolcode, usrclass, section, Hm_usrID);
//                //}
//            }
//        }
//        else
//        {
//            int Status = Addnew(fname, lname, mobile);
//            if (Status == 1)
//            {
//                AddSubUser(mobile, fname, lname, schoolcode, usrclass, section, Hm_usrID);
//            }
//        }
//    }
//    catch (Exception ez)
//    {

//    }

//}

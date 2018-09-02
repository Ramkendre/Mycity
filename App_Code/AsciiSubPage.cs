
#region Namespaces

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

#endregion Namespaces

/// <summary>
/// 
/// </summary>
/// 
public class AsciiSubPage
{

    #region Classtype
    CommonCode cc = new CommonCode();
    udisecce.MdmDetails mdm = new udisecce.MdmDetails();
    #endregion Classtype

    #region DataType

    string Data = "New";
    string[] WholeMgs;
    string[] SplitMsg;

    #endregion DataType

    public AsciiSubPage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //---------------------------------------------------User Registration---------------------------------------------------------------------------

    #region UserRegistration
    public string UserRegistration(string Username, string MobileNo, string usrEmailId, string usrGender, string Age)
    {
        string userid = "";
        try
        {
            //string[] FullName = Username.Split(' ');
            //string fname = Convert.ToString(FullName[0].Trim());
            //string lname = Convert.ToString(FullName[1].Trim());

            userid = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            string pwd = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            string Sql = "insert into usermaster(usrUserId,usrFirstName,usrMobileNo,usrPassword,usrEmailId,usrGender,Age)" +
                     " values('" + userid + "','" + Username + "','" + MobileNo + "','" + pwd + "','" + usrEmailId + "','" + usrGender + "','" + Age + "')";
            int ID = cc.ExecuteNonQuery(Sql);
            if (ID == 1)
            {
                string myPassword = cc.DESDecrypt(pwd);
                string passwordMessage = "Dear " + Username + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(MobileNo);
                int smslength = passwordMessage.Length;
                cc.TransactionalSMSCountry("Website", MobileNo, passwordMessage, smslength, 7);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return userid;
    }
    #endregion UserRegistration

    //---------------------------------------------------UDISE ADM  Keyword--------------------------------------------------------------------------

    #region UdiseADM

    public void UdiseAdm(string MobileNo, string Smsbody, string CurrenctDate, string p1, string p2)
    {
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' or userid='" + getuserID + "' and Active=1 and mainrole=1 ";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "" || GetRoleID == null)
                {
                    // Hm/texcaher not define
                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    if (GetRoleID == "76")
                    {
                        string checkschoolcode = "select sm.SchoolCode from UDISE_SchoolMaster as sm inner join UDISE_TeacherMaster as Tm on Tm.SchoolCode=sm.SchoolCode  where Tm.junior_id='" + getuserID + "' and Tm.Active=1";
                        string Getschoolcode = cc.ExecuteScalar(checkschoolcode);
                        if (Getschoolcode == "" || Getschoolcode == null)
                        {
                            //get teacher/Hm Not define School 
                            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                   " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                            int b = cc.ExecuteNonQuery(Sql);
                        }
                        else
                        {
                            string strup = Smsbody.ToUpper();
                            string strwh = strup.Replace("ADM*", "");
                            WholeMgs = strwh.Trim().Split('#');
                            for (int k = 0; k < WholeMgs.Length; k++)
                            {
                                string Attendence = WholeMgs[k].ToString();
                                SplitMsg = Attendence.Split('*');

                                string GetDate = "Select Stud_Id from UDISE_RegisterStudent where Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "' and SchoolCode='" + Getschoolcode + "'";
                                string studId = Convert.ToString(cc.ExecuteScalar(GetDate));
                                if (studId == "" || studId == null)
                                {

                                    string AddStudPre = "insert into UDISE_RegisterStudent(usrUserId,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls)" +
                                          "values('" + getuserID + "','" + Getschoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + SplitMsg[0].Trim() + "','" + SplitMsg[1].Trim() + "','" + SplitMsg[3].Trim() + "','" + SplitMsg[5].Trim() + "')";
                                    int a = cc.ExecuteNonQuery(AddStudPre);
                                    if (a == 1)
                                    {
                                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                    " ('" + Attendence.Trim() + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','Y','" + p1 + "','" + p2 + "' )";
                                        int b = cc.ExecuteNonQuery(Sql);
                                    }
                                }
                                else
                                {
                                    string UpdateStudPre = "update UDISE_RegisterStudent set usrUserId='" + getuserID + "',SchoolCode='" + Getschoolcode + "',Class='" + SplitMsg[0].Trim() + "',Division='" + SplitMsg[1].Trim() + "',RegBoys='" +
                                        SplitMsg[3].Trim() + "',RegGirls='" + SplitMsg[5].Trim() + "' where SchoolCode='" + Getschoolcode + "' and Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "'";
                                    int a = cc.ExecuteNonQuery(UpdateStudPre);
                                    if (a == 1)
                                    {
                                    }
                                }
                                string AllDiseMsg = " insert into UDISE_AllMessage(SchoolCode,Message,mobile,Keword,Date)" +
                                   "values('" + Getschoolcode + "','" + Attendence.Trim() + "','" + MobileNo + "','','" + Convert.ToString(CurrenctDate) + "')";
                                int aa = cc.ExecuteNonQuery(AllDiseMsg);
                            }
                        }
                    }
                    else
                    {
                        //not assign techaer/hm role perticular user
                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                  " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                        int b = cc.ExecuteNonQuery(Sql);
                    }
                }
            }
            else
            {
                //not registered
                string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                             " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                int b = cc.ExecuteNonQuery(Sql);
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                      " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }

    #endregion UdiseADM

    //---------------------------------------------------UDISE MDM  Keyword--------------------------------------------------------------------------

    #region UdiseMDM

    public void UdiseMDM(string MobileNo, string Smsbody, string CurrenctDate, string p1, string p2)
    {
        try
        {
            //string Attendence = "";

            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' or userid='" + getuserID + "' and Active=1 and mainrole=1 ";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "" || GetRoleID == null)
                {
                    // Hm/texcaher not define
                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                    " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                    int b = cc.ExecuteNonQuery(Sql);
                }
                else
                {
                    if (GetRoleID == "76" || GetRoleID == "77")
                    {
                        string checkschoolcode = "select sm.SchoolCode from UDISE_SchoolMaster as sm inner join UDISE_TeacherMaster as Tm on Tm.SchoolCode=sm.SchoolCode  where Tm.junior_id='" + getuserID + "' and Tm.Active=1";
                        string Getschoolcode = cc.ExecuteScalar(checkschoolcode);
                        if (Getschoolcode == "" || Getschoolcode == null)
                        {
                        }
                        else
                        {
                            WholeMgs = Smsbody.Trim().Split('#');
                            string Attendence = WholeMgs[0].ToString();

                            for (int k = 1; k < WholeMgs.Length; k++)
                            {
                                if (k == 1)
                                {
                                    Attendence = WholeMgs[k].ToString();
                                    Attendence = Attendence.Replace("DAR*", "");
                                    SplitMsg = Attendence.Split('*');

                                    string GetReg = "Select RegBoys ,RegGirls FROM UDISE_RegisterStudent where Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "' and SchoolCode='" + Getschoolcode + "'";
                                    DataSet ds = cc.ExecuteDataset(GetReg);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        string RegBoys = Convert.ToString(ds.Tables[0].Rows[0]["RegBoys"]);
                                        string RegGirls = Convert.ToString(ds.Tables[0].Rows[0]["RegGirls"]);
                                        if ((RegBoys == "" || RegGirls == "") || (RegBoys == null || RegGirls == null))
                                        { }
                                        else
                                        {
                                            string GetDate = "Select EntryDate from UDISE_StudentPresenty where EntryDate='" + Convert.ToString(CurrenctDate) + "' and Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "' and SchoolCode='" + Getschoolcode + "'";
                                            string FindDate = Convert.ToString(cc.ExecuteScalar(GetDate));
                                            if (FindDate == "" || FindDate == null)
                                            {

                                                string AddStudPre = "insert into UDISE_StudentPresenty(usrUserId,Keyword,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls,Present_B,Present_G,Created,mdmStudPresent)" +
                                                      "values('" + getuserID + "','MDM','" + Getschoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + SplitMsg[0].Trim() + "','" + SplitMsg[1].Trim() + "','" + RegBoys + "','" + RegGirls + "','" + SplitMsg[3].Trim() + "','" + SplitMsg[5].Trim() + "','Myct','" + SplitMsg[7].Trim() + "')";
                                                int a = cc.ExecuteNonQuery(AddStudPre);
                                                if (a == 1)
                                                {
                                                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                                " ('" + Attendence.Trim() + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','Y','" + p1 + "','" + p2 + "' )";
                                                    int b = cc.ExecuteNonQuery(Sql);
                                                }
                                            }
                                            else
                                            {
                                                string UpdateStudPre = "update UDISE_StudentPresenty set usrUserId='" + getuserID + "',Keyword='MDM',SchoolCode='" + Getschoolcode + "',Class='" + SplitMsg[0].Trim() + "',Division='" + SplitMsg[1].Trim() + "',RegBoys='" +
                                                    RegBoys + "',RegGirls='" + RegGirls + "',Present_B='" + SplitMsg[3].Trim() + "',Present_G='" + SplitMsg[5].Trim() + "',mdmStudPresent='" + SplitMsg[7].Trim() + "' where EntryDate='" + Convert.ToString(CurrenctDate) + "' and SchoolCode='" + Getschoolcode + "' and Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "'";
                                                int a = cc.ExecuteNonQuery(UpdateStudPre);
                                                if (a == 1)
                                                {
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //not assign techaer/hm role perticular user
                                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                  " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                                        int b = cc.ExecuteNonQuery(Sql);
                                    }

                                }
                                else
                                {
                                    Attendence = WholeMgs[k].ToString();
                                    SplitMsg = Attendence.Split('*');

                                    string GetReg = "Select RegBoys ,RegGirls FROM UDISE_RegisterStudent where Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "' and SchoolCode='" + Getschoolcode + "'";
                                    DataSet ds = cc.ExecuteDataset(GetReg);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        string RegBoys = Convert.ToString(ds.Tables[0].Rows[0]["RegBoys"]);
                                        string RegGirls = Convert.ToString(ds.Tables[0].Rows[0]["RegGirls"]);

                                        if ((RegBoys == "" || RegGirls == "") || (RegBoys == null || RegGirls == null))
                                        { }
                                        else
                                        {
                                            string GetDate = "Select EntryDate from UDISE_StudentPresenty where EntryDate='" + Convert.ToString(CurrenctDate) + "' and Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "' and SchoolCode='" + Getschoolcode + "'";
                                            string FindDate = Convert.ToString(cc.ExecuteScalar(GetDate));
                                            if (FindDate == "" || FindDate == null)
                                            {

                                                string AddStudPre = "insert into UDISE_StudentPresenty(usrUserId,Keyword,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls,Present_B,Present_G,Created,mdmStudPresent)" +
                                                      "values('" + getuserID + "','MDM','" + Getschoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + SplitMsg[0].Trim() + "','" + SplitMsg[1].Trim() + "','" + RegBoys + "','" + RegGirls + "','" + SplitMsg[3].Trim() + "','" + SplitMsg[5].Trim() + "','Myct','" + SplitMsg[7].Trim() + "')";
                                                int a = cc.ExecuteNonQuery(AddStudPre);
                                                if (a == 1)
                                                {
                                                    string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                                " ('" + Attendence.Trim() + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','0','Y','" + p1 + "','" + p2 + "' )";
                                                    int b = cc.ExecuteNonQuery(Sql);
                                                }
                                            }
                                            else
                                            {
                                                string UpdateStudPre = "update UDISE_StudentPresenty set usrUserId='" + getuserID + "',Keyword='MDM',SchoolCode='" + Getschoolcode + "',Class='" + SplitMsg[0].Trim() + "',Division='" + SplitMsg[1].Trim() + "',RegBoys='" +
                                                    RegBoys + "',RegGirls='" + RegGirls + "',Present_B='" + SplitMsg[3].Trim() + "',Present_G='" + SplitMsg[5].Trim() + "',mdmStudPresent='" + SplitMsg[7].Trim() + "' where EntryDate='" + Convert.ToString(CurrenctDate) + "' and SchoolCode='" + Getschoolcode + "' and Class='" + SplitMsg[0].Trim() + "' and Division='" + SplitMsg[1].Trim() + "'";
                                                int a = cc.ExecuteNonQuery(UpdateStudPre);
                                                if (a == 1)
                                                {

                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //not assign techaer/hm role perticular user
                                        string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                  " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','3','N','" + p1 + "','" + p2 + "' )";
                                        int b = cc.ExecuteNonQuery(Sql);
                                    }
                                }
                            }
                            for (int k = 0; k < WholeMgs.Length; k++)
                            {
                                if (k == 0)
                                {
                                    Attendence = WholeMgs[0].ToString();
                                    SplitMsg = Attendence.Split('*');
                                    mdm.Menudetails(Getschoolcode, SplitMsg[1], getuserID);
                                }
                                break;
                            }
                            string AllDiseMsg = " insert into UDISE_AllMessage(SchoolCode,Message,mobile,Keword,Date)" +
                                  "values('" + Getschoolcode + "','" + Smsbody.Trim() + "','" + MobileNo + "','','" + Convert.ToString(CurrenctDate) + "')";
                            int aa = cc.ExecuteNonQuery(AllDiseMsg);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                          " ('" + Smsbody + "','" + MobileNo + "','" + Convert.ToString(CurrenctDate) + "','" + Data + "','" + Convert.ToString(CurrenctDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }

    #endregion UdiseMDM

    //---------------------------------------------------UDISE Add Student Register------------------------------------------------------------------

    #region UdiseAddstudRegister
    public void UdiseAddstudRegister(string UserId, string scode, string sclass, string div, string regboy, string reggirl, string CurrentDate)
    {
        try
        {
            string Sql = "SELECT Stud_Id FROM UDISE_RegisterStudent where SchoolCode='" + scode + "' and  Class='" + sclass + "' and Division='" + div + "'";
            string StudId = Convert.ToString(cc.ExecuteScalar(Sql));
            if (StudId == "" || StudId == null)
            {
                string Sqlin = "Insert into UDISE_RegisterStudent(usrUserId,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls)" +
                              " values('" + UserId + "','" + scode + "','" + Convert.ToString(CurrentDate) + "','" + sclass + "','" + div + "','" + regboy + "','" + reggirl + "')";
                int k = cc.ExecuteNonQuery(Sqlin);
            }
            else
            {
                string sqlup = "Update UDISE_RegisterStudent set RegBoys='" + regboy + "',RegGirls='" + reggirl + "' ,ModifyDate='" + Convert.ToString(CurrentDate) + "' where SchoolCode='" + scode + "' and  Class='" + sclass + "' and Division='" + div + "'";
                int k = cc.ExecuteNonQuery(sqlup);
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion UdiseAddstudRegister

    //----------------------------------------------------BJSS* Name * Age * M/F * City* email I'd & BJSE* Name * Age * M/F * City* email I'd--------

    #region BJSS&BJSEData
    public void BJSSBJSE(string Wholestr, string MobileNo, string CurrentDate, string p1, string p2)
    {
        try
        {
            string[] SplitMsg = Wholestr.Split('*');
            string fullname = Convert.ToString(SplitMsg[1]);
            string Age = Convert.ToString(SplitMsg[2]);
            string gender = Convert.ToString(SplitMsg[3].Trim().ToUpper());
            if (gender == "MALE" || gender == "M")
            {
                gender = "Male";
            }
            else if (gender == "FEMALE" || gender == "F")
            {
                gender = "Female";
            }
            string city = Convert.ToString(SplitMsg[4]);
            string EmailId = Convert.ToString(SplitMsg[5]);

            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (String.IsNullOrEmpty(getuserID))
            {
                getuserID = UserRegistration(fullname, MobileNo, EmailId, gender, Age);
            }
            if (getuserID != "" || getuserID != null)
            {
                string Sqlchk = "Select UserId from UserGroup where GroupId=92 and UserId='" + getuserID + "'";
                string usrIdchk = Convert.ToString(cc.ExecuteScalar(Sqlchk));
                if (String.IsNullOrEmpty(usrIdchk))
                {
                    string Sql = "insert into UserGroup (UserId,GroupId,city,joindate)values('" + getuserID + "','92','" + city + "','" + CurrentDate + "')";
                    int k = cc.ExecuteNonQuery(Sql);
                    if (k == 1)
                    {
                        if (p1 == "" || p2 == "")
                        { }
                        else
                        {
                            SendSMSBJS(getuserID, MobileNo, CurrentDate);
                            string Sql1 = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                                  " ('" + Wholestr + "','" + MobileNo + "','" + Convert.ToString(CurrentDate) + "','" + Data + "','" + Convert.ToString(CurrentDate) + "','0','N','" + p1 + "','" + p2 + "' )";
                            int b = cc.ExecuteNonQuery(Sql1);
                            //if (b == 1)
                            //{
                            //    //SendSMSBJS(getuserID, MobileNo, CurrentDate);
                            //}

                        }
                    }
                }
                else
                {
                    string Sql = "Update UserGroup set joindate='" + Convert.ToString(CurrentDate) + "' where UserId='" + getuserID + "'  and GroupId='92'";
                    int k = cc.ExecuteNonQuery(Sql);
                    if (k == 1)
                    {
                        //SendSMSBJS(getuserID, MobileNo, CurrentDate);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            string Sql = " Insert into come2mycity.test(message, mobile, shortcode, data, SendDate,FlagStatus,smsStatus,SIMNO,IEMI) values " +
                                          " ('" + Wholestr + "','" + MobileNo + "','" + Convert.ToString(CurrentDate) + "','" + Data + "','" + Convert.ToString(CurrentDate) + "','1','N','" + p1 + "','" + p2 + "' )";
            int b = cc.ExecuteNonQuery(Sql);
        }
    }

    public string SendSMSBJS(string UserId, string MobileNo, string Date)
    {
        string Data = "0";
        string MgsId = "", msgsent = "";
        int CountMsg = 0;
        try
        {
            string Sql = "SELECT Id, setMessage,Count1 FROM BJSSetMessage where Active=1";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                MgsId = Convert.ToString(ds.Tables[0].Rows[0]["Id"]);
                msgsent = Convert.ToString(ds.Tables[0].Rows[0]["setMessage"]);
                CountMsg = Convert.ToInt32(ds.Tables[0].Rows[0]["Count1"]);

                string Sqlinsertdata = "Insert into BJSSendSMSReport(SendFrom,SendTo,sentMessage,UserId,EntryDate,Count1,MsgId)values('BJS','" + MobileNo + "','" + msgsent + "','" + UserId + "','" + Date + "'," + CountMsg + "," + MgsId + ")";
                int k = cc.ExecuteNonQuery(Sqlinsertdata);
                if (k == 1)
                {
                    int smslength = msgsent.Length;
                    cc.TransactionalSMSCountry("PromotionalSMS", MobileNo, msgsent, smslength, 3);
                    Data = "1";
                }
            }
        }
        catch (Exception ex)
        {

        }
        return Data;
    }

    #endregion BJSS&BJSEData
}

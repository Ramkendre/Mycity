<%@ WebService Language="C#" Class="SendEmail" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Collections;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Linq;

[WebService(Namespace = "http://www.myct.in/webservice/SendEmail.asmx")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class SendEmail : System.Web.Services.WebService
{
    UserRegistrationBLL urRegistBll = new UserRegistrationBLL();
    CommonCode cc = new CommonCode();
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod(Description = "Send Email method")]
    public void sendEmail(string eMailIDSendTO, string subject, string mailBody)
    {
        MailMessage mail = new MailMessage();
        mail.To.Add(eMailIDSendTO.ToString());
        //mail.To.Add("amit_jain_online@yahoo.com");
        mail.From = new MailAddress("myctsms@gmail.com");
        mail.Subject = subject.ToString();

        string Body = mailBody.ToString();
        mail.Body = Body;

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential
             ("myctsms@gmail.com", "myct@6789#");
        //Or your Smtp Email ID and Password
        smtp.EnableSsl = true;
        smtp.Send(mail);
    }

    [WebMethod(Description = "Check Teacher Registeresd or not")]
    public bool IsRegistered(string TeacherMobileNo)
    {
        bool Flag = false;
        urRegistBll.usrMobileNo = TeacherMobileNo;
        int ststus = urRegistBll.BLLIsExistUserRegistrationInitial(urRegistBll);
        if (ststus == 0)
        {
            Flag = true;
            return Flag;
        }
        else
        {
            Flag = false;
            return Flag;
        }
    }
    [WebMethod(Description = "Register TEacher.")]
    public bool RegisterUser(string TeacherMobileNo, string FirstName, string lastName, string Address, string PIN, string email, string School_collegeId, string categortid)
    {
        bool Flag = false;
        string sqlchk = "select usrUserid from usermaster where usrMobileNo='" + Convert.ToString(TeacherMobileNo) + "'";
        string Jr_ID = Convert.ToString(cc.ExecuteScalar(sqlchk));//Get Jr userID in myct usermaster table for checking he is  subuser or not.  
        if (Jr_ID == "" || Jr_ID == null)
        {
            string usrUserId = System.Guid.NewGuid().ToString();
            Random rnd = new Random();
            string usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

            string sql = "insert into UserMaster(usrUserId,usrMobileNo,usrAddress,usrPassword,usrFirstName,usrLastName,usrPIN,usrEmailId,School_CollegeID,PersonCategory) " +
                         " values('" + usrUserId + "','" + TeacherMobileNo + "','" + Address + "','" + usrPassword.ToString() + "','" + FirstName + "','" + lastName + "','" + PIN + "','" + email + "','" + School_collegeId + "','" + categortid + "')  ";
            int ststus = cc.ExecuteNonQuery(sql);
            if (ststus == 1)
            {
                string msg1 = "Dear " + lastName + ", Password for ur First Login is " + cc.DESDecrypt(usrPassword) + " " + cc.AddSMS(TeacherMobileNo);
                int smslength = msg1.Length;
                cc.TransactionalSMSCountry("School SMS", TeacherMobileNo, msg1, smslength, 8);

                Flag = true;

            }
            else
            {
                Flag = false;

            }
        }
        return Flag;
    }



    [WebMethod(Description = "Update Registration")]
    public bool Update_RegisterUser(string TeacherMobileNo, string School_collegeId, string categortid)
    {
        bool Flag = false;
        string usrUserId = System.Guid.NewGuid().ToString();
        Random rnd = new Random();
        string usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

        string sql = "Update UserMaster set School_CollegeID='" + School_collegeId + "',PersonCategory='" + categortid + "' where usrMobileNo='" + TeacherMobileNo + "'";

        int ststus = cc.ExecuteNonQuery(sql);
        if (ststus > 0)
        {
            Flag = true;
            return Flag;
        }
        else
        {
            Flag = false;
            return Flag;
        }
    }

    [WebMethod(Description = "Send TRansactional message.")]
    public bool SendMessageTransactional(string sender, string sendTo, string message, int smslength, int SenderCode)
    {
        bool Flag = false;
        Flag = cc.TransactionalSMSCountry(sender, sendTo, message, smslength, SenderCode);
        return Flag;
    }

    [WebMethod(Description = "Send simpal message.")]
    public bool SendMessageWithoutTransactional(string sender, string sendTo, string message, string SenderName)
    {
        bool Flag = false;
        Flag = cc.SendMessage_School(sender, sendTo, message, SenderName);
        return Flag;
    }

    [WebMethod(Description = "Student Attendence.")]
    public bool StudentAttendence(string MobileNo, string schoolcode, string Class, string Division, string RegBoys, string RegGirls, string PresentBoys, string PresentGirls, string CurrenctDate)
    {
        bool Flag = false;
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string Sqlrole = "Select roleid from AdminSubMarketingSubUser where friendid ='" + getuserID + "' or userid='" + getuserID + "' and Active=1 and mainrole=1";
                string strRoleid = cc.ExecuteScalar(Sqlrole);
                if (strRoleid == "76" || strRoleid == "77")
                {
                    string GetDate = "Select EntryDate from UDISE_StudentPresenty where EntryDate='" + Convert.ToString(CurrenctDate) + "' and Class='" + Class + "' and Division='" + Division + "' and SchoolCode='" + schoolcode + "'";
                    string FindDate = Convert.ToString(cc.ExecuteScalar(GetDate));
                    if (FindDate == "" || FindDate == null)
                    {

                        string AddStudPre = "insert into UDISE_StudentPresenty(usrUserId,SchoolCode,EntryDate,Class,Division,RegBoys,RegGirls,Present_B,Present_G,Created)" +
                              "values('" + getuserID + "','" + schoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + Class + "','" + Division + "','" + RegBoys + "','" + RegGirls + "','" + PresentBoys + "','" + PresentGirls + "','WSchool')";
                        int a = 1;// cc.ExecuteNonQuery(AddStudPre);
                        if (a == 1)
                        {
                            Flag = true;
                        }
                    }
                    else
                    {
                        string UpdateStudPre = "update UDISE_StudentPresenty set usrUserId='" + getuserID + "',SchoolCode='" + schoolcode + "',Class='" + Class + "',Division='" + Division + "',RegBoys='" +
                            RegBoys + "',RegGirls='" + RegGirls + "',Present_B='" + PresentBoys + "',Present_G='" + PresentGirls + "' where EntryDate='" + Convert.ToString(CurrenctDate) + "' and SchoolCode='" + schoolcode + "' and Class='" + Class + "' and Division='" + Division + "'";
                        int a = 1;// cc.ExecuteNonQuery(UpdateStudPre);
                        if (a == 1)
                        {
                            Flag = true;
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {

        }
        return Flag;
    }

    [WebMethod(Description = "Teacher Attendence.")]
    public bool TeacherAttendance(string MobileNo, string schoolcode, string RegMale, string RegFemale, string PresentMale, string PresentFemale, string CurrenctDate)
    {
        bool Flag = false;
        try
        {
            string sqlget = "select usrUserid from usermaster where usrMobileNo='" + MobileNo + "'";
            string getuserID = cc.ExecuteScalar(sqlget);
            if (getuserID != "" || getuserID != null)
            {
                string sqlcheck = "select roleid from AdminSubMarketingSubUser where friendid='" + getuserID + "' and Active=1 and mainrole=1";
                string GetRoleID = cc.ExecuteScalar(sqlcheck);
                if (GetRoleID == "76")
                {
                    string GetDate = "Select EntryDate from UDISE_TeacherPresenty where EntryDate='" + Convert.ToString(CurrenctDate) + "' and SchoolCode='" + schoolcode + "'";
                    string FindDate = Convert.ToString(cc.ExecuteScalar(GetDate));
                    if (FindDate == "" || FindDate == null)
                    {
                        string AddStudPre = "insert into UDISE_TeacherPresenty(usrUserId,SchoolCode,EntryDate,RegMale,RegFemale,Present_M,Present_F,Created)" +
                               "values('" + getuserID + "','" + schoolcode + "','" + Convert.ToString(CurrenctDate) + "','" + RegMale + "','" + RegFemale + "','" + PresentMale + "','" + PresentFemale + "','WSchool')";
                        int a = 1;// cc.ExecuteNonQuery(AddStudPre);
                        if (a == 1)
                        {
                            Flag = true;
                        }
                    }
                    else
                    {
                        string UpdateStudPre = "update  UDISE_TeacherPresenty set RegMale='" + RegMale + "',RegFemale='" + RegFemale + "',Present_M='" +
                            PresentMale + "',Present_F='" + PresentFemale + "' where SchoolCode='" + schoolcode + "' and usrUserId='" + getuserID + "' and EntryDate='" + Convert.ToString(CurrenctDate) + "'";
                        int a = 1;// cc.ExecuteNonQuery(UpdateStudPre);
                        if (a == 1)
                        {
                            Flag = true;
                        }
                    }
                }
            }
            else
            {
                Flag = false;
            }
        }
        catch (Exception ex)
        {
            Flag = false;
        }
        return Flag;
    }

}



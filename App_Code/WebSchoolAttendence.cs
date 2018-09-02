using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

/// <summary>
/// Summary description for WebSchoolAttendence
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebSchoolAttendence : System.Web.Services.WebService
{
    string CurrenctDate;
    CommonCode cc = new CommonCode();
    public WebSchoolAttendence()
    {
        //Dateformat();
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public void Dateformat()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        CurrenctDate = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss tt''");
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
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

    [WebMethod]

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


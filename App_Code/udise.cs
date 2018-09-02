using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
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
using System.Xml;

/// <summary>
/// Summary description for udise
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class udise : System.Web.Services.WebService
{
    string strMyUrl = "", MobileNO = "", fnm = "", lnm = "", mnm = "", add = "", Appsstatus;
    CommonCode cc = new CommonCode();
    GetMembersAppsDetails memberapps = new GetMembersAppsDetails();
    UDISE_AddSubUser udise_addsub = new UDISE_AddSubUser();
    public udise()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

   // [WebMethod(Description = "Add Teacher")]
    //public void AddTeacher(string mobile, string fname, string lname, string schoolcode, string usrclass, string section, string UserName)
    //{
    //    udise_addsub.AddSubUser(mobile, fname, lname, schoolcode, usrclass, section, UserName);
    //}
    [WebMethod(Description = "DS Record")]
    public DataSet GetDS(string MobileNO)
    {
        string SQl = " Select usrFirstName,usrMiddleName,usrLastName,usrAddress ,image from UserMaster " +
                         " left join storeimage on storeimage.usrAutoid=UserMaster.usrAutoid " +
                        "where	usrmobileno='" + MobileNO + "'";
        DataSet ds = cc.ExecuteDataset(SQl);
        // Return the DataSet as an XmlElement.
        XmlDataDocument xmldata = new XmlDataDocument(ds);
        XmlElement xmlElement = xmldata.DocumentElement;
        return ds;


    }
    [WebMethod(Description = "GetMemberAppsDetails")]
    public XmlElement GetMemberAppsDetails(string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15, string p16, string p17, string p18, string p19, string date, string p20, string p21, string p22, string p23, string p24, string p25, string p26, string p27, string p28, string p29, string p30, string p31, string p32, string p33, string p34, string p35, string p36, string p37, string p38, string p39, string p40, string p41, string p42, string p43, string p44, string p45, string p46, string p47, string p48, string p49, string p50)
    {
        XmlDocument xmldata = new XmlDocument();
        xmldata = memberapps.geturlrecords(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, date, p20, p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38, p39, p40, p41, p42, p43, p44);
        XmlElement xmlElement = xmldata.DocumentElement;
        return xmlElement;
    }
    [WebMethod(Description = "GetMember")]
    public XmlElement GetMember(string p1)
    {
        XmlDocument xmldata = new XmlDocument();
        xmldata = memberapps.geturl(p1);
        // Return the DataSet as an XmlElement.         
        XmlElement xmlElement = xmldata.DocumentElement;
        return xmlElement;
    }

    [WebMethod(Description = "Head Record")]
    public XmlElement Head(string MobileNO)
    {

        string SQl = " select p5 as usrFirstName,  p7 as usrLastName ,  p8 as Address, MemberImage as Image  from androidlongcode left outer join EApps_MemberImage on androidlongcode.id = EApps_MemberImage.AppsMem_Id " + 
               " where p4='" + MobileNO + "'"; // this query changed inner join to left outer join

        DataSet ds = cc.ExecuteDataset(SQl);
        // Return the DataSet as an XmlElement.


        XmlDataDocument xmldata = new XmlDataDocument(ds);
        XmlElement xmlElement = xmldata.DocumentElement;
        return xmlElement;
    }

    [WebMethod(Description = "Relative Record")]
    public XmlElement Relative(string MobileNO)
    {
        string SQl = " select p6 as usrFirstName,p7 as usrLastName ,  p9 as Address from [androidlongcode] " +
               " where p5='" + MobileNO + "'";

        DataSet ds = cc.ExecuteDataset(SQl);
        // Return the DataSet as an XmlElement.


        XmlDataDocument xmldata = new XmlDataDocument(ds);
        XmlElement xmlElement = xmldata.DocumentElement;
        return xmlElement;
    }

    [WebMethod(Description = "Member Record")]
    public XmlElement Member(string MobileNO)
    {
        string SQl = " select p7 as usrFirstName,  p9 as usrLastName ,  p10 as Address , MemberImage as Image  from androidlongcode inner join EApps_MemberImage on androidlongcode.id = EApps_MemberImage.AppsMem_Id  " +
               " where p6='" + MobileNO + "'";

        DataSet ds = cc.ExecuteDataset(SQl);
        // Return the DataSet as an XmlElement.


        XmlDataDocument xmldata = new XmlDataDocument(ds);
        XmlElement xmlElement = xmldata.DocumentElement;
        return xmlElement;
    }


    [WebMethod(Description = "Share Info")]
    public XmlElement ShareInfoHead(string HeadMobNO)
    {
        XmlDocument xmldata = new XmlDocument();
        xmldata = memberapps.ShareInfo(HeadMobNO);
        XmlElement xmlElement = xmldata.DocumentElement;
        return xmlElement;

    }
    private string Get(string url)
    {

        string text = "";
        List<string> myCollection = new List<string>();
        int a1;
        char character;
        string[] a = url.Split(',');

        for (int i = 0; i < a.Length; i++)
        {

            a1 = Convert.ToInt32(a[i]);
            character = (char)a1;
            text = character.ToString();
            myCollection.Add(text);
        }
        string resulr = String.Join("", myCollection.ToArray());
        return resulr;

    }

}
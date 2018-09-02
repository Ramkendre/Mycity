using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;

/// <summary>
/// Summary description for TrueVoter
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class TrueVoter : System.Web.Services.WebService
{

    CommonCode cc = new CommonCode();
    public TrueVoter()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string LoginCheck(String Password, string MobileNo)
    {
        //if (!string.IsNullOrEmpty(MobileNo))
        //{
        try
        {
            string s = string.Empty;
            DataSet ds = new DataSet();
            string str = "select usrPassword,usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + MobileNo + "' ";
            ds = cc.ExecuteDataset(str);
            string str1 = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));
            if (str1 == Password)
            {
                string sql = "select usertype FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where UserId='" + Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]) + "'";
                ds = cc.ExecuteDataset(sql);
                s = ds.Tables[0].Rows[0]["usertype"].ToString();
            }
            if (s == "2" && s == "3")
            {
                return s;
            }
            return "4";
        }
        catch (SqlException ex)
        {
            return ex.Message;
        }
    }


    [WebMethod]
    public XmlDocument Login(String Password, string MobileNo)
    {
        string s = string.Empty;
        string str1 = string.Empty;
        string keyword = string.Empty;
        XmlDataDocument xmldata = new XmlDataDocument();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        MobileNo = EncryptDecrypt.DecodeAndDecrypt(MobileNo);
        //Password = EncryptDecrypt.DecodeAndDecrypt(Password);

        //string str = " select usrPassword,usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + MobileNo + "' ";
        //ds = cc.ExecuteDataset(str);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    str1 = cc.DESDecrypt(Convert.ToString(ds.Tables[0].Rows[0]["usrPassword"]));
        //}

        //string str2 = "select [keyword] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where UserId='" + Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]) + "' and keyword='TRUEVOTER'";
        //DataSet ds0 = cc.ExecuteDataset(str2);
        //keyword = ds0.Tables[0].Rows[0]["keyword"].ToString();

        //if (str1 == Password)
        //{
        //    if (keyword == "TRUEVOTER")
        //    {
        string sql = "SELECT [keyword],[strDevId],[strSimSerialNo],[firstName],[lastName],[firmName],[mobileNo],[address],[eMailId],[typeOfUse_Id],[RefMobileNo],[State],[District],[Taluka],[latitude],[longitude] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [mobileNo] = '" + MobileNo + "' and keyword='TRUEVOTER'";//UserId='" + Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]) + "' and keyword='TRUEVOTER'";
        ds = cc.ExecuteDataset(sql);
        //s = ds.Tables[0].Rows[0]["usertype"].ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            xmldata = new XmlDataDocument(ds);
            XmlElement xmlele = xmldata.DocumentElement;
            return xmldata;
        }
        else
        {
            dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NoRecord"] = "105";
            dt.Rows.Add(dr);
            DataSet ds3 = new DataSet();
            ds3.Tables.Add(dt);
            xmldata = new XmlDataDocument(ds3);
            XmlElement xmlelement = xmldata.DocumentElement;
            return xmldata;
        }
    }
    //else
    //{
    //    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
    //    DataRow dr = dt.NewRow();
    //    dr["NoRecord"] = "105";
    //    dt.Rows.Add(dr);
    //    DataSet ds4 = new DataSet();
    //    ds4.Tables.Add(dt);
    //    xmldata = new XmlDataDocument(ds4);
    //    XmlElement xmlelement = xmldata.DocumentElement;
    //    return xmldata;
    //}
}

//else
//{
//    dt.Columns.Add(new DataColumn("NoRecord", typeof(int)));
//    DataRow dr = dt.NewRow();
//    dr["NoRecord"] = "105";
//    dt.Rows.Add(dr);
//    ds.Tables.Add(dt);
//    xmldata = new XmlDataDocument(ds);
//    XmlElement xmlelement = xmldata.DocumentElement;
//    return xmldata;
//}
//}
//}


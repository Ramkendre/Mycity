using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Summary description for EzeeMuncipalCouncil
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EzeeMuncipalCouncil : System.Web.Services.WebService
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    private static JsonSerializerSettings theJsonSerializerSettings = new JsonSerializerSettings();
    public EzeeMuncipalCouncil()
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
    public XmlDataDocument DownloadDepartments()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        string str = "select [ID],[DepartmentName] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalDepartments]";
        ds = cc.ExecuteDataset(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
        }
        return xmlData;
    }

    [WebMethod]
    public XmlDataDocument DownloadRoles()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        string str = "select [RoleName] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalRoles]";
        ds = cc.ExecuteDataset(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
        }
        return xmlData;
    }

    //[WebMethod]
    //public string InserComplaints(string ComplaintName1, string Department1, string MobileNo1, string Role1, string Councipal1)
    //{
    //    //string[] stringArray = EString.Split(new char[] { '#', '*' });
    //    string nonInsertedValues = string.Empty;
    //    string nonInsertedValues1 = string.Empty;
    //    int result;
    //    string returnValue = string.Empty;
    //    int count = 0;
    //    cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
    //    if (ComplaintName1 == null || ComplaintName1 == "" || ComplaintName1 == "0")
    //    {
    //        return "NUll";
    //    }
    //    else
    //    {
    //        string str = "insert into tbl_CouncipalComplaints([ComplaintName],[Department],[MobileNo],[Role],[Councipal])values('" + ComplaintName1 + "','" + Department1 + "','" + MobileNo1 + "','" + Role1 + "','" + Councipal1 + "')";
    //        cmd.CommandText = str;
    //        cmd.Connection = con;
    //        if (cmd.Connection.State == ConnectionState.Closed)
    //            cmd.Connection.Open();
    //        try
    //        {
    //            cmd.ExecuteNonQuery();
    //            cmd.CommandText = "select max(ComplaintID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalComplaints]";
    //            int id = Convert.ToInt32(cmd.ExecuteScalar());
    //            returnValue += id + "*";
    //        }
    //        catch (Exception ex)
    //        {
    //            returnValue += "0*";
    //        }
    //        count++;

    //        if (count == 1)
    //        {
    //            return returnValue;
    //        }
    //        if (returnValue.EndsWith("*"))
    //        {
    //            returnValue = returnValue.Substring(0, returnValue.Length - 1);
    //        }
    //    }
    //    return returnValue;
    //}

    //[WebMethod]
    //public string InsertEnquiry(string Enquiry1, string Department1, string MobileNo1, string Role1, string Councipal1)
    //{
    //    //string[] stringArray = EString.Split(new char[] { '#', '*' });
    //    string nonInsertedValues = string.Empty;
    //    string nonInsertedValues1 = string.Empty;
    //    int result;
    //    string returnValue = string.Empty;
    //    int count = 0;
    //    cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

    //    string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalEnquiry]([Enquiry],[Department],[MobileNo],[Role],[Councipal])VALUES('" + Enquiry1 + "','" + Department1 + "','" + MobileNo1 + "','" + Role1 + "','" + Councipal1 + "')";
    //    cmd.CommandText = str;
    //    cmd.Connection = con;
    //    if (cmd.Connection.State == ConnectionState.Closed)
    //        cmd.Connection.Open();
    //    try
    //    {
    //        cmd.ExecuteNonQuery();
    //        cmd.CommandText = "select max(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEnquiry]";
    //        int id = Convert.ToInt32(cmd.ExecuteScalar());
    //        returnValue += id + "*";
    //    }
    //    catch (Exception ex)
    //    {
    //        returnValue += "0*";
    //    }
    //    count++;

    //    if (count == 1)
    //    {
    //        return returnValue;
    //    }
    //    if (returnValue.EndsWith("*"))
    //    {
    //        returnValue = returnValue.Substring(0, returnValue.Length - 1);
    //    }
    //    return returnValue;
    //}

    //[WebMethod]
    //public string InsertSuggestions(string Suggestions1, string Department1, string MobileNo1, string Role1, string Councipal1)
    //{
    //    //string[] stringArray = EString.Split(new char[] { '#', '*' });
    //    string nonInsertedValues = string.Empty;
    //    string nonInsertedValues1 = string.Empty;
    //    int result;
    //    string returnValue = string.Empty;
    //    int count = 0;
    //    cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

    //    string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalSuggestions]([Suggestions],[Department],[MobileNo],[Role],[Councipal])VALUES('" + Suggestions1 + "','" + Department1 + "','" + MobileNo1 + "','" + Role1 + "','" + Councipal1 + "')";
    //    cmd.CommandText = str;
    //    cmd.Connection = con;
    //    if (cmd.Connection.State == ConnectionState.Closed)
    //        cmd.Connection.Open();
    //    try
    //    {
    //        cmd.ExecuteNonQuery();
    //        cmd.CommandText = "select max(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalSuggestions]";
    //        int id = Convert.ToInt32(cmd.ExecuteScalar());
    //        returnValue += id + "*";
    //    }
    //    catch (Exception ex)
    //    {
    //        returnValue += "0*";
    //    }
    //    count++;

    //    if (count == 1)
    //    {
    //        return returnValue;
    //    }
    //    if (returnValue.EndsWith("*"))
    //    {
    //        returnValue = returnValue.Substring(0, returnValue.Length - 1);
    //    }
    //    return returnValue;
    //}

    [WebMethod]
    public string InsertComplaints(string Data)
    {
        //XmlReader xmlFile;
        //int count = 0;
        //string returnValue = string.Empty;
        //XmlReader reader = XmlReader.Create(new StringReader(Data));
        //ds.ReadXml(reader);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    string CompName = ds.Tables[0].Rows[i]["ComplaintName"].ToString();
        //    string Dept = ds.Tables[0].Rows[i]["Department"].ToString();
        //    string MobtNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
        //    string Role1 = ds.Tables[0].Rows[i]["Role"].ToString();
        //    string Councipal1 = ds.Tables[0].Rows[i]["Councipal"].ToString();
        //    //string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();

        //    string str = "insert into tbl_CouncipalComplaints([ComplaintName],[Department],[MobileNo],[Role],[Councipal])values('" + CompName + "','" + Dept + "','" + MobtNo + "','" + Role1 + "','" + Councipal1 + "')";
        //    cmd.CommandText = str;
        //    cmd.Connection = con;
        //    if (cmd.Connection.State == ConnectionState.Closed)
        //        cmd.Connection.Open();
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        cmd.CommandText = "select max(ComplaintID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalComplaints]";
        //        int id = Convert.ToInt32(cmd.ExecuteScalar());
        //        returnValue += id + "*"; //+ appid +"#";
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValue += "0*";
        //    }
        //    count++;
        //}
        //if (count == 1)
        //{
        //    return returnValue;
        //}
        //if (returnValue.EndsWith("*"))
        //{
        //    returnValue = returnValue.Substring(0, returnValue.Length - 1);
        //}
        //return returnValue;

        XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(Data));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string CompName = ds.Tables[0].Rows[i]["Complaints"].ToString();
            string Dept = ds.Tables[0].Rows[i]["Department"].ToString();
            string MobtNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
            string Role1 = ds.Tables[0].Rows[i]["Role"].ToString();
            string Councipal1 = ds.Tables[0].Rows[i]["Council"].ToString();

            string Subject = ds.Tables[0].Rows[i]["Subject"].ToString();
            string Images = ds.Tables[0].Rows[i]["ImageStr"].ToString();
            string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();

            string str = "insert into [Come2myCityDB].[come2mycity].[tbl_CouncipalComplaints]([ComplaintName],[Department],[MobileNo],[Role],[Councipal],[Subject],[Images])values('" + CompName + "','" + Dept + "','" + MobtNo + "','" + Role1 + "','" + Councipal1 + "','" + Subject + "','" + Images + "')";
            cmd.CommandText = str;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select max(ComplaintID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalComplaints]";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                returnValue += id + "*" + appid + "#";
            }
            catch (Exception ex)
            {
                returnValue += "0*";
            }
            count++;
        }
        if (count == 1)
        {
            return returnValue;
        }
        if (returnValue.EndsWith("*"))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;
    }

    [WebMethod]
    public string InsertNews(string Data)
    {
        XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(Data));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string Topic1 = ds.Tables[0].Rows[i]["Topic"].ToString();
            string Department1 = ds.Tables[0].Rows[i]["Department"].ToString();
            string Title1 = ds.Tables[0].Rows[i]["Title"].ToString();
            string LastDate1 = ds.Tables[0].Rows[i]["LastDate"].ToString();
            string Status1 = ds.Tables[0].Rows[i]["RadiobtnStatus"].ToString();
            string Details1 = ds.Tables[0].Rows[i]["Details"].ToString();
            string mobileNo1 = ds.Tables[0].Rows[i]["mobileNo"].ToString();
            string council1 = ds.Tables[0].Rows[i]["council"].ToString();
            string State1 = ds.Tables[0].Rows[i]["State"].ToString();
            string District1 = ds.Tables[0].Rows[i]["District"].ToString();
            string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();
            string villageId=ds.Tables[0].Rows[i]["villageId"].ToString();
            string officeLevel = ds.Tables[0].Rows[i]["officeLevel"].ToString();
            string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] ([Topic],[Department],[Title],[LastDate],[RadiobtnStatus],[Details],[mobileNo],[council],[State],[District],[villageId],[officeLevel]) values('" + Topic1 + "','" + Department1 + "','" + Title1 + "','" + LastDate1 + "','" + Status1 + "','" + Details1 + "','" + mobileNo1 + "','" + council1 + "','" + State1 + "','" + District1 + "','" + villageId + "','" + officeLevel + "')";
            cmd.CommandText = str;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select max(NID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo]";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                returnValue += appid + "*" + id + "#"; //+ appid +"#";
            }
            catch (Exception ex)
            {
                returnValue += "0*";
            }
            count++;
        }
        if (count == 1)
        {
            return returnValue;
        }
        if (returnValue.EndsWith("*"))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;
    }

    [WebMethod]
    public string InsertEnquiry(string EData)
    {
        //XmlReader xmlFile;
        //int count = 0;
        //string returnValue = string.Empty;
        //XmlReader reader = XmlReader.Create(new StringReader(EData));
        //ds.ReadXml(reader);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    string enq = ds.Tables[0].Rows[i]["Enquiry"].ToString();
        //    string Dept = ds.Tables[0].Rows[i]["Department"].ToString();
        //    string MobNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
        //    string role1 = ds.Tables[0].Rows[i]["Role"].ToString();
        //    string conc = ds.Tables[0].Rows[i]["Councipal"].ToString();
        //    //string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();

        //    string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalEnquiry]([Enquiry],[Department],[MobileNo],[Role],[Councipal])VALUES('" + enq + "','" + Dept + "','" + MobNo + "','" + role1 + "','" + conc + "')";
        //    cmd.CommandText = str;
        //    cmd.Connection = con;
        //    if (cmd.Connection.State == ConnectionState.Closed)
        //        cmd.Connection.Open();
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        cmd.CommandText = "SELECT MAX(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEnquiry]";
        //        int id = Convert.ToInt32(cmd.ExecuteScalar());
        //        returnValue += id + "*"; //+ appid +"#";
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValue += "0*";
        //    }
        //}
        //count++;
        //if (count == 1)
        //{
        //    return returnValue;
        //}
        //if (returnValue.EndsWith("*"))
        //{
        //    returnValue = returnValue.Substring(0, returnValue.Length - 1);
        //}
        //return returnValue;

        XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(EData));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string enq = ds.Tables[0].Rows[i]["Enquiry"].ToString();
            string Dept = ds.Tables[0].Rows[i]["Department"].ToString();
            string MobNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
            string role1 = ds.Tables[0].Rows[i]["Role"].ToString();
            string conc = ds.Tables[0].Rows[i]["Councipal"].ToString();

            string Subject = ds.Tables[0].Rows[i]["Subject"].ToString();
            string Images = ds.Tables[0].Rows[i]["ImageStr"].ToString();
            string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();

            string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalEnquiry]([Enquiry],[Department],[MobileNo],[Role],[Councipal],[Subject],[Images])VALUES('" + enq + "','" + Dept + "','" + MobNo + "','" + role1 + "','" + conc + "','" + Subject + "','" + Images + "')";
            cmd.CommandText = str;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT MAX(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEnquiry]";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                returnValue += id + "*" + appid + "#";
            }
            catch (Exception ex)
            {
                returnValue += "0*";
            }
        }
        count++;
        if (count == 1)
        {
            return returnValue;
        }
        if (returnValue.EndsWith("*"))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;
    }

    [WebMethod]
    public string InsertSuggestions(string EData)
    {
        //XmlReader xmlFile;
        //int count = 0;
        //string returnValue = string.Empty;
        //XmlReader reader = XmlReader.Create(new StringReader(EData));
        //ds.ReadXml(reader);
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    string sugg = ds.Tables[0].Rows[i]["Suggestions"].ToString();
        //    string Dept = ds.Tables[0].Rows[i]["Department"].ToString();
        //    string MobNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
        //    string role1 = ds.Tables[0].Rows[i]["Role"].ToString();
        //    string conc = ds.Tables[0].Rows[i]["Councipal"].ToString();
        //    //string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();

        //    string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalSuggestions]([Suggestions],[Department],[MobileNo],[Role],[Councipal])VALUES('" + sugg + "','" + Dept + "','" + MobNo + "','" + role1 + "','" + conc + "')";
        //    cmd.CommandText = str;
        //    cmd.Connection = con;
        //    if (cmd.Connection.State == ConnectionState.Closed)
        //        cmd.Connection.Open();
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        cmd.CommandText = "SELECT MAX(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalSuggestions]";
        //        int id = Convert.ToInt32(cmd.ExecuteScalar());
        //        returnValue += id + "*"; //+ appid +"#";
        //    }
        //    catch (Exception ex)
        //    {
        //        returnValue += "0*";
        //    }
        //}
        //count++;
        //if (count == 1)
        //{
        //    return returnValue;
        //}
        //if (returnValue.EndsWith("*"))
        //{
        //    returnValue = returnValue.Substring(0, returnValue.Length - 1);
        //}
        //return returnValue;

        XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(EData));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string sugg = ds.Tables[0].Rows[i]["Suggesions"].ToString();
            string Dept = ds.Tables[0].Rows[i]["Department"].ToString();
            string MobNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
            string role1 = ds.Tables[0].Rows[i]["Role"].ToString();
            string conc = ds.Tables[0].Rows[i]["Council"].ToString();

            string Subject = ds.Tables[0].Rows[i]["Subject"].ToString();
            string Images = ds.Tables[0].Rows[i]["ImageStr"].ToString();
            string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();

            string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalSuggestions]([Suggestions],[Department],[MobileNo],[Role],[Councipal],[Subject],[Images])VALUES('" + sugg + "','" + Dept + "','" + MobNo + "','" + role1 + "','" + conc + "','" + Subject + "','" + Images + "')";
            cmd.CommandText = str;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT MAX(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalSuggestions]";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                returnValue += id + "*" + appid + "#";
            }
            catch (Exception ex)
            {
                returnValue += "0*";
            }
        }
        count++;
        if (count == 1)
        {
            return returnValue;
        }
        if (returnValue.EndsWith("*"))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;

    }

    [WebMethod]
    public string InsertEmployee(string EData)
    {
        // XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(EData));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string Dept = ds.Tables[0].Rows[i]["Department"].ToString();
            string MobNo = ds.Tables[0].Rows[i]["EmpMobileNo"].ToString();
            string Name = ds.Tables[0].Rows[i]["Name"].ToString();
            string Desg = ds.Tables[0].Rows[i]["Designation"].ToString();
            string refMobNo = ds.Tables[0].Rows[i]["RefMobileNo"].ToString();
            string Imgstr = ds.Tables[0].Rows[i]["ImageStr"].ToString();
            string Council1 = ds.Tables[0].Rows[i]["Council"].ToString();
            string apppk_id = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();
            string distId=ds.Tables[0].Rows[i]["distId"].ToString();
            string villageId=ds.Tables[0].Rows[i]["villageId"].ToString();
            string officeLevel = ds.Tables[0].Rows[i]["officeLevel"].ToString();
            string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalEmployee]([Department],[EmpMobileNo],[Name],[Designation],[RefMobileNo],[ImageStr],[Council],[AppPK_Id],[distId],[villageId],[officeLevel]) VALUES('" + Dept + "','" + MobNo + "','" + Name + "','" + Desg + "','" + refMobNo + "','" + Imgstr + "','" + Council1 + "','" + apppk_id + "','" + distId + "','" + villageId + "','" + officeLevel + "')";
            cmd.CommandText = str;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                //cmd.CommandText = "SELECT MAX(EID),[AppPK_Id] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEmployee]";
                string sql = "SELECT EID,[AppPK_Id] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEmployee] ORDER BY EID DESC";
                //int id = Convert.ToInt32(cmd.ExecuteScalar());
                DataSet ds1 = cc.ExecuteDataset(sql);
                int id = Convert.ToInt32(ds1.Tables[0].Rows[0]["EID"]);
                int id1 = Convert.ToInt32(ds1.Tables[0].Rows[0]["AppPK_Id"]);
                returnValue += id + "*" + id1 + "#";
            }
            catch
            {
                returnValue += "0*";
            }
        }
        count++;
        if (count == 1)
        {
            return returnValue;
        }
        if (returnValue.EndsWith("*"))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;
    }

    [WebMethod]
    public string InsertMemberReg(string EData)
    {
        //XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(EData));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string Samiti1 = ds.Tables[0].Rows[i]["Samiti"].ToString();
            string MembMobNo1 = ds.Tables[0].Rows[i]["MembMobNo"].ToString();
            string Name1 = ds.Tables[0].Rows[i]["Name"].ToString();
            string Designation1 = ds.Tables[0].Rows[i]["Designation"].ToString();
            string RefMobileNo1 = ds.Tables[0].Rows[i]["RefMobileNo"].ToString();
            string Imgstr = ds.Tables[0].Rows[i]["ImageStr"].ToString();
            string Council1 = ds.Tables[0].Rows[i]["Council"].ToString();
            string ImeiNo = ds.Tables[0].Rows[i]["IEMINo"].ToString();
            string Keyword = ds.Tables[0].Rows[i]["Keyword"].ToString();
            //string CrtDate = ds.Tables[0].Rows[i]["CurrentDate"].ToString();
            string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();
            string distId=ds.Tables[0].Rows[i]["distId"].ToString();
            string villageId=ds.Tables[0].Rows[i]["villageId"].ToString();
            string officeLevel = ds.Tables[0].Rows[i]["officeLevel"].ToString();
            string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg]([Samiti],[MembMobNo],[Name],[Designation],[RefMobileNo],ImageStr,[Council],[IEMINo],[Keyword],[CurrentDate],[distId],[villageId],[officeLevel]) VALUES('" + Samiti1 + "','" + MembMobNo1 + "','" + Name1 + "','" + Designation1 + "','" + RefMobileNo1 + "','" + Imgstr + "','" + Council1 + "','" + ImeiNo + "','" + Keyword + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + distId + "','" + villageId + "','" + officeLevel + "')";
            cmd.CommandText = str;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT MAX(MID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg]";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                returnValue += appid + "*" + id + "#"; //+ appid +"#";
            }
            catch (Exception ex)
            {
                returnValue += "0*";
            }
        }
        count++;
        if (count == 1)
        {
            return returnValue;
        }
        if (returnValue.EndsWith("*"))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;
    }

    [WebMethod]
    public string InsertCouncil(string CData)
    {
        string stry = string.Empty;
        XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(CData));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string CouncilName1 = ds.Tables[0].Rows[i]["CouncilName"].ToString();
            string Information1 = ds.Tables[0].Rows[i]["Information"].ToString();
            string Departments1 = ds.Tables[0].Rows[i]["Departments"].ToString();
            string Departmentid = ds.Tables[0].Rows[i]["DepartmentId"].ToString();
            string CouncilId = ds.Tables[0].Rows[i]["CouncilId"].ToString();
            string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();

            string  distId=ds.Tables[0].Rows[i]["distId"].ToString();
            string villageId=ds.Tables[0].Rows[i]["villageId"].ToString();
            string officeLevel = ds.Tables[0].Rows[i]["officeLevel"].ToString();

            stry = "Select * from [Come2myCityDB].[come2mycity].[tbl_CouncipalAboutCouncil] Where [DepartmentId]=" + Departmentid + " and [CouncilId]=" + CouncilId + " AND [distId]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
            DataSet Ds = cc.ExecuteDataset(stry);
            if (Ds.Tables[0].Rows.Count > 0)
            {
                stry = "Update [Come2myCityDB].[come2mycity].[tbl_CouncipalAboutCouncil] set [Information]='" + Information1 + "' Where [DepartmentId]=" + Departmentid + " and [CouncilId]=" + CouncilId + " AND [distId]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
                int res = cc.ExecuteNonQuery(stry);

                stry = "Select ID From [Come2myCityDB].[come2mycity].[tbl_CouncipalAboutCouncil] Where [DepartmentId]=" + Departmentid + " and [CouncilId]=" + CouncilId + "AND [distId]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
                int ID = Convert.ToInt32(cc.ExecuteScalar(stry));
                returnValue += appid + "*" + ID + "#";
            }
            else
            {
                string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalAboutCouncil]([CouncilName],[Information],[Departments],[CouncilId],[DepartmentId],[distId],[villageId],[officeLevel]) VALUES('" + CouncilName1 + "','" + Information1 + "','" + Departments1 + "','" + CouncilId + "','" + Departmentid + "','" + distId + "','" + villageId + "','" + officeLevel + "')";
                cmd.CommandText = str;
                cmd.Connection = con;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT MAX(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalAboutCouncil]";
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    returnValue += appid + "*" + id + "#";  // + appid + "#";
                }

                catch (Exception)
                {
                    returnValue += "0*";
                }
            }
            count++;
            if (count == 1)
            {
                return returnValue;
            }
            if (returnValue.EndsWith("*"))
            {
                returnValue = returnValue.Substring(0, returnValue.Length - 1);
            }
        }
        return returnValue;

    }

    [WebMethod]
    public string InsertSchedule(string EData)
    {
        XmlReader xmlFile;
        int count = 0;
        string returnValue = string.Empty;
        XmlReader reader = XmlReader.Create(new StringReader(EData));
        ds.ReadXml(reader);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string sche = ds.Tables[0].Rows[i]["TypeOfSchedule"].ToString();
            string Topic1 = ds.Tables[0].Rows[i]["Topic"].ToString();
            string Date1 = ds.Tables[0].Rows[i]["Date"].ToString();
            string Time1 = ds.Tables[0].Rows[i]["Time"].ToString();
            string Day1 = ds.Tables[0].Rows[i]["Day"].ToString();
            string AreaName1 = ds.Tables[0].Rows[i]["AreaName"].ToString();
            string Details1 = ds.Tables[0].Rows[i]["Details"].ToString();
            string Council1 = ds.Tables[0].Rows[i]["Council"].ToString();
            string mobNo = ds.Tables[0].Rows[i]["mobNo"].ToString();
            string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();
            string DistId = ds.Tables[0].Rows[i]["DistId"].ToString(); 
            string VillageId = ds.Tables[0].Rows[i]["VillageId"].ToString();
            string officeLevel = ds.Tables[0].Rows[i]["officeLevel"].ToString();
            string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncipalSchedule]([TypeOfSchedule],[Topic],[Date],[Time],[Day],[AreaName],[Details],[Council],[mobNo], [DistId] , [VillageId],[officeLevel]) VALUES('" + sche + "','" + Topic1 + "','" + Date1 + "','" + Time1 + "','" + Day1 + "','" + AreaName1 + "','" + Details1 + "','" + Council1 + "','" + mobNo + "','" + DistId + "','" + VillageId + "','" + officeLevel + "')";
            cmd.CommandText = str;
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT MAX(ID) FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalSchedule]";
                int id = Convert.ToInt32(cmd.ExecuteScalar());
                returnValue += id + "*" + appid + "#";
            }
            catch (Exception ex)
            {
                returnValue += "0*";
            }
        }
        count++;
        if (count == 1)
        {
            return returnValue;
        }
        if (returnValue.EndsWith("*"))
        {
            returnValue = returnValue.Substring(0, returnValue.Length - 1);
        }
        return returnValue;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AddJunior(string jsonString)
    {
        string returnString = string.Empty;
        int result; string sql = string.Empty;
        try
        {
            List<Addjunoir> lstjunior = new JavaScriptSerializer().Deserialize<List<Addjunoir>>(jsonString);
            foreach (Addjunoir addjunior in lstjunior)
            {
                sql = "select [Id],[UserMobile] from [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] where [AppMobileNo]='" + addjunior.APPMOBILENO.ToString() + "' and [UserMobile]='" + addjunior.USERMOBILE.ToString() + "'";
                ds = cc.ExecuteDataset(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    sql = "Update [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] set [UserMobile]='" + addjunior.USERMOBILE.ToString() + "',[isActive]='"+ addjunior.ACTIVE.ToString() +"' where [Id]=" + ds.Tables[0].Rows[0][0] + "";
                    cc.ExecuteNonQuery(sql);
                    returnString = ds.Tables[0].Rows[0][0] + "*" + addjunior.id.ToString() + "#";
                }
                else
                {
                    sql = "insert into [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances]([UserMobile],[AppMobileNo],[IMEINumber],[CreateDate],[keyword],[UserName],[isActive]) " +
                          "values('" + addjunior.USERMOBILE.ToString() + "','" + addjunior.APPMOBILENO.ToString() + "','" + addjunior.IMEI.ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + addjunior.TYPE.ToString() + "','" + addjunior.USERNAME.ToString() + "','" + addjunior.ACTIVE.ToString() + "')";
                    result = cc.ExecuteNonQuery(sql);

                    sql = "select max(Id) from [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances]";
                    string serverid = cc.ExecuteScalar(sql);
                    returnString += serverid + "*" + addjunior.id.ToString() + "#";
                }
            }

        }
        catch { }
        return returnString;
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string DownloadAddJunoir(string AppMobileNo, string keyword)
    {
        string sql = string.Empty; List<Addjunoir> lstjunior = new List<Addjunoir>();
        string returnstring = string.Empty;

        try
        {
            sql = "select  [Id],[UserMobile],[AppMobileNo],[IMEINumber],[keyword],[UserName],[isActive] from [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] where [AppMobileNo]='" + AppMobileNo.ToString() + "' and [keyword]='" + keyword.ToString() + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Addjunoir AddJunior = new Addjunoir();

                    AddJunior.id = ds.Tables[0].Rows[i]["Id"].ToString();
                    AddJunior.USERMOBILE = ds.Tables[0].Rows[i]["UserMobile"].ToString();
                    AddJunior.APPMOBILENO = ds.Tables[0].Rows[i]["AppMobileNo"].ToString();
                    AddJunior.IMEI = ds.Tables[0].Rows[i]["IMEINumber"].ToString();
                    AddJunior.TYPE = ds.Tables[0].Rows[i]["keyword"].ToString();
                    AddJunior.USERNAME = ds.Tables[0].Rows[i]["UserName"].ToString();
                    AddJunior.ACTIVE = ds.Tables[0].Rows[i]["isActive"].ToString();

                    lstjunior.Add(AddJunior);
                }
            }
            returnstring = JsonConvert.SerializeObject(lstjunior, theJsonSerializerSettings);
        }
        catch
        {

        }

        return returnstring;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateStatus(string updtjsonString)
    {
        string returnstring = string.Empty;
        string serid = string.Empty;
        try
        {
            List<Addjunoir> lstjunior = new JavaScriptSerializer().Deserialize<List<Addjunoir>>(updtjsonString);
            foreach (Addjunoir adjunr in lstjunior)
            {
                string sql = "update [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] set [isActive]='" + adjunr.ACTIVE.ToString() + "' where [Id]=" + adjunr.id.ToString() + " and [UserMobile]='" + adjunr.USERMOBILE.ToString() + "'";
                cc.ExecuteNonQuery(sql);

                string SQl = "select max(Id) from [Come2myCityDB].[come2mycity].[tbl_CouncipalAddRefferances] where [Id]=" + adjunr.id.ToString() + " and [UserMobile]='" + adjunr.USERMOBILE.ToString() + "'";
                serid = cc.ExecuteScalar(SQl);
                returnstring += serid + "#";
            }
        }
        catch
        {
            returnstring = "105";
        }
        return returnstring;
    }

    public class Addjunoir
    {
        public string id { get; set; }
        public string APPMOBILENO { get; set; }
        public string USERMOBILE { get; set; }
        public string IMEI { get; set; }
        public string ModifyDate { get; set; }
        public string TYPE { get; set; }
        public string USERNAME { get; set; }
        public string ACTIVE { get; set; }
        public string UpdatedBy { get; set; }

        public string NotFound { get; set; }
        public string Error { get; set; }
    }

    [WebMethod]
    //public XmlDataDocument DownloadNews(string council1, string State1, string District1)
    public XmlDataDocument DownloadNews()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        //string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[Status],[Details],[mobileNo],[council],[State],[District],[CurrentDate] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] where council='" + council1 + "' and State='" + State1 + "' and  District='" + District1 + "'";
        string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[Status],[Details],[mobileNo],[council],[State],[District],[CurrentDate] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo]";
        DataSet ds = cc.ExecuteDataset(str);

        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }

    [WebMethod(Description = "DOWNLOAD NEWS INFORMATION TOPIC WISE")]
    public XmlDataDocument DownloadNewsTopicWise(string Topic, string serverId, string deptName, string council, string distId, string villageId, string officeLevel)
    {
        //THIS METHOD IS CHANGED BY JITENDRA PATIL DATED ON 28.12.2016
        XmlDataDocument xmlData = new XmlDataDocument();
        #region OLD Service
        //string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[RadiobtnStatus],[Details],[mobileNo],[council],[State]," +
        //             "[District],[CurrentDate],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] WHERE  [NID] > " + serverId + " AND Topic = N'" + Topic + "'  AND [Department]='" + deptName + "' AND [council]='" + council + "' AND [District]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
        #endregion
        #region New Modify Umesh sir cha sangnyanusar
        string str = string.Empty;
        if (officeLevel.ToString().Equals("10"))
        {
            str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[RadiobtnStatus],[Details],[mobileNo],[council],[State]," +
                        "[District],[CurrentDate],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] WHERE  [NID] > " + serverId + " AND Topic = N'" + Topic + "'  AND [Department]='" + deptName + "' AND [District]='" + distId + "' AND [officeLevel]='" + officeLevel + "'";
        }
        if (officeLevel.ToString().Equals("11"))
        {
            str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[RadiobtnStatus],[Details],[mobileNo],[council],[State]," +
                        "[District],[CurrentDate],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] WHERE  [NID] > " + serverId + " AND Topic = N'" + Topic + "'  AND [Department]='" + deptName + "' AND [council]='" + council + "' AND [officeLevel]='" + officeLevel + "'";
        }
        if (officeLevel.ToString().Equals("12"))
        {
            str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[RadiobtnStatus],[Details],[mobileNo],[council],[State]," +
                        "[District],[CurrentDate],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] WHERE  [NID] > " + serverId + " AND Topic = N'" + Topic + "'  AND [Department]='" + deptName + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
        }
        #endregion
        DataSet ds = cc.ExecuteDataset(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }



    [WebMethod]
    //public XmlDataDocument DownloadNews(string council1, string State1, string District1)
    public XmlDataDocument DownloadSchedule(string serverid, string typeofschedule, string Council)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        //string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[Status],[Details],[mobileNo],[council],[State],[District],[CurrentDate] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] where council='" + council1 + "' and State='" + State1 + "' and  District='" + District1 + "'";
        string str = "SELECT [ID],[TypeOfSchedule],[Topic],[Date],[Time],[Day],[AreaName],[Details],[Council],[mobNo] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalSchedule] where ID > '" + serverid + "' And TypeOfSchedule='" + typeofschedule + "' AND [Council]='" + Council + "'";
        DataSet ds = cc.ExecuteDataset(str);

        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }

    [WebMethod]
    //public XmlDataDocument DownloadNews(string council1, string State1, string District1)
    public XmlDataDocument DownloadEmployee(string serverid, string Department, string Council, string distId, string villageId, string officeLevel)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        #region OLD Service
        // All Ready Comments string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[Status],[Details],[mobileNo],[council],[State],[District],[CurrentDate] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] where council='" + council1 + "' and State='" + State1 + "' and  District='" + District1 + "'";
        //string str = "SELECT  [EID],[Department],[EmpMobileNo],[Name],[Designation],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEmployee] Where [EID] > " + serverid + " and [Department]=N'" + Department + "' AND [Council]='" + Council + "' AND [distId]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
        #endregion
        #region New Service Modify Umesh Sir Sangnyanusar
        string str = string.Empty;
        if (officeLevel.ToString().Equals("10"))
        {
            str = "SELECT  [EID],[Department],[EmpMobileNo],[Name],[Designation],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEmployee] Where [EID] > " + serverid + " and [Department]=N'" + Department + "' AND [distId]='" + distId + "' AND [officeLevel]='" + officeLevel + "'";
        }
        if (officeLevel.ToString().Equals("11"))
        {
            str = "SELECT  [EID],[Department],[EmpMobileNo],[Name],[Designation],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEmployee] Where [EID] > " + serverid + " and [Department]=N'" + Department + "' AND [Council]='" + Council + "' AND [officeLevel]='" + officeLevel + "'";
        }
        if (officeLevel.ToString().Equals("12"))
        {
            str = "SELECT  [EID],[Department],[EmpMobileNo],[Name],[Designation],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalEmployee] Where [EID] > " + serverid + " and [Department]=N'" + Department + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
        }
        #endregion
        DataSet ds = cc.ExecuteDataset(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }





    [WebMethod]
    //public XmlDataDocument DownloadNews(string council1, string State1, string District1)
    public XmlDataDocument DownloadMember(string samiti, string serverid, string Council, string distId, string villageId, string officeLevel)
    {
        string str = string.Empty;
        XmlDataDocument xmlData = new XmlDataDocument();
        //string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[Status],[Details],[mobileNo],[council],[State],[District],[CurrentDate] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] where council='" + council1 + "' and State='" + State1 + "' and  District='" + District1 + "'";
        #region OLD SERVICE
        //if (serverid.Equals(0))
        //{
        //    str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [Samiti]=N'" + samiti + "' AND [Council]='" + Council + "' AND [distId]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
        //}
        //else
        //{
        //    str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [MID] > '" + serverid + "' and [Samiti]=N'" + samiti + "' AND [Council]='" + Council + "' AND [distId]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
        //}
        #endregion
        #region New Service Umesh Sir Hukumavrun
        if (officeLevel.ToString().Equals("10"))
        {
            if (serverid.Equals(0))
            {
                str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [Samiti]=N'" + samiti + "' AND [distId]='" + distId + "' AND [officeLevel]='" + officeLevel + "'";
            }
            else
            {
                str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [MID] > '" + serverid + "' and [Samiti]=N'" + samiti + "' AND [distId]='" + distId + "' AND [officeLevel]='" + officeLevel + "'";
            }
        }
        if (officeLevel.ToString().Equals("11"))
        {
            if (serverid.Equals(0))
            {
                str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [Samiti]=N'" + samiti + "' AND [Council]='" + Council + "' AND [officeLevel]='" + officeLevel + "'";
            }
            else
            {
                str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [MID] > '" + serverid + "' and [Samiti]=N'" + samiti + "' AND [Council]='" + Council + "' AND [officeLevel]='" + officeLevel + "'";
            }
        }
        if (officeLevel.ToString().Equals("12"))
        {
            if (serverid.Equals(0))
            {
                str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [Samiti]=N'" + samiti + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
            }
            else
            {
                str = "SELECT [MID],[Samiti],[MembMobNo],[Name],[Designation],[Userid],[RefMobileNo],[ImageStr],[Council],[distId],[villageId],[officeLevel] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalMemReg] where [MID] > '" + serverid + "' and [Samiti]=N'" + samiti + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
            }
        }
        #endregion
        DataSet ds = cc.ExecuteDataset(str);
        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }


    [WebMethod(Description = "Download about council")]
    //public XmlDataDocument DownloadNews(string council1, string State1, string District1)
    public XmlDataDocument DownloadCouncil(string Sid, string Did)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        //string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[Status],[Details],[mobileNo],[council],[State],[District],[CurrentDate] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] where council='" + council1 + "' and State='" + State1 + "' and  District='" + District1 + "'";
        string str = "SELECT [State],[District],[Council],[ID] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCityInfo] where [State]=" + Sid + " and [District]=" + Did + "";
        DataSet ds = cc.ExecuteDataset(str);

        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }

    [WebMethod]
    //public XmlDataDocument DownloadNews(string council1, string State1, string District1)
    public XmlDataDocument DownloadAboutCouncil(string councilid, string deptid)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        //string str = "SELECT [NID],[Topic],[Department],[Title],[LastDate],[Status],[Details],[mobileNo],[council],[State],[District],[CurrentDate] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalCouncilNewsInfo] where council='" + council1 + "' and State='" + State1 + "' and  District='" + District1 + "'";
        string str = "SELECT [ID],[CouncilName],[Information],[Departments],[DepartmentId],[CouncilId] FROM [Come2myCityDB].[come2mycity].[tbl_CouncipalAboutCouncil] where [CouncilId]=" + councilid + " and [DepartmentId]=" + deptid + "";
        DataSet ds = cc.ExecuteDataset(str);

        if (ds.Tables[0].Rows.Count > 0)
        {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
        else
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "106";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }

    #region DownloadCouncilData(Panchayat Samiti)
    [WebMethod(Description = "DownloadCouncilData")]
    public XmlDataDocument DownloadCouncilData()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {
            string sqlQuery = "select [CoId],[OfficerName] from [Come2myCityDB].[come2mycity].[tbl_CouncilOfficerMaster] ";
            sqlQuery += "select [CDId],[DepartmentName],[CoId] from [Come2myCityDB].[come2mycity].[tbl_CouncilDepartmentMaster] ";
            sqlQuery += "select [CEId],[DesigEmployeeName],[CDId],[DepartmentName],[CoId],[OfficerName] from [Come2myCityDB].[come2mycity].[tbl_CouncilDesigEmployee]";

            DataSet DS = cc.ExecuteDataset(sqlQuery);
            if (DS.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(DS);
                XmlElement xmlEle = xmlData.DocumentElement;
                return xmlData;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NewRecord"] = "106";
                dt.Rows.Add(dr);

                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlelement = xmlData.DocumentElement;
                return xmlData;
            }
        }
        catch
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["Error"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlelement = xmlData.DocumentElement;
            return xmlData;
        }
    }
    #endregion

    #region INSERT MEMBER WORK FOR NAGAR PARISHAD
    //THIS WEB METHHOD UPDATED BY JITENDRA PATIL DATED ON 27.12.2016 
    [WebMethod(Description = "INSERT MEMBER WORK DETAILS")]
    public string InsertmemberWork(string Data)
    {
        int count = 0;
        string returnValue = string.Empty;

        try
        {
            XmlReader reader = XmlReader.Create(new StringReader(Data));
            ds.ReadXml(reader);
            int dsCount = ds.Tables[0].Rows.Count;

            if (dsCount > 0)
            {
                for (int i = 0; i < dsCount; i++)
                {
                    string firstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                    string lastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                    string MemberMobileNo = ds.Tables[0].Rows[i]["MobileNo"].ToString();
                    string WorkHeading = ds.Tables[0].Rows[i]["WorkHeading"].ToString();
                    string WorkDetais = ds.Tables[0].Rows[i]["WorkDetails"].ToString();
                    string imgstr = ds.Tables[0].Rows[i]["ImageStr"].ToString();
                    string Imei = ds.Tables[0].Rows[i]["Imei"].ToString();
                    string Cid = ds.Tables[0].Rows[i]["CNPId"].ToString();
                    string Keyword = ds.Tables[0].Rows[i]["Keyword"].ToString();
                    string WardNo = ds.Tables[0].Rows[i]["WardNo"].ToString();
                    string appid = ds.Tables[0].Rows[i]["AppPK_Id"].ToString();
                    string distId=ds.Tables[0].Rows[i]["distId"].ToString();
                    string villageId=ds.Tables[0].Rows[i]["villageId"].ToString();
                    string officeLevel = ds.Tables[0].Rows[i]["officeLevel"].ToString();
                    string str = "INSERT INTO [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork]([FirstName],[LastName],[MobileNo],[WorkHeading],[WorkDetails],[Image],[Imei],[CNPId],[Keyword],[CreatedBy],[CreatedDate],[WardNo],[distId],[villageId],[officeLevel])" +
                                 "VALUES ('" + firstName + "','" + lastName + "','" + MemberMobileNo + "','" + WorkHeading + "','" + WorkDetais + "','" + imgstr + "','" + Imei + "','" + Cid + "','" + Keyword + "','" + MemberMobileNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + WardNo + "','" + distId + "','" + villageId + "','" + officeLevel + "')";
                    cmd.CommandText = str;
                    cmd.Connection = con;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "SELECT MAX(CMemWorkId) FROM [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork]";
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        returnValue += appid + "*" + id + "#";
                    }
                    catch
                    {
                        returnValue += "0*";
                    }
                    count++;
                }
            }
            if (count == 1)
            {
                return returnValue;
            }
            if (returnValue.EndsWith("*"))
            {
                returnValue = returnValue.Substring(0, returnValue.Length - 1);
            }
        }
        catch
        {
            return returnValue;
        }

        return returnValue;
    }

    #endregion

    #region DownloadData Report for Nagar parishad
    [WebMethod(Description = "Download Search Data Details")]
    public XmlDataDocument DownloadmemberWorkData(string Keyword, string CId, string wardno, string LastServerId, string distId, string villageId, string officeLevel)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            #region OLD Service
            //string Sql = "Select Top 10 [CMemWorkId],[MobileNo],[CNPId],[FirstName],[LastName],[WorkHeading],[WorkDetails],[Image],[WardNo],[distId],[villageId],[officeLevel] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where [CNPId]=" + CId + " AND WardNo='" + wardno + "' AND [CMemWorkId]>'" + LastServerId + "' AND [distId]='" + distId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
            //All Ready Comment string Sql = "Select [CMemWorkId],[MobileNo],[CNPId],[FirstName],[LastName],[WorkHeading],[WorkDetails],[Image],[WardNo] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where [CNPId]=" + CId + " AND WardNo='" + wardno + "' ";
            #endregion
            #region New Service Umesh Sir cha Sangnyanusar
            string Sql = string.Empty;
            if (officeLevel.ToString().Equals("10"))
            {
                Sql = "Select Top 10 [CMemWorkId],[MobileNo],[CNPId],[FirstName],[LastName],[WorkHeading],[WorkDetails],[Image],[WardNo],[distId],[villageId],[officeLevel] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where WardNo='" + wardno + "' AND [CMemWorkId]>'" + LastServerId + "' AND [distId]='" + distId + "' AND [officeLevel]='" + officeLevel + "'";
            }
            if (officeLevel.ToString().Equals("11"))
            {
                Sql = "Select Top 10 [CMemWorkId],[MobileNo],[CNPId],[FirstName],[LastName],[WorkHeading],[WorkDetails],[Image],[WardNo],[distId],[villageId],[officeLevel] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where [CNPId]=" + CId + " AND [WardNo]='" + wardno + "' AND [CMemWorkId]>'" + LastServerId + "' AND [officeLevel]='" + officeLevel + "'";
            }
            if (officeLevel.ToString().Equals("12"))
            {
                Sql = "Select Top 10 [CMemWorkId],[MobileNo],[CNPId],[FirstName],[LastName],[WorkHeading],[WorkDetails],[Image],[WardNo],[distId],[villageId],[officeLevel] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where WardNo='" + wardno + "' AND [CMemWorkId]>'" + LastServerId + "' AND [villageId]='" + villageId + "' AND [officeLevel]='" + officeLevel + "'";
            }
            #endregion
            ds = cc.ExecuteDataset(Sql);
            //string Sql1 = "Select [FirstName],[LastName],[WorkHeading],[WorkDetails],[Image] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where [CNPId]=" + CId + " ";
            //ds = cc.ExecuteDataset(Sql1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
                DataRow dr = dt.NewRow();
                dr["NewRecord"] = "106";
                dt.Rows.Add(dr);

                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlEle = xmlData.DocumentElement;
                return xmlData;
            }
        }
        catch
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            DataRow dr = dt.NewRow();
            dr["NewRecord"] = "105";
            dt.Rows.Add(dr);

            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
            return xmlData;
        }
        //XmlDataDocument xmlData = new XmlDataDocument();
        //DataSet ds = new DataSet();
        //try
        //{
        //    if (Keyword == "Nagar Parishad")
        //    {
        //        string Sql = "Select [FirstName],[LastName],[WorkHeading],[WorkDetails],[Image] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where [CNPId]=" + CId + " ";
        //        ds = cc.ExecuteDataset(Sql);
        //    }
        //    else if (Keyword == "Gram Panchayat")
        //    {
        //        string Sql = "Select [FirstName],[LastName],[WorkHeading],[WorkDetails],[Image] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where [CNPId]=" + CId + " ";
        //        ds = cc.ExecuteDataset(Sql);
        //    }
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        xmlData = new XmlDataDocument(ds);
        //        XmlElement xmlEle = xmlData.DocumentElement;
        //    }
        //    else
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
        //        DataRow dr = dt.NewRow();
        //        dr["NewRecord"] = "106";
        //        dt.Rows.Add(dr);

        //        ds.Tables.Add(dt);
        //        xmlData = new XmlDataDocument(ds);
        //        XmlElement xmlEle = xmlData.DocumentElement;
        //        return xmlData;
        //    }
        //}
        //catch
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn("Error", typeof(int)));
        //    DataRow dr = dt.NewRow();
        //    dr["NewRecord"] = "105";
        //    dt.Rows.Add(dr);

        //    ds.Tables.Add(dt);
        //    xmlData = new XmlDataDocument(ds);
        //    XmlElement xmlEle = xmlData.DocumentElement;
        //    return xmlData;
        //}
        return xmlData;
    }
    #endregion

    //#region DownloadMemberWorkData(Nagar Parishad)
    //[WebMethod(Description = "Download Member Work Deatils")]
    //public XmlDataDocument DownloadmemberWorkData(string firstName, string lastName)
    //{
    //    XmlDataDocument xmlData = new XmlDataDocument();
    //    try
    //    {
    //        string Sql = "Select [FirstName],[LastName],[WorkHeading],[WorkDetails],[Image] from [Come2myCityDB].[come2mycity].[tbl_CouncilMemberWork] where [FirstName]='" + firstName + "' and [LastName]='" + lastName + "' ";
    //        DataSet ds = cc.ExecuteDataset(Sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            xmlData = new XmlDataDocument(ds);
    //            XmlElement xmlEle = xmlData.DocumentElement;
    //            return xmlData;
    //        }
    //        else
    //        {
    //            DataTable dt = new DataTable();
    //            dt.Columns.Add(new DataColumn("NewRecord", typeof(int)));
    //            DataRow dr = dt.NewRow();
    //            dt.Rows.Add(dr);

    //            ds.Tables.Add(dt);
    //            xmlData = new XmlDataDocument(ds);
    //            XmlElement xmlEle = xmlData.DocumentElement;
    //            return xmlData;
    //        }
    //    }
    //    catch
    //    {
    //        DataTable dt = new DataTable();
    //        dt.Columns.Add(new DataColumn("Error", typeof(int)));
    //        DataRow dr = dt.NewRow();
    //        dt.Rows.Add(dr);

    //        ds.Tables.Add(dt);
    //        xmlData = new XmlDataDocument(ds);
    //        XmlElement xmlEle = xmlData.DocumentElement;
    //        return xmlData;
    //    }
    //}
    //#endregion

}


using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;
using System.Configuration;
using System.Text;
using System.Collections.Generic;

/// <summary>
/// Summary description for Myct
/// </summary>
/// 

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Myct : System.Web.Services.WebService
{
    CommonCode cc = new CommonCode();
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    string returnString = string.Empty;
    public Myct()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    #region Method For DropDown
    [WebMethod]
    public XmlDocument DownloadAllComboValue()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {

            string str = "select [categoryId],[categoryName],[parentCategoryId],[catLevel] from [Come2myCityDB].[dbo].[Category]";
            DataSet ds1 = cc.ExecuteDataset(str);

            xmlData = new XmlDataDocument(ds1);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        catch (Exception ex)
        {

        }
        return xmlData;
    }
    #endregion

    #region Method For Download Item
    [WebMethod]
    public XmlDocument DownloadItem(string CategoryId, string Talukaid) //string State, string DistrictId,
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            string str = "select itemAutoId,[itemName],itemDescription,[Area],[Address],[Latitude],[Longitude],[Specialities],[TypeOfUser],[PhoneNo],[Website],[STDCode],[FaxNo],[PinCode] FROM [Come2myCityDB].[dbo].[Item] where  [categoryId]='" + CategoryId + "'  and [Taluka]='" + Talukaid + "'"; //[State]='" + State + "' and and [District]='" + DistrictId + "'
             ds = cc.ExecuteDataset(str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlele = xmlData.DocumentElement;
            }
            else
            {
                dt.Columns.Add("NoRecord",typeof(int));
                DataRow dr = dt.NewRow();
                dr["No"] = "106";
                dt.Rows.Add(dr);
                ds.Tables.Add(dt);
                xmlData = new XmlDataDocument(ds);
                XmlElement xmlele = xmlData.DocumentElement;
            }
        }
        catch (Exception e)
        {
            dt.Columns.Add("Error",typeof(int));
            DataRow dr = dt.NewRow();
            dr["Error"]="105";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    [WebMethod]
    public string DownloadCategory(string categoryName)
    {

        DataSet ds = new DataSet();

        string str = "select ImageStr FROM [Come2myCityDB].[dbo].[Category] where [categoryName]='" + categoryName + "'";
        ds = cc.ExecuteDataset(str);

        byte[] bytei = (byte[])ds.Tables[0].Rows[0][0];

        string result = ds.Tables[0].Rows[0][0].ToString();
        return result;
    }

    #region Method For Download Image
    [WebMethod]
    public XmlDocument DownloadImage(string itemAutoId)
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            //string str = "select ImageStr FROM [Come2myCityDB].[dbo].[Category] where [categoryName]='" + categoryName + "'";
           // string str = "select ImageString FROM [Come2myCityDB].[dbo].[Item] where [itemAutoId]='" + itemAutoId + "'";

            string str = "select ImageString FROM [Come2myCityDB].[dbo].[ItemImgString] where [ImgAutoId]='" + itemAutoId + "'";

             ds = cc.ExecuteDataset(str);
            //byte[] bytei = (byte[])ds.Tables[0].Rows[0][0];
            //string foo = Encoding.ASCII.GetString(bytei);
            if(ds.Tables[0].Rows.Count > 0)
            {
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
            }
            else
            {
            dt.Columns.Add("Norecord", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Norecord"] = "106";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
            }
        }
        catch (Exception)
        {
            dt.Columns.Add("Error", typeof(int));
            DataRow dr = dt.NewRow();
            dr["Error"] = "100";
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        return xmlData;
    }
    #endregion

    #region Method For Insert Profile
    [WebMethod]
    public string InsertData(string Keyword, string BString, string MobileNo)
    {
        if (BString != "" && Keyword != null)
        {

            try
            {
                if (Keyword.Equals("USER"))
                {
                    return Profile(BString, MobileNo);
                }
                //else if (Keyword.Equals("AE"))
                //{
                //    return EntraUser(BString, MobileNo);
                //}


                return null;
            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        else
        {

            return CommonCode.WRONG_INPUT.ToString();
        }

    }
    private string Profile(string Bstring, string MobileNo)
    {
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        string uid = System.Guid.NewGuid().ToString();
        string st = "select usrUserId from UserMaster where usrMobileNo='" + MobileNo + "'";
        uid = cc.ExecuteScalar(st);
        if (uid == "" || uid == null)
        {
            for (int i = 1; i < stringArray.Length; i += 13)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

                cmd.Parameters.Add(new SqlParameter("@usrFirstName", stringArray[i].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrLastName", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrMobileNo", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrEmailId", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrAddress", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrState", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@strDevId", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrDistrict", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrTaluka", stringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrCity", stringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@usrUserId", uid));


                cmd.CommandText = "uspMYCTUserMasterInsert";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                //string str = "select max(GID) from [Come2myCityDB].[dbo].[tbl_BCreateGat] ";
                //string str1 = cc.ExecuteScalar(str);
                //nonInsertedValues1 += str1 + "*";


            }
        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString();
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;



    }
    [WebMethod]
    public string InsertEntraUser(string MobileNo, string usrFirstName, string usrLastName, string usrMobileNo, string usrEmailId, string usrAddress, string usrState, string strDevId, string usrDistrict, string usrTaluka, string usrCity, string itemName, string TypeOfFirm, string GovOrganisation, string Area, string Specialities, string VerifiedAgent, string TypeOfUser, string Address, string State, string District, string Taluka, string cityId, string Latitude, string Longitude, string ImageString, string categoryId, string Active, string PhoneNo, string STDCode, string FaxNo, string PinCode, string Website)
    {
        //string[] stringArray = EString.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        string newUid = string.Empty;
        string uid = "select usrUserId from UserMaster where usrMobileNo='" + MobileNo + "'";
        string uid1 = cc.ExecuteScalar(uid);


        cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

        if (uid1 == "" || uid1 == null)
        {
            newUid = System.Guid.NewGuid().ToString();

            cmd.Parameters.Add(new SqlParameter("@usrFirstName", usrFirstName));
            cmd.Parameters.Add(new SqlParameter("@usrLastName", usrLastName));
            cmd.Parameters.Add(new SqlParameter("@usrMobileNo", usrMobileNo));
            cmd.Parameters.Add(new SqlParameter("@usrEmailId", usrEmailId));
            cmd.Parameters.Add(new SqlParameter("@usrAddress", usrAddress));
            cmd.Parameters.Add(new SqlParameter("@usrState", usrState));
            cmd.Parameters.Add(new SqlParameter("@strDevId", strDevId));
            cmd.Parameters.Add(new SqlParameter("@usrDistrict", usrDistrict));
            cmd.Parameters.Add(new SqlParameter("@usrTaluka", usrTaluka));
            cmd.Parameters.Add(new SqlParameter("@usrCity", usrTaluka));
            cmd.Parameters.Add(new SqlParameter("@usrUserId", newUid));


            cmd.CommandText = "uspMYCTUserMasterInsert";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();
        }
       
            string itemid = System.Guid.NewGuid().ToString();
            cmd.Parameters.Add(new SqlParameter("@IEMINo", strDevId));
            cmd.Parameters.Add(new SqlParameter("@itemId", itemid));
            cmd.Parameters.Add(new SqlParameter("@itemName", itemName));
            cmd.Parameters.Add(new SqlParameter("@TypeOfFirm", TypeOfFirm));
            cmd.Parameters.Add(new SqlParameter("@GovOrganisation", GovOrganisation));
            cmd.Parameters.Add(new SqlParameter("@Area", Area));
            cmd.Parameters.Add(new SqlParameter("@Specialities", Specialities));
            cmd.Parameters.Add(new SqlParameter("@VerifiedAgent", VerifiedAgent));
            cmd.Parameters.Add(new SqlParameter("@TypeOfUser", TypeOfUser));
            cmd.Parameters.Add(new SqlParameter("@Address", Address));
            cmd.Parameters.Add(new SqlParameter("@State", State));
            cmd.Parameters.Add(new SqlParameter("@District", District));
            cmd.Parameters.Add(new SqlParameter("@Taluka", Taluka));
            cmd.Parameters.Add(new SqlParameter("@cityId", cityId));
            cmd.Parameters.Add(new SqlParameter("@Latitude", Latitude));
            cmd.Parameters.Add(new SqlParameter("@Longitude", Longitude));
            cmd.Parameters.Add(new SqlParameter("@ImageString", ImageString));
            cmd.Parameters.Add(new SqlParameter("@categoryId", categoryId));
            cmd.Parameters.Add(new SqlParameter("@Active", Active));
            cmd.Parameters.Add(new SqlParameter("@MobileNo", MobileNo));
            cmd.Parameters.Add(new SqlParameter("@PhoneNo", PhoneNo));
            cmd.Parameters.Add(new SqlParameter("@STDCode", STDCode));
            cmd.Parameters.Add(new SqlParameter("@FaxNo", FaxNo));
            cmd.Parameters.Add(new SqlParameter("@PinCode", PinCode));

            cmd.Parameters.Add(new SqlParameter("@Website", Website));
            //cmd.Parameters.Add(new SqlParameter("@UserMasterUid", newUid));

            cmd.CommandText = "uspMYCTUMAEInsert";
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            result = cmd.ExecuteNonQuery();

            if (string.IsNullOrEmpty(nonInsertedValues))
            {
                string sql = "Select [itemAutoId] from [Come2myCityDB].[dbo].[Item] order by [itemAutoId] desc";
                string ID = Convert.ToString(cc.ExecuteScalar(sql));
                return ID;
                //string sql = CommonCode.OK.ToString();
                //return sql + nonInsertedValues1;
            }
            else
                return nonInsertedValues;
    }

    //public string EntraUser(string EString,string MobileNo)
    //{
    //    string[] stringArray = EString.Split(new char[] {'#','*'});
    //    string nonInsertedValues = string.Empty;
    //    string nonInsertedValues1 = string.Empty;
    //    int result;
    //    string newUid = string.Empty;
    //    string uid = "select usrUserId from UserMaster where usrMobileNo='"+MobileNo+"'";
    //    string uid1 = cc.ExecuteScalar(uid);

    //        for (int i = 1; i < stringArray.Length; i += 29)
    //        {
    //            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

    //            if (uid1 == "" || uid1 == null)
    //            {
    //                newUid = System.Guid.NewGuid().ToString();

    //            cmd.Parameters.Add(new SqlParameter("@usrFirstName", stringArray[i].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrLastName", stringArray[i + 1].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrMobileNo", stringArray[i + 2].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrEmailId", stringArray[i + 3].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrAddress", stringArray[i + 4].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrState", stringArray[i + 5].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@strDevId", stringArray[i + 6].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrDistrict", stringArray[i + 7].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrTaluka", stringArray[i + 8].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrCity", stringArray[i + 9].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@usrUserId", newUid));


    //            cmd.CommandText = "uspMYCTUserMasterInsert";
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            if (cmd.Connection.State == ConnectionState.Closed)
    //                cmd.Connection.Open();
    //            result = cmd.ExecuteNonQuery();
    //            }

    //            string itemid = System.Guid.NewGuid().ToString();
    //            cmd.Parameters.Add(new SqlParameter("@itemId", itemid));
    //            cmd.Parameters.Add(new SqlParameter("@itemName", stringArray[i + 10].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@TypeOfFirm", stringArray[i + 11].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@GovOrganisation", stringArray[i + 12].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@Area", stringArray[i + 13].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@Specialities", stringArray[i + 14].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@VerifiedAgent", stringArray[i + 15].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@TypeOfUser", stringArray[i + 16].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@Address", stringArray[i + 17].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@State", stringArray[i + 18].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@District", stringArray[i + 19].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@Taluka", stringArray[i + 20].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@cityId", stringArray[i + 21].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@Latitude", stringArray[i + 22].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@Longitude", stringArray[i + 23].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@ImageString", stringArray[i + 24].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@categoryId", stringArray[i + 25].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@Active", stringArray[i + 26].ToString()));
    //            cmd.Parameters.Add(new SqlParameter("@UserMasterUid", newUid));


    //            cmd.CommandText = "uspMYCTUMAEInsert";
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            if (cmd.Connection.State == ConnectionState.Closed)
    //                cmd.Connection.Open();
    //            result = cmd.ExecuteNonQuery();
    //        }

    //        if (string.IsNullOrEmpty(nonInsertedValues))
    //        {
    //            string sql = CommonCode.OK.ToString();
    //            return sql + nonInsertedValues1;
    //        }
    //        else
    //            return nonInsertedValues;

    //}

    [WebMethod(Description ="Item Related insert image details")]
    public string InsertImage(string itmAutoId,string imgString,string insertBy)
    {
        string SqlQry = string.Empty;
        int res = 0;
        try
        {
            SqlQry = "insert into  [Come2myCityDB].[dbo].[ItemImgString]([ImgAutoId],[ImageString],[CreatedBy],[CreatedDate]) values('" + itmAutoId + "','" + imgString + "','"+ insertBy +"','"+ System.DateTime.Now.ToString("yyyy-MM-dd") +"')";
            res = cc.ExecuteNonQuery(SqlQry);
        }
        catch
        {
            return "106";
        }
        return "105";
    }


    #endregion

    #region Method For OTP

    [WebMethod]
    public string SendOTP(string CategoryId, string MobileNo, string IEMINo)
    {
        int result = 0;
        string imei = string.Empty;
        string mobieno = string.Empty;
        string cid = string.Empty;
        string otpstr = string.Empty;
        string OTPstr = string.Empty;
        string str0 = string.Empty;
        string str1 = string.Empty;
        string catName = string.Empty;

        string st = "select categoryId,MobileNo,IEMINo from [Come2myCityDB].[dbo].[Item] where categoryId='" + CategoryId + "' and MobileNo='" + MobileNo + "'";
        DataSet ds = cc.ExecuteDataset(st);

        string count = ds.Tables[0].Rows.Count.ToString();

        if (ds.Tables[0].Rows.Count > 0)
        {
            imei = ds.Tables[0].Rows[0]["IEMINo"].ToString();
            mobieno = ds.Tables[0].Rows[0]["IEMINo"].ToString();
            cid = ds.Tables[0].Rows[0]["IEMINo"].ToString();

        }


        if (count == "" || count == null || count == "0")
        {
            string st1 = "select categoryName from [Come2myCityDB].[dbo].[Category] where categoryId='" + CategoryId + "'";
            ds = cc.ExecuteDataset(st1);
            catName = ds.Tables[0].Rows[0][0].ToString();
            string o = "select [IEMINo],[MobileNo],[CategoryId],[OTP] FROM [Come2myCityDB].[dbo].[MyCtAppROTP] where IEMINo='" + IEMINo + "' and MobileNo='" + MobileNo + "' and CategoryId='" + CategoryId + "' ";
            ds = cc.ExecuteDataset(o);

            if (ds.Tables[0].Rows.Count > 0)
            {
                otpstr = Convert.ToString(ds.Tables[0].Rows[0]["OTP"]);
            }
            else
            {
                Random rand = new Random();
                otpstr = rand.Next(1001, 9999).ToString();
                str0 = "Insert into [Come2myCityDB].[dbo].[MyCtAppROTP]([IEMINo],[MobileNo],[CategoryId],[OTP]) values('" + IEMINo + "','" + MobileNo + "','" + CategoryId + "','" + otpstr + "')";
                result = cc.ExecuteNonQuery(str0);
            }

            //----------Send SMS---------------------
            if (result > 0)
            {

                string myMobileNo = MobileNo;
                OTPstr = otpstr;
                //string myName = firstname;
                string passwordMessage = "Dear Sir, Your Username is " + myMobileNo + " & OTP is " + OTPstr + " for  " + catName + " registration  " + cc.AddSMS(myMobileNo);
                int smslength = passwordMessage.Length;
                cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

            }
            return "SUCCESS";
        }
        else if (imei.ToString() == IEMINo.ToString() && mobieno.ToString() == MobileNo.ToString() && cid.ToString() == CategoryId.ToString())
        {

            return "UPDATE";

        }
        else
        {
            string o1 = "select [IEMINo],[MobileNo],[CategoryId],[OTP] FROM [Come2myCityDB].[dbo].[MyCtAppROTP] where IEMINo='" + IEMINo + "' and MobileNo='" + MobileNo + "' and CategoryId='" + CategoryId + "' ";
            ds = cc.ExecuteDataset(o1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                otpstr = Convert.ToString(ds.Tables[0].Rows[0]["OTP"]);
            }
            else
            {
                Random rand = new Random();
                otpstr = rand.Next(1001, 9999).ToString();
                str1 = "Insert into [Come2myCityDB].[dbo].[MyCtAppROTP]([IEMINo],[MobileNo],[CategoryId],[OTP]) values('" + IEMINo + "','" + MobileNo + "','" + CategoryId + "','" + otpstr + "')";
                result = cc.ExecuteNonQuery(str1);
            }

            //----------Send SMS---------------------
            if (result > 0)
            {

                string myMobileNo = MobileNo;
                OTPstr = otpstr;
                //string myName = firstname;
                string passwordMessage = "Welcome , Your OTP Verification for Myct ur Username=" + myMobileNo + " & OTP is " + OTPstr + "  " + cc.AddSMS(myMobileNo);
                int smslength = passwordMessage.Length;
                cc.TransactionalSMSCountry("OnlineExam", myMobileNo, passwordMessage, smslength, 22);

            }
            return "IEMEI";
        }
    }
    #endregion

    #region CheckOTP
    [WebMethod]
    public string chkOTP(string MobileNo, string OTP, string CategoryId, string IEMINo)
    {
        cmd.Connection = con;
        string otpEzee1 = "select OTP from [Come2myCityDB].[dbo].[MyCtAppROTP] where categoryId='" + CategoryId + "' and MobileNo='" + MobileNo + "' and IEMINo='" + IEMINo + "'";
        cmd.CommandText = otpEzee1;
        DataSet ds2 = cc.ExecuteDataset(otpEzee1);
        string otpEzee = ds2.Tables[0].Rows[0][0].ToString();

        if (OTP.ToString() == otpEzee.ToString())
        {
            try
            {
                cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@categoryId", CategoryId);
                cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                cmd.Parameters.AddWithValue("@IEMINo", IEMINo);


                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspMyctItemUpdateOTP";

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }

            return "107";
        }
        else
        {

            return "108";
        }
    }
    #endregion

    [WebMethod]
    public string insertxmlData(string xmlString)
    {
        DataSet ds = new DataSet();
        StringBuilder output = new StringBuilder();
        XmlReader xmlFile = XmlReader.Create(new StringReader(xmlString));
        XmlWriterSettings ws = new XmlWriterSettings();
        ws.Indent = true;
        XmlWriter writer = XmlWriter.Create(output, ws);
        ds.ReadXml(xmlFile);

        string s = ds.Tables[0].Rows[0][0].ToString();
        string s1 = ds.Tables[0].Rows[0][1].ToString();

        return "1";
    }

    //////////In  myct App To Create Association Related To Myct  By Ram Kendre///////////////

    #region METHOD TO Insert Data for News,Group Creation,Complaint,group participant
    [WebMethod(Description = "Method to Insert data for News Details")]
    public string InsertNewsData(string NewsString)
    {
        string SqlQuery = string.Empty;
        int result;
        string[] ArryString = NewsString.Split(new char[] { '*', '#' });
        var temp = new List<string>();
        foreach (var s in ArryString)
        {
            if (!string.IsNullOrEmpty(s))
                temp.Add(s);
        }
        ArryString = temp.ToArray();
        try
        {
            for (int i = 0; i < ArryString.Length; i += 5)
            {
                SqlQuery = "insert into [Come2myCityDB].[dbo].[tblmyctAddNews]([usrMobNo],[NewsgroupId],[NewsTitle],[NewsBody],[day],[CreatedBy],[CreatedDate])" +
                           "values('" + ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                result = cc.ExecuteNonQuery(SqlQuery);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Method to Insert data for Complaint Details")]
    public string InsertComplaintData(string ComplaintString)
    {
        string SqlQuery = string.Empty;
        int result;
        string[] ArryString = ComplaintString.Split(new char[] { '*', '#' });
        var temp = new List<string>();
        foreach (var s in ArryString)
        {
            if (!string.IsNullOrEmpty(s))
                temp.Add(s);
        }
        ArryString = temp.ToArray();
        try
        {
            for (int i = 0; i < ArryString.Length; i += 5)
            {
                SqlQuery = "insert into [Come2myCityDB].[dbo].[tblmyctComplaint]([usrComplaintMobNo],[ComplaintgroupId],[ComplaintTitle],[ComplaintBody],[Day],[CreatedBy],[CreatedDate])" +
                           "values('" + ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                result = cc.ExecuteNonQuery(SqlQuery);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Method to Insert data for Group Creation Details")]
    public string InsertGroupCreationData(string GrpCreationString)
    {
        string SqlQuery = string.Empty;
        int result; string SQL = string.Empty; string serverid = string.Empty;
        string[] ArryString = GrpCreationString.Split(new char[] { '*', '#' });
        var temp = new List<string>();
        foreach (var s in ArryString)
        {
            if (!string.IsNullOrEmpty(s))
                temp.Add(s);
        }
        ArryString = temp.ToArray();

        try
        {
            for (int i = 0; i < ArryString.Length; i += 5)
            {
                SqlQuery = "insert into [Come2myCityDB].[dbo].[tblmyctGroupCreation]([AssociationName],[Mission],[Vission],[Icon],[CreatedBy],[CreatedDate],[IsVerify])" +
                           "values('" + ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','0')";
                result = cc.ExecuteNonQuery(SqlQuery);

                SQL = "select max([SnoId]) from [Come2myCityDB].[dbo].[tblmyctGroupCreation]";
                serverid = cc.ExecuteScalar(SQL);

                returnString += serverid + "*" + ArryString[i].ToString() + "#";
            }
        }
        catch
        {
            return "0";
        }
        return returnString;
    }

    [WebMethod(Description = "Method to Insert data for Group Creation Details")]
    public string InsertGroupparticipantData(string GrpparticipantString)
    {
        string SqlQuery = string.Empty;
        int result;
        string[] ArryString = GrpparticipantString.Split(new char[] { '*', '#' });
        var temp = new List<string>();
        foreach (var s in ArryString)
        {
            if (!string.IsNullOrEmpty(s))
                temp.Add(s);
        }
        ArryString = temp.ToArray();
        try
        {
            for (int i = 0; i < ArryString.Length; i += 7)
            {
                SqlQuery = "insert into [Come2myCityDB].[dbo].[tblmyctGroupParticipant]([usrGroupParticipantMobNo],[FirstName],[LastName],[AdminNo],[AddedBy],[Role],[GroupId],[CreatedBy],[CreatedDate])" +
                           "values('" + ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i + 5].ToString() + "','" + ArryString[i + 6].ToString() + "','" + ArryString[i].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                result = cc.ExecuteNonQuery(SqlQuery);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }
    #endregion

    #region METHOD TO DOWNLOAD FOR GROUP CREATION DATA DETAILS
    [WebMethod(Description = "METHOD TO Download Group Creation Details.")]
    public string DownloadGroupCreation(string usrMobgrpCreationNo)
    {
        DataSet ds = new DataSet();
        string SqlQry = string.Empty;
        string returnStr = String.Empty;
        string GrouppId = string.Empty;
        string userMobile = string.Empty;
        string newsGroupId = string.Empty;
        string newsTitle = string.Empty;
        string newsBody = string.Empty;
        string day = string.Empty;
        string groupCreId = string.Empty;
        string isverify = string.Empty;

        try
        {
            SqlQry = "SELECT [GroupId] FROM [Come2myCityDB].[dbo].[tblmyctGroupParticipant] WHERE [usrGroupParticipantMobNo]='" + usrMobgrpCreationNo + "'";
            ds = cc.ExecuteDataset(SqlQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GrouppId = GrouppId + "," + ds.Tables[0].Rows[i][0].ToString();
                }
                GrouppId = GrouppId.Substring(1);
            }
            SqlQry = "SELECT [SnoId],[AssociationName],[Mission],[Vission],[Icon],[IsVerify] FROM [Come2myCityDB].[dbo].[tblmyctGroupCreation] WHERE [SnoId] IN (" + GrouppId + ")";
                DataSet Ds = cc.ExecuteDataset(SqlQry);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                int count = Ds.Tables[0].Rows.Count;
                    for (int rows = 0; rows < count; rows++)
                    {
                        groupCreId = Ds.Tables[0].Rows[rows]["SnoId"].ToString();
                        userMobile = Ds.Tables[0].Rows[rows]["AssociationName"].ToString();
                        newsGroupId = Ds.Tables[0].Rows[rows]["Mission"].ToString();
                        newsTitle = Ds.Tables[0].Rows[rows]["Vission"].ToString();
                        newsBody = Ds.Tables[0].Rows[rows]["Icon"].ToString();
                        isverify = Ds.Tables[0].Rows[rows]["IsVerify"].ToString();

                        returnStr += groupCreId + "*" + userMobile + "*" + newsGroupId + "*" + newsTitle + "*" + newsBody + "*" + isverify +"#";
                    }
                    return returnStr;
                }
                else
                {
                    return "106" ;
                }
            }
        catch
        {
            return returnStr;
        }
        return returnStr;
    }
    #endregion

    #region METHOD TO DOWNLOAD NEW DETAILS
    [WebMethod(Description = "METHOD TO DOWNLOAD NEW DETAILS")]
    public string DownloadNewDetails(string userMobileNumber)
    {
        DataSet ds = new DataSet();
        string SqlQry = string.Empty;
        string returnStr = "0";
        string GrouppId = string.Empty;
        string userMobile = string.Empty;
        string newsGroupId = string.Empty;
        string newsTitle = string.Empty;
        string newsBody = string.Empty;
        string day = string.Empty;

        try
        {
            SqlQry = "SELECT DISTINCT [GroupId] FROM [Come2myCityDB].[dbo].[tblmyctGroupParticipant] WHERE [usrGroupParticipantMobNo]='" + userMobileNumber + "'";
            ds = cc.ExecuteDataset(SqlQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GrouppId = GrouppId + ",'" + ds.Tables[0].Rows[i][0].ToString() + "'";
                }
                GrouppId = GrouppId.Substring(1);

                SqlQry = "SELECT [usrMobNo],[NewsgroupId],[NewsTitle],[NewsBody],[day] FROM [Come2myCityDB].[dbo].[tblmyctAddNews] WHERE [NewsgroupId] IN (" + GrouppId + ")";
                DataSet Ds = cc.ExecuteDataset(SqlQry);
                int count = Ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int rows = 0; rows < count; rows++)
                    {
                        userMobile = Ds.Tables[0].Rows[rows]["usrMobNo"].ToString();
                        newsGroupId = Ds.Tables[0].Rows[rows]["NewsgroupId"].ToString();
                        newsTitle = Ds.Tables[0].Rows[rows]["NewsTitle"].ToString();
                        newsBody = Ds.Tables[0].Rows[rows]["NewsBody"].ToString();
                        day = Ds.Tables[0].Rows[rows]["day"].ToString();

                        returnStr += userMobile + "*" + newsGroupId + "*" + newsTitle + "*" + newsBody + "*" + day + "#";
                    }
                    return returnStr;
                }
                else
                {
                    return returnStr;
                }
            }
            return returnStr;
        }
        catch
        {
            return returnStr;
        }
    }

    #endregion

    #region METHOD TO DOWNLOAD COMPLAINT DETAILS
    [WebMethod(Description = "METHOD TO DOWNLOAD COMPLAINT DETAILS")]
    public string DownloadComplaintDetails(string userMobileNumber)
    {
        DataSet ds = new DataSet();
        string SqlQry = string.Empty;
        string returnStr = "0";
        string GrouppId = string.Empty;
        string userMobile = string.Empty;
        string newsGroupId = string.Empty;
        string newsTitle = string.Empty;
        string newsBody = string.Empty;
        string day = string.Empty;
        try
        {
            SqlQry = "SELECT DISTINCT [GroupId] FROM [Come2myCityDB].[dbo].[tblmyctGroupParticipant] WHERE [usrGroupParticipantMobNo]='" + userMobileNumber + "'";
            ds = cc.ExecuteDataset(SqlQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GrouppId = GrouppId + ",'" + ds.Tables[0].Rows[i][0].ToString() + "'";
                }
                GrouppId = GrouppId.Substring(1);

                SqlQry = "SELECT [usrComplaintMobNo],[ComplaintgroupId],[ComplaintTitle],[ComplaintBody],[Day] FROM [Come2myCityDB].[dbo].[tblmyctComplaint] WHERE [ComplaintgroupId] IN (" + GrouppId + ")";
                DataSet Ds = cc.ExecuteDataset(SqlQry);
                int count = Ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int rows = 0; rows < count; rows++)
                    {
                        userMobile = Ds.Tables[0].Rows[rows]["usrComplaintMobNo"].ToString();
                        newsGroupId = Ds.Tables[0].Rows[rows]["ComplaintgroupId"].ToString();
                        newsTitle = Ds.Tables[0].Rows[rows]["ComplaintTitle"].ToString();
                        newsBody = Ds.Tables[0].Rows[rows]["ComplaintBody"].ToString();
                        day = Ds.Tables[0].Rows[rows]["Day"].ToString();

                        returnStr += userMobile + "*" + newsGroupId + "*" + newsTitle + "*" + newsBody + "*" + day + "#";
                    }
                    return returnStr;
                }
                else
                {
                    return returnStr;
                }
            }
            return returnStr;
        }
        catch
        {
            return returnStr;
        }
    }

    #endregion

    #region METHOD TO DOWNLOAD GROUP PARTICIPANTS
    [WebMethod(Description = "METHOD TO DOWNLOAD GROUP PARTICIPANTS")]
    public string DownloadGroupParticipants(string userMobileNumber)
    {
        DataSet ds = new DataSet();
        string SqlQry = string.Empty;
        string returnStr = "0";
        string GrouppId = string.Empty;
        string userMobile = string.Empty;
        string firstName = string.Empty;
        string lastName = string.Empty;
        string admNo = string.Empty;
        string addedBy = string.Empty;
        string role = string.Empty;
        string groupId = string.Empty;

        try
        {
            SqlQry = "SELECT DISTINCT [GroupId] FROM [Come2myCityDB].[dbo].[tblmyctGroupParticipant] WHERE [usrGroupParticipantMobNo]='" + userMobileNumber + "'";
            ds = cc.ExecuteDataset(SqlQry);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GrouppId = GrouppId + ",'" + ds.Tables[0].Rows[i][0].ToString() + "'";
                }
                GrouppId = GrouppId.Substring(1);

                SqlQry = "SELECT [usrGroupParticipantMobNo],[FirstName],[LastName],[AdminNo],[AddedBy],[Role],[GroupId] " +
                         "FROM [Come2myCityDB].[dbo].[tblmyctGroupParticipant] WHERE [GroupId] IN (" + GrouppId + ")";

                DataSet Ds = cc.ExecuteDataset(SqlQry);
                int count = Ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    for (int rows = 0; rows < count; rows++)
                    {
                        userMobile = Ds.Tables[0].Rows[rows]["usrGroupParticipantMobNo"].ToString();
                        firstName = Ds.Tables[0].Rows[rows]["FirstName"].ToString();
                        lastName = Ds.Tables[0].Rows[rows]["LastName"].ToString();
                        admNo = Ds.Tables[0].Rows[rows]["AdminNo"].ToString();
                        addedBy = Ds.Tables[0].Rows[rows]["AddedBy"].ToString();
                        role = Ds.Tables[0].Rows[rows]["Role"].ToString();
                        groupId = Ds.Tables[0].Rows[rows]["GroupId"].ToString();

                        returnStr += userMobile + "*" + firstName + "*" + lastName + "*" + admNo + "*" + addedBy + "*" + role + "*" + groupId + "#";
                    }
                    return returnStr;
                }
                else
                {
                    return returnStr;
                }
            }
            return returnStr;
        }
        catch
        {
            return returnStr;
        }
    }

    #endregion

}


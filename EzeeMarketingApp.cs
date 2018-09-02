using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Management;
using System.Data;

/// <summary>
/// Summary description for EzeeMarketingApp
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EzeeMarketingApp : System.Web.Services.WebService
{
    public EzeeMarketingApp()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    string projName = "", status = "", description = "", date = "", loginNo = "", refMobileNo = "";
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    XmlDataDocument dataXml = new XmlDataDocument();
    string returnstring = string.Empty;
    string Sql = string.Empty;

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    #region INSERT DATA
    //[WebMethod(Description = "METHOD TO INSERT DEVELOPER REPORTS")]
    //public string InsertDevReports(string DevString)
    //{
    //    //string userId = string.Empty;
    //    //string fname = string.Empty;
    //    //string lname = string.Empty;
    //    //string refmobno = string.Empty;
    //    int result;
    //    string[] ArryString = DevString.Split(new char[] { '*', '#' });
    //    var temp = new List<string>();
    //    foreach (var s in ArryString)
    //    {
    //        if (!string.IsNullOrEmpty(s))
    //            temp.Add(s);
    //    }
    //    ArryString = temp.ToArray();
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        for (int i = 0; i < ArryString.Length; i += 9)
    //        {
    //            string sql = "insert into [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt]([usrUserId],[usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrWorkStatus],[usrSubject],[usrContents],[usrTimeReq],[usrEndDate],[PrjDay],[PrjDate],[usrSpecificwork],[usrAttachment],[PrjImage],[usrCurrentDate])" +
    //                         "VALUES('7984075e-627b-4210-9cf8-5ab34bd32779','abc','xyz','" + ArryString[i].ToString() + "','asdfg','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','1/1/2014','" + ArryString[i + 5].ToString() + "','" + ArryString[i + 6].ToString() + "','" + ArryString[i + 7].ToString() + "','E:\\HostingSpaces\\myct\\myct.in\\wwwroot\\MarketingAdmin\\NewsFiles\','" + ArryString[i + 8].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
    //            result = cc.ExecuteNonQuery(sql);
    //        }

    //        //string sqlQuery = " INSERT INTO [Come2myCityDB].[come2mycity].[EzeeMarketingDevReports] ([ProjectName],[Status],[Description],[Date],[LoginNumber],[RefMobileNumber]) " +
    //        //                  " VALUES ('" + projectName + "','" + status + "','" + details + "','" + date + "','" + loginNumber + "','" + refMobileNumber + "')";
    //        //cc.ExecuteNonQuery(sqlQuery);
    //        //string sql = "select usrUserId, usrFirstName, usrLastName from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + loginNumber + "'";
    //        //ds = cc.ExecuteDataset(sql);
    //        //if (ds.Tables[0].Rows.Count > 0)
    //        //{
    //        //    userId = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
    //        //    fname = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
    //        //    lname = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
    //        //}
    //        //string SQL = "select [RefMobileNo] from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [keyword]='EZEEMARKETING' and [mobileNo]='" + loginNumber + "'";
    //        //ds = cc.ExecuteDataset(SQL);
    //        //if (ds.Tables[0].Rows.Count > 0)
    //        //{
    //        //    refmobno = Convert.ToString(ds.Tables[0].Rows[0]["RefMobileNo"]);
    //        //}
    //        //string sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt]([usrUserId],[usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrContents],[usrTimeReq],[usrEndDate],[usrAttachment],[usrWorkStatus],[usrSpecificwork],[usrSubject],[usrCurrentDate],[RefMobileNo])" +
    //        //                  "VALUES('" + userId + "','" + fname + "','" + lname + "','" + projectName + "','" + EntryType + "','" + Content + "','" + TimeReq + "','" + EndDate + "','E:\\HostingSpaces\\myct\\myct.in\\wwwroot\\MarketingAdmin\\NewsFiles\','" + status + "','" + details + "','" + Subject + "','" + System.DateTime.Now + "','" + refmobno + "')";
    //        //cc.ExecuteNonQuery(sqlQuery);
    //        //return "106";
    //    }
    //    catch
    //    {
    //        return "105";
    //    }
    //    return "106";
    //}


    //[WebMethod(Description = "Marketing DEVELOPER TO ADMIN")]
    //public string DownloadDevReports(string refMobile)
    //{
    //    try
    //    {
    //        string sqlQuery = "SELECT * FROM [Come2myCityDB].[come2mycity].[report] WHERE [RefMobileNumber] = '" + refMobile + "'";  //EzeeMarketingDevReports
    //        DataSet ds = cc.ExecuteDataset(sqlQuery);

    //        int count = ds.Tables[0].Rows.Count;
    //        string resString = "";
    //        if (count > 0)
    //        {
    //            for (int i = 0; i < count; i++)
    //            {
    //                projName = ds.Tables[0].Rows[i][1].ToString();
    //                status = ds.Tables[0].Rows[i][2].ToString();
    //                description = ds.Tables[0].Rows[i][3].ToString();
    //                date = ds.Tables[0].Rows[i][4].ToString();
    //                if (date.Length > 11)
    //                {
    //                    date = date.Substring(0, 10);
    //                }
    //                loginNo = ds.Tables[0].Rows[i][5].ToString();
    //                refMobileNo = ds.Tables[0].Rows[i][6].ToString();

    //                resString += projName + "*" + status + "*" + description + "*" + date + "*" + loginNo + "*" + refMobileNo + "#";
    //            }
    //            return resString;
    //        }
    //        return "105"; 
    //    }
    //    catch
    //    {
    //        return "105"; 
    //    }
    //}

    [WebMethod(Description = "METHOD TO INSERT DEVELOPER REPORTS")]
    public string UploadDevReports(string DevString)
    {
        //string userId = string.Empty;
        //string fname = string.Empty;
        //string lname = string.Empty;
        string Serverid = string.Empty;
        int result;
        string[] ArryString = DevString.Split(new char[] { '*', '#' });
        var temp = new List<string>();
        foreach (var s in ArryString)
        {
            if (!string.IsNullOrEmpty(s))
                temp.Add(s);
        }
        ArryString = temp.ToArray();
        DataSet ds = new DataSet();
        try
        {
            for (int i = 0; i < ArryString.Length; i += 13)
            {
                string sql = "insert into [EzeeMarketingDevReport]([ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[CreatedBy],[CreatedDate],[Imei],[CustName])" +
                             "VALUES('" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i + 5].ToString() + "','" + ArryString[i + 6].ToString() + "','" + ArryString[i + 7].ToString() + "','" + ArryString[i + 8].ToString() + "','" + ArryString[i + 9].ToString() + "','NULL','" + ArryString[i + 10].ToString() + "','" + ArryString[i + 11].ToString() + "','" + ArryString[i + 11].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','0','" + ArryString[i + 12].ToString() + "')";
                result = cc.ExecuteNonQuery(sql);

                string Sql = "select max([ReportId]) as serverid from [EzeeMarketingDevReport]";
                Serverid = Convert.ToString(cc.ExecuteScalar(Sql));

                returnstring += Serverid.ToString() + "*";
            }

            //string sqlQuery = " INSERT INTO [Come2myCityDB].[come2mycity].[EzeeMarketingDevReports] ([ProjectName],[Status],[Description],[Date],[LoginNumber],[RefMobileNumber]) " +
            //                  " VALUES ('" + projectName + "','" + status + "','" + details + "','" + date + "','" + loginNumber + "','" + refMobileNumber + "')";
            //cc.ExecuteNonQuery(sqlQuery);
            //string sql = "select usrUserId, usrFirstName, usrLastName from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + loginNumber + "'";
            //ds = cc.ExecuteDataset(sql);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    userId = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
            //    fname = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
            //    lname = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);
            //}
            //string SQL = "select [RefMobileNo] from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [keyword]='EZEEMARKETING' and [mobileNo]='" + loginNumber + "'";
            //ds = cc.ExecuteDataset(SQL);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    refmobno = Convert.ToString(ds.Tables[0].Rows[0]["RefMobileNo"]);
            //}
            //string sqlQuery = "INSERT INTO [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt]([usrUserId],[usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrContents],[usrTimeReq],[usrEndDate],[usrAttachment],[usrWorkStatus],[usrSpecificwork],[usrSubject],[usrCurrentDate],[RefMobileNo])" +
            //                  "VALUES('" + userId + "','" + fname + "','" + lname + "','" + projectName + "','" + EntryType + "','" + Content + "','" + TimeReq + "','" + EndDate + "','E:\\HostingSpaces\\myct\\myct.in\\wwwroot\\MarketingAdmin\\NewsFiles\','" + status + "','" + details + "','" + Subject + "','" + System.DateTime.Now + "','" + refmobno + "')";
            //cc.ExecuteNonQuery(sqlQuery);
            //return "106";
        }
        catch
        {
            return "106";
        }
        return "105*" + returnstring.ToString();
    }

    [WebMethod]
    public string InsertData(string Keyword, string BString, string appMobNo, string adminMobNo)
    {
        if (BString != "" && Keyword != null)
        {
            try
            {
                if (Keyword.Equals("ITEM"))
                {
                    return AddItem(BString, appMobNo, adminMobNo);
                }
                else if (Keyword.Equals("CUSTOMER"))
                {
                    return CustAdd(BString, appMobNo, adminMobNo);
                }
                //else if (Keyword.Equals("EXPENDITURE"))
                //{
                //    return ExpEntries(BString, usereNumber);
                //}
                //else if (Keyword.Equals("ISSUELOAN"))
                //{
                //    return IssueLoan(BString, usereNumber);
                //}
                //else if (Keyword.Equals("RECEIVEDEPOSITE"))
                //{
                //    return ReceiveDeposite(BString, usereNumber);
                //}
                //else if (Keyword.Equals("INSTALMENT"))
                //{
                //    return SubInstalment(BString, usereNumber);
                //}
                //else if (Keyword.Equals("SETTING"))
                //{
                //    return Setting(BString, usereNumber);
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

    private string AddItem(string Bstring, string appMobNo, string adminMobNo)
    {
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 9)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@ItemName", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@GroupID", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Latitude", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Langitude", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrmobileNo", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RefMobileNo", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@IemiNo", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Appmobno", appMobNo));
                cmd.Parameters.Add(new SqlParameter("@adminmobno", adminMobNo));

                cmd.CommandText = "uspInsertEzeeMarketingAddItem";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(ItemId) from [Come2myCityDB].[dbo].[EzeeMarketingAddItem] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                //SqlParameter[] par = new SqlParameter[]
                //{
                //    new SqlParameter("@GID",stringArray[i]),
                //    new SqlParameter("@GatName", stringArray[i + 1].ToString()),
                //    new SqlParameter("@MobileNo", stringArray[i + 2].ToString()),
                //    new SqlParameter("@EntryDate", stringArray[i + 3].ToString()),

                //};

                //string str1 = "update [Come2myCityDB].[dbo].[tbl_BCreateGat] set [GatName]='" + stringArray[i + 1].ToString() + "',[MobileNo]='" + stringArray[i + 2].ToString() + "',[EntryDate]='" + stringArray[i + 3].ToString() + "' where GID='" + stringArray[i] + "' ";
                //result = cc.ExecuteNonQuery(str1);
                //string str = "select GID from [Come2myCityDB].[dbo].[tbl_BCreateGat] where GID='" + stringArray[i] + "'";
                //string str7 = cc.ExecuteScalar(str);
                //nonInsertedValues1 += str7 + "*";
            }
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;



        if (string.IsNullOrEmpty(nonInsertedValues) || nonInsertedValues.ToString() == "NULL" || nonInsertedValues.ToString() == "")
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    private string CustAdd(string Bstring, string appMobNo, string adminMobNo)
    {
        string nonInsertedValues = string.Empty;
        try
        {
            string[] stringArray = Bstring.Split(new char[] { '#', '*' });

            string nonInsertedValues1 = string.Empty;
            int result;

            for (int i = 1; i < stringArray.Length; i += 15)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

                if (stringArray[i] == "0")
                {
                    cmd.Parameters.Add(new SqlParameter("@Cust_mobile", stringArray[i + 1].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", stringArray[i + 2].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@LastName", stringArray[i + 3].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@FirmName", stringArray[i + 4].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Type", stringArray[i + 5].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@EmaiIdl", stringArray[i + 6].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Latitude", stringArray[i + 7].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Langitude", stringArray[i + 8].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@UsrmobileNo", stringArray[i + 9].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@RefMobileNo", stringArray[i + 10].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@stateid", stringArray[i + 11].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@districtid", stringArray[i + 12].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@talukaid", stringArray[i + 13].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Appmobno", appMobNo));
                    cmd.Parameters.Add(new SqlParameter("@adminMobno", adminMobNo));

                    cmd.CommandText = "uspInsertEzeeMarketingCustDetails";
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    result = cmd.ExecuteNonQuery();

                    //string str = "select max(CId) from [Come2myCityDB].[dbo].[EzeeMarketingCustDetails] ";  //[uspInsertEzeeMarketingCustDetails]
                    //string str1 = cc.ExecuteScalar(str);

                    // nonInsertedValues1 += str1 + "*";

                }
            }
            return "105";
        }
        catch
        {
            return "0";
        }
    }

    private string History(string Bstring)
    {
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 10)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@Name", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MobileNo", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@callType", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Duration", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DateTime", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrmobileNo", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RefMobileNo", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@IemiNo", stringArray[i + 8].ToString()));

                cmd.CommandText = "uspInsertEzeeMarketingCustDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(Id) from [Come2myCityDB].[dbo].[EzeeMarketingHistory] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                //SqlParameter[] par = new SqlParameter[]
                //{
                //    new SqlParameter("@GID",stringArray[i]),
                //    new SqlParameter("@GatName", stringArray[i + 1].ToString()),
                //    new SqlParameter("@MobileNo", stringArray[i + 2].ToString()),
                //    new SqlParameter("@EntryDate", stringArray[i + 3].ToString()),

                //};

                //string str1 = "update [Come2myCityDB].[dbo].[tbl_BCreateGat] set [GatName]='" + stringArray[i + 1].ToString() + "',[MobileNo]='" + stringArray[i + 2].ToString() + "',[EntryDate]='" + stringArray[i + 3].ToString() + "' where GID='" + stringArray[i] + "' ";
                //result = cc.ExecuteNonQuery(str1);
                //string str = "select GID from [Come2myCityDB].[dbo].[tbl_BCreateGat] where GID='" + stringArray[i] + "'";
                //string str7 = cc.ExecuteScalar(str);
                //nonInsertedValues1 += str7 + "*";
            }
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;



        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    private string Report(string Bstring)
    {
        string[] stringArray = Bstring.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 10)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@Name", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MobileNo", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@callType", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Duration", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DateTime", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrmobileNo", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RefMobileNo", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@IemiNo", stringArray[i + 8].ToString()));

                cmd.CommandText = "uspInsertEzeeMarketingCustDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(Id) from [Come2myCityDB].[dbo].[EzeeMarketingHistory] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                //SqlParameter[] par = new SqlParameter[]
                //{
                //    new SqlParameter("@GID",stringArray[i]),
                //    new SqlParameter("@GatName", stringArray[i + 1].ToString()),
                //    new SqlParameter("@MobileNo", stringArray[i + 2].ToString()),
                //    new SqlParameter("@EntryDate", stringArray[i + 3].ToString()),

                //};

                //string str1 = "update [Come2myCityDB].[dbo].[tbl_BCreateGat] set [GatName]='" + stringArray[i + 1].ToString() + "',[MobileNo]='" + stringArray[i + 2].ToString() + "',[EntryDate]='" + stringArray[i + 3].ToString() + "' where GID='" + stringArray[i] + "' ";
                //result = cc.ExecuteNonQuery(str1);
                //string str = "select GID from [Come2myCityDB].[dbo].[tbl_BCreateGat] where GID='" + stringArray[i] + "'";
                //string str7 = cc.ExecuteScalar(str);
                //nonInsertedValues1 += str7 + "*";
            }
            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //if (result != 1)
                //{
                //    i--;
                //    nonInsertedValues += stringArray[i].ToString() + "*";
                //    i++;
                //}

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                    result = cmd.ExecuteNonQuery();

                    //if (result != 1)
                    //{
                    //    i--;
                    //    nonInsertedValues += stringArray[i].ToString() + "*";
                    //    i++;
                    //}
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;



        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    #endregion

    #region DOWNLOAD DEVELOPER REPORT

    //[WebMethod(Description = "Marketing Download Developer Report Details")]
    //public string DownloadDevReport(string refMobNo)
    //{
    //    DataSet ds = new DataSet();
    //    string returnstring = string.Empty;

    //    try
    //    {
    //        string sql = "SELECT [usrFName],[usrLName],[usrPrjName],[usrEntryType],[usrSubject],[usrContents],[usrTimeReq],[usrEndDate],[usrSpecificwork],[usrAttachment],[usrWorkStatus],[usrCurrentDate]" +
    //                     "FROM [Come2myCityDB].[come2mycity].[tblEmpDaily_rpt] WHERE [RefMobileNo]='" + refMobNo + "'";
    //        ds = cc.ExecuteDataset(sql);

    //        for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
    //        {
    //            for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
    //            {
    //                returnstring += "*" + ds.Tables[0].Rows[r][c].ToString();
    //            }
    //        }
    //        returnstring += "#";
    //    }
    //    catch
    //    {
    //        return "0";
    //    }
    //    return returnstring;
    //}

    [WebMethod(Description = "Marketing Download Developer Report Details")]
    public string DownloadDevReports(string admoinmobno, string role, string custMobno, string projectid)
    {
        DataSet ds = new DataSet();
        string returnstring = string.Empty;
        string sql = string.Empty;
        try
        {
            if (admoinmobno != "" && role == "" && custMobno == "" && projectid == "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                        "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' "; //and [EmployeeMobNo]='" + custMobno + "' and ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role != "" && custMobno == "" && projectid == "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                      "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' and  [ProjectDate]='"+ role +"' "; //[EmployeeMobNo]='" + custMobno + "' and ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role != "" && custMobno != "" && projectid == "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                      "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [EmployeeMobNo]='" + custMobno + "' and [ProjectDate]='"+ role +"' "; // ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role == "" && custMobno != "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                      "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [EmployeeMobNo]='" + custMobno + "' and ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role != "" && custMobno == "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                      "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [ProjectDate]='" + role + "' and ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role == "" && custMobno != "" && projectid == "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                      "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [EmployeeMobNo]='" + custMobno + "'"; //and [ProjectDate]='" + role + "' "; // ProjectId='" + projectid + "'";
            }

            else if (admoinmobno != "" && role == "" && custMobno == "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                      "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' and ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role != "" && custMobno != "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[CustName]" +
                      "FROM [EzeeMarketingDevReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [EmployeeMobNo]='" + custMobno + "' and ProjectId='" + projectid + "' and [ProjectDate]='" + role + "' "; 
            }

            ds = cc.ExecuteDataset(sql);

            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                returnstring += ds.Tables[0].Rows[r]["ProjectId"].ToString() + "*" + ds.Tables[0].Rows[r]["EmployeeMobNo"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectStatus"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectDetails"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectContents"].ToString() + "*"
                                + ds.Tables[0].Rows[r]["ProjectTime"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectDate"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectQuantity"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectWork"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectImage"].ToString() + "*"
                                + ds.Tables[0].Rows[r]["ParentId"].ToString() + "*" + ds.Tables[0].Rows[r]["AdminMobNo"].ToString() + "*" + ds.Tables[0].Rows[r]["ReportId"].ToString() + "*" + ds.Tables[0].Rows[r]["CustName"].ToString() + "#";
            }
        }
        catch
        {
            return "0";
        }
        return returnstring;
    }

    #endregion

    #region ALL WEB METHOD OF EZEEMARKETING

    [WebMethod(Description = "Upload customer data")]  // not use in EzeeMarketing App
    public string AddCustDetails(string Adm_number, string Usr_Mobile, string Cust_Mobile, string F_name, string L_name, string Firm_Name, string Type, string Email)
    {
        int res = 0;
        try
        {
            string sql = "insert into [EzeeMarketingCustdetails] (Usr_mobile,Cust_mobile,F_name,L_name,Firm_name,C_Type,email,Adm_mobile) values ('" + Usr_Mobile + "','" + Cust_Mobile + "','" + F_name + "','" + L_name + "','" + Firm_Name + "','" + Type + "','" + Email + "','" + Adm_number + "')";
            res = cc.ExecuteNonQuery(sql);
        }
        catch { }

        if (res != null)
        {
            return "1";
        }
        else
        {
            return "0";
        }

    }

    [WebMethod]            //Not use in EzeeMarketing App
    public string AddFeedBack(string Adm_number, string usr_mobileNo, string Cust_mobileNo, string Feedback, string points, string Reminder_date)
    {
        int res = 0;
        try
        {
            string sql1 = "insert into EzeeMarketing_FeedBack ([Usr_mobile],[Cust_mobile],[FeedBack_Desc],[Points],[ReminderDare],[Admin_Num]) values ('" + usr_mobileNo + "','" + Cust_mobileNo + "','" + Feedback + "','" + points + "','" + Reminder_date + "','" + Adm_number + "')";
            res = cc.ExecuteNonQuery(sql1);
        }
        catch { }

        if (res != null)
        {
            return "1";
        }
        else
        {
            return "0";
        }
    }

    [WebMethod(Description = "Upload order details")]
    public string AddOrderDetails(string OrderString, string AppMobNo, string AdminMobNo)
    {
        int res = 0;
        try
        {
            string[] ArryString = OrderString.Split(new char[] { '*', '#' });
            var temp = new List<string>();
            foreach (var s in ArryString)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            ArryString = temp.ToArray();
            for (int i = 0; i < ArryString.Length; i += 3)
            {
                string sql1 = "insert into [EzeemarketingAddOrder]([Cust_Id],[ItemId],[Quantity],[CreatedDate],[AppMobileNo],[AdminMobNo]) values (" + ArryString[i] + "," + ArryString[i + 1] + ",'" + ArryString[i + 2].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppMobNo + "','" + AdminMobNo + "')";
                res = cc.ExecuteNonQuery(sql1);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Upload customer report details")]   /// FeedBack Report Details
    public string AddCustomerReport(string CustReport, string AppMobNo, string AdminMobNo)
    {
        int res = 0;
        try
        {
            string[] arryString = CustReport.Split(new char[] { '*', '#' });
            var temp = new List<string>();
            foreach (var s in arryString)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            arryString = temp.ToArray();
            for (int i = 0; i < arryString.Length; i += 5)
            {
                string sql1 = "insert into EzeemarketingCustomerDetails([Cust_Id],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time],[CreatedDate],[AppMobileNo],[AdminMobNo]) values ('" + arryString[i] + "','" + arryString[i + 1].ToString() + "','" + arryString[i + 2].ToString() + "','" + arryString[i + 3].ToString() + "','" + arryString[i + 4].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppMobNo + "','" + AdminMobNo + "')";
                res = cc.ExecuteNonQuery(sql1);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Add Admin Details..")]
    public string AddAdmin(string DataString, string AppMobNo)
    {
        int result = 0;
        try
        {
            string[] ArryString = DataString.Split(new char[] { '*', '#' });
            var temp = new List<string>();
            foreach (var s in ArryString)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            ArryString = temp.ToArray();

            for (int i = 0; i < ArryString.Length; i += 5)
            {
                string sql = "insert into [Come2myCityDB].[dbo].[EzeeMarketingAddAdmin]([Cust_Id],[Custmor_MobNo],[FirstName],[LastName],[Desigation],[CreatedBy],[CreatedDate],[AppMobileNo]) values('" + ArryString[i] + "','" + ArryString[i + 1].ToString() + "','" + Convert.ToString(ArryString[i + 2]) + "','" + Convert.ToString(ArryString[i + 3]) + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i + 1].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppMobNo + "')";
                result = cc.ExecuteNonQuery(sql);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Add Call Log Details..")]
    public string AddCallLog(string CallLogString, string AppMobNo, string AdminMobNo)
    {
        int result = 0;
        try
        {
            string[] ArryString = CallLogString.Split(new char[] { '*', '#' });
            var temp = new List<string>();
            foreach (var S in ArryString)
            {
                if (!string.IsNullOrEmpty(S))
                    temp.Add(S);
            }
            ArryString = temp.ToArray();
            for (int i = 0; i < ArryString.Length; i += 5)
            {
                string sql = "insert into [Come2myCityDB].[dbo].[EzeeMarketingHistory]([Name],[MobileNo],[callType],[Duration],[CurrentDate],[CreatedBy],[AppMobileNO],[AdminMobNo],[CreatedDate]) values('" + ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + AppMobNo + "','" + AppMobNo + "','" + AdminMobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";  //ArryString[i + 1].ToString()
                result = cc.ExecuteNonQuery(sql);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Add Reference Customer Data")]
    public string AddReferenceCustomerData(string DataString, string appMobNo)
    {
        int res = 0;
        string Serverid = string.Empty;
        string rtnServerid = string.Empty;
        try
        {
            string[] ArryStry = DataString.Split(new char[] { '*', '#' });
            var temp = new List<string>();
            foreach (var s in ArryStry)
            {
                if (!string.IsNullOrEmpty(s))
                    temp.Add(s);
            }
            ArryStry = temp.ToArray();
            for (int i = 0; i < ArryStry.Length; i++)
            {
                string sql = "insert into [EzeeMarketingReferenceCustomer]([MobileNo],[AppMobNo],[CreatedBy],[CreatedDate])" +
                              "values('" + ArryStry[i].ToString() + "','" + appMobNo + "','" + appMobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                res = cc.ExecuteNonQuery(sql);

                string Sql = "select max([CustId]) as serverid from [EzeeMarketingReferenceCustomer]";
                Serverid = Convert.ToString(cc.ExecuteScalar(Sql));

                rtnServerid += Serverid + "*";
            }
        }
        catch
        {
            return "0";
        }
        return "105*" + rtnServerid + "";
    }

    [WebMethod(Description = "Add Emp Permission Under Admin Details..")]
    public string InsertAddEmpPermission(string CallLogString, string AppMobNo)
    {
        int result = 0;
        try
        {
            string[] ArryString = CallLogString.Split(new char[] { '*', '#' });
            var temp = new List<string>();
            foreach (var S in ArryString)
            {
                if (!string.IsNullOrEmpty(S))
                    temp.Add(S);
            }
            ArryString = temp.ToArray();
            for (int i = 0; i < ArryString.Length; i += 8)
            {
                string sql = "insert into [Come2myCityDB].[dbo].[EzeeMarketing_AddEmpPermission]([EmpMobNo],[EmpCategory],[Permission],[StartTime],[EndTime],[WorkingDays],[AppMobNo],[CreatedBy],[CreatedDate],[FirstName],[LastName]) values('" + 
                    ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','"+ArryString[i + 5].ToString()+"','" + 
                    AppMobNo + "','" + AppMobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + ArryString[i + 6].ToString() + "','" + ArryString[i + 7].ToString() + "')"; //,[EndTime] ,'" + ArryString[i + 3].ToString() + "'
                result = cc.ExecuteNonQuery(sql);                                
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }


    [WebMethod(Description = "EzeeMarketing Add hierarchya")]
    public string AddHierarchy(string StrData)
    {
        string usrmobNo = string.Empty; string jrMobno = string.Empty;
        string jrName = string.Empty; string type = string.Empty;
        string role = string.Empty; string active = string.Empty;
        string MaxId = string.Empty; string returnString = string.Empty;
        string districtid = string.Empty; string blockid = string.Empty;
        try
        {
            XmlReader reader = XmlReader.Create(new StringReader(StrData));
            ds.ReadXml(reader);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                usrmobNo = ds.Tables[0].Rows[i]["UserMobileNumber"].ToString();
                jrMobno = ds.Tables[0].Rows[i]["JuniorMobNo"].ToString();
                jrName = ds.Tables[0].Rows[i]["JuniorMobName"].ToString();
                type = ds.Tables[0].Rows[i]["Type"].ToString();
                role = ds.Tables[0].Rows[i]["Role"].ToString();
                active = ds.Tables[0].Rows[i]["Active"].ToString();
                districtid = ds.Tables[0].Rows[i]["Districtid"].ToString();
                blockid = ds.Tables[0].Rows[i]["Blockid"].ToString();

                Sql = "update [EzeeMarketingHierarchy] set [JuniorMobNo]='" + jrMobno + "',[JuniorName]='" + jrName + "',[Role]='" + role + "',[Type]='" + type + "',[IsActive]='" + active + "',[DistrictId]='" + districtid + "',[BlockId]='" + blockid + "'" +
                      ",[ModifyBy]='" + usrmobNo + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' where [usrMobileNo]='" + usrmobNo + "' and [JuniorMobNo]='" + jrMobno + "'";
                cc.ExecuteNonQuery(Sql);

                string sqlMaxId = "SELECT MAX(Id) FROM [EzeeMarketingHierarchy](NOLOCK) where [usrMobileNo]='" + usrmobNo + "' and [JuniorMobNo]='" + jrMobno + "'";
                MaxId = cc.ExecuteScalar(sqlMaxId);

                if (MaxId == "")
                {
                    Sql = "Insert into [EzeeMarketingHierarchy]([JuniorMobNo],[JuniorName],[usrMobileNo],[Role],[Type],[IsActive],[CreatedDate],[DistrictId],[BlockId])" +
                     "Values('" + jrMobno + "','" + jrName + "','" + usrmobNo + "','" + role + "','" + type + "','" + active + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + districtid + "','" + blockid + "')";
                    cc.ExecuteNonQuery(Sql);

                    sqlMaxId = "SELECT MAX(Id) FROM [EzeeMarketingHierarchy](NOLOCK)";
                    MaxId = cc.ExecuteScalar(sqlMaxId);
                }
                returnString += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + MaxId + "#";
            }
        }
        catch
        {
            returnString += "0*";
        }
        return returnString;
    }

    [WebMethod(Description = "EzeeMarketing Update hierarchya")]
    public string UpdateHierarchy(string StrData)
    {
        string serverid = string.Empty; string usrmobNo = string.Empty;
        string active = string.Empty;
        string MaxId = string.Empty; string returnString = string.Empty;
        try
        {
            XmlReader reader = XmlReader.Create(new StringReader(StrData));
            ds.ReadXml(reader);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                serverid = ds.Tables[0].Rows[i]["ServerId"].ToString();
                active = ds.Tables[0].Rows[i]["Active"].ToString();
                usrmobNo = ds.Tables[0].Rows[i]["AppUserMobNo"].ToString();

                Sql = "update [EzeeMarketingHierarchy] set [IsActive]='" + active + "'" +
                      ",[ModifyBy]='" + usrmobNo + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' where [Id]='" + serverid + "'";
                cc.ExecuteNonQuery(Sql);

                string sqlMaxId = "SELECT MAX(Id) FROM [EzeeMarketingHierarchy](NOLOCK) where [Id]='" + serverid + "'";
                MaxId = cc.ExecuteScalar(sqlMaxId);

                returnString += "*" + MaxId;
            }
        }
        catch
        {
            returnString += "0*";
        }
        returnString = returnString.Substring(1);
        return returnString;
    }

    #endregion

    #region ALL WEB METHOD TO DOWNLOAD EZEEMARKETING

    [WebMethod(Description = "Add Admin Data details")]
    public string DownloadAdminData(string AppMobNo)
    {
        string cust_Mobno = string.Empty; string F_name = string.Empty;
        string L_name = string.Empty; string desigation = string.Empty;
        try
        {
            string sql = "select [Custmor_MobNo],[FirstName],[LastName],[Desigation] from [EzeeMarketingAddAdmin] where [AppMobileNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    cust_Mobno = Convert.ToString(ds.Tables[0].Rows[r]["Custmor_MobNo"]);
                    F_name = Convert.ToString(ds.Tables[0].Rows[r]["FirstName"]);
                    L_name = Convert.ToString(ds.Tables[0].Rows[r]["LastName"]);
                    desigation = Convert.ToString(ds.Tables[0].Rows[r]["Desigation"]);

                    returnstring += cust_Mobno + "*" + F_name + "*" + L_name + "*" + desigation + "#";
                }
                //returnstring += "#";
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {
            return "0";
        }
        return returnstring;
    }

    [WebMethod(Description = "call Log Data details")]
    public string DownloadCallLog(string AppMobNo)
    {
        string Name = string.Empty; string MobileNo = string.Empty;
        string callType = string.Empty; string Duration = string.Empty;
        string Curnt_date = string.Empty;
        try
        {
            string sql = "select [Name],[MobileNo],[callType],[Duration],[CurrentDate] from [EzeeMarketingHistory] where [AppMobileNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {

                    Name = Convert.ToString(ds.Tables[0].Rows[r]["Name"]);
                    MobileNo = Convert.ToString(ds.Tables[0].Rows[r]["MobileNo"]);
                    callType = Convert.ToString(ds.Tables[0].Rows[r]["callType"]);
                    Duration = Convert.ToString(ds.Tables[0].Rows[r]["Duration"]);
                    Curnt_date = Convert.ToString(ds.Tables[0].Rows[r]["CurrentDate"]);

                    //for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                    //{
                    //    returnstring += "*" + ds.Tables[0].Rows[r][c].ToString();
                    //}
                    returnstring += Name + "*" + MobileNo + "*" + callType + "*" + Duration + "*" + Curnt_date + "#";
                }
                // returnstring += "#";
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {
            return "0";
        }
        return returnstring;
    }

    [WebMethod(Description = "Order Data details")]
    public string DownloadOrderData(string AppMobNo)
    {
        string Cust_Id = string.Empty; string ItemId = string.Empty;
        string Quantity = string.Empty;
        try
        {
            string sql = "select [Cust_Id],[ItemId],[Quantity] from [EzeemarketingAddOrder] where [AppMobileNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    Cust_Id = Convert.ToString(ds.Tables[0].Rows[r]["Cust_Id"]);
                    ItemId = Convert.ToString(ds.Tables[0].Rows[r]["ItemId"]);
                    Quantity = Convert.ToString(ds.Tables[0].Rows[r]["quantity"]);

                    returnstring += Cust_Id + "*" + ItemId + "*" + Quantity + "#";
                }
                //returnstring += "#";
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {
            return "0";
        }
        return returnstring;
    }

    [WebMethod(Description = "Customer Data Details")]
    public string DownloadCustData(string AppMobNo, string category, string stateid, string districtid, string talukaid, string adminNo, string type)
    {
        string Cust_mobile = string.Empty; string FirstName = string.Empty;
        string LastName = string.Empty; string FirmName = string.Empty;
        string Type = string.Empty; string EmaiIdl = string.Empty;
        string latitude = string.Empty; string langitude = string.Empty;
        string usrmobno = string.Empty; string refmobno = string.Empty;
        string sql = string.Empty;
        try
        {
            if (category == "ALL")
            {
                sql = "select [Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiIdl],[Latitude],[Langitude],[UsrmobileNo],[RefMobileNo] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "'"; //[AdminMobNo]

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                //    {
                //        Cust_mobile = Convert.ToString(ds.Tables[0].Rows[r]["Cust_mobile"]);
                //        FirstName = Convert.ToString(ds.Tables[0].Rows[r]["FirstName"]);
                //        LastName = Convert.ToString(ds.Tables[0].Rows[r]["LastName"]);
                //        FirmName = Convert.ToString(ds.Tables[0].Rows[r]["FirmName"]);
                //        Type = Convert.ToString(ds.Tables[0].Rows[r]["Type"]);
                //        EmaiIdl = Convert.ToString(ds.Tables[0].Rows[r]["EmaiIdl"]);
                //        latitude = Convert.ToString(ds.Tables[0].Rows[r]["Latitude"]);
                //        langitude = Convert.ToString(ds.Tables[0].Rows[r]["Langitude"]);
                //        usrmobno = Convert.ToString(ds.Tables[0].Rows[r]["UsrmobileNo"]);
                //        refmobno = Convert.ToString(ds.Tables[0].Rows[r]["RefMobileNo"]);

                //        returnstring += Cust_mobile + "*" + FirstName + "*" + LastName + "*" + FirmName + "*" + Type + "*" + EmaiIdl + "*" + latitude + "*" + langitude + "*" + usrmobno + "*" + refmobno + "#";
                //    }
                //}
                //else
                //{
                //    return "NoRecord";
                //}
            }
            else
            {
                if (adminNo != "" && stateid != "" && districtid == "" && talukaid == "" && type == "")
                {
                    sql = "select [Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiIdl],[Latitude],[Langitude],[UsrmobileNo],[RefMobileNo] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "'";
                }
                else if (adminNo != "" && stateid != "" && districtid != "" && talukaid == "" && type == "")
                {
                    sql = "select [Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiIdl],[Latitude],[Langitude],[UsrmobileNo],[RefMobileNo] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "' and [DistrictId]='" + districtid + "'";
                }
                else if (adminNo != "" && stateid != "" && districtid != "" && talukaid != "" && type == "")
                {
                    sql = "select [Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiIdl],[Latitude],[Langitude],[UsrmobileNo],[RefMobileNo] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "' and [DistrictId]='" + districtid + "' and [TalukaId]='" + talukaid + "'";
                }
                else if (adminNo != "" && stateid != "" && districtid != "" && talukaid != "" && type != "")
                {
                    sql = "select [Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiIdl],[Latitude],[Langitude],[UsrmobileNo],[RefMobileNo] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "' and [DistrictId]='" + districtid + "' and [TalukaId]='" + talukaid + "' and [Type]='" + type + "'";
                }
            }

            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    Cust_mobile = Convert.ToString(ds.Tables[0].Rows[r]["Cust_mobile"]);
                    FirstName = Convert.ToString(ds.Tables[0].Rows[r]["FirstName"]);
                    LastName = Convert.ToString(ds.Tables[0].Rows[r]["LastName"]);
                    FirmName = Convert.ToString(ds.Tables[0].Rows[r]["FirmName"]);
                    Type = Convert.ToString(ds.Tables[0].Rows[r]["Type"]);
                    EmaiIdl = Convert.ToString(ds.Tables[0].Rows[r]["EmaiIdl"]);
                    latitude = Convert.ToString(ds.Tables[0].Rows[r]["Latitude"]);
                    langitude = Convert.ToString(ds.Tables[0].Rows[r]["Langitude"]);
                    usrmobno = Convert.ToString(ds.Tables[0].Rows[r]["UsrmobileNo"]);
                    refmobno = Convert.ToString(ds.Tables[0].Rows[r]["RefMobileNo"]);

                    returnstring += Cust_mobile + "*" + FirstName + "*" + LastName + "*" + FirmName + "*" + Type + "*" + EmaiIdl + "*" + latitude + "*" + langitude + "*" + usrmobno + "*" + refmobno + "#";
                }
            }
            else
            {
                return "NoRecord";
            }

        }
        catch
        {
            return "Error";
        }
        return returnstring;
    }

    [WebMethod(Description = "Item Data Details")]
    public string DownloadAddItem(string adminmobno)
    {
        string ItemName = string.Empty; string GroupID = string.Empty;
        string itemid = string.Empty;
        try
        {
            string sql = "select [ItemId],[ItemName],[GroupID] from [EzeeMarketingAddItem] where [AdminMobNo]='" + adminmobno + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    itemid = Convert.ToString(ds.Tables[0].Rows[r]["ItemId"]);
                    ItemName = Convert.ToString(ds.Tables[0].Rows[r]["ItemName"]);
                    GroupID = Convert.ToString(ds.Tables[0].Rows[r]["GroupID"]);

                    returnstring += itemid + "*" + ItemName + "*" + GroupID + "#";
                }
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {

        }
        return returnstring;
    }

    [WebMethod(Description = "Download Customer mobile no")]
    public string DownloadCustomerMobNo(string AppMobNo)
    {
        string custid = string.Empty; string custmobno = string.Empty;
        try
        {
            string sql = "select [CustId],[MobileNo] from [EzeeMarketingReferenceCustomer] where [AppMobNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    custid = Convert.ToString(ds.Tables[0].Rows[r]["CustId"]);
                    custmobno = Convert.ToString(ds.Tables[0].Rows[r]["MobileNo"]);

                    returnstring += custid + "*" + custmobno + "#";
                }
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {

        }
        return returnstring;
    }

    [WebMethod(Description = "Download FeedBack data")]
    public string DownloadCustFeedBack(string AppMobNo)
    {
        string custid = string.Empty;
        string feedbckdescription = string.Empty; string feedbckpoint = string.Empty;
        string rmddate = string.Empty; string rmdtime = string.Empty;
        try
        {
            string sql = "select [Cust_Id],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time] from [EzeemarketingCustomerDetails] where [AppMobileNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    custid = Convert.ToString(ds.Tables[0].Rows[r]["Cust_Id"]);
                    feedbckdescription = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Description"]);
                    feedbckpoint = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Point"]);
                    rmddate = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Date"]);
                    rmdtime = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Time"]);

                    returnstring += custid + "*" + feedbckdescription + "*" + feedbckpoint + "*" + rmddate + "*" + rmdtime + "#";
                }
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {

        }
        return returnstring;
    }

    [WebMethod(Description = "Admin Order Data details")]
    public string DownloadAdminOrderData(string AppMobNo, string Date)
    {
        string ItemName = string.Empty; string ItemId = string.Empty;
        string Custid = string.Empty; string custMobno = string.Empty;
        string qunty = string.Empty;
        try
        {
            string sql = "select [Cust_Id],[ItemId],[Quantity] from [EzeemarketingAddOrder] where [AppMobileNo]='" + AppMobNo.Substring(2).Trim() + "' and [CreatedDate]='" + Date + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    string stry = "select [ItemId],[ItemName] from [EzeeMarketingAddItem] where [ItemId]=" + ds.Tables[0].Rows[r][1].ToString() + "";
                    DataSet DS = cc.ExecuteDataset(stry);

                    string strqry = "select  [CustId],[MobileNo] from [EzeeMarketingReferenceCustomer] where [CustId]=" + ds.Tables[0].Rows[r][0].ToString() + "";
                    DataSet Dtset = cc.ExecuteDataset(strqry);

                    ItemId = Convert.ToString(DS.Tables[0].Rows[0]["ItemId"]);
                    ItemName = Convert.ToString(DS.Tables[0].Rows[0]["ItemName"]);
                    Custid = Convert.ToString(Dtset.Tables[0].Rows[0]["CustId"]);
                    custMobno = Convert.ToString(Dtset.Tables[0].Rows[0]["MobileNo"]);
                    qunty = Convert.ToString(ds.Tables[0].Rows[r]["Quantity"]);

                    returnstring += ItemId + "*" + ItemName + "*" + Custid + "*" + custMobno + "*" + qunty + "#";
                }
                //returnstring += "#";
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {
            return "0";
        }
        return returnstring;
    }

    [WebMethod(Description = "Download Admin FeedBack data")]
    public string DownloadAdminFeedBack(string AppMobNo, string Date)
    {
        string custid = string.Empty;
        string feedbckdescription = string.Empty; string feedbckpoint = string.Empty;
        string rmddate = string.Empty; string rmdtime = string.Empty; string custmobno = string.Empty;
        try
        {
            string sql = "select [Cust_Id],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time] from [EzeemarketingCustomerDetails] where [AppMobileNo]='" + AppMobNo.Substring(2).Trim() + "' and [CreatedDate]='" + Date + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    string strqry = "select [MobileNo] from [EzeeMarketingReferenceCustomer] where [CustId]=" + ds.Tables[0].Rows[r][0].ToString() + "";
                    DataSet Dtset = cc.ExecuteDataset(strqry);

                    custid = Convert.ToString(ds.Tables[0].Rows[r]["Cust_Id"]);
                    custmobno = Convert.ToString(Dtset.Tables[0].Rows[0]["MobileNo"]);
                    feedbckdescription = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Description"]);
                    feedbckpoint = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Point"]);
                    rmddate = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Date"]);
                    rmdtime = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Time"]);

                    returnstring += custid + "*" + custmobno + "*" + feedbckdescription + "*" + feedbckpoint + "*" + rmddate + "*" + rmdtime + "#";
                }
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {

        }
        return returnstring;
    }

    /// <summary>
    /// This method is use for Download under admin data hierarchy..
    /// </summary>
    /// <param name="usrMobno"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    [WebMethod(Description = "Download Ezeemarketing Add hierarchya")]
    public string DownloadHierarchy(string usrMobno, string type)
    {
        try
        {
            if (usrMobno != "" && type != "")
            {
                Sql = "select  [Id],[JuniorMobNo],[JuniorName],[usrMobileNo],[Role],[Type],[IsActive] from [EzeeMarketingHierarchy] where [usrMobileNo]='" + usrMobno + "' and [Type]='" + type + "' ";
            }
            else
            {
                Sql = "select  [Id],[JuniorMobNo],[JuniorName],[usrMobileNo],[Role],[Type],[IsActive] from [EzeeMarketingHierarchy] where [usrMobileNo]='" + usrMobno + "'";
            }
            ds = cc.ExecuteDataset(Sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    returnstring += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + ds.Tables[0].Rows[i]["JuniorMobNo"].ToString() + "*" + ds.Tables[0].Rows[i]["JuniorName"].ToString() + "*" + ds.Tables[0].Rows[i]["usrMobileNo"].ToString()
                                    + "*" + ds.Tables[0].Rows[i]["Role"].ToString() + "*" + ds.Tables[0].Rows[i]["Type"].ToString() + "*" + ds.Tables[0].Rows[i]["IsActive"].ToString() + "#";
                }
            }
            else
            {
                returnstring += "NoRecord";
            }

        }
        catch
        {
            returnstring += "Error";
        }

        return returnstring;
    }

    /// <summary>
    /// This method used for  display all record based on appmobnno and date to Admin 
    /// </summary>
    /// <param name="AppMobNo"></param>
    /// <param name="Date"></param>
    /// <returns></returns>
    [WebMethod(Description = "Download Admin FeedBack data")]
    public string DownloadAdminCallLog(string AppMobNo, string Date)
    {
        string Name = string.Empty;
        string MobileNo = string.Empty; string callType = string.Empty;
        string Duration = string.Empty; string Curnt_date = string.Empty;
        try
        {
            string sql = "select [Name],[MobileNo],[callType],[Duration],[CurrentDate] from [EzeeMarketingHistory] where [AppMobileNo]='" + AppMobNo.Substring(2).Trim() + "' and [CreatedDate]='" + Date + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    Name = Convert.ToString(ds.Tables[0].Rows[r]["Name"]);
                    MobileNo = Convert.ToString(ds.Tables[0].Rows[r]["MobileNo"]);
                    callType = Convert.ToString(ds.Tables[0].Rows[r]["callType"]);
                    Duration = Convert.ToString(ds.Tables[0].Rows[r]["Duration"]);
                    Curnt_date = Convert.ToString(ds.Tables[0].Rows[r]["CurrentDate"]);

                    returnstring += Name + "*" + MobileNo + "*" + callType + "*" + Duration + "*" + Curnt_date + "#";
                }
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {

        }
        return returnstring;
    }

    [WebMethod(Description = "Download Add Emp Permision under Admin data")]
    public string DownloadAddEmpPermission(string AppMobNo)
    {
        string Empmobno = string.Empty;
        string permision = string.Empty; string starttime = string.Empty;
        string intime = string.Empty; string id = string.Empty;
        string wrkingdy = string.Empty; string fName = string.Empty;
        string lName = string.Empty;
        try
        {
            string sql = "select [Id],[EmpMobNo],[Permission],[StartTime],[EndTime],[WorkingDays],[FirstName],[LastName] from [EzeeMarketing_AddEmpPermission] where [AppMobNo]='" + AppMobNo + "'"; //,[EndTime]
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    id = Convert.ToString(ds.Tables[0].Rows[r]["Id"]);
                    Empmobno = Convert.ToString(ds.Tables[0].Rows[r]["EmpMobNo"]);
                    permision = Convert.ToString(ds.Tables[0].Rows[r]["Permission"]);
                    starttime = Convert.ToString(ds.Tables[0].Rows[r]["StartTime"]);
                    // endtime = Convert.ToString(ds.Tables[0].Rows[r]["EndTime"]);
                    intime = Convert.ToString(ds.Tables[0].Rows[r]["EndTime"]);
                    wrkingdy = Convert.ToString(ds.Tables[0].Rows[r]["WorkingDays"]);
                    fName = Convert.ToString(ds.Tables[0].Rows[r]["FirstName"]);
                    lName = Convert.ToString(ds.Tables[0].Rows[r]["LastName"]);
                    returnstring += id + "*" + Empmobno + "*" + permision + "*" + starttime + "*" + intime + "*" + wrkingdy + "*" + fName + "*" + lName + "#"; // + endtime + "*"
                }
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {

        }
        return returnstring;
    }

    #endregion

    //////////////////////By ram created for EzeeClass App //////////
    #region METHOD TO DOWNLOAD FOR CATEGORY IN MYCT
    [WebMethod]
    public XmlDataDocument DownloadInstituteTypeEzeeClass()
    {
        XmlDataDocument xmlData = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            string sql = "SELECT  [categoryId],[categoryName] FROM [Category] WHERE [parentCategoryId]=7 " +
                         "SELECT  [categoryId],[categoryName],[parentCategoryId] FROM [Category] WHERE [parentCategoryId] IN (64,65,66,67,68,69,70,71,72)";
            ds = cc.ExecuteDataset(sql);

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlEle = xmlData.DocumentElement;
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
        }
        return xmlData;
    }

    //[WebMethod]
    //public XmlDataDocument DownloadInstituteSubTypeEzeeClass(string institueTypeId)
    //{
    //    XmlDataDocument xmlData = new XmlDataDocument();
    //    DataSet ds = new DataSet();
    //    try
    //    {
    //        string sql = "SELECT  [categoryId],[categoryName] FROM [Category] WHERE [parentCategoryId]=" + institueTypeId + "";
    //        ds = cc.ExecuteDataset(sql);

    //        xmlData = new XmlDataDocument(ds);
    //        XmlElement xmlEle = xmlData.DocumentElement;
    //    }
    //    catch
    //    {
    //        DataTable dt = new DataTable();
    //        dt.Columns.Add(new DataColumn("Error", typeof(int)));
    //        DataRow dr = dt.NewRow();
    //        dr["Error"] = "105";
    //        dt.Rows.Add(dr);
    //        ds.Tables.Add(dt);
    //        xmlData = new XmlDataDocument(ds);
    //        XmlElement xmlelement = xmlData.DocumentElement;
    //    }
    //    return xmlData;
    //}
    #endregion

    ////////////////True voter Download Representative under district//////////
    [WebMethod]
    public string DownloadRepresenativeDistrictWise(string districtid)
    {
        try
        {
            Sql = "SELECT [Id],[JuniorMobNo],[JuniorName],[usrMobileNo],[Role],[DistrictId],[BlockId] FROM [EzeeMarketingHierarchy] " +
                 "WHERE [DistrictId]='" + districtid + "' AND [Role]='2'";
            ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    returnstring += ds.Tables[0].Rows[i]["Id"].ToString() + "*" + ds.Tables[0].Rows[i]["JuniorMobNo"].ToString() + "*" + ds.Tables[0].Rows[i]["JuniorName"].ToString() + "*" + ds.Tables[0].Rows[i]["usrMobileNo"].ToString()
                                    + "*" + ds.Tables[0].Rows[i]["Role"].ToString() + "*" + ds.Tables[0].Rows[i]["DistrictId"].ToString() + "*" + ds.Tables[0].Rows[i]["BlockId"].ToString() + "#";
                }
            }
            else
            {
                returnstring += "0*";
            }
        }
        catch
        {
            returnstring += "Error";
        }
        return returnstring;
    }

}
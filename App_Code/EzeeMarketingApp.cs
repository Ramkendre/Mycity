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
using System.Web.Script.Services;
using System.Web.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;

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
    JavaScriptSerializer js = new JavaScriptSerializer();

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
                //string sql = "insert into [EzeeMarketingWorkReport]([ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[CreatedDate],[Imei],[EmployeeName],[CurentStatus],[CurentStatusby],[CurentStatusDate],[CurentStatusRemark])" +
                //             "VALUES('" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i + 5].ToString() + "','" + ArryString[i + 6].ToString() + "','" + ArryString[i + 7].ToString() + "','" + ArryString[i + 8].ToString() + "','" + ArryString[i + 9].ToString() + "','NULL','" + ArryString[i + 10].ToString() + "','" + ArryString[i + 11].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','0','" + ArryString[i + 12].ToString() + "'"+
                //               ",'" + ArryString[i + 13].ToString() + "','" + ArryString[i + 14].ToString() + "','" + ArryString[i + 15].ToString() + "','" + ArryString[i + 16].ToString() + "')";

                string sql = "insert into [EzeeMarketingWorkReport]([ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[CreatedDate],[Imei],[EmployeeName],[CurentStatus],[CurentStatusby],[CurentStatusDate],[CurentStatusRemark])" +
                             " VALUES('" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i + 5].ToString() + "','" + ArryString[i + 6].ToString() + "','" + ArryString[i + 7].ToString() + "','" + ArryString[i + 8].ToString() + "','" + ArryString[i + 9].ToString() + "','NULL','" + ArryString[i + 10].ToString() + "','" + ArryString[i + 11].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','0','" + ArryString[i + 12].ToString() + "','0','0','0','0')";
                result = cc.ExecuteNonQuery(sql);

                string Sql = "select max([ReportId]) as serverid from [EzeeMarketingWorkReport]";
                Serverid = Convert.ToString(cc.ExecuteScalar(Sql));

                returnstring += Serverid.ToString() + "*";
            }

            //string sqlQuery = " INSERT INTO [Come2myCityDB].[come02mycity].[EzeeMarketingDevReports] ([ProjectName],[Status],[Description],[Date],[LoginNumber],[RefMobileNumber]) " +
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

    [WebMethod(Description = "METHOD TO INSERT DEVELOPER REPORTS")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<EzeeMarketingBAL> JsonUploadDevReports(string DevString)
    {
        string data = string.Empty;

        List<EzeeMarketingBAL> listworkreport = new List<EzeeMarketingBAL>();
        try
        {
            var objListWorkReport = JsonConvert.DeserializeObject<List<EzeeMarketingBAL>>(DevString);

            using (var connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                foreach (var item in objListWorkReport)
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "uspWorkreport";
                        cmd.Connection = connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@projectid", item.ProjectId);
                        cmd.Parameters.AddWithValue("@usermobno", item.UserMobile);
                        cmd.Parameters.AddWithValue("@projectstatus", item.ProjectStatus);
                        cmd.Parameters.AddWithValue("@projectdetails", item.ProjectDetails);
                        cmd.Parameters.AddWithValue("@projectcontents", item.ProjectContents);
                        cmd.Parameters.AddWithValue("@projecttime", item.ProjectTime);
                        cmd.Parameters.AddWithValue("@projectdate", item.ProjectDate);
                        cmd.Parameters.AddWithValue("@projectquantity", item.ProjectQuantity);
                        cmd.Parameters.AddWithValue("@projectwork", item.ProjectWork);
                        cmd.Parameters.AddWithValue("@projectimage", "0");
                        cmd.Parameters.AddWithValue("@ParentId", item.ParentId);
                        cmd.Parameters.AddWithValue("@adminmobno", item.AdminMobile);
                        cmd.Parameters.AddWithValue("@createddate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@imei", "0");
                        cmd.Parameters.AddWithValue("@employeename", item.EmployeeName);
                        cmd.Parameters.AddWithValue("@curentstatus", "0");
                        cmd.Parameters.AddWithValue("@curentstatusby", "0");
                        cmd.Parameters.AddWithValue("@curentstatusdate", "0");
                        cmd.Parameters.AddWithValue("@curentstatusremark", "0");

                        cmd.Parameters.Add("@returnid", SqlDbType.VarChar, 250);
                        cmd.Parameters["@returnid"].Direction = ParameterDirection.Output;
                        connection.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        listworkreport.Add(new EzeeMarketingBAL()
                        {
                            Id = item.Id,
                            ReturnId = Convert.ToString(cmd.Parameters["@returnid"].Value)
                        });
                    }
                }
            }
        }
        catch
        {
            listworkreport.Add(new EzeeMarketingBAL()
            {
                Id = "0",
                ReturnId = Convert.ToString("106")
            });

            return listworkreport.ToList();
        }
        return listworkreport.ToList();
    }

    public class EzeeMarketingBAL
    {
        private string _projectId;

        public string ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        private string _userMobile;

        public string UserMobile
        {
            get { return _userMobile; }
            set { _userMobile = value; }
        }

        private string _projectStatus;

        public string ProjectStatus
        {
            get { return _projectStatus; }
            set { _projectStatus = value; }
        }

        private string _projectDetails;

        public string ProjectDetails
        {
            get { return _projectDetails; }
            set { _projectDetails = value; }
        }

        private string _projectContents;

        public string ProjectContents
        {
            get { return _projectContents; }
            set { _projectContents = value; }
        }

        private string _projectTime;

        public string ProjectTime
        {
            get { return _projectTime; }
            set { _projectTime = value; }
        }

        private string _projectDate;

        public string ProjectDate
        {
            get { return _projectDate; }
            set { _projectDate = value; }
        }

        private string _projectQuantity;

        public string ProjectQuantity
        {
            get { return _projectQuantity; }
            set { _projectQuantity = value; }
        }

        private string _projectWork;

        public string ProjectWork
        {
            get { return _projectWork; }
            set { _projectWork = value; }
        }

        private string _projectImage;

        public string ProjectImage
        {
            get { return _projectImage; }
            set { _projectImage = value; }
        }

        private string _parentId;

        public string ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }

        private string _adminMobile;

        public string AdminMobile
        {
            get { return _adminMobile; }
            set { _adminMobile = value; }
        }

        private string _createdDate;

        public string CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        private string _imei;

        public string Imei
        {
            get { return _imei; }
            set { _imei = value; }
        }

        private string _employeeName;

        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        private string _curentStatus;

        public string CurentStatus
        {
            get { return _curentStatus; }
            set { _curentStatus = value; }
        }

        private string _curentStatusby;

        public string CurentStatusby
        {
            get { return _curentStatusby; }
            set { _curentStatusby = value; }
        }

        private string _curentStatusDate;

        public string CurentStatusDate
        {
            get { return _curentStatusDate; }
            set { _curentStatusDate = value; }
        }

        private string _curentStatusRemark;

        public string CurentStatusRemark
        {
            get { return _curentStatusRemark; }
            set { _curentStatusRemark = value; }
        }

        private string _returnId;

        public string ReturnId
        {
            get { return _returnId; }
            set { _returnId = value; }
        }

        private string _id;

        public string Id  // App Side Local Id Parameter
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    [WebMethod(Description = "Work Report Updated On WorkReport Server Id")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateDeveloperReport(string workstring)
    {
        string returnstring = string.Empty;
        string Result = string.Empty;
        int I;
        //List<WorkReportData> objListWorkReportData = new List<WorkReportData>();
        WorkReportData objWorkReportData = new WorkReportData();
        List<WorkReport> objListWorkReport = new List<WorkReport>();
        List<WorkReportData> listobj = null;
        try
        {
            List<WorkReportData> objListWorkReportData = new JavaScriptSerializer().Deserialize<List<WorkReportData>>(workstring);

            foreach (WorkReportData items in objListWorkReportData)
            {
                using (SqlConnection connn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    SqlParameter[] par = new SqlParameter[11];
                    par[0] = new SqlParameter("@CurentStatus", items.CurentStatus);
                    par[1] = new SqlParameter("@CurentStatusby", items.CurentStatusby);
                    par[2] = new SqlParameter("@CurentStatusDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                    par[3] = new SqlParameter("@CurentStatusRemark", items.CurentStatusRemark);
                    par[4] = new SqlParameter("@ReportId", items.ReportId);
                    par[5] = new SqlParameter("@returnvalue", SqlDbType.Int);
                    par[5].Direction = ParameterDirection.InputOutput;
                    I = SqlHelper.ExecuteNonQuery(connn, CommandType.StoredProcedure, "UspUpdateWorkReport", par);
                    Result = par[5].Value.ToString();
                    returnstring += items.ReportId + "*";
                }
            }
            return returnstring;
        }
        catch (Exception)
        {
            return returnstring = "105";
        }
    }

    [WebMethod(Description = "UpdateAddItemName on  Server Id")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string UpdateAddItemName(string itemstring)
    {
        StringBuilder sb = new StringBuilder();
        ItemName itemName = new ItemName();
        try
        {
            List<ItemName> listItemName = new JavaScriptSerializer().Deserialize<List<ItemName>>(itemstring);

            foreach (ItemName items in listItemName)
            {
                using (SqlConnection connn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    string sql = "Select [AppMobNo] From [EzeeMarketingAddItem] Where [ItemId]=" + items.ItemId + "";
                    string appmobno = Convert.ToString(cc.ExecuteScalar(sql));

                    string sqlString = "Update [Come2myCityDB].[dbo].[EzeeMarketingAddItem] SET [ItemName]='" + items.itemName + "',[GroupID]='" + items.GroupId + "',[ModifyBy]='" + appmobno + "',[ModifyDate]='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "' WHERE [ItemId]=" + items.ItemId + "";
                    cc.ExecuteNonQuery(sqlString);
                    sb.Append(items.Id + "*");
                    sb.Append(items.ItemId + "#");
                }
            }
            return sb.ToString();
        }
        catch (Exception)
        {
            return sb.Append("105").ToString();
        }
    }

    public class ItemName
    {
        public string ItemId { get; set; }
        public string itemName { get; set; }
        public string GroupId { get; set; }
        public string AdminMobNo { get; set; }
        public string Id { get; set; }
    }

    public class WorkReport
    {
        public WorkReport(string Success, List<WorkReportData> objListWorkReportData)
        {
            this.Status = Success;
            this.Data = objListWorkReportData;
        }
        public string Status { get; set; }
        public List<WorkReportData> Data { get; set; }
    }

    public class WorkReportData
    {
        private string strings;

        public string Strings
        {
            get { return strings; }
            set { strings = value; }
        }

        private string curentStatus;

        public string CurentStatus
        {
            get { return this.curentStatus; }
            set { this.curentStatus = value; }
        }

        private string curentStatusby;

        public string CurentStatusby
        {
            get { return curentStatusby; }
            set { curentStatusby = value; }
        }

        private string curentStatusDate;

        public string CurentStatusDate
        {
            get { return curentStatusDate; }
            set { curentStatusDate = value; }
        }

        private string curentStatusRemark;

        public string CurentStatusRemark
        {
            get { return curentStatusRemark; }
            set { curentStatusRemark = value; }
        }

        private string reportId;

        public string ReportId
        {
            get { return reportId; }
            set { reportId = value; }
        }
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
        for (int i = 1; i < stringArray.Length; i += 4)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@ItemName", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@GroupID", stringArray[i + 2].ToString()));
                // cmd.Parameters.Add(new SqlParameter("@Latitude", stringArray[i + 3].ToString()));
                //cmd.Parameters.Add(new SqlParameter("@Langitude", stringArray[i + 4].ToString()));
                // cmd.Parameters.Add(new SqlParameter("@UsrmobileNo", stringArray[i + 5].ToString()));
                // cmd.Parameters.Add(new SqlParameter("@RefMobileNo", stringArray[i + 6].ToString()));
                // cmd.Parameters.Add(new SqlParameter("@IemiNo", stringArray[i + 7].ToString()));
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

            for (int i = 1; i < stringArray.Length; i += 13)
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
                    cmd.Parameters.Add(new SqlParameter("@EmaiId", stringArray[i + 6].ToString()));
                    // cmd.Parameters.Add(new SqlParameter("@Latitude", stringArray[i + 7].ToString()));
                    // cmd.Parameters.Add(new SqlParameter("@Langitude", stringArray[i + 8].ToString()));
                    // cmd.Parameters.Add(new SqlParameter("@UsrmobileNo", stringArray[i + 9].ToString()));
                    // cmd.Parameters.Add(new SqlParameter("@RefMobileNo", stringArray[i + 10].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@stateid", stringArray[i + 7].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@districtid", stringArray[i + 8].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@talukaid", stringArray[i + 9].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Latitude", stringArray[i + 10].ToString()));
                    cmd.Parameters.Add(new SqlParameter("@Langitude", stringArray[i + 11].ToString()));
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
    public string DownloadDevReports(string admoinmobno, string role, string custMobno, string projectid, string serverid)
    {
        DataSet ds = new DataSet();
        string returnstring = string.Empty;
        string sql = string.Empty; string projworkid = string.Empty;
        try
        {
            if (admoinmobno != "" && role == "" && custMobno == "" && projectid == "")
            {
                sql = "SELECT top 100 [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                        " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and ReportId >" + serverid + ""; //and [EmployeeMobNo]='" + custMobno + "' and ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role != "" && custMobno == "" && projectid == "")
            {
                sql = "SELECT [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                      " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and  [ProjectDate]='" + role + "' and ReportId >" + serverid + ""; //[EmployeeMobNo]='" + custMobno + "' and ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role != "" && custMobno != "" && projectid == "")
            {
                sql = "SELECT [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                      " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [UserMobNo]='" + custMobno + "' and [ProjectDate]='" + role + "' and ReportId >" + serverid + ""; // ProjectId='" + projectid + "'";
            }
            else if (admoinmobno != "" && role == "" && custMobno != "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                      " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [UserMobNo]='" + custMobno + "' and ProjectId='" + projectid + "' and ReportId >" + serverid + "";
            }
            else if (admoinmobno != "" && role != "" && custMobno == "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                      " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [ProjectDate]='" + role + "' and ProjectId='" + projectid + "' and ReportId >" + serverid + "";
            }
            else if (admoinmobno != "" && role == "" && custMobno != "" && projectid == "")
            {
                sql = "SELECT [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                      " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [UserMobNo]='" + custMobno + "' and ReportId >" + serverid + ""; //and [ProjectDate]='" + role + "' "; // ProjectId='" + projectid + "'";
            }

            else if (admoinmobno != "" && role == "" && custMobno == "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                      " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and ProjectId='" + projectid + "' and ReportId >" + serverid + "";
            }
            else if (admoinmobno != "" && role != "" && custMobno != "" && projectid != "")
            {
                sql = "SELECT [ProjectId],[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ProjectImage],[ParentId],[AdminMobNo],[ReportId],[EmployeeName],CurentStatus,CurentStatusby,CurentStatusDate,CurentStatusRemark" +
                      " FROM [EzeeMarketingWorkReport] WHERE [AdminMobNo]='" + admoinmobno + "' and [UserMobNo]='" + custMobno + "' and ProjectId='" + projectid + "' and [ProjectDate]='" + role + "' and ReportId >" + serverid + "";
            }

            ds = cc.ExecuteDataset(sql);

            for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
            {
                string value = ds.Tables[0].Rows[r]["ProjectWork"].ToString();
                // ... Switch on the string.
                switch (value)
                {
                    case "Pending": projworkid = "0";
                        break;
                    case "Continued": projworkid = "1";
                        break;
                    case "Partial": projworkid = "2";
                        break;
                    case "Complete": projworkid = "3";
                        break;
                    case "Proposed": projworkid = "4";
                        break;
                    case "Dissmissed": projworkid = "5";
                        break;
                    case "Cancled": projworkid = "6";
                        break;
                    default:
                        projworkid = ds.Tables[0].Rows[r]["ProjectWork"].ToString();
                        break;
                }

                returnstring += ds.Tables[0].Rows[r]["ProjectId"].ToString() + "*" + ds.Tables[0].Rows[r]["UserMobNo"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectStatus"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectDetails"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectContents"].ToString() + "*"
                                + ds.Tables[0].Rows[r]["ProjectTime"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectDate"].ToString() + "*" + ds.Tables[0].Rows[r]["ProjectQuantity"].ToString() + "*" + projworkid + "*" + 0 + "*"    //ds.Tables[0].Rows[r]["ProjectImage"].ToString()
                                + ds.Tables[0].Rows[r]["ParentId"].ToString() + "*" + ds.Tables[0].Rows[r]["AdminMobNo"].ToString() + "*" + ds.Tables[0].Rows[r]["ReportId"].ToString() + "*" + ds.Tables[0].Rows[r]["EmployeeName"].ToString() + "*" + ds.Tables[0].Rows[r]["CurentStatus"].ToString() + "*" + ds.Tables[0].Rows[r]["CurentStatusby"].ToString() + "*" + ds.Tables[0].Rows[r]["CurentStatusDate"].ToString() + "*" + ds.Tables[0].Rows[r]["CurentStatusRemark"].ToString() + "#";
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
            for (int i = 0; i < ArryString.Length; i += 5)
            {
                string sql1 = "insert into [EzeemarketingAddOrder]([Cust_MobNo],[ItemId],[Quantity],[CreatedDate],[AppMobileNo],[AdminMobNo],[Latitude],[Longitude]) values (" + ArryString[i] + "," + ArryString[i + 1] + ",'" + ArryString[i + 2].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppMobNo + "','" + AdminMobNo + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "')";
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
            //for (int i = 0; i < arryString.Length; i += 5)
            //{
            //    string sql1 = "insert into EzeemarketingCust_Feedback([Cust_MobNo],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time],[CreatedDate],[AppMobileNo],[AdminMobNo]) values ('" + arryString[i] + "','" + arryString[i + 1].ToString() + "','" + arryString[i + 2].ToString() + "','" + arryString[i + 3].ToString() + "','" + arryString[i + 4].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppMobNo + "','" + AdminMobNo + "')";
            //    res = cc.ExecuteNonQuery(sql1);
            //}
            for (int i = 0; i < arryString.Length; i += 9)
            {
                string sql1 = "insert into EzeemarketingCust_Feedback([Cust_MobNo],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time],[CreatedDate],[AppMobileNo],[AdminMobNo],[ParentId],[Latitude],[Longitude]) values ('" + arryString[i] + "','" + arryString[i + 1].ToString() + "','" + arryString[i + 2].ToString() + "','" + arryString[i + 3].ToString() + "','" + arryString[i + 4].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppMobNo + "','" + AdminMobNo + "','" + arryString[i + 5].ToString() + "','" + arryString[i + 6].ToString() + "','" + arryString[i + 7].ToString() + "')";
                res = cc.ExecuteNonQuery(sql1);

                string sqlid = "SELECT max(Sid) FROM EzeemarketingCust_Feedback";
                string sid = Convert.ToString(cc.ExecuteScalar(sqlid));

                returnstring += arryString[i + 6].ToString() + "*" + sid + "#";
            }
        }
        catch
        {
            return "0";
        }
        //return "1";
        return returnstring;
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

            for (int i = 0; i < ArryString.Length; i += 4)
            {
                string sql = "insert into [Come2myCityDB].[dbo].[EzeeMarketingAddAdmin]([Custmor_MobNo],[FirstName],[LastName],[Desigation],[CreatedDate],[AppMobileNo]) values('" + ArryString[i].ToString() + "','" + Convert.ToString(ArryString[i + 1]) + "','" + Convert.ToString(ArryString[i + 2]) + "','" + ArryString[i + 3].ToString() + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + AppMobNo + "')";
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
            for (int i = 0; i < ArryString.Length; i += 4)
            {
                string sql = "insert into [Come2myCityDB].[dbo].[EzeeMarketingHistory]([MobileNo],[callType],[Duration],[CurrentDate],[AppMobileNO],[AdminMobNo],[CreatedDate]) " +
                "values('" + ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + AppMobNo + "','" + AdminMobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";  //ArryString[i + 1].ToString()
                result = cc.ExecuteNonQuery(sql);
            }
        }
        catch
        {
            return "0";
        }
        return "1";
    }

    [WebMethod(Description = "Add Reference Customer Data")]   // Not use       
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
            for (int i = 0; i < ArryString.Length; i += 9)
            {
                string sql = "insert into [Come2myCityDB].[dbo].[EzeeMarketing_AddEmpPermission]([EmpMobNo],[EmpCategory],[Permission],[StartTime],[EndTime],[WorkingDays],[AppMobNo],[CreatedDate],[FirstName],[LastName],[Department]) values('" +
                    ArryString[i].ToString() + "','" + ArryString[i + 1].ToString() + "','" + ArryString[i + 2].ToString() + "','" + ArryString[i + 3].ToString() + "','" + ArryString[i + 4].ToString() + "','" + ArryString[i + 5].ToString() + "','" +
                    AppMobNo + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "','" + ArryString[i + 6].ToString() + "','" + ArryString[i + 7].ToString() + "','" + ArryString[i + 8].ToString() + "')"; //,[EndTime] ,'" + ArryString[i + 3].ToString() + "'
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

    [WebMethod(Description = "Upload Expense Details")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string AddExpense(string expenseJsonStr)
    {
        List<Expense> expenseList = js.Deserialize<List<Expense>>(expenseJsonStr);
        List<Expense> returnExpenseList = new List<Expense>();
        try
        {
            using (var con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                foreach (Expense expense in expenseList)
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "uspInsertExpense";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Date", expense.Date);
                        cmd.Parameters.AddWithValue("@Expensetype", expense.Expensetype);
                        cmd.Parameters.AddWithValue("@Amount", expense.Amount);
                        cmd.Parameters.AddWithValue("@Description", expense.Description);
                        cmd.Parameters.AddWithValue("@Rate", expense.Rate);
                        cmd.Parameters.AddWithValue("@Quantity", expense.Quantity);
                        cmd.Parameters.AddWithValue("@Paymentstatus", expense.Paymentstatus);
                        cmd.Parameters.AddWithValue("@UserMobNo", expense.UserMobNo);
                        cmd.Parameters.AddWithValue("@RefMobNo", expense.RefMobNo);
                        cmd.Parameters.AddWithValue("@ImeiNo", expense.ImeiNo);
                        cmd.Parameters.AddWithValue("@Unit", expense.Unit);
                        cmd.Parameters.Add("@returnId", SqlDbType.VarChar, 50);
                        cmd.Parameters["@returnId"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        returnExpenseList.Add(new Expense()
                            {
                                LocalAppId = expense.LocalAppId,
                                RerurnId = cmd.Parameters["@returnId"].Value.ToString()
                            });
                    }
                }
            }
        }
        catch (Exception)
        {
            returnstring = js.Serialize(105);
            throw;
        }
        returnstring = js.Serialize(returnExpenseList);
        return returnstring;
    }

    #region About Fcm Details

    [WebMethod(Description = "Fcm Registration in EzeeMarketing")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string FcmRegistration(string fcmstring)
    {
        FcmReg fcmreg = new FcmReg();
        try
        {
            List<FcmReg> listfcmreg = new JavaScriptSerializer().Deserialize<List<FcmReg>>(fcmstring);

            foreach (FcmReg fcmregs in listfcmreg)
            {
                using (SqlConnection connn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    string querySelect = "SELECT [FcmId] FROM [EzeemarketingFcmReg] WHERE  [AppMobileNo]='" + fcmregs.AppMobileNo + "'";   //Imei='" + fcmregs.Imei +"' and
                    string fcmid = Convert.ToString(cc.ExecuteScalar(querySelect));
                    if (fcmid == string.Empty || fcmid == "0" || fcmid == "")
                    {
                        string sqlString = "Insert Into EzeemarketingFcmReg([AppMobileNo],[FcmId],[Imei],[AppKeyword],[AdminMobileNo],[RoleId],[ModifyDate]) Values('" + fcmregs.AppMobileNo + "','" + fcmregs.FcmId + "','" + fcmregs.Imei + "','" + fcmregs.AppKeyword + "','" + fcmregs.AdminMobileNo + "','" + fcmregs.RoleId + "','" + System.DateTime.Now.ToString("yyyy-MM-dd") + "')";
                        cc.ExecuteNonQuery(sqlString);

                        string sql = "SELECT MAX(Id) FROM EzeemarketingFcmReg";
                        sb.Append(cc.ExecuteScalar(sql));
                    }
                    else
                    {
                        string queryUpdate = "UPDATE [Come2myCityDB].[dbo].[EzeemarketingFcmReg] SET [FcmId]='" + fcmregs.FcmId + "',AdminMobileNo='" + fcmregs.AdminMobileNo + "',RoleId='" + fcmregs.RoleId + "',AppKeyword='" + fcmregs.AppKeyword + "',ModifyDate='" + System.DateTime.Now.ToString("yyyy-MM-dd") + "',Imei='" + fcmreg.Imei + "' WHERE  AppMobileNo='" + fcmregs.AppMobileNo + "'";
                        //"UPDATE [Come2myCityDB].[dbo].[EzeemarketingFcmReg] SET [FcmId]='" + fcmregs.FcmId + "',[AdminMobileNo]='" + fcmregs.AdminMobileNo + "',RoleId='" + fcmregs.RoleId + "',AppKeyword='" + fcmregs.AppKeyword + "',ModifyDate='"+ System.DateTime.Now.ToString(("yyyy-MM-dd") +"' WHERE  [AppMobileNo]='" + fcmregs.AppMobileNo + "' and Imei='" + fcmregs.Imei + "'";  //Imei='"+ fcmregs.Imei +"' and
                        cc.ExecuteNonQuery(queryUpdate);

                        string sql = "SELECT Id FROM EzeemarketingFcmReg WHERE  AppMobileNo='" + fcmregs.AdminMobileNo + "'";   //[Come2myCityDB].[dbo].[EzeemarketingFcmReg]
                        sb.Append(cc.ExecuteScalar(sql));
                    }
                }
            }
            return sb.ToString();
        }
        catch (Exception)
        {
            return sb.Append("105").ToString();
        }
    }

    public class FcmReg
    {
        public string AppMobileNo { get; set; }
        public string RoleId { get; set; }
        public string AdminMobileNo { get; set; }
        public string FcmId { get; set; }
        public string Imei { get; set; }
        public string AppKeyword { get; set; }
        public string NoData { get; set; }
        public string Error { get; set; }
    }

    public class FcmOrder
    {
        public string itemName { get; set; }
        public string itemQuantity { get; set; }
        public string mobileNoOrder { get; set; }
        public string empMobileNo { get; set; }
        public string adminMobileNo { get; set; }
        public string id { get; set; }
        public string date { get; set; }
        public string NoData { get; set; }
        public string Error { get; set; }
    }
    [WebMethod(Description = "Fcm Upload Data in EzeeMarketing")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string FcmUpload(string fcmstring)
    {
        FcmOrder fcm = new FcmOrder();
        try
        {
            List<FcmOrder> listfcm = new JavaScriptSerializer().Deserialize<List<FcmOrder>>(fcmstring);

            foreach (FcmOrder fcmorders in listfcm)
            {
                using (var con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
                {
                    using (var cmd = new SqlCommand())
                    {
                        //string sql = "SELECT [FcmId] FROM [EzeemarketingFcmReg] WHERE [AdminMobileNo]='" + fcmorders.adminMobileNo + "'";
                        //string deviceid=Convert.ToString(cc.ExecuteScalar(sql));



                        cmd.CommandText = "uspInsertFcmDetails";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@itemName", fcmorders.itemName);
                        cmd.Parameters.AddWithValue("@itemQuantity", fcmorders.itemQuantity);
                        cmd.Parameters.AddWithValue("@mobileNoOrder", fcmorders.mobileNoOrder);
                        cmd.Parameters.AddWithValue("@empMobileNo", fcmorders.empMobileNo);
                        cmd.Parameters.AddWithValue("@adminMobileNo", fcmorders.adminMobileNo);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        string getstring = SendNotification_FCMNew(fcmorders.adminMobileNo);
                        //cmd.Parameters.Add("@returnId", SqlDbType.VarChar, 250);
                        //cmd.Parameters["@returnId"].Direction = ParameterDirection.Output;

                        //sb.Append(cmd.Parameters["@returnId"].Value);
                        sb.Append("106");
                    }
                }
            }
            return sb.ToString();
        }
        catch (Exception)
        {
            return sb.Append("105").ToString();
        }
    }

    [WebMethod(Description = "Fcm Download Data in EzeeMarketing")]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string FcmDownload(string empMob, string adminMob)
    {
        FcmReg fcm = new FcmReg(); string strJSON = string.Empty;
        List<FcmOrder> listfcm = new List<FcmOrder>();
        try
        {
            using (var con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (var cmd = new SqlCommand())
                {
                    using (var da = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "uspGetFcmOrder";
                        cmd.Parameters.Add("@adminMobNo", adminMob);
                        cmd.Parameters.Add("@empMobNo", empMob);
                        cmd.Parameters.Add("@query", 2);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                listfcm.Add(new FcmOrder()
                                {
                                    itemName = ds.Tables[0].Rows[i]["ItemName"].ToString(),
                                    itemQuantity = ds.Tables[0].Rows[i]["ItemQuantity"].ToString(),
                                    empMobileNo = ds.Tables[0].Rows[i]["EmpMobileNo"].ToString(),
                                    mobileNoOrder = ds.Tables[0].Rows[i]["MobileNoOrder"].ToString(),
                                    date = System.DateTime.Now.ToString("dd/MM/yyyy"),
                                    id = ds.Tables[0].Rows[i]["Id"].ToString()
                                });
                            }
                            strJSON = js.Serialize(listfcm);
                            return strJSON;
                        }
                        else
                        {
                            strJSON = js.Serialize(106);
                            return strJSON;
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            strJSON = js.Serialize(105);
            return strJSON;
        }
    }

    public string SendNotification_FCMNew(string moNO)
    {
        string SERVER_API_KEY = "AAAAPjCvuKM:APA91bH3idwas1m3zBdt09AolFwxM00qnQNEGLlhJgCVrO2s054Pqcq2NuNgrQZIZgUmtNB5ncdyfkja3HJ0mgvDJXC-0TkNFDPUvysmB8S2Cfc2gLLYuswv35uIl49LxcQPpacrkhkY";
        string SENDER_ID = "267104794787";

        string str = string.Empty;
        try
        {
            //string query = "SELECT [FcmId] FROM [EzeemarketingFcmReg] WHERE [AdminMobileNo]='" + moNO + "'";
            //string deviceid = Convert.ToString(cc.ExecuteScalar(query));

            using (var con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]))
            {
                using (var cmd = new SqlCommand())
                {
                    using (var da = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "uspGetFcmOrder";
                        cmd.Parameters.Add("@adminMobNo", moNO);
                        cmd.Parameters.Add("@empMobNo", "0");
                        cmd.Parameters.Add("@query", 1);
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            // string deviceId = "dXw7j9ncxZE:APA91bGcQbpCs47lkKFBeb-nR-wYGISh76X4cXW9DK2_F43LFTqjb5PN_PBGHUj0RHV-oq0qrsaKY51ahRGDuG3L1R8g0eJ7k1fP7y_BSlihBPv2VDEs7xPB0iw27upBya1ZoYHApMuz";
                            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                            tRequest.Method = "post";
                            tRequest.ContentType = "application/json";
                            var data = new
                            {
                                to = ds.Tables[0].Rows[0]["FcmId"].ToString(),
                                notification = new
                                {
                                    body = ds.Tables[0].Rows[0]["ItemName"].ToString() + " - " + ds.Tables[0].Rows[0]["ItemQuantity"].ToString() + " - " + ds.Tables[0].Rows[0]["EmpMobileNo"].ToString(),
                                    title = "Ezee Marketing",
                                    sound = "Hiii",
                                    click_action = "FcmNotifier"
                                }
                            };
                            var serializer = new JavaScriptSerializer();
                            var json = serializer.Serialize(data);
                            Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                            tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));
                            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));
                            tRequest.ContentLength = byteArray.Length;
                            #region add
                            tRequest.UseDefaultCredentials = true;
                            tRequest.PreAuthenticate = true;
                            tRequest.Credentials = CredentialCache.DefaultCredentials;
                            #endregion

                            using (Stream dataStream = tRequest.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                                using (WebResponse tResponse = tRequest.GetResponse())//
                                {
                                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                    {
                                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                        {
                                            String sResponseFromServer = tReader.ReadToEnd();
                                            str = sResponseFromServer;
                                        }
                                    }
                                }
                            }
                            str = "SUCCESS:" + str;
                        }
                        else
                        {

                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            str = "ERROR:" + ex.Message;
        }
        return str;
    }

    #endregion


    #endregion

    #region ALL WEB METHOD TO DOWNLOAD EZEEMARKETING

    StringBuilder sb = new StringBuilder();

    [WebMethod(Description = "Add Admin Data details")]
    public string DownloadAdminData(string AppMobNo)
    {
        //string cust_Mobno = string.Empty; string F_name = string.Empty;
        //string L_name = string.Empty; string desigation = string.Empty;
        try
        {
            string sql = "select [Custmor_MobNo],[FirstName],[LastName],[Desigation] from [EzeeMarketingAddAdmin] where [AppMobileNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["Custmor_MobNo"]) + "*");
                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["FirstName"]) + "*");
                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["LastName"]) + "*");
                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["Desigation"]) + "#");

                    //cust_Mobno = Convert.ToString(ds.Tables[0].Rows[r]["Custmor_MobNo"]);
                    //F_name = Convert.ToString(ds.Tables[0].Rows[r]["FirstName"]);
                    //L_name = Convert.ToString(ds.Tables[0].Rows[r]["LastName"]);
                    //desigation = Convert.ToString(ds.Tables[0].Rows[r]["Desigation"]);

                    // returnstring += cust_Mobno + "*" + F_name + "*" + L_name + "*" + desigation + "#";
                }
                //returnstring += "#";
            }
            else
            {
                //return "NoRecord";
                return sb.Append("NoRecord").ToString();
            }
        }
        catch
        {
            // return "0";
            return sb.Append("0").ToString();
        }
        return sb.ToString();
    }

    [WebMethod(Description = "call Log Data details")]
    public string DownloadCallLog(string AppMobNo)
    {
        //string Name = string.Empty; string MobileNo = string.Empty;
        //string callType = string.Empty; string Duration = string.Empty;
        //string Curnt_date = string.Empty;
        try
        {
            string sql = "select [MobileNo],[callType],[Duration],[CurrentDate] from [EzeeMarketingHistory] where [AppMobileNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    //MobileNo = Convert.ToString(ds.Tables[0].Rows[r]["MobileNo"]);
                    //callType = Convert.ToString(ds.Tables[0].Rows[r]["callType"]);
                    //Duration = Convert.ToString(ds.Tables[0].Rows[r]["Duration"]);
                    //Curnt_date = Convert.ToString(ds.Tables[0].Rows[r]["CurrentDate"]);

                    //returnstring += MobileNo + "*" + callType + "*" + Duration + "*" + Curnt_date + "#";

                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["MobileNo"]) + "*");
                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["callType"]) + "*");
                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["Duration"]) + "*");
                    sb.Append(Convert.ToString(ds.Tables[0].Rows[r]["CurrentDate"]) + "#");

                }
            }
            else
            {
                return sb.Append("NoRecord").ToString();
                // "NoRecord";
            }
        }
        catch
        {
            return sb.Append("0").ToString();
            //"0";
        }
        return sb.ToString();
    }

    [WebMethod(Description = "Order Data details")]
    public string DownloadOrderData(string AppMobNo)
    {
        string Cust_Id = string.Empty; string ItemId = string.Empty;
        string Quantity = string.Empty;
        try
        {
            string sql = "select [Cust_MobNo],[ItemId],[Quantity],[Latitude],[Longitude] from [EzeemarketingAddOrder] where [AppMobileNo]='" + AppMobNo + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    Cust_Id = Convert.ToString(ds.Tables[0].Rows[r]["Cust_MobNo"]);
                    ItemId = Convert.ToString(ds.Tables[0].Rows[r]["ItemId"]);
                    Quantity = Convert.ToString(ds.Tables[0].Rows[r]["quantity"]);

                    returnstring += Cust_Id + "*" + ItemId + "*" + Quantity + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Latitude"]) + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Longitude"]) + "#";
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
        string Type = string.Empty; string EmaiId = string.Empty;
        string CId = string.Empty; string AdminMobNo = string.Empty;
        string StateId = string.Empty; string TalukaId = string.Empty;
        string DistrictId = string.Empty;
        string sql = string.Empty;
        try
        {
            if (category == "ALL")
            {
                sql = "select [CId],[Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiId],[AppMobNo],[AdminMobNo],[StateId],[DistrictId],[TalukaId] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "'"; //[AdminMobNo]

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
                    sql = "select [CId],[Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiId],[AppMobNo],[AdminMobNo],[StateId],[DistrictId],[TalukaId] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "'";
                }
                else if (adminNo != "" && stateid != "" && districtid != "" && talukaid == "" && type == "")
                {
                    sql = "select [CId],[Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiId],[AppMobNo],[AdminMobNo],[StateId],[DistrictId],[TalukaId] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "' and [DistrictId]='" + districtid + "'";
                }
                else if (adminNo != "" && stateid != "" && districtid != "" && talukaid != "" && type == "")
                {
                    sql = "select [CId],[Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiId],[AppMobNo],[AdminMobNo],[StateId],[DistrictId],[TalukaId] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "' and [DistrictId]='" + districtid + "' and [TalukaId]='" + talukaid + "'";
                }
                else if (adminNo != "" && stateid != "" && districtid != "" && talukaid != "" && type != "")
                {
                    sql = "select [CId],[Cust_mobile],[FirstName],[LastName],[FirmName],[Type],[EmaiId],[AppMobNo],[AdminMobNo],[StateId],[DistrictId],[TalukaId] from [EzeeMarketingCustDetails] where [AdminMobNo]='" + adminNo + "' and [StateId]='" + stateid + "' and [DistrictId]='" + districtid + "' and [TalukaId]='" + talukaid + "' and [Type]='" + type + "'";
                }
            }

            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    CId = Convert.ToString(ds.Tables[0].Rows[r]["CId"]);
                    Cust_mobile = Convert.ToString(ds.Tables[0].Rows[r]["Cust_mobile"]);
                    FirstName = Convert.ToString(ds.Tables[0].Rows[r]["FirstName"]);
                    LastName = Convert.ToString(ds.Tables[0].Rows[r]["LastName"]);
                    FirmName = Convert.ToString(ds.Tables[0].Rows[r]["FirmName"]);
                    Type = Convert.ToString(ds.Tables[0].Rows[r]["Type"]);
                    EmaiId = Convert.ToString(ds.Tables[0].Rows[r]["EmaiId"]);
                    AppMobNo = Convert.ToString(ds.Tables[0].Rows[r]["AppMobNo"]);
                    AdminMobNo = Convert.ToString(ds.Tables[0].Rows[r]["AdminMobNo"]);
                    StateId = Convert.ToString(ds.Tables[0].Rows[r]["StateId"]);
                    DistrictId = Convert.ToString(ds.Tables[0].Rows[r]["DistrictId"]);
                    TalukaId = Convert.ToString(ds.Tables[0].Rows[r]["TalukaId"]);


                    returnstring += CId + "*" + Cust_mobile + "*" + FirstName + "*" + LastName + "*" + FirmName + "*" + Type + "*" + EmaiId + "*" + AppMobNo + "*" + AdminMobNo + "*" + StateId + "*" + DistrictId + "*" + TalukaId + "#";
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

    [WebMethod(Description = "Download Customer mobile no")] //Not use
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
        string sql = string.Empty;
        try
        {
            if (AppMobNo.Length > 10)
            {
                sql = "select [Sid],[Cust_MobNo],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time],[ParentId],[Latitude],[Longitude] from [EzeemarketingCust_Feedback] where [AppMobileNo]='" + AppMobNo.Replace("*", "") + "' AND [CreatedDate] = '" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                sql = "select [Sid],[Cust_MobNo],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time],[ParentId],[Latitude],[Longitude] from [EzeemarketingCust_Feedback] where [AppMobileNo]='" + AppMobNo + "'";
            }
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    custid = Convert.ToString(ds.Tables[0].Rows[r]["Cust_MobNo"]);
                    feedbckdescription = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Description"]);
                    feedbckpoint = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Point"]);
                    rmddate = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Date"]);
                    rmdtime = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Time"]);

                    returnstring += custid + "*" + feedbckdescription + "*" + feedbckpoint + "*" + rmddate + "*" + rmdtime + "*" + Convert.ToString(ds.Tables[0].Rows[r]["ParentId"]) + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Sid"]) + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Latitude"]) + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Longitude"]) + "#";
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
            string sql = "select O.[Cust_MobNo],O.[Quantity],I.[ItemId],I.[ItemName],O.[Latitude],O.[Longitude] from [Come2myCityDB].[dbo].[EzeemarketingAddOrder] O left join [Come2myCityDB].[dbo].[EzeeMarketingAddItem] I " +
                         " ON O.[ItemId]=I.ItemId where [AppMobileNo]='" + AppMobNo + "' and [CreatedDate]='" + Date + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    //string stry = "select [ItemId],[ItemName] from [EzeeMarketingAddItem] where [ItemId]=" + ds.Tables[0].Rows[r][1].ToString() + "";
                    //DataSet DS = cc.ExecuteDataset(stry);

                    //string strqry = "select  [CustId],[MobileNo] from [EzeeMarketingReferenceCustomer] where [CustId]=" + ds.Tables[0].Rows[r][0].ToString() + "";
                    //DataSet Dtset = cc.ExecuteDataset(strqry);

                    ItemId = Convert.ToString(ds.Tables[0].Rows[r]["ItemId"]);
                    ItemName = Convert.ToString(ds.Tables[0].Rows[r]["ItemName"]);
                    Custid = Convert.ToString(ds.Tables[0].Rows[r]["Cust_MobNo"]);
                    // custMobno = Convert.ToString(Dtset.Tables[0].Rows[0]["MobileNo"]);
                    qunty = Convert.ToString(ds.Tables[0].Rows[r]["Quantity"]);

                    returnstring += ItemId + "*" + ItemName + "*" + Custid + "*" + qunty + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Latitude"]) + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Longitude"]) + "#"; //+ custMobno + "*"
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
            string sql = "select [Cust_MobNo],[Feedback_Description],[Feedback_Point],[Reminder_Date],[Reminder_Time],[Latitude],[Longitude] from [EzeemarketingCust_Feedback] where [AppMobileNo]='" + AppMobNo + "' and [CreatedDate]='" + Date + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    //string strqry = "select [MobileNo] from [EzeeMarketingReferenceCustomer] where [CustId]=" + ds.Tables[0].Rows[r][0].ToString() + "";
                    //DataSet Dtset = cc.ExecuteDataset(strqry);

                    custid = Convert.ToString(ds.Tables[0].Rows[r]["Cust_MobNo"]);
                    //custmobno = Convert.ToString(Dtset.Tables[0].Rows[0]["MobileNo"]);
                    feedbckdescription = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Description"]);
                    feedbckpoint = Convert.ToString(ds.Tables[0].Rows[r]["Feedback_Point"]);
                    rmddate = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Date"]);
                    rmdtime = Convert.ToString(ds.Tables[0].Rows[r]["Reminder_Time"]);

                    returnstring += custid + "*" + feedbckdescription + "*" + feedbckpoint + "*" + rmddate + "*" + rmdtime + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Latitude"]) + "*" + Convert.ToString(ds.Tables[0].Rows[r]["Longitude"]) + "#"; //+ custmobno + "*"
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
            string sql = "select [MobileNo],[callType],[Duration],[CurrentDate] from [EzeeMarketingHistory] where [AppMobileNo]='" + AppMobNo.ToString() + "' and [CreatedDate]='" + Date + "'";
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    //Name = Convert.ToString(ds.Tables[0].Rows[r]["Name"]);
                    MobileNo = Convert.ToString(ds.Tables[0].Rows[r]["MobileNo"]);
                    callType = Convert.ToString(ds.Tables[0].Rows[r]["callType"]);
                    Duration = Convert.ToString(ds.Tables[0].Rows[r]["Duration"]);
                    Curnt_date = Convert.ToString(ds.Tables[0].Rows[r]["CurrentDate"]);

                    returnstring += MobileNo + "*" + callType + "*" + Duration + "*" + Curnt_date + "#";//Name + "*" +
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
        string EmpCategory = string.Empty; string dept = string.Empty;
        string MiddleName = string.Empty; string Address = string.Empty; string City = string.Empty;
        try
        {
            string sql = "select [Id],[EmpMobNo],[Permission],[StartTime],[EndTime],[WorkingDays],[FirstName],[LastName],[EmpCategory],Department from [EzeeMarketing_AddEmpPermission] where [AppMobNo]='" + AppMobNo + "'"; //,[EndTime]
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
                    EmpCategory = Convert.ToString(ds.Tables[0].Rows[r]["EmpCategory"]);
                    dept = Convert.ToString(ds.Tables[0].Rows[r]["Department"]);
                    returnstring += id + "*" + Empmobno + "*" + permision + "*" + starttime + "*" + intime + "*" + wrkingdy + "*" + fName + "*" + lName + "*" + EmpCategory + "*" + dept + "#"; // + endtime + "*"
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

    [WebMethod(Description = "Download Add Emp Permision Setting data")]
    public string DownloadSetting(string AppMobNo, string EmpMobNo)
    {
        try
        {
            string sql = "select [Id],[EmpMobNo],[Permission],[StartTime],[EndTime],[WorkingDays],[FirstName],[LastName],[EmpCategory],Department from [EzeeMarketing_AddEmpPermission] where [AppMobNo]='" + AppMobNo + "' and [EmpMobNo]='" + EmpMobNo + "'"; //,[EndTime]
            ds = cc.ExecuteDataset(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string permission = Convert.ToString(ds.Tables[0].Rows[0]["Permission"]);
                string[] strArray = permission.Split(',');
                if (strArray[0].ToString() == "5" || strArray[0].ToString() == "6")
                {
                    //if (strArray[0].ToString() == "5" && strArray[1].ToString() == "6")
                    //{
                    //    returnstring = GetSetting(ds, "1", "1");
                    //}
                    //else if (strArray[0].ToString() == "6")
                    //{
                    //    returnstring = GetSetting(ds, "0", "1");
                    //}
                    //else
                    //{
                    //    returnstring = GetSetting(ds, "1", "0");
                    //}
                    try
                    {
                        returnstring = checkCondition(strArray[0].ToString(), strArray[1].ToString());
                    }
                    catch (Exception ex)
                    {
                        returnstring = checkCondition(strArray[0].ToString(), "Error");
                    }
                }
                else if (strArray[1].ToString() == "5" || strArray[1].ToString() == "6")
                {
                    try
                    {
                        returnstring = checkCondition(strArray[1].ToString(), strArray[2].ToString());
                    }
                    catch (Exception ex)
                    {
                        returnstring = checkCondition(strArray[1].ToString(), "Error");
                    }
                }
                else if (strArray[2].ToString() == "5" || strArray[2].ToString() == "6")
                {
                    try
                    {
                        returnstring = checkCondition(strArray[2].ToString(), strArray[3].ToString());
                    }
                    catch (Exception ex)
                    {
                        returnstring = checkCondition(strArray[2].ToString(), "Error");
                    }
                }
                else if (strArray[3].ToString() == "5" || strArray[3].ToString() == "6")
                {
                    try
                    {
                        returnstring = checkCondition(strArray[3].ToString(), strArray[4].ToString());
                    }
                    catch (Exception ex)
                    {
                        returnstring = checkCondition(strArray[3].ToString(), "Error");
                    }
                }
                else if (strArray[4].ToString() == "5" || strArray[4].ToString() == "6")
                {
                    try
                    {
                        returnstring = checkCondition(strArray[4].ToString(), strArray[5].ToString());
                    }
                    catch
                    {
                        returnstring = checkCondition(strArray[4].ToString(), "Error");
                    }
                }
                else if (strArray[5].ToString() == "5" || strArray[5].ToString() == "6")
                {
                    try
                    {
                        returnstring = checkCondition(strArray[5].ToString(), strArray[6].ToString());
                    }
                    catch
                    {
                        returnstring = checkCondition(strArray[5].ToString(), "Error");
                    }
                }
                else if (strArray[6].ToString() == "5" || strArray[6].ToString() == "6")
                {
                    returnstring = checkCondition(strArray[6].ToString(), strArray[6].ToString());
                }
                else
                {
                    returnstring = GetSetting(ds, "0", "0");
                }
            }
            else
            {
                return "NoRecord";
            }
        }
        catch
        {
            return "105";
        }
        return returnstring;
    }

    public string checkCondition(string par1, string par2)
    {
        if (par1 == "5" && par2 == "6")
        {
            return returnstring = GetSetting(ds, "1", "1");
        }
        else if (par1 == "6")
        {
            return returnstring = GetSetting(ds, "0", "1");
        }
        else
        {
            return returnstring = GetSetting(ds, "1", "0");
        }
    }

    public string GetSetting(DataSet ds, string par5, string par6)
    {
        StringBuilder sb = new StringBuilder();
        try
        {
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    sb.Append("Id1" + ds.Tables[0].Rows[i][""].ToString() );
            //}
            sb.Append(par5 + "*");
            sb.Append(par6 + "*");
            sb.Append(ds.Tables[0].Rows[0]["StartTime"].ToString() + "*");
            sb.Append(ds.Tables[0].Rows[0]["EndTime"].ToString() + "#");
            //sb.Append("Id1:" + "1" + ",");
            //sb.Append("value:" + "0" + ",");
            //sb.Append("StartTime:" + " " +ds.Tables[0].Rows[0]["StartTime"].ToString() + " "  + ",");
            //sb.Append("EndTime:" + " " + ds.Tables[0].Rows[0]["EndTime"].ToString() + " " + "}");
        }
        catch (Exception ex)
        {

            throw;
        }
        return sb.ToString();
    }

    #endregion

    //////////////////////for EzeeClass App //////////
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
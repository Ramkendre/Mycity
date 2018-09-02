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
/// Summary description for JobProfile
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class JobProfile : System.Web.Services.WebService
{

    public JobProfile()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 

    }
    CommonCode cc = new CommonCode();
    //[WebMethod]
    //public string HelloWorld() {
    //    GCMDLL.Message msg = new GCMDLL.Message();
    //    return msg.SingleMessage();
    //    //return "Hello World";
    //}
    #region insert Data
    [WebMethod(Description = "JobProfile")]

    public string InsertData(string Keyword, string JobString, string UserMobileNo)
    {
        int i;
        //if (!string.IsNullOrEmpty(eventString) && !string.IsNullOrEmpty(keyWord))

        if (JobString != "" && Keyword != null)
        {
            try
            {
                if (Keyword.Equals("PERSONAL"))
                {
                    return Personsal(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("EDUCATION"))
                {
                    return Education(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("WORK-EXPERIENCE"))
                {
                    return WExperience(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("KEYSKILLS"))
                {
                    return Keyskills(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("RESUME"))
                {
                    return Resume(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("COMPANYREG"))
                {
                    return CompanyReg(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("POSTREQUIRMENT"))
                {
                    return PostReq(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("DEMANDJOB"))
                {
                    return DemandJob(JobString, UserMobileNo);
                }
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
    private string Personsal(string PersonalDString, string UsrMobileNo)
    {
        int result;
        DataSet ds = new DataSet();
        string[] StringArray = PersonalDString.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 17)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            if (StringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@FName", StringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LName", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@BOD", StringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@State", StringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@District", StringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@City", StringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PinCode", StringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PhoneNo", StringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Image", StringArray[i + 10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@EmailId", StringArray[i + 11].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Address", StringArray[i + 12].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrDeviceId", StringArray[i + 13].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrSimSerialNo", StringArray[i + 14].ToString()));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 15].ToString()));
                cmd.Parameters.Add(new SqlParameter("@AadharNo", StringArray[i + 16].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));


                cmd.CommandText = "uspInsertJPersonalDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();

                string str = "select max(ID) from [Come2myCityDB].[come2mycity].[tbl_JPersonalDetails]";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";

            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@ID",StringArray[i]),
                    new SqlParameter("@FName",StringArray[i+1]),new SqlParameter("@LName",StringArray[i+2]),
                    new SqlParameter("@BOD",StringArray[i+3]),new SqlParameter("@State",StringArray[i+4]),
                    new SqlParameter("@District",StringArray[i+5]),new SqlParameter("@City",StringArray[i+6]),
                    new SqlParameter("@PinCode",StringArray[i+7]),new SqlParameter("@MobileNo",StringArray[i+8]),
                    new SqlParameter("@PhoneNo",StringArray[i+9]),new SqlParameter("@Image",StringArray[i+10]),
                    new SqlParameter("@EmailId",StringArray[i+11]),new SqlParameter("@Address", StringArray[i+12]),
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                    new SqlParameter("@UsrDeviceId", StringArray[i+13]), new SqlParameter("@UsrSimSerialNo", StringArray[i+14]),
                    new SqlParameter("@EntryDate", StringArray[i+15]),new SqlParameter("@AadharNo", StringArray[i + 16].ToString())
                };
                //Make tommarow Changes
                string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(s);
                string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JPersonalDetails] set [FName]='" + StringArray[i + 1].ToString() + "',[LName]='" + StringArray[i + 2].ToString() + "',[BOD]='" + StringArray[i + 3].ToString() + "',[State]='" + StringArray[i + 4].ToString() + "',[District]='" + StringArray[i + 5].ToString() + "',[City/Taluka]='" + StringArray[i + 6].ToString() + "',[PinCode]='" + StringArray[i + 7].ToString() + "',[MobileNo]='" + StringArray[i + 8].ToString() + "',[PhoneNo]='" + StringArray[i + 9].ToString() + "',[Image]='" + StringArray[i + 10].ToString() + "',[EmailId]='" + StringArray[i + 11].ToString() + "',[Address]='" + StringArray[i + 12].ToString() + "',[usrDeviceId]='" + StringArray[i + 13].ToString() + "',[usrSimserialno]='" + StringArray[i + 14].ToString() + "',[EntryDate]='" + StringArray[i + 15].ToString() + "',AadharNo='" + StringArray[i + 16].ToString() + "' where ID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
                result = cc.ExecuteNonQuery(str1);

            }



            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    private string Education(string EducationString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = EducationString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 13)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            if (StringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@Qualification", StringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DegName", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Specialization", StringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@CollegeName", StringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@YearPassout", StringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@University", StringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Marks", StringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Keyword", StringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));

                cmd.Parameters.Add(new SqlParameter("@UsrDeviceId", StringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrSimSerialNo", StringArray[i + 10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 11].ToString()));
                cmd.CommandText = "[come2mycity].[uspInsertJEducationDetails]";
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();

                string s = "SELECT max(EID) from [Come2myCityDB].[come2mycity].[tbl_JEducation]";
                string str1 = cc.ExecuteScalar(s);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@EID",StringArray[i]),
                    new SqlParameter("@Qualification",StringArray[i+1].ToString()),new SqlParameter("@DegName",StringArray[i+2]),
                    new SqlParameter("@Specialization",StringArray[i+3].ToString()),
                    new SqlParameter("@CollegeName",StringArray[i+4].ToString()),new SqlParameter("@YearPassout",StringArray[i+5].ToString()),
                    new SqlParameter("@University",StringArray[i+6].ToString()),new SqlParameter("@Marks",StringArray[i+7].ToString()),
                    new SqlParameter("@Keyword",StringArray[i+8].ToString()), new SqlParameter("@UsrMobileNo", UsrMobileNo),
                    new SqlParameter("@UsrDeviceId", StringArray[i+9].ToString()), new SqlParameter("@UsrSimSerialNo", StringArray[i+10].ToString()),
                    new SqlParameter("@EntryDate",StringArray[i+11].ToString())
                };
                cmd.Parameters.AddRange(par);
                string st = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(st);
                string st1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JEducation] set [Qualification]='" + StringArray[i + 1].ToString() + "',[Specialization]='" + StringArray[i + 2].ToString() + "',[CollegeName]='" + StringArray[i + 3].ToString() + "',[YearPassout]='" + StringArray[i + 4].ToString() + "',[University]='" + StringArray[i + 5].ToString() + "',[Marks]='" + StringArray[i + 6].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 8].ToString() + "',[usrSimserialno]='" + StringArray[i + 9].ToString() + "',[EntryDate]='" + StringArray[i + 10].ToString() + "' where [EID]='" + StringArray[i] + "' and [UserId]='" + st1 + "'";
                int result = cc.ExecuteNonQuery(str1);
            }
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }



    private string WExperience(string WExpString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = WExpString.Split(new char[] { '*', '#' });
        string nonInsertedValue = string.Empty;
        string nonInsertedValues1 = string.Empty;

        for (int i = 1; i < StringArray.Length; i += 13)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            if (StringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@FrmDate", StringArray[i + 1]));
                cmd.Parameters.Add(new SqlParameter("@ToDate", StringArray[i + 2]));
                cmd.Parameters.Add(new SqlParameter("@TotalExpYr", StringArray[i + 3]));
                cmd.Parameters.Add(new SqlParameter("@TotalExpM", StringArray[i + 4]));
                cmd.Parameters.Add(new SqlParameter("@JTitle", StringArray[i + 5]));
                cmd.Parameters.Add(new SqlParameter("@CompName", StringArray[i + 6]));
                cmd.Parameters.Add(new SqlParameter("@Salary", StringArray[i + 7]));
                cmd.Parameters.Add(new SqlParameter("@FArea", StringArray[i + 8]));

                cmd.Parameters.Add(new SqlParameter("@UsrDeviceId", StringArray[i + 9]));
                cmd.Parameters.Add(new SqlParameter("@UsrSimSerialNo", StringArray[i + 10]));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 11]));
                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));

                cmd.CommandText = "[come2mycity].[uspInsertJWExpDetails]";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();

                string s = "SELECT max(ID) from [Come2myCityDB].[come2mycity].[tbl_JWorkExp]";
                string str1 = cc.ExecuteScalar(s);
                nonInsertedValues1 += str1 + "*";

            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@ID",StringArray[i]),
                new SqlParameter("@FrmDate", StringArray[i + 1]),new SqlParameter("@ToDate", StringArray[i + 2]),
                new SqlParameter("@TotalExpYr", StringArray[i + 3]),new SqlParameter("@TotalExpM", StringArray[i + 4]),
                new SqlParameter("@JTitle", StringArray[i + 5]),new SqlParameter("@CompName", StringArray[i + 6]),
                new SqlParameter("@Salary", StringArray[i + 7]),new SqlParameter("@FArea", StringArray[i + 8]),
                new SqlParameter("@UsrMobileNo", UsrMobileNo),
                new SqlParameter("@UsrDeviceId", StringArray[i+9]), new SqlParameter("@UsrSimSerialNo", StringArray[i+10]),
                new SqlParameter("@EntryDate",StringArray[i+11])
                };

                cmd.Parameters.AddRange(par);
                string st = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(st);
                string st1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JWorkExp] set [FrmDate]='" + StringArray[i + 1].ToString() + "',[ToDate]='" + StringArray[i + 2].ToString() + "',[TotalExpYr]='" + StringArray[i + 3].ToString() + "',[TotalExpM]='" + StringArray[i + 4].ToString() + "',[JTitle]='" + StringArray[i + 5].ToString() + "',[CompName]='" + StringArray[i + 6].ToString() + "',[Salary]='" + StringArray[i + 7].ToString() + "',[FArea]='" + StringArray[i + 8].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 9].ToString() + "',[usrSimserialno]='" + StringArray[i + 10].ToString() + "',[EntryDate]='" + StringArray[i + 11].ToString() + "' where [ID]='" + StringArray[i] + "' and [UserId]='" + st1 + "'";
                int result = cc.ExecuteNonQuery(str1);
            }
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValue))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValue;

    }


    private string Keyskills(string KeySkillString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = KeySkillString.Split(new char[] { '*', '#' });
        string nonInsertedValue = string.Empty;
        string nonInsertedValues1 = string.Empty;

        for (int i = 1; i < StringArray.Length; i += 6)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;

            if (StringArray[i] == "0")
            {

                cmd.Parameters.Add(new SqlParameter("@Skill", StringArray[i + 1].ToString()));

                cmd.Parameters.Add(new SqlParameter("@UsrDeviceId", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrSimSerialNo", StringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));

                cmd.CommandText = "[come2mycity].[uspInsertJKeySkillDetails]";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

                string sql1 = "select max(JID) from [Come2myCityDB].[come2mycity].[tbl_JSkill]";
                string str1 = cc.ExecuteScalar(sql1);
                nonInsertedValues1 += str1 + "*";

            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@JID",StringArray[i]),
                    new SqlParameter("@Skill",StringArray[i+1]),
                    new SqlParameter("@UsrDeviceId", StringArray[i+2]), new SqlParameter("@UsrSimSerialNo", StringArray[i+3]),
                    new SqlParameter("@EntryDate",StringArray[i+4]),new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
                cmd.Parameters.AddRange(par);
                string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(s);
                string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JSkill] set [Skill]='" + StringArray[i + 1].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 2].ToString() + "',[usrSimserialno]='" + StringArray[i + 3].ToString() + "',[EntryDate]='" + StringArray[i + 4].ToString() + "' where JID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
                int result = cc.ExecuteNonQuery(str1);
            }

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValue))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValue;

    }

    private string Resume(string ResumeString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = ResumeString.Split(new char[] { '*', '#' });
        string nonInsertedValue = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 5)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;

            if (StringArray[i] == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@RTitle", StringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@ResumeName", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Course", StringArray[i + 3].ToString()));

                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));

                cmd.CommandText = "[come2mycity].[uspInsertJResumeDetails]";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();


                string stra = "select max(PID) from [Come2myCityDB].[come2mycity].[tbl_JProfile]";
                string a = cc.ExecuteScalar(stra);
                nonInsertedValues1 = a + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@PID",StringArray[i]),
                    new SqlParameter("@RTitle",StringArray[i+1]),new SqlParameter("ResumeName",StringArray[i+2]),
                    new SqlParameter("@Course",StringArray[i+3]),
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
                cmd.Parameters.AddRange(par);
                string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(s);
                string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JProfile] set [RTitle]='" + StringArray[i + 1].ToString() + "',[ResumeName]='" + StringArray[i + 2].ToString() + "',[Course]='" + StringArray[i + 3].ToString() + "' where PID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
                int result = cc.ExecuteNonQuery(str1);

            }



            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValue))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValue;
    }

    private string CompanyReg(string EducationString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = EducationString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 15)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            if (StringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@NameOfComp", StringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@TypeOfUnit", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DirectName", StringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Role", StringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@EmailId", StringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@FAddress", StringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@State", StringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@District", StringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));

                cmd.Parameters.Add(new SqlParameter("@Taluka", StringArray[i + 10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@City", StringArray[i + 11].ToUpper().ToString()));
                cmd.Parameters.Add(new SqlParameter("@Sectors", StringArray[i + 12].ToString()));
                cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 13].ToString()));
                cmd.CommandText = "uspInsertJCompReg";
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();

                string s = "SELECT max(CID) from [Come2myCityDB].[come2mycity].[tbl_JCompReg]";
                string str1 = cc.ExecuteScalar(s);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@EID",StringArray[i]),
                    new SqlParameter("@Qualification",StringArray[i+1].ToString()),new SqlParameter("@DegName",StringArray[i+2]),
                    new SqlParameter("@Specialization",StringArray[i+3].ToString()),
                    new SqlParameter("@CollegeName",StringArray[i+4].ToString()),new SqlParameter("@YearPassout",StringArray[i+5].ToString()),
                    new SqlParameter("@University",StringArray[i+6].ToString()),new SqlParameter("@Marks",StringArray[i+7].ToString()),
                    new SqlParameter("@Keyword",StringArray[i+8].ToString()), new SqlParameter("@UsrMobileNo", UsrMobileNo),
                    new SqlParameter("@UsrDeviceId", StringArray[i+9].ToString()), new SqlParameter("@UsrSimSerialNo", StringArray[i+10].ToString()),
                    new SqlParameter("@EntryDate",StringArray[i+11].ToString())
                };
                cmd.Parameters.AddRange(par);
                string st = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(st);
                string st1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JEducation] set [Qualification]='" + StringArray[i + 1].ToString() + "',[Specialization]='" + StringArray[i + 2].ToString() + "',[CollegeName]='" + StringArray[i + 3].ToString() + "',[YearPassout]='" + StringArray[i + 4].ToString() + "',[University]='" + StringArray[i + 5].ToString() + "',[Marks]='" + StringArray[i + 6].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 8].ToString() + "',[usrSimserialno]='" + StringArray[i + 9].ToString() + "',[EntryDate]='" + StringArray[i + 10].ToString() + "' where [EID]='" + StringArray[i] + "' and [UserId]='" + st1 + "'";
                int result = cc.ExecuteNonQuery(str1);
            }
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    // -------1*0*Abhinav*Agriculture*Admin*BE*Java*2*02-02-2015*20000*Fresher*Yes*Pune*2015-02-02#-----
    private string PostReq(string EducationString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = EducationString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 14)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            if (StringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@CName", StringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@InSector", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@JRole", StringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Qualification", StringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Skill", StringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@JRequirment", StringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@VaccancyTill", StringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@SalaryOffered", StringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@FreExp", StringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@TrainingOffered", StringArray[i + 10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@City", StringArray[i + 11].ToUpper().ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));

                cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 12].ToString()));
                cmd.CommandText = "uspInsertJPostReq";
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();

                string s = "SELECT max(PID) from [Come2myCityDB].[come2mycity].[tbl_JPostReq]";
                string str1 = cc.ExecuteScalar(s);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@EID",StringArray[i]),
                    new SqlParameter("@Qualification",StringArray[i+1].ToString()),new SqlParameter("@DegName",StringArray[i+2]),
                    new SqlParameter("@Specialization",StringArray[i+3].ToString()),
                    new SqlParameter("@CollegeName",StringArray[i+4].ToString()),new SqlParameter("@YearPassout",StringArray[i+5].ToString()),
                    new SqlParameter("@University",StringArray[i+6].ToString()),new SqlParameter("@Marks",StringArray[i+7].ToString()),
                    new SqlParameter("@Keyword",StringArray[i+8].ToString()), new SqlParameter("@UsrMobileNo", UsrMobileNo),
                    new SqlParameter("@UsrDeviceId", StringArray[i+9].ToString()), new SqlParameter("@UsrSimSerialNo", StringArray[i+10].ToString()),
                    new SqlParameter("@EntryDate",StringArray[i+11].ToString())
                };
                cmd.Parameters.AddRange(par);
                string st = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(st);
                string st1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JEducation] set [Qualification]='" + StringArray[i + 1].ToString() + "',[Specialization]='" + StringArray[i + 2].ToString() + "',[CollegeName]='" + StringArray[i + 3].ToString() + "',[YearPassout]='" + StringArray[i + 4].ToString() + "',[University]='" + StringArray[i + 5].ToString() + "',[Marks]='" + StringArray[i + 6].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 8].ToString() + "',[usrSimserialno]='" + StringArray[i + 9].ToString() + "',[EntryDate]='" + StringArray[i + 10].ToString() + "' where [EID]='" + StringArray[i] + "' and [UserId]='" + st1 + "'";
                int result = cc.ExecuteNonQuery(str1);
            }
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    public string DemandJob(string EducationString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = EducationString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 13)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            if (StringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Sector", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@JRole", StringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Experience", StringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Salary", StringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@State", StringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@District", StringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Taluka", StringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Date", StringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@IntrestedFor", StringArray[i + 10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UsrMobileNo", UsrMobileNo));

                cmd.Parameters.Add(new SqlParameter("@EntryDate", StringArray[i + 11].ToString()));
                cmd.CommandText = "uspInsertJDemandJob";
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();

                string s = "SELECT max(DID) from [Come2myCityDB].[come2mycity].[tbl_JDemandJob]";
                string str1 = cc.ExecuteScalar(s);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@EID",StringArray[i]),
                    new SqlParameter("@Qualification",StringArray[i+1].ToString()),new SqlParameter("@DegName",StringArray[i+2]),
                    new SqlParameter("@Specialization",StringArray[i+3].ToString()),
                    new SqlParameter("@CollegeName",StringArray[i+4].ToString()),new SqlParameter("@YearPassout",StringArray[i+5].ToString()),
                    new SqlParameter("@University",StringArray[i+6].ToString()),new SqlParameter("@Marks",StringArray[i+7].ToString()),
                    new SqlParameter("@Keyword",StringArray[i+8].ToString()), new SqlParameter("@UsrMobileNo", UsrMobileNo),
                    new SqlParameter("@UsrDeviceId", StringArray[i+9].ToString()), new SqlParameter("@UsrSimSerialNo", StringArray[i+10].ToString()),
                    new SqlParameter("@EntryDate",StringArray[i+11].ToString())
                };
                cmd.Parameters.AddRange(par);
                string st = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
                ds = cc.ExecuteDataset(st);
                string st1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
                string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JEducation] set [Qualification]='" + StringArray[i + 1].ToString() + "',[Specialization]='" + StringArray[i + 2].ToString() + "',[CollegeName]='" + StringArray[i + 3].ToString() + "',[YearPassout]='" + StringArray[i + 4].ToString() + "',[University]='" + StringArray[i + 5].ToString() + "',[Marks]='" + StringArray[i + 6].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 8].ToString() + "',[usrSimserialno]='" + StringArray[i + 9].ToString() + "',[EntryDate]='" + StringArray[i + 10].ToString() + "' where [EID]='" + StringArray[i] + "' and [UserId]='" + st1 + "'";
                int result = cc.ExecuteNonQuery(str1);
            }
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    #endregion

    #region Update Data
    [WebMethod(Description = "UpdateData")]

    public string UpdateData(string Keyword, string JobString, string UserMobileNo)
    {
        int i;
        //if (!string.IsNullOrEmpty(eventString) && !string.IsNullOrEmpty(keyWord))

        if (JobString != "" && Keyword != null)
        {
            try
            {
                if (Keyword.Equals("PERSONAL"))
                {
                    return UpdatePersonsal(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("EDUCATION"))
                {
                    return UpdateEducation(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("WORK-EXPERIENCE"))
                {
                    return UpdateWExperience(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("KEYSKILLS"))
                {
                    return UpdateKeyskills(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("RESUME"))
                {
                    return Resume(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("COMPANYREG"))
                {
                    return CompRegi(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("POSTREQUIRMENT"))
                {
                    return UpdatePostReq(JobString, UserMobileNo);
                }
                else if (Keyword.Equals("DEMANDJOB"))
                {
                    return DemandJ(JobString, UserMobileNo);
                }
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
    private string UpdatePersonsal(string PersonalDString, string UsrMobileNo)
    {
        int result;
        DataSet ds = new DataSet();
        string[] StringArray = PersonalDString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 15)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@ID",StringArray[i]),
                    new SqlParameter("@FName",StringArray[i+1]),new SqlParameter("@LName",StringArray[i+2]),
                    new SqlParameter("@BOD",StringArray[i+3]),new SqlParameter("@State",StringArray[i+4]),
                    new SqlParameter("@District",StringArray[i+5]),new SqlParameter("@City",StringArray[i+6]),
                    new SqlParameter("@PinCode",StringArray[i+7]),new SqlParameter("@MobileNo",StringArray[i+8]),
                    new SqlParameter("@PhoneNo",StringArray[i+9]),new SqlParameter("@Image",StringArray[i+10]),
                    new SqlParameter("@EmailId",StringArray[i+11]),
                    new SqlParameter("@UsrDeviceId", StringArray[i+12]), new SqlParameter("@UsrSimSerialNo",StringArray[i+13]),
                    new SqlParameter("@AadharNo",StringArray[i+14]),
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
            //Make tommarow Changes
            string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
            ds = cc.ExecuteDataset(s);
            string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
            string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JPersonalDetails] set [FName]='" + StringArray[i + 1].ToString() + "',[LName]='" + StringArray[i + 2].ToString() + "',[BOD]='" + StringArray[i + 3].ToString() + "',[State]='" + StringArray[i + 4].ToString() + "',[District]='" + StringArray[i + 5].ToString() + "',[City/Taluka]='" + StringArray[i + 6].ToString() + "',[PinCode]='" + StringArray[i + 7].ToString() + "',[MobileNo]='" + StringArray[i + 8].ToString() + "',[PhoneNo]='" + StringArray[i + 9].ToString() + "',[Image]='" + StringArray[i + 10].ToString() + "',[EmailId]='" + StringArray[i + 11].ToString() + "',[usrDeviceId]='" + StringArray[i + 12].ToString() + "',[usrSimserialno]='" + StringArray[i + 13].ToString() + "',AadharNo='" + StringArray[i + 14].ToString() + "' where ID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
            result = cc.ExecuteNonQuery(str1);





            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;

    }
    private string UpdateEducation(string EducationString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = EducationString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 11)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;

            SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@EID",StringArray[i]),
                    new SqlParameter("@Qualification",StringArray[i+1].ToString()),new SqlParameter("@Specialization",StringArray[i+2].ToString()),
                    new SqlParameter("@CollegeName",StringArray[i+3].ToString()),new SqlParameter("@YearPassout",StringArray[i+4].ToString()),
                    new SqlParameter("@University",StringArray[i+5].ToString()),new SqlParameter("@Marks",StringArray[i+6].ToString()),
                    new SqlParameter("@Keyword",StringArray[i+7].ToString()), 
                    new SqlParameter("@UsrDeviceId", StringArray[i+8]), new SqlParameter("@UsrSimSerialNo", StringArray[i+9]),
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
            cmd.Parameters.AddRange(par);
            string st = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
            ds = cc.ExecuteDataset(st);
            string st1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
            string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JEducation] set [Qualification]='" + StringArray[i + 1].ToString() + "',[Specialization]='" + StringArray[i + 2].ToString() + "',[CollegeName]='" + StringArray[i + 3].ToString() + "',[YearPassout]='" + StringArray[i + 4].ToString() + "',[University]='" + StringArray[i + 5].ToString() + "',[Marks]='" + StringArray[i + 6].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 8].ToString() + "',[usrSimserialno]='" + StringArray[i + 9].ToString() + "' where [EID]='" + StringArray[i] + "' and [UserId]='" + st1 + "'";
            int result = cc.ExecuteNonQuery(str1);

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    private string UpdateWExperience(string WExpString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = WExpString.Split(new char[] { '*', '#' });
        string nonInsertedValue = string.Empty;
        string nonInsertedValues1 = string.Empty;

        for (int i = 1; i < StringArray.Length; i += 12)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;

            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@ID",StringArray[i]),
                new SqlParameter("@FrmDate", StringArray[i + 1]),new SqlParameter("@ToDate", StringArray[i + 2]),
                new SqlParameter("@TotalExpYr", StringArray[i + 3]),new SqlParameter("@TotalExpM", StringArray[i + 4]),
                new SqlParameter("@JTitle", StringArray[i + 5]),new SqlParameter("@CompName", StringArray[i + 6]),
                new SqlParameter("@Salary", StringArray[i + 7]),new SqlParameter("@FArea", StringArray[i + 8]),
                 new SqlParameter("@UsrDeviceId", StringArray[i+9]), new SqlParameter("@UsrSimSerialNo", StringArray[i+10]),
                new SqlParameter("@UsrMobileNo", UsrMobileNo),
               
                };

            cmd.Parameters.AddRange(par);
            string st = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
            ds = cc.ExecuteDataset(st);
            string st1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
            string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JWorkExp] set [FrmDate]='" + StringArray[i + 1].ToString() + "',[ToDate]='" + StringArray[i + 2].ToString() + "',[TotalExpYr]='" + StringArray[i + 3].ToString() + "',[TotalExpM]='" + StringArray[i + 4].ToString() + "',[JTitle]='" + StringArray[i + 5].ToString() + "',[CompName]='" + StringArray[i + 6].ToString() + "',[Salary]='" + StringArray[i + 7].ToString() + "',[FArea]='" + StringArray[i + 8].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 9].ToString() + "',[usrSimserialno]='" + StringArray[i + 10].ToString() + "' where [ID]='" + StringArray[i] + "' and [UserId]='" + st1 + "'";
            int result = cc.ExecuteNonQuery(str1);

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValue))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValue;

    }
    private string UpdateKeyskills(string KeySkillString, string UsrMobileNo)
    {
        DataSet ds = new DataSet();
        string[] StringArray = KeySkillString.Split(new char[] { '*', '#' });
        string nonInsertedValue = string.Empty;
        string nonInsertedValues1 = string.Empty;

        for (int i = 1; i < StringArray.Length; i += 5)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;


            SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@JID",StringArray[i]),
                    new SqlParameter("@Skill",StringArray[i+1]),
                    new SqlParameter("@UsrDeviceId", StringArray[i+2]), new SqlParameter("@UsrSimSerialNo", StringArray[i+3]),
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
            cmd.Parameters.AddRange(par);
            string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
            ds = cc.ExecuteDataset(s);
            string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
            string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JSkill] set [Skill]='" + StringArray[i + 1].ToString() + "',[usrMobileNo]='" + UsrMobileNo + "',[usrDeviceId]='" + StringArray[i + 2].ToString() + "',[usrSimserialno]='" + StringArray[i + 3].ToString() + "' where JID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
            int result = cc.ExecuteNonQuery(str1);


            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValue))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValue;

    }
    private string CompRegi(string PersonalDString, string UsrMobileNo)
    {
        int result;
        DataSet ds = new DataSet();
        string[] StringArray = PersonalDString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 15)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@CID",StringArray[i]),
                    new SqlParameter("@NameOfComp",StringArray[i+1]),new SqlParameter("@TypeOfUnit",StringArray[i+2]),
                    new SqlParameter("@DirectName",StringArray[i+3]),new SqlParameter("@MobileNo",StringArray[i+4]),
                    new SqlParameter("@EmailId",StringArray[i+5]),new SqlParameter("@FAddress",StringArray[i+6]),
                    new SqlParameter("@State",StringArray[i+7]),new SqlParameter("@District",StringArray[i+8]),
                    new SqlParameter("@Taluka",StringArray[i+9]),new SqlParameter("@City",StringArray[i+10]),
                    new SqlParameter("@Sectors",StringArray[i+11]),
                    new SqlParameter("@EntryDate", StringArray[i+12]), 
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
            //Make tommarow Changes
            string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
            ds = cc.ExecuteDataset(s);
            string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
            string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JCompReg] set [NameOfComp]='" + StringArray[i + 1].ToString() + "',[TypeOfUnit]='" + StringArray[i + 2].ToString() + "',[DirectName]='" + StringArray[i + 3].ToString() + "',[MobileNo]='" + StringArray[i + 4].ToString() + "',[EmailId]='" + StringArray[i + 5].ToString() + "',[FAddress]='" + StringArray[i + 6].ToString() + "',[State]='" + StringArray[i + 7].ToString() + "',[District]='" + StringArray[i + 8].ToString() + "',[Taluka]='" + StringArray[i + 9].ToString() + "',[City]='" + StringArray[i + 10].ToString() + "',[Sectors]='" + StringArray[i + 11].ToString() + "',[EntryDate]='" + StringArray[i + 12].ToString() + "' where CID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
            result = cc.ExecuteNonQuery(str1);

            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;

    }

    private string UpdatePostReq(string PersonalDString, string UsrMobileNo)
    {
        int result;
        DataSet ds = new DataSet();
        string[] StringArray = PersonalDString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 14)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@PID",StringArray[i]),
                    new SqlParameter("@CName",StringArray[i+1]),new SqlParameter("@InSector",StringArray[i+2]),
                    new SqlParameter("@JRole",StringArray[i+3]),new SqlParameter("@Qualification",StringArray[i+4]),
                    new SqlParameter("@Skill",StringArray[i+5]),new SqlParameter("@JRequirment",StringArray[i+6]),
                    new SqlParameter("@VaccancyTill",StringArray[i+7]),new SqlParameter("@SalaryOffered",StringArray[i+8]),
                    new SqlParameter("@FreExp",StringArray[i+9]),new SqlParameter("@TrainingOffered",StringArray[i+10]),
                    new SqlParameter("@City", StringArray[i+11]),
                    new SqlParameter("@EntryDate", StringArray[i+12]), 
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
            //Make tommarow Changes
            string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
            ds = cc.ExecuteDataset(s);
            string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
            string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JPostReq] set [CName]='" + StringArray[i + 1].ToString() + "',[InSector]='" + StringArray[i + 2].ToString() + "',[JRole]='" + StringArray[i + 3].ToString() + "',[Qualification]='" + StringArray[i + 4].ToString() + "',[Skill]='" + StringArray[i + 5].ToString() + "',[JRequirment]='" + StringArray[i + 6].ToString() + "',[VaccancyTill]='" + StringArray[i + 7].ToString() + "',[SalaryOffered]='" + StringArray[i + 8].ToString() + "',[FreExp]='" + StringArray[i + 9].ToString() + "',[TrainingOffered]='" + StringArray[i + 10].ToString() + "',[EntryDate]='" + StringArray[i + 12].ToString() + "' where PID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
            result = cc.ExecuteNonQuery(str1);





            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    private string DemandJ(string PersonalDString, string UsrMobileNo)
    {
        int result;
        DataSet ds = new DataSet();
        string[] StringArray = PersonalDString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < StringArray.Length; i += 13)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@DID",StringArray[i]),
                    new SqlParameter("@MobileNo",StringArray[i+1]),new SqlParameter("@Sector",StringArray[i+2]),
                    new SqlParameter("@JRole",StringArray[i+3]),new SqlParameter("@Experience",StringArray[i+4]),
                    new SqlParameter("@Salary",StringArray[i+5]),new SqlParameter("@State",StringArray[i+6]),
                    new SqlParameter("@District",StringArray[i+7]),new SqlParameter("@Taluka",StringArray[i+8]),
                    new SqlParameter("@Date",StringArray[i+9]),new SqlParameter("@IntrestedFor",StringArray[i+10]),
                    
                    new SqlParameter("@EntryDate", StringArray[i+11]), 
                    new SqlParameter("@UsrMobileNo", UsrMobileNo),
                };
            //Make tommarow Changes
            string s = "SELECT usrUserId from UserMaster where usrMobileNo='" + UsrMobileNo + "'";
            ds = cc.ExecuteDataset(s);
            string s1 = ds.Tables[0].Rows[0]["usrUserId"].ToString();
            string str1 = "update [Come2myCityDB].[come2mycity].[tbl_JDemandJob] set [MobileNo]='" + StringArray[i + 1].ToString() + "',[Sector]='" + StringArray[i + 2].ToString() + "',[JRole]='" + StringArray[i + 3].ToString() + "',[Experience]='" + StringArray[i + 4].ToString() + "',[Salary]='" + StringArray[i + 5].ToString() + "',[State]='" + StringArray[i + 6].ToString() + "',[District]='" + StringArray[i + 7].ToString() + "',[Taluka]='" + StringArray[i + 8].ToString() + "',[Date]='" + StringArray[i + 9].ToString() + "',[IntrestedFor]='" + StringArray[i + 10].ToString() + "',[EntryDate]='" + StringArray[i + 12].ToString() + "' where DID='" + StringArray[i] + "' and [UserId]='" + s1 + "'";
            result = cc.ExecuteNonQuery(str1);





            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                //int result = cmd.ExecuteNonQuery();
                //if (result != -1)
                //{
                //    i--;
                //    nonInsertedValues += StringArray[i].ToString();
                //    i++;
                //}
            }
            catch (SqlException ex)
            {

            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }


        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() + "*";
            return s + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    #endregion

    #region Insert Document Store
    [WebMethod]
    public string insertDocument(string DString)
     {
        string[] StringArray = DString.Split(new char[] { '*', '#' });
        string nonInsertedValues = string.Empty;
        try
        {
            for (int i = 0; i < StringArray.Length; i += 5)
            {
                SqlCommand cmd = new SqlCommand();
                SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
                cmd.Connection = con;

                cmd.Parameters.Add(new SqlParameter("@MobileNo", StringArray[i + 0].ToString()));
                cmd.Parameters.Add(new SqlParameter("@AadharNo", StringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DocumentName", StringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@DocumentImage", StringArray[i + 3].ToString()));

                cmd.CommandText = "[come2mycity].[uspInsertJDocumetStore]";
                cmd.CommandType = CommandType.StoredProcedure;

                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();

                int result = cmd.ExecuteNonQuery();

            }
        }
        catch (SqlException ex)
        {

        }
        catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string s = CommonCode.OK.ToString() ;
            return s;
            
        }
        else
            return nonInsertedValues;
    }
    #endregion

    #region DownLoadComboData
    [WebMethod(Description = "DownLoadComboData")]
    public string DownLoadAllComboData(string Keyword)
    {
        if (!string.IsNullOrEmpty(Keyword))
        {
            try
            {
                if (Keyword.Equals("ALL"))
                {
                    return AllDataSend();
                }
                else if (Keyword.Equals("10th"))
                {
                    return TenthData();
                }
                else if (Keyword.Equals("12th"))
                {
                    return TwelvethData();
                }
                else if (Keyword.Equals("GRADUATE"))
                {
                    return GraduateData();
                }
                else if (Keyword.Equals("PG"))
                {
                    return PGData();
                }
                else if (Keyword.Equals("Universities"))
                {
                    return University();
                }
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

    public string AllDataSend()
    {
        int count = 1;
        string returnString = string.Empty;
        try
        {
            string str = "select qualificationName,MainQulificationID from [Come2myCityDB].[dbo].[UserQualification]";
            DataSet ds = cc.ExecuteDataset(str);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    returnString += count++;
                    for (int col = 0; col < 2; col++)
                    {
                        returnString += "*" + ds.Tables[0].Rows[row][col];

                    }
                    returnString += "#";
                }
                return returnString;
            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }

    }
    public string TenthData()
    {
        string returnString = string.Empty;
        int count = 1;
        try
        {
            string str = "select qualificationName,MainQulificationID from [Come2myCityDB].[dbo].[UserQualification] where MainQulificationID='1'";
            DataSet ds = cc.ExecuteDataset(str);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                returnString += count++;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        returnString += "*" + ds.Tables[0].Rows[row][col];
                    }
                    returnString += "#";
                }
                return returnString;
            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }

    }
    public string TwelvethData()
    {
        string returnString = string.Empty;
        int count = 1;
        try
        {
            string str = "select qualificationName,MainQulificationID from [Come2myCityDB].[dbo].[UserQualification] where MainQulificationID='2'";
            DataSet ds = cc.ExecuteDataset(str);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                returnString += count++;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        returnString += "*" + ds.Tables[0].Rows[row][col];
                    }
                    returnString += "#";
                }
                return returnString;
            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }

    }
    public string GraduateData()
    {
        string returnString = string.Empty;
        int count = 1;
        try
        {
            string str = "select qualificationName,MainQulificationID from [Come2myCityDB].[dbo].[UserQualification] where MainQulificationID='3'";
            DataSet ds = cc.ExecuteDataset(str);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                returnString += count++;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        returnString += "*" + ds.Tables[0].Rows[row][col];
                    }
                    returnString += "#";
                }
                return returnString;
            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }

    }
    public string PGData()
    {
        string returnString = string.Empty;
        int count = 1;
        try
        {
            string str = "select qualificationName,MainQulificationID from [Come2myCityDB].[dbo].[UserQualification] where MainQulificationID='4'";
            DataSet ds = cc.ExecuteDataset(str);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                returnString += count++;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        returnString += "*" + ds.Tables[0].Rows[row][col];
                    }
                    returnString += "#";
                }
                return returnString;
            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }

    }

    public string University()
    {
        string returnString = string.Empty;
        int count = 1;
        try
        {
            string str = "select brduniName from [Come2myCityDB].[dbo].[UserBoardUniversity]";
            DataSet ds = cc.ExecuteDataset(str);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                returnString += count++;
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    for (int col = 0; col < 1; col++)
                    {
                        returnString += "*" + ds.Tables[0].Rows[row][col];
                    }
                    returnString += "#";
                }
                return returnString;
            }
            else
            {
                return CommonCode.NO_RECORD_FOUND.ToString();
            }
        }
        catch (SqlException ex)
        {
            return ex.Number.ToString();
        }
        catch (Exception ex)
        {
            return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
        }
    }
    #endregion

    #region DownloadSeach Data
    [WebMethod(Description = "DownloadSeach Data")]
    public XmlDocument SerachData(string keyword, string Value)
    {
        XmlDataDocument xmldata = new XmlDataDocument();
        DataSet ds = new DataSet();
        try
        {
            if (keyword == "CITY")
            {
                string s = Value.ToUpper();
                string str = "Select [PID],[CName],[JRole],[Qualification],[Skill],[JRequirment],[VaccancyTill],[SalaryOffered],[FreExp],[TrainingOffered],[City],[EntryDate] FROM [Come2myCityDB].[come2mycity].[tbl_JPostReq] where City='" + s + "'COLLATE SQL_Latin1_General_CP1_CS_AS";
                //string str = "Select [PID],[CName],[JRole],[Qualification],[Skill],[JRequirment],[VaccancyTill],[SalaryOffered],[FreExp],[TrainingOffered],[City],[EntryDate] FROM [Come2myCityDB].[come2mycity].[tbl_JPostReq] where City='" + Value + "'";
                ds = cc.ExecuteDataset(str);
            }
            else if (keyword == "COMPANY")
            {
                string str1 = "Select [PID],[CName],[JRole],[Qualification],[Skill],[JRequirment],[VaccancyTill],[SalaryOffered],[FreExp],[TrainingOffered],[City],[EntryDate] FROM [Come2myCityDB].[come2mycity].[tbl_JPostReq] where CName='" + Value + "'";
                ds = cc.ExecuteDataset(str1);
            }
            else if (keyword == "SKILL")
            {
                string str1 = "Select [PID],[CName],[JRole],[Qualification],[Skill],[JRequirment],[VaccancyTill],[SalaryOffered],[FreExp],[TrainingOffered],[City],[EntryDate] FROM [Come2myCityDB].[come2mycity].[tbl_JPostReq] where Skill='" + Value + "'";
                ds = cc.ExecuteDataset(str1);
            }

            xmldata = new XmlDataDocument(ds);
            XmlElement xmlele = xmldata.DocumentElement;

        }
        catch (Exception ex)
        {

        }
        return xmldata;

    }
    #endregion

    #region chklogin
    [WebMethod]
    public string chklogin(string user, string pwd)
    {
        string sql = "select usrPassword from UserMaster where usrMobileNo='" + user + "'";
        CommonCode cc = new CommonCode();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = sql;
        cmd.Connection = new SqlConnection("server=www.Come2myCity.com;User Id=Come2mycity; Password=myct2013;Min Pool Size=20; Max Pool Size=200;");
        if (cmd.Connection.State == ConnectionState.Closed)
        {
            cmd.Connection.Open();
        }
        string password = cmd.ExecuteScalar().ToString();
        password = cc.DESDecrypt(password);
        if (password == pwd)
        {
            return "1";
        }
        return "0";
    }

    [WebMethod]
    public XmlDocument userpersonalprofile(string mobileno, string keyword)
    {
        XmlDataDocument xmldata = new XmlDataDocument();
        try
        {
            DataSet ds;
            if (keyword == "MYPROFILE")
            {
                string sql = "select [EzeeDrugAppId],[firstName],[lastName],[mobileNo],[address],[eMailId],[pincode],[State],[District],[LadlineNo],[Village],[Taluka] FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where mobileNo='" + mobileno + "' and keyword='" + keyword + "'";
                ds = cc.ExecuteDataset(sql);
            }
            else if (keyword == "WORK-EXPERIENCE")
            {
                string sql = "select [ID],[FrmDate],[ToDate],[TotalExpYr],[TotalExpM],[JTitle],[CompName],[Salary],[FArea],[usrMobileNo],[usrDeviceId],[usrSimserialno] FROM [Come2myCityDB].[come2mycity].[tbl_JWorkExp] where usrMobileNo='" + mobileno + "'";
                ds = cc.ExecuteDataset(sql);
            }
            else if (keyword == "KEYSKILLS")
            {
                string sql = "SELECT [JID],[Skill],[usrMobileNo],[usrDeviceId],[usrSimserialno] FROM [Come2myCityDB].[come2mycity].[tbl_JSkill] where usrMobileNo='" + mobileno + "'";
                ds = cc.ExecuteDataset(sql);
            }
            else
            {
                string sql = "select * from [Come2myCityDB].[come2mycity].[tbl_JEducation] where [Keyword]='" + keyword + "' and [usrMobileNo]='" + mobileno + "'";
                ds = cc.ExecuteDataset(sql);
            }

            xmldata = new XmlDataDocument(ds);
            XmlElement xmlele = xmldata.DocumentElement;
        }
        catch (Exception ex)
        {

        }
        return xmldata;
    }
    #endregion

    #region Method for DropDown
    [WebMethod]
    public XmlDocument ComboValue(string keyword)
    {
        DataSet ds = new DataSet();
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {

            if (keyword == "DIVISIONS")
            {
                string str = "select [ID],[DivisionName] from [Come2myCityDB].[come2mycity].[tbl_JDivision]";
                ds = cc.ExecuteDataset(str);
            }
            else if (keyword == "UNIT")
            {
                string str = "select [ID],[UnitName] from [Come2myCityDB].[come2mycity].[tbl_JUnitName]";
                ds = cc.ExecuteDataset(str);
            }
            else if (keyword == "ROLE")
            {
                string str = "select [SID],[GroupID],[DID],[NameOfQP] FROM [Come2myCityDB].[come2mycity].[tbl_JSubDivisionNew]";
                ds = cc.ExecuteDataset(str);
            }

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        catch (Exception ex)
        {

        }
        return xmlData;
    }
    #endregion

    #region Method for DropDown
    [WebMethod]
    public XmlDocument ComboValueFroRole(string keyword, string DID)
    {
        DataSet ds = new DataSet();
        XmlDataDocument xmlData = new XmlDataDocument();
        try
        {

            if (keyword == "ROLE")
            {
                //string str = "select top 200 [SID],[GroupID],[DID],[NameOfQP] FROM [Come2myCityDB].[come2mycity].[tbl_JSubDivisionNew] where SID>='"+ID+"'";
                string str = "select  [SID],[GroupID],[DID],[NameOfQP] FROM [Come2myCityDB].[come2mycity].[tbl_JSubDivision] where DID='" + DID + "'";
                ds = cc.ExecuteDataset(str);
            }

            xmlData = new XmlDataDocument(ds);
            XmlElement xmlele = xmlData.DocumentElement;
        }
        catch (Exception ex)
        {

        }
        return xmlData;
    }
    #endregion

    #region Method for Get Feedback Details

    [WebMethod(Description = "Method to Get Feedback of Users")]
    public int getFeedbackDetails(string firstName, string lastName, string userMobNo, string imei, string typeOfFeedback, string feedbackContent, DateTime date)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "uspInsertJFeedbackDetails";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlParameter[] parameter = new SqlParameter[]
        {
            new SqlParameter("@firstName",firstName),
            new SqlParameter("@lastName",lastName),
            new SqlParameter("@userMobNo",userMobNo),
            new SqlParameter("@imei",imei),
            new SqlParameter("@typeOfFeedback",typeOfFeedback),
            new SqlParameter("@feedbackContent",feedbackContent),
            new SqlParameter("@feedbackDate",date) 
        };
        cmd.Parameters.AddRange(parameter);
        cmd.Connection.Open();
        int status = cmd.ExecuteNonQuery();
        cmd.Connection.Close();

        return status;

    }
    #endregion

    [WebMethod]
    public XmlDocument MarketingData(String RefralMobNo)
    {
        string s = string.Empty;
        string keyword = string.Empty;
        XmlDataDocument xmldata = new XmlDataDocument();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();


        string str2 = "select [ID],[Parent_MobileNo],[Child_MobileNo],[ParentName],[ChildName],[ProjectName],[Role] FROM [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] where Parent_MobileNo='" + RefralMobNo + "'";
        ds = cc.ExecuteDataset(str2);


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

            ds.Tables.Add(dt);
            xmldata = new XmlDataDocument(ds);
            XmlElement xmlelement = xmldata.DocumentElement;
            return xmldata;
        }


    }
}


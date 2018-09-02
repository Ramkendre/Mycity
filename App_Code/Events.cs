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
/// Summary description for Events
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Events : System.Web.Services.WebService
{
    CommonCode cc = new CommonCode();
    public Events()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //[WebMethod]
    //public string HelloWorld()
    //{
    //    return "Hello World";
    //}
    [WebMethod(Description = "Event")]
    public string InsertData(string keyWord, string eventString, string usereNumber)
    {
        int i;
        //if (!string.IsNullOrEmpty(eventString) && !string.IsNullOrEmpty(keyWord))

        if (eventString != "" && keyWord != null)
        {
            try
            {
                if (keyWord.Equals("BIRTHDAY"))
                {
                    return BirthDate2(eventString, usereNumber);
                }
                else if (keyWord.Equals("NEWS"))
                {
                    return News(eventString, usereNumber);
                }
                else if (keyWord.Equals("DEATH"))
                {
                    return Death(eventString, usereNumber);
                }
                else if (keyWord.Equals("MEETING"))
                {
                    return Meeting(eventString, usereNumber);
                }
                else if (keyWord.Equals("MARRIAGE"))
                {
                    return Marriage(eventString, usereNumber);
                }
                else if (keyWord.Equals("COMPLAINT"))
                {
                    return Complaints(eventString, usereNumber);
                }
                else if (keyWord.Equals("FOLLOWUP"))
                {
                    return ComplaintFollowup(eventString, usereNumber);
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

    private string BirthDate2(string birthEvent, string usereNumber)
    {
        DataSet ds = new DataSet();
        string[] stringArray = birthEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 11)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
           
            sqlCommand.Parameters.Add(new SqlParameter("@name", stringArray[i + 1].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@mobleNumber", stringArray[i + 2].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@date", stringArray[i + 3].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@gender", stringArray[i + 4].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@smes", stringArray[i + 5].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@mdiscription", stringArray[i + 6].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@RemDate", stringArray[i + 7].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@time", stringArray[i + 8].ToString()));
            sqlCommand.Parameters.Add(new SqlParameter("@usereNumber", usereNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@CurrentDate", stringArray[i + 9].ToString()));
            if (stringArray[i].ToString() == "0")
            {
                SqlParameter pass = new SqlParameter("@rid", SqlDbType.NVarChar, 50);
                pass.Direction = ParameterDirection.Output;
                
                sqlCommand.Parameters.Add(pass);
                sqlCommand.CommandText = "sp_Ebirthday";
            }
            else
            {
                sqlCommand.Parameters.Add(new SqlParameter("@BID", stringArray[i]));
                sqlCommand.CommandText = "[sp_UEbirthday]";
            }
            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();
            try
            {
                int result = sqlCommand.ExecuteNonQuery();
                string str = "";
                if (stringArray[i].ToString() == "0")
                {
                    str = sqlCommand.Parameters["@rid"].Value.ToString();
                    nonInsertedValues1 += str + "*";
                    //nonInsertedValues += CommonCode.OK.ToString() + "*" ;
                }
                //else
                //    str = CommonCode.OK.ToString();

                if (result != 1)
                {
                    i--;
                    nonInsertedValues += CommonCode.FAIL.ToString() + "*";
                    i++;
                }
                //else
                //{
                //    nonInsertedValues += str + "*";
                //}


            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    sqlCommand.CommandText = "[sp_UEbirthday]";
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result != 1)
                    {
                        i--;
                        nonInsertedValues += stringArray[i].ToString() + "*";
                        i++;
                    }
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            
            return nonInsertedValues;
    }

   

    private string Death(string deathEvent, string LoginMobileNo)
    {
        string[] stringArray = deathEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
          int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 12)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i] == "0")
            {
                
                cmd.Parameters.Add(new SqlParameter("@NameOfAccused",stringArray[i+1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Date",stringArray[i+2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Time",stringArray[i+3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Location",stringArray[i+4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@SDescp",stringArray[i+5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Relative",stringArray[i+6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Relation",stringArray[i+7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PVisit",stringArray[i+8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MDescp",stringArray[i+9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo",LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@CurrentDate", stringArray[i + 10].ToString()));
                
                
                cmd.CommandText = "sp_Edeath";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(DID) from [Come2myCityDB].[dbo].[tbl_EventDeath] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[]
                {
                    new SqlParameter("@DID",stringArray[i]),
                    new SqlParameter("@NameOfAccused",stringArray[i+1]),new SqlParameter("@Date",stringArray[i+2]),
                    new SqlParameter("@Time",stringArray[i+3]),new SqlParameter("@Location",stringArray[i+4]),
                    new SqlParameter("@SDescp",stringArray[i+5]),new SqlParameter("@Relative",stringArray[i+6]),
                    new SqlParameter("@Relation",stringArray[i+7]),new SqlParameter("@PVisit",stringArray[i+8]),
                     new SqlParameter("@MDescp",stringArray[i+9]),new SqlParameter("@LoginMobileNo",LoginMobileNo),
                     new SqlParameter("@CurrentDate",stringArray[i+10])   
                };
                cmd.Parameters.AddRange(par);
                cmd.CommandText = "[sp_UEDeath]";
                cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {

                
                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEDeath]";
                   result = cmd.ExecuteNonQuery();

                    if (result != 1)
                    {
                        i--;
                        nonInsertedValues += stringArray[i].ToString() + "*";
                        i++;
                    }
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
    }
    private string News(string marriageEvent, string LoginMobileNo)
    {
        string[] stringArray = marriageEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        int result;
        string nonInsertedValues1 = string.Empty;
        for (int i = 1; i < stringArray.Length; i += 12)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {

                cmd.Parameters.Add(new SqlParameter("@NewsHead ", stringArray[i + 1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@NewsDetails", stringArray[i + 2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@NPaper ", stringArray[i + 3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Role", stringArray[i + 4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Date", stringArray[i + 5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Time", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@TypeOfNews", stringArray[i + 7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Location", stringArray[i + 8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Feedback", stringArray[i + 9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@CurrentDate", stringArray[i + 10].ToString()));

                cmd.CommandText = "sp_Enews";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(NID) from [Come2myCityDB].[dbo].[tbl_EventNews] ";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] par = new SqlParameter[] 
            {
                new SqlParameter("@NID",stringArray[i].ToString()),
                new SqlParameter("@NewsHead ",stringArray[i+1].ToString()),new SqlParameter("@NewsDetails",stringArray[i+2].ToString()),
                new SqlParameter("@NPaper ",stringArray[i+3].ToString()),new SqlParameter("@Role",stringArray[i+4].ToString()),
                new SqlParameter("@Date",stringArray[i+5].ToString()),new SqlParameter("@Time",stringArray[i+6].ToString()),
                new SqlParameter("@TypeOfNews",stringArray[i+7].ToString()), new SqlParameter("@Location",stringArray[i+8].ToString()),
                new SqlParameter("@Feedback",stringArray[i+9].ToString()),new SqlParameter("@LoginMobileNo",LoginMobileNo),
                new SqlParameter("@CurrentDate",stringArray[i+10].ToString()),
            };
                cmd.Parameters.AddRange(par);
                cmd.CommandText = "[sp_UEnews]";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
               result = cmd.ExecuteNonQuery();
            }


            try
            {

                if (result!= 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEnews]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery();
                    if (result != 1)
                    {
                        i--;
                        nonInsertedValues += stringArray[i].ToString() + "*";
                        i++;
                    }
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    public string Meeting(string meetingEvent, string LoginMobileNo)
    {
        string[] stringArray = meetingEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 14)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@ETitle",stringArray[i+1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MeetingType",stringArray[i+2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Location",stringArray[i+3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@FrmDate",stringArray[i+4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@FrmTime",stringArray[i+5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UptoDate", stringArray[i + 6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@UptoTime",stringArray[i+7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Descp",stringArray[i+8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RemDate",stringArray[i+9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RemTime",stringArray[i+10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RepRemainder",stringArray[i+11].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo",LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@CurrentDate",stringArray[i+12].ToString()));
                
                
                cmd.CommandText = "sp_Emeeting";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_EventMeeting]";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";

            }
            else
            {
                SqlParameter[] par = new SqlParameter[] 
                {
                    new SqlParameter("@ID",stringArray[i].ToString()),
                    new SqlParameter("@ETitle",stringArray[i+1].ToString()), new SqlParameter("@MeetingType",stringArray[i+2].ToString()),
                    new SqlParameter("@Location",stringArray[i+3].ToString()),
                    new SqlParameter("@FrmDate",stringArray[i+4].ToString()),
                    new SqlParameter("@FrmTime",stringArray[i+5].ToString()), 
                    new SqlParameter("@UptoDate",stringArray[i+6].ToString()),
                    new SqlParameter("@UptoTime",stringArray[i+7].ToString()), new SqlParameter("@Descp",stringArray[i+8].ToString()),
                    new SqlParameter("@RemDate",stringArray[i+9].ToString()), new SqlParameter("@RemTime",stringArray[i+10].ToString()),
                    new SqlParameter("@RepRemainder",stringArray[i+11].ToString()), new SqlParameter("@LoginMobileNo",LoginMobileNo),
                    new SqlParameter("@CurrentDate",stringArray[i+12].ToString()),
                 };
                cmd.Parameters.AddRange(par);
                cmd.CommandText = "[sp_UEmeeting]";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                
            }

           
            try
            {

               
                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }

            }

            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEmeeting]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery();
                    if (result != 1)
                    {
                        i--;
                        nonInsertedValues += stringArray[i].ToString() + "*";
                        i++;
                    }
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;

    }
    public string Marriage(string marriageEvent, string LoginMobileNo)
    {
        string[] stringArray = marriageEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 15)
        {

            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@BrideName",stringArray[i+1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@GroomName",stringArray[i+2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@InvitionFrom",stringArray[i+3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Date",stringArray[i+4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Time",stringArray[i+5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Location",stringArray[i+6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PersonName",stringArray[i+7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MobileNumber",stringArray[i+8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@PVisit",stringArray[i+9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MDescp",stringArray[i+10].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RemDate",stringArray[i+11].ToString()));
                cmd.Parameters.Add(new SqlParameter("@RemTime",stringArray[i+12].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo",LoginMobileNo));
                cmd.Parameters.Add(new SqlParameter("@CurrentDate",stringArray[i+13].ToString()));

                
                cmd.CommandText = "sp_Emarriage";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                 result = cmd.ExecuteNonQuery();
                string str = "select max(Id) from [Come2myCityDB].[dbo].[tbl_EventMyCt]";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";

            }
            else
            {
                SqlParameter[] par = new SqlParameter[] 
                {
                    new SqlParameter("@Id",stringArray[i].ToString()),
                    new SqlParameter("@BrideName",stringArray[i+1].ToString()),new SqlParameter("@GroomName",stringArray[i+2].ToString()),
                    new SqlParameter("@InvitionFrom",stringArray[i+3].ToString()),new SqlParameter("@Date",stringArray[i+4].ToString()),
                    new SqlParameter("@Time",stringArray[i+5].ToString()),new SqlParameter("@Location",stringArray[i+6].ToString()),
                    new SqlParameter("@PersonName",stringArray[i+7].ToString()),new SqlParameter("@MobileNumber",stringArray[i+8].ToString()),
                    new SqlParameter("@PVisit",stringArray[i+9].ToString()),
                    new SqlParameter("@MDescp",stringArray[i+10].ToString()),new SqlParameter("@RemDate",stringArray[i+12].ToString()),
                    new SqlParameter("@RemTime",stringArray[i+11].ToString()),new SqlParameter("@LoginMobileNo",LoginMobileNo),
                    new SqlParameter("@CurrentDate",stringArray[i+13].ToString()),
                };
                cmd.CommandText = "[sp_UEmarriage]";
                cmd.Parameters.AddRange(par);
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
            }

          
            try
            {
               
                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "[sp_UEmarriage]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery();
                    if (result != 1)
                    {
                        i--;
                        nonInsertedValues += stringArray[i].ToString() + "*";
                        i++;
                    }
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }
        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string str3 = CommonCode.OK.ToString() + "*";
            return str3 + nonInsertedValues1;
        }
        else
        {
            return nonInsertedValues;
        }
    }
    public string Complaints(string complaintsEvent, string LoginMobileNo)
    {
        int i = 1;
        DataSet ds = new DataSet();
        string[] stringArray = complaintsEvent.Split(new char[] { '#', '*' });
        string NonInsertedValue = string.Empty;
        string NonInsertedValue1 = string.Empty;
        int result;
        for (i = 1; i < stringArray.Length; i += 11)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@CompType",stringArray[i+1].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Date",stringArray[i+2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@CompSub",stringArray[i+3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@CompDetails",stringArray[i+4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@CompFDept",stringArray[i+5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@CompName",stringArray[i+6].ToString()));
                cmd.Parameters.Add(new SqlParameter("@MobileNo",stringArray[i+7].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Address",stringArray[i+8].ToString()));
                cmd.Parameters.Add(new SqlParameter("@CurrentDate",stringArray[i+9].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo",LoginMobileNo)); 
                cmd.CommandText = "sp_EComplaint";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(CID) from [Come2myCityDB].[dbo].[tbl_EventComplaint]";
                string str1 = cc.ExecuteScalar(str);
                NonInsertedValue1 += str1 + "*";

            }
            else
            {
                SqlParameter[] par = new SqlParameter[] 
            { 
               new SqlParameter("@CID",stringArray[i]),
                new SqlParameter("@CompType",stringArray[i+1].ToString()),new SqlParameter("@Date",stringArray[i+2].ToString()),new SqlParameter("@CompSub",stringArray[i+3].ToString()),
                new SqlParameter("@CompDetails",stringArray[i+4].ToString()),new SqlParameter("@CompFDept",stringArray[i+5].ToString()),
                new SqlParameter("@CompName",stringArray[i+6].ToString()),new SqlParameter("@MobileNo",stringArray[i+7].ToString()),
                new SqlParameter("@Address",stringArray[i+8].ToString()),new SqlParameter("@CurrentDate",stringArray[i+9].ToString()),
                new SqlParameter("@LoginMobileNo",LoginMobileNo),
            };

                cmd.Parameters.AddRange(par);
                cmd.CommandText = "sp_UEComplaint";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
               result = cmd.ExecuteNonQuery();

            }



            
            try
            {
                
                if (result != 1)
                {
                    i--;
                    NonInsertedValue += stringArray[i].ToString() + "*";
                    i++;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    cmd.CommandText = "sp_UEComplaint";
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery();
                    if (result != 1)
                    {
                        i--;
                        NonInsertedValue += stringArray[i] + "*";
                        i++;
                    }
                }
                else
                {
                    return ex.Number.ToString();
                }
            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }



        }


        if (string.IsNullOrEmpty(NonInsertedValue))
        {

            //return NonInsertedValue;
            string str3 = CommonCode.OK.ToString() + "*";
            return str3 + NonInsertedValue1;




        }
        else
        {
            return NonInsertedValue;
        }

    }

    public string ComplaintFollowup(string followupEvent, string LoginMobileNo)
    {
        string[] stringArray = followupEvent.Split(new char[] { '#', '*' });
        string NonInsertedValue = string.Empty;
        string NonInsertedValue1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 7)
        {

            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {
                cmd.Parameters.Add(new SqlParameter("@CID",stringArray[i+1]));
                cmd.Parameters.Add(new SqlParameter("@Date",stringArray[i+2].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Remark",stringArray[i+3].ToString()));
                cmd.Parameters.Add(new SqlParameter("@Status",stringArray[i+4].ToString()));
                cmd.Parameters.Add(new SqlParameter("@CurrentDate",stringArray[i+5].ToString()));
                cmd.Parameters.Add(new SqlParameter("@LoginMobileNo",LoginMobileNo));
                
                cmd.CommandText = "[dbo].[sp_Efollowup]";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                string str = "select max(CFID) from [Come2myCityDB].[dbo].[tbl_ECFollowUp]";
                string str1 = cc.ExecuteScalar(str);
                NonInsertedValue1 = str1 + "*";

            }
            else
            {
                SqlParameter[] par = new SqlParameter[] 
                {
                    new SqlParameter("@CFID",stringArray[i]),
                    new SqlParameter("@CID",stringArray[i+1]),
                    new SqlParameter("@Date",stringArray[i+2].ToString()),
                    new SqlParameter("@Remark",stringArray[i+3].ToString()),new SqlParameter("@Status",stringArray[i+4].ToString()),
                    new SqlParameter("@CurrentDate",stringArray[i+5].ToString()),new SqlParameter("@LoginMobileNo",LoginMobileNo),
                };
                cmd.Parameters.AddRange(par);
                cmd.CommandText = "sp_UEFollowUp";
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                 result = cmd.ExecuteNonQuery();
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            try
            {
                
                if (result != 1)
                {
                    i--;
                    NonInsertedValue += stringArray[i].ToString() + "*";
                    i++;
                }
            }
            catch (SqlException ex)
            {
                //if(ex.Number==2627)
                //{
                //    cmd.CommandText = "";
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    int result = cmd.ExecuteNonQuery();
                //    if (result != 1)
                //    {
                //        i--;
                //        NonInsertedValue += stringArray[i] + "*";
                //        i++;
                //    }
                //}
                //else
                //{
                return ex.Number.ToString();
                //}
            }
            catch (Exception ex)
            {
                return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString();
            }

        }

        if (string.IsNullOrEmpty(NonInsertedValue))
        {

            string sql = CommonCode.OK.ToString() + "*";
            return sql + NonInsertedValue1;



        }
        else
        {
            return NonInsertedValue;
        }

    }


    [WebMethod(Description = "Upload Image")]
    public string UploadImage(int ID, string imgString, string EventType, string mobileno, string EntryDate)
    {
        string Data = "0";
        try
        {

            if (imgString != "" && imgString != null)
            {
                string str = "select usrUserId from UserMaster where usrMobileNo='" + mobileno + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(str);
                string s = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string sql = "insert into [come2mycity].[tbl_EventImage](EID,ImgString,EventType,MobileNo,UserId,Status,EntryDate)values('" + ID + "','" + imgString + "','" + EventType + "','" + mobileno + "','" + s + "','0','"+EntryDate+"')";
                int result = cc.ExecuteNonQuery(sql);
                return Data = "1";
            }
            else
            {
                return Data = "0";
            }
        }
        catch (Exception ex)
        { }
        return Data;
    }
    [WebMethod(Description = "Download Image")]
    public string DownloadImage(string EventType, string mobileno)
    {
        int count = 1;
        try
        {
        string str = "select usrUserId from UserMaster where usrMobileNo='" + mobileno + "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str);
        string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
        string s = "Select EID,EventType,ImgString,EntryDate FROM [Come2myCityDB].[come2mycity].[tbl_EventImage] where UserId='" + str1 + "' and EventType='" + EventType + "' and Status='0'";
        ds = cc.ExecuteDataset(s);

                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string u = "update [Come2myCityDB].[come2mycity].[tbl_EventImage] set Status='1' where UserId='" + str1 + "' and EventType='" + EventType + "'";
                    int i = cc.ExecuteNonQuery(u);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 3; cols++)
                        {
                            if (cols != 3)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                            }
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
                //return "Shweta";
            }
      }
    [WebMethod(Description = "Child Image")]
    public string DownloadChildImage(string keyword,string RefMobileNo)
    {
        DataSet ds = new DataSet();
        int count = 1;
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(keyword))
        {
        try
        {
            string str =
                     " with Event as( " +
                     " select *from( " +
                     " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                     " inner join " +
                     " [Come2myCityDB].[come2mycity].[tbl_EventImage] as table2 " +
                     " on " +
                     " table1.uid=table2.UserId " +
                     " ) " +
                     " ) ";
            str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],[EID],[EventType],[ImgString],EntryDate,UserId from Event where Status='0'";
            ds = cc.ExecuteDataset(str);

            if(ds!=null && ds.Tables[0].Rows.Count!=0)
            {
                string returnString = string.Empty;
                string header = string.Empty;
                string userid = string.Empty;
                for (int row = 0; row < ds.Tables[0].Rows.Count;row++ )
                {
                    if(row==0)
                    {
                        userid=ds.Tables[0].Rows[row][11].ToString();
                        header = "$" + ds.Tables[0].Rows[row][0].ToString() + '*' + ds.Tables[0].Rows[row][1].ToString() + '*' +
                                  ds.Tables[0].Rows[row][2].ToString() + '*' + ds.Tables[0].Rows[row][3].ToString() + '*' +
                                  ds.Tables[0].Rows[row][4].ToString() + '*' + ds.Tables[0].Rows[row][5].ToString() + '*' +
                                  ds.Tables[0].Rows[row][6].ToString() + "!";

                        returnString = header + returnString;
                    }
                    else 
                    {
                        if (!ds.Tables[0].Rows[row][11].ToString().Equals(userid))
                        {
                            userid = ds.Tables[0].Rows[row][11].ToString();
                            header = "$" + ds.Tables[0].Rows[row][0].ToString() + '*' + ds.Tables[0].Rows[row][1].ToString() + '*' +
                                      ds.Tables[0].Rows[row][2].ToString() + '*' + ds.Tables[0].Rows[row][3].ToString() + '*' +
                                      ds.Tables[0].Rows[row][4].ToString() + '*' + ds.Tables[0].Rows[row][5].ToString() + '*' +
                                      ds.Tables[0].Rows[row][6].ToString() + "!";

                            returnString = header + returnString;
                        }
                    }

                    
                        string str4 = "Update [Come2myCityDB].[come2mycity].[tbl_EventImage] set Status='1' where UserId='" + ds.Tables[0].Rows[row][11].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);
                         returnString += count++;
                        for (int col = 7; col < 11; col++)
                        {

                            if (col != 11)
                            {
                                returnString += "*" + ds.Tables[0].Rows[row][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[row][col].ToString();
                            //returnString += count++;
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

        else
            return CommonCode.WRONG_INPUT.ToString();

    }

    
    

    #region sendData
    [WebMethod(Description = "Send Data")]
    public string SendData(string keyWord, String LoginMobileNo)
    {

        int i;
        if (!string.IsNullOrEmpty(keyWord) && !string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                if (keyWord.Equals("BIRTHDAY"))
                {
                    return BirthdaySend(LoginMobileNo);
                }
                else if (keyWord.Equals("NEWS"))
                {
                    return NewsSend(LoginMobileNo);
                }
                else if (keyWord.Equals("DEATH"))
                {
                    return DeathSend(LoginMobileNo);
                }
                else if (keyWord.Equals("MEETING"))
                {
                    return MeetingSend(LoginMobileNo);
                }
                else if (keyWord.Equals("MARRIAGE"))
                {
                    return MarriageSend(LoginMobileNo);
                }
                else if (keyWord.Equals("COMPLAINT"))
                {
                    return ComplaintSend(LoginMobileNo);
                }
                else if (keyWord.Equals("FOLLOWUP"))
                {
                    return ComplaintFollowupSend(LoginMobileNo);
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



    public string BirthdaySend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {

            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str1);
                string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                string str = "Select BID,NameOfPerson,MobileNo,BirthDate,Gender,SMsg,MDescp,RemDate,Time,CurrentDate,UserId,Status1 from tbl_EBirthday where UserId='" + str2 + "' and Status1='0'  ";

                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    string str4 = "Update tbl_EBirthday set Status1='1',Status2='0' where UserId='" + str2 + "' ";
                    int i = cc.ExecuteNonQuery(str4);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;

                        for (int col = 0; col < 10; col++)
                        {
                            if (col != 10)
                            {

                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

                                //returnString += count++;
                            }

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
        else
            return CommonCode.WRONG_INPUT.ToString();

    }
    public string NewsSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

                string str2 = "select NID,NewsHead,NewsDetails,NPaper,Role,Date,Time,TypeOfNews,Location,Feedback,UserId,Status1 from tbl_EventNews where UserId='" + str1 + "' and Status1='0'";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string str3 = "update tbl_EventNews set Status1='1',Status2='0' where UserId='" + str1 + "'";
                    int i = cc.ExecuteNonQuery(str3);
                    string returnstring = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnstring += count++;
                        for (int col = 0; col < 11; col++)
                        {
                            if (col != 10)
                            {
                                returnstring += ds.Tables[0].Rows[rows][col].ToString() + "*";
                            }
                            else
                            {
                                returnstring += ds.Tables[0].Rows[rows][col].ToString();
                                //returnstring += count++;
                            }

                        }
                        returnstring += "#";
                    }
                    return returnstring;
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }

    }

    public string DeathSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "' ";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string str2 = "select DID,NameOfAccused,Date,Time,Location,SDescp,Relative,Relation,PVisit,UserId,Status1 from [Come2myCityDB].[dbo].[tbl_EventDeath] where Status1='0' and UserId='" + str1 + "'";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string str4 = "update [Come2myCityDB].[dbo].[tbl_EventDeath] set Status1='1' where UserId='" + str1 + "'";
                    int result = cc.ExecuteNonQuery(str4);
                    string returnString = string.Empty;
                    for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                    {
                        returnString += count++;
                        for (int col = 0; col < 10; col++)
                        {
                            if (col != 9)
                            {
                                returnString += ds.Tables[0].Rows[row][col].ToString() + "*";
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[row][col].ToString();
                                //returnString += count++;
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string MeetingSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string str2 = "select ID,ETitle,MeetingType,Location,FrmDate,FrmTime,UptoDate,UptoTime,Descp,RemDate,RemTime,RepRemainder,UserId,CurrentDate,Status1 from [Come2myCityDB].[dbo].[tbl_EventMeeting] where UserId='" + str1 + "' and Status1='0'";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    string str3 = "update [Come2myCityDB].[dbo].[tbl_EventMeeting] set Status1='1' where UserId='" + str1 + "'";
                    int result = cc.ExecuteNonQuery(str3);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 13; cols++)
                        {
                            if (cols != 12)
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString() + "*";
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                                //returnString += count++;
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string MarriageSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string str2 = "select Id,BrideName,GroomName,InvitionFrom,Date,Time,Location,PersonName,MobileNumber,PVisit,MDescp,RemDate,RemTime,CurrentDate,MyCt_UserId,Status1 from [Come2myCityDB].[dbo].[tbl_EventMyCt] where MyCt_UserId='" + str1 + "'and Status1='0' ";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string str3 = "Update [Come2myCityDB].[dbo].[tbl_EventMyCt] set Status1='1' where MyCt_UserId='" + str1 + "'";
                    int result = cc.ExecuteNonQuery(str3);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 13; cols++)
                        {
                            if (cols != 13)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                                //returnString += count++;
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string ComplaintSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string str2 = "select CID,CompType,Date,CompSub,CompDetails,CompFDept,CompName,MobileNo,Address,CurrentDate,UserId,Status1 from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='" + str1 + "' and Status1='0'";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string str3 = "update [Come2myCityDB].[dbo].[tbl_EventComplaint] set Status1='1' where UserId='" + str1 + "' ";
                    int s = cc.ExecuteNonQuery(str3);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 10; cols++)
                        {
                            if (cols != 10)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string ComplaintFollowupSend(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                //string str4 = "select CID from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='"+str1+"'";
                //ds = cc.ExecuteDataset(str4);
                string str2 = "select CID,Date,Remark,Status,CurrentDate,UserId,Status1 from [Come2myCityDB].[dbo].[tbl_ECFollowUp] where UserId='" + str1 + "' and Status1='0'";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string str3 = "update [Come2myCityDB].[dbo].[tbl_ECFollowUp] set Status1='1' where UserId='" + str1 + "' ";
                    int s = cc.ExecuteNonQuery(str3);
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        count++;
                        for (int cols = 0; cols < 5; cols++)
                        {
                            if (cols != 5)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
#endregion

    #region Download All Data
    [WebMethod(Description = "Download All Data")]
    public string DownloadAllData(string keyWord, string LoginMobileNo)
    {
        int i;
        if (!string.IsNullOrEmpty(LoginMobileNo) && !string.IsNullOrEmpty(keyWord))
        {
            try
            {
                if (keyWord.Equals("BIRTHDAY"))
                {
                    return BirthdaySendAll(LoginMobileNo);
                }
                else if (keyWord.Equals("NEWS"))
                {
                    return NewsSendAll(LoginMobileNo);
                }
                else if (keyWord.Equals("DEATH"))
                {
                    return DeathSendAll(LoginMobileNo);
                }
                else if (keyWord.Equals("MEETING"))
                {
                    return MeetingSendAll(LoginMobileNo);
                }
                else if (keyWord.Equals("MARRIAGE"))
                {
                    return MarriageSendAll(LoginMobileNo);
                }
                else if (keyWord.Equals("COMPLAINT"))
                {
                    return ComplaintSendAll(LoginMobileNo);
                }
                else if (keyWord.Equals("FOLLOWUP"))
                {
                    return ComplaintFollowupSendAll(LoginMobileNo);
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

    public string BirthdaySendAll(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string str2 = "Select BID,NameOfPerson,MobileNo,BirthDate,Gender,SMsg,MDescp,RemDate,Time,CurrentDate,UserId from tbl_EBirthday where UserId='" + str1 + "'";
                ds = cc.ExecuteDataset(str2);

                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 10; cols++)
                        {
                            if (cols != 10)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }

    public string NewsSendAll(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string sql = "select NID,NewsHead,NewsDetails,NPaper,Role,Date,Time,TypeOfNews,Location,Feedback,CurrentDate,UserId from tbl_EventNews where UserId='" + str1 + "'";
                ds = cc.ExecuteDataset(sql);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 11; cols++)
                        {
                            if (cols != 11)
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            else
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();

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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }

    }
    public string DeathSendAll(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string str2 = "select DID,NameOfAccused,Date,Time,Location,SDescp,Relative,Relation,PVisit,MDescp,CurrentDate,UserId,Status1 from [Come2myCityDB].[dbo].[tbl_EventDeath] where UserId='" + str1 + "'";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 11; cols++)
                        {
                            if (cols != 12)
                                returnString += "*" + ds.Tables[0].Rows[rows][cols];
                            else
                                returnString += ds.Tables[0].Rows[rows][cols];
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string MeetingSendAll(string LoginMobileNo)
    {

        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string sql = "select ID,ETitle,MeetingType,Location,FrmDate,FrmTime,UptoDate,UptoTime,Descp,RemDate,RemTime,RepRemainder,CurrentDate,UserId,Status1 from [Come2myCityDB].[dbo].[tbl_EventMeeting] where UserId='" + str1 + "' ";
                ds = cc.ExecuteDataset(sql);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 13; cols++)
                        {
                            if (cols != 13)
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            else
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string MarriageSendAll(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                DataSet ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string sql = "select Id,BrideName,GroomName,InvitionFrom,Date,Time,Location,PersonName,MobileNumber,PVisit,MDescp,RemDate,RemTime,CurrentDate,MyCt_UserId,Status1 from [Come2myCityDB].[dbo].[tbl_EventMyCt] where MyCt_UserId='" + str1 + "' ";
                ds = cc.ExecuteDataset(sql);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 14; cols++)
                        {
                            if (cols != 15)
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            else
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }

    }
    public string ComplaintSendAll(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                string str2 = "select CID,CompType,Date,CompSub,CompDetails,CompFDept,CompName,MobileNo,Address,CurrentDate,UserId,Status1 from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='" + str1 + "' ";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 10; cols++)
                        {
                            if (cols != 10)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string ComplaintFollowupSendAll(string LoginMobileNo)
    {
        if (!string.IsNullOrEmpty(LoginMobileNo))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str = "select usrUserId from UserMaster where usrMobileNo='" + LoginMobileNo + "'";
                ds = cc.ExecuteDataset(str);
                string str1 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);
                //string str4 = "select CID from [Come2myCityDB].[dbo].[tbl_EventComplaint] where UserId='"+str1+"'";
                //ds = cc.ExecuteDataset(str4);
                string str2 = "select CFID,CID,Date,Remark,Status,CurrentDate,UserId,Status1 from [Come2myCityDB].[dbo].[tbl_ECFollowUp] where UserId='" + str1 + "'";
                ds = cc.ExecuteDataset(str2);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        returnString += count++;
                        for (int cols = 0; cols < 6; cols++)
                        {
                            if (cols != 6)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][cols].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][cols].ToString();
                            }
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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    #endregion

    #region Download Child Data
    [WebMethod(Description = "Download Child Data")]
    public string DownloadData(string keyWord, String RefMobileNo, string CurrentDate)
    {

        int i;
        if (!string.IsNullOrEmpty(keyWord) && !string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {
            try
            {
                if (keyWord.Equals("BIRTHDAY"))
                {
                    return BirthdaySend(RefMobileNo, CurrentDate);
                }
                else if (keyWord.Equals("NEWS"))
                {
                    return NewsSend(RefMobileNo, CurrentDate);
                }
                else if (keyWord.Equals("DEATH"))
                {
                    return DeathSend(RefMobileNo, CurrentDate);
                }
                else if (keyWord.Equals("MEETING"))
                {
                    return MeetingSend(RefMobileNo, CurrentDate);
                }
                else if (keyWord.Equals("MARRIAGE"))
                {
                    return MarriageSend(RefMobileNo, CurrentDate);
                }
                else if (keyWord.Equals("COMPLAINT"))
                {
                    return ComplaintSend(RefMobileNo, CurrentDate);
                }
                else if (keyWord.Equals("FOLLOWUP"))
                {
                    return FollowUpSend(RefMobileNo, CurrentDate);
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
    public string BirthdaySend(string RefMobileNo, string CurrentDate)
    {
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                //string str =
                //  "with asd as(" +
                //  " select *from( " +
                //  " select Table1.mobileNo as m, UserId as uid from(select mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where RefMobileNo='" + RefMobileNo + "' and keyword='EZEEPLANNER')as Table1 " +
                //  " inner join " +
                //  " [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] as Table2 " +
                //  " on " +
                //  " Table1.mobileNo=Table2.mobileNo " +
                //  " )as Table3 " +
                //  " left outer join " +
                //  " tbl_EBirthday " +
                //  " on " +
                //  " Table3.uid=tbl_EBirthday.UserId) ";
                //if (!CurrentDate.Equals("0"))
                //    str += " select NameOfPerson,MobileNo,BirthDate,Time,Gender,SMsg,MDescp,UserId,CurrentDate from asd where Status2='0' and CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "')";

                //string str =
                //    " with Event as( " +
                //    " select *from( " +
                //    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                //    " inner join " +
                //    " [Come2myCityDB].[dbo].[tbl_EBirthDay] as table2 " +

                //    " on " +
                //    " table1.uid=table2.[UserId] " +
                //    " ) " +
                //    " ) ";
                //str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],BID,NameOfPerson,MobileNo,BirthDate,Gender,SMsg,MDescp,RemDate,Time,CurrentDate,UserId from Event where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "')) order by UserId";

                //string str =
                //    " with Event as( " +
                //    " select *from( " +
                //    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                //    " inner join " +
                //    " [Come2myCityDB].[dbo].[tbl_EBirthDay] as table2 " +

                //    " on " +
                //    " table1.uid=table2.[UserId] " +
                //    " ) " +
                //    " ) ";
                //str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],BID,NameOfPerson,MobileNo,BirthDate,Gender,SMsg,MDescp,RemDate,Time,CurrentDate,UserId from Event where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "')) order by UserId";
                string str = " with Event as( select *from(  (SELECT [firstName],[lastName],[mobileNo]as m,[usertype],[RefMobileNo] as refmobno,[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1  inner join [Come2myCityDB].[dbo].[tbl_EBirthDay] as table2 on table1.uid=table2.[UserId]  )  )  select [firstName],[lastName],m,[usertype],refmobno,[address],[eMailId],[BID],[NameOfPerson],[MobileNo],[BirthDate],[Gender],[SMsg],[MDescp],[RemDate],[Time],[CurrentDate],[UserId] from Event	where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "')) order by UserId";
                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string returnString = string.Empty;
                    string userid = string.Empty;
                    string header = string.Empty;

                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            userid = ds.Tables[0].Rows[rows][17].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                            returnString = header + returnString;
                        }
                        else
                        {
                            if (!ds.Tables[0].Rows[rows][17].ToString().Equals(userid))
                            {
                                userid = ds.Tables[0].Rows[rows][17].ToString();
                                header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                                returnString = returnString + header;
                            }

                        }

                        string str4 = "Update [Come2myCityDB].[dbo].[tbl_EBirthday] set Status2='1' where UserId='" + ds.Tables[0].Rows[rows][17].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);
                        returnString += count++;
                        for (int col = 7; col < 17; col++)
                        {

                            if (col != 17)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[rows][col].ToString();
                            //returnString += count++;
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
        else
            return CommonCode.WRONG_INPUT.ToString();

    }
    public string NewsSend(string RefMobileNo, string CurrentDate)
    {
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {

            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                //string str =
                //"with asd as(" +
                //" select *from( " +
                //" select Table1.mobileNo as m, UserId as uid from(select mobileNo from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where RefMobileNo='" + RefMobileNo + "' and keyword='EZEEPLANNER')as Table1 " +
                //" inner join " +
                //" [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] as Table2 " +
                //" on " +
                //" Table1.mobileNo=Table2.mobileNo " +
                //" )as Table3 " +
                //" left outer join " +
                //" tbl_EventNews " +
                //" on " +
                //" Table3.uid=tbl_EventNews.UserId) ";
                //if (!CurrentDate.Equals("0"))
                //    str += "  select NewsHead,NewsDetails,NPaper,Role,Date,Time,TypeOfNews,Location,Feedback,UserId from [Come2myCityDB].[dbo].[tbl_EventNews] where Status2='0' and CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "')";
                string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo] as refmobno,[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_EventNews] as table2 " +
                    " on " +
                    " table1.uid=table2.[UserId] " +
                    " ) " +
                    " ) ";
                str += " select [firstName],[lastName],m,[usertype],refmobno,[address],[eMailId],[NID],[NewsHead],[NewsDetails],[NPaper],[Role],[Date],[Time],[TypeOfNews],[Location],[Feedback],[CurrentDate],[UserId] from Event where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "'))order by UserId";
                ds = cc.ExecuteDataset(str);

                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string returnString = string.Empty;
                    string userid = string.Empty;
                    string header = string.Empty;

                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            userid = ds.Tables[0].Rows[rows][18].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                            returnString = header + returnString;
                        }
                        else
                        {
                            if (!ds.Tables[0].Rows[rows][18].ToString().Equals(userid))
                            {
                                userid = ds.Tables[0].Rows[rows][18].ToString();
                                header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                                returnString = returnString + header;
                            }
                        }

                        string str4 = "Update tbl_EventNews set Status2='1' where UserId='" + ds.Tables[0].Rows[rows][18].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);

                        returnString += count++;
                        for (int col = 7; col < 18; col++)
                        {

                            if (col != 18)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[rows][col].ToString();
                            //returnString += count++;
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
        else
            return CommonCode.WRONG_INPUT.ToString();

    }
    public string DeathSend(string RefMobileNo, string CurrentDate)
    {
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_EventDeath] as table2 " +
                    " on " +
                    " table1.uid=table2.[UserId] " +
                    " ) " +
                    " ) ";
                str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],DID,NameOfAccused,Date,Time,Location,SDescp,Relative,Relation,PVisit,MDescp,CurrentDate,UserId from Event where Status2='0' ";
                ds = cc.ExecuteDataset(str);

                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {


                    string returnString = string.Empty;
                    string header = string.Empty;
                    string userid = string.Empty;

                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            userid = ds.Tables[0].Rows[rows][18].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                            returnString = header + returnString;
                        }
                        else
                        {
                            if (!ds.Tables[0].Rows[rows][18].ToString().Equals(userid))
                            {
                                userid = ds.Tables[0].Rows[rows][18].ToString();
                                header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                                returnString = returnString + header;
                            }
                        }

                        string str4 = "Update tbl_EventDeath set Status2='1' where UserId='" + ds.Tables[0].Rows[rows][18].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);

                        returnString += count++;

                        for (int col = 7; col < 18; col++)
                        {

                            if (col != 18)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

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
        else
            return CommonCode.WRONG_INPUT.ToString();
    }
    public string MeetingSend(string RefMobileNo, string CurrentDate)
    {
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_EventMeeting] as table2 " +
                    " on " +
                    " table1.uid=table2.[UserId] " +
                    " ) " +
                    " ) ";
                str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],ID,ETitle,MeetingType,Location,FrmDate,FrmTime,UptoDate,UptoTime,Descp,RemDate,RemTime,RepRemainder,CurrentDate,UserId from Event where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "'))order by UserId";
                ds = cc.ExecuteDataset(str);

                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {


                    string returnString = string.Empty;
                    string header = string.Empty;
                    string userid = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            userid = ds.Tables[0].Rows[rows][20].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                            returnString = header + returnString;
                        }
                        else
                        {
                            if (!ds.Tables[0].Rows[rows][20].ToString().Equals(userid))
                            {
                                userid = ds.Tables[0].Rows[rows][20].ToString();
                                header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                                returnString = returnString + header;
                            }
                        }
                        string str4 = "Update tbl_EventMeeting set Status2='1' where UserId='" + ds.Tables[0].Rows[rows][20].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);
                        returnString += count++;
                        for (int col = 7; col < 20; col++)
                        {

                            if (col != 20)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

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
        else
        {
            return CommonCode.WRONG_INPUT.ToString();
        }
    }
    public string MarriageSend(string RefMobileNo, string CurrentDate)
    {
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_EventMyCt] as table2 " +
                    " on " +
                    " table1.uid=table2.[MyCt_UserId] " +
                    " ) " +
                    " ) ";
                str += " select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],Id,BrideName,GroomName,InvitionFrom,Date,Time,Location,PersonName,MobileNumber,PVisit,MDescp,RemDate,RemTime,CurrentDate,MyCt_UserId from Event where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "'))order by MyCt_UserId";
               ds = cc.ExecuteDataset(str);

                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {

                    string header = string.Empty;
                    string userid = string.Empty;
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            userid = ds.Tables[0].Rows[rows][21].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                            returnString = header + returnString;
                        }
                        else
                        {
                            if (!ds.Tables[0].Rows[rows][21].ToString().Equals(userid))
                            {
                                userid = ds.Tables[0].Rows[rows][21].ToString();
                                header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                                returnString = returnString + header;
                            }
                        }
                        string str4 = "Update tbl_EventMyCt set Status2='1' where MyCt_UserId='" + ds.Tables[0].Rows[rows][21].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);
                        returnString += count++;
                        for (int col = 7; col < 21; col++)
                        {
                            if (col != 21)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

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
        else
            return CommonCode.WRONG_INPUT.ToString();
    }

    public string ComplaintSend(string RefMobileNo, string CurrentDate)
    {
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address] as a,[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_EventComplaint] as table2 " +
                    " on " +
                    " table1.uid=table2.[UserId] " +
                    " ) " +
                    " ) ";
                str += "select [firstName],[lastName],m,[usertype],[RefMobileNo],a,[eMailId],CID,CompType,Date,CompSub,CompDetails,CompFDept,CompName,MobileNo,Address,CurrentDate,UserId from Event where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "'))order by UserId";
                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string header = string.Empty;
                    string userid = string.Empty;
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            userid = ds.Tables[0].Rows[rows][17].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                            returnString = header + returnString;
                        }
                        else
                        {
                            if (!ds.Tables[0].Rows[rows][17].ToString().Equals(userid))
                            {
                                userid = ds.Tables[0].Rows[rows][16].ToString();
                                header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                                returnString = returnString + header;
                            }
                        }
                        string str4 = "Update [Come2myCityDB].[dbo].[tbl_EventComplaint] set Status2='1' where UserId='" + ds.Tables[0].Rows[rows][17].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);
                        returnString += count++;
                        for (int col = 7; col < 17; col++)
                        {
                            if (col != 17)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

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
        else
            return CommonCode.WRONG_INPUT.ToString();
    }
    public string FollowUpSend(string RefMobileNo, string CurrentDate)
    {
        if (!string.IsNullOrEmpty(RefMobileNo) && !string.IsNullOrEmpty(CurrentDate))
        {
            try
            {
                int count = 1;
                DataSet ds = new DataSet();
                string str =
                    " with Event as( " +
                    " select *from( " +
                    " (SELECT [firstName],[lastName],[mobileNo] as m,[usertype],[RefMobileNo],[address],[eMailId],[UserId] as uid FROM [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='" + RefMobileNo + "' and keyword='EZEEPLANNER')as table1 " +
                    " inner join " +
                    " [Come2myCityDB].[dbo].[tbl_ECFollowUp] as table2 " +
                    " on " +
                    " table1.uid=table2.[UserId] " +
                    " ) " +
                    " ) ";
                str += "select [firstName],[lastName],m,[usertype],[RefMobileNo],[address],[eMailId],CFID,CID,Date,Remark,Status,CurrentDate,UserId from Event where Status2='0' and (CurrentDate=convert(date,'" + CurrentDate + "') or CurrentDate>convert(date,'" + CurrentDate + "'))order by UserId";
                ds = cc.ExecuteDataset(str);
                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    string header = string.Empty;
                    string userid = string.Empty;
                    string returnString = string.Empty;
                    for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                    {
                        if (rows == 0)
                        {
                            userid = ds.Tables[0].Rows[rows][13].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                       ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                            returnString = header + returnString;
                        }
                        else
                        {
                            if (!ds.Tables[0].Rows[rows][13].ToString().Equals(userid))
                            {
                                userid = ds.Tables[0].Rows[rows][13].ToString();
                                header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '*' + ds.Tables[0].Rows[rows][1].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][2].ToString() + '*' + ds.Tables[0].Rows[rows][3].ToString() + '*' +
                                           ds.Tables[0].Rows[rows][4].ToString() + '*' + ds.Tables[0].Rows[rows][5].ToString() + '*' + ds.Tables[0].Rows[rows][6].ToString() + '!';
                                returnString = returnString + header;
                            }
                        }
                        string str4 = "Update [Come2myCityDB].[dbo].[tbl_ECFollowUp] set Status2='1' where UserId='" + ds.Tables[0].Rows[rows][13].ToString() + "' ";
                        int i = cc.ExecuteNonQuery(str4);
                        returnString += count++;
                        for (int col = 7; col < 13; col++)
                        {
                            if (col != 13)
                            {
                                returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

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
        else
            return CommonCode.WRONG_INPUT.ToString();
    }

    #endregion

    [WebMethod(Description = "Insert All ComboData")]
    public string InsertDataInCombo(string keyWord, string eventString, string usereNumber)
    {
        int i;
        if (eventString != "" && keyWord != null)
        {
            try
            {
                if (keyWord.Equals("NEWS"))
                {
                    return NewsTypeInsert(eventString, usereNumber);
                }

                else if (keyWord.Equals("MEETING"))
                {
                    return MeetingTypeInsert(eventString, usereNumber);
                }
                else if (keyWord.Equals("COMPLAINT_TYPE"))
                {
                    return ComplaintTypeInsert(eventString, usereNumber);
                }
                else if (keyWord.Equals("COMPLAINT_DEPT"))
                {
                    return ComplaintDeptInsert(eventString, usereNumber);
                }

                else if (keyWord.Equals("COMPLAINT_STATUS"))
                {
                    return ComplaintFollowupInsert(eventString, usereNumber);
                }
                else if (keyWord.Equals("USER_TYPE"))
                {
                    return UserTypeInsert(eventString, usereNumber);
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

    private string NewsTypeInsert(string birthEvent, string LoginMobileNo)
    {
        DataSet ds = new DataSet();
        string[] stringArray = birthEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 3)
        {
            
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {
                sqlCommand.Parameters.Add(new SqlParameter("@Sub_ID","1"));
                sqlCommand.Parameters.Add(new SqlParameter("@name",stringArray[i+1].ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@LoginMobileNo",LoginMobileNo));

                sqlCommand.CommandText = "sp_ENewsCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();
                 result = sqlCommand.ExecuteNonQuery();
                string str="select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID]";
                string str1=cc.ExecuteScalar(str);
                nonInsertedValues1=str1+"*";
            }
            else
            {
                SqlParameter[] parameter = new SqlParameter[] {
                new SqlParameter("@Sub_ID","1"),
                new SqlParameter("@ID",stringArray[i].ToString()),
                new SqlParameter("@name",stringArray[i+1].ToString()),
                new SqlParameter("@LoginMobileNo",LoginMobileNo),
               };
                sqlCommand.CommandText = "sp_ENewsCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                 result = sqlCommand.ExecuteNonQuery();
            }
            //new SqlParameter("@CurrentDate",DateTime.Now.Date.AddHours(6).ToString("yyyy-MM-dd"))};

            try
            {


                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }

            }
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        sqlCommand.CommandText = "[sp_UEbirthday]";
            //        int result = sqlCommand.ExecuteNonQuery();
            //        if (result != 1)
            //        {
            //            i--;
            //            nonInsertedValues += stringArray[i].ToString() + "*";
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        return ex.Number.ToString();
            //    }
            //}
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql=CommonCode.OK.ToString()+"*";
            return sql+nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }

    private string MeetingTypeInsert(string birthEvent, string LoginMobileNo)
    {
        DataSet ds = new DataSet();
        string[] stringArray = birthEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsetedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 3)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Sub_ID", "2"));
                sqlCommand.Parameters.Add(new SqlParameter("@name", stringArray[i + 1].ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                sqlCommand.CommandText = "sp_EMeetingCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID]";
                string str1 = cc.ExecuteScalar(str);
                nonInsetedValues1 += str1 + "*";
            }
            else
            {

                SqlParameter[] parameter = new SqlParameter[] {
                    new SqlParameter("@Sub_ID","1"),
                    new SqlParameter("@ID",stringArray[i].ToString()),
                    new SqlParameter("@name",stringArray[i+1].ToString()),
                    new SqlParameter("@LoginMobileNo",LoginMobileNo),
                   };
                sqlCommand.CommandText = "sp_EMeetingCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            //new SqlParameter("@CurrentDate",DateTime.Now.Date.AddHours(6).ToString("yyyy-MM-dd"))};

            
            try
            {


                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }

            }
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        sqlCommand.CommandText = "[sp_UEbirthday]";
            //        int result = sqlCommand.ExecuteNonQuery();
            //        if (result != 1)
            //        {
            //            i--;
            //            nonInsertedValues += stringArray[i].ToString() + "*";
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        return ex.Number.ToString();
            //    }
            //}
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql=CommonCode.OK.ToString()+"*";
            return sql + nonInsetedValues1; 
            }
        else
            return nonInsertedValues;
    }

    public string ComplaintTypeInsert(string birthEvent, string LoginMobileNo)
    {
        DataSet ds = new DataSet();
        string[] stringArray = birthEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsetedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 3)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Sub_ID", "3"));
                sqlCommand.Parameters.Add(new SqlParameter("@name", stringArray[i + 1].ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                sqlCommand.CommandText = "sp_EComplaintTypeCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID]";
                string str1 = cc.ExecuteScalar(str);
                nonInsetedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] parameter = new SqlParameter[] {
                    new SqlParameter("@Sub_ID","3"),
                    new SqlParameter("@ID",stringArray[i].ToString()),
                    new SqlParameter("@name",stringArray[i+1].ToString()),
                    new SqlParameter("@LoginMobileNo",LoginMobileNo),
                   };
                sqlCommand.CommandText = "sp_EComplaintTypeCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            //new SqlParameter("@CurrentDate",DateTime.Now.Date.AddHours(6).ToString("yyyy-MM-dd"))};

            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();
            try
            {

                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }

            }
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        sqlCommand.CommandText = "[sp_UEbirthday]";
            //        int result = sqlCommand.ExecuteNonQuery();
            //        if (result != 1)
            //        {
            //            i--;
            //            nonInsertedValues += stringArray[i].ToString() + "*";
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        return ex.Number.ToString();
            //    }
            //}
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql+nonInsetedValues1;
        }
        else
            return nonInsertedValues;
    }

    public string ComplaintDeptInsert(string birthEvent, string LoginMobileNo)
    {
        DataSet ds = new DataSet();
        string[] stringArray = birthEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsetedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 3)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Sub_ID", "4"));
                sqlCommand.Parameters.Add(new SqlParameter("@name", stringArray[i + 1].ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                sqlCommand.CommandText = "sp_EComplaintDeptCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                string str ="select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID]";
                string str1 = cc.ExecuteScalar(str);
                nonInsetedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] parameter = new SqlParameter[] {
                    new SqlParameter("@Sub_ID","3"),
                    new SqlParameter("@ID",stringArray[i].ToString()),
                    new SqlParameter("@name",stringArray[i+1].ToString()),
                    new SqlParameter("@LoginMobileNo",LoginMobileNo),
                   };
                sqlCommand.CommandText = "sp_EComplaintDeptCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            //new SqlParameter("@CurrentDate",DateTime.Now.Date.AddHours(6).ToString("yyyy-MM-dd"))};

            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();
            try
            {

                
                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }

            }
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        sqlCommand.CommandText = "[sp_UEbirthday]";
            //        int result = sqlCommand.ExecuteNonQuery();
            //        if (result != 1)
            //        {
            //            i--;
            //            nonInsertedValues += stringArray[i].ToString() + "*";
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        return ex.Number.ToString();
            //    }
            //}
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString()+"*";
            return sql+nonInsetedValues1 ;
        }
        else
            return nonInsertedValues;
    }

    public string ComplaintFollowupInsert(string birthEvent, string LoginMobileNo)
    {
        DataSet ds = new DataSet();
        string[] stringArray = birthEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result ;
        for (int i = 1; i < stringArray.Length; i += 3)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Sub_ID", "5"));
                sqlCommand.Parameters.Add(new SqlParameter("@name", stringArray[i + 1].ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                sqlCommand.CommandText = "sp_EFollowupStatus";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID]";
                string str1 = cc.ExecuteScalar(str);
               nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] parameter = new SqlParameter[] {
                    new SqlParameter("@Sub_ID","3"),
                    new SqlParameter("@ID",stringArray[i].ToString()),
                    new SqlParameter("@name",stringArray[i+1].ToString()),
                    new SqlParameter("@LoginMobileNo",LoginMobileNo),
                   };
                sqlCommand.CommandText = "sp_EMeetingCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            //new SqlParameter("@CurrentDate",DateTime.Now.Date.AddHours(6).ToString("yyyy-MM-dd"))};

            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();
            try
            {

               
                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }


            }
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        sqlCommand.CommandText = "[sp_UEbirthday]";
            //        int result = sqlCommand.ExecuteNonQuery();
            //        if (result != 1)
            //        {
            //            i--;
            //            nonInsertedValues += stringArray[i].ToString() + "*";
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        return ex.Number.ToString();
            //    }
            //}
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString()+"*";
            return sql + nonInsertedValues1;
        }
        else
            return nonInsertedValues;
    }
    public string UserTypeInsert(string birthEvent, string LoginMobileNo)
    {
        DataSet ds = new DataSet();
        string[] stringArray = birthEvent.Split(new char[] { '#', '*' });
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        int result;
        for (int i = 1; i < stringArray.Length; i += 3)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            if (stringArray[i].ToString() == "0")
            {

                sqlCommand.Parameters.Add(new SqlParameter("@Sub_ID", "6"));
                sqlCommand.Parameters.Add(new SqlParameter("@name", stringArray[i + 1].ToString()));
                sqlCommand.Parameters.Add(new SqlParameter("@LoginMobileNo", LoginMobileNo));
                sqlCommand.CommandText = "sp_EUserRegCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
                string str = "select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID]";
                string str1 = cc.ExecuteScalar(str);
                nonInsertedValues1 += str1 + "*";
            }
            else
            {
                SqlParameter[] parameter = new SqlParameter[] {
                    new SqlParameter("@Sub_ID","3"),
                    new SqlParameter("@ID",stringArray[i].ToString()),
                    new SqlParameter("@name",stringArray[i+1].ToString()),
                    new SqlParameter("@LoginMobileNo",LoginMobileNo),
                   };
                sqlCommand.CommandText = "sp_EMeetingCombo";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (sqlCommand.Connection.State == ConnectionState.Closed)
                    sqlCommand.Connection.Open();
                result = sqlCommand.ExecuteNonQuery();
            }
            //new SqlParameter("@CurrentDate",DateTime.Now.Date.AddHours(6).ToString("yyyy-MM-dd"))};

            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();
            try
            {

                
                if (result != 1)
                {
                    i--;
                    nonInsertedValues += stringArray[i].ToString() + "*";
                    i++;
                }

            }
            //catch (SqlException ex)
            //{
            //    if (ex.Number == 2627)
            //    {
            //        sqlCommand.CommandText = "[sp_UEbirthday]";
            //        int result = sqlCommand.ExecuteNonQuery();
            //        if (result != 1)
            //        {
            //            i--;
            //            nonInsertedValues += stringArray[i].ToString() + "*";
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        return ex.Number.ToString();
            //    }
            //}
            catch (Exception ex) { return CommonCode.ERROR_OCCUR_WHILE_EXECUTION.ToString(); }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";
            return sql + nonInsertedValues1;
        }
            return nonInsertedValues;
    }
    [WebMethod(Description = "DownloadComboData")]
    public string DownloadAllComboData(string keyWord)
    {

        int i;
        if (!string.IsNullOrEmpty(keyWord))
        {
            try
            {
                if (keyWord.Equals("ALL"))
                {
                    return Alldatasend();
                }
                //else if (keyWord.Equals("NEWS"))
                //{
                //    return NewsSend(RefMobileNo, CurrentDate);
                //}

                //else if (keyWord.Equals("MEETING"))
                //{
                //    return MeetingSend(RefMobileNo, CurrentDate);
                //}

                //else if (keyWord.Equals("COMPLAINT"))
                //{
                //    return ComplaintSend(RefMobileNo, CurrentDate);
                //}
                //else if (keyWord.Equals("FOLLOWUP"))
                //{
                //    return FollowUpSend(RefMobileNo, CurrentDate);
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

    public string Alldatasend()
    {

        try
        {

            int count = 1;
            DataSet ds = new DataSet();
            //ds = cc.ExecuteDataset(str);
            //string str1 = Convert.ToString(ds.Tables[0].Rows[1]["Name"]);
            //string sql = "select * from [Come2myCityDB].[dbo].[tbl_Main_ID]  ";
            //ds = cc.ExecuteDataset(sql);
            string str =
                   " with Event as( " +
                   " select *from( " +
                   " (select [ID] as i,[Name] as n from [Come2myCityDB].[dbo].[tbl_Sub_ID]) as table1 " +
                   " inner join " +
                   " [Come2myCityDB].[dbo].[tbl_Main_ID] as table2 " +
                   " on " +
                   " table1.i=table2.Sub_ID " +
                     " ) " +
                   " ) ";
            str += "select distinct n,ID,Name,UserId from Event";
            ds = cc.ExecuteDataset(str);
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                string header = string.Empty;
                string userid = string.Empty;
                string name1 = string.Empty;
                string returnString = string.Empty;
                for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                {
                    if (rows == 0)
                    {
                        name1 = ds.Tables[0].Rows[rows][0].ToString();
                        header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '!';
                        returnString = header + returnString;
                    }
                    else
                    {
                        if (!ds.Tables[0].Rows[rows][0].ToString().Equals(name1))
                        {
                            name1 = ds.Tables[0].Rows[rows][0].ToString();
                            header = "$" + ds.Tables[0].Rows[rows][0].ToString() + '!';
                            returnString = returnString + header;
                        }
                    }
                    returnString.Trim();
                    returnString += count++;
                    for (int col = 1; col < 3; col++)
                    {
                        if (col != 3)
                        {
                            returnString += "*" + ds.Tables[0].Rows[rows][col].ToString();
                        }
                        else
                            returnString += ds.Tables[0].Rows[rows][col].ToString();

                    }
                    returnString += "#";
                    returnString=returnString.Trim();
                    returnString=returnString.Replace("\t",string.Empty);

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






}


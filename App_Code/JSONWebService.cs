using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.Runtime.Serialization.Json;
//using Newtonsoft.Json;






/// <summary>
/// Summary description for JSONWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]


public class JSONWebService : System.Web.Services.WebService
{

    CommonCode cc = new CommonCode();
    public JSONWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
    public string HelloWorld()
    {
        return "Hello World";
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public String Hi()
    //{
    //    return new JavaScriptSerializer().Serialize("hi");
    //}
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
                //else if (keyWord.Equals("NEWS"))
                //{
                //    return NewsSend(LoginMobileNo);
                //}
                //else if (keyWord.Equals("DEATH"))
                //{
                //    return DeathSend(LoginMobileNo);
                //}
                //else if (keyWord.Equals("MEETING"))
                //{
                //    return MeetingSend(LoginMobileNo);
                //}
                //else if (keyWord.Equals("MARRIAGE"))
                //{
                //    return MarriageSend(LoginMobileNo);
                //}
                //else if (keyWord.Equals("COMPLAINT"))
                //{
                //    return ComplaintSend(LoginMobileNo);
                //}
                //else if (keyWord.Equals("FOLLOWUP"))
                //{
                //    return ComplaintFollowupSend(LoginMobileNo);
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
    //class Employee
    //{
    //    public string EmpName { get; set; }
    //    public string MobNo { get; set; }
    //    public string sal { get; set; }
    //    public string qualification { get; set; }
    //}
    class Employee
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string MobileNo { get; set; }
        public string Post { get; set; }
    }
    [WebMethod]
    //[ScriptMethod(UseHttpGet = true)]
    public void SendEmployeeData()
    {
        List<Employee> li = new List<Employee>();
        Employee e = new Employee();
        string ans = string.Empty;
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            cmd.Connection = con;
            string str = "Select [FName],[LName],[MobileNo],[Post] from [Come2myCityDB].[dbo].[tbl_BMRegistration]";
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            cmd.CommandText = str;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";

            for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
            {
                e.FName = ds.Tables[0].Rows[rows]["FName"].ToString();
                e.LName = ds.Tables[0].Rows[rows]["LName"].ToString();
                e.MobileNo = ds.Tables[0].Rows[rows]["MobileNo"].ToString();
                e.Post = ds.Tables[0].Rows[rows]["Post"].ToString();
                li.Add(e);
                //ans = JsonConvert.SerializeObject(li, Formatting.Indented);

            }
        }
        catch (Exception ex)
        {

        }
        //string temp = "{\"d\":" + ans + "}";
        //Context.Response.Write(temp);
        //return new JavaScriptSerializer().Serialize(e);
        System.Web.Script.Serialization.JavaScriptSerializer jSearializer =
                   new System.Web.Script.Serialization.JavaScriptSerializer();
        //return jSearializer.Serialize(li);
        Context.Response.Write(serializer.Serialize(li));

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
                List<string> returnResponse = new List<string>();
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

                                returnString += ds.Tables[0].Rows[rows][col].ToString();
                            }
                            else
                            {
                                returnString += ds.Tables[0].Rows[rows][col].ToString();

                                //returnString += count++;
                            }

                        }
                        //returnString += "#";
                        returnResponse.Add(returnString);

                    }

                    return new JavaScriptSerializer().Serialize(returnResponse);
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
    class c
    {
        List<string> ss { get; set; }

    }
    [WebMethod]
    public void sa(string s)
    {
        object o = new JavaScriptSerializer().DeserializeObject(s);

    }


    class Birthday
    {
        public string name { get; set; }
        public string date { get; set; }
        public string mobileNO { get; set; }
        public Birthday(string na, string d, string m)
        {
            this.name = na;
            this.date = d;
            this.mobileNO = m;
        }
        public Birthday()
        { }

    }

    [WebMethod]
    public string getBirthday()
    {
        List<Birthday> list = new List<Birthday>();
        Birthday b = new Birthday();
        b.mobileNO = "123546879";
        b.name = "abc";
        b.date = "2012/12/12";
        list.Add(b);

        b = new Birthday();
        b.mobileNO = "5523546879";
        b.name = "xyz";
        b.date = "2012/12/02";
        list.Add(b);


        b = new Birthday();
        b.mobileNO = "8885464597";
        b.name = "pqr";
        b.date = "2012/02/1";
        list.Add(b);




        return new JavaScriptSerializer().Serialize(list);
    }



    class Birthday1
    {
        public string NameOfPerson { get; set; }
        public string MobileNo { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string SMsg { get; set; }
        public string MDescp { get; set; }
        public string RemDate { get; set; }
        public string Time { get; set; }




    }

    [WebMethod]
    public void SendBirthday(string LoginMobileNo)
    {
        List<Birthday1> li = new List<Birthday1>();
        Birthday1 b = new Birthday1();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        try
        {
            int count = 1;
            DataSet ds = new DataSet();
            string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
            ds = cc.ExecuteDataset(str1);
            string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

            string str = "Select BID,NameOfPerson,MobileNo,BirthDate,Gender,SMsg,MDescp,RemDate,Time,CurrentDate,UserId,Status1 from tbl_EBirthday where UserId='" + str2 + "' and Status1='0'  ";

            ds = cc.ExecuteDataset(str);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            //List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            //Dictionary<string, object> row;

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                //List<Birthday1> li = new List<Birthday1>();
                //Birthday1 b = new Birthday1();

                string returnString = string.Empty;
                for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                {


                    b.NameOfPerson = ds.Tables[0].Rows[rows]["NameOfPerson"].ToString();
                    b.BirthDate = ds.Tables[0].Rows[rows]["BirthDate"].ToString();
                    b.MobileNo = ds.Tables[0].Rows[rows]["MobileNo"].ToString();
                    b.Gender = ds.Tables[0].Rows[rows]["Gender"].ToString();
                    b.SMsg = ds.Tables[0].Rows[rows]["SMsg"].ToString();
                    b.MDescp = ds.Tables[0].Rows[rows]["MDescp"].ToString();
                    b.RemDate = ds.Tables[0].Rows[rows]["RemDate"].ToString();
                    b.Time = ds.Tables[0].Rows[rows]["MobileNo"].ToString();
                    li.Add(b);

                }
                //returnString += "#";
                //return new JavaScriptSerializer().Serialize(li);


            }


        }



        catch (SqlException ex)
        {
            throw ex;
            //return ex.Number.ToString();

        }


        //return new JavaScriptSerializer().Serialize(li);
        Context.Response.Write(serializer.Serialize(li));


    }


    [WebMethod]
    public string downloadBirthday(string LoginMobileNo)
    {
        List<Birthday1> li = new List<Birthday1>();
        Birthday1 b = new Birthday1();
        JavaScriptSerializer Machinejson = new JavaScriptSerializer();
        this.Context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
        this.Context.Response.ContentType = "application/json; charset=utf-8"; // to remove xml tag from response
        //this.Context.Response.Write(Machinejson.Serialize([li]));
        try
        {
            int count = 1;
            DataSet ds = new DataSet();
            string str1 = " select usrUserId from [Come2myCityDB].[dbo].[UserMaster] where usrMobileNo='" + LoginMobileNo + "'";
            ds = cc.ExecuteDataset(str1);
            string str2 = Convert.ToString(ds.Tables[0].Rows[0]["usrUserId"]);

            string str = "Select BID,NameOfPerson,MobileNo,BirthDate,Gender,SMsg,MDescp,RemDate,Time,CurrentDate,UserId,Status1 from tbl_EBirthday where UserId='" + str2 + "' and Status1='0'  ";

            ds = cc.ExecuteDataset(str);

            //Context.Response.Clear();
            //Context.Response.ContentType = "application/json";
            //List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            //Dictionary<string, object> row;

            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                //List<Birthday1> li = new List<Birthday1>();
                //Birthday1 b = new Birthday1();

                string returnString = string.Empty;
                for (int rows = 0; rows < ds.Tables[0].Rows.Count; rows++)
                {


                    b.NameOfPerson = ds.Tables[0].Rows[rows]["NameOfPerson"].ToString();
                    b.BirthDate = ds.Tables[0].Rows[rows]["BirthDate"].ToString();
                    b.MobileNo = ds.Tables[0].Rows[rows]["MobileNo"].ToString();
                    b.Gender = ds.Tables[0].Rows[rows]["Gender"].ToString();
                    b.SMsg = ds.Tables[0].Rows[rows]["SMsg"].ToString();
                    b.MDescp = ds.Tables[0].Rows[rows]["MDescp"].ToString();
                    b.RemDate = ds.Tables[0].Rows[rows]["RemDate"].ToString();
                    b.Time = ds.Tables[0].Rows[rows]["MobileNo"].ToString();
                    li.Add(b);
                }
                //returnString += "#";
                //return new JavaScriptSerializer().Serialize(li);


            }


        }



        catch (SqlException ex)
        {
            //throw ex;
            return ex.Number.ToString();

        }


        return new JavaScriptSerializer().Serialize(li);
        //return Context.Response.Write(serializer.Serialize(li));


    }
    //[{"name":"abc","date":"2012/12/12","mobileNO":"123546879"},{"name":"xyz","date":"2012/12/02","mobileNO":"5523546879"},{"name":"pqr","date":"2012/02/1","mobileNO":"8885464597"}]
    [WebMethod]
    public string InsertBirthday(string LoginMobileNo, string Estr)
    {

        List<Birthday1> o = new JavaScriptSerializer().Deserialize<List<Birthday1>>(Estr);
        //string[] stringArray 
        string nonInsertedValues = string.Empty;
        string nonInsertedValues1 = string.Empty;
        SqlCommand sqlCommand = new SqlCommand();
        sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        foreach (Birthday1 obj in o)
        {

            sqlCommand.Parameters.Add(new SqlParameter("@name", obj.NameOfPerson));
            sqlCommand.Parameters.Add(new SqlParameter("@mobleNumber", obj.MobileNo));

            sqlCommand.Parameters.Add(new SqlParameter("@date", obj.BirthDate));
            sqlCommand.Parameters.Add(new SqlParameter("@gender", obj.Gender));
            sqlCommand.Parameters.Add(new SqlParameter("@smes", obj.SMsg));
            sqlCommand.Parameters.Add(new SqlParameter("@mdiscription", obj.MDescp));
            sqlCommand.Parameters.Add(new SqlParameter("@RemDate", obj.RemDate));
            sqlCommand.Parameters.Add(new SqlParameter("@time", obj.Time));
            sqlCommand.Parameters.Add(new SqlParameter("@usereNumber", LoginMobileNo));
            //sqlCommand.Parameters.Add(new SqlParameter("@CurrentDate", stringArray[i + 9].ToString()));
            SqlParameter pass = new SqlParameter("@rid", SqlDbType.NVarChar, 50);
            pass.Direction = ParameterDirection.Output;

            sqlCommand.Parameters.Add(pass);
            sqlCommand.CommandText = "sp_Ebirthday";

            if (sqlCommand.Connection.State == ConnectionState.Closed)
                sqlCommand.Connection.Open();

            int result = sqlCommand.ExecuteNonQuery();

            //if (stringArray[i].ToString() == "0")
            //{
            //SqlParameter pass = new SqlParameter("@rid", SqlDbType.NVarChar, 50);
            //pass.Direction = ParameterDirection.Output;

            //sqlCommand.Parameters.Add(pass);
            //sqlCommand.CommandText = "sp_Ebirthday";
            //int result = sqlCommand.ExecuteNonQuery();
            //}



            //for (int i = 1; i < stringArray.Length; i += 11)
            //{
            //    SqlCommand sqlCommand = new SqlCommand();
            //    sqlCommand.Connection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);

            //    sqlCommand.Parameters.Add(new SqlParameter("@name", stringArray[i + 1].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@mobleNumber", stringArray[i + 2].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@date", stringArray[i + 3].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@gender", stringArray[i + 4].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@smes", stringArray[i + 5].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@mdiscription", stringArray[i + 6].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@RemDate", stringArray[i + 7].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@time", stringArray[i + 8].ToString()));
            //    sqlCommand.Parameters.Add(new SqlParameter("@usereNumber", usereNumber));
            //    sqlCommand.Parameters.Add(new SqlParameter("@CurrentDate", stringArray[i + 9].ToString()));
            //    if (stringArray[i].ToString() == "0")
            //    {
            //        SqlParameter pass = new SqlParameter("@rid", SqlDbType.NVarChar, 50);
            //        pass.Direction = ParameterDirection.Output;

            //        sqlCommand.Parameters.Add(pass);
            //        sqlCommand.CommandText = "sp_Ebirthday";
            //    }

            //    try
            //    {
            //        int result = sqlCommand.ExecuteNonQuery();
            //        string str = "";
            //        if (stringArray[i].ToString() == "0")
            //        {
            //            str = sqlCommand.Parameters["@rid"].Value.ToString();
            //            nonInsertedValues1 += str + "*";
            //            //nonInsertedValues += CommonCode.OK.ToString() + "*" ;
            //        }
            //        //else
            //        //    str = CommonCode.OK.ToString();

            //        if (result != 1)
            //        {
            //            i--;
            //            nonInsertedValues += CommonCode.FAIL.ToString() + "*";
            //            i++;
            //        }
            //else
            //{
            //    nonInsertedValues += str + "*";
            //}


            //        }
            //        catch (SqlException ex)
            //        {
            //            throw ex;
            //        }

        }
        if (string.IsNullOrEmpty(nonInsertedValues))
        {
            string sql = CommonCode.OK.ToString() + "*";

        }
        //    else

        //        return nonInsertedValues;

        return nonInsertedValues;
    }
}


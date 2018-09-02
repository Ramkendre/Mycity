using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for JsonChatForum
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class JsonChatForum : System.Web.Services.WebService
{

    CommonCode cc = new CommonCode();
    public JsonChatForum()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertForumData(string data)
    {
        List<forumdata> lifdata = new JavaScriptSerializer().Deserialize<List<forumdata>>(data);
        foreach (forumdata fdata in lifdata)
        {
            string sql = "insert into [Come2myCityDB].[come2mycity].[tblChatForum]([MobileNo],[RegId]) values('" + fdata.mobileno + "','" + fdata.regid + "')";
            cc.ExecuteNonQuery(sql);
        }

        return "1";
    }

    public class forumdata
    {
        public string mobileno { get; set; }
        public string regid { get; set; }
    }

    [WebMethod]
    public string insertforum(string mobileno, string regId, string name)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "uspinsertForumData";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = con;

        cmd.Parameters.AddWithValue("@mobileno", mobileno);
        cmd.Parameters.AddWithValue("@regid", regId);
        cmd.Parameters.AddWithValue("@Name", name);

        if (cmd.Connection.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd.ExecuteNonQuery();
        return "1";
    }

    [WebMethod]
    public string insertmessage(string mobileno, string message, string type)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();

        try
        {
            cmd.CommandText = "SELECT [RegId] FROM [Come2myCityDB].[come2mycity].[tblChatForum] WHERE [MobileNo] != '" + mobileno + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            da.Fill(ds);


            cmd.CommandText = "uspinsertmessage";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@mobileno", mobileno);
            cmd.Parameters.AddWithValue("@message", message);
            cmd.Parameters.AddWithValue("@type", type);

            if (cmd.Connection.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                var applicationID = "AIzaSyAd1PUL0jrMg-XZ-D31HoG-q8Q2SL0dDGE";//AIzaSyDScxxxxxxxxxxxxxcLJgpv66IfgA

                var SENDER_ID = "610781756720";//77580014625
                var value = message;
                WebRequest tRequest;
                tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));//

                tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

                string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message="
                    + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + ds.Tables[0].Rows[i]["RegId"] + "&key=" + type + "";


                //Console.WriteLine(postData);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = byteArray.Length;

                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                
            }
            return "1";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}


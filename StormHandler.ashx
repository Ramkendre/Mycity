<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

public class ImageHandler : IHttpHandler
{

    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);
    //string strcon = ConfigurationManager.AppSettings["ConnectionString"].ToString();
    //public void ProcessRequest(HttpContext context)
    //{
    //    string imageid = context.Request.QueryString["PID"];
    //    //string imageid2 = context.Request.QueryString["userId"];

    //    //if (imageid2 == "")
    //    //{ }
    //    //else
    //    //{
    //    //    string Sql = "Select usrAutoId from UserMaster where usrUserId='" + imageid2 + "'";
    //    //    string AutoId = Convert.ToString(cc.ExecuteScalar(Sql));
    //    //    if (AutoId != "")
    //    //    {
    //    //        string sql = "select id from storeimage where usrAutoId='" + AutoId + "'";
    //    //        imageid = cc.ExecuteScalar(sql);

    //    //    }
    //    //}
    //    if (imageid == "" || imageid == null)
    //    {
    //        string AutoId = "22887";
    //        imageid = "1";
    //        //SqlConnection connection = new SqlConnection(strcon);
    //        //connection.Open();

    //        //SqlCommand command = new SqlCommand("select [Image] FROM [Come2myCityDB].[dbo].[tbl_imagestore] where PID='" + imageid + "'");
    //        //SqlCommand command = new SqlCommand("select [image] from storeimage where usrAutoId='" + AutoId + "'");
    //        //con.Open();
    //        //command.Connection = con;
    //        //SqlDataReader dr = command.ExecuteReader();
    //        //dr.Read();
    //        ////byte[] MyImg = (byte[])dr["image"];
    //        //context.Response.BinaryWrite((Byte[])dr[0]);

    //        //con.Close();
    //        //context.Response.End();
    //    }
    //    else
    //    {
    //        //DataSet ds = new DataSet();
    //        string PID = "1";
    //        string AutoId = "22887";
    //        //SqlConnection connection = new SqlConnection(strcon);
    //        con.Open();
    //        SqlCommand command = new SqlCommand("select [Image] FROM [Come2myCityDB].[dbo].[tbl_imagestore] where PID='" + PID + "'");
    //        //SqlCommand command = new SqlCommand("select [image] from storeimage where usrAutoId='" + AutoId + "'");
    //        //SqlCommand command = new SqlCommand("select [Image] from [DBeZeeSchool].[dbo].[tblStoreT_Image] where PID='" + PID + "'");
    //        command.Connection = con;
    //        DataSet ds = new DataSet();

    //        DataTable dt = new DataTable();
    //        SqlDataAdapter da = new SqlDataAdapter(command);
    //        //byte[] bytes = (byte[])GetData("select [Image] FROM [Come2myCityDB].[dbo].[tbl_imagestore] where PID="+PID).Rows[0]["Image"];
            
    //        da.Fill(ds);
    //        string str = Convert.ToBase64String((byte[])ds.Tables[0].Rows[0][0]);
    //        dt.Columns.Add(new DataColumn("Image", typeof(string)));
    //        //dt.Rows.Add(ds.Tables[0].Rows[0]["Image"].ToString());
    //        //ds.Tables.Add(dt);
    //        MemoryStream ms = new MemoryStream(Convert.ToInt32(str));
    //        //imgOptE.BackgroundImage.Save(ms, ImageFormat.Jpeg);
            
    //        byte[] optE = Convert.To(ms.ToArray());



    //        //byte[] abc2 = Convert.ToByte(str);
            
    //        //string imgg = ds.Tables[0].Rows[0][0].ToString();
    //        //SqlDataReader dr = command.ExecuteReader();
    //        //dr.Read();
    //        //byte[] bArray = Encoding.UTF8.GetBytes(imgg.ToString());
    //        //context.Response.BinaryWrite(Convert.FromBase64String());
    //        //byte[] MyImg = (byte[])dr["image"];
    //        //MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0][0]);
    //        //context.Response.BinaryWrite(str);
    //        context.Response.BinaryWrite(optE);

    //        con.Close();
    //        context.Response.End();
    //    }
    //    //SqlConnection connection1 = new SqlConnection(strcon);
    //    //connection1.Open();
    //    //SqlCommand command1 = new SqlCommand("SELECT image FROM  storeimage WHERE id =" + imageid, connection1);
    //    //SqlDataReader dr1 = command1.ExecuteReader();
    //    //dr1.Read();
    //    ////byte[] MyImg = (byte[])dr["image"];
    //    //context.Response.BinaryWrite((Byte[])dr1[0]);

    //    //connection1.Close();
    //    //context.Response.End();




    //}
    //private DataTable GetData(string query)
    //{
    //    DataTable dt = new DataTable();
        
    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {
    //        using (SqlCommand cmd = new SqlCommand(query))
    //        {
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.CommandType = CommandType.Text;
    //                cmd.Connection = con;
    //                sda.SelectCommand = cmd;
    //                sda.Fill(dt);
    //            }
    //        }
    //        return dt;
    //    }
    //}

    public void ProcessRequest(HttpContext context)
    {
        string imageid = context.Request.QueryString["PID"];
       
        if (imageid == "" || imageid == null)
        {
            //string AutoId = "22887";
            //imageid = "1";

            context.Response.Write("Photo Cant Display");

            //con.Close();
            //context.Response.End();
        }
        else
        {
            DataSet ds = new DataSet();
            
          
            con.Open();
           
            SqlCommand command = new SqlCommand("select [Image] from [DBeZeeSchool].[dbo].[tblStoreT_Image] where PID='" + imageid + "'");
            command.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(ds);
            string imgg = ds.Tables[0].Rows[0][0].ToString();
           
            context.Response.BinaryWrite(Convert.FromBase64String(ds.Tables[0].Rows[0][0].ToString()));
         

            con.Close();
            context.Response.End();
        }
        



    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
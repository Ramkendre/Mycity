<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
public class ImageHandler : IHttpHandler
{

    CommonCode cc = new CommonCode();
    string strcon = ConfigurationManager.AppSettings["ConnectionString"].ToString();
    public void ProcessRequest(HttpContext context)
    {
        string imageid = context.Request.QueryString["id"];
        string imageid2 = context.Request.QueryString["userId"];

        if (imageid2 == "")
        { }
        else
        {
            string Sql = "Select usrAutoId from UserMaster where usrUserId='" + imageid2 + "'";
            string AutoId = Convert.ToString(cc.ExecuteScalar(Sql));
            if (AutoId != "")
            {
                string sql = "select id from [Come2myCityDB].[come2mycity].[storeimage] where usrAutoId='" + AutoId + "'";
                imageid = cc.ExecuteScalar(sql);

            }
        }
        if (imageid == "" || imageid == null)
        {
            imageid = "1";
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT image FROM  [Come2myCityDB].[come2mycity].[storeimage] WHERE id =" + imageid, connection);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            //byte[] MyImg = (byte[])dr["image"];
            context.Response.BinaryWrite((Byte[])dr[0]);

            connection.Close();
            context.Response.End();
        }
        else
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT image FROM  [Come2myCityDB].[come2mycity].[storeimage] WHERE id =" + imageid, connection);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            //byte[] MyImg = (byte[])dr["image"];
            context.Response.BinaryWrite((Byte[])dr[0]);

            connection.Close();
            context.Response.End();
        }
        //SqlConnection connection1 = new SqlConnection(strcon);
        //connection1.Open();
        //SqlCommand command1 = new SqlCommand("SELECT image FROM  storeimage WHERE id =" + imageid, connection1);
        //SqlDataReader dr1 = command1.ExecuteReader();
        //dr1.Read();
        ////byte[] MyImg = (byte[])dr["image"];
        //context.Response.BinaryWrite((Byte[])dr1[0]);

        //connection1.Close();
        //context.Response.End();

    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
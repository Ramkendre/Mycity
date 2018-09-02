﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

/// <summary>
/// Summary description for EventMain_IDDAL
/// </summary>
public class EventMain_IDDAL
{
	public EventMain_IDDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int AddRecord(EventMain_IDBLL SPMI)
    {
        int row;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try 
        {
            SqlParameter[] par = new SqlParameter[]
                {
                new SqlParameter("@ID",SPMI.ID1),
                new SqlParameter("@Sub_ID",SPMI.Sub_ID1),
                new SqlParameter("@Name",SPMI.Name1),
                new SqlParameter("@Description",SPMI.Description1),
                new SqlParameter("@User",SPMI.User1),
                new SqlParameter("@UserId",SPMI.UserId1)

                };
            SqlCommand cmd = new SqlCommand("EventMain_IDInsert", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            row = cmd.ExecuteNonQuery();
            return row;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    public int AddRecordSubID(EventMain_IDBLL SPSI)
    {
        int row1;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[] 
            {
                
                new SqlParameter("@Name",SPSI.Name1),
                new SqlParameter("@Description",SPSI.Description1),
                new SqlParameter("@UserId",SPSI.UserId1)
            };
            SqlCommand cmd = new SqlCommand("EventSub_IDInsert", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            row1 = cmd.ExecuteNonQuery();
            return row1;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}

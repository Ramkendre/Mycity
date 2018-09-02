using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for Udise_ExeCountTotal
/// </summary>
public class Udise_ExeCountTotal
{
    CommonCode cc = new CommonCode();
    DataSet ds;
	public Udise_ExeCountTotal()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public int Exe_PresentyRecord()
    {

        int status;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                status = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "SP_Populate_UDISE_TotalByRole");


            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }
}

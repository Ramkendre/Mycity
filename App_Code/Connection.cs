using System;
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
using System.Collections;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Net;



/// <summary>
/// Summary description for CommonCode
/// </summary>
public class Connection
{




    public Connection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //public static SqlConnection GetConnection(string connectionString)
    public SqlConnection Connect()
    {
        SqlConnection scon = new SqlConnection();
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
       
            try
            {
               
                scon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

                scon.Open();

                              
            }
            catch (Exception ex)
            {
                //ex should be written into a error log

                // dispose of the connection to avoid connections leak
                if (con != null)
                {
                    con.Dispose();
                }
            }
            return scon;
       

    }
}
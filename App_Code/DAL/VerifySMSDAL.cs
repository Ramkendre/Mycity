using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.ApplicationBlocks.Data;
using System.Collections;


/// <summary>
/// Summary description for VerifySMSDAL
/// </summary>
public class VerifySMSDAL
{DataSet ds = new DataSet();
int status;
    //VerifySMSBLL objBLL = new VerifySMSBLL();
    CommonCode cc = new CommonCode();
	public VerifySMSDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<VerifySMSBLL> getSMSHistory(VerifySMSBLL obj)
    {
             List<VerifySMSBLL> objBllVar = new List<VerifySMSBLL>();
             DataSet ds = new DataSet();
             string sql = "select * from test order by PK desc";
            ds = cc.ExecuteDataset(sql );
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                VerifySMSBLL obj1 = new VerifySMSBLL();
                obj1.pk = Convert.ToInt32(dr1["PK"]);
                obj1.mobileNo = Convert.ToString(dr1["mobile"]);
                obj1.message = Convert.ToString(dr1["Message"]);
                obj1.date = Convert.ToString(dr1["shortcode"]);
                obj1.flag = Convert.ToInt32(dr1["FlagStatus"]);
                objBllVar.Add(obj1 );
            
            }
        
   
         

        return objBllVar;
    }

    public DataSet  getSMSHistoryCurrentdate(VerifySMSBLL obj)
    {
        DataSet ds1 = new DataSet();
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            try
            {
            SqlParameter [] par =new  SqlParameter[7];
            par[1]=new SqlParameter("@pk",obj.pk );
            par[2]=new SqlParameter("@mobile",obj.mobileNo );
            par[3]=new SqlParameter("@shortcode",obj.date );
            par[4]=new SqlParameter("@FlagStatus",obj.flag );
            par[5] = new SqlParameter("@Message", obj.message);
            par[6] = new SqlParameter("@Status", 7);
            par[6].Direction = ParameterDirection.Output;

           ds1=SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spGetSMSHistoryByCurrentDate", par);
                status =Convert.ToInt32(par[6].Value);

             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 con.Close();
             }

         }
         return ds1;
     }




   
  public List<VerifySMSBLL>  getSendSMSHistory_CurrentDate(VerifySMSBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
        {
            List<VerifySMSBLL> objBllVar = new List<VerifySMSBLL>();
            try
            {

                SqlParameter[] par = new SqlParameter[1];
               
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetSMSHistory_ByCurrentDate");
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    VerifySMSBLL obj1 = new VerifySMSBLL();
                    obj1.pk = Convert.ToInt32(dr1["PK"]);
                    obj1.mobileNo = Convert.ToString(dr1["mobile"]);
                    obj1.message = Convert.ToString(dr1["Message"]);
                    obj1.date = Convert.ToString(dr1["shortcode"]);
                    obj1.flag = Convert.ToInt32(dr1["FlagStatus"]);
                    objBllVar.Add(obj1);

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return objBllVar;
        }

    }


     


    public List<VerifySMSBLL> getSMSHistory_ByDate(VerifySMSBLL obj)
    {
       using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]))
       {
           List<VerifySMSBLL> objBllVar = new List<VerifySMSBLL>();
               try
               {
                   
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@FromDate", obj.fromdate);
                par[1] = new SqlParameter("@ToDate",obj.ToDate);
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetSMSHistory_ByDate",par);
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    VerifySMSBLL obj1 = new VerifySMSBLL();
                    obj1.pk = Convert.ToInt32(dr1["PK"]);
                    obj1.mobileNo = Convert.ToString(dr1["mobile"]);
                    obj1.message = Convert.ToString(dr1["Message"]);
                    obj1.date = Convert.ToString(dr1["shortcode"]);
                    obj1.flag = Convert.ToInt32(dr1["FlagStatus"]);
                    objBllVar.Add(obj1);

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
               return objBllVar;
        }
       
    }
     


  
    public List<VerifySMSBLL> getSendSMSHistory(VerifySMSBLL obj)
    {
        List<VerifySMSBLL> objBllVar = new List<VerifySMSBLL>();
        DataSet ds = new DataSet();
        string sql = "select * from sendSMSstatus";
        ds = cc.ExecuteDataset(sql);
        foreach (DataRow dr1 in ds.Tables[0].Rows)
        {
            VerifySMSBLL obj1 = new VerifySMSBLL();
            obj1.ID = Convert.ToInt32(dr1["ID"]);
            obj1.SendFrom = Convert.ToString(dr1["SendFrom"]);
            obj1.SendTo = Convert.ToString(dr1["SendTo"]);
            obj1.SendSMS = Convert.ToString(dr1["sentMessage"]);
            obj1.FlagCode = Convert.ToString(dr1["Flag"]);
            objBllVar.Add(obj1);

        }




        return objBllVar;
    }
}

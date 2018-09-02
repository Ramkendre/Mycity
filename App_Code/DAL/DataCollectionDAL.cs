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

/// <summary>
/// Summary description for DataCollectionDAL
/// </summary>
public class DataCollectionDAL
{
    CommonCode cc = new CommonCode();
    int status;
    DataSet ds = new DataSet();
    public DataCollectionDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int DALInsertLongCodeRegistration(DataCollectionBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "insert into [Come2myCityDB].[come2mycity].LongCodeRegistration(customer_name,address,mobileno,Sim_no,reg_date,IMEINO,customer_contact,no_usefor,send_data,Response_Msg,MissCallType,customer_contact1,customer_contact2,customer_contact3,customer_contact4)" +
                    " values('" + obj.Customername + "','" + obj.Address + "','" + obj.Mobileno + "','" + obj.SIMno + "','" + obj.Regdate + "','" + obj.IMEIMO + "','" + obj.Customer_contact + "','" + obj.No_usefor + "','" +
                    obj.Send_data + "','" + obj.ResponseMsg + "','" + obj.MissCallType1 + "','" + obj.Customer_contact1 + "','" + obj.Customer_contact2 + "','" + obj.Customer_contact3 + "','" + obj.Customer_contact4 + "')";
                status = cc.ExecuteNonQuery(sql);

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

    public int DALUpdateLongCodeRegistration(DataCollectionBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "update [Come2myCityDB].[come2mycity].LongCodeRegistration set Response_Msg='" + obj.ResponseMsg + "' where  reg_id='" + obj.Regid + "'";
                status = cc.ExecuteNonQuery(sql);

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

    public DataSet DALGetLongCodeDetails(DataCollectionBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                string sql = "select * from [Come2myCityDB].[come2mycity].LongCodeRegistration order by reg_id desc";
                ds = cc.ExecuteDataset(sql);

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
        return ds;
    }

    public int DALDeleteLongCode(DataCollectionBLL obj)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                string sql = "delete from [Come2myCityDB].[come2mycity].LongCodeRegistration where reg_id='" + obj.Regid + "'";
                status = cc.ExecuteNonQuery(sql);

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

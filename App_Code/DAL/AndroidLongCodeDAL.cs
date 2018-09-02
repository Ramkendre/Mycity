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
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for AndroidLongCodeDAL
/// </summary>
public class AndroidLongCodeDAL
{
    int status;
    public AndroidLongCodeDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int DALInsertAndroidData(AndroidLongCodeBLL ur)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[50];
                par[0] = new SqlParameter("@p1", ur.P1);
                par[1] = new SqlParameter("@p2", ur.P2);
                par[2] = new SqlParameter("@p3", ur.P3);
                par[3] = new SqlParameter("@p4", ur.P4);
                par[4] = new SqlParameter("@p5", ur.P5);
                par[5] = new SqlParameter("@p6", ur.P6);
                par[6] = new SqlParameter("@p7", ur.P7);
                par[7] = new SqlParameter("@p8", ur.P8);
                par[8] = new SqlParameter("@p9", ur.P9);
                par[9] = new SqlParameter("@p10", ur.P10);
                par[10] = new SqlParameter("@p11", ur.P11);
                par[11] = new SqlParameter("@p12", ur.P12);
                par[12] = new SqlParameter("@p13", ur.P13);
                par[13] = new SqlParameter("@p14", ur.P14);
                par[14] = new SqlParameter("@p15", ur.P15);
                par[15] = new SqlParameter("@p16", ur.P16);
                par[16] = new SqlParameter("@p17", ur.P17);
                par[17] = new SqlParameter("@p18", ur.P18);
                par[18] = new SqlParameter("@date", ur.Date);
                par[19] = new SqlParameter("@p19", ur.P19);
                par[20] = new SqlParameter("@p20", ur.P20);
                par[21] = new SqlParameter("@p21", ur.P21);
                par[22] = new SqlParameter("@p22", ur.P22);
                par[23] = new SqlParameter("@p23", ur.P23);
                par[24] = new SqlParameter("@p24", ur.P24);
                par[25] = new SqlParameter("@p25", ur.P25);
                par[26] = new SqlParameter("@p26", ur.P26);
                par[27] = new SqlParameter("@p27", ur.P27);
                par[28] = new SqlParameter("@p28", ur.P28);
                par[29] = new SqlParameter("@p29", ur.P29);
                par[30] = new SqlParameter("@p30", ur.P30);
                par[31] = new SqlParameter("@p31", ur.P31);
                par[32] = new SqlParameter("@p32", ur.P32);
                par[33] = new SqlParameter("@p33", ur.P33);
                par[34] = new SqlParameter("@p34", ur.P34);
                par[35] = new SqlParameter("@p35", ur.P35);
                par[36] = new SqlParameter("@p36", ur.P36);

                par[37] = new SqlParameter("@p37", ur.P37);
                par[38] = new SqlParameter("@p38", ur.P38);
                par[39] = new SqlParameter("@p39", ur.P39);
                par[40] = new SqlParameter("@p40", ur.P40);
                par[41] = new SqlParameter("@p41", ur.P41);
                par[42] = new SqlParameter("@p42", ur.P42);
                par[43] = new SqlParameter("@p43", ur.P43);
                par[44] = new SqlParameter("@p44", ur.P44);
                par[45] = new SqlParameter("@status", 50);
                par[45].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "AndroidInsertkeyword", par);
                status = (int)par[45].Value;

            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
        return status;

    }

    public string DALGetUseridAndroid(AndroidLongCodeBLL ur)
    {
        //string mobileno = "";
        SqlDataReader dr;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@IMEINO", ur.P2);
                par[1] = new SqlParameter("@Sim_no", ur.P1);
                //par[2] = new SqlParameter("@status", 4);
                //par[2].Direction = ParameterDirection.Output;
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "GetContactNobySimno", par);
                if (dr.HasRows)
                {
                    dr.Read();
                    ur.Mobile = Convert.ToString(dr["mobileno"]);
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
        return ur.Mobile;

    }
}

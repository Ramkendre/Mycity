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
/// Summary description for BSSGRulesSettingDAL
/// </summary>
public class BSSGRulesSettingDAL
{
	public BSSGRulesSettingDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet LoadGrid(BSSGRulesSettingBLL SSGB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[1];
            par[0] = new SqlParameter("@UserId", SSGB.UserId1);
            SqlCommand cmd = new SqlCommand("uspBLoadSSGRuleSetting", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            return ds;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int AddRecord(BSSGRulesSettingBLL SSGB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
              new SqlParameter("@MemberShipFee",SSGB.MemberShipFee1),  
              new SqlParameter("@DueDateSP",SSGB.DueDateSP1),new SqlParameter("@PAmount",SSGB.PAmount1),
              new SqlParameter("@AdditionalAmt",SSGB.AdditionalAmt1), new SqlParameter("@LoanLimit",SSGB.LoanLimit1),
              new SqlParameter("@IntOnLoan",SSGB.IntOnLoan1),new SqlParameter("@IntOnDeposit",SSGB.IntOnDeposit1),
              new SqlParameter("@DueDays",SSGB.DueDays1),new SqlParameter("@PIntRate",SSGB.PIntRate1),
              new SqlParameter("@BankANo",SSGB.BankANo1),new SqlParameter("@BankName",SSGB.BankName1),
              new SqlParameter("@TypeOfExp",SSGB.TypeOfExp1),new SqlParameter("@FYrOfExpYrFr",SSGB.FYrOfExpYrFr1),
              new SqlParameter("@FYrOfExpYrFrM",SSGB.FYrOfExpYrFrM1), new SqlParameter("@UserId",SSGB.UserId1), 
            };
            SqlCommand cmd = new SqlCommand("uspBSSGRuleSettingInsertMyct", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int Update(BSSGRulesSettingBLL SSGB)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",SSGB.ID1),
              new SqlParameter("@MemberShipFee",SSGB.MemberShipFee1),  
              new SqlParameter("@DueDateSP",SSGB.DueDateSP1),new SqlParameter("@PAmount",SSGB.PAmount1),
              new SqlParameter("@AdditionalAmt",SSGB.AdditionalAmt1), new SqlParameter("@LoanLimit",SSGB.LoanLimit1),
              new SqlParameter("@IntOnLoan",SSGB.IntOnLoan1),new SqlParameter("@IntOnDeposit",SSGB.IntOnDeposit1),
              new SqlParameter("@DueDays",SSGB.DueDays1),new SqlParameter("@PIntRate",SSGB.PIntRate1),
              new SqlParameter("@BankANo",SSGB.BankANo1),new SqlParameter("@BankName",SSGB.BankName1),
              new SqlParameter("@TypeOfExp",SSGB.TypeOfExp1),new SqlParameter("@FYrOfExpYrFr",SSGB.FYrOfExpYrFr1),
              new SqlParameter("@FYrOfExpYrFrM",SSGB.FYrOfExpYrFrM1),  
            };
            SqlCommand cmd = new SqlCommand("uspUBSSGRuleSetting", con);
            cmd.Parameters.AddRange(par);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            return result;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Select(BSSGRulesSettingBLL SSGB)
    {
        SqlDataReader dr;
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            SqlParameter[] par = new SqlParameter[]
            {
                new SqlParameter("@ID",SSGB.ID1),
            };
            dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspSelectBSSGRuleSetting", par);
            if(dr.HasRows)
            {
                dr.Read();
                SSGB.MemberShipFee1 = Convert.ToString(dr["MemberShipFee"]);
                SSGB.DueDateSP1 = Convert.ToString(dr["DueDateSP"]);
                SSGB.PAmount1 = Convert.ToString(dr["PAmount"]);
                SSGB.AdditionalAmt1 = Convert.ToString(dr["AdditionalAmt"]);
                SSGB.LoanLimit1 = Convert.ToString(dr["LoanLimit"]);
                SSGB.IntOnLoan1 = Convert.ToString(dr["IntOnLoan"]);
                SSGB.IntOnDeposit1 = Convert.ToString(dr["IntOnDeposit"]);
                SSGB.DueDays1 = Convert.ToString(dr["DueDays"]);
                SSGB.PIntRate1 = Convert.ToString(dr["PIntRate"]);
                SSGB.BankANo1 = Convert.ToString(dr["BankANo"]);
                SSGB.BankName1 = Convert.ToString(dr["BankName"]);
                SSGB.TypeOfExp1 = Convert.ToString(dr["TypeOfExp"]);
                SSGB.FYrOfExpYrFr1 = Convert.ToString(dr["FYrOfExpYrFr"]);
                SSGB.FYrOfExpYrFrM1 = Convert.ToString(dr["FYrOfExpYrFrM"]);
            }
        }
        catch(Exception ex)
        {
        
        }

    }
}

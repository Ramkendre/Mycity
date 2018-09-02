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

/// <summary>
/// Summary description for BSSGRulesSettingBLL
/// </summary>
public class BSSGRulesSettingBLL
{
	public BSSGRulesSettingBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private Int16 ID;
    public Int16 ID1
    {
        get { return ID; }
        set { ID = value; }
    }
    private string MemberShipFee;

    public string MemberShipFee1
    {
        get { return MemberShipFee; }
        set { MemberShipFee = value; }
    }
    private string DueDateSP;

    public string DueDateSP1
    {
        get { return DueDateSP; }
        set { DueDateSP = value; }
    }

    private String PAmount;
    public String PAmount1
    {
        set { PAmount = value; }
        get { return PAmount; }
    }
    private String AdditionalAmt;
    public String AdditionalAmt1
    {
        set { AdditionalAmt = value; }
        get { return AdditionalAmt; }
    }
    private String LoanLimit;
    public String LoanLimit1
    {
        set { LoanLimit = value; }
        get { return LoanLimit; }
    }
    private String IntOnLoan;
    public String IntOnLoan1
    {
        set { IntOnLoan = value; }
        get { return IntOnLoan; }
    }
    private String IntOnDeposit;
    public String IntOnDeposit1
    {
        set { IntOnDeposit = value; }
        get { return IntOnDeposit; }
    }
    private String DueDays;
    public String DueDays1
    {
        set { DueDays = value; }
        get { return DueDays; }
    }
    private String PIntRate;
    public String PIntRate1
    {
        set { PIntRate = value; }
        get { return PIntRate; }
    }
    private String BankANo;
    public String BankANo1
    {
        set { BankANo = value; }
        get { return BankANo; }
    }
    private String BankName;
    public String BankName1
    {
        set { BankName = value; }
        get { return BankName; }
    }
    private String TypeOfExp;
    public String TypeOfExp1
    {
        set { TypeOfExp = value; }
        get { return TypeOfExp; }
    }
    private String FYrOfExpYrFr;
    public String FYrOfExpYrFr1
    {
        set { FYrOfExpYrFr = value; }
        get { return FYrOfExpYrFr; }

    }
    private String FYrOfExpYrFrM;
    public String FYrOfExpYrFrM1
    {
        set { FYrOfExpYrFrM = value; }
        get { return FYrOfExpYrFrM; }
    }

    private String UserId;
    public String UserId1
    {
        set { UserId = value; }
        get { return UserId; }
    }
    private String EntryDate;
    public String EntryDate1
    {
        set { EntryDate = value; }
        get { return EntryDate; }
    }

    BSSGRulesSettingDAL objBSSGRulesSettingDAL = new BSSGRulesSettingDAL();

    public DataSet LoadgridBLL(BSSGRulesSettingBLL objBSSGRulesSettingBLL)
    {
        return objBSSGRulesSettingDAL.LoadGrid(objBSSGRulesSettingBLL);

    }
    public int AddRecordBLL(BSSGRulesSettingBLL objBSSGRulesSettingBLL)
    {
        int k = objBSSGRulesSettingDAL.AddRecord(objBSSGRulesSettingBLL);
        return k;
    }
    public int UpdateBLL(BSSGRulesSettingBLL objBSSGRulesSettingBLL)
    {
        int i = objBSSGRulesSettingDAL.Update(objBSSGRulesSettingBLL);
        return i;
    }
    public void SelectBLL(BSSGRulesSettingBLL objBSSGRulesSettingBLL)
    {
        objBSSGRulesSettingDAL.Select(objBSSGRulesSettingBLL);
    
    }
}

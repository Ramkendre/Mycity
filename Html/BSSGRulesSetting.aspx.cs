using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Html_BSSGRulesSetting : System.Web.UI.Page
{
    BSSGRulesSettingBLL objBSSGRulesSettingBLL = new BSSGRulesSettingBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadGrid();
        }
    }

    public void LoadGrid()
    {
        objBSSGRulesSettingBLL.UserId1 = Convert.ToString(Session["User"]);
        DataSet ds = objBSSGRulesSettingBLL.LoadgridBLL(objBSSGRulesSettingBLL);
        if (ds.Tables[0].Rows.Count != 0)
        {
            gvItem.DataSource = ds;
            gvItem.DataBind();
        }
    }

    public void AddRecord()
    {
        objBSSGRulesSettingBLL.MemberShipFee1 = Convert.ToString(txtMemFees.Text);
        objBSSGRulesSettingBLL.DueDateSP1 = Convert.ToString(txtdate.Text);
        objBSSGRulesSettingBLL.PAmount1 = Convert.ToString(txtPAmount.Text);
        objBSSGRulesSettingBLL.AdditionalAmt1 = Convert.ToString(rbtnPAount.Text);
        objBSSGRulesSettingBLL.LoanLimit1 = Convert.ToString(txtLLimit.Text);
        objBSSGRulesSettingBLL.IntOnLoan1 = Convert.ToString(txtIOLoan.Text);
        objBSSGRulesSettingBLL.IntOnDeposit1 = Convert.ToString(txtIODeposit.Text);
        objBSSGRulesSettingBLL.DueDays1 = Convert.ToString(txtDueDays.Text);
        objBSSGRulesSettingBLL.PIntRate1 = Convert.ToString(txtPenaltyIntrest.Text);
        objBSSGRulesSettingBLL.BankANo1 = Convert.ToString(txtBAcNo.Text);
        objBSSGRulesSettingBLL.BankName1 = Convert.ToString(txtBankName.Text);
        objBSSGRulesSettingBLL.TypeOfExp1 = Convert.ToString(ddlTExp.Text);
        objBSSGRulesSettingBLL.FYrOfExpYrFr1 = Convert.ToString(txtdateFr.Text);
        objBSSGRulesSettingBLL.FYrOfExpYrFrM1 = Convert.ToString(txtdateM.Text);
        objBSSGRulesSettingBLL.UserId1 = Convert.ToString(Session["User"]);
        int Status = objBSSGRulesSettingBLL.AddRecordBLL(objBSSGRulesSettingBLL);
        if (Status == 1)
        {
            LoadGrid();
            clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void Update(string ID)
    {
        objBSSGRulesSettingBLL.ID1 = Convert.ToInt16(ID);
        objBSSGRulesSettingBLL.MemberShipFee1 = Convert.ToString(txtMemFees.Text);
        objBSSGRulesSettingBLL.DueDateSP1 = Convert.ToString(txtdate.Text);
        objBSSGRulesSettingBLL.PAmount1 = Convert.ToString(txtPAmount.Text);
        objBSSGRulesSettingBLL.AdditionalAmt1 = Convert.ToString(rbtnPAount.Text);
        objBSSGRulesSettingBLL.LoanLimit1 = Convert.ToString(txtLLimit.Text);
        objBSSGRulesSettingBLL.IntOnLoan1 = Convert.ToString(txtIOLoan.Text);
        objBSSGRulesSettingBLL.IntOnDeposit1 = Convert.ToString(txtIODeposit.Text);
        objBSSGRulesSettingBLL.DueDays1 = Convert.ToString(txtDueDays.Text);
        objBSSGRulesSettingBLL.PIntRate1 = Convert.ToString(txtPenaltyIntrest.Text);
        objBSSGRulesSettingBLL.BankANo1 = Convert.ToString(txtBAcNo.Text);
        objBSSGRulesSettingBLL.BankName1 = Convert.ToString(txtBankName.Text);
        objBSSGRulesSettingBLL.TypeOfExp1 = Convert.ToString(ddlTExp.Text);
        objBSSGRulesSettingBLL.FYrOfExpYrFr1 = Convert.ToString(txtdateFr.Text);
        objBSSGRulesSettingBLL.FYrOfExpYrFrM1 = Convert.ToString(txtdateM.Text);

        int Status = objBSSGRulesSettingBLL.UpdateBLL(objBSSGRulesSettingBLL);
        if (Status == 1)
        {
            LoadGrid();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Update Successfully')", true);
        }
    }
    public void clear()
    {
        txtMemFees.Text = "";
        txtdate.Text = "";
        txtPAmount.Text = "";
        txtLLimit.Text = "";
        txtIOLoan.Text = "";
        txtIODeposit.Text = "";
        txtDueDays.Text="";
        txtPenaltyIntrest.Text = "";
        txtBAcNo.Text = "";
        txtBankName.Text = "";
        txtdateFr.Text = "";
        txtdateM.Text = "";
    }
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        string ID = Convert.ToString(lblId.Text.ToString());
        if (ID == "" || ID == null)
        {
            AddRecord();
        }
        else
        {
            Update(ID);
        }
    }

    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSumbit.Text = "Update";
            string ID = Convert.ToString(e.CommandArgument);
            lblId.Text = ID;
            objBSSGRulesSettingBLL.ID1 = Convert.ToInt16(ID);
            objBSSGRulesSettingBLL.SelectBLL(objBSSGRulesSettingBLL);

            txtMemFees.Text = Convert.ToString(objBSSGRulesSettingBLL.MemberShipFee1);
            txtdate.Text = Convert.ToString(objBSSGRulesSettingBLL.DueDateSP1);
            txtPAmount.Text = Convert.ToString(objBSSGRulesSettingBLL.PAmount1);
            rbtnPAount.Text = Convert.ToString(objBSSGRulesSettingBLL.AdditionalAmt1);
            txtLLimit.Text = Convert.ToString(objBSSGRulesSettingBLL.LoanLimit1);
            txtIOLoan.Text = Convert.ToString(objBSSGRulesSettingBLL.IntOnLoan1);
            txtIODeposit.Text=Convert.ToString(objBSSGRulesSettingBLL.IntOnDeposit1);
            txtDueDays.Text=Convert.ToString(objBSSGRulesSettingBLL.DueDays1);
            txtPenaltyIntrest.Text = Convert.ToString(objBSSGRulesSettingBLL.PIntRate1);
            txtBAcNo.Text = Convert.ToString(objBSSGRulesSettingBLL.BankANo1);
            txtBankName.Text = Convert.ToString(objBSSGRulesSettingBLL.BankName1);
            txtdateFr.Text = Convert.ToString(objBSSGRulesSettingBLL.FYrOfExpYrFr1);
            txtdateM.Text = Convert.ToString(objBSSGRulesSettingBLL.FYrOfExpYrFrM1);
        }

        if (Convert.ToString(e.CommandName) == "Delete")
        {
            string ID = Convert.ToString(e.CommandArgument);

            string str = "Delete from [Come2myCityDB].[dbo].[tbl_BSSGRuleSetting] where ID='" + ID + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            int st = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

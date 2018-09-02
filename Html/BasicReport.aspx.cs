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

public partial class Html_BasicReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { }
    }
    public void LoadGrid()
    {
        string str = "SELECT [MID],[GID],[FName],[LName],[MobileNo],[Post],[DOJ],[Subscription],[Deposite],[Loan],UserId FROM [Come2myCityDB].[dbo].[tbl_BMRegistration] where UserId='" + Session["User"] + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();
    }
    public void LoadGridLoan()
    {
        string str3 = "SELECT [ID],[MID],[PreBalance],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate] FROM [Come2myCityDB].[dbo].[tbl_BIssueLoan] where UserId='" + Session["User"] + "' ";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str3, con);
        da.Fill(ds);
        gvItemLoan.DataSource = ds.Tables[0];
        gvItemLoan.DataBind();
    }
    public void LoadGridInst()
    {
        string str1 = "SELECT [ID],[MID],[SubAmt],[LInstalment],[LIMonth],[Date] FROM [Come2myCityDB].[dbo].[tbl_BSubInstalment] where UserId='" + Session["User"] + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str1, con);
        da.Fill(ds);
        gvItemInst.DataSource = ds.Tables[0];
        gvItemInst.DataBind();
    }
    public void LoadGridDep()
    {
        string str2 = "SELECT [ID],[MID],[DepositeAmt],[PaymentType],[Date],[DepositPeriod] FROM [Come2myCityDB].[dbo].[tbl_BReceiveDeposite] where UserId='" + Session["User"] + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str2,con);
        da.Fill(ds);
        gvItemDeposite.DataSource = ds.Tables[0];
        gvItemDeposite.DataBind();
    }
    public void LoadgridExp()
    {
        string str = "SELECT [ID],[Date],[VoucharNo],[TypeOfExp],[Amount],[Description],[Mode]  FROM [Come2myCityDB].[dbo].[tbl_BExpenditureE] where UserId='" + Session["User"] + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        gvItemExp.DataSource = ds.Tables[0];
        gvItemExp.DataBind();

    }
    protected void lnkMemList_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        LoadGrid();
    }
    protected void lnkLoanIssued_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        LoadGridLoan();
    }
    protected void lnkInstal_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View3);
        LoadGridInst();
    }
    protected void lnkDeposite_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View4);
        LoadGridDep();
    }
    protected void lnkExp_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View5);
        LoadgridExp();
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {
        //MultiView1.ActiveViewChanged = -1;
    }
    protected void View2_Activate(object sender, EventArgs e)
    {

    }
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        gvItem.DataBind();
        LoadGrid();
    }
    protected void gvItemLoan_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemLoan.PageIndex = e.NewPageIndex;
        gvItemLoan.DataBind();
        LoadGridLoan();
    }
    protected void gvItemInst_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemInst.PageIndex = e.NewPageIndex;
        gvItemInst.DataBind();
        LoadGridInst();
    }
    protected void gvItemDeposite_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemDeposite.PageIndex = e.NewPageIndex;
        gvItemDeposite.DataBind();
        LoadGridDep();
    }
    protected void gvItemExp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemExp.PageIndex = e.NewPageIndex;
        gvItemExp.DataBind();
        LoadgridExp();
    }
}

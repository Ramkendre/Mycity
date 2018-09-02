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

public partial class Html_BReceiveDeposite : System.Web.UI.Page
{
    BReceiveDepBLL objBReceiveDep= new BReceiveDepBLL();
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            Fill();
        }
    }
    public void Fill()
    {
     
        string str = "select FName + replicate(' ', 20 - len(FName)) + LName as name,MID from [Come2myCityDB].[dbo].[tbl_BMRegistration]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        ddlSMember.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlSMember.DataValueField = "MID";
            ddlSMember.DataTextField = "name";
        }
        ddlSMember.DataBind();
        ddlSMember.Items.Add("Select");
        ddlSMember.SelectedIndex = ddlSMember.Items.Count - 1;
        ddlSMember.Items[ddlSMember.Items.Count-1].Value="";
   
    }
    public void LoadGrid()
    {
        objBReceiveDep.UserId1 = Convert.ToString(Session["User"]);
        DataSet ds = objBReceiveDep.LoadgridBLL(objBReceiveDep);
        if (ds.Tables[0].Rows.Count != 0)
        {
            gvItem.DataSource = ds;
            gvItem.DataBind();
        }
    }

    public void AddRecord()
    {
        string st = DateTime.Now.Date.ToString("yyyy-MM-dd");

        string str = "select MID from [Come2myCityDB].[dbo].[tbl_BMRegistration] where FName='" + ddlSMember.SelectedItem.ToString() + "'";
        string sql = cc.ExecuteScalar(str);

        
        objBReceiveDep.MID1 = Convert.ToString(sql);
        objBReceiveDep.DepositPeriod1 = Convert.ToString(txtTTPDeposit.Text);
        objBReceiveDep.DepositeAmt1 = Convert.ToString(txtLAmount.Text);
        objBReceiveDep.PaymentType1 = Convert.ToString(rbtnReceivedBy.Text);
        objBReceiveDep.Date1 = Convert.ToString(txtdate.Text);
        objBReceiveDep.UserId1 = Convert.ToString(Session["User"]);
        objBReceiveDep.EntryDate1 = Convert.ToString(st);
        int Status = objBReceiveDep.AddRecordBLL(objBReceiveDep);
        if (Status == 1)
        {
            LoadGrid();
            Clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void Update(string ID)
    {
        string st = DateTime.Now.Date.ToString("yyyy-MM-dd");
        objBReceiveDep.ID1 = Convert.ToInt16(ID);
        objBReceiveDep.MID1 = Convert.ToString(ddlSMember.SelectedItem.Text);
        objBReceiveDep.DepositPeriod1 = Convert.ToString(txtTTPDeposit.Text);
        objBReceiveDep.DepositeAmt1 = Convert.ToString(txtLAmount.Text);
        objBReceiveDep.PaymentType1 = Convert.ToString(rbtnReceivedBy.Text);
        objBReceiveDep.Date1 = Convert.ToString(txtdate.Text);
        //objBReceiveDep.UserId1 = Convert.ToString(Session["User"]);
        objBReceiveDep.EntryDate1 = Convert.ToString(st);
        int Status = objBReceiveDep.UpdateBLL(objBReceiveDep);
        if (Status == 1)
        {
            LoadGrid();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated Successfully')", true);
        }
    }
    public void Clear()
    {
        txtTTPDeposit.Text = "";
        txtLAmount.Text = "";
        rbtnReceivedBy.Text = "";
        txtdate.Text = "";
    }
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
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
        if(Convert.ToString(e.CommandName)=="Modify")
        {
            btnSumbit.Text = "Update";
            string ID = Convert.ToString(e.CommandArgument);
            lblId.Text = ID;
            objBReceiveDep.ID1 = Convert.ToInt16(ID);
            objBReceiveDep.SelectBLL(objBReceiveDep);

            ddlSMember.SelectedItem.Text = Convert.ToString(objBReceiveDep.MID1); ;
            txtTTPDeposit.Text = Convert.ToString(objBReceiveDep.DepositPeriod1);
            txtLAmount.Text = Convert.ToString(objBReceiveDep.DepositeAmt1);
            rbtnReceivedBy.Text = Convert.ToString(objBReceiveDep.PaymentType1);
            txtdate.Text = Convert.ToString(objBReceiveDep.Date1);

        }
    }
}

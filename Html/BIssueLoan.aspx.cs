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

public partial class Html_BIssueLoan : System.Web.UI.Page
{
    BIsueeLoanBLL objBIsueeLoanBLL = new BIsueeLoanBLL();
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadgrid();
            Fill();
        }
    }
    public void Fill()
    {
        string str = "Select FName  + replicate(' ', 20 - len(FName)) + LName as name,MID from [Come2myCityDB].[dbo].[tbl_BMRegistration]";
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
        ddlSMember.Items[ddlSMember.Items.Count - 1].Value = "";
    }
    public void loadgrid()
    {
        objBIsueeLoanBLL.UserId1 = Convert.ToString(Session["User"]);
        DataSet ds = objBIsueeLoanBLL.LoadgridBLL(objBIsueeLoanBLL);
        if (ds.Tables[0].Rows.Count != 0)
        {
            gvItem.DataSource = ds;
            gvItem.DataBind();
        }
    }
    public void Addrecord()
    {
        string str = "Select MID from [Come2myCityDB].[dbo].[tbl_BMRegistration]";
        string sql = cc.ExecuteScalar(str);
        objBIsueeLoanBLL.MID1 = Convert.ToString(sql);
        //objBIsueeLoanBLL.PreBalance1 = Convert.ToString();
        objBIsueeLoanBLL.LoanAmt1 = Convert.ToString(txtLAmount.Text);
        objBIsueeLoanBLL.DateOfIssue1 = Convert.ToString(txtdate.Text);
        objBIsueeLoanBLL.MInstalment1 = Convert.ToString(txtMInst.Text);
        objBIsueeLoanBLL.DueDate1 = Convert.ToString(txtDueDate.Text);
        objBIsueeLoanBLL.UserId1 = Convert.ToString(Session["User"]);
        int Status = objBIsueeLoanBLL.AddRecordBLL(objBIsueeLoanBLL);
        if (Status == 1)
        {
            loadgrid();
            clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void Update(string ID)
    {
        
        objBIsueeLoanBLL.ID1 = Convert.ToInt16(ID);
        objBIsueeLoanBLL.MID1 = Convert.ToString(ddlSMember.SelectedItem.ToString());
        objBIsueeLoanBLL.LoanAmt1 = Convert.ToString(txtLAmount.Text);
        objBIsueeLoanBLL.DateOfIssue1 = Convert.ToString(txtdate.Text);
        objBIsueeLoanBLL.MInstalment1 = Convert.ToString(txtMInst.Text);
        objBIsueeLoanBLL.DueDate1 = Convert.ToString(txtDueDate.Text);
        objBIsueeLoanBLL.UserId1 = Convert.ToString(Session["User"]);
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
        objBIsueeLoanBLL.EntryDate1 = Convert.ToString(str);
        int Status = objBIsueeLoanBLL.Update(objBIsueeLoanBLL);
        if (Status == 1)
        {
            loadgrid();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Updated Successfully')", true);
        }
    }
    public void clear()
    {
        txtLAmount.Text = "";
        txtdate.Text = "";
        txtMInst.Text = "";
        txtDueDate.Text = "";

    }
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }

    protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        string ID = Convert.ToString(lblId.Text.ToString());
        if (ID == "" || ID == null)
        {
            Addrecord();
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
            objBIsueeLoanBLL.ID1 = Convert.ToInt16(ID);
            objBIsueeLoanBLL.SelectRecord(objBIsueeLoanBLL);

            ddlSMember.SelectedItem.Text = Convert.ToString(objBIsueeLoanBLL.MID1);
            txtMInst.Text = Convert.ToString(objBIsueeLoanBLL.MInstalment1);
            txtLAmount.Text = Convert.ToString(objBIsueeLoanBLL.LoanAmt1);
            txtdate.Text = Convert.ToString(objBIsueeLoanBLL.DateOfIssue1);
            txtDueDate.Text = Convert.ToString(objBIsueeLoanBLL.DueDate1);
        }

        if(Convert.ToString(e.CommandName)=="Delete")
        {
            string ID = Convert.ToString(e.CommandArgument);
            lblId.Text = ID;
            objBIsueeLoanBLL.ID1 = Convert.ToInt16(ID);

            string str = "Delete from [Come2myCityDB].[dbo].[tbl_BIssueLoan] where ID='"+ID+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(str,con);
             cmd.ExecuteNonQuery();
             con.Close();
             ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Deleted Successfully')", true);
        }
    }
}


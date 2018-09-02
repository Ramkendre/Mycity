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

public partial class Html_BSubscriptionInstalment : System.Web.UI.Page
{
    BSubscriptionInstBLL objBSubscriptionInstBLL = new BSubscriptionInstBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LoadGrid();
            fill();
        }
    }
    public void fill()
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
        objBSubscriptionInstBLL.UserId1 = Convert.ToString(Session["User"]);
        DataSet ds = objBSubscriptionInstBLL.LoadgridBLL(objBSubscriptionInstBLL);
        if (ds.Tables[0].Rows.Count != 0)
        {
            gvItem.DataSource = ds;
            gvItem.DataBind();
        }

    }
    public void clear()
    {
        txtSubscription.Text = "";
        txtLoanInst.Text = "";
        txtLIMonth.Text = "";
        txtdate.Text = "";
    }
    public void AddRecord()
    {
        string str = "Select MID from [Come2myCityDB].[dbo].[tbl_BMRegistration]";
        string sql = cc.ExecuteScalar(str);
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        objBSubscriptionInstBLL.MID1 = Convert.ToString(sql);
        objBSubscriptionInstBLL.SubAmt1 = Convert.ToString(txtSubscription.Text);
        objBSubscriptionInstBLL.LInstalment1 = Convert.ToString(txtLoanInst.Text);
        objBSubscriptionInstBLL.LIMonth1 = Convert.ToString(txtLIMonth.Text);
        objBSubscriptionInstBLL.Date1 = Convert.ToString(txtdate.Text);
        objBSubscriptionInstBLL.UserId1 = Convert.ToString(Session["User"]);
        objBSubscriptionInstBLL.EnteryDate1 = Convert.ToString(str1);
        int Status = objBSubscriptionInstBLL.AddRecordBLL(objBSubscriptionInstBLL);
        if (Status == 1)
        {
            LoadGrid();
            clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }

    }
    public void UpdateRecord(string ID)
    {

        objBSubscriptionInstBLL.ID1 = Convert.ToInt16(ID);
        objBSubscriptionInstBLL.MID1 = Convert.ToString(ddlSMember.SelectedItem.ToString());
        objBSubscriptionInstBLL.SubAmt1 = Convert.ToString(txtSubscription.Text);
        objBSubscriptionInstBLL.LInstalment1 = Convert.ToString(txtLoanInst.Text);
        objBSubscriptionInstBLL.LIMonth1 = Convert.ToString(txtLIMonth.Text);
        objBSubscriptionInstBLL.Date1 = Convert.ToString(txtdate.Text);
        objBSubscriptionInstBLL.UserId1 = Convert.ToString(Session["User"]);
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
        objBSubscriptionInstBLL.EnteryDate1 = Convert.ToString(str);
        int Status = objBSubscriptionInstBLL.UpdateBLL(objBSubscriptionInstBLL);
        if (Status == 1)
        {
            LoadGrid();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated Successfully')", true);
        }
    }
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string ID = Convert.ToString(lblId.Text.ToString());
        if (ID == "" || ID == null)
        {
            AddRecord();
        }
        else
        {
            UpdateRecord(ID);
        }
    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(Convert.ToString(e.CommandName)=="Modify")
        {
            btnSubmit.Text = "Update";
            string ID = Convert.ToString(e.CommandArgument);
            lblId.Text = ID;
            objBSubscriptionInstBLL.ID1 = Convert.ToInt16(ID);
            objBSubscriptionInstBLL.SelectBLL(objBSubscriptionInstBLL);

            txtLoanInst.Text = Convert.ToString(objBSubscriptionInstBLL.LInstalment1);
            txtSubscription.Text = Convert.ToString(objBSubscriptionInstBLL.SubAmt1);
            txtdate.Text = Convert.ToString(objBSubscriptionInstBLL.LIMonth1);
            ddlSMember.SelectedItem.Text=Convert.ToString(objBSubscriptionInstBLL.MID1);
        }

        if(Convert.ToString(e.CommandName)=="Delete")
        {
            string ID=Convert.ToString(e.CommandArgument);

            string str = "Delete from [dbo].[tbl_BSubInstalment] where ID='"+ID+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(str,con);
            int st = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

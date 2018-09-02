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

public partial class Html_BMemRegistration : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    BMemRegBLL objBMemRegBLL = new BMemRegBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fill();
            LoadGrid();
        }
    }
    public void fill()
    {
        string str = "Select * from [Come2myCityDB].[dbo].[tbl_BCreateGat]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        ddlGID.DataSource=ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlGID.DataValueField="GID";
            ddlGID.DataTextField = "GatName";
        }
        ddlGID.DataBind();
        ddlGID.Items.Add("Select");
        ddlGID.SelectedIndex = ddlGID.Items.Count - 1;
        ddlGID.Items[ddlGID.Items.Count - 1].Value = "";
    }

    public void LoadGrid()
    {
        objBMemRegBLL.UserId1 = Convert.ToString(Session["User"]);
        DataSet ds = objBMemRegBLL.LoadgridBLL(objBMemRegBLL);
        if (ds.Tables[0].Rows.Count != 0)
        {
            gvItem.DataSource = ds;
            gvItem.DataBind();
        }
    }

    public void AddRecord()
    {
        string str = "select GID from [Come2myCityDB].[dbo].[tbl_BCreateGat] where GatName='" + ddlGID.SelectedItem.ToString() + "'";
        string sql = cc.ExecuteScalar(str);

        objBMemRegBLL.GID1 = Convert.ToString(sql);
        objBMemRegBLL.FName1 = Convert.ToString(txtFName.Text);
        objBMemRegBLL.LName1 = Convert.ToString(txtLName.Text);
        objBMemRegBLL.MobileNo1 = Convert.ToString(txtMobileNo.Text);
        
        objBMemRegBLL.Post1 = Convert.ToString(ddlPost.Text);
        objBMemRegBLL.DOJ1 = Convert.ToString(txtdate.Text);
        objBMemRegBLL.Subscription1 = Convert.ToString(txtSub.Text);
        objBMemRegBLL.Deposite1 = Convert.ToString(txtDeposit.Text);
        objBMemRegBLL.Loan1 = Convert.ToString(txtLoan.Text);
        objBMemRegBLL.UserId1 = Convert.ToString(Session["User"]);
        int Status = objBMemRegBLL.AddRecordBLL(objBMemRegBLL);
        if (Status == 1)
        {
            LoadGrid();
            clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void UpdateRecord(string MID)
    {
        try
        {
            objBMemRegBLL.MID1 = Convert.ToInt16(MID);
            objBMemRegBLL.GID1 = Convert.ToString(ddlGID.SelectedItem.ToString());
            objBMemRegBLL.FName1 = Convert.ToString(txtFName.Text);
            objBMemRegBLL.LName1 = Convert.ToString(txtLName.Text);
            objBMemRegBLL.MobileNo1 = Convert.ToString(txtMobileNo.Text);
            objBMemRegBLL.Post1 = Convert.ToString(ddlPost.Text);
            objBMemRegBLL.DOJ1 = Convert.ToString(txtdate.Text);
            objBMemRegBLL.Subscription1 = Convert.ToString(txtSub.Text);
            objBMemRegBLL.Deposite1 = Convert.ToString(txtDeposit.Text);
            objBMemRegBLL.Loan1 = Convert.ToString(txtLoan.Text);
            objBMemRegBLL.UserId1 = Convert.ToString(Session["User"]);

            int Status = objBMemRegBLL.UpdateBLL(objBMemRegBLL);
            if (Status == 1)
            {
                LoadGrid();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated Successfully')", true);
            }
        }
        catch (SqlException ex)
        { }

    }
    public void clear()
    {
        txtFName.Text = "";
        txtLName.Text = "";
        txtMobileNo.Text = "";
        txtdate.Text = "";
        txtSub.Text = "";
        txtDeposit.Text = "";
        txtLoan.Text = "";
    }
    protected void btnSumbit_Click(object sender, EventArgs e)
    {
        string MID=Convert.ToString(lblId.Text.ToString());
        if(MID=="" || MID==null)
        {
            AddRecord();
        }
        else
        {
            UpdateRecord(MID);
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

    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if(Convert.ToString(e.CommandName)=="Modify")
      {
          btnSumbit.Text = "Update";
          string MID = Convert.ToString(e.CommandArgument);
          lblId.Text = MID;
          objBMemRegBLL.MID1 = Convert.ToInt16(MID);
          objBMemRegBLL.SelectBLL(objBMemRegBLL);

          ddlGID.SelectedItem.Text = Convert.ToString(objBMemRegBLL.GID1);
          txtFName.Text = Convert.ToString(objBMemRegBLL.FName1);
          txtLName.Text = Convert.ToString(objBMemRegBLL.LName1);
          txtMobileNo.Text = Convert.ToString(objBMemRegBLL.MobileNo1);
          ddlPost.SelectedItem.Text = Convert.ToString(objBMemRegBLL.Post1);
          txtLoan.Text = Convert.ToString(objBMemRegBLL.Loan1);
          txtSub.Text = Convert.ToString(objBMemRegBLL.Subscription1);
          txtDeposit.Text = Convert.ToString(objBMemRegBLL.Deposite1);
          txtLoan.Text = Convert.ToString(objBMemRegBLL.Loan1);

      }

      if(Convert.ToString(e.CommandName)=="Delete")
      {
          string MID = Convert.ToString(e.CommandArgument);
          lblId.Text = MID;
          objBMemRegBLL.MID1 = Convert.ToInt16(MID);
          con.Open();
          string str = "Delete From [Come2myCityDB].[dbo].[tbl_BMRegistration] where MID='"+MID+"'";
          SqlCommand cmd = new SqlCommand(str, con);
          cmd.ExecuteNonQuery();
          con.Close();
      }
    }
    protected void txtMobileNo_TextChanged(object sender, EventArgs e)
    {
        con.Open();
        string str = "select MobileNo from [Come2myCityDB].[dbo].[tbl_BMRegistration] where MobileNo='" + txtMobileNo.Text + "'";
       string sql=cc.ExecuteScalar(str);
        if(sql!="")
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Alredy Exit')", true); 
       }
       else
       {
           //AddRecord();
           
       }

    }
}

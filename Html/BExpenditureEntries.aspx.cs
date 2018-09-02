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

public partial class Html_BExpenditureEntries : System.Web.UI.Page
{
    BExpEntriesBLL objBExpEntriesBLL = new BExpEntriesBLL();
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {

        ReportDocument cryRpt = new ReportDocument();
        cryRpt.Load(Server.MapPath("practiceBachagat.rpt"));
        CrystalReportViewer1.ReportSource = cryRpt;     

        if(!IsPostBack)
        {
            LoadGrid();
        }
    }
    
    public void LoadGrid()
    {
        objBExpEntriesBLL.UserId1 = Convert.ToString(Session["User"]);
        
        DataSet ds = objBExpEntriesBLL.LoadgridBLL(objBExpEntriesBLL);
        if(ds.Tables[0].Rows.Count!=0)
        {
            gvItem.DataSource = ds;
            gvItem.DataBind();
        }
    }

    public void AddRecord()
    {
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
        objBExpEntriesBLL.Date1 = Convert.ToString(txtdate.Text);
        objBExpEntriesBLL.VoucharNo1 = Convert.ToString(txtVoucherNo.Text);
        objBExpEntriesBLL.TypeOfExp1 = Convert.ToString(ddlTOExp.Text);
        objBExpEntriesBLL.Amount1 = Convert.ToString(txtAmount.Text);
        objBExpEntriesBLL.Description1 = Convert.ToString(txtDescription.Text);
        objBExpEntriesBLL.Mode1 = Convert.ToString(rbtnMode.Text);
        objBExpEntriesBLL.UserId1 = Convert.ToString(Session["User"]);
        objBExpEntriesBLL.EntryDate1 = Convert.ToString(str);
        int Status = objBExpEntriesBLL.AddRecordBLL(objBExpEntriesBLL);
        if(Status==1)
        {
            LoadGrid();
            clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void UpdateRecord(string ID)
    {
        string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
        objBExpEntriesBLL.ID1 = Convert.ToInt16(ID);
        objBExpEntriesBLL.Date1 = Convert.ToString(txtdate.Text);
        objBExpEntriesBLL.VoucharNo1 = Convert.ToString(txtVoucherNo.Text);
        objBExpEntriesBLL.TypeOfExp1 = Convert.ToString(ddlTOExp.Text);
        objBExpEntriesBLL.Amount1 = Convert.ToString(txtAmount.Text);
        objBExpEntriesBLL.Description1 = Convert.ToString(txtDescription.Text);
        objBExpEntriesBLL.Mode1 = Convert.ToString(rbtnMode.Text);
        objBExpEntriesBLL.UserId1 = Convert.ToString(Session["User"]);
        objBExpEntriesBLL.EntryDate1 = Convert.ToString(str);
        int Status = objBExpEntriesBLL.UpdateBLL(objBExpEntriesBLL);
        if (Status == 1)
        {
            LoadGrid();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Updated Successfully')", true);
        } 
    }
    public void clear()
    {
        txtdate.Text = "";
        txtVoucherNo.Text = "";
        txtAmount.Text = "";
        txtDescription.Text = "";
        rbtnMode.Text = "";

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
        if(ID==null || ID=="")
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
            objBExpEntriesBLL.ID1 = Convert.ToInt16(ID);
            objBExpEntriesBLL.SelectBLL(objBExpEntriesBLL);

            txtdate.Text = Convert.ToString(objBExpEntriesBLL.Date1);
            txtVoucherNo.Text = Convert.ToString(objBExpEntriesBLL.VoucharNo1);
            ddlTOExp.SelectedItem.Text = Convert.ToString(objBExpEntriesBLL.TypeOfExp1);
            txtAmount.Text = Convert.ToString(objBExpEntriesBLL.Amount1);
            txtDescription.Text = Convert.ToString(objBExpEntriesBLL.Description1);
            rbtnMode.Text = Convert.ToString(objBExpEntriesBLL.Mode1);

        }

        if (Convert.ToString(e.CommandName) == "Delete")
        {
            string ID = Convert.ToString(e.CommandArgument);

            string str = "Delete from [Come2myCityDB].[dbo].[tbl_BExpenditureE] where ID='" + ID + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            int st = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

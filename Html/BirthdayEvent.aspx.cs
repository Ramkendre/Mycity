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
using Microsoft.Reporting.WebForms;


public partial class html_BirthdayEvent : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    EventBirthDayBLL objEBDB = new EventBirthDayBLL();
    SendSMSEvent sm = new SendSMSEvent();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    //string DateFormat;
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        string UserIdSession = Convert.ToString(Session["User"]);
        string user= Request.QueryString["UserIdSession"];
        lblUserId.Visible = true;
        lblUserId.Text = user;
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            //DateFormatStatus();
            //catchBday();
            if (!IsPostBack)
            {
               
                LoadGrid();
                Clear();
            }
        }
    }
    //----------------------------------------------------------Current Date Format---------------------------------------------------------------------

    //public void catchBday()
    //{
    //    DataSet ds = objEBDB.catchBdayBLL(objEBDB);
    //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    //    {
    //        string mobileNumber = ds.Tables[0].Rows[i][2].ToString();
    //        string messageToSend = "Your Ammount has been received.Your scrachCode for application is " + 123 + "";
    //        string s = sm.SendSMS("ezeesoft", "67893", mobileNumber, messageToSend);
    //    }
    //}
    //public void DateFormatStatus()
    //{
    //    DateTime dt = DateTime.Now; // get current date
    //    double d = 5; //add hours in time
    //    double m = 48; //add min in time
    //    DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
    //    SystemDate = SystemDate.AddMinutes(m);
    //    DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    //}
    public void LoadGrid()
    {
        try
        {
            objEBDB.UserId1 = Convert.ToString(Session["User"].ToString());
            DataSet ds = objEBDB.LoadgridBLL(objEBDB);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
            foreach (GridViewRow row in gvItem.Rows)
            {
                String data = row.Cells[5].Text;
                row.Cells[5].Text = data;
                
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //public void LoadGrid1()
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //}
    
    //protected void btnCreate_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string BID = Convert.ToString(lblId.Text);
    //        if (String.IsNullOrEmpty(BID))
    //        {
    //            AddRecord();
    //        }
    //        //else
    //        //{
    //        //    UpdateRecord(Id);
    //        //}

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    public void AddRecord()
    {
        try
        {
            objEBDB.NameOfPerson1 = Convert.ToString(txtNameOfPerson.Text);
            objEBDB.MobileNo1 = Convert.ToString(txtMobileNo.Text);
            objEBDB.Birthdate1 = Convert.ToString(txtBirthdate.Text);
            objEBDB.RemDate1 = Convert.ToString(txtRemDate.Text);
            objEBDB.Time1 = Convert.ToString(txtTime.Text);
            objEBDB.Gender1 = Convert.ToString(rbtnGender.Text);
            objEBDB.SMsg1 = Convert.ToString(rbtnSMsg.Text);
            objEBDB.MDescp1 = Convert.ToString(txtDescp.Text);
           
            objEBDB.UserId1 = Convert.ToString(Session["User"].ToString());
     
           
            int Status = objEBDB.AddRecordBLL(objEBDB);
            if (Status == 1)
            {
                LoadGrid();
                Clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this,typeof(Page),"msg","alert('Event not added Successfully')",true);
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        


    }
    public void UpdateRecord(String BID)
    {
        try
        {
            objEBDB.BID1 = Convert.ToInt16(BID);
            objEBDB.NameOfPerson1 = Convert.ToString(txtNameOfPerson.Text);
            objEBDB.MobileNo1 = Convert.ToString(txtMobileNo.Text);
            objEBDB.Birthdate1 = Convert.ToString(txtBirthdate.Text);
            objEBDB.RemDate1 = Convert.ToString(txtRemDate.Text);
            objEBDB.Time1 = Convert.ToString(txtTime.Text);
            objEBDB.Gender1=Convert.ToString(rbtnGender.Text);
            objEBDB.SMsg1=Convert.ToString(rbtnSMsg.Text);
            objEBDB.MDescp1 = Convert.ToString(txtDescp.Text);
            objEBDB.UserId1 = Convert.ToString(Session["User"]);
            int Status = objEBDB.UpdateRecordBLL(objEBDB);
            if (Status == 1)
            {
                LoadGrid();
                Clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Updated Successfully')", true);
            }
            else
            {
                
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Updated Successfully')", true);

            }

        }
        catch (Exception)
        {
        }
    }
    //public void UpdateRecord(string Id)
    //{
    //    try
    //    {
    //        objEBDB.BId1 = Convert.ToInt16(Id);
    //        objEBDB.NameOfPerson1 = Convert.ToString(txtName.Text);
    //        objEBDB.UserId1 = Convert.ToString(Session["User"]);
    //        objEBDB.Birthdate1 = Convert.ToString(txtBirthdate.Text);
    //        objEBDB.Time1 = Convert.ToString(txtTime.Text);
    //        objEBDB.Addr = Convert.ToString(txtDescp.Text);
    //        objEBDB.MobileNo1 = Convert.ToString(txtMobileNo.Text);
    //        int k = objEBDB.UpdateRecordBLL(objEBDB);
    //        if (k == 1)
    //        {
    //            LoadGrid();
    //            Clear();
    //            Response.Write("<script>alert('Event Update...')</script>");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    public void Clear()
    {
        lblId.Text = "";
        txtNameOfPerson.Text = "";
        txtMobileNo.Text = "";
        txtBirthdate.Text = "";
        txtTime.Text = "";
        txtDescp.Text = "";
        btnCtreate.Text = "Create";
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvItem.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
       
        
    //}


   
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }
    protected void btnCtreate_Click(object sender, EventArgs e)
    {
        try
        {
            string BID = Convert.ToString(lblId.Text);
            if (BID== "" || BID == null)
            {
                AddRecord();
            //catchBday();
            }
            else
            {
                UpdateRecord(BID);
            }
            //Response.Redirect("BirthdayEvent.aspx?Name="+this.txtNameOfPerson.Text);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnCtreate.Text = "Update";
            string BID = Convert.ToString(e.CommandArgument);
            lblId.Text = BID;
            objEBDB.BID1 = Convert.ToInt16(BID);
            objEBDB.Selectrecord(objEBDB);

            txtNameOfPerson.Text = Convert.ToString(objEBDB.NameOfPerson1);
            txtBirthdate.Text = Convert.ToString(objEBDB.Birthdate1);
            txtRemDate.Text = Convert.ToString(objEBDB.RemDate1);
            txtMobileNo.Text = Convert.ToString(objEBDB.MobileNo1);
            txtTime.Text = Convert.ToString(objEBDB.Time1);
            rbtnGender.Text = Convert.ToString(objEBDB.Gender1);
            rbtnSMsg.Text = Convert.ToString(objEBDB.SMsg1);
            txtDescp.Text = Convert.ToString(objEBDB.MDescp1);




        }
        if (Convert.ToString(e.CommandName) == "Delete")
        {
            string BID = Convert.ToString(e.CommandArgument);
            lblId.Text = BID;
            objEBDB.BID1 = Convert.ToInt16(BID);
            con.Open();
            string str = "Delete from [Come2myCityDB].[dbo].[tbl_EBirthDay] where BID='" + BID + "' ";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void gvItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void lnkexcel_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

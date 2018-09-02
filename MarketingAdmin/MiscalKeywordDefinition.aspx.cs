using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class MarketingAdmin_MiscalKeywordDefinition : System.Web.UI.Page
{
    int status;
    KeywordBLL keywordBLLObj = new KeywordBLL();
    DataTable dtkeywordList = new DataTable();
    CommonCode cc = new CommonCode();
    string choice = "";
    protected void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
           
            LoadKeyword();
            clearItems();
            Inboxshow();
        }
    }
    private void Inboxshow()
    {
        string userid = Session["MarketingUser"].ToString();
        string sql2 = "select sim_no,IMEINO from LongCodeRegistration where usrUserid='" + userid + "'";
        DataSet dd = cc.ExecuteDataset(sql2);
        string sim = Convert.ToString(dd.Tables[0].Rows[0]["sim_no"]);
        string IMEINo = Convert.ToString(dd.Tables[0].Rows[0]["IMEINO"]);
        string date = DateTime.Today.ToShortDateString();
        date = cc.ChangeDatenewformat(date);
        string sql = "select top(50)* from longCodeSmsReceve where p1='" + sim + "' and p2='" + IMEINo + "' order by id desc";
        DataSet ds = cc.ExecuteDataset(sql);
        gvInbox.DataSource = ds.Tables[0];
        gvInbox.DataBind();
        sql = "select count(*) from longCodeSmsReceve where p1='" + sim + "' and p2='" + IMEINo + "'";
        lblcount.Text = cc.ExecuteScalar(sql);

    }
    protected void btnSearch2_Click(object sender, EventArgs e)
    {
       // viewfromdateto();
    }
    //public void viewfromdateto()
    //{
    //    string userid = Session["MarketingUser"].ToString();
    //    string sql2 = "select sim_no,IMEINO from LongCodeRegistration where usrUserid='" + userid + "'";
    //    DataSet dd = cc.ExecuteDataset(sql2);
    //    string sim = Convert.ToString(dd.Tables[0].Rows[0]["sim_no"]);
    //    string IMEINo = Convert.ToString(dd.Tables[0].Rows[0]["IMEINO"]);
    // //   string datefrom = cc.ChangeDate(txtFrom1.Text);
    // //   string dateto = cc.ChangeDate(txtTo1.Text);
    // //   string sql = "select  * from longCodeSmsReceve where p1='" + sim + "' and p2='" + IMEINo + "' and (receivedDateTime >= (select CONVERT(varchar, '" + datefrom + "', 106)))and (receivedDateTime <= (select CONVERT(varchar, '" + dateto + "', 106)))";
    //    DataSet ds = cc.ExecuteDataset(sql);
    //    gvInbox.DataSource = ds.Tables[0];
    //    gvInbox.DataBind();
    //}
    protected void gvInbox_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInbox.PageIndex = e.NewPageIndex;
        Inboxshow();
       // viewfromdateto();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=7");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string Id = lblId.Text;
        if (Id == "" || Id == null)
        {
            InsertKeyword();
        }
        else
        {
            UpdateKeyword(Id);
        }

        
   }
    private void InsertKeyword()
    {
        try
        {
            string userid = Session["MarketingUser"].ToString();
            string sql = "select IMEINO,Sim_no from LongCodeRegistration where UsrUserid='" + userid + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            keywordBLLObj.IMEINO = Convert.ToString(ds.Tables[0].Rows[0]["IMEINO"]);
            keywordBLLObj.Simno = Convert.ToString(ds.Tables[0].Rows[0]["Sim_no"]);
            string date = DateTime.Today.ToShortDateString();
            date = cc.DTInsert_Local(date);
            keywordBLLObj.keywordCreationDate = date;
            keywordBLLObj.keywordName = Convert.ToString(txtKeywordName.Text.ToUpperInvariant());
            keywordBLLObj.keywordDescription = Convert.ToString(txtKeywordDescription.Text);
            keywordBLLObj.responseMsg = Convert.ToString(txtResponseMessage.Text);
            keywordBLLObj.Email = Convert.ToString(txtEmail.Text);
            keywordBLLObj.keyEmailSub = Convert.ToString(txtEmailSub.Text.Trim());
            keywordBLLObj.Fwdmobileno = Convert.ToString(txtFwdMobileno.Text);
            keywordBLLObj.Keywordfor = Convert.ToString(ddlkeyword.SelectedItem.Value);
            string keywordstatus = "Active";
            keywordBLLObj.Keywordstatus = keywordstatus;
            status = keywordBLLObj.BLLMiscalKeywordIsExist(keywordBLLObj);
            if (status > 0)
            {
                status = keywordBLLObj.BLLMiscalKeywordInsert(keywordBLLObj);
                if (status > 0)
                {
                    ////////Comment for sumtime becz it is in progress
                    if (ddlkeyword.SelectedItem.Value == "2")
                    {
                        listitem();
                        sql = "select Id from PersonalLongCodekeywords where keywordName='" + keywordBLLObj.keywordName + "' and IMEINO='" + keywordBLLObj.IMEINO + "' and simno='" + keywordBLLObj.Simno + "'";
                        string id = cc.ExecuteScalar(sql);
                        sql = "insert into RegistrationKeyword(Pid,RegNo)values('" + id + "','" + choice + "')";
                        int a = cc.ExecuteNonQuery(sql);
                    }
                    ////////////////////////////////////////
                    LoadKeyword();
                    clearItems();
                    Response.Write("<script>alert('Keyword Added successfully')</script>");
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Added successfully')", true);
                    
                }
            }
            else
            {
                Response.Write("<script>alert('Keyword Added successfully')</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Name Already Exist ')", true);
                clearItems();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }

    private void UpdateKeyword(string Id)
    {
        try
        {
            keywordBLLObj.responseMsg = Convert.ToString(txtResponseMessage.Text);
            keywordBLLObj.Id = Convert.ToInt32(Id);
            status = keywordBLLObj.BLLMiscalKeywordUpdate(keywordBLLObj);
            if (status > 0)
            {
                Response.Write("<script>(alert)('Keyword Update successfully')</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Update successfully ')", true);
                LoadKeyword();
                clearItems();
            }
        }
        catch (Exception ex)
        {
        }
    }
    private void listitem()
    {
        string Newspapername = "";
        for (int i = 0; i < chkRegSelection.Items.Count; i++)
        {
            if (chkRegSelection.Items[i].Selected == true)
            {
                Newspapername = Newspapername + "," + chkRegSelection.Items[i].Text;

            }
        }
        if (Newspapername.Length > 1)
        {
            Newspapername = Newspapername.Substring(1);
        }
         choice = Newspapername;
       
    }
    public void clearItems()
    {
        try
        {
            txtKeywordName.Text = "";
            txtKeywordDescription.Text = "";
            txtEmail.Text = "";
            txtResponseMessage.Text = "";
            txtEmailSub.Text = "";
            txtKeywordName.Enabled = true;
            txtEmail.Enabled = true;
            btnSubmit.Visible = true;
            txtFwdMobileno.Text = "";
            ddlkeyword.ClearSelection();
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LoadKeyword()
    {
        try
        {
            string userid = Session["MarketingUser"].ToString();
            string sql = "select IMEINO,Sim_no from LongCodeRegistration where UsrUserid='" + userid + "'";
            DataSet ds = cc.ExecuteDataset(sql);
            keywordBLLObj.IMEINO = Convert.ToString(ds.Tables[0].Rows[0]["IMEINO"]);
            keywordBLLObj.Simno = Convert.ToString(ds.Tables[0].Rows[0]["Sim_no"]);
            dtkeywordList = keywordBLLObj.BLLMiscalKeywordSelectAll(keywordBLLObj);
            gvKeywordDefinition.DataSource = dtkeywordList;
            gvKeywordDefinition.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvKeywordDefinition_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int id = gvKeywordDefinition.SelectedIndex;
            txtKeywordName.Text = gvKeywordDefinition.Rows[id].Cells[0].Text;
            txtKeywordDescription.Text = gvKeywordDefinition.Rows[id].Cells[1].Text;
            txtResponseMessage.Text = gvKeywordDefinition.Rows[id].Cells[2].Text;
            txtEmail.Text = gvKeywordDefinition.Rows[id].Cells[7].Text;
            txtEmailSub.Text = gvKeywordDefinition.Rows[id].Cells[8].Text;
           
            string a = gvKeywordDefinition.Rows[id].Cells[7].Text;
           
            txtKeywordName.Enabled = false;
            
            btnSubmit.Visible = false;
          //  btnModify.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  
    protected void gvKeywordDefinition_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gvKeywordDefinition.PageIndex = e.NewPageIndex;
            dtkeywordList = keywordBLLObj.BLLKeywordSelectAll();
            gvKeywordDefinition.DataSource = dtkeywordList;
            gvKeywordDefinition.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    

   
   
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=7");
    }
    protected void gvInbox_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlkeyword.SelectedValue == "2")
        {
            chkregistration.Visible = true;
        }
    }


    protected void gvKeywordDefinition_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            if (Convert.ToString(e.CommandName) == "Modify")
            {

                string sql = "select * from PersonalLongCodekeywords where Id='"+Id+"'";
                DataSet ds = cc.ExecuteDataset(sql);
                txtKeywordName.Text = Convert.ToString(ds.Tables[0].Rows[0]["KeywordName"]);
                txtKeywordDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["KeywordDescription"]);
                txtEmail.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailAddress"]);
                txtEmailSub.Text = Convert.ToString(ds.Tables[0].Rows[0]["EmailSubject"]);
                txtFwdMobileno.Text = Convert.ToString(ds.Tables[0].Rows[0]["Fwdmobileno"]);
                txtResponseMessage.Text = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMessage"]);
                //ddlkeyword.SelectedItem.Text = Convert.ToString(ds.Tables[0].Rows[0][""]);
                btnSubmit.Text = "Edit";
                txtKeywordName.Enabled = false;
                txtKeywordDescription.Enabled = false;
                txtEmail.Enabled = false;
                txtEmailSub.Enabled = false;
                txtFwdMobileno.Enabled = false;

            }
            else if (Convert.ToString(e.CommandName) == "Delete")
            {
                keywordBLLObj.Id = Convert.ToInt32(Id);
                status = keywordBLLObj.BLLKeywordUpdateDeactive(keywordBLLObj);
                if (status > 0)
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Deleted successfully')", true);
                    Response.Write("<script>(alert)('Record Deleted successfully')</script>");
                    LoadKeyword();
                    clearItems();
                }

            }
        }
        catch (Exception ex)
        {
            string m = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtKeywordName.Text = "";
        txtKeywordDescription.Text = "";
        txtEmail.Text = "";
        txtEmailSub.Text = "";
        txtFwdMobileno.Text = "";
        txtResponseMessage.Text = "";
        ddlkeyword.ClearSelection();
        chkRegSelection.Visible = false;
    }
    protected void gvKeywordDefinition_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

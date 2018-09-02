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

public partial class MarketingAdmin_MiscalLongCodeKeyword : System.Web.UI.Page
{
    int status;
    KeywordBLL keywordBLLObj = new KeywordBLL();
    DataTable dtkeywordList = new DataTable();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void rdbButton_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbButton.SelectedValue == "1")
        {
            lblDataMobile.Visible = true;
            txtDataMobile.Visible = true;
            btnSearch.Visible = true;
            btnSubmit.Enabled = false;
        }
        else
        {
            lblDataMobile.Visible = false;
            txtDataMobile.Visible = false;
            btnSearch.Visible = false;
            btnSubmit.Enabled = true;

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //string Id = lblId.Text;
        //if (Id == "" || Id == null)
        //{
        InsertKeyword();
        //}
        //else
        //{
        //    UpdateKeyword(Id);
        //}
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
            txtDataMobile.Text = "";
            txtDataMobile.Visible = false;
            lblDataMobile.Visible = false;
            rdbButton.ClearSelection();
            btnSearch.Visible = false;

            //ddlkeyword.ClearSelection();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void InsertKeyword()
    {
        try
        {
            string mobileno = txtDataMobile.Text;
            if (mobileno == "" || mobileno == null)
            {
                string userid = Session["MarketingUser"].ToString();
                
                string date = DateTime.Today.ToShortDateString();
                date = cc.DTInsert_Local(date);
                keywordBLLObj.keywordCreationDate = date;
                keywordBLLObj.keywordName = Convert.ToString(txtKeywordName.Text.ToUpperInvariant());
                keywordBLLObj.keywordDescription = Convert.ToString(txtKeywordDescription.Text);
                keywordBLLObj.responseMsg = Convert.ToString(txtResponseMessage.Text);
                keywordBLLObj.Email = Convert.ToString(txtEmail.Text);
                keywordBLLObj.keyEmailSub = Convert.ToString(txtEmailSub.Text.Trim());
                keywordBLLObj.Fwdmobileno = Convert.ToString(txtFwdMobileno.Text);
                //keywordBLLObj.Keywordfor = Convert.ToString(ddlkeyword.SelectedItem.Value);
                string keywordstatus = "Active";
                keywordBLLObj.Keywordstatus = keywordstatus;
                status = keywordBLLObj.BLLMiscalKeywordIsExist(keywordBLLObj);
                if (status > 0)
                {
                    status = keywordBLLObj.BLLMiscalKeywordinLongcodeInsert(keywordBLLObj);
                    if (status > 0)
                    {
                        //LoadKeyword();
                        clearItems();
                        Response.Write("<script>alert('Keyword Added successfully')</script>");
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Added successfully')", true);

                    }
                }
                else
                {
                    Response.Write("<script>alert('Keyword Name Already Exist')</script>");
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Name Already Exist ')", true);
                    clearItems();
                }
            }
            else
            {
                 string userid = Session["MarketingUser"].ToString();
                 mobileno = txtDataMobile.Text; 
                string sql = "select IMEINO,Sim_no from LongCodeRegistration where customer_contact='" + mobileno + "'";
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
                //keywordBLLObj.Keywordfor = Convert.ToString(ddlkeyword.SelectedItem.Value);
                string keywordstatus = "Active";
                keywordBLLObj.Keywordstatus = keywordstatus;
                status = keywordBLLObj.BLLMiscalKeywordIsExist(keywordBLLObj);
                if (status > 0)
                {
                    status = keywordBLLObj.BLLMiscalKeywordInsert(keywordBLLObj);
                    if (status > 0)
                    {
                        ////////Comment for sumtime becz it is in progress
                        //if (ddlkeyword.SelectedItem.Value == "2")
                        //{
                        //    listitem();
                        //    sql = "select Id from PersonalLongCodekeywords where keywordName='" + keywordBLLObj.keywordName + "' and IMEINO='" + keywordBLLObj.IMEINO + "' and simno='" + keywordBLLObj.Simno + "'";
                        //    string id = cc.ExecuteScalar(sql);
                        //    sql = "insert into RegistrationKeyword(Pid,RegNo)values('" + id + "','" + choice + "')";
                        //    int a = cc.ExecuteNonQuery(sql);
                        //}
                        ////////////////////////////////////////
                        //LoadKeyword();
                        clearItems();
                        Response.Write("<script>alert('Keyword Added successfully')</script>");
                        //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Added successfully')", true);

                    }
                }
                else
                {
                    Response.Write("<script>alert('Keyword Name Already Exist')</script>");
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Name Already Exist ')", true);
                    clearItems();
                }
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
                //LoadKeyword();
                clearItems();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string sql = "select reg_id from LongCodeRegistration where customer_contact='" + txtDataMobile.Text + "'";
        string id = cc.ExecuteScalar(sql);
        if (id == "" || id == null)
        {
            Response.Write("<script>(alert)('This number is not valid')</script>");
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This number is not valid number')", true);
        }
        else
        {
            Response.Write("<script>(alert)('This number is  valid number')</script>");
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This number is valid number')", true);
        }
        btnSubmit.Enabled = true;

    }
}

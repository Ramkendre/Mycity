using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class MarketingAdmin_KeywordDefinition : System.Web.UI.Page
{
    int status;
    KeywordBLL keywordBLLObj = new KeywordBLL();
    DataTable dtkeywordList = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDDLGroup();
            LoadKeyword();
            clearItems();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            keywordBLLObj.keywordName = Convert.ToString(txtKeywordName.Text.ToUpperInvariant());
            keywordBLLObj.keywordDescription = Convert.ToString(txtKeywordDescription.Text);
            keywordBLLObj.responseMsg = Convert.ToString(txtResponseMessage.Text);
            keywordBLLObj.validUpto = Convert.ToDateTime(txtValidUpto.Text).ToShortDateString();
            keywordBLLObj.keywordCreationDate = Convert.ToDateTime(txtKeywordCreationDate.Text).ToShortDateString();
            keywordBLLObj.Active = Convert.ToInt32(RadioButtonList1.SelectedValue);
            keywordBLLObj.groupid = Convert.ToInt32(ddlGroupName.SelectedItem.Value);
            keywordBLLObj.SubGroupid = Convert.ToInt32(ddlSubGroupName.SelectedItem.Value);
            keywordBLLObj.Email = Convert.ToString(txtEmail .Text );
            keywordBLLObj.keyEmailSub = Convert.ToString(txtEmailSub.Text.Trim());
            keywordBLLObj.keyEmailBody = Server.HtmlEncode(FCKeditor1.Content.ToString());
            
            status = keywordBLLObj.BLLKeywordIsExist(keywordBLLObj);
            if (status > 0)
            {
                status = keywordBLLObj.BLLKeywordInsert(keywordBLLObj);
                if (status > 0)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Added successfully ')", true);
                    LoadKeyword();
                    clearItems();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Name Already Exist ')", true);
                clearItems();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        
    }
    public void clearItems()
    {
        try
        {
            txtKeywordName.Text = "";
            txtKeywordDescription.Text = "";
            txtEmail.Text = "";
            txtValidUpto.Text = "";
            txtResponseMessage.Text = "";
            txtKeywordCreationDate.Text = "";
            ddlGroupName.SelectedIndex = ddlGroupName.Items.Count - 1;
            ddlSubGroupName.SelectedIndex = ddlSubGroupName.Items.Count - 1;
            txtKeywordName.Enabled = true;
            txtEmail.Enabled = true;
            txtValidUpto.Enabled = true;
            txtKeywordCreationDate.Enabled = true;
            btnSubmit.Visible = true;
            btnModify.Visible = false;
            FCKeditor1.Content = "";
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
            dtkeywordList = keywordBLLObj.BLLKeywordSelectAll();
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
            txtKeywordCreationDate.Text = gvKeywordDefinition.Rows[id].Cells[3].Text;
            txtValidUpto.Text = gvKeywordDefinition.Rows[id].Cells[4].Text;
            txtEmail.Text = gvKeywordDefinition.Rows[id].Cells[7].Text;
            txtEmailSub.Text = gvKeywordDefinition.Rows[id].Cells[8].Text;
            FCKeditor1.Content = Server.HtmlDecode(gvKeywordDefinition.Rows[id].Cells[9].Text);
            //string ab = Convert.ToString(gvKeywordDefinition.Rows[id].Cells[5].Text);
            //if (ab != "&nbsp;")
            //{
            //    ddlGroupName.Text = gvKeywordDefinition.Rows[id].Cells[5].Text;
            //}
            //string abc = Convert.ToString(gvKeywordDefinition.Rows[id].Cells[6].Text);
            //if (abc != "&nbsp;")
            //{
            //    ddlSubGroupName.Text = gvKeywordDefinition.Rows[id].Cells[6].Text;
            //}
            string a = gvKeywordDefinition.Rows[id].Cells[7].Text;
            if (a == "1")
            {
                RadioButtonList1.SelectedIndex = 0;
            }
            else
            {
                RadioButtonList1.SelectedIndex = 1;
            }
            txtKeywordName.Enabled = false;
            //txtEmail.Enabled = false;
            txtValidUpto.Enabled = false;
            txtKeywordCreationDate.Enabled = false;
            btnSubmit.Visible = false;
            btnModify.Visible = true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        keywordBLLObj.keywordName = Convert.ToString(txtKeywordName.Text.ToUpperInvariant());
        keywordBLLObj.Email = Convert.ToString(txtEmail .Text );
        keywordBLLObj.keywordDescription = Convert.ToString(txtKeywordDescription.Text);
        keywordBLLObj.responseMsg = Convert.ToString(txtResponseMessage.Text);
        keywordBLLObj.Active = Convert.ToInt32(RadioButtonList1.SelectedValue);
        keywordBLLObj.groupid = Convert.ToInt32(ddlGroupName.SelectedItem.Value);
        keywordBLLObj.SubGroupid = Convert.ToInt32(ddlSubGroupName.SelectedItem.Value);
        keywordBLLObj.keyEmailSub = txtEmailSub.Text.ToString().Trim();
        keywordBLLObj.keyEmailBody = Server.HtmlEncode(FCKeditor1.Content).ToString();
        status = keywordBLLObj.BLLKeywordUpdate(keywordBLLObj);
        if (status > 0)
        {
          ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Keyword Updated Successfully ')", true);
          LoadKeyword();
          clearItems();
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
    public void FillDDLGroup()
    {
        try
        {
            dtkeywordList = keywordBLLObj.BLLSelectAllGroup();
            
            ddlGroupName.DataSource = dtkeywordList;
            ddlGroupName.DataTextField = "GroupName";
            ddlGroupName.DataValueField = "GroupId";
            ddlGroupName.DataBind();
            ddlGroupName.Items.Add("---Select---");
            ddlSubGroupName.Items.Add("---Select---");
            ddlSubGroupName.Items[ddlSubGroupName.Items.Count - 1].Value = "";
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int groupId = Convert.ToInt32(ddlGroupName.SelectedValue);
            fillDDLSubGroup(groupId);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void fillDDLSubGroup(int GroupId)
    {
        try
        {
            dtkeywordList = keywordBLLObj.BLLSelectSubGroupById(GroupId);
            ddlSubGroupName.DataSource = dtkeywordList;
            ddlSubGroupName.DataTextField = "GroupValueName";
            ddlSubGroupName.DataValueField = "GroupValueId";
            ddlSubGroupName.DataBind();
            ddlSubGroupName.Items.Add("---Select---");
            ddlSubGroupName.SelectedIndex = ddlSubGroupName.Items.Count - 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

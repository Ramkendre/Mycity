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

public partial class MarketingAdmin_KeywordDataReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    KeywordInfoBLL KBLL = new KeywordInfoBLL();
    string DateFormat = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
        DateFormatStatus();
    }
    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 12; //add hours in time
        double m = 30; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd HH':'mm':'ss''");
    }
    //------------------Panel1-------------------------------------

    #region EntryKeyword

    public void LoadData()
    {
        try
        {
            DataSet ds = KBLL.LoadInfo(KBLL);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();

            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[7].Text.ToString();
                Data = cc.DTGet_Local(Data);
                row.Cells[7].Text = Data;
            }

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                string Data = row.Cells[5].Text.ToString();
                if (Data == "1")
                {
                    Data = "Myct";
                }
                else if (Data == "2")
                {
                    Data = "Udisecce";
                }
                else if (Data == "3")
                {
                    Data = "School";
                }
                else if (Data == "4")
                {
                    Data = "Android Mobile Apps";
                }

                row.Cells[5].Text = Data;
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void Clear()
    {
        txtKeyword.Text = "";
        txtSyntax.Text = "";
        txtPurpose.Text = "";
        txtDiscrip.Text = "";
        ddlWebSite.SelectedIndex = 0;
        btnSubmit.Text = "Submit";
        lblId.Text = "";
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string Id = Convert.ToString(lblId.Text);
            if (Id == "" || Id == null)
            {
                AddRecord();
            }
            else
            {
                Update(Id);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void AddRecord()
    {
        try
        {
            string Sql = "Select KeyId from KeywordInformation where KeywordName='" + txtKeyword.Text + "' ";
            string KeyId = Convert.ToString(cc.ExecuteScalar(Sql));
            if (KeyId == "" || KeyId == null)
            {
                KBLL.KeywordName1 = Convert.ToString(txtKeyword.Text);
                KBLL.KeywordSyntax1 = Convert.ToString(txtSyntax.Text);
                KBLL.KeywordPurpose1 = Convert.ToString(txtPurpose.Text);
                KBLL.KeyDiscip1 = Convert.ToString(txtDiscrip.Text);
                KBLL.WebsiteGroup1 = Convert.ToString(ddlWebSite.SelectedValue);
                KBLL.EntryDate1 = Convert.ToString(DateFormat);
                int status = KBLL.AddInfo(KBLL);
                if (status == 1)
                {
                    LoadData();
                    Clear();
                    Response.Write("<script>alert('Record Inserted.............!')</script>");
                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        { }
    }
    public void Update(string Id)
    {
        try
        {
            string Sql = "Select KeyId from KeywordInformation where KeywordName='" + txtKeyword.Text + "' and  keyId<>" + Id + "";
            string KeyId = Convert.ToString(cc.ExecuteScalar(Sql));
            if (KeyId == "" || KeyId == null)
            {
                KBLL.KeyId1 = Convert.ToInt64(Id);
                KBLL.KeywordName1 = Convert.ToString(txtKeyword.Text);
                KBLL.KeywordSyntax1 = Convert.ToString(txtSyntax.Text);
                KBLL.KeywordPurpose1 = Convert.ToString(txtPurpose.Text);
                KBLL.KeyDiscip1 = Convert.ToString(txtDiscrip.Text);
                KBLL.WebsiteGroup1 = Convert.ToString(ddlWebSite.SelectedValue);
                KBLL.EntryDate1 = Convert.ToString(DateFormat);
                int status = KBLL.UpdateInfo(KBLL);
                if (status == 1)
                {
                    LoadData();
                    Clear();
                    Response.Write("<script>alert('Record Updated.............!')</script>");
                }
                else
                {

                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            //btnSubmit.Text = "Update";
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            KBLL.KeyId1 = Convert.ToInt64(Id);
            KBLL.SelectInfo(KBLL);
            try
            {

                txtKeyword.Text = Convert.ToString(KBLL.KeywordName1);
                txtSyntax.Text = Convert.ToString(KBLL.KeywordSyntax1);
                txtDiscrip.Text = Convert.ToString(KBLL.KeyDiscip1);
                ddlWebSite.SelectedValue = Convert.ToString(KBLL.WebsiteGroup1);
                txtPurpose.Text = Convert.ToString(KBLL.KeywordPurpose1);
                btnSubmit.Text = "Update";
            }
            catch (Exception ex)
            { }
        }
    }

    //----------------------------DownLoad Gridview----------------------------------------------------------------------------------------------------
    //-----------------------------------Don't Delete This Function. It Is used to Excel Download File-----------------------------------------------

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=KeywordReport.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GridView1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadData();
    }

    #endregion EntryKeyword

    //------------------Panel2-------------------------------------



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string Keyid = ddlWebsiteSearch.SelectedValue;

            string Sql = "Select KeyId, KeywordName, KeywordSyntax,KeywordPurpose,KeyDiscip,WebsiteGroup, EntryDate from " +
            "KeywordInformation where WebsiteGroup=" + ddlWebsiteSearch.SelectedValue + " order by keyId Asc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvSearch.DataSource = ds.Tables[0];
            gvSearch.DataBind();
            foreach (GridViewRow row in gvSearch.Rows)
            {
                string Data = row.Cells[7].Text.ToString();
                Data = cc.DTGet_Local(Data);
                row.Cells[7].Text = Data;
            }
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            foreach (GridViewRow row in GridView2.Rows)
            {
                string Data = row.Cells[5].Text.ToString();
                if (Data == "1")
                {
                    Data = "Myct";
                }
                else if (Data == "2")
                {
                    Data = "Udisecce";
                }
                else if (Data == "3")
                {
                    Data = "School";
                }
                else if (Data == "4")
                {
                    Data = "Android Mobile Apps";
                }

                row.Cells[5].Text = Data;
            }


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btnDwn_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=KeywordReport.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GridView2.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

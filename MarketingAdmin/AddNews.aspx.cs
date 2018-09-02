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
using System.IO;
using System.Data.SqlClient;

public partial class MarketingAdmin_AddNews : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        //showId();
        if (!IsPostBack)
        {
            bindstate();
            bindgvNews();
            showId();
            ddlbindPrjlist();
            ddlbindNewPaper();

        }
    }
    public void bindstate()
    {
        string sql;
        sql = "select stateId, stateName from [Come2myCityDB].[dbo].[StateMaster]";
        ds = cc.ExecuteDataset(sql);
        ddlstate.DataSource = ds;
        ddlstate.DataTextField = "stateName";
        ddlstate.DataValueField = "stateId";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    public void binddistrict()
    {
        string sql;
        sql = "select distId, distName from [Come2myCityDB].[dbo].[DistrictMaster] where stateId='" + ddlstate.SelectedValue + "'";
        ds = cc.ExecuteDataset(sql);
        ddlDistrict.DataSource = ds;
        ddlDistrict.DataTextField = "distName";
        ddlDistrict.DataValueField = "distId";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    public void bindcity()
    {
        string sql;
        sql = "select cityId, cityName from [Come2myCityDB].[dbo].[CityMaster] where distId='" + ddlDistrict.SelectedValue + "'";
        ds = cc.ExecuteDataset(sql);
        ddlcity.DataSource = ds;
        ddlcity.DataTextField = "cityName";
        ddlcity.DataValueField = "cityId";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("--Select--", "0"));


    }
    public void showId()
    {
        string sqlId;
        sqlId = "select max(NID)+1 as NID from [Come2myCityDB].[come2mycity].[tblShowNews]";
        ds = cc.ExecuteDataset(sqlId);
        //int m=Convert.ToInt32(ds.Tables[0].Rows[0]["NID"]);
        lblId.Text = Convert.ToString(ds.Tables[0].Rows[0]["NID"]);
    }
    public void ddlbindPrjlist()
    {
        string str = "select * from [Come2myCityDB].[come2mycity].[tblProjectList]";
        ds = cc.ExecuteDataset(str);

        ddlprject.DataSource = ds;
        ddlprject.DataValueField = "prj_Id";
        ddlprject.DataTextField = "prj_Name";
        ddlprject.DataBind();
        ddlprject.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlprject.SelectedIndex = 0;
    }
    public void ddlbindNewPaper()
    {
        string str = "select * from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='1'";
        ds = cc.ExecuteDataset(str);

        ddlNewsPaper.DataSource = ds;
        ddlNewsPaper.DataValueField = "ID";
        ddlNewsPaper.DataTextField = "Name";
        ddlNewsPaper.DataBind();
        ddlNewsPaper.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlNewsPaper.SelectedIndex = 0;

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string dt = cc.DateFormatStatus();
        if (btnSubmit.Text == "Submit")
        {
            string sql; string imgstring = "0";
            string folderPath;
            string ab = FileUpload1.FileName;
            folderPath = Server.MapPath("NewsFiles\\" + FileUpload1.FileName);
            if (FileUpload1.HasFile == true)
            {
                string path = "";
                path = Server.MapPath("NewsFiles");
                path = path + "\\" + FileUpload1.FileName;
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower().Substring(1, 3);
                if (fileExtension == "jpeg" || fileExtension == "jpg" || fileExtension == "png" || fileExtension == "gif")
                {
                    int imgLength = FileUpload1.PostedFile.ContentLength;
                    byte[] imgcontent = new byte[imgLength];
                    HttpPostedFile file = FileUpload1.PostedFile;
                    file.InputStream.Read(imgcontent, 0, imgLength);
                    imgstring = Convert.ToBase64String(imgcontent, 0, imgLength);
                }
                if (File.Exists(path))
                {
                    File.Delete(path);
                    FileUpload1.SaveAs(path);
                }
                else
                {
                    FileUpload1.SaveAs(path);
                }
                //Response.Write("<script>alert('File Uploaded successfully')</script>");
            }
            //else
            //{
            //    Response.Write("<script>alert('File format not recognised')</script>");
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File format not recognised')", true);
            //}

            sql = "insert into [Come2myCityDB].[come2mycity].[tblShowNews] ([NHeading],[NTopic],[NPaper],[DONR],[LDOA],[NFeesApp],[NInDetail],[NAttachment],[NApplicablefor],[NState],[NDistrict],[NCity],[NFileName],[NCurrentDate],[NPrjname],[NImg],[status],[examid]) values" +
                 "(N'" + txtNewsHeading.Text + "',N'" + ddlTopic.SelectedItem.Text + "',N'" + ddlNewsPaper.SelectedItem.Text + "',N'" + txtdtnewsRece.Text + "',N'" + txtDtApplication.Text + "',N'" + txtfees.Text + "',N'" + txtNewsDetail.Text + "',N'" + folderPath + "',N'" + rdoApplicablefor.SelectedItem.Text + "',N'" + ddlstate.SelectedValue + "',N'" + ddlDistrict.SelectedValue + "',N'" + ddlcity.SelectedValue + "',N'" + ab + "',N'" + dt + "',N'" + ddlprject.SelectedValue + "',N'" + imgstring + "','1',N'" + ddlexamIdName.SelectedValue + "')";
            int status = cc.ExecuteNonQuery(sql);
            if (status == 1)
            {
                Response.Write("<script>alert('Record Inserted Successfully...!!!')</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Inserted Successfully...!!!')", true);
            }
        }
        else if (btnSubmit.Text == "Modify")
        {
            string sql;
            sql = "update [Come2myCityDB].[come2mycity].[tblShowNews] set [NHeading]=N'" + txtNewsHeading.Text + "',[NTopic]=N'" + ddlTopic.SelectedItem.Text + "',[NPaper]=N'" + ddlNewsPaper.SelectedItem.Text + "',[LDOA]=N'" + txtDtApplication.Text + "',[NFeesApp]=N'" + txtfees.Text + "',[NInDetail]=N'" + txtNewsDetail.Text + "',[NApplicablefor]=N'" + rdoApplicablefor.SelectedItem.Text + "',[NPrjname]=N'" + ddlprject.SelectedValue + "',[NCurrentDate]=N'" + dt + "',[examid]=N'" + ddlexamIdName.SelectedValue + "' where NID=N'" + lblId.Text + "'";
            int status = cc.ExecuteNonQuery(sql);
            if (status == 1)
            {
                Response.Write("<script>alert('Record Updated Successfully...!!!')</script>");
            }
            btnSubmit.Text = "Submit";
            lblId.Text = "";
            ddlexamIdName.Visible = false;
            txtdtnewsRece.Enabled = true;
        }
        clear();
        bindgvNews();
        showId();
    }


    public void clear()
    {
        txtNewsHeading.Text = "";
        ddlTopic.SelectedIndex = 0;
        ddlNewsPaper.SelectedIndex = 0;
        txtdtnewsRece.Text = "";
        txtDtApplication.Text = "";
        txtfees.Text = "";
        txtNewsDetail.Text = "";
        ddlstate.SelectedIndex = 0;
        ddlDistrict.ClearSelection();
        ddlcity.ClearSelection();
        rdoApplicablefor.ClearSelection();
        ddlprject.SelectedIndex = 0;
        if (ddlTopic.SelectedValue == "3")
            ddlexamIdName.SelectedIndex = 0;
    }
    protected void rdoApplicablefor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoApplicablefor.SelectedValue == "1")
        {
            statepnl.Visible = true;
            districtpnl.Visible = false;
            citypnl.Visible = false;
        }
        else if (rdoApplicablefor.SelectedValue == "2")
        {
            statepnl.Visible = true;
            districtpnl.Visible = true;
            citypnl.Visible = false;
        }
        else if (rdoApplicablefor.SelectedValue == "3")
        {
            statepnl.Visible = true;
            districtpnl.Visible = true;
            citypnl.Visible = true;
        }
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddistrict();
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity();
    }
    protected void gvDispNews_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvDispNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDispNews.PageIndex = e.NewPageIndex;
        bindgvNews();
    }
    public void bindgvNews()
    {
        string sql;
        sql = "SELECT TOP 50 [NID],[NHeading],[NTopic],[NPaper],[DONR],[LDOA],[NFeesApp],[NInDetail],[NApplicablefor] FROM [Come2myCityDB].[come2mycity].[tblShowNews] order by NID desc";
        DataSet ds = cc.ExecuteDataset(sql);

        gvDispNews.DataSource = ds;
        gvDispNews.DataBind();

    }
    protected void gvDispNews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string id = Convert.ToString(e.CommandArgument);
        if (e.CommandName == "Modify")
        {
            string sql;
            sql = "select [NID],[NHeading],[NTopic],[NPaper],[NPrjname],[DONR],[LDOA],[NFeesApp],[NInDetail],[NApplicablefor],[NPrjname],[examid] FROM [Come2myCityDB].[come2mycity].[tblShowNews] where NID='" + id + "'";
            DataSet ds = cc.ExecuteDataset(sql);

            lblId.Text = Convert.ToString(ds.Tables[0].Rows[0]["NID"]);
            txtNewsHeading.Text = Convert.ToString(ds.Tables[0].Rows[0]["NHeading"]);
            txtdtnewsRece.Text = Convert.ToString(ds.Tables[0].Rows[0]["DONR"]);
            txtdtnewsRece.Enabled = false;
            txtDtApplication.Text = Convert.ToString(ds.Tables[0].Rows[0]["LDOA"]);
            txtfees.Text = Convert.ToString(ds.Tables[0].Rows[0]["NFeesApp"]);
            txtNewsDetail.Text = Convert.ToString(ds.Tables[0].Rows[0]["NInDetail"]);
            ddlTopic.ClearSelection();
            string a = ds.Tables[0].Rows[0]["NPaper"].ToString();
            ddlTopic.Items.FindByText(Convert.ToString(ds.Tables[0].Rows[0]["NTopic"])).Selected = true;
            if (ddlTopic.SelectedItem.Text == "Syllabus")
            {
                ddlexamIdName.Visible = true;
                bindexamIdName();
                ddlexamIdName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["examid"]);
            }
            ddlNewsPaper.ClearSelection();
            ddlNewsPaper.Items.FindByText(a).Selected = true;
            ddlprject.ClearSelection();
            ddlprject.Items.FindByValue(Convert.ToString(ds.Tables[0].Rows[0]["NPrjname"])).Selected = true;
            rdoApplicablefor.ClearSelection();
            rdoApplicablefor.Items.FindByText(Convert.ToString(ds.Tables[0].Rows[0]["NApplicablefor"])).Selected = true;
            btnSubmit.Text = "Modify";
        }

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "0")
        {
            string sql;
            sql = "select [NID],[NHeading],[NTopic],[NPaper],[DONR],[LDOA],[NFeesApp],[NInDetail],[NApplicablefor] FROM [Come2myCityDB].[come2mycity].[tblShowNews] where NTopic='" + ddlCategory.SelectedItem.Text + "' order by NID desc";
            DataSet ds = cc.ExecuteDataset(sql);

            gvDispNews.DataSource = ds;
            gvDispNews.DataBind();
        }
        else
        {
            bindgvNews();
        }
    }
    protected void ddlTopic_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTopic.SelectedValue == "3")
        {
            bindexamIdName();
            ddlexamIdName.Visible = true;
        }
        else
        {
            ddlexamIdName.Visible = false;
        }
    }
    public void bindexamIdName()
    {
        try
        {
            string sql;
            sql = "select examId, examName from [Come2myCityDB].[come2mycity].[tblexam_Id_Name]";
            ds = cc.ExecuteDataset(sql);

            ddlexamIdName.DataSource = ds;
            ddlexamIdName.DataTextField = "examName";
            ddlexamIdName.DataValueField = "examId";
            ddlexamIdName.DataBind();
            ddlexamIdName.Items.Insert(0, new ListItem("--Select Exam--", "0"));
            ddlexamIdName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
        }
    }
}

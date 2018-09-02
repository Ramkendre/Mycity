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

public partial class MarketingAdmin_UploadMLAFile : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    string dt = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();

        }
        DateFormatStatus();
    }
    public void LoadGrid()
    {
        try
        {
            string Sql = "Select Id , Committee_name,Committee_url, FileName from committeedetail where RoleId=29";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvToday.DataSource = ds.Tables[0];
            gvToday.DataBind();

            string Sql1 = "Select Id , Committee_name as Name from committeedetail where RoleId=29";
            DataSet ds1 = cc.ExecuteDataset(Sql1);
            ddlUploadCenter.DataSource = ds1.Tables[0];
            ddlUploadCenter.DataTextField = "Name";
            ddlUploadCenter.DataValueField = "Id";
            ddlUploadCenter.DataBind();
            ddlUploadCenter.Items.Add("--Select--");
            ddlUploadCenter.SelectedIndex = ddlUploadCenter.Items.Count - 1;
        }
        catch (Exception ex)
        { }


    }
    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 12; //add hours in time
        double m = 30; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
        string ds1 = Convert.ToString(DateFormat);
        return ds1;
    }
    protected void ddlUploadCenter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        HttpFileCollection uploadFilCol = Request.Files;
        for (int i = 0; i < uploadFilCol.Count; i++)
        {
            HttpPostedFile file = uploadFilCol[i];
            string fileExt = Path.GetExtension(file.FileName).ToLower();
            string fileName = Path.GetFileName(file.FileName);
            if (fileName != string.Empty)
            {
                try
                {
                    if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".jpeg" || fileExt == ".png" || fileExt == ".pdf" || fileExt == ".docx" || fileExt == ".mp3" || fileExt == ".mp4" || fileExt == ".3gp")
                    {
                        if (ddlUploadCenter.SelectedValue != "" || ddlUploadCenter.SelectedValue != null)
                        {
                            if (txtSubject.Text == "" || txtSubject.Text == null)
                            {
                                Response.Write("<script>alert('Please Enter The File....!')</script>");
                            }
                            else
                            {
                                fileName = Convert.ToString(txtSubject.Text) + DateFormat.Replace('-', ' ') + fileExt;

                                string Sql = "Select FileName from committeedetail where Id=" + ddlUploadCenter.SelectedValue + " and FileName='" + fileName + "'";
                                string FindFileName = Convert.ToString(cc.ExecuteScalar(Sql));

                                if (FindFileName != "")
                                {
                                    FileInfo TheFile = new FileInfo(Server.MapPath("~/downloadfilesMLA/") + fileName);
                                    if (TheFile.Exists)
                                    {
                                        File.Delete(Server.MapPath("~/downloadfilesMLA/") + fileName);
                                    }
                                }

                                file.SaveAs(Server.MapPath("~/downloadfilesMLA/") + fileName);
                                Sql = "Update committeedetail set FileName='" + fileName + "' where Id=" + ddlUploadCenter.SelectedValue + "";
                                int k = cc.ExecuteNonQuery(Sql);
                                if (k == 1)
                                {
                                    Response.Write("<script>alert('File Uploaded successfully')</script>");
                                    LoadGrid();
                                    Clear();

                                }
                                else
                                {
                                    Response.Write("<script>alert('File not Uploaded successfully')</script>");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    public void Clear()
    {
        ddlUploadCenter.SelectedIndex = ddlUploadCenter.Items.Count - 1;
        txtSubject.Text = "";
    }
}
//FileInfo TheFile = new FileInfo(MapPath(".") + "\\" + txtFile.Text);
//if (TheFile.Exists) {
//File.Delete(MapPath(".") + "\\" + txtFile.Text);
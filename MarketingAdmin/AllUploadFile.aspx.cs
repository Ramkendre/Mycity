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

public partial class MarketingAdmin_AllUploadFile : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { }
        DateFormatStatus();
    }
    //----------------------------------------------------------Current Date Format---------------------------------------------------------------------

    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    public void LoadGrid(string Sql)
    {
        try
        {
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
        catch (Exception ex)
        { }

    }
    protected void ddlUploadCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        Loaddata();
    }
    public void Loaddata()
    {
        string Sql = "";
        if (ddlUploadCenter.SelectedValue == "1")
        {
            Sql = "Select Id,Committee_name,Committee_url,FileName,EntryDate from committeedetail where Committee_name='MPCC' order by Id desc";
            LoadGrid(Sql);
        }
        else if (ddlUploadCenter.SelectedValue == "2")
        {
            Sql = "Select Id,Committee_name,Committee_url,FileName ,EntryDate from committeedetail where Committee_url like 'http://www.myct.in/smt.aspx/%' order by Id desc";
            LoadGrid(Sql);
        }
        else if (ddlUploadCenter.SelectedValue == "3")
        {
            Sql = "Select Id,Committee_name,Committee_url,FileName ,EntryDate from committeedetail where Committee_url like 'http://www.myct.in/BJS.aspx%' order by Id desc";
            LoadGrid(Sql);
        }
    }
    protected void btnShidori_Click(object sender, EventArgs e)
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
                    if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".bmp" || fileExt == ".jpeg" || fileExt == ".png" || fileExt == ".pdf" || fileExt == ".docx")
                    {
                        if (ddlUploadCenter.SelectedValue == "1")
                        {
                            file.SaveAs(Server.MapPath("~/downloadfilesMPCC/") + fileName);
                            string Sql = "Update committeedetail set FileName='N" + fileName + "' , EntryDate='" + DateFormat + "' where Id=32";
                            int k = cc.ExecuteNonQuery(Sql);
                            if (k == 1)
                            {
                                Response.Write("<script>alert('File Uploaded successfully')</script>");
                                Loaddata(); 
                                Clear();
                               
                            }
                            else
                            {
                                Response.Write("<script>alert('File not Uploaded successfully')</script>");
                            }
                        }
                        else if (ddlUploadCenter.SelectedValue == "2")
                        {
                            if (txtSubject.Text == "" || txtSubject.Text == null)
                            {
                                Response.Write("<script>alert('Please Enter The month and date like e.g  Sept13')</script>");
                            }
                            else
                            {
                                file.SaveAs(Server.MapPath("~/downloadfileSMT/") + fileName);

                                string UrlFile = "http://www.myct.in/smt.aspx/" + txtSubject.Text;
                                string Sql = "insert into committeedetail(Committee_name,Committee_url,FileName,roleid,userid,EntryDate)" +
                                    " values('" + txtSubject.Text + "','" + UrlFile + "','" + fileName + "','" + Convert.ToString(Session["RoleId"]) + "','" + Convert.ToString(Session["MarketingUser"]) + "', '" + DateFormat + "')";
                                int k = cc.ExecuteNonQuery(Sql);
                                if (k == 1)
                                {
                                    Response.Write("<script>alert('File Uploaded successfully')</script>");
                                    Loaddata(); 
                                    Clear();
                                   
                                }
                                else
                                {
                                    Response.Write("<script>alert('File not Uploaded successfully')</script>");
                                }
                            }
                        }
                        else if (ddlUploadCenter.SelectedValue == "3")
                        {
                            if (txtSubject.Text == "" || txtSubject.Text == null)
                            {
                                Response.Write("<script>alert('Please Enter The month and date like e.g  Sept13')</script>");
                            }
                            else
                            {
                                file.SaveAs(Server.MapPath("~/downloadfileBJS/") + fileName);

                                string UrlFile = "http://www.myct.in/BJS.aspx/" + txtSubject.Text;
                                string Sql = "insert into committeedetail(Committee_name,Committee_url,FileName,roleid,userid,EntryDate)" +
                                    " values('" + txtSubject.Text + "','" + UrlFile + "','" + fileName + "','" + Convert.ToString(Session["RoleId"]) + "','" + Convert.ToString(Session["MarketingUser"]) + "', '" + DateFormat + "')";
                                int k = cc.ExecuteNonQuery(Sql);
                                if (k == 1)
                                {
                                    Response.Write("<script>alert('File Uploaded successfully')</script>");
                                    Loaddata();
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
    public void Clear()
    {
        ddlUploadCenter.SelectedValue = "0";
        txtSubject.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
}

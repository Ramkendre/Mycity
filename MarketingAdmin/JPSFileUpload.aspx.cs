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

public partial class JPSFileUpload : System.Web.UI.Page
{
    BLLFileUpload bllFileobj = new BLLFileUpload();
    int status;
    CommonCode cc = new CommonCode();
   
    string filename;
   
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            displayrecords();
         
            
        }

    }

    private void displayrecords()
    {
        string rolename = Session["RoleName"].ToString();
        string sql = "select roleid from SubMenuPermission where RoleName='" + rolename + "' ";
        int roleid = cc.ExecuteScalar1(sql);
        string sqldisplay = "select Committee_url,FileName from committeedetail where roleid='" + roleid + "'";
        DataSet ds = cc.ExecuteDataset(sqldisplay);
        GridShow.DataSource = ds.Tables[0];
        GridShow.DataBind();

    }

   

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (txturlName.Text == "" || txturlName.Text == null)
        {
           // ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Enter Url Name')", true);
            Response.Write("<script>(alert)('Please Enter Url Name')</script>");
            //lblError.Text = "Please Enter Url Name";

        }
        else
        {
            DateTime date = System.DateTime.Now;
            if (myFile.HasFile)
            {
                try
                {
                    string path = "";

                    filename = myFile.FileName;
                    string mobileno = Convert.ToString(Session["MobileNumber"]);
                    string userid = Session["MarketingUser"].ToString();

                    if (userid != "")
                    {

                        string thisDir = Server.MapPath("~/downloadfileJPS/");

                        System.IO.Directory.CreateDirectory(thisDir);


                        string newpa = "" + thisDir;

                        string newpath = Server.MapPath("~/downloadfileJPS/");

                        path = newpath + "\\" + myFile.FileName;


                        string ePath = newpa+filename;
                        System.IO.DirectoryInfo di = new DirectoryInfo(ePath);
                        if (File.Exists(ePath))
                        {
                           // lblError.Text = "This file is already exists,cannot upload file";
                            Response.Write("<script>(alert)('This file is already exists,cannot upload file')</script>");

                        }
                        else
                        {
                            
                            string rolename = Session["RoleName"].ToString();
                            string sql = "select roleid from SubMenuPermission where RoleName='" + rolename + "' ";
                            int roleid = cc.ExecuteScalar1(sql);
                            string sqlid = "select Id from committeedetail where roleid='" + roleid + "' and committee_name='" + txturlName.Text + "'";
                            string Id = cc.ExecuteScalar(sqlid);
                            if (!(Id == null || Id == ""))
                            {
                                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('This Name is already exist')", true);
                                Response.Write("<script>(alert)('This Name is already exist')</script>");
                            }
                            else
                            {
                                myFile.SaveAs(path);
                                string committeeurl = "http://www.myct.in/JPS.aspx/" + txturlName.Text + "";
                                bllFileobj.Commiteename = txturlName.Text;
                                bllFileobj.Commiteeurl = committeeurl;
                                bllFileobj.Filename = filename;
                                bllFileobj.Roleid = roleid;
                                bllFileobj.Userid = userid;
                                status = bllFileobj.BLLinsertFileupload(bllFileobj);

                                if (status == 0)
                                {
                                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File added Successfully')", true);
                                    Response.Write("<script>(alert)('File added Successfully')</script>");
                                }
                            }
                        }


                    }
                }


                catch (Exception ex)
                { }
            }
        }
        
    }
   

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        txturlName.Text = "";
        
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=27");
    }
    protected void GridShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridShow.PageIndex = e.NewPageIndex;
        displayrecords();
    }
}

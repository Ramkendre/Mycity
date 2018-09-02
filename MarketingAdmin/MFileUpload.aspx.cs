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

public partial class MFileUpload : System.Web.UI.Page
{

    UserRegistrationBLL usrBLL = new UserRegistrationBLL();
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
         string Role = Convert.ToString(Session["RoleId"]);
         if (Role == "28" || Role == "29")
         {
             string Id = Request.QueryString["Id"];
             string sql = "select usrFirstName+''+usrLastName as username,usrMobileNo,FileName,Committee_url from UserMaster inner join committeedetail on UserMaster.usrUserId =committeedetail.userid where Id='" + Id + "'";
             DataSet ds = cc.ExecuteDataset(sql);
             gvUser.DataSource = ds.Tables[0];
             gvUser.DataBind();
         }
         else if (Role == "37")
         {
             string Id = "32";
             string sql = "select usrFirstName+''+usrLastName as username,usrMobileNo,FileName,Committee_url from UserMaster inner join committeedetail on UserMaster.usrUserId =committeedetail.userid where Id='" + Id + "'";
             DataSet ds = cc.ExecuteDataset(sql);
             gvUser.DataSource = ds.Tables[0];
             gvUser.DataBind();
         }
         else if (Role == "38")
         {
             string Id = Request.QueryString["Id"];
             string sql = "select usrFirstName+''+usrLastName as username,usrMobileNo,FileName,Committee_url from UserMaster inner join committeedetail on UserMaster.usrUserId =committeedetail.userid where Id='" + Id + "'";
             DataSet ds = cc.ExecuteDataset(sql);
             gvUser.DataSource = ds.Tables[0];
             gvUser.DataBind();
         }

    }

   
   

    


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string Role = Convert.ToString(Session["RoleId"]);
        if (Role == "28" || Role == "29")
        {
            string Id = Request.QueryString["Id"];
            string userid = Session["MarketingUser"].ToString();
            DateTime date = System.DateTime.Now;
            if (myFile.HasFile)
            {
                try
                {
                    string path = "";

                    filename = myFile.FileName;
                    string mobileno = Convert.ToString(Session["MobileNumber"]);

                    string sql = "select Committee_name,Committee_url from committeedetail where Id='" + Id + "'";
                    DataSet dset = cc.ExecuteDataset(sql);
                    string committeename = Convert.ToString(dset.Tables[0].Rows[0]["Committee_name"]);
                    string comitteeurl = Convert.ToString(dset.Tables[0].Rows[0]["Committee_url"]);

                    if (Id != "")
                    {
                        string thisDir = Server.MapPath("~/downloadfilesMLA/");

                        System.IO.Directory.CreateDirectory(thisDir + committeename + "");


                        string newpa = "" + thisDir + committeename + "";

                        string newpath = Server.MapPath("~/downloadfilesMLA/" + committeename + "");

                        path = newpath + "\\" + myFile.FileName;


                        string ePath = newpa;
                        System.IO.DirectoryInfo di = new DirectoryInfo(ePath);
                        FileInfo[] fiArr = di.GetFiles();
                        foreach (FileInfo fi in fiArr)
                        {
                            fi.Delete();
                        }

                        myFile.SaveAs(path);
                        string type = System.IO.Path.GetExtension(myFile.FileName);

                        string sqlupdate = "update committeedetail set FileName='" + filename + "',userid='" + userid + "' where Id='" + Id + "' and Committee_name='" + committeename + "'";
                        int status = cc.ExecuteScalar1(sqlupdate);
                        if (status == 0)
                        {
                            displayrecords();
                            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File added Successfully')", true);
                            Response.Write("<script>(alert)('File Uploaded Successfully')</script>");
                        }


                    }
                }


                catch (Exception ex)
                { }
            }
        }
        else if (Role == "38")
        {
            string Id = Request.QueryString["Id"];
            string userid = Session["MarketingUser"].ToString();
            DateTime date = System.DateTime.Now;
            if (myFile.HasFile)
            {
                try
                {
                    string path = "";

                    filename = myFile.FileName;
                    string mobileno = Convert.ToString(Session["MobileNumber"]);

                    string sql = "select Committee_name,Committee_url from committeedetail where Id='" + Id + "'";
                    DataSet dset = cc.ExecuteDataset(sql);
                    string committeename = Convert.ToString(dset.Tables[0].Rows[0]["Committee_name"]);
                    string comitteeurl = Convert.ToString(dset.Tables[0].Rows[0]["Committee_url"]);

                    if (Id != "")
                    {
                        string thisDir = Server.MapPath("~/download files/");

                        System.IO.Directory.CreateDirectory(thisDir + committeename + "");


                        string newpa = "" + thisDir + committeename + "";

                        string newpath = Server.MapPath("~/download files/" + committeename + "");

                        path = newpath + "\\" + myFile.FileName;


                        string ePath = newpa;
                        System.IO.DirectoryInfo di = new DirectoryInfo(ePath);
                        FileInfo[] fiArr = di.GetFiles();
                        foreach (FileInfo fi in fiArr)
                        {
                            fi.Delete();
                        }

                        myFile.SaveAs(path);
                        string type = System.IO.Path.GetExtension(myFile.FileName);

                        string sqlupdate = "update committeedetail set FileName='" + filename + "',userid='" + userid + "' where Id='" + Id + "' and Committee_name='" + committeename + "'";
                        int status = cc.ExecuteScalar1(sqlupdate);
                        if (status == 0)
                        {
                            displayrecords();
                            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File added Successfully')", true);
                            Response.Write("<script>(alert)('File Uploaded Successfully')</script>");
                        }


                    }
                }


                catch (Exception ex)
                { }
            }

        }
        else if (Role == "37")
        {
            string userid = Session["MarketingUser"].ToString();
            DateTime date = System.DateTime.Now;
            string Id = "32";
            string sql = "select Committee_name,Committee_url from committeedetail where Id='" + Id + "'";
            DataSet dset = cc.ExecuteDataset(sql);
            string committeename = Convert.ToString(dset.Tables[0].Rows[0]["Committee_name"]);
            string comitteeurl = Convert.ToString(dset.Tables[0].Rows[0]["Committee_url"]);
            if (myFile.HasFile)
            {
                try
                {
                    string path = "";

                    filename = myFile.FileName;
                    string mobileno = Convert.ToString(Session["MobileNumber"]);
                    if (Id != "")
                    {


                        string thisDir = Server.MapPath("~/downloadfilesMPCC/");



                        System.IO.Directory.CreateDirectory(thisDir);

                        string newpath = Server.MapPath("~/downloadfilesMPCC/");

                        path = newpath + "\\" + myFile.FileName;


                        string ePath = newpath;
                        System.IO.DirectoryInfo di = new DirectoryInfo(thisDir);
                        FileInfo[] fiArr = di.GetFiles();
                        foreach (FileInfo fi in fiArr)
                        {
                            fi.Delete();
                        }

                        myFile.SaveAs(path);


                        string sqlupdate = "update committeedetail set FileName='" + filename + "',userid='" + userid + "',roleid='" + Role + "' where Id='" + Id + "' and Committee_name='" + committeename + "'";
                        int status = cc.ExecuteScalar1(sqlupdate);
                        if (status == 0)
                        {
                            displayrecords();

                            Response.Write("<script>(alert)('File Uploaded Successfully')</script>");
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
        Response.Redirect("../MarketingAdmin/MFileUpload.aspx");
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
       // Response.Redirect("../MarketingAdmin/MBulletien.aspx");
    }
}

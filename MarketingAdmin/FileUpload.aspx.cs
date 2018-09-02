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
using System.Threading;

public partial class MarketingAdmin_FileUpload : System.Web.UI.Page
{
    UserRegistrationBLL usrBLL = new UserRegistrationBLL();
    int status;
    CommonCode cc = new CommonCode();
    string userid = "";
    string usrAutoId = "";
    string filename;
    string newstring = "";
    string url = "";
    string fakefileName = "";
    string mobileno = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridUploadshow();

        }

    }

    private void GridUploadshow()
    {
        string mono = Convert.ToString(Session["MobileNumber"]);
        string sql = "select id, upload_date,actual_filename,url_link from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mono + "' order by id desc";
        //string sql = "select upload_date,actual_filename from uploaddetails where folderuserid='"+userid.ToString()+"'";
        DataSet dt = cc.ExecuteDataset(sql);
        GridUpload.DataSource = dt.Tables[0];
        GridUpload.DataBind();

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {

       
        DateTime date = System.DateTime.Now;
        if (myFile.HasFile)
        {
            try
            {
                string path = "";

                filename = myFile.FileName;
               // Session["filename"]=filename ;

                string mobileno = Convert.ToString(Session["MobileNumber"]);

                string sql = "select usrAutoId, usruserid,JoinGroup from usermaster where usrMobileNo='" + mobileno + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                userid = Convert.ToString(ds.Tables[0].Rows[0]["usruserid"]);
                usrAutoId = Convert.ToString(ds.Tables[0].Rows[0]["usrAutoId"]);
                string JoinGroup = Convert.ToString(ds.Tables[0].Rows[0]["JoinGroup"]);

                string checkq = "select actual_filename from uploaddetails where actual_filename='" + filename + "' and folderuserid='" + userid + "'";
                string checkfilename = cc.ExecuteScalar(Convert.ToString(checkq));
                if (checkfilename == filename)
                {

                    Response.Write("<script>alert('File is already exist')</script>");

                }

                else
                {

                    if (userid != "")
                    {


                        string thisDir = Server.MapPath("~/User_Resource/");



                        System.IO.Directory.CreateDirectory(thisDir + userid + "");


                        string newpa = "" + thisDir + userid + "";

                        string newpath = Server.MapPath("~/User_Resource/" + userid + "");

                        path = newpath + "\\" + myFile.FileName;


                        if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".wav" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".mp4" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".txt" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".doc" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".xlsx" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".mp3" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".flv" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".avi" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".xls" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".pdf" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".png" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".gif" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpeg" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".csv")
                        {
                            lblError.Text = "The file must have an extension of .MP3,.FLV,.AVI,.XLS,.xlsx.PDF,.JPG,.JPEG,.png,.gif,.csv,.doc,.txt,.mp4,.wav";
                            return;
                        }

                        else
                        {

                            string ePath = newpa;
                            string[] filename1 = Directory.GetFiles(ePath, "*");




                            myFile.SaveAs(path);
                            string type = System.IO.Path.GetExtension(myFile.FileName);

                             fakefileName = Guid.NewGuid().ToString();
                            string fname = filename.Replace(filename, fakefileName);
                            string newfname = fakefileName.Remove(5);
                            Response.Write("<script>alert('File Uploaded Successfully')</script>");
                            //string ur = "User_Resource/";
                            string aa = "http://www.myct.in/NCP/down.aspx?";
                             newstring = aa.Replace("NCP", JoinGroup);
                             url = "" + newstring + usrAutoId + newfname + "";
                            if (userid != "")
                            {
                                string sql11 = "update usermaster set FilePath= '" + url + "' where usrUserid='" + userid + "'";
                                int a = cc.ExecuteNonQuery(sql11);
                            }

                            string senderid = "myctin";
                            string Message = "Dear user Download Url " + url + "" + cc.AddSMS(mobileno);
                            cc.SendMessageTra(senderid, mobileno, Message);

                            string sqlinsert = "insert into uploaddetails(autouserid,url,upload_filename,upload_filetype,upload_date,folderuserid,actual_filename,url_link)" +
                                "values('" + usrAutoId + "','" + url + "','" + newfname + "','" + type + "','" + date + "','" + userid + "','" + filename + "','" + url + "')";
                            int ss = cc.ExecuteNonQuery(sqlinsert);


                        }

                    }
                }

            }
            catch (Exception ex)
            { }
        }
        GridUploadshow();
    }


    protected void lnkDownload_Click(object sender, EventArgs e)
    {
         mobileno = Convert.ToString(Session["MobileNumber"]);

        string sql = "select usruserid from usermaster where usrMobileNo='" + mobileno + "'";
        string usrid = cc.ExecuteScalar(sql);
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        string filePath = GridUpload.DataKeys[gvrow.RowIndex].Value.ToString();
        Response.ContentType = "image/jpg";
        string newpp = usrid + "/";
        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/User_Resource/" + newpp));

        foreach (FileInfo fi in di.GetFiles())
        {
            if (System.IO.Path.GetExtension(di.Name).ToLower() != ".wav" && System.IO.Path.GetExtension(di.Name).ToLower() != ".mp4" && System.IO.Path.GetExtension(di.Name).ToLower() != ".txt" && System.IO.Path.GetExtension(di.Name).ToLower() != ".doc" && System.IO.Path.GetExtension(di.Name).ToLower() != ".xlsx" && System.IO.Path.GetExtension(di.Name).ToLower() != ".mp3" && System.IO.Path.GetExtension(di.Name).ToLower() != ".flv" && System.IO.Path.GetExtension(di.Name).ToLower() != ".avi" && System.IO.Path.GetExtension(di.Name).ToLower() != ".xls" && System.IO.Path.GetExtension(di.Name).ToLower() != ".pdf" && System.IO.Path.GetExtension(di.Name).ToLower() != ".jpg" && System.IO.Path.GetExtension(di.Name).ToLower() != ".png" && System.IO.Path.GetExtension(di.Name).ToLower() != ".gif" && System.IO.Path.GetExtension(di.Name).ToLower() != ".jpeg" && System.IO.Path.GetExtension(di.Name).ToLower() != ".csv")
            {
                if (fi.Name == filePath)
                {
                    //fileDownload(fi.Name, di.FullName + fi.Name);
                }



            }
        }

    }

    protected void GridUpload_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            Session["id"] = Id;
            if (Convert.ToString(e.CommandName) == "Delete")
            {
                string sqlll = "select actual_filename,folderuserid from uploaddetails where id='" + Id + "'";
                DataSet ds11 = cc.ExecuteDataset(sqlll);
                string folder = Convert.ToString(ds11.Tables[0].Rows[0]["folderuserid"]);
                string a_filename = Convert.ToString(ds11.Tables[0].Rows[0]["actual_filename"]);
                DirectoryInfo di1 = new DirectoryInfo(Server.MapPath("~/User_Resource/" + folder));
                string ePath = di1.ToString();
                string query = "delete from uploaddetails where id='" + Id + "'";
                DataSet ds = cc.ExecuteDataset(query);

                RemoveFiles(ePath, a_filename);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File Deleted Successfully')", true);
               


            }
            else if (Convert.ToString(e.CommandName) == "Download")
            {
                Groupname.Visible = true;
                //Id = Convert.ToString(e.CommandArgument);
                //lblId.Text =Id;

                //lbldownloadfrnd.Text = Id;
                string sql121 = "select actual_filename from uploaddetails where id='" + Id + "'";
                string actualfilename = cc.ExecuteScalar(sql121);
                lblfilename.Visible = true;
                lblfilename.Text = actualfilename;
                //string labelfilename = lblfilename.Text;

            }

           
        }
        catch { }
        GridUploadshow();
    }

    private void RemoveFiles(string strPath, string filename)
    {

        System.IO.DirectoryInfo di = new DirectoryInfo(strPath);

        FileInfo[] fiArr = di.GetFiles();

        foreach (FileInfo fi in fiArr)
        {

            if (fi.Name == filename)
            {

                fi.Delete();

            }

        }

    }
  
    protected void GridUpload_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridUpload.PageIndex = e.NewPageIndex;
        GridUploadshow();
    }
    protected void btndownload_Click(object sender, EventArgs e)
    {
         mobileno = Convert.ToString(Session["MobileNumber"]);

        string sql = "select usruserid from usermaster where usrMobileNo='" + mobileno + "'";

        userid = cc.ExecuteScalar(sql);
        
        if (drpdownfrnd.SelectedIndex == 1)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR1='1' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='"+mobileno+"' and id='"+urlid+"'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + usrAutoId + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                   "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 1 ')", true);

        }
        else if (drpdownfrnd.SelectedIndex == 2)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR2='2' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                  "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 2 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 3)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR3='3' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                  "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 3 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 4)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR4='4' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 4 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 5)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR5='5' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 5 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 6)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR6='6' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 6 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 7)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR7='7' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 7 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 8)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR8='8' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 8 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 9)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR9='9' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 9 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 10)
        {

            string sqlsearch = "select FriRelId,friendid,senderid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR10='10' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 10 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 11)
        {

            string sqlsearch = "select FriRelId,friendid,senderid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR11='11' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 11 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 12)
        {

            string sqlsearch = "select FriRelId,friendid,senderid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR12='12' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 12 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 13)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR13='13' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 13 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 14)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR14='14' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 14 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 15)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR15='15' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 15 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 16)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR16='16' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 16 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 17)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR17='17' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 17 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 18)
        {

            string sqlsearch = "select FriRelId,friendid,senderid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR18='18' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 18 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 19)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR19='19' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 19 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 20)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR20='20' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 20 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 21)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR21='21' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 21 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 22)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR22='22' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 22 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 23)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR23='23' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 23 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 24)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR24='24' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 24 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 25)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR25='25' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 25 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 26)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR26='26' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 26 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 27)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR27='27' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 27 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 28)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR28='28' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 28 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 29)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR29='29' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 29 ')", true);
        }
        else if (drpdownfrnd.SelectedIndex == 30)
        {

            string sqlsearch = "select FriRelId,senderid,friendid,usrMobileNo from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where friendrelationmaster.FR30='30' and friendrelationmaster.userid='" + userid + "'";
            DataSet ds1 = cc.ExecuteDataset(sqlsearch);
            foreach (DataRow dr1 in ds1.Tables[0].Rows)
            {
                string friendid = Convert.ToString(dr1["friendid"]);
                string firRelid = Convert.ToString(dr1["FriRelId"]);
                string mobile = Convert.ToString(dr1["usrMobileNo"]);
                string senderid = Convert.ToString(dr1["senderid"]);
                string flagstatus = "Active";
                string urlid = Convert.ToString(Session["id"]);
                string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
                string urlstring = cc.ExecuteScalar(sqlfetch);
                fakefileName = Guid.NewGuid().ToString();
                string newfname = fakefileName.Remove(5);
                string urlstring1 = urlstring.Remove(33);
                string frndurl = "" + urlstring1 + newfname + "";
                string sqlinsert2 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                 "values('" + firRelid + "','" + urlstring + "','" + urlstring + "','" + flagstatus + "')";
                string b = cc.ExecuteScalar(sqlinsert2);
                string sqlinsert1 = "insert into frienddownloadlink(friendid,usr_url,frnd_url,flag)" +
                    "values('" + firRelid + "','" + urlstring + "','" + frndurl + "','" + flagstatus + "')";
                string a = cc.ExecuteScalar(sqlinsert1);
                string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(mobile);
                cc.SendMessageTra(senderid, mobile, friendMessage);

            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully to Group No 30 ')", true);
        }

    }
    protected void btnSubmitGroup_Click(object sender, EventArgs e)
    {
        string sql = "select Userid from userGroup where GroupId='16'";
        string user = cc.ExecuteScalar(sql);

    }
}

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

public partial class html_demofileupload : System.Web.UI.Page
{
    UserRegistrationBLL usrBLL = new UserRegistrationBLL();
    int status;
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string filename = "";
        //if (FileUpload1.HasFile)
        //{
        //   string a= FileUpload1.FileName.ToString();
        //    string uploadFolder = Request.PhysicalApplicationPath + "UploadHere\\";
        //    FileUpload1.SaveAs(uploadFolder + FileUpload1.FileName);  
        //}

        if (myFile.HasFile)
        {
            try
            {
                string path = "";

                filename = myFile.FileName;
                //}
               string mobileno = Convert.ToString(Session["MobileNo"]);
              
               string sql = "select usruserid from usermaster where usrMobileNo='" + mobileno + "'";
                DataSet ds = cc.ExecuteDataset(sql);
                string userid = Convert.ToString(ds.Tables[0].Rows[0]["usruserid"]);


                if (userid != "")
                {


                    string thisDir = Server.MapPath("~/User_Resource/");



                    System.IO.Directory.CreateDirectory(thisDir + userid + "");


                    string newpa = "" + thisDir + userid + "";

                    string newpath = Server.MapPath("~/User_Resource/" + userid + "");

                    path = newpath + "\\" + myFile.FileName;

                    if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".wav" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".mp4" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".txt" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".doc" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".xlsx"  && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".mp3" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".flv" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".avi" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".xls" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".pdf" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".png" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".gif" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpeg" && System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".csv")
                    {
                        lblError.Text = "The file must have an extension of .MP3,.FLV,.AVI,.XLS,.xlsx.PDF,.JPG,.JPEG,.png,.gif,.csv,.doc,.txt,.mp4,.wav";
                        return;
                    }

                    else
                    {
                       
                        string ePath = newpa;
                        string[] filename1 = Directory.GetFiles(ePath, "*");



                        foreach (string str in filename1)
                        {
                            File.Delete(str);
                        }



                        myFile.SaveAs(path);
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File Uploaded Successfully')", true);
                        string aa = "http://www.myct.in/NCP/down.aspx?User_Resource/";
                        string url = "" + aa + userid + "";
                        if (userid != "")
                        {
                            string sql11 = "update usermaster set FilePath= '" + url + "' where usrUserid='" + userid + "'";
                            int a = cc.ExecuteNonQuery(sql11);
                        }
                       
                        string senderid = "myctin";
                        string Message = "Dear user Downloading Url is " + url + "" + cc.AddSMS(mobileno);
                        cc.SendMessageTra(senderid,mobileno,Message);


                        
                    }

                }
            }
            catch (Exception ex)
            { }
        }

    }

}



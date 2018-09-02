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

public partial class MarketingAdmin_AdminFileUpload : System.Web.UI.Page
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
            displayrecords();
            bind();
             GridUploadshow();
        }

    }

    private void displayrecords()
    {
        string mono = Convert.ToString(Session["MobileNumber"]);
        string sql = "select SMSbal,JoinGroup from usermaster where usrMobileNo='" + mono + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        lblgroupname.Text = Convert.ToString(ds.Tables[0].Rows[0]["JoinGroup"]);
        lblBalance.Text = Convert.ToString(ds.Tables[0].Rows[0]["SMSbal"]);


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

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

        int i = Convert.ToInt32(Convert.ToString(ddlState.SelectedValue));
        string sql = "select distId,distName from DistrictMaster where stateId=" + i.ToString() + "";
        DataSet dtDist = new DataSet();
        dtDist = cc.ExecuteDataset(sql);
        ddlDist.DataSource = dtDist.Tables[0];
        ddlDist.DataTextField = "distName";
        ddlDist.DataValueField = "distId";
        ddlDist.DataBind();
        ddlDist.Items.Add("--Select-- ");
        ddlDist.SelectedIndex = ddlDist.Items.Count - 1;
        ddlDist.Items[ddlDist.Items.Count - 1].Value = "";
       
    }

    protected void ddlDist_SelectedIndexChanged(object sender, EventArgs e)
    {

        int i = Convert.ToInt32(Convert.ToString(ddlDist.SelectedValue));
        string sql = "select CityId,CityName from CityMaster where DistId=" + i.ToString() + "";
        DataSet dtCity = new DataSet();
        dtCity = cc.ExecuteDataset(sql);
        ddlCity.DataSource = dtCity.Tables[0];
        ddlCity.DataTextField = "CityName";
        ddlCity.DataValueField = "CityId";
        ddlCity.DataBind();
        ddlCity.Items.Add("--Select--");
        ddlCity.SelectedIndex = ddlCity.Items.Count - 1;
        ddlCity.Items[ddlCity.Items.Count - 1].Value = "";

       

    }

    private void bind()
    {
        string sql = "select StateId,StateName from StateMaster ";
        DataSet dtState = new DataSet();
        dtState = cc.ExecuteDataset(sql);
        ddlState.DataSource = dtState.Tables[0];
        ddlState.DataTextField = "StateName";
        ddlState.DataValueField = "StateId";
        ddlState.DataBind();
        ddlState.Items.Add("--select--");
        ddlState.SelectedIndex = ddlState.Items.Count - 1;
        ddlState.Items[ddlState.Items.Count - 1].Value = "";




    }

    protected void GridUpload_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridUpload.PageIndex = e.NewPageIndex;
        GridUploadshow();
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
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('File Deleted Successfully')", true);
               



            }
            else if (Convert.ToString(e.CommandName) == "Download")
            {

                divGroupname.Visible = true;
                string sql121 = "select actual_filename from uploaddetails where id='" + Id + "'";
                string actualfilename = cc.ExecuteScalar(sql121);
                lblfilename.Visible = true;
                lblfilename.Text = actualfilename;
                //string labelfilename = lblfilename.Text;
               // divselectlevel.Visible = true;
                divselectlevel.Visible = true;
            }


        }
        catch { }
       // GridUploadshow();
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
                Response.Write("<script>alert('File deleted Successfully')</script>");

            }

        }

        GridUploadshow();
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
    protected void btnSubmitGroup_Click(object sender, EventArgs e)
    {
         show();
         btnSubmitGroup.Enabled = false;
    }


    public void show()
    {
        string stateid="", distid="", cityid = "";
        string date = System.DateTime.Now.ToString();
        string senderid = "myctin";
        int count = 0;

        string mobileno = Convert.ToString(Session["MobileNumber"]);
        string sql = "select JoinGroup,SMSBal,usrFirstName from usermaster where usrMobileNo='" + mobileno + "'";
        DataSet ds1 = cc.ExecuteDataset(sql);
        string grpname = Convert.ToString(ds1.Tables[0].Rows[0]["JoinGroup"]);
        int SMSBal = Convert.ToInt32(ds1.Tables[0].Rows[0]["SMSBal"]);
        string Fname = Convert.ToString(ds1.Tables[0].Rows[0]["usrFirstName"]);
        string sql1 = "select GroupValueId from GroupValue where GroupValueName='" + grpname + "'";
        //int grpid = cc.ExecuteNonQuery(sql1);
        string grpid = cc.ExecuteScalar(sql1);
        string fetchquery = "select UserMaster.usrMobileNo, UserMaster.usrAutoId ,UserMaster.usrFirstName, UserMaster.usrLastName " +
                    " from UserMaster inner join UserGroup " +
                    " on UserMaster.usrUserId =UserGroup.UserId " +
                    " inner join CityMaster " +
                    " on CityMaster.cityId = UserMaster.usrCityId " +
                    " where UserGroup.GroupId  ='" + grpid + "' ";

        if (ddlState.SelectedIndex != ddlState.Items.Count - 1)
        {

            fetchquery = fetchquery + " and CityMaster.stateId='" + ddlState.SelectedValue.ToString() + "'";
            stateid = ddlState.SelectedValue.ToString();
        }

        if (ddlDist.SelectedIndex != ddlDist.Items.Count - 1)
        {

            fetchquery = fetchquery + " and CityMaster.distId='" + ddlDist.SelectedValue.ToString() + "'";
            distid = ddlDist.SelectedValue.ToString();
        }
        if (ddlCity.SelectedIndex != ddlCity.Items.Count - 1)
        {
            fetchquery = fetchquery + " and CityMaster.cityId='" + ddlCity.SelectedValue.ToString() + "' ";
            cityid = ddlCity.SelectedValue.ToString();
        }
        DataSet ds = cc.ExecuteDataset(fetchquery);
        

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string usermobileno = Convert.ToString(dr["usrMobileNo"]);
            string firRelid = Convert.ToString(dr["usrAutoId"]);
            string flagstatus = "Active";
            string urlid = Convert.ToString(Session["id"]);
            string sqlfetch = "select url from uploaddetails inner join UserMaster on folderuserid =usrUserId where usrMobileNo='" + mobileno + "' and id='" + urlid + "'";
            string urlstring = cc.ExecuteScalar(sqlfetch);
            fakefileName = Guid.NewGuid().ToString();
            string newfname = fakefileName.Remove(5);
            string urlstring1 = urlstring.Remove(33);
            string frndurl = "" + urlstring1 + newfname + "";
            string sqlinsert1 = "insert into admindownloadlink(teamname,stateid,districtid,cityid,usr_url,sentto_url,send_date,flag)" +

                "values('" + grpname + "','"+stateid+"','"+distid+"','"+cityid+"','" + urlstring + "','" + frndurl + "','"+date+"','" + flagstatus + "')";
            string a = cc.ExecuteScalar(sqlinsert1);
            string friendMessage = "Dear user Download Url " + frndurl + "" + cc.AddSMS(usermobileno);
            cc.SendMessageTra(senderid, usermobileno, friendMessage);
            count=count +1;
           
        }
        lblmsg.Visible = true;
        lblmsg.Text = "Dear, "+Fname.ToString()+" " + count.ToString() + " no. of download link sent successfully";
        SMSBal = SMSBal - count;
        string sqlupdate = "update usermaster set SMSBal='" + SMSBal + "' where usrMobileNo='" + mobileno + "' ";
        string b = cc.ExecuteScalar(sqlupdate);

        displayrecords();
       




    }


    //protected void btnView_Click(object sender, EventArgs e)
    //{
    //    divview.Visible = true;
        //string mobileno = Convert.ToString(Session["MobileNumber"]);
        //string sql = "select JoinGroup from usermaster where usrMobileNo='" + mobileno + "'";
        //string grpname = cc.ExecuteScalar(sql);
        //string sql1 = "select GroupValueId from GroupValue where GroupValueName='" + grpname + "'";
        ////int grpid = cc.ExecuteNonQuery(sql1);
        //string grpid = cc.ExecuteScalar(sql1);
        //string fetchquery = "select UserMaster.usrMobileNo ,UserMaster.usrFirstName, UserMaster.usrLastName " +
        //            " from UserMaster inner join UserGroup " +
        //            " on UserMaster.usrUserId =UserGroup.UserId " +
        //            " inner join CityMaster " +
        //            " on CityMaster.cityId = UserMaster.usrCityId " +
        //            " where UserGroup.GroupId  ='" + grpid + "' ";
        
        //if(ddlState.SelectedIndex != ddlState.Items.Count -1)
        //{
        //       fetchquery = fetchquery + " and CityMaster.stateId='" + ddlState.SelectedValue.ToString() + "'";
        //}

        //if(ddlDist.SelectedIndex != ddlDist.Items.Count -1)
        //{
            
        // fetchquery=fetchquery +" and CityMaster.distId='" + ddlDist.SelectedValue.ToString() + "'";
        //}
        //if (ddlCity.SelectedIndex != ddlCity.Items.Count - 1)
        //{
        //    fetchquery = fetchquery + " and CityMaster.cityId='" + ddlCity.SelectedValue.ToString() + "' ";
        //}
        //DataSet ds = cc.ExecuteDataset(fetchquery);
    //    gvView.DataSource = ds.Tables[0];
    //    gvView.DataBind();

    //    btnView.Visible = false;
      

    //}

    protected void GridUpload_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

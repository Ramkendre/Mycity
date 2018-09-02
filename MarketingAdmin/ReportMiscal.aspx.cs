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
using Microsoft.ApplicationBlocks.Data;


public partial class MarketingAdmin_ReportMiscal : System.Web.UI.Page
{
    #region Datatype
    string UserName = "";
    CommonCode cc = new CommonCode();
    CommonSqlQueryCode cqc = new CommonSqlQueryCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    BALMiscalRegistration objMiscalreg = new BALMiscalRegistration();
    FriendGroupBLL fgBLLObj = new FriendGroupBLL();
    DropDownList drdList;
    int status;
    public DataTable dtFriendGroup;

    #endregion Datatype

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            gridShow();
            //todaysMiscal();

            gridShowMulti();
            todaymsg();
            fetchdata();
            ddlGroupbind();
            txtMessage.Text = "www.myct.in";
            txtMultiText.Text = "www.myct.in";

        }
    }

    //---------------------------------------------------Specify the Single Or Multiple-----------------------------------------------

    #region Choice

    public void LoadData()
    {
        try
        {
            string Sql = "Select send_data,MissCallType from [Come2myCityDB].[come2mycity].LongCodeRegistration where UsrUserid='" + Convert.ToString(Session["MarketingUser"]) + "'";
            // string CallType = Convert.ToString(cc.ExecuteScalar(Sql));
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string CallType = Convert.ToString(ds.Tables[0].Rows[0]["MissCallType"]);
                string SendData = Convert.ToString(ds.Tables[0].Rows[0]["send_data"]);
                if (CallType == "Single")
                {
                    pnlExistUser.Visible = true;
                    AccordionPane1.Visible = false;
                    if (SendData == "3")
                    {
                        Emgcy();

                        btnEmgsingle.Visible = true;
                    }
                }
                else if (CallType == "Multiple")
                {
                    pnlExistUser.Visible = false;
                    AccordionPane1.Visible = true;
                    AccordionPane2.Visible = false;
                    AccordionPane3.Visible = false;
                    if (SendData == "3")
                    {
                        Emgcymulti();
                        btnEmg.Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion Choice

    //----------------------------------------Single Miss Call  (Code)----------------------------------------------------------------

    #region oldCode

    private void ddlGroupbind()
    {
        ddlGroup.Items.Clear();
        string sql = "select GroupNo from [Come2myCityDB].[come2mycity].MiscalGroup";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sql);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string Gname = Convert.ToString(ds.Tables[0].Rows[0]["GroupNo"]);
            string[] tmp = Gname.Split(',');
            ddlGroup.Items.Add("--Select--");
            ddlGroup.Items.Add("0");

            ddlViewGroup.Items.Add("--Select--");
            foreach (string s in tmp)
            {
                ddlGroup.Items.Add(s);
                ddlGroup.ID.Insert(0, s);
                ddlViewGroup.Items.Add(s);
                ddlViewGroup.ID.Insert(0, s);
            }
        }
    }
    private void ClearAll()
    {
        txtMessage.Text = "";
        txtCharCount2.Text = "";
        gridShow();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtMessage.Text.Contains("www.myct.in"))
        {
            string Id2 = Convert.ToString(lblId.Text.ToString());
            if (Id2 == "" || Id2 == null)
            {
                Insert();
            }
            else
            {
                Update(Id2);

            }
        }
        else
        {
            Response.Write("<script>(alert)('Plz add in message www.myct.in')</script>");
        }
    }
    private void Insert()
    {
        try
        {
            int count = 0;
            string message = "";
            string Prefix = "";
            if (ddlPrefix.SelectedItem.Value == "0")
            {
                Prefix = "";
            }
            else
            {
                Prefix = ddlPrefix.SelectedItem.Text;
            }
            message = "" + Prefix + " " + txtMessage.Text + "";
            int messagecount = message.Length;
            if (messagecount <= 160)
            {
                count = 1;
            }
            else if (messagecount >= 160)
            {
                count = 2;
            }
            else if (messagecount >= 306)
            {
                count = 3;
            }
            else if (messagecount >= 459)
            {
                count = 4;
            }
            else if (messagecount >= 612)
            {
                count = 5;
            }
            else if (messagecount >= 765)
            {
                count = 6;
            }
            else if (messagecount >= 918)
            {
                count = 7;
            }
            else if (messagecount >= 1071)
            {
                count = 8;
            }
            else if (messagecount >= 1224)
            {
                count = 9;
            }
            else if (messagecount >= 1377)
            {
                count = 10;
            }
            else if (messagecount >= 1530)
            {
                count = 11;
            }

            string userid = Session["MarketingUser"].ToString();
            string sql2 = "select Sim_no,reg_id from [Come2myCityDB].[come2mycity].LongCodeRegistration where usrUserid='" + userid + "'";
            DataSet ds = cc.ExecuteDataset(sql2);
            string sim = Convert.ToString(ds.Tables[0].Rows[0]["sim_no"]);
            string LongCodeid = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);
            DateTime date = DateTime.Now;
            string Group = ddlGroup.SelectedItem.Text;
            string sql1 = "update [Come2myCityDB].[come2mycity].MiscalResponse set Msg_Status='Deactive' where userid='" + userid + "' and GroupNo='" + Group + "'";
            string b = cc.ExecuteScalar(sql1);
            string Msg_status = "Active";
            string sql = "insert into [Come2myCityDB].[come2mycity].MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,GroupNo,LongCodeId,MsgCharCount,msgcount)values('" + userid + "','" + sim + "','" + message + "','" + date + "','" + Msg_status + "','" + Group + "','" + LongCodeid + "','" + messagecount + "','" + count + "') ";
            string a = cc.ExecuteScalar(sql);
            ClearAll();
            ddlGroupbind();
            ddlPrefix.ClearSelection();
            //Response.Write("<script>(alert)('Message Inserted Successfully')</script>");
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Inserted Successfully')", true);
        }
        catch (Exception ex)
        {
        }
    }
    private void gridShow()
    {
        string userid = Session["MarketingUser"].ToString();
        string sql = "select * from [Come2myCityDB].[come2mycity].MiscalResponse where userid='" + userid + "' order by id desc";
        DataSet ds = cc.ExecuteDataset(sql);
        gvMessageShow.DataSource = ds.Tables[0];
        gvMessageShow.DataBind();
    }
    protected void gvMessageShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string userid = Session["MarketingUser"].ToString();
        string Id = Convert.ToString(e.CommandArgument);
        lblId.Text = Id;
        if (Convert.ToString(e.CommandName) == "Edit")
        {

            message.Visible = true;
            string sql1 = "select ResponseMsg from [Come2myCityDB].[come2mycity].MiscalResponse where id='" + Id + "'";
            string s = cc.ExecuteScalar(sql1);
            txtMessage.Text = s;
            txtMessage.Enabled = false;
            txtCharCount2.Enabled = false;
        }
    }
    private void Update(string Id)
    {
        try
        {
            string userid = Session["MarketingUser"].ToString();
            string status = ddlstatus.SelectedItem.Text;
            string sql1 = "update [Come2myCityDB].[come2mycity].MiscalResponse set Msg_Status='Deactive' where userid='" + userid + "' and Msg_Status='Active'";
            string aa1 = cc.ExecuteScalar(sql1);
            string sql = "update [Come2myCityDB].[come2mycity].MiscalResponse set Msg_Status='" + status + "' where userid='" + userid + "' and id='" + Id + "'";
            string fire = cc.ExecuteScalar(sql);

            ClearAll();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Updated Successfully')", true);
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvMessageShow_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtMessage.Text = "";
        txtCharCount2.Text = "";
        ddlGroupbind();
        ddlPrefix.ClearSelection();
    }
    private void fetchdata()
    {
        string userid = Session["MarketingUser"].ToString();
        string sql2 = "select sim_no,IMEINO from [Come2myCityDB].[come2mycity].LongCodeRegistration where usrUserid='" + userid + "'";
        DataSet dd = cc.ExecuteDataset(sql2);
        if (dd.Tables[0].Rows.Count > 0)
        {
            string sim = Convert.ToString(dd.Tables[0].Rows[0]["sim_no"]);
            string IMEINo = Convert.ToString(dd.Tables[0].Rows[0]["IMEINO"]);

            //string Fromdate = txtFrom.Text;
            //Fromdate = cc.ChangeDt1(Fromdate);
            //string ToDate = txtTo.Text;
            //ToDate = cc.ChangeDt1(ToDate);
            lblCalc.Visible = true;
            string sql1 = "select count(*) from [Come2myCityDB].[come2mycity].Connection1 where (p1='" + sim + "' and MIMENumber='" + IMEINo + "')";
            lblCalulate.Text = cc.ExecuteScalar(sql1);

            string sql = "select top(50)* from [Come2myCityDB].[come2mycity].Connection1 where p1='" + sim + "' and MIMENumber='" + IMEINo + "' order by cid desc";
            DataSet ds = cc.ExecuteDataset(sql);
            gvLongCodeshow.DataSource = ds.Tables[0];
            gvLongCodeshow.DataBind();
        }
    }
    protected void gvLongCodeshow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvLongCodeshow.PageIndex = e.NewPageIndex;
        fetchdata();
    }
    protected void gvMessageShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMessageShow.PageIndex = e.NewPageIndex;
        gridShow();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        fetchdataMessage();
    }
    private void fetchdataMessage()
    {
        //string userid = Session["MarketingUser"].ToString();
        //string fromdate = TextBox1.Text;
        //fromdate = cc.ChangeDt1(fromdate);
        //string todate = TextBox2.Text;
        //todate = cc.ChangeDt1(todate);
        //string sql = "select MiscalResponse.ResponseMsg,MiscalResponseCounter.MobileNumber from MiscalResponseCounter" +
        //                " inner join MiscalResponse" +
        //                " on MiscalResponseCounter.Message_id=MiscalResponse.id" +
        //                " where MiscalResponse.userid='" + userid + "'" +
        //                " and date like '" + date + "'";
        //DataSet ds = cc.ExecuteDataset(sql);
        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();
    }
    private void todaysMiscal()
    {
        string userid = Session["MarketingUser"].ToString();
        string sql2 = "select sim_no,IMEINO from [Come2myCityDB].[come2mycity].LongCodeRegistration where usrUserid='" + userid + "'";
        DataSet dd = cc.ExecuteDataset(sql2);
        string sim = Convert.ToString(dd.Tables[0].Rows[0]["sim_no"]);
        string IMEINo = Convert.ToString(dd.Tables[0].Rows[0]["IMEINO"]);
        string date = System.DateTime.Now.ToShortDateString();
        date = cc.ChangeDt2(date);
        lblCalc.Visible = true;
        string sql1 = "select count(*) from Connection1 where p1='" + sim + "' and MIMENumber='" + IMEINo + "'";
        lblCalulate.Text = cc.ExecuteScalar(sql1);
        string sql = "select * from Connection1 where p1='" + sim + "' and MIMENumber='" + IMEINo + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        gvLongCodeshow.DataSource = ds.Tables[0];
        gvLongCodeshow.DataBind();

    }
    private void todaymsg()
    {
        string userid = Session["MarketingUser"].ToString();
        string date = System.DateTime.Now.ToShortDateString();
        date = cc.ChangeDt2(date);
        string sql1 = "select count(*) from [Come2myCityDB].[come2mycity].MiscalResponseCounter" +
                       " inner join [Come2myCityDB].[come2mycity].MiscalResponse" +
                       " on [Come2myCityDB].[come2mycity].MiscalResponseCounter.Message_id=MiscalResponse.id" +
                       " where [Come2myCityDB].[come2mycity].MiscalResponse.userid='" + userid + "'";

        string count = cc.ExecuteScalar(sql1);
        Label7.Visible = true;
        Label8.Text = count;
        string sql = "select top(100)MiscalResponseCounter.id as id,MiscalResponse.ResponseMsg,MiscalResponseCounter.MobileNumber,MiscalResponseCounter.date from [Come2myCityDB].[come2mycity].MiscalResponseCounter" +
                        " inner join [Come2myCityDB].[come2mycity].MiscalResponse" +
                        " on [Come2myCityDB].[come2mycity].MiscalResponseCounter.Message_id=[Come2myCityDB].[come2mycity].MiscalResponse.id" +
                        " where [Come2myCityDB].[come2mycity].MiscalResponse.userid='" + userid + "'" +
                        " order by [Come2myCityDB].[come2mycity].MiscalResponseCounter.id desc";
        DataSet ds = cc.ExecuteDataset(sql);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();

        sql = "select sum(MiscalResponse.msgcount) from [Come2myCityDB].[come2mycity].MiscalResponseCounter inner join MiscalResponse on MiscalResponseCounter.Message_id=MiscalResponse.id where MiscalResponse.userid='" + userid + "'";
        lblCount.Text = cc.ExecuteScalar(sql);
        lblMessageCount.Visible = true;
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //fetchdataMessage();
        todaymsg();
    }
    protected void gvFriendRelativeSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddFriRel")
        {
            string[] cmndAgrs = Convert.ToString(e.CommandArgument).Split(',');

            string friendId = cmndAgrs[0];
            string frirelName = cmndAgrs[1];
            string userid = Convert.ToString(Session["MarketingUser"]);

            if (userid == friendId)
            {
                gvFriendRelativeSearch.Visible = false;
                lblMesg.Text = "You can't yourself as friend.";
            }
            else
            {
                foreach (GridViewRow grdRow in gvFriendRelativeSearch.Rows)
                {
                    drdList = (DropDownList)(gvFriendRelativeSearch.Rows[grdRow.RowIndex].Cells[0].FindControl("cmbGroupType"));
                    objMiscalreg.Userid = Convert.ToString(Session["MarketingUser"]);
                    objMiscalreg.Friendid = friendId;
                    objMiscalreg.FriendName = frirelName;
                    objMiscalreg.Groupno = drdList.SelectedValue;
                    status = objMiscalreg.BALFriendIsExist(objMiscalreg);
                    if (status == 1)
                    {
                        status = objMiscalreg.BALInsertMiscalRegistration(objMiscalreg);
                        if (status > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully')", true);
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend already exist in ur group')", true);
                    }
                }
            }
            gvFriendRelativeSearch.Visible = false;
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (CSVUpload.HasFile)
        {
            string path = "";
            path = Server.MapPath("File_Upload");
            path = path + "\\" + CSVUpload.FileName;
            if (File.Exists(path))
            {
                File.Delete(path);
                CSVUpload.SaveAs(path);
            }
            else
            {
                CSVUpload.SaveAs(path);
            }
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();

            do
            {
                line = sr.ReadLine();
                string mno = "", fnm = "", lnm = "", pin = "", gr = "", ct = "", defltgrp = "", prefix = "";

                i++;
                if (i == 1)
                {
                    string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + Convert.ToString(Session["MobileNumber"]) + "'";
                    DataSet ds = new DataSet();
                    ds = cc.ExecuteDataset(sql);
                    string userId;
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                    }
                }
                if (line != null)
                {

                    string[] ArrLine = line.Split(',');
                    mno = ArrLine[0].ToString();
                    fnm = ArrLine[1].ToString();
                    lnm = ArrLine[2].ToString();
                    pin = ArrLine[3].ToString();

                    gr = ArrLine[4].ToString();
                    ct = ArrLine[5].ToString();
                    prefix = ArrLine[6].ToString();

                    RegisterNewExcel1(mno, fnm, lnm, pin, gr, ct, prefix, defltgrp);
                }

            } while (line != null);
        }
    }
    public bool RegisterNewExcel1(string mno, string fnm, string lnm, string pin, string gr, string ct, string prefix, string defltgrp)
    {
        bool a = true;
        try
        {
            string usrmoNo = Convert.ToString(Session["MobileNumber"]);
            cqc.usrMobileNo = usrmoNo.ToString();
            status = BLLIsExistUserRegistrationInitial(usrmoNo);
            if (status == 0)
            {
                status = BLLIsExistUserRegistrationInitial(mno);
                if (status == 0)
                {
                    string sql = "select * from usermaster where usrMobileNo='" + mno + "'";
                    DataSet ds1 = cc.ExecuteDataset(sql);
                    objMiscalreg.Userid = Session["MarketingUser"].ToString();
                    string friendid = Convert.ToString(ds1.Tables[0].Rows[0]["usrUserid"]);
                    objMiscalreg.Friendid = friendid;
                    string fname = Convert.ToString(ds1.Tables[0].Rows[0]["usrFirstName"]);
                    string lname = Convert.ToString(ds1.Tables[0].Rows[0]["usrLastName"]);
                    status = objMiscalreg.BALFriendIsExist(objMiscalreg);
                    if (status == 1)
                    {
                        objMiscalreg.Friendid = friendid;
                        objMiscalreg.FriendName = fname + "" + lname;
                        objMiscalreg.Groupno = gr;
                        objMiscalreg.Userid = Session["MarketingUser"].ToString();
                        objMiscalreg.BALInsertMiscalRegistration(objMiscalreg);
                    }
                    else
                    {
                        objMiscalreg.Friendid = friendid;
                        objMiscalreg.FriendName = fname + "" + lname;
                        objMiscalreg.Groupno = gr;
                        objMiscalreg.Userid = Session["MarketingUser"].ToString();
                        objMiscalreg.BALUpdateMiscalRegistration(objMiscalreg);
                    }
                }
                else
                {
                    urUserRegBLLObj.usrFirstName = fnm;
                    urUserRegBLLObj.usrLastName = lnm;
                    urUserRegBLLObj.usrPIN = pin;
                    urUserRegBLLObj.usrCityName = ct;
                    urUserRegBLLObj.usrMobileNo = mno;
                    urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
                    Random rnd = new Random();
                    urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
                    status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                    if (status > 0)
                    {
                        string senderId = "COM2MYCT";
                        string myMobileNo = urUserRegBLLObj.usrMobileNo;
                        string myPassword = cc.DESDecrypt(urUserRegBLLObj.usrPassword);
                        string myName = urUserRegBLLObj.usrFirstName;
                        string passwordMessage = "Dear " + myName + ", Password for ur First Login is " + myPassword + " " + cc.AddSMS(myMobileNo);
                        int length = passwordMessage.Length;
                        //cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                        cc.SendMessageRegistrationSMS("Website", myMobileNo, passwordMessage, length);
                    }
                    string sql1 = "select * from usermaster where usrMobileNo='" + mno + "'";
                    DataSet ds = cc.ExecuteDataset(sql1);

                    string friendid = Convert.ToString(ds.Tables[0].Rows[0]["usrUserid"]);
                    string fname = Convert.ToString(ds.Tables[0].Rows[0]["usrFirstName"]);
                    string lname = Convert.ToString(ds.Tables[0].Rows[0]["usrLastName"]);

                    cqc.frnrelFriendId = friendid;
                    cqc.frnrelUserId = Session["MarketingUser"].ToString();
                    //cqc.FR1 = "1";   //Not to add in personal group
                    //cqc.BLLInsertUserFriendRelative(cqc);
                    objMiscalreg.Friendid = friendid;
                    objMiscalreg.FriendName = fname + "" + lname;
                    objMiscalreg.Groupno = gr;
                    objMiscalreg.Userid = Session["MarketingUser"].ToString();
                    objMiscalreg.BALInsertMiscalRegistration(objMiscalreg);
                }

            }
        }
        catch (Exception ex)
        {
        }
        return a;
    }
    public int BLLIsExistUserRegistrationInitial(string mno)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int Check = 1;

        try
        {

            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrMobileNo", mno);
            par[1] = new SqlParameter("@status", 11);
            par[1].Direction = ParameterDirection.Output;

            Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserRegistrationIsExist", par));
            Check = (int)par[1].Value;

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
        return Check;
    }
    protected void lnkAddFriRel_Click(object sender, EventArgs e)
    {
        string id = Session["MarketingUser"].ToString();
        Response.Redirect("../MarketingAdmin/AddNewFriends.aspx?id=" + id);
    }
    protected void btnSearchFriRel_Click(object sender, EventArgs e)
    {
        gvFriendRelativeSearch.Visible = true;
        FriendRelativeSearch();

    }
    public void FriendRelativeSearch()
    {

        try
        {

            urUserRegBLLObj.usrAltMobileNo = Convert.ToString(Session["Mobile"]);

            urUserRegBLLObj.usrMobileNo = Convert.ToString(txtSearchFriRel.Text);
            DataTable dtUserList = urUserRegBLLObj.BLLFriendRelativeByMob(urUserRegBLLObj);

            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            dtFriendGroup = urUserRegBLLObj.BLLShowAllFriendGroup(urUserRegBLLObj);
            gvFriendRelativeSearch.DataSource = dtUserList;
            gvFriendRelativeSearch.DataBind();
            txtSearchFriRel.Text = "";


            foreach (GridViewRow grdRow in gvFriendRelativeSearch.Rows)
            {


                string sql = "select GroupNo from MiscalGroup";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string Gname = Convert.ToString(ds.Tables[0].Rows[0]["GroupNo"]);
                    string[] tmp = Gname.Split(',');
                    //drdList.Items.Clear();
                    drdList = (DropDownList)(gvFriendRelativeSearch.Rows[grdRow.RowIndex].Cells[0].FindControl("cmbGroupType"));

                    foreach (string s in tmp)
                    {

                        drdList.Items.Add(s);
                        drdList.ID.Insert(0, s);
                    }


                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDowmLoad_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Friendlist Format/MyCityFriendFile1.csv");
    }
    protected void btnViewSendGroupSMS_Click(object sender, EventArgs e)
    {
        string userid = Session["MarketingUser"].ToString();
        LoadViewSendGroupSMS();
        string sql = "select count(*) from UserMaster inner join MiscalFriends on UserMaster.usrUserId = MiscalFriends.friendid where MiscalFriends.userid ='" + userid + "' and GroupNo='" + ddlViewGroup.SelectedItem.Text + "'";
        lblGroupCount.Text = cc.ExecuteScalar(sql);
        lblGroupCount.Visible = true;
        lbltotal.Visible = true;

    }
    public void LoadViewSendGroupSMS()
    {
        string userid = Session["MarketingUser"].ToString();
        string sql = "select usrMobileNo,FriendName from UserMaster inner join MiscalFriends on UserMaster.usrUserId = MiscalFriends.friendid where MiscalFriends.userid ='" + userid + "' and GroupNo='" + ddlViewGroup.SelectedItem.Text + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        gvViewGroup.DataSource = ds.Tables[0];
        gvViewGroup.DataBind();
    }
    protected void btnGridtoexcel_Click(object sender, EventArgs e)
    {
        try
        {
            string userid = Session["MarketingUser"].ToString();
            string sql2 = "select sim_no,IMEINO from [Come2myCityDB].[come2mycity].LongCodeRegistration where usrUserid='" + userid + "'";
            DataSet dd = cc.ExecuteDataset(sql2);
            string sim = Convert.ToString(dd.Tables[0].Rows[0]["sim_no"]);
            string IMEINo = Convert.ToString(dd.Tables[0].Rows[0]["IMEINO"]);
            objMiscalreg.Simno = sim;
            objMiscalreg.IMEINO = IMEINo;
            DataSet ds = new DataSet();
            string attachment = "attachment; filename=MiscallReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            ds = objMiscalreg.BALGetAllMiscalReport(objMiscalreg);
            DataGrid grid = new DataGrid();
            grid.DataSource = ds.Tables[0];
            grid.DataBind();
            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();
        }
        catch (Exception ex)
        { }
    }
    protected void btnGridtoexcel1_Click(object sender, EventArgs e)
    {
        try
        {
            string userid = Session["MarketingUser"].ToString();
            DataSet ds = new DataSet();
            string attachment = "attachment; filename=MessageReport.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            HtmlForm frm = new HtmlForm();
            objMiscalreg.Userid = userid;
            ds = objMiscalreg.BALGetAllMessageReport(objMiscalreg);
            DataGrid grid = new DataGrid();
            grid.DataSource = ds.Tables[0];
            grid.DataBind();
            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

        }
        catch (Exception ex)
        { }
    }
    protected void gvViewGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvViewGroup.PageIndex = e.NewPageIndex;
        LoadViewSendGroupSMS();
    }

    #endregion oldCode

    //----------------------------------------Multi Miss Call  (Ketan Code)-----------------------------------------------------------

    #region MultiMissCall

    protected void btnSubmitMulti_Click(object sender, EventArgs e)
    {
        if (txtMultiText.Text.Contains("www.myct.in"))
        {
            string Id2 = Convert.ToString(lblIdMulti.Text.ToString());
            if (Id2 == "" || Id2 == null)
            {
                Insertmulti();
            }
            else
            {
                UpdateMulti(Id2);

            }
        }
        else
        {
            Response.Write("<script>(alert)('Plz add in message www.myct.in')</script>");
        }
    }
    private void Insertmulti()
    {
        try
        {
            int count = 0;
            string message = "";
            DateTime date = DateTime.Now;
            message = Convert.ToString(txtMultiText.Text);
            int messagecount = message.Length;
            string Group = ddlmultiGroup.SelectedItem.Text;
            if (messagecount <= 160)
            {
                count = 1;
            }
            else if (messagecount >= 160)
            {
                count = 2;
            }
            else if (messagecount >= 306)
            {
                count = 3;
            }
            else if (messagecount >= 459)
            {
                count = 4;
            }
            else if (messagecount >= 612)
            {
                count = 5;
            }
            else if (messagecount >= 765)
            {
                count = 6;
            }
            else if (messagecount >= 918)
            {
                count = 7;
            }
            else if (messagecount >= 1071)
            {
                count = 8;
            }
            else if (messagecount >= 1224)
            {
                count = 9;
            }
            else if (messagecount >= 1377)
            {
                count = 10;
            }
            else if (messagecount >= 1530)
            {
                count = 11;
            }
            string sql2 = "select Sim_no,reg_id from LongCodeRegistration where usrUserid='" + Convert.ToString(Session["MarketingUser"]) + "'";
            DataSet ds = cc.ExecuteDataset(sql2);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ddlMgsStatus.SelectedItem.Text == "--Select--")
                {
                    Response.Write("<script>(alert)('Plz Select Message Status..!')</script>");
                }
                else
                {
                    string sim = Convert.ToString(ds.Tables[0].Rows[0]["sim_no"]);
                    string LongCodeid = Convert.ToString(ds.Tables[0].Rows[0]["reg_id"]);

                    string sql1 = "update MiscalResponse set Msg_Status='Deactive' where userid='" + Convert.ToString(Session["MarketingUser"]) + "' and mobileno='" + sim + "' and GroupNo='" + Group + "'";
                    int b = cc.ExecuteNonQuery(sql1);
                    if (b >= 0)
                    {

                        string Msg_status = Convert.ToString(ddlMgsStatus.SelectedItem.Text);
                        string sql = "insert into MiscalResponse(userid,mobileno,ResponseMsg,MsgDate,Msg_Status,GroupNo,LongCodeId,MsgCharCount,msgcount)values('" + Convert.ToString(Session["MarketingUser"]) + "','" + sim + "','" + message + "','" + date + "','" + Msg_status + "','" + Group + "','" + LongCodeid + "','" + messagecount + "','" + count + "') ";
                        string a = cc.ExecuteScalar(sql);
                        ClearMulti();
                        gridShowMulti();
                        //Response.Write("<script>(alert)('Message Inserted Successfully')</script>");
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Inserted Successfully')", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void ClearMulti()
    {
        ddlmultiGroup.SelectedValue = "-1";
        txtCharCountMulti.Text = "";
        txtMultiText.Text = "www.myct.in";
        btnSubmitMulti.Text = "Submit";
        lblIdMulti.Text = "";
        ddlMgsStatus.SelectedValue = "-1";
    }
    private void UpdateMulti(string Id)
    {
        try
        {
            string userid = Session["MarketingUser"].ToString();
            string group = ddlmultiGroup.SelectedItem.Text;
            string MgsStatus = ddlMgsStatus.SelectedItem.Text;
            if (group == "--Select--")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select Group...!')", true);
            }
            else if (MgsStatus == "--Select--")
            {
                Response.Write("<script>(alert)('Plz Select Message Status..!')</script>");
            }
            else
            {
                //string sql1 = "update MiscalResponse set Msg_Status='Deactive' where userid='" + userid + "' and Msg_Status='Active'";
                //int aa1 = cc.ExecuteNonQuery(sql1);

                string sql = "update MiscalResponse set ResponseMsg='" + txtMultiText.Text + "', Msg_Status='" + MgsStatus + "' ,GroupNo=" + group + "  where userid='" + userid + "' and id='" + Id + "'";
                int fire = cc.ExecuteNonQuery(sql);

                ClearMulti();
                gridShowMulti();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Updated Successfully')", true);
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnCancelMulti_Click(object sender, EventArgs e)
    {

    }
    protected void gvItemMulti_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string userid = Session["MarketingUser"].ToString();
        string Id = Convert.ToString(e.CommandArgument);
        lblIdMulti.Text = Id;
        if (Convert.ToString(e.CommandName) == "Edit")
        {
            try
            {
                message.Visible = true;
                string sql1 = "select ResponseMsg ,GroupNo ,Msg_Status from [Come2myCityDB].[come2mycity].MiscalResponse where id='" + Id + "'";
                DataSet ds = cc.ExecuteDataset(sql1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtMultiText.Text = Convert.ToString(ds.Tables[0].Rows[0]["ResponseMsg"]);
                    ddlmultiGroup.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["GroupNo"]);
                    string MgsStatus = Convert.ToString(ds.Tables[0].Rows[0]["Msg_Status"]);
                    //txtMultiText.Enabled = false;
                    //txtCharCountMulti.Enabled = false;
                    btnSubmitMulti.Text = "Update";
                    if (MgsStatus == "Active")
                    {
                        ddlMgsStatus.SelectedValue = "0";
                    }
                    else if (MgsStatus == "Active")
                    {
                        ddlMgsStatus.SelectedValue = "1";
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        else if (Convert.ToString(e.CommandName) == "Deactive")
        {
            try
            {
                string sql = "update [Come2myCityDB].[come2mycity].MiscalResponse set Msg_Status='Deactive'  where userid='" + userid + "' and id='" + Id + "'";
                int fire = cc.ExecuteNonQuery(sql);
                if (fire == 1)
                {
                    gridShowMulti();
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Deactivited Successfully')", true);
                }
            }
            catch (Exception ex)
            { }
        }
    }
    private void gridShowMulti()
    {
        string userid = Session["MarketingUser"].ToString();
        string sql = "select * from [Come2myCityDB].[come2mycity].MiscalResponse where userid='" + userid + "' and Msg_Status='Active' order by id desc";
        DataSet ds = cc.ExecuteDataset(sql);
        gvItemMulti.DataSource = ds.Tables[0];
        gvItemMulti.DataBind();
    }
    protected void gvItemMulti_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    #endregion MultiMissCall

    //------------------------------------------- Emergency Message Single Misscall-------------------------------------------------------------------
    #region EmergencySingleMisscall

    public void Emgcy()
    {
        try
        {
            string Sql = "Select EmergencyMgs from MiscalResponse where userid='" + Convert.ToString(Session["MarketingUser"]) + "' and Msg_Status='Active'";
            string mgs = Convert.ToString(cc.ExecuteScalar(Sql));
            if (mgs == "" || mgs == null)
            {
                txtmgsEm.Text = "www.myct.in";
            }
            else
            {
                txtmgsEm.Text = mgs;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSubmitEm_Click(object sender, EventArgs e)
    {
        try
        {
            string emMgschk = Convert.ToString(txtmgsEm.Text);
            if (txtmgsEm.Text == "")
            {

            }
            else
            {
                if (emMgschk.Contains(" www.myct.in"))
                {
                    string Sql = "Update MiscalResponse set EmergencyMgs='" + Convert.ToString(txtmgsEm.Text) + "' where userid='" + Convert.ToString(Session["MarketingUser"]) + "' and Msg_Status='Active'";
                    int k = cc.ExecuteNonQuery(Sql);
                    if (k == 1)
                    {

                    }
                }
                else
                {
                    Response.Write("<script>alert('Please End the syntax of -- www.myct.in')</script>");
                }
            }
        }
        catch (Exception ex)
        { }
    }
    public void ClearSingleMissCallEm()
    {
        txtmgsEm.Text = "";
    }
    protected void btnDeleteEm_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Update MiscalResponse set EmergencyMgs='' where userid='" + Convert.ToString(Session["MarketingUser"]) + "' and Msg_Status='Active'";
            int k = cc.ExecuteNonQuery(Sql);
            if (k == 1)
            {
                Emgcy();
            }
        }
        catch (Exception ex)
        { }
    }

    #endregion EmergencySingleMisscall






    #region EmergencyMultipleMisscall

    public void Emgcymulti()
    {
        try
        {
            string Sql = "Select EmergencyMgs from MiscalResponse where userid='" + Convert.ToString(Session["MarketingUser"]) + "' and Msg_Status='Active'";
            string mgs = Convert.ToString(cc.ExecuteScalar(Sql));
            if (mgs == "" || mgs == null)
            {
                txtMgsMultiEm.Text = "www.myct.in";
            }
            else
            {
                txtMgsMultiEm.Text = mgs;
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnSubmitMultiEm_Click(object sender, EventArgs e)
    {
        try
        {
            string emMgschk = Convert.ToString(txtMgsMultiEm.Text);
            if (txtMgsMultiEm.Text == "")
            {

            }
            else
            {
                if (emMgschk.Contains(" www.myct.in"))
                {
                    string Sql = "Update MiscalResponse set EmergencyMgs='" + Convert.ToString(txtMgsMultiEm.Text) + "' where userid='" + Convert.ToString(Session["MarketingUser"]) + "' and Msg_Status='Active'";
                    int k = cc.ExecuteNonQuery(Sql);
                    if (k >= 1)
                    {
                        //ClearMultiMissCallEm();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Please End the syntax of -- www.myct.in')</script>");
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnDeleteMultiEm_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Update MiscalResponse set EmergencyMgs='' where userid='" + Convert.ToString(Session["MarketingUser"]) + "' and Msg_Status='Active'";
            int k = cc.ExecuteNonQuery(Sql);
            if (k >= 1)
            {
                Emgcymulti();
            }
        }
        catch (Exception ex)
        { }
    }

    public void ClearMultiMissCallEm()
    {
        txtMgsMultiEm.Text = "";
    }

    #endregion EmergencyMultipleMisscall


    protected void btnEmgsingle_Click(object sender, EventArgs e)
    {
        panelmiscall.Visible = true;
    }
    protected void acdLogin_DataBinding(object sender, EventArgs e)
    {

    }
    protected void btnEmg_Click(object sender, EventArgs e)
    {
        panel1.Visible = true;
    }

}

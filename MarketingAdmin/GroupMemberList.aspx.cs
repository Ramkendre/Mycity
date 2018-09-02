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
using System.Data.SqlClient;
using System.IO;

public partial class MarketingAdmin_GroupMemberList : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat = "";
    DataSet dsSend = null;

    AsciiSubPage asp = new AsciiSubPage();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Convert.ToString(System.DateTime.Now);
        string UserId = Convert.ToString(Session["MarketingUser"]);
        if (UserId == "7cd807ae-a6ce-4345-812c-a91c0f777e68")
        {

            if (!IsPostBack)
            {

                LoadData();
                LoadGrid();
                LoadDataReplay();
                LoadReplaySMSReport();

            }
            DateFormatStatus();
        }
        else
        {

        }
    }
    //--------------------------------------------------------- Date Format--------------------------------------------------------------------------

    public void DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 5; //add hours in time
        double m = 48; //add min in time
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy'-'MM'-'dd''");
    }

    //------------------------------------------------------Load Data on Page Load------------------------------------------------------------------

    #region LoadDataonPageLoad
    public void LoadData()
    {
        try
        {//(usrFirstName+space(1)+usrLastName)
            string Sql = "Select usrFirstName as FullName,usrMobileNo,ug.GroupId,GroupValueName,city,joindate from UserMaster um " +
                         "inner join UserGroup ug on um.usrUserId=ug.UserId inner join GroupValue gv on  ug.GroupId= gv.GroupValueId " +
                         "where  ug.GroupId=92";
            if (txtFromDate.Text != "" && txtTodate.Text != "")
            {
                Sql = Sql + " and joindate between '" + txtFromDate.Text + "' and '" + txtTodate.Text + "' ";
            }
            if (txtcity.Text != "")
            {
                Sql = Sql + " and city='" + txtcity.Text + "' ";
            }
            Sql = Sql + " order by joindate desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = ds.Tables[0];
                gvItem.DataBind();
            }
            txtGroupSMSMsg.Text = " www.myct.in";
            txtBjsMgs.Text = " www.myct.in";
            txtMgsReplay.Text = " www.myct.in";
        }
        catch (Exception ex)
        { }
    }
    public void LoadGrid()
    {
        try//" + Convert.ToString(Session["SchoolCode"]) + " and Message like 'TEA%' or Message like 'Tea%' '27180109801'
        {
            string Sql = "Select Distinct(shortcode),PK,Message,mobile,data,shortcode,FlagStatus  from " +
                          " come2mycity.test where Message like 'BJSE%' or Message like 'BJSS%' order by pk desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItemSms.DataSource = ds.Tables[0];
            gvItemSms.DataBind();

            foreach (GridViewRow row in gvItemSms.Rows)
            {
                string Data = row.Cells[4].Text.ToString();
                if (Data == "0")
                {
                    row.Cells[4].Text = "Correct";
                }
                else if (Data == "1")
                {
                    row.Cells[4].Text = "Incorrect";
                }
                else if (Data == "2")
                {
                    row.Cells[4].Text = "Updated";
                }
                else if (Data == "3")
                {
                    row.Cells[4].Text = "Pending";
                }
            }
            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[3].Text.ToString();
                string[] DateFormat1 = Data.Split(' ');
                Data = Convert.ToString(DateFormat1[0]);
                row.Cells[3].Text = Data;
            }
        }
        catch (Exception ex)
        {

        }

    }
    public void LoadDataReplay()
    {
        try
        {//(usrFirstName+space(1)+usrLastName)
            string Sql = "SELECT ID,setMessage,UserId,Totallen,Count1,EntryDate,Active FROM BJSSetMessage where UserId='" + Convert.ToString(Session["MarketingUser"]) + "' order by Id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvReplay.DataSource = ds.Tables[0];
                gvReplay.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    #endregion LoadDataonPageLoad

    //----------------------------------------------- Read Data to A Perticular Line GridView----------------------------------------------------

    protected void gvItemSms_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Push")
        {
            //btnSubmit.Text = "Update";
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            string Sql = "Select Message,mobile,shortcode,data,SendDate from come2mycity.test where PK='" + Id + "'";
            try
            {
                DataSet ds = cc.ExecuteDataset(Sql);
                txtMgs.Text = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                lblMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["mobile"]);
                lblDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["shortcode"]);

            }
            catch (Exception ex)
            { }
        }
    }


    protected void btnSendMessage_Click(object sender, EventArgs e)
    {

        string Sql = "Select (usrFirstName+space(1)+usrLastName) as FullName,usrMobileNo,ug.GroupId,GroupValueName,city,joindate from UserMaster um " +
                     "inner join UserGroup ug on um.usrUserId=ug.UserId inner join GroupValue gv on  ug.GroupId= gv.GroupValueId " +
                     "where  ug.GroupId=92";
        if (txtFromDate.Text != "" && txtTodate.Text != "")
        {
            Sql = Sql + " and joindate between '" + txtFromDate.Text + "' and '" + txtTodate.Text + "' ";
        }
        if (txtcity.Text != "")
        {
            Sql = Sql + " and city='" + txtcity.Text + "' ";
        }
        dsSend = cc.ExecuteDataset(Sql);
        if (dsSend.Tables[0].Rows.Count > 0)
        {
            string mob = "";
            string Mono = "";
            for (int i = 0; i < dsSend.Tables[0].Rows.Count; i++)
            {
                mob = Convert.ToString(dsSend.Tables[0].Rows[i]["usrMobileNo"]);
                Mono = Mono + "," + mob;
            }
            if (Mono == "" || Mono == null)
            { }
            else
            {
                string mgs = Convert.ToString(txtGroupSMSMsg.Text);
                PromotionalSMS(Mono, mgs);
            }
        }
    }

    //------------------------------------------------Send Promotional SMS-----------------------------------------------------------------------

    #region SendPromotionalSMS
    private void PromotionalSMS(string sendToMoNo, string mgsbjs)
    {

        string UserId = Convert.ToString(Session["MarketingUser"]);
        if (UserId == "7cd807ae-a6ce-4345-812c-a91c0f777e68")
        {
            int smslength;
            int smsBalCutCount = 0;
            string msgSndFrom = "9158887019";
            string usrIdSn = "7cd807ae-a6ce-4345-812c-a91c0f777e68";
            string paidBal = "select paidCount from userMaster where usrUserId='" + usrIdSn.ToString() + "'";
            int bal = Convert.ToInt32(cc.ExecuteScalar(paidBal));
            if (bal >= 1)
            {
                int txtSmsLength = sendToMoNo.Length;
                string[] sndMoNoCount = { };
                if (txtSmsLength > 10)
                {
                    sndMoNoCount = sendToMoNo.Split(',');
                    if (sndMoNoCount.Length > 1)
                    {

                    }
                    else
                    {
                        sndMoNoCount = sendToMoNo.Split('\n');
                    }
                }
                else
                {
                    sndMoNoCount = sendToMoNo.Split(',');
                }

                if (sndMoNoCount.Length <= bal)
                {
                    if (sndMoNoCount.Length != 0 && mgsbjs.Trim() != "")
                    {
                        string mess = mgsbjs;
                        int smsLength = mess.Length;

                        if (smsLength >= 0 && smsLength <= 160)
                        {
                            smsBalCutCount = sndMoNoCount.Length;
                        }
                        else if (smsLength >= 161 && smsLength <= 306)
                        {
                            smsBalCutCount = 2 * sndMoNoCount.Length;
                        }
                        else if (smsLength >= 307 && smsLength <= 459)
                        {
                            smsBalCutCount = 3 * sndMoNoCount.Length;

                        }
                        else if (smsLength >= 460 && smsLength <= 612)
                        {
                            smsBalCutCount = 4 * sndMoNoCount.Length;

                        }
                        else if (smsLength >= 613 && smsLength <= 765)
                        {
                            smsBalCutCount = 5 * sndMoNoCount.Length;
                        }
                        else if (smsLength >= 766 && smsLength <= 918)
                        {
                            smsBalCutCount = 6 * sndMoNoCount.Length;

                        }
                        else if (smsLength >= 919 && smsLength <= 1071)
                        {
                            smsBalCutCount = 7 * sndMoNoCount.Length;

                        }
                        else if (smsLength >= 1072 && smsLength <= 1224)
                        {
                            smsBalCutCount = 8 * sndMoNoCount.Length;
                        }
                        else if (smsLength >= 1225 && smsLength <= 1377)
                        {
                            smsBalCutCount = 9 * sndMoNoCount.Length;

                        }
                        else if (smsLength >= 1378 && smsLength <= 1530)
                        {
                            smsBalCutCount = 10 * sndMoNoCount.Length;
                        }
                        else { }

                        if (smsBalCutCount < bal && smsLength <= 1280)
                        {

                            string Message = "Dear Total " + sndMoNoCount.Length + " Promotional  message sent successfully www.myct.in ";
                            smslength = Message.Length;
                            cc.SendMessagePromotionalSMS("PromotionalSMS", msgSndFrom, Message, smslength);
                            string msgSnd = "", msgSndTo = "";
                            msgSnd = mgsbjs;
                            smslength = msgSnd.Length;


                            sendToMoNo = sendToMoNo.Replace("\n", string.Empty);
                            sendToMoNo = sendToMoNo.Replace("\t", string.Empty);

                            if (msgSnd.Contains(" www.myct.in"))
                            {
                                cc.SendMessageTraBulkPromotional(msgSndFrom, sendToMoNo, msgSnd, smslength);
                            }
                            //---------------------------Ketan Code-------------------------

                            string balance = Convert.ToString(bal - smsBalCutCount - 1);

                            string sqlCutBalQuery = "update userMaster set paidCount = " + balance + " where usrMobileNo='" + msgSndFrom.ToString() + "'";
                            int SmsSndSuccess = Convert.ToInt32(cc.ExecuteNonQuery(sqlCutBalQuery));
                            if (SmsSndSuccess > 0)
                            {
                                int TotalSmsCount = Convert.ToInt16(sndMoNoCount.Length);

                                string Sql = "Insert Into PromotionalSendSMSReport(SendFrom,SendTo,sentMessage,TotalSent,Totallength,TotalSms,Balance,EntryDate)" +
                                    " Values('" + msgSndFrom + "','" + sendToMoNo + "','" + msgSnd + "'," + TotalSmsCount + "," + smslength + "," + (smsBalCutCount + 1) + "," + balance + ",'" + DateFormat + "')";
                                int k = cc.ExecuteNonQuery(Sql);
                                if (k == 1)
                                {
                                    Response.Write("<script>alert('SMS send successfully.')</script>");
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('SMS send successfully.')", true);
                                    //ClearPaidSms();
                                    // string loginfrm = Session["Mobile"].ToString();
                                    Cancel();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    #endregion SendPromotionalSMS


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Select (usrFirstName+space(1)+usrLastName) as FullName,usrMobileNo,ug.GroupId,GroupValueName,city,joindate from UserMaster um " +
                         "inner join UserGroup ug on um.usrUserId=ug.UserId inner join GroupValue gv on  ug.GroupId= gv.GroupValueId " +
                         "where  ug.GroupId=92";
            if (txtFromDate.Text != "" && txtTodate.Text != "")
            {
                Sql = Sql + " and joindate between '" + txtFromDate.Text + "' and '" + txtTodate.Text + "' ";
            }
            if (txtcity.Text != "")
            {
                Sql = Sql + " and city='" + txtcity.Text + "' ";
            }
            dsSend = cc.ExecuteDataset(Sql);
            if (dsSend.Tables[0].Rows.Count > 0)
            {
                gvItem.DataSource = dsSend.Tables[0];
                gvItem.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }
    protected void btnsendCancel_Click(object sender, EventArgs e)
    {
        Cancel();
    }

    public void Cancel()
    {
        txtFromDate.Text = "";
        txtTodate.Text = "";
        txtcity.Text = "";
        txtGroupSMSMsg.Text = "www.myct.in";
    }

    // --------------------------------------------------------- Assign Paging to GridView-----------------------------------------------------------

    protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItem.PageIndex = e.NewPageIndex;
        LoadData();
    }

    protected void gvLongCodeReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemSms.PageIndex = e.NewPageIndex;
        LoadGrid();
    }

    //---------------------------------------------------Clear Data----------------------------------------------------------------------------------

    public void Clear()
    {
        txtMgs.Text = "";
        lblDate.Text = "";
        lblId.Text = "";
        lblMobileNo.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    //-------------------------------------------------------------- Send Data to Push To Student Table------------------------------------------------

    protected void btnPushMgs_Click(object sender, EventArgs e)
    {
        KeywordSyntax();
    }
    public void KeywordSyntax()
    {
        string ReceivedDate = Convert.ToString(lblDate.Text);
        if (ReceivedDate.Contains('/'))
        {
            string[] date = ReceivedDate.Split(' ');
            string[] dateformate = date[0].Split('/'); //7/24/2013 2:59:39 PM Send SMS format server

            ReceivedDate = dateformate[2] + "-" + dateformate[0] + "-" + dateformate[1];
        }
        string MobileNo = Convert.ToString(lblMobileNo.Text);
        string Syntax = Convert.ToString(txtMgs.Text.Trim());
        asp.BJSSBJSE(Syntax, MobileNo, ReceivedDate, "", "");

        if (!String.IsNullOrEmpty(lblId.Text))
        {
            string Sql = "Update come2mycity.test Set FlagStatus=2 where mobile='" + MobileNo + "' and PK='" + lblId.Text + "'";
            int k = cc.ExecuteNonQuery(Sql);
            if (k == 1)
            {
                Clear();
                LoadGrid();
            }
        }
    }


    //---------------------------------------------------------- Download to Excel-----------------------------------------------------------------
    //-----------------------------------Don't Delete This Function. It Is used to Excel Download File---------------------------------------------

    #region DownloadReport

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void btnDownLoadFormat_Click(object sender, EventArgs e)
    {
        try
        {
            //gvItem.AllowPaging = false;
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            //Response.ContentType = "application/vnd.xls";
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //gvItem.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();



            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BJSGroupReport.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvItem.AllowPaging = false;
            LoadData();
            //Change the Header Row back to white color

            gvItem.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();


            gvItemSms.AllowPaging = true;
        }
        catch (Exception ex)
        {
            // throw ex;
        }
        gvItem.AllowPaging = true;
    }
    protected void btndnload_Click(object sender, EventArgs e)
    {
        try
        {
            //gvItemSms.AllowPaging = false;
            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            //Response.ContentType = "application/vnd.xls";
            //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //gvItemSms.RenderControl(htmlWrite);
            //Response.Write(stringWrite.ToString());
            //Response.End();

            //gvItemSms.AllowPaging = false;
            //Response.ClearContent();
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("Content-Disposition", "attachment; filename= Attendance" + "_" + DateTime.Today.ToShortDateString() + ".xls");
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //System.IO.StringWriter tw = new StringWriter(sb);
            //System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(tw);

            ////gvItemsave
            //gvItemSms.RenderControl(hw);
            //Response.Write(sb);

            //Response.End();
            //gvItem.RenderControl(hw);
            //Response.Write(sb);
            //Response.End();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BJSSMSReport.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvItemSms.AllowPaging = false;
            LoadGrid();
            //Change the Header Row back to white color

            gvItemSms.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();


            gvItemSms.AllowPaging = true;
        }
        catch (Exception ex)
        {
            // throw ex;
        }
        //gvItemSms.AllowPaging = true;

    }

    #endregion DownloadReport


    #region SendmessageId
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = " Select Distinct(shortcode),PK,Message,mobile  from " +
                            "come2mycity.test where ( pk between " + txtIdTo.Text + " and " + txtIdFrom.Text + " )and " +
                            "(Message like 'BJSE%' or Message like 'BJSS%') order by pk desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string mob = "";
                string Mono = "";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    mob = Convert.ToString(ds.Tables[0].Rows[i]["mobile"]);
                    Mono = Mono + "," + mob;
                }
                if (Mono == "" || Mono == null)
                { }
                else
                {
                    string mgs = Convert.ToString(txtBjsMgs.Text);
                    PromotionalSMS(Mono, mgs);
                }
                ClearBjs();
            }

        }
        catch (Exception ex)
        { }
    }
    protected void btnCancelmgs_Click(object sender, EventArgs e)
    {
        ClearBjs();
    }
    public void ClearBjs()
    {
        txtIdTo.Text = "";

        txtIdFrom.Text = "";
        txtBjsMgs.Text = " www.myct.in";
    }

    //protected void txtIdFrom_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string Sql = " Select Distinct(shortcode),PK,Message,mobile  from " +
    //                        "come2mycity.test where ( pk between " + txtIdTo.Text + " and " + txtIdFrom.Text + " )and " +
    //                        "(Message like 'BJSE%' or Message like 'BJSS%') order by pk desc";
    //        DataSet ds = cc.ExecuteDataset(Sql);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            GridView1.DataSource = ds.Tables[0];
    //            GridView1.DataBind();
    //        }

    //    }
    //    catch (Exception ex)
    //    { }
    //}

    protected void btnSearchId_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = " Select Distinct(shortcode),PK,Message,mobile  from " +
                            "come2mycity.test where ( pk between " + txtIdTo.Text + " and " + txtIdFrom.Text + " )and " +
                            "(Message like 'BJSE%' or Message like 'BJSS%') order by pk desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }

        }
        catch (Exception ex)
        { }
    }

    #endregion SendmessageId

    //------------------------------------Send Replay Messages-----------------------------------------------------------------------------

    #region SendReplayBJS
    protected void btnSubmitReplay_Click(object sender, EventArgs e)
    {
        try
        {
            string mess = Convert.ToString(txtMgsReplay.Text);
            int smsLength = mess.Length;
            int smsBalCutCount = 0;
            if (smsLength >= 0 && smsLength <= 160)
            {
                smsBalCutCount = 1;
            }
            else if (smsLength >= 161 && smsLength <= 306)
            {
                smsBalCutCount = 2;
            }
            else if (smsLength >= 307 && smsLength <= 459)
            {
                smsBalCutCount = 3;

            }
            else if (smsLength >= 460 && smsLength <= 612)
            {
                smsBalCutCount = 4;

            }
            else if (smsLength >= 613 && smsLength <= 765)
            {
                smsBalCutCount = 5;
            }
            else if (smsLength >= 766 && smsLength <= 918)
            {
                smsBalCutCount = 6;

            }
            else if (smsLength >= 919 && smsLength <= 1071)
            {
                smsBalCutCount = 7;

            }
            else if (smsLength >= 1072 && smsLength <= 1224)
            {
                smsBalCutCount = 8;
            }
            else if (smsLength >= 1225 && smsLength <= 1377)
            {
                smsBalCutCount = 9;

            }
            else if (smsLength >= 1378 && smsLength <= 1530)
            {
                smsBalCutCount = 10;
            }
            else { }


            string UserId = Convert.ToString(Session["MarketingUser"]);
            if (UserId == "7cd807ae-a6ce-4345-812c-a91c0f777e68")
            {
                string Sqlchk = "Select Id from BJSSetMessage where Active=1";
                string mgsId = Convert.ToString(cc.ExecuteScalar(Sqlchk));
                if (!String.IsNullOrEmpty(mgsId))
                {
                    string UpdateActive = "Update BJSSetMessage set Active=0 where Id=" + mgsId + "";
                    int j = cc.ExecuteNonQuery(UpdateActive);
                    if (j == 1)
                    {
                        string Sql = "  Insert into BJSSetMessage(setMessage,UserId,Totallen,Count1,EntryDate,Active) " +
                                 "  values('" + mess + "', '" + UserId + "'," + smsLength + "," + smsBalCutCount + ",'" + DateFormat + "',1)";
                        int k = cc.ExecuteNonQuery(Sql);
                        if (k == 1)
                        {
                            LoadDataReplay();
                        }
                    }
                    else
                    {
                        string Sql = "  Insert into BJSSetMessage(setMessage,UserId,Totallen,Count1,EntryDate,Active) " +
                                     "  values('" + mess + "', '" + UserId + "'," + smsLength + "," + smsBalCutCount + ",'" + DateFormat + "',1)";
                        int k = cc.ExecuteNonQuery(Sql);
                        if (k == 1)
                        {
                            LoadDataReplay();
                        }
                    }
                }
                else
                {
                    string Sql = "  Insert into BJSSetMessage(setMessage,UserId,Totallen,Count1,EntryDate,Active) " +
                             "  values('" + mess + "', '" + UserId + "'," + smsLength + "," + smsBalCutCount + ",'" + DateFormat + "',1)";
                    int k = cc.ExecuteNonQuery(Sql);
                    if (k == 1)
                    {
                        LoadDataReplay();
                    }
                }
            }


            txtMgsReplay.Text = " www.myct.in";

        }
        catch (Exception ex)
        { }
    }


    protected void btnCancelReplay_Click(object sender, EventArgs e)
    {
        try
        {
            txtMgsReplay.Text = " www.myct.in";
        }
        catch (Exception ex)
        { }
    }
    protected void gvReplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReplay.PageIndex = e.NewPageIndex;
        LoadDataReplay();
    }

    #endregion SendReplayBJS

    //--------------------------------------Send Auto repaly SMS------------------------------------------------------------------------------

    #region SendAutoreplaySMS
    public void LoadReplaySMSReport()
    {
        try
        {
            string Sql = "SELECT ID, SendFrom,SendTo,sentMessage,EntryDate,Count1,MsgId FROM BJSSendSMSReport order by ID desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvReportRelpay.DataSource=ds.Tables[0];
                gvReportRelpay.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void gvReportRelpay_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvReportRelpay.PageIndex = e.NewPageIndex;
        LoadReplaySMSReport();
    }
    #endregion SendAutoreplaySMS

    
}

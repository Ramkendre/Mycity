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

using System.Net.Mail;

public partial class MarketingAdmin_StormReport : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["schoolconnectionstring"]);

    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //LoadGrid();

            //gvItem.DataSource = this.LoadGrid();
            //gvItem.DataBind();
        }
    }

    protected void lnkEO_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        //LoadGrid();
    }
    protected void txtDateCH_TextChanged(object sender, EventArgs e)
    {
        CHReport();
    }
    protected void txtDateBEO_TextChanged(object sender, EventArgs e)
    {
        BEOReport();
    }
    protected void lnkBEO_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        
    }
    protected void lnkExT_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View3);
       
    }
    protected void lnkCH_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View4);
        
    }
    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {
        //MultiView1.ActiveViewChanged = -1;
    }

    public void LoadGrid()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        DataTable dt = new DataTable();
        if (txtDate.Text == "")
        {
            //SqlCommand cmd = new SqlCommand("select [BlockCode],[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount],(sum(convert(int,[AbsentGirlsCount]) + convert(int,[AbsentBoysCount]))) as [TotalAbsentStudCount],[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblBEORepot] where date='" + str + "' group by [BlockCode],[Date],[BlockCode],[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount]");
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Connection = con;
            //con.Open();
            //da.Fill(ds);
            ////for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            ////{
            ////    string bc = ds.Tables[0].Rows[i]["BlockCode"].ToString();
            ////    string t = "select [CityName] FROM [DBeZeeSchool].[dbo].[CityMaster] where CID='"+bc+"'";
            ////    DataSet ds1 = cc.ExecuteDataset(t);
            ////}
            
            //dt.Columns.Add("BlockCode",typeof(string));
            //dt.Columns.Add("ToatalStaff", typeof(string));
            //dt.Columns.Add("TotalPresentStaff", typeof(string));
            
            //dt.Columns.Add("TotalStudent", typeof(string));
            //dt.Columns.Add("TotalPresentStudCount", typeof(string));
            //dt.Columns.Add("TotalAbsentStudCount", typeof(string));
            //dt.Columns.Add("TotalAbsentStudCount", typeof(string));
            //dt.Columns.Add("TotalAbsentStudCount", typeof(string));
            //dt.Columns.Add("TotalAbsentStudCount", typeof(string));
            //dt.Columns.Add("TotalAbsentStudCount", typeof(string));
            //dt.Columns.Add("TotalAbsentStudCount", typeof(string));
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    string bc = ds.Tables[0].Rows[i]["BlockCode"].ToString();
            //    string t = "select [CityName] FROM [DBeZeeSchool].[dbo].[CityMaster] where CID='" + bc + "'";
            //    DataSet ds1 = cc.ExecuteDataset(t);
            //    dt.Rows.Add(ds1.Tables[0].Rows[i][0],ds.Tables[0].Rows[i][1],ds.Tables[0].Rows[i][2],ds.Tables[0].Rows[i][3],ds.Tables[0].Rows[i][4],ds.Tables[0].Rows[i][5]);

            //}
            string str =
                 " with Storm as( " +
                 " select [CityName],[ToatalStaff],NotReportedStaff,TotalSchool,[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],TotalAbsentStudent,[AbsentBoysCount],Date,[AbsentGirlsCount],[TotalAbsentStaff],[halfDayleave],[earnedleave],[maternityleave],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from( " +
                 " (select [BlockCode] as b,TotalSchool,NotReportedStaff,[ToatalStaff],[TotalPresentStaff],TotalAbsentStudent,[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount],[TotalAbsentStaff],Date,[halfDayleave],[earnedleave],[maternityleave],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblBEORepot] where  [Date]='" + str1 + "' ) as t1" +
                 " inner join " +
                 " [DBeZeeSchool].[dbo].[CityMaster] as t2 " +
                 " on " +
                 " t1.b=t2.CID " +
                   " ) " +
                 " ) ";
            str += "select [CityName],TotalSchool,NotReportedStaff,[TotalReportedSchool],[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[halfDayleave],[earnedleave],[maternityleave],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from Storm";
            SqlCommand cmd = new SqlCommand(str);
            cmd.CommandTimeout = 1;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        else
        {
            //SqlCommand cmd = new SqlCommand("select [BlockCode],[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount],(sum(convert(int,[AbsentGirlsCount]) + convert(int,[AbsentBoysCount]))) as [TotalAbsentStudCount],[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblBEORepot] where date='" + txtDate.Text + "' group by [BlockCode],[Date],[BlockCode],[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount]");
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //cmd.Connection = con;
            //con.Open();
            //da.Fill(ds);
            ////for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            ////{
            ////    string bc = ds.Tables[0].Rows[i]["BlockCode"].ToString();
            ////    string t = "select [CityName] FROM [DBeZeeSchool].[dbo].[CityMaster] where CID='"+bc+"'";
            ////    DataSet ds1 = cc.ExecuteDataset(t);
            ////}
            
            //dt.Columns.Add("BlockCode", typeof(string));
            //dt.Columns.Add("ToatalStaff", typeof(string));
            //dt.Columns.Add("TotalPresentStaff", typeof(string));

            //dt.Columns.Add("TotalStudent", typeof(string));
            //dt.Columns.Add("TotalPresentStudCount", typeof(string));
            //dt.Columns.Add("TotalAbsentStudCount", typeof(string));

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    string bc = ds.Tables[0].Rows[i]["BlockCode"].ToString();
            //    string t = "select [CityName] FROM [DBeZeeSchool].[dbo].[CityMaster] where CID='" + bc + "'";
            //    DataSet ds1 = cc.ExecuteDataset(t);
            //    dt.Rows.Add(ds1.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5]);

            //}
            
            string str =
                " with Storm as( " +
                " select [CityName],TotalSchool,NotReportedStaff,[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],TotalAbsentStudent,[AbsentBoysCount],Date,[AbsentGirlsCount],[TotalAbsentStaff],[halfDayleave],[earnedleave],[maternityleave],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from( " +
                " (select [BlockCode] as b,TotalSchool,NotReportedStaff,[ToatalStaff],[TotalPresentStaff],TotalAbsentStudent,[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount],[TotalAbsentStaff],Date,[halfDayleave],[earnedleave],[maternityleave],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblBEORepot] where  [Date]='" + txtDate.Text + "' ) as t1" +
                " inner join " +
                " [DBeZeeSchool].[dbo].[CityMaster] as t2 " +
                " on " +
                " t1.b=t2.CID " +
                  " ) " +
                " ) ";
            str += "select [CityName],TotalSchool,NotReportedStaff,[TotalReportedSchool],[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[halfDayleave],[earnedleave],[maternityleave],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from Storm";
            SqlCommand cmd = new SqlCommand(str);
           
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
               
                cmd.Connection.Open();
            da.Fill(ds);
            //dt = ds.Tables[0];
            //da.Fill(dt);
            //return dt;
        }
        //return dt;
        gvItem.DataSource = ds.Tables[0];
        gvItem.DataBind();
    
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        LoadGrid();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvItem.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            //Get the GridView Data from database.
            //DataTable dt = LoadGrid();

            ////Set DataTable Name which will be the name of Excel Sheet.
            //dt.TableName = "GridView_Data";

            ////Create a New Workbook.
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    //Add the DataTable as Excel Worksheet.
            //    wb.Worksheets.Add(dt);

            //    using (MemoryStream memoryStream = new MemoryStream())
            //    {
            //        //Save the Excel Workbook to MemoryStream.
            //        wb.SaveAs(memoryStream);

            //        //Convert MemoryStream to Byte array.
            //        byte[] bytes = memoryStream.ToArray();
            //        memoryStream.Close();

            //        //Send Email with Excel attachment.
            //        using (MailMessage mm = new MailMessage("ezeesoftindia@gmail.com", "ezeesoftindia@gmail.com"))
            //        {
            //            mm.Subject = "GridView Exported Excel";
            //            mm.Body = "GridView Exported Excel Attachment";

            //            //Add Byte array as Attachment.
            //            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "GridView.xlsx"));
            //            mm.IsBodyHtml = true;
            //            SmtpClient smtp = new SmtpClient();
            //            smtp.Host = "smtp.gmail.com";
            //            smtp.EnableSsl = true;
            //            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
            //            credentials.UserName = "ezeesoftindia@gmail.com";
            //            credentials.Password = "abhi_chk";
            //            smtp.UseDefaultCredentials = true;
            //            smtp.Credentials = credentials;
            //            smtp.Port = 587;
            //            smtp.Send(mm);
            //        }
            //    }
            //}
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
   
    #region Sum
    //public void CalSum()
    //{
    //    DataTable dt = new DataTable();
    //    SqlCommand cmd = new SqlCommand();
    //    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    //    cmd.Connection = con;

    //    cmd.CommandText = "select [BlockCode],[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount],(sum(convert(int,[AbsentGirlsCount]) + convert(int,[AbsentBoysCount]))) as [TotalAbsentStudCount] from [DBeZeeSchool].[dbo].[tblBEORepot] where date='" + str + "' group by [BlockCode],[Date],[BlockCode],[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount]";

    //    if (cmd.Connection.State == ConnectionState.Closed)
    //        cmd.Connection.Open();
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    da.SelectCommand = cmd;
    //    da.Fill(dt);


    //    int sum = 0;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        foreach (DataColumn dc in dt.Columns)
    //        {
    //            sum += Convert.ToInt16(dr[dc]);
    //        }
    //    }


    //}
    #endregion
    int total = 0;
    int total0 = 0;
    int total1 = 0;
    int total2 = 0;
    int total3 = 0;
    int total4 = 0;
    int total5 = 0;
    int total6 = 0;
    int total7 = 0;
    int total8 = 0;
    int total9 = 0;
    int total10 = 0;
    int total01 = 0;
    int total00 = 0;
    int total11 = 0;
    int total12 = 0;
    int total13 = 0;
    int total14 = 0;
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqy = (Label)e.Row.FindControl("lblTotal");
            int qty = Int32.Parse(lblqy.Text);
            total = total + qty;

            Label lblqyTotalSchool = (Label)e.Row.FindControl("lblTotalSchool");
            int qtyTS = Int32.Parse(lblqyTotalSchool.Text);
            total00 = total00 + qtyTS;

            Label lblqyTotalReportedSchool = (Label)e.Row.FindControl("lblTotalReportedSchool");
            int qtySR = Int32.Parse(lblqyTotalReportedSchool.Text);
            total01 = total01 + qtySR;

            Label lblqyToatalStaff = (Label)e.Row.FindControl("lblToatalStaff");
            int qtyS = Int32.Parse(lblqyToatalStaff.Text);
            total0 = total0 + qtyS;

            Label lblqyStud = (Label)e.Row.FindControl("lblTotalStud");
            int qtyStud = Int32.Parse(lblqyStud.Text);
            total1 = total1 + qtyStud;

            Label lblqyStudPC = (Label)e.Row.FindControl("lblTotalPStudCount");
            int qtyStudPC = Int32.Parse(lblqyStudPC.Text);
            total2 = total2 + qtyStudPC;

            Label lblqyStydAC = (Label)e.Row.FindControl("lblTotalAbsentStudent");
            int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            total3 = total3 + qtystudAC;

            Label lblqyAbsentStaff = (Label)e.Row.FindControl("lblTotalAbsentStaff");
            int qtyAbsentStaff = Int32.Parse(lblqyAbsentStaff.Text);
            total4 = total4 + qtyAbsentStaff;

            Label lblqyOnCLStaff = (Label)e.Row.FindControl("lblOnCLStaff");
            int qtyOnCLStaff = Int32.Parse(lblqyOnCLStaff.Text);
            total5 = total5 + qtyOnCLStaff;

            Label lblqyOnmedicalLeave = (Label)e.Row.FindControl("lblOnmedicalLeave");
            int qtyOnmedicalLeave = Int32.Parse(lblqyOnmedicalLeave.Text);
            total6 = total6 + qtyOnmedicalLeave;

            Label lblOutdoorOnOfficeleave = (Label)e.Row.FindControl("lblOutdoorOnOfficeleave");
            int qtyOutdoorOnOfficeleave = Int32.Parse(lblOutdoorOnOfficeleave.Text);
            total7 = total7 + qtyOutdoorOnOfficeleave;

            Label lblqyOntraining = (Label)e.Row.FindControl("lblOntraining");
            int qtyOntraining = Int32.Parse(lblqyOntraining.Text);
            total8 = total8 + qtyOntraining;

            Label lblqyAbsentWithoutNotice = (Label)e.Row.FindControl("lblAbsentWithoutNotice");
            int qtyAbsentWithoutNotice = Int32.Parse(lblqyAbsentWithoutNotice.Text);
            total9 = total9 + qtyAbsentWithoutNotice;

            Label lblqyLateAttendance = (Label)e.Row.FindControl("lblLateAttendance");
            int qtyLateAttendance = Int32.Parse(lblqyLateAttendance.Text);
            total10 = total10 + qtyLateAttendance;

            Label lblqyhalfDayleave = (Label)e.Row.FindControl("lblhalfDayleave");
            int qtyHD = Int32.Parse(lblqyhalfDayleave.Text);
            total11 = total11 + qtyHD;

            Label lblqyearnedleave = (Label)e.Row.FindControl("lblearnedleave");
            int qtyEL = Int32.Parse(lblqyearnedleave.Text);
            total12 = total12 + qtyEL;

            Label lblqylblmaternityleave = (Label)e.Row.FindControl("lblmaternityleave");
            int qtySR1 = Int32.Parse(lblqylblmaternityleave.Text);
            total13 = total13 + qtySR1;

            Label lblqylblNotReportedStaff = (Label)e.Row.FindControl("lblNotReportedStaff");
            int qtySR2 = Int32.Parse(lblqylblNotReportedStaff.Text);
            total14 = total14 + qtySR2;

        }
        if(e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAll = (Label)e.Row.FindControl("lblTotalAll");
            lblTotalAll.Text = total.ToString();

            Label lblTotalAllTS = (Label)e.Row.FindControl("lblAllTotalSchool");
            lblTotalAllTS.Text = total00.ToString();


            Label lblTotalAllTRS = (Label)e.Row.FindControl("lblAllTotalReportedSchool");
            lblTotalAllTRS.Text = total01.ToString();


            Label lblTotalAllS = (Label)e.Row.FindControl("lblAllToatalStaff");
            lblTotalAllS.Text = total0.ToString();

            Label lblTotalAllStud = (Label)e.Row.FindControl("lblTotalAllStud");
            lblTotalAllStud.Text = total1.ToString();

            Label lblTotalStudPCAll = (Label)e.Row.FindControl("lblTotalpAllStudC");
            lblTotalStudPCAll.Text = total2.ToString();

            //Label lblqyStydAC = (Label)e.Row.FindControl("lblAllTotalAbsentStudent");
            //int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            //total3 = total3 + qtystudAC;

            Label lblTotalStudAAll = (Label)e.Row.FindControl("lblAllTotalAbsentStudent");
            lblTotalStudAAll.Text = total3.ToString();


            Label lblTotalStudACAll = (Label)e.Row.FindControl("lblAllTotalAbsentStaff");
            lblTotalStudACAll.Text = total4.ToString();

            Label lblOnCLStaffAll = (Label)e.Row.FindControl("lblAllOnCLStaff");
            lblOnCLStaffAll.Text = total5.ToString();

            Label lblOnmedicalLeaveAll = (Label)e.Row.FindControl("lblAllOnmedicalLeave");
            lblOnmedicalLeaveAll.Text = total6.ToString();

            Label lblOutdoorOnOfficeleaveAll = (Label)e.Row.FindControl("lblAllOutdoorOnOfficeleave");
            lblOutdoorOnOfficeleaveAll.Text = total7.ToString();

            Label lblOntrainingAll = (Label)e.Row.FindControl("lblAllOntraining");
            lblOntrainingAll.Text = total8.ToString();

            Label lblAbsentWithoutNoticeAll = (Label)e.Row.FindControl("lblAllAbsentWithoutNotice");
            lblAbsentWithoutNoticeAll.Text = total9.ToString();

            Label lblLateAttendanceAll = (Label)e.Row.FindControl("lblAllLateAttendance");
            lblLateAttendanceAll.Text = total10.ToString();

            //Label lblTotalStudACAll = (Label)e.Row.FindControl("lblTotalAAllStudC");
            //lblTotalStudACAll.Text = total3.ToString();

            Label lblAllhalfDayleaveAll = (Label)e.Row.FindControl("lblAllhalfDayleave");
            lblAllhalfDayleaveAll.Text = total11.ToString();

            Label lblAllearnedleaveAll = (Label)e.Row.FindControl("lblAllearnedleave");
            lblAllearnedleaveAll.Text = total12.ToString();

            Label lblAllmaternityleaveAll = (Label)e.Row.FindControl("lblAllmaternityleave");
            lblAllmaternityleaveAll.Text = total13.ToString();

            Label lblAllNotReportedStaffAll = (Label)e.Row.FindControl("lblAllNotReportedStaff");
            lblAllNotReportedStaffAll.Text = total14.ToString();

        }
    }


    #region BEOReport
    public void BEOReport()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        if(txtDateBEO.Text=="")
        {

            string str = "select [EXTOMobNo],[TotalSchool],[TotalReportedSchool],[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblEXTOReport] where  [Date]='" + str1 + "'";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        else
        {
            string str = "select [EXTOMobNo],[TotalSchool],[TotalReportedSchool],[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblEXTOReport] where  [Date]='" + txtDateBEO.Text + "'";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        gvItemBEO.DataSource = ds.Tables[0];
        gvItemBEO.DataBind();
        ds.Clear();
    }
    #endregion

    protected void btnExportToExcelBEO_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvItemBEO.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //int total = 0;
    //int total0 = 0;
    //int total1 = 0;
    //int total2 = 0;
    //int total3 = 0;
    //int total4 = 0;
    //int total5 = 0;
    //int total6 = 0;
    //int total7 = 0;
    //int total8 = 0;
    //int total9 = 0;
    //int total10 = 0;
    protected void gvItemBEO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqy = (Label)e.Row.FindControl("lblTotal");
            int qty = Int32.Parse(lblqy.Text);
            total = total + qty;

            Label lblqyToatalStaff = (Label)e.Row.FindControl("lblToatalStaff");
            int qtyS = Int32.Parse(lblqyToatalStaff.Text);
            total0 = total0 + qtyS;

            Label lblqyStud = (Label)e.Row.FindControl("lblTotalStud");
            int qtyStud = Int32.Parse(lblqyStud.Text);
            total1 = total1 + qtyStud;

            Label lblqyStudPC = (Label)e.Row.FindControl("lblTotalPStudCount");
            int qtyStudPC = Int32.Parse(lblqyStudPC.Text);
            total2 = total2 + qtyStudPC;

            Label lblqyStydAC = (Label)e.Row.FindControl("lblTotalAbsentStudent");
            int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            total3 = total3 + qtystudAC;

            Label lblqyAbsentStaff = (Label)e.Row.FindControl("lblTotalAbsentStaff");
            int qtyAbsentStaff = Int32.Parse(lblqyAbsentStaff.Text);
            total4 = total4 + qtyAbsentStaff;

            Label lblqyOnCLStaff = (Label)e.Row.FindControl("lblOnCLStaff");
            int qtyOnCLStaff = Int32.Parse(lblqyOnCLStaff.Text);
            total5 = total5 + qtyOnCLStaff;

            Label lblqyOnmedicalLeave = (Label)e.Row.FindControl("lblOnmedicalLeave");
            int qtyOnmedicalLeave = Int32.Parse(lblqyOnmedicalLeave.Text);
            total6 = total6 + qtyOnmedicalLeave;

            Label lblOutdoorOnOfficeleave = (Label)e.Row.FindControl("lblOutdoorOnOfficeleave");
            int qtyOutdoorOnOfficeleave = Int32.Parse(lblOutdoorOnOfficeleave.Text);
            total7 = total7 + qtyOutdoorOnOfficeleave;

            Label lblqyOntraining = (Label)e.Row.FindControl("lblOntraining");
            int qtyOntraining = Int32.Parse(lblqyOntraining.Text);
            total8 = total8 + qtyOntraining;

            Label lblqyAbsentWithoutNotice = (Label)e.Row.FindControl("lblAbsentWithoutNotice");
            int qtyAbsentWithoutNotice = Int32.Parse(lblqyAbsentWithoutNotice.Text);
            total9 = total9 + qtyAbsentWithoutNotice;

            Label lblqyLateAttendance = (Label)e.Row.FindControl("lblLateAttendance");
            int qtyLateAttendance = Int32.Parse(lblqyLateAttendance.Text);
            total10 = total10 + qtyLateAttendance;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAll = (Label)e.Row.FindControl("lblTotalAll");
            lblTotalAll.Text = total.ToString();

            Label lblTotalAllS = (Label)e.Row.FindControl("lblAllToatalStaff");
            lblTotalAllS.Text = total0.ToString();

            Label lblTotalAllStud = (Label)e.Row.FindControl("lblTotalAllStud");
            lblTotalAllStud.Text = total1.ToString();

            Label lblTotalStudPCAll = (Label)e.Row.FindControl("lblTotalpAllStudC");
            lblTotalStudPCAll.Text = total2.ToString();

            //Label lblqyStydAC = (Label)e.Row.FindControl("lblAllTotalAbsentStudent");
            //int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            //total3 = total3 + qtystudAC;

            Label lblTotalStudACAll = (Label)e.Row.FindControl("lblAllTotalAbsentStaff");
            lblTotalStudACAll.Text = total4.ToString();

            Label lblOnCLStaffAll = (Label)e.Row.FindControl("lblAllOnCLStaff");
            lblOnCLStaffAll.Text = total5.ToString();

            Label lblOnmedicalLeaveAll = (Label)e.Row.FindControl("lblAllOnmedicalLeave");
            lblOnmedicalLeaveAll.Text = total6.ToString();

            Label lblOutdoorOnOfficeleaveAll = (Label)e.Row.FindControl("lblAllOutdoorOnOfficeleave");
            lblOutdoorOnOfficeleaveAll.Text = total7.ToString();

            Label lblOntrainingAll = (Label)e.Row.FindControl("lblAllOntraining");
            lblOntrainingAll.Text = total8.ToString();

            Label lblAbsentWithoutNoticeAll = (Label)e.Row.FindControl("lblAllAbsentWithoutNotice");
            lblAbsentWithoutNoticeAll.Text = total9.ToString();

            Label lblLateAttendanceAll = (Label)e.Row.FindControl("lblAllLateAttendance");
            lblLateAttendanceAll.Text = total10.ToString();

            //Label lblTotalStudACAll = (Label)e.Row.FindControl("lblTotalAAllStudC");
            //lblTotalStudACAll.Text = total3.ToString();
        }
    }
  

    #region EXTOReport
    public void EXTOReport()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        if (txtDateEXTO.Text == "")
        {
            string str = "select [CHMobNo],[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblClusterHeadReport] where  [Date]='" + str1+ "' ";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        else
        {
            string str = "select [CHMobNo],[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblClusterHeadReport] where  [Date]='" + txtDateEXTO.Text + "' ";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        gvItemEXTO.DataSource = ds.Tables[0];
        gvItemEXTO.DataBind();
        ds.Clear();
    }
    protected void txtDateEXTO_TextChanged(object sender, EventArgs e)
    {
        EXTOReport();
    }
    protected void btnExportToExcelEXTO_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvItemEXTO.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //int total = 0;
    //int total0 = 0;
    //int total1 = 0;
    //int total2 = 0;
    //int total3 = 0;
    //int total4 = 0;
    //int total5 = 0;
    //int total6 = 0;
    //int total7 = 0;
    //int total8 = 0;
    //int total9 = 0;
    //int total10 = 0;
    protected void gvItemEXTO_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqy = (Label)e.Row.FindControl("lblTotal");
            int qty = Int32.Parse(lblqy.Text);
            total = total + qty;

            Label lblqyToatalStaff = (Label)e.Row.FindControl("lblToatalStaff");
            int qtyS = Int32.Parse(lblqyToatalStaff.Text);
            total0 = total0 + qtyS;

            Label lblqyStud = (Label)e.Row.FindControl("lblTotalStud");
            int qtyStud = Int32.Parse(lblqyStud.Text);
            total1 = total1 + qtyStud;

            Label lblqyStudPC = (Label)e.Row.FindControl("lblTotalPStudCount");
            int qtyStudPC = Int32.Parse(lblqyStudPC.Text);
            total2 = total2 + qtyStudPC;

            Label lblqyStydAC = (Label)e.Row.FindControl("lblTotalAbsentStudent");
            int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            total3 = total3 + qtystudAC;

            Label lblqyAbsentStaff = (Label)e.Row.FindControl("lblTotalAbsentStaff");
            int qtyAbsentStaff = Int32.Parse(lblqyAbsentStaff.Text);
            total4 = total4 + qtyAbsentStaff;

            Label lblqyOnCLStaff = (Label)e.Row.FindControl("lblOnCLStaff");
            int qtyOnCLStaff = Int32.Parse(lblqyOnCLStaff.Text);
            total5 = total5 + qtyOnCLStaff;

            Label lblqyOnmedicalLeave = (Label)e.Row.FindControl("lblOnmedicalLeave");
            int qtyOnmedicalLeave = Int32.Parse(lblqyOnmedicalLeave.Text);
            total6 = total6 + qtyOnmedicalLeave;

            Label lblOutdoorOnOfficeleave = (Label)e.Row.FindControl("lblOutdoorOnOfficeleave");
            int qtyOutdoorOnOfficeleave = Int32.Parse(lblOutdoorOnOfficeleave.Text);
            total7 = total7 + qtyOutdoorOnOfficeleave;

            Label lblqyOntraining = (Label)e.Row.FindControl("lblOntraining");
            int qtyOntraining = Int32.Parse(lblqyOntraining.Text);
            total8 = total8 + qtyOntraining;

            Label lblqyAbsentWithoutNotice = (Label)e.Row.FindControl("lblAbsentWithoutNotice");
            int qtyAbsentWithoutNotice = Int32.Parse(lblqyAbsentWithoutNotice.Text);
            total9 = total9 + qtyAbsentWithoutNotice;

            Label lblqyLateAttendance = (Label)e.Row.FindControl("lblLateAttendance");
            int qtyLateAttendance = Int32.Parse(lblqyLateAttendance.Text);
            total10 = total10 + qtyLateAttendance;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAll = (Label)e.Row.FindControl("lblTotalAll");
            lblTotalAll.Text = total.ToString();

            Label lblTotalAllS = (Label)e.Row.FindControl("lblAllToatalStaff");
            lblTotalAllS.Text = total0.ToString();

            Label lblTotalAllStud = (Label)e.Row.FindControl("lblTotalAllStud");
            lblTotalAllStud.Text = total1.ToString();

            Label lblTotalStudPCAll = (Label)e.Row.FindControl("lblTotalpAllStudC");
            lblTotalStudPCAll.Text = total2.ToString();

            //Label lblqyStydAC = (Label)e.Row.FindControl("lblAllTotalAbsentStudent");
            //int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            //total3 = total3 + qtystudAC;

            Label lblTotalStudACAll = (Label)e.Row.FindControl("lblAllTotalAbsentStaff");
            lblTotalStudACAll.Text = total4.ToString();

            Label lblOnCLStaffAll = (Label)e.Row.FindControl("lblAllOnCLStaff");
            lblOnCLStaffAll.Text = total5.ToString();

            Label lblOnmedicalLeaveAll = (Label)e.Row.FindControl("lblAllOnmedicalLeave");
            lblOnmedicalLeaveAll.Text = total6.ToString();

            Label lblOutdoorOnOfficeleaveAll = (Label)e.Row.FindControl("lblAllOutdoorOnOfficeleave");
            lblOutdoorOnOfficeleaveAll.Text = total7.ToString();

            Label lblOntrainingAll = (Label)e.Row.FindControl("lblAllOntraining");
            lblOntrainingAll.Text = total8.ToString();

            Label lblAbsentWithoutNoticeAll = (Label)e.Row.FindControl("lblAllAbsentWithoutNotice");
            lblAbsentWithoutNoticeAll.Text = total9.ToString();

            Label lblLateAttendanceAll = (Label)e.Row.FindControl("lblAllLateAttendance");
            lblLateAttendanceAll.Text = total10.ToString();

            //Label lblTotalStudACAll = (Label)e.Row.FindControl("lblTotalAAllStudC");
            //lblTotalStudACAll.Text = total3.ToString();
        }
    }
    #endregion

    #region ChReport
    public void CHReport()
    {
        string str1 = DateTime.Now.Date.ToString("yyyy-MM-dd");
        if (txtDateCH.Text == "")
        {
            string str =
                " with Storm as( " +
                " select [CityName],[ToatalStaff],[TotalPresentStaff],[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],TotalAbsentStudent,[AbsentBoysCount],Date,[AbsentGirlsCount],[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from( " +
                " (select [BlockCode] as b,[ToatalStaff],[TotalPresentStaff],TotalAbsentStudent,[TotalReportedSchool],[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount],[TotalAbsentStaff],Date,[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblHMReport] where  [Date]='" + str1 +"' ) as t1" +
                " inner join " +
                " [DBeZeeSchool].[dbo].[CityMaster] as t2 " +
                " on " +
                " t1.b=t2.CID " +
                  " ) " +
                " ) ";
            str += "select [CityName],[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from Storm";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        else
        {
            string str =
                " with Storm as( " +
                " select [CityName],HMMobNo,[ToatalStaff],[TotalPresentStaff],[TotalStudent],[TotalPresentStudCount],TotalAbsentStudent,[AbsentBoysCount],Date,[AbsentGirlsCount],[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from( " +
                " (select [BlockCode] as b,HMMobNo,[ToatalStaff],[TotalPresentStaff],TotalAbsentStudent,[TotalStudent],[TotalPresentStudCount],[AbsentBoysCount],[AbsentGirlsCount],[TotalAbsentStaff],Date,[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from [DBeZeeSchool].[dbo].[tblHMReport] where  [Date]='" + txtDateCH.Text + "' ) as t1" +
                " inner join " +
                " [DBeZeeSchool].[dbo].[CityMaster] as t2 " +
                " on " +
                " t1.b=t2.CID " +
                  " ) " +
                " ) ";
            str += "select [CityName],HMMobNo,[ToatalStaff],[TotalPresentStaff],TotalPresentStudCount,TotalAbsentStudent,[TotalStudent],Date,[TotalAbsentStaff],[OnCLStaff],[OnmedicalLeave],[OutdoorOnOfficeleave],[Ontraining],[AbsentWithoutNotice],[LateAttendance] from Storm";
            SqlCommand cmd = new SqlCommand(str);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Connection = con;
            if (cmd.Connection.State == ConnectionState.Closed)
                cmd.Connection.Open();
            da.Fill(ds);
        }
        gvItemCH.DataSource = ds.Tables[0];
        gvItemCH.DataBind();
        ds.Clear();
    }
    
    protected void btnExportToExcelCH_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvItemCH.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //int total = 0;
    //int total0 = 0;
    //int total1 = 0;
    //int total2 = 0;
    //int total3 = 0;
    //int total4 = 0;
    //int total5 = 0;
    //int total6 = 0;
    //int total7 = 0;
    //int total8 = 0;
    //int total9 = 0;
    //int total10 = 0;
    protected void gvItemCH_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqy = (Label)e.Row.FindControl("lblTotal");
            int qty = Int32.Parse(lblqy.Text);
            total = total + qty;

            Label lblqyToatalStaff = (Label)e.Row.FindControl("lblToatalStaff");
            int qtyS = Int32.Parse(lblqyToatalStaff.Text);
            total0 = total0 + qtyS;

            Label lblqyStud = (Label)e.Row.FindControl("lblTotalStud");
            int qtyStud = Int32.Parse(lblqyStud.Text);
            total1 = total1 + qtyStud;

            Label lblqyStudPC = (Label)e.Row.FindControl("lblTotalPStudCount");
            int qtyStudPC = Int32.Parse(lblqyStudPC.Text);
            total2 = total2 + qtyStudPC;

            Label lblqyStydAC = (Label)e.Row.FindControl("lblTotalAbsentStudent");
            int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            total3 = total3 + qtystudAC;

            Label lblqyAbsentStaff = (Label)e.Row.FindControl("lblTotalAbsentStaff");
            int qtyAbsentStaff = Int32.Parse(lblqyAbsentStaff.Text);
            total4 = total4 + qtyAbsentStaff;

            Label lblqyOnCLStaff = (Label)e.Row.FindControl("lblOnCLStaff");
            int qtyOnCLStaff = Int32.Parse(lblqyOnCLStaff.Text);
            total5 = total5 + qtyOnCLStaff;

            Label lblqyOnmedicalLeave = (Label)e.Row.FindControl("lblOnmedicalLeave");
            int qtyOnmedicalLeave = Int32.Parse(lblqyOnmedicalLeave.Text);
            total6 = total6 + qtyOnmedicalLeave;

            Label lblOutdoorOnOfficeleave = (Label)e.Row.FindControl("lblOutdoorOnOfficeleave");
            int qtyOutdoorOnOfficeleave = Int32.Parse(lblOutdoorOnOfficeleave.Text);
            total7 = total7 + qtyOutdoorOnOfficeleave;

            Label lblqyOntraining = (Label)e.Row.FindControl("lblOntraining");
            int qtyOntraining = Int32.Parse(lblqyOntraining.Text);
            total8 = total8 + qtyOntraining;

            Label lblqyAbsentWithoutNotice = (Label)e.Row.FindControl("lblAbsentWithoutNotice");
            int qtyAbsentWithoutNotice = Int32.Parse(lblqyAbsentWithoutNotice.Text);
            total9 = total9 + qtyAbsentWithoutNotice;

            Label lblqyLateAttendance = (Label)e.Row.FindControl("lblLateAttendance");
            int qtyLateAttendance = Int32.Parse(lblqyLateAttendance.Text);
            total10 = total10 + qtyLateAttendance;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalAll = (Label)e.Row.FindControl("lblTotalAll");
            lblTotalAll.Text = total.ToString();

            Label lblTotalAllS = (Label)e.Row.FindControl("lblAllToatalStaff");
            lblTotalAllS.Text = total0.ToString();

            Label lblTotalAllStud = (Label)e.Row.FindControl("lblTotalAllStud");
            lblTotalAllStud.Text = total1.ToString();

            Label lblTotalStudPCAll = (Label)e.Row.FindControl("lblTotalpAllStudC");
            lblTotalStudPCAll.Text = total2.ToString();

            //Label lblqyStydAC = (Label)e.Row.FindControl("lblAllTotalAbsentStudent");
            //int qtystudAC = Int32.Parse(lblqyStydAC.Text);
            //total3 = total3 + qtystudAC;

            Label lblTotalStudACAll = (Label)e.Row.FindControl("lblAllTotalAbsentStaff");
            lblTotalStudACAll.Text = total4.ToString();

            Label lblOnCLStaffAll = (Label)e.Row.FindControl("lblAllOnCLStaff");
            lblOnCLStaffAll.Text = total5.ToString();

            Label lblOnmedicalLeaveAll = (Label)e.Row.FindControl("lblAllOnmedicalLeave");
            lblOnmedicalLeaveAll.Text = total6.ToString();

            Label lblOutdoorOnOfficeleaveAll = (Label)e.Row.FindControl("lblAllOutdoorOnOfficeleave");
            lblOutdoorOnOfficeleaveAll.Text = total7.ToString();

            Label lblOntrainingAll = (Label)e.Row.FindControl("lblAllOntraining");
            lblOntrainingAll.Text = total8.ToString();

            Label lblAbsentWithoutNoticeAll = (Label)e.Row.FindControl("lblAllAbsentWithoutNotice");
            lblAbsentWithoutNoticeAll.Text = total9.ToString();

            Label lblLateAttendanceAll = (Label)e.Row.FindControl("lblAllLateAttendance");
            lblLateAttendanceAll.Text = total10.ToString();

            //Label lblTotalStudACAll = (Label)e.Row.FindControl("lblTotalAAllStudC");
            //lblTotalStudACAll.Text = total3.ToString();
        }
    }
    #endregion

}

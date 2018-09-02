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

public partial class MarketingAdmin_SchoolAttendence : System.Web.UI.Page
{

    CommonCode cc = new CommonCode();
    String Dt;
    string DateFormat = "";
    string SchoolCode = "";
    string HmMobile = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        SchoolCode = Convert.ToString(Request.QueryString["sc"]);
        HmMobile = Convert.ToString(Request.QueryString["mn"]);

        SchoolCode = cc.DESDecrypt(SchoolCode);
        HmMobile = cc.DESDecrypt(HmMobile);

        DateFormatStatus();
        if (!IsPostBack)
        {
            LoadItem();
            LoadGrid();
            LoadGrid1();
        }
        lblSchoolCode.Text = "School Code :" + SchoolCode;

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
        lblDate.Text = SystemDate.ToString("dd'/'MM'/'yyyy''");
        lblDateTeacher.Text = SystemDate.ToString("dd'/'MM'/'yyyy''");
    }

    //-------------------------------------------------------------- Load Item Data------------------------------------------------------------------

    private void LoadItem()
    {

        try
        {
            DataSet ds = cc.LoadMonthYear();
            ddlmonth.DataSource = ds.Tables[0];
            ddlmonth.DataTextField = "strMonth";
            ddlmonth.DataValueField = "intMonth";
            ddlmonth.DataBind();
            ddlmonth.SelectedIndex = ddlmonth.Items.Count - 1;


            ddlMonthteacher.DataSource = ds.Tables[0];
            ddlMonthteacher.DataTextField = "strMonth";
            ddlMonthteacher.DataValueField = "intMonth";
            ddlMonthteacher.DataBind();
            ddlMonthteacher.SelectedIndex = ddlmonth.Items.Count - 1;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //------------------------------
    public string DateSplit(string data)
    {
        string[] dt = data.Split(' ');
        string[] Dts = dt[0].Split('/');
        data = Dts[1] + "/" + Dts[0] + "/" + Dts[2];
        return data;
    }
    //----------------------------------------------------------------- Load Grid Data---------------------------------------------------------------

    public void LoadGrid()
    {
        try
        {
            string Sql = "Select usrMobileno,Class,Division, RegBoys,RegGirls,Present_B, Present_G, EntryDate from  " +
                       " UDISE_StudentPresenty inner join UserMaster on UDISE_StudentPresenty.usrUserId=UserMaster.usrUserId  where SchoolCode = " +
                       Convert.ToString(SchoolCode) + " and EntryDate='" + Convert.ToString(DateFormat) + "' order by Class desc";//'" + Convert.ToString(DateFormat) + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[7].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[7].Text = Data;
            }
            for (int i = 0; i < gvItem.Rows.Count; i++)
            {
                Label lblPerb = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerBoy");
                Label lblPerg = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerGirls");
                Label lblAllStud = (Label)gvItem.Rows[i].Cells[0].FindControl("lblAllStud");
                {
                    double RegisterBoy = Convert.ToDouble(gvItem.Rows[i].Cells[3].Text);
                    double RegisterGirls = Convert.ToDouble(gvItem.Rows[i].Cells[4].Text);

                    double PresentBoy = Convert.ToDouble(gvItem.Rows[i].Cells[5].Text);
                    double PresentGirls = Convert.ToDouble(gvItem.Rows[i].Cells[6].Text);

                    if (RegisterBoy == 0.0 && RegisterGirls == 0.0)
                    {
                        lblPerb.Text = "0%";
                        lblPerg.Text = "0%";
                        lblAllStud.Text = "0%";
                    }
                    else if (RegisterBoy == 0.0 && RegisterGirls != 0.0)
                    {
                        double k = 0.0;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                    else if (RegisterBoy != 0.0 && RegisterGirls == 0.0)
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = 0.0;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                    else
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                }
            }
        }
        catch (Exception ex)
        { }
    }

    //----------------------------------------------------------------- Load Grid Teacher-------------------------------------------------------------

    public void LoadGrid1()
    {
        try
        {
            string Sql = "SELECT Top(25) usrMobileNo,EntryDate,RegMale,RegFemale,Present_M,Present_F,ModifyDate FROM UDISE_TeacherPresenty" +
                       " UDISE_TeacherPresenty inner join UserMaster on UDISE_TeacherPresenty.usrUserId=UserMaster.usrUserId  where SchoolCode = " +
                       Convert.ToString(SchoolCode) + " order by TeacherID desc ";//'" + Convert.ToString(DateFormat) + "'";
            DataSet ds = cc.ExecuteDataset(Sql);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            gvTeacher.DataSource = ds.Tables[0];
            gvTeacher.DataBind();
            foreach (GridViewRow row in gvTeacher.Rows)
            {
                string Data = row.Cells[1].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[1].Text = Data;
            }
            foreach (GridViewRow row in gvTeacher.Rows)
            {
                string Data = row.Cells[6].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[6].Text = Data;
            }
          
            //}
        }
        catch (Exception ex)
        { }
    }

    //------------------------------------------------------------ Select ChkMonth Code--------------------------------------------------------------

    protected void ChkMonth_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkMonth.Checked == true)
        {
            ddlmonth.Enabled = true;
            ChkDate.Checked = false;
            Image1.Enabled = false;
            txtDate.Text = "";
        }
        else if (ChkMonth.Checked == false)
        {
            ddlmonth.SelectedIndex = ddlmonth.Items.Count - 1;
            ddlmonth.Enabled = false;

        }
    }


    //------------------------------------------------------------ Select ChkMonth Code----------------------------------------------------------------

    protected void ChkDate_CheckedChanged(object sender, EventArgs e)
    {
        if (ChkDate.Checked == true)
        {
            Image1.Enabled = true;
            ChkMonth.Checked = false;
            ddlmonth.SelectedIndex = ddlmonth.Items.Count - 1;
            ddlmonth.Enabled = false;
        }
        else if (ChkDate.Checked == false)
        {

            Image1.Enabled = false;
        }
    }
    //------------------------------------------------------------ Select ChkMonth Code Teacher---------------------------------------------------------

    protected void chkmonthtech_CheckedChanged(object sender, EventArgs e)
    {
        if (chkmonthtech.Checked == true)
        {
            ddlMonthteacher.Enabled = true;
            chkdatetech.Checked = false;
            Image2.Enabled = false;
            txtDate.Text = "";
        }
        else if (chkdatetech.Checked == false)
        {
            ddlMonthteacher.SelectedIndex = ddlMonthteacher.Items.Count - 1;
            ddlMonthteacher.Enabled = false;

        }
    }


    //------------------------------------------------------------ Select ChkMonth Teacher----------------------------------------------------------------

    protected void chkdatetech_CheckedChanged(object sender, EventArgs e)
    {
        if (chkdatetech.Checked == true)
        {
            Image2.Enabled = true;
            chkdatetech.Checked = false;
            ddlMonthteacher.SelectedIndex = ddlMonthteacher.Items.Count - 1;
            ddlMonthteacher.Enabled = false;
        }
        else if (chkdatetech.Checked == false)
        {
            Image2.Enabled = false;
        }
    }


    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (Convert.ToString(e.CommandName) == "Push")
        //{
        //btnSubmit.Text = "Update";
        //string Id = Convert.ToString(e.CommandArgument);
        //string Sql = "Select Message,mobile,shortcode,data,SendDate from Come2mycity.test where PK='" + Id + "'";
        //try
        //{
        //    DataSet ds = cc.ExecuteDataset1(Sql);
        //    txtMgs.Text = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);// "TEACHER*9595826669*Ketan Shinde*10*B";// 
        //    lblMobileNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["mobile"]);
        //    lblDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["shortcode"]);

        //}
        //catch (Exception ex)
        //{ }
        //}
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Select  usrMobileno,Class,Division, RegBoys,RegGirls,Present_B, Present_G, EntryDate from  " +
                       " UDISE_StudentPresenty inner join UserMaster on UDISE_StudentPresenty.usrUserId=UserMaster.usrUserId  where SchoolCode = " +
                       Convert.ToString(SchoolCode) + " ";//'" + Convert.ToString(DateFormat) + "'";

            if (ddlmonth.SelectedIndex != ddlmonth.Items.Count - 1)
            {
                Sql = Sql + " and datePart(month,UDISE_StudentPresenty.EntryDate)=" + ddlmonth.SelectedValue.ToString() + " ";
            }
            else if (txtDate.Text != "")
            {
                Sql = Sql + " and UDISE_StudentPresenty.EntryDate='" + txtDate.Text + "'";
            }
            DataSet ds = cc.ExecuteDataset(Sql);

            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[7].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[7].Text = Data;
            }
            for (int i = 0; i < gvItem.Rows.Count; i++)
            {
                Label lblPerb = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerBoy");
                Label lblPerg = (Label)gvItem.Rows[i].Cells[0].FindControl("lblPerGirls");
                Label lblAllStud = (Label)gvItem.Rows[i].Cells[0].FindControl("lblAllStud");
                {
                    double RegisterBoy = Convert.ToDouble(gvItem.Rows[i].Cells[3].Text);
                    double RegisterGirls = Convert.ToDouble(gvItem.Rows[i].Cells[4].Text);

                    double PresentBoy = Convert.ToDouble(gvItem.Rows[i].Cells[5].Text);
                    double PresentGirls = Convert.ToDouble(gvItem.Rows[i].Cells[6].Text);

                    if (RegisterBoy == 0.0 && RegisterGirls == 0.0)
                    {
                        lblPerb.Text = "0%";
                        lblPerg.Text = "0%";
                        lblAllStud.Text = "0%";
                    }
                    else if (RegisterBoy == 0.0 && RegisterGirls != 0.0)
                    {
                        double k = 0.0;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                    else if (RegisterBoy != 0.0 && RegisterGirls == 0.0)
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = 0.0;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }
                    else
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb.Text = Convert.ToInt16(k) + "%";
                        lblPerg.Text = Convert.ToInt16(j) + "%";
                        lblAllStud.Text = Convert.ToInt16(m) + "%";
                    }


                }
            }
            GvTech.DataSource = ds.Tables[0];
            GvTech.DataBind();
            for (int i = 0; i < GvTech.Rows.Count; i++)
            {
                Label lblPerb1 = (Label)GvTech.Rows[i].Cells[0].FindControl("lblPerBoy1");
                Label lblPerg1 = (Label)GvTech.Rows[i].Cells[0].FindControl("lblPerGirls1");
                Label lblAllStud1 = (Label)GvTech.Rows[i].Cells[0].FindControl("lblAllStud1");
                {
                    double RegisterBoy = Convert.ToDouble(GvTech.Rows[i].Cells[6].Text);
                    double RegisterGirls = Convert.ToDouble(GvTech.Rows[i].Cells[7].Text);

                    double PresentBoy = Convert.ToDouble(GvTech.Rows[i].Cells[8].Text);
                    double PresentGirls = Convert.ToDouble(GvTech.Rows[i].Cells[9].Text);

                    if (RegisterBoy == 0.0 && RegisterGirls == 0.0)
                    {
                        lblPerb1.Text = "0%";
                        lblPerg1.Text = "0%";
                        lblAllStud1.Text = "0%";
                    }
                    else if (RegisterBoy == 0.0 && RegisterGirls != 0.0)
                    {
                        double k = 0.0;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb1.Text = Convert.ToInt16(k) + "%";
                        lblPerg1.Text = Convert.ToInt16(j) + "%";
                        lblAllStud1.Text = Convert.ToInt16(m) + "%";
                    }
                    else if (RegisterBoy != 0.0 && RegisterGirls == 0.0)
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = 0.0;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb1.Text = Convert.ToInt16(k) + "%";
                        lblPerg1.Text = Convert.ToInt16(j) + "%";
                        lblAllStud1.Text = Convert.ToInt16(m) + "%";
                    }
                    else
                    {
                        double k = PresentBoy / RegisterBoy;
                        k = k * 100;
                        double j = PresentGirls / RegisterGirls;
                        j = j * 100;

                        double m = (PresentBoy + PresentGirls) / (RegisterBoy + RegisterGirls);
                        m = m * 100;

                        lblPerb1.Text = Convert.ToInt16(k) + "%";
                        lblPerg1.Text = Convert.ToInt16(j) + "%";
                        lblAllStud1.Text = Convert.ToInt16(m) + "%";
                    }

                }
            }
        }
        catch (Exception ex)
        { }

    }
    protected void btnShowTeacher_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "SELECT Top(25) usrMobileNo,EntryDate,RegMale,RegFemale,Present_M,Present_F,ModifyDate FROM UDISE_TeacherPresenty" +
                      " UDISE_TeacherPresenty inner join UserMaster on UDISE_TeacherPresenty.usrUserId=UserMaster.usrUserId  where SchoolCode = " +
                      Convert.ToString(SchoolCode) + " order by TeacherID desc ";//'" + Convert.ToString(DateFormat) + "'";
            if (ddlMonthteacher.SelectedIndex != ddlMonthteacher.Items.Count - 1)
            {
                Sql = Sql + " and datePart(month,UDISE_TeacherPresenty.EntryDate)=" + ddlmonth.SelectedValue.ToString() + " ";
            }
            else if (txtDateTeacher.Text != "")
            {
                Sql = Sql + " and UDISE_TeacherPresenty.EntryDate='" + txtDateTeacher.Text + "'";
            }
            DataSet ds = cc.ExecuteDataset(Sql);

            gvTeacher.DataSource = ds.Tables[0];
            gvTeacher.DataBind();
            foreach (GridViewRow row in gvTeacher.Rows)
            {
                string Data = row.Cells[6].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[6].Text = Data;
            }
            foreach (GridViewRow row in gvTeacher.Rows)
            {
                string Data = row.Cells[1].Text.ToString();
                Data = DateSplit(Data);
                row.Cells[1].Text = Data;
            }
            GvHM.DataSource = ds.Tables[0];
            GvHM.DataBind();
        }
        catch (Exception ex)
        { }


    }

    //-----------------------------------Don't Delete This Function. It Is used to Excel Download File-----------------------------------------------

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GvTech.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnDownloadTech_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Report.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            GvHM.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

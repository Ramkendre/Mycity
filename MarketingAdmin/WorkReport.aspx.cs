using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Mail;
using Microsoft.ApplicationBlocks.Data;


public partial class MarketingAdmin_WorkReport : System.Web.UI.Page
{
    SqlConnection conmyct = new SqlConnection();
    SqlCommand cmd = new SqlCommand(); DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();
    CommonCode cc = new CommonCode();
    string sql = string.Empty;
    string mob;//= "9422325020";//"8087371027"; //"9422325020";
    string ID;
    string IDI;
    string mobileNo = "8087371027";
    string Name;
    string RemarkID = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["TID"] != null)
        {
            txtParentId.Text = Convert.ToString(Request.QueryString["TID"]);
        }
       
        if (!IsPostBack) 
        {
            if (Request.QueryString["TID"] != null)//if (Application["TID"]!=null)
            {
                //ID=Convert.ToString(Application["TID"]);
                ID = Convert.ToString(Request.QueryString["TID"]);
                BindDDL();
                BindWorkAssign();
                loginSession();
                SessionName();
                //Trail(ID);               
                txtParentId.Text = Convert.ToString(Request.QueryString["TID"]);//Convert.ToString(Application["IDI"]);
                lblMsgHead.Visible = true;
                lblMsgHead.Text = "Trail For Record No='" + ID + "'";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Trail For Record No=" + ID + "')", true);
            }
            else if (Request.QueryString["ReportId"]!=null)
            {
                ID = Convert.ToString(Request.QueryString["ReportId"]);
                BindDDL();
                BindWorkAssign();
                loginSession();
                SessionName();
                ALLTrail(ID);
            }
            else
            {
                BindDDL();
                BindWorkAssign();
                loginSession();
                SessionName();
                GvBind();

            }           
        }
       
    }
    public void Trail(string RID)
    {
        btnSubmit.Visible = false;
        lblWorkStatus.Visible = true;
        ddlWorkStatus.Visible = true;
        btnSave.Visible = true;
        lblCurrentStatus.Visible = true;
        ddlCurrentStatus.Visible = true;
        lblRemark.Visible = true;
        txtRemark.Visible = true;
        using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@type", 1);
            objSqlParameter[1] = new SqlParameter("@ReportId", RID);
            ds.Clear();
            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "UspDownloadWWorkReport", objSqlParameter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //ddlNameOfworkPrj.DataValueField = ds.Tables[0].Rows[0][""].ToString();
                ddlNameOfworkPrj.SelectedItem.Text = ds.Tables[0].Rows[0]["ItemName"].ToString();
                ddlWorkType.Text = ds.Tables[0].Rows[0]["ProjectStatus"].ToString();
                txtSubject.Text = ds.Tables[0].Rows[0]["ProjectDetails"].ToString();
                txtContents.Text = ds.Tables[0].Rows[0]["ProjectContents"].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0]["ProjectQuantity"].ToString();
                txtTimeRequired.Text = ds.Tables[0].Rows[0]["ProjectTime"].ToString();
                txtDate.Text = ds.Tables[0].Rows[0]["ProjectDate"].ToString();
                ddlWorkAssignTo.Text = ds.Tables[0].Rows[0]["UserMobNo"].ToString();
                ddlWorkStatus.SelectedItem.Text = ds.Tables[0].Rows[0]["ProjectWork"].ToString();
            }
            txtSubject.ReadOnly = true;
            txtContents.ReadOnly = true;
            txtQuantity.ReadOnly = true;
            txtTimeRequired.ReadOnly = true;
            txtDate.ReadOnly = true;
            txtSubject.ReadOnly = true;
        }
    }
    public void ALLTrail(string RID)
    {
        btnSubmit.Visible = false;
        lblWorkStatus.Visible = true;
        ddlWorkStatus.Visible = true;
        btnSave.Visible = true;
        lblCurrentStatus.Visible = true;
        ddlCurrentStatus.Visible = true;
        lblRemark.Visible = true;
        txtRemark.Visible = true;
        txtParentId.Text = RID;
        int vr1 =Convert.ToInt32(ddlWorkStatus.SelectedValue);
        int vr2 = Convert.ToInt32(ddlCurrentStatus.SelectedValue);
        lblMsgHead.Text = "Trail For Record No='" + RID + "'";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Trail For Record No=" + RID + "')", true);
        using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
        {
            ds.Clear();
            SqlParameter[] objSqlParameter = new SqlParameter[11];
            objSqlParameter[0] = new SqlParameter("@type", 1);
            objSqlParameter[1] = new SqlParameter("@ReportId", RID);
            ds = SqlHelper.ExecuteDataset(conn, CommandType.StoredProcedure, "UspDownloadWWorkReport", objSqlParameter);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //ddlNameOfworkPrj.DataValueField = ds.Tables[0].Rows[0][""].ToString();
                ddlNameOfworkPrj.SelectedItem.Text = ds.Tables[0].Rows[0]["ItemName"].ToString();
                ddlWorkType.Text = ds.Tables[0].Rows[0]["ProjectStatus"].ToString();
                txtSubject.Text = ds.Tables[0].Rows[0]["ProjectDetails"].ToString();
                txtContents.Text = ds.Tables[0].Rows[0]["ProjectContents"].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0]["ProjectQuantity"].ToString();
                txtTimeRequired.Text = ds.Tables[0].Rows[0]["ProjectTime"].ToString();
                txtDate.Text = ds.Tables[0].Rows[0]["ProjectDate"].ToString();
                ddlWorkAssignTo.SelectedItem.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                ddlWorkStatus.SelectedItem.Text = ds.Tables[0].Rows[0]["ProjectWork"].ToString();
            }
        }
    }
    public string loginSession()
    {
        if (Session["Mobile"] != null)
        {
            mob = Session["Mobile"].ToString();
        }
        else
        {
            Response.Redirect("~/default.aspx");
        }
        return mob;
    }

    public void BindWorkAssign()
    {
        try
        {
            //sql = "select [EmpMobNo],[FirstName],[LastName] from [EzeeMarketing_AddEmpPermission] where [AppMobNo]='" + Session["MobileNumber"].ToString() + "' ";
            sql = "select [EmpMobNo],[FirstName] + ' ' +[LastName] AS FirstName from [EzeeMarketing_AddEmpPermission] where [AppMobNo]='" + mobileNo.ToString() + "' ";
            ds = cc.ExecuteDataset(sql);

            ddlWorkAssignTo.DataSource = ds.Tables[0];
            ddlWorkAssignTo.DataTextField = "FirstName";
            ddlWorkAssignTo.DataValueField = "EmpMobNo";
            ddlWorkAssignTo.DataBind();
            ddlWorkAssignTo.Items.Add("--Select--");
            ddlWorkAssignTo.SelectedIndex = ddlWorkAssignTo.Items.Count - 1;
        }
        catch { }
    }

    public void BindDDL()
    {
        try
        {
            //sql = "select [ItemId],[ItemName],[GroupID] from [EzeeMarketingAddItem] where [AdminMobNo]='" + Session["MobileNumber"].ToString() + "' and [GroupID]=4";//Session["MobileNumber"].ToString()
            sql = "select [ItemId],[ItemName],[GroupID] from [EzeeMarketingAddItem] where [AdminMobNo]='" + mobileNo.ToString() + "' and [GroupID]=4";//Session["MobileNumber"].ToString()
            ds = cc.ExecuteDataset(sql);
            ddlNameOfworkPrj.DataSource = ds.Tables[0];
            ddlNameOfworkPrj.DataTextField = "ItemName";
            ddlNameOfworkPrj.DataValueField = "ItemId";
            ddlNameOfworkPrj.DataBind();
            ddlNameOfworkPrj.Items.Add("--Select--");
            ddlNameOfworkPrj.SelectedIndex = ddlNameOfworkPrj.Items.Count - 1;
        }
        catch { }
    } 
    
    public void GvBind()
    {
        try
        {
            //sql = "select ReportId,[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork],[ParentId] from [Come2myCityDB].[dbo].[EzeeMarketingDevReport] where [AdminMobNo]='" + mob + "'";
            //sql = "select ReportId,[EmployeeMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork] ,[ParentId]from [Come2myCityDB].[dbo].[EzeeMarketingDevReport] where [AdminMobNo]='" + Session["MobileNumber"].ToString() + "'";
            sql = "select ReportId,[UserMobNo],[ProjectStatus],[ProjectDetails],[ProjectContents],[ProjectTime],[ProjectDate],[ProjectQuantity],[ProjectWork] ,[ParentId] FROM [Come2myCityDB].[dbo].[EzeeMarketingWorkReport] where [AdminMobNo]='" + mobileNo.ToString() + "' ORDER by ReportId DESC";
            ds = cc.ExecuteDataset(sql);
            WorkreportGv.DataSource = ds.Tables[0];
            WorkreportGv.DataBind();
        }
        catch
        {

        }
    }

    protected void ddlNameOfworkPrj_SelectedIndexChanged(object sender, EventArgs e)
    {
        //sql = "select [ItemId],[ItemName],[GroupID] from [EzeeMarketingAddItem] where [AdminMobNo]='" + Session["MobileNumber"].ToString() + "' and [GroupID]=5";
        sql = "select [ItemId],[ItemName],[GroupID] from [EzeeMarketingAddItem] where [AdminMobNo]='" + mobileNo.ToString() + "' and [GroupID]=5";
        ds = cc.ExecuteDataset(sql);
        ddlWorkType.DataSource = ds.Tables[0];
        ddlWorkType.DataTextField = "ItemName";
        ddlWorkType.DataValueField = "ItemId";
        ddlWorkType.DataBind();
        ddlWorkType.Items.Add("--Select--");
        ddlWorkType.SelectedIndex = ddlWorkType.Items.Count - 1;
    }
    public void SessionName()
    {
        if (Session["UserFirstNameN"] != null)
        {
            Name = Session["UserFirstNameN"].ToString();
            //Application["UserFirstNameN"] = Name.ToString();
            ViewState["UserFirstNameN"] = Name.ToString();
        }
        //if (Name=="UserFirstNameN")
        //{
        //    MailMessage objMailMessage = new MailMessage();
        //    objMailMessage.From = new MailAddress("Sham@gmail.com");
        //    objMailMessage.To.Add("ram@gmail.com");
        //    objMailMessage.Subject = "Gental Reminder !!!";
        //    objMailMessage.Body = "Dear Sir Please Fillup the To day Work";
        //    objMailMessage.IsBodyHtml = true;
        //    SmtpClient objSmtpClient = new SmtpClient("smtp.gmail.com");
        //    objSmtpClient.Port=587;
        //    objSmtpClient.UseDefaultCredentials = false;
        //    objSmtpClient.Credentials = new System.Net.NetworkCredential("sham@gmail.com", "shampassword");
        //    objSmtpClient.EnableSsl = true;
        //}     
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string FirstName = ViewState["UserFirstNameN"].ToString();
        int i;
        string ParentId = string.Empty;
        //ParentId = ID.ToString();
        //string sql = "Select [ParentId] FROM [Come2myCityDB].[dbo].[EzeeMarketingDevReport] where [AdminMobNo]='" + Session["MobileNumber"].ToString() + "' OR [ReportId]='" + ID + "'";
        //ds = cc.ExecuteDataset(sql);
        if (txtParentId.Text!=string.Empty)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                ParentId = txtParentId.Text;// Convert.ToString(Request.QueryString["TID"]); //Application["TID"].ToString();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Parameters.Add("@NameOfWorkProject", ddlNameOfworkPrj.SelectedValue.ToString());
                cmd.Parameters.Add("@workType", ddlWorkType.SelectedValue.ToString());
                cmd.Parameters.Add("@subject", txtSubject.Text);
                cmd.Parameters.Add("@Contents", txtContents.Text);
                cmd.Parameters.Add("@quantity", txtQuantity.Text);
                cmd.Parameters.Add("@TimeRequire", txtTimeRequired.Text);
                cmd.Parameters.Add("@Date", txtDate.Text);
                cmd.Parameters.Add("@WorkAssign", ddlWorkAssignTo.SelectedValue.ToString());
                cmd.Parameters.Add("@workStatus", ddlWorkStatus.SelectedItem.Text);
                //cmd.Parameters.Add("@adminMobNo", Session["MobileNumber"].ToString());
                cmd.Parameters.Add("@adminMobNo", mobileNo.ToString());
                cmd.Parameters.Add("@Createdate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.Add("@ParentId", SqlDbType.NVarChar).Value = ParentId.ToString();
                cmd.Parameters.Add("@CustName", SqlDbType.NVarChar).Value = Session["UserFirstNameN"].ToString();
                cmd.CommandText = "spEzeeMarketingInsertWorkReport";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                i = cmd.ExecuteNonQuery();
                if (i.Equals(1))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('" + ParentId + " No.Record Trailed Successfully...')", true);
                }
                con.Close();
                Clear();
                GvBind();
                lblError.Visible = true;
                //lblError.Text = "Record Inserted Successfully";

            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                ParentId = "-1";
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Parameters.Add("@NameOfWorkProject", ddlNameOfworkPrj.SelectedValue.ToString());
                cmd.Parameters.Add("@workType", ddlWorkType.SelectedValue.ToString());
                cmd.Parameters.Add("@subject", txtSubject.Text);
                cmd.Parameters.Add("@Contents", txtContents.Text);
                cmd.Parameters.Add("@quantity", txtQuantity.Text);
                cmd.Parameters.Add("@TimeRequire", txtTimeRequired.Text);
                cmd.Parameters.Add("@Date", txtDate.Text);
                cmd.Parameters.Add("@WorkAssign", ddlWorkAssignTo.SelectedValue.ToString());
                cmd.Parameters.Add("@workStatus", ddlWorkStatus.SelectedItem.Text);
                //cmd.Parameters.Add("@adminMobNo", Session["MobileNumber"].ToString());
                cmd.Parameters.Add("@adminMobNo", mobileNo.ToString());
                cmd.Parameters.Add("@Createdate", System.DateTime.Now.ToString("yyyy-MM-dd"));
                cmd.Parameters.Add("@ParentId", SqlDbType.NVarChar).Value = ParentId.ToString();
                cmd.Parameters.Add("@CustName", SqlDbType.NVarChar).Value = Session["UserFirstNameN"].ToString();
                cmd.CommandText = "spEzeeMarketingInsertWorkReport";
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                i = cmd.ExecuteNonQuery();
                if (i.Equals(1))
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Inserted Successfully...')", true);
                }
                con.Close();
                Clear();
                GvBind();

                lblError.Visible = true;
                //lblError.Text = "Record Inserted Successfully";

            }
        }
    }

    public void Clear()
    {
        ddlNameOfworkPrj.SelectedIndex = 0;
        ddlWorkType.SelectedIndex = 0;
        txtSubject.Text = "";
        txtContents.Text = "";
        txtQuantity.Text = "";
        txtTimeRequired.Text = "";
        txtDate.Text = "";
        ddlWorkAssignTo.SelectedIndex = 0;
        ddlWorkStatus.SelectedIndex = 0;
    }

    protected void WorkreportGv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        WorkreportGv.PageIndex = e.NewPageIndex;
        GvBind();
    }
    protected void WorkreportGv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        WorkreportGv.EditIndex = e.NewEditIndex;
        GvBind();
    }
    protected void WorkreportGv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        WorkreportGv.EditIndex = -1;
        GvBind();
    }
    protected void WorkreportGv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            //int NameOfWorkProject = Convert.ToInt32(WorkreportGv.DataKeys[e.RowIndex].Value.ToString());
            //GridViewRow row = (GridViewRow)WorkreportGv.Rows[e.RowIndex];
            //TextBox txId=(TextBox)row.Cells[0].Controls[0];
            // ddlWorkType.Text =Convert.ToString((DropDownList)row.Cells[1].Controls[0]);
            //txtSubject.Text = Convert.ToString((TextBox)row.Cells[2].Controls[0]);
            //txtContents.Text = Convert.ToString((TextBox)row.Cells[3].Controls[0]);

            //txtTimeRequired.Text = Convert.ToString((TextBox)row.Cells[4].Controls[0]);
            //txtDate.Text = Convert.ToString((TextBox)row.Cells[5].Controls[0]);
            //txtQuantity.Text = Convert.ToString((TextBox)row.Cells[6].Controls[0]);
            //ddlWorkAssignTo.Text = Convert.ToString((TextBox)row.Cells[7].Controls[0]);
            //ddlWorkStatus.Text = Convert.ToString((TextBox)row.Cells[7].Controls[0]);

            int ReportId = Convert.ToInt32(WorkreportGv.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)WorkreportGv.Rows[e.RowIndex];
            //TextBox txId=(TextBox)row.Cells[0].Controls[0];
            TextBox txtWorkAssignss = (TextBox)row.Cells[2].Controls[0];
            TextBox txtSub = (TextBox)row.Cells[3].Controls[0];
            TextBox txtCon = (TextBox)row.Cells[4].Controls[0];
            TextBox txttime = (TextBox)row.Cells[5].Controls[0];
            TextBox txtDat = (TextBox)row.Cells[6].Controls[0];
            TextBox txtNoofQuantity = (TextBox)row.Cells[7].Controls[0];
            TextBox txtWorkSta = (TextBox)row.Cells[8].Controls[0];
            WorkreportGv.EditIndex = -1;

            cmd.CommandText = "[spEzeeMarketingUpdateWorkReport]";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.Add("@ReportId", SqlDbType.NVarChar).Value = ReportId.ToString();
            cmd.Parameters.Add("@WorkAssign", SqlDbType.NVarChar).Value = txtWorkAssignss.Text.ToString();
            cmd.Parameters.Add("@subject", SqlDbType.NVarChar).Value = txtSub.Text.ToString();
            cmd.Parameters.Add("@Contents", SqlDbType.NVarChar).Value = txtCon.Text.ToString();
            cmd.Parameters.Add("@TimeRequire", SqlDbType.NVarChar).Value = txttime.Text.ToString();
            cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDat.Text.ToString();

            cmd.Parameters.Add("@quantity", SqlDbType.NVarChar).Value = txtNoofQuantity.Text.ToString();
            cmd.Parameters.Add("@workStatus", SqlDbType.NVarChar).Value = txtWorkSta.Text.ToString();

            //cmd.Parameters.Add("@adminMobNo", SqlDbType.NVarChar).Value = Session["MobileNumber"].ToString();
            cmd.Parameters.Add("@adminMobNo", SqlDbType.NVarChar).Value = mobileNo.ToString();
            cmd.Parameters.Add("@Createdate", SqlDbType.NVarChar).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
            cmd.ExecuteNonQuery();
            GvBind();
        }
        catch { }
        finally { con.Close(); }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //int ReportId = 1;
        //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        //cmd.CommandText = "[spEzeeMarketingUpdateWorkReport]";
        //cmd.CommandType = CommandType.StoredProcedure;
        //if (con.State == ConnectionState.Closed)
        //{
        //    con.Open();
        //}
        //cmd.Parameters.Add("@ReportId", SqlDbType.NVarChar).Value = ReportId.ToString();
        //cmd.Parameters.Add("@WorkAssign", SqlDbType.NVarChar).Value = ddlWorkType.Text;
        //cmd.Parameters.Add("@subject", SqlDbType.NVarChar).Value = txtSubject.Text;
        //cmd.Parameters.Add("@Contents", SqlDbType.NVarChar).Value = txtContents.Text;
        //cmd.Parameters.Add("@TimeRequire", SqlDbType.NVarChar).Value = txtTimeRequired.Text;
        //cmd.Parameters.Add("@Date", SqlDbType.NVarChar).Value = txtDate.Text;

        //cmd.Parameters.Add("@quantity", SqlDbType.NVarChar).Value = txtQuantity.Text;
        //cmd.Parameters.Add("@workStatus", SqlDbType.NVarChar).Value = ddlWorkStatus.Text;

        //cmd.Parameters.Add("@adminMobNo", SqlDbType.NVarChar).Value = mob;
        //cmd.Parameters.Add("@Createdate", SqlDbType.NVarChar).Value = System.DateTime.Now.ToString("yyyy-MM-dd");
        //cmd.ExecuteNonQuery();
    }
    protected void WorkreportGv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Are You Sure to Delete this Records ?')", true);

        SqlConnection con = new SqlConnection(WebConfigurationManager.AppSettings["ConnectionString"]);
        try
        {

            int ReportId = Convert.ToInt32(WorkreportGv.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)WorkreportGv.Rows[e.RowIndex];
            //string SQL = "Delete  FROM [Come2myCityDB].[dbo].[EzeeMarketingDevReport] Where [ReportId]='" + Convert.ToInt32(WorkreportGv.DataKeys[e.RowIndex].Value.ToString()) + "' ";
            cmd.CommandText = "[spEzeeMarketingDeleteWorkReport]";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.Add("@ReportId", SqlDbType.NVarChar).Value = ReportId.ToString();
            cmd.ExecuteNonQuery();
            GvBind();
        }
        catch { }
        finally { con.Close(); }
    }

    protected void WorkreportGv_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlNameOfworkPrj.DataValueField = WorkreportGv.SelectedRow.Cells[2].Text;
        txtParentId.Text = WorkreportGv.SelectedRow.Cells[10].Text;
        ID = ddlNameOfworkPrj.DataValueField.ToString();
        Application["TID"] = ID;
        txtParentId.Text = ID;
        lblMsgHead.Visible = true;
        lblMsgHead.Text = "Trail For Record No='" + ID + "'";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Trail For Record No=" + ID + "')", true);
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtContents.Text = string.Empty;
        txtDate.Text = string.Empty;
        txtParentId.Text = string.Empty;
        txtQuantity.Text = string.Empty;
        txtSubject.Text = string.Empty;
        txtTimeRequired.Text = string.Empty;
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeReports.aspx");
    }
    protected void LinkRemark_Click(object sender, EventArgs e)
    {
        string ReportId = string.Empty;
        string ParentId = string.Empty;
        LinkButton lnkRemove = (LinkButton)sender;
        RemarkID = lnkRemove.CommandArgument;

        string id = RemarkID;
        string[] ary = id.Split(',');
        ReportId = Convert.ToString(ary[0].Trim());
        ParentId = Convert.ToString(ary[1].Trim());
        //ddlNameOfworkPrj.DataValueField = WorkreportGv.SelectedRow.Cells[2].Text;
        //RemarkID = ddlNameOfworkPrj.DataValueField.ToString();

        Trail(ReportId);
        lblMsgHead.Visible = true;
        lblMsgHead.Text = "Remark For Record No='" + ReportId + "'";
        txtParentId.Text = string.Empty;
        txtParentId.Text = ReportId;
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Remark For Record No=" + ReportId + " In Refernce to Record No=" + ParentId + "')", true);
    }
    //protected void btnSave_Click(object sender, EventArgs e)
    //{

    //    using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
    //    {
    //        string ParentId = "-1";
    //        int i = 0;
    //        cmd = new SqlCommand();
    //        cmd.Connection = con;
    //        cmd.Parameters.Add("@ReportId", txtParentId.Text);
    //        cmd.Parameters.Add("@CurentStatus", ddlCurrentStatus.SelectedItem.ToString());
    //        cmd.Parameters.Add("@CurentStatusRemark", txtRemark.Text);
    //        cmd.Parameters.Add("@CurentStatusby", ddlWorkAssignTo.SelectedValue.ToString());
    //        cmd.Parameters.Add("@CurentStatusDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
    //        cmd.CommandText = "UspEzeeMarketingInsertWorkReportALL";//UspEzeeMarketingInsertWorkReportALL
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        con.Open();
    //        i = cmd.ExecuteNonQuery();
    //        if (i.Equals(1))
    //        {
    //            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Inserted Successfully...')", true);
    //        }
    //        con.Close();
    //        Clear();
    //        GvBind();
    //        lblError.Visible = true;
    //    }
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            string ParentId = "-1";
            int i = 0;
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Parameters.Add("@ReportId", txtParentId.Text);
            cmd.Parameters.Add("@CurentStatus", ddlCurrentStatus.SelectedItem.ToString());
            cmd.Parameters.Add("@CurentStatusRemark", txtRemark.Text);
            cmd.Parameters.Add("@CurentStatusby", ddlWorkAssignTo.SelectedValue.ToString());
            cmd.Parameters.Add("@CurentStatusDate", System.DateTime.Now.ToString("yyyy-MM-dd"));
            cmd.CommandText = "UspEzeeMarketingInsertWorkReportALL";//UspEzeeMarketingInsertWorkReportALL
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            i = cmd.ExecuteNonQuery();
            if (i.Equals(1))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Inserted Successfully...')", true);
            }
            con.Close();
            Clear();
            GvBind();
            lblError.Visible = true;
        }
    }
}
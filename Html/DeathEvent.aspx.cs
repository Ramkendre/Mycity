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
using System.Data.OleDb;
using System.Threading;

public partial class html_DeathEvent : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    EventDeathBLL objEventDeathBLL = new EventDeathBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        String UserIdSession = Convert.ToString(Session["User"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                LoadGrid();
                
            }
        }

    }
    public void LoadGrid()
    {
        try
        {
            objEventDeathBLL.UserId1 = Convert.ToString(Session["User"].ToString());
            DataSet ds = objEventDeathBLL.loadgridBLL(objEventDeathBLL);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
            foreach (GridViewRow row in gvItem.Rows)
            {
                String data = row.Cells[5].Text.ToString();
                row.Cells[5].Text = data;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //public void LoadGrid1()
    //{
    //    objEventMeetingBLL.UserId1 = Convert.ToString(Session["User"]);
    //    objEventDeathBLL.usrMobileNo1 = Convert.ToString(Session["MobileNo"]);
    //    DataSet ds = objEventDeathBLL.LoadGrid1BLL(objEventDeathBLL);
    //    if (ds != null && ds.Tables[0].Rows.Count != 0)
    //    {
    //        GridView1.DataSource = ds.Tables[0];
    //        GridView1.DataBind();
    //    }
    //}
    //----------------------------------------------------------Current Date Format---------------------------------------------------------------------
    public void Addrecord()
    {
        objEventDeathBLL.NameOfAccused1 = Convert.ToString(txtNameOfAcc.Text);
        objEventDeathBLL.Date1 = Convert.ToString(txtDate.Text);
        objEventDeathBLL.Time1 = Convert.ToString(txtTime.Text);
        objEventDeathBLL.Location1 = Convert.ToString(txtLocation.Text);
        objEventDeathBLL.SDescp1 = Convert.ToString(txtDescp.Text);
        objEventDeathBLL.Relative1 = Convert.ToString(txtRelative.Text);
        objEventDeathBLL.Relation1 = Convert.ToString(txtRAccused.Text);
        objEventDeathBLL.PVisit1 = Convert.ToString(rbtnPvisit.Text);
        objEventDeathBLL.MDescp1 = Convert.ToString(txtMDescp.Text);
        objEventDeathBLL.UserId1 = Convert.ToString(Session["User"].ToString());
      int Status=  objEventDeathBLL.AddRecordBLL(objEventDeathBLL);
      if (Status == 1)
      {
          LoadGrid();
          clear();
          ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String DID = Convert.ToString(lblId.Text.ToString());
        if (DID == "" || DID == null)
        {
            Addrecord();
            clear();
        }
        else
        {
            Update(DID);
        }
    }
    public void clear()
    {
        lblId.Text = "";
        txtNameOfAcc.Text = "";
        txtRAccused.Text = "";
        txtMDescp.Text = "";
        txtRelative.Text = "";
        txtDate.Text = "";
        txtTime.Text = "";
        rbtnPvisit.Text = "";
        txtDescp.Text = "";
        txtLocation.Text = "";
        btnSubmit.Text = "Submit";
    }
    public void Update(string DID)
    {
        objEventDeathBLL.DID1 = Convert.ToInt16(DID);
        objEventDeathBLL.NameOfAccused1 = Convert.ToString(txtNameOfAcc.Text);
        objEventDeathBLL.Date1 = Convert.ToString(txtDate.Text);
        objEventDeathBLL.Time1 = Convert.ToString(txtTime.Text);
        objEventDeathBLL.Location1 = Convert.ToString(txtLocation.Text);
        objEventDeathBLL.SDescp1 = Convert.ToString(txtDescp.Text);
        objEventDeathBLL.Relative1 = Convert.ToString(txtRelative.Text);
        objEventDeathBLL.Relation1 = Convert.ToString(txtRAccused.Text);
        objEventDeathBLL.PVisit1 = Convert.ToString(rbtnPvisit.Text);
        objEventDeathBLL.MDescp1 = Convert.ToString(txtMDescp.Text);
        objEventDeathBLL.UserId1=Convert.ToString(Session["User"]);

        int Status = objEventDeathBLL.UpdateBLL(objEventDeathBLL);
        if (Status == 1)
        {
            LoadGrid();
            
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Updated Successfully')", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Updated Successfully')", true);
        }

    }
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }
    
    protected void gvItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modify")
        {
            btnSubmit.Text = "Update";
            string DID = Convert.ToString(e.CommandArgument);
            lblId.Text = DID;
            objEventDeathBLL.DID1 = Convert.ToInt16(DID);
            objEventDeathBLL.SelectRecordBLL(objEventDeathBLL);

            txtNameOfAcc.Text = Convert.ToString(objEventDeathBLL.NameOfAccused1);
            txtDate.Text = Convert.ToString(objEventDeathBLL.Date1);
            txtTime.Text = Convert.ToString(objEventDeathBLL.Time1);
            txtLocation.Text = Convert.ToString(objEventDeathBLL.Location1);
            txtDescp.Text = Convert.ToString(objEventDeathBLL.SDescp1);
            txtRelative.Text = Convert.ToString(objEventDeathBLL.Relative1);
            txtRAccused.Text = Convert.ToString(objEventDeathBLL.Relation1);
            rbtnPvisit.Text = Convert.ToString(objEventDeathBLL.PVisit1);
            txtMDescp.Text = Convert.ToString(objEventDeathBLL.MDescp1);

        }
        if(Convert.ToString(e.CommandName)=="Delete")
        {
            string DID = Convert.ToString(e.CommandArgument);
            lblId.Text = DID;
            objEventDeathBLL.DID1 = Convert.ToInt16(DID);
            con.Open();
            string str = "Delete from [Come2myCityDB].[dbo].[tbl_EventDeath] where DID='"+DID+"' ";
            SqlCommand cmd = new SqlCommand(str,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void lnkshowchild_Click(object sender, EventArgs e)
    {
        //LoadGrid1();
        MultiView1.SetActiveView(View2);
        MultiView1.Visible = true;
    }
    protected void btnUploadFile_Click(object sender, EventArgs e)
    {
        try
        {
            if (excelFileUpload.HasFile)
            {
                string path = "";
                path = Server.MapPath("Download");
                path = path + "\\" + excelFileUpload.FileName;
                string ab = excelFileUpload.FileName;

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    excelFileUpload.SaveAs(path);
                }
                else
                {
                    excelFileUpload.SaveAs(path);
                }
            }

            string strQuery = "Select * From [Sheet1$]";
            DataSet dscount = GetDataTable(strQuery);

            FetchData(dscount);

            lblStatus.Text = "Record Added Successfully..!!!";
            lblStatus.Font.Bold = true;
            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Visible = true;

            //gvExportToExcel.DataSource = dscount.Tables[0];
            //gvExportToExcel.DataBind();
        }
        catch (Exception ex)
        {
            lblStatus.Text = "ERROR : " + ex;
            lblStatus.Font.Bold = true;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Visible = true;
        }
    }
    public void FetchData(DataSet excelDS)
    {

        string NameOfAccused = string.Empty;
        string Date = string.Empty;
        string Time = string.Empty;
        string Location = string.Empty;
        string SDescp = string.Empty;
        string Relative = string.Empty;
        string Relation = string.Empty;
        string PVisit = string.Empty;
        string MDescp = string.Empty;
        string EnteryMobileNo = string.Empty;
        for (int k = 0; k < excelDS.Tables[0].Rows.Count; k++)
        {
            //Id = Convert.ToInt32(excelDS.Tables[0].Rows[k][0]);
            NameOfAccused = excelDS.Tables[0].Rows[k][0].ToString();
            Date = excelDS.Tables[0].Rows[k][1].ToString();
            Time = excelDS.Tables[0].Rows[k][2].ToString();
            Location = excelDS.Tables[0].Rows[k][3].ToString();
            SDescp = excelDS.Tables[0].Rows[k][4].ToString();
            Relative = excelDS.Tables[0].Rows[k][5].ToString();
            Relation = excelDS.Tables[0].Rows[k][6].ToString();
            PVisit = excelDS.Tables[0].Rows[k][7].ToString();
            MDescp=excelDS.Tables[0].Rows[k][8].ToString();
            //if ((Id).ToString() != "" && Id != "")
            //{
            //    //string SqlQuery1 = " Select StudName From tblSocialWelFareResult Where CenterIdNo='" + centerIdNo + "' and UserIdNo='" + userIdNo + "'";
            //string student = cc.ExecuteScalar(SqlQuery1);

            //if (student != "")
            //{
            //}
            //else
            //{
            string str=DateTime.Now.Date.ToString("yyyy-MM-dd");
            string SqlQuery = "Insert Into [Come2myCityDB].[dbo].[tbl_EventDeath]([NameOfAccused],[Date],[Time],[Location],[SDescp],[Relative],[Relation],[PVisit],[MDescp],[UserId],[CurrentDate])" +
                             " values(N'" + NameOfAccused + "',N'" + Date + "',N'" + Time + "',N'" + Location + "',N'" + SDescp + "',N'" + Relative + "',N'" + Relation + "',N'" + PVisit + "',N'" + MDescp + "','" + Session["User"].ToString() + "','" + str + "')";
            //string SqlQuery = " Insert Into tblSocialWelFareResult(SNO,StudName,HostelName,Location,CenterIdNo,UserIdNo,ExamDate,TotalMarks,Grades,Result) " +
            //                  " Values (" + SNO + ",'" + stuName + "','" + hostelName + "','" + location + "','" + centerIdNo + "','" + userIdNo + "','" + exDate + "','" + totMark + "','" + grades1 + "','" + result1 + "') ";
            DataSet ds = cc.ExecuteDataset(SqlQuery);

            //}
            //}
        }
    }

    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        string filePath = Server.MapPath("Download\\" + excelFileUpload.FileName);
        {
            string conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(conPath);
            try
            {
                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
                tempDs = new DataSet();
                adapter.Fill(tempDs);
            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
            conn.Close();
        }
        return tempDs;

    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Download/Death.xlsx");
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}


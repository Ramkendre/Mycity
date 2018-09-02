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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading;


public partial class html_EventMyct : System.Web.UI.Page
{
    EventMyctBLL objEventMyctBLL = new EventMyctBLL();
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
         string UserIdSession = Convert.ToString(Session["User"]);
         if (UserIdSession == "")
         {
             Response.Redirect("../default.aspx");
         }
         else
         {
             if (!IsPostBack)
             {
                 LoadGrid();
                 Clear();
             }
         }
    }

    

    public void LoadGrid()
    {
        try
        {
          
            objEventMyctBLL.MyCt_UserId1 = Convert.ToString(Session["User"].ToString());
            DataSet ds = objEventMyctBLL.LoadgridBLL(objEventMyctBLL);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
            foreach (GridViewRow row in gvItem.Rows)
            {
                string Data = row.Cells[5].Text.ToString();
                //Data = DateSplit(Data);
                
                row.Cells[5].Text = Data;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //public void LoadGrid1()
    //{
    //    //objEventMeetingBLL.UserId1 = Convert.ToString(Session["User"]);
    //    objEventMyctBLL.usrMobileNo1 = Convert.ToString(Session["MobileNo"]);
    //    DataSet ds = objEventMyctBLL.LoadGrid1BLL(objEventMyctBLL);
    //    if (ds != null && ds.Tables[0].Rows.Count != 0)
    //    {
    //        gvItem1.DataSource = ds.Tables[0];
    //        gvItem1.DataBind();
    //    }
    //}
    //------------------------------Local---------
    //public string DateSplit(string data)
    //{
    //    string[] dt = data.Split(' ');
    //    string[] Dts = dt[0].Split('-');
    //    data = Dts[2] + "/" + Dts[1] + "/" + Dts[0];
    //    return data;
    //}

    //------------------------------Server---------

    //public string DateSplit(string data)
    //{
    //    string[] dt = data.Split(' ');
    //    string[] Dts = dt[0].Split('/');
    //    data = Dts[1] + "/" + Dts[0] + "/" + Dts[2];
    //    return data;
    //}

    

    public void Clear()
    {
        txtBrideName.Text = "";
        txtGroom.Text = "";
        txtDateOfMgs.Text = "";
        txtLocation.Text = "";
        txtTime.Text = "";
        txtPersonName.Text = "";
        rbtnPvisit.Text = "";
        txtTextMgs.Text = "";
        
        lblId.Text = "";
        btnSubmit.Text = "Submit";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string Id = Convert.ToString(lblId.Text.ToString());

        if (Id == "" || Id == null)
        {
            AddRecord();
        }
        else
        {
            UpdateRecord(Id);
        }
    }
    public void AddRecord()
     {
        try
        {
           // string Start = StartTime.Hour.ToString() + ":" + StartTime.Minute.ToString() + ":00";
          
            objEventMyctBLL.BrideName1 = Convert.ToString(txtBrideName.Text);
            objEventMyctBLL.GroomName1 = Convert.ToString(txtGroom.Text);
            objEventMyctBLL.InvitionFrom1 = Convert.ToString(rdbInvite.Text);
            objEventMyctBLL.Date1 = Convert.ToString(txtDateOfMgs.Text);
            objEventMyctBLL.Time1 = Convert.ToString(txtTime.Text);
            objEventMyctBLL.Location1 = Convert.ToString(txtLocation.Text);
            objEventMyctBLL.RemDate1 = Convert.ToString(txtRemDate.Text);
            objEventMyctBLL.RemTime1 = Convert.ToString(txtRemTime.Text);
            objEventMyctBLL.MobileNumber1 = Convert.ToString(txtMobileNo.Text);
            objEventMyctBLL.PersonName1 = Convert.ToString(txtPersonName.Text);
            objEventMyctBLL.PVisit1 = Convert.ToString(rbtnPvisit.Text);
            objEventMyctBLL.MyCt_UserId1 = Convert.ToString(Session["User"].ToString());
            objEventMyctBLL.MDescp1 = Convert.ToString(txtTextMgs.Text);

        
            int status = objEventMyctBLL.AddrecordBll(objEventMyctBLL);
            if (status == 1)
            {
                LoadGrid();
                Clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event not Added Successfully')", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void UpdateRecord(string Id)
    {
        try
        {

            //  string Start = StartTime.Hour.ToString() + ":" + StartTime.Minute.ToString() + ":00";
            objEventMyctBLL.Id1 = Convert.ToInt16(Id);
            objEventMyctBLL.BrideName1 = Convert.ToString(txtBrideName.Text);
            objEventMyctBLL.GroomName1 = Convert.ToString(txtGroom.Text);
            objEventMyctBLL.InvitionFrom1 = Convert.ToString(rdbInvite.Text);
            objEventMyctBLL.Date1 = Convert.ToString(txtDateOfMgs.Text);
            objEventMyctBLL.Time1 = Convert.ToString(txtTime.Text);
            objEventMyctBLL.RemDate1 = Convert.ToString(txtRemDate.Text);
            objEventMyctBLL.RemTime1 = Convert.ToString(txtRemTime.Text);
            objEventMyctBLL.Location1 = Convert.ToString(txtLocation.Text);
            objEventMyctBLL.PersonName1 = Convert.ToString(txtPersonName.Text);
            objEventMyctBLL.MobileNumber1 = Convert.ToString(txtMobileNo.Text);
            
            objEventMyctBLL.PVisit1 = Convert.ToString(rbtnPvisit.Text);
            objEventMyctBLL.MyCt_UserId1 = Convert.ToString(Session["User"].ToString());
            objEventMyctBLL.MDescp1 = Convert.ToString(txtTextMgs.Text);
  

            //objEventMyctBLL.SendMgs1 = Convert.ToString(txtTextMgs.Text);


            int status = objEventMyctBLL.UpdaterecordBll(objEventMyctBLL);
            if (status == 1)
            {
                LoadGrid();
                Clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Updated Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event not Updated Successfully')", true);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (Convert.ToString(e.CommandName) == "Modify")
    //    {
    //        btnSubmit.Text = "Update";
    //        string Id = Convert.ToString(e.CommandArgument);
    //        lblId.Text = Id;
    //        objEventMyctBLL.Id1 = Convert.ToInt16(Id);
    //        objEventMyctBLL.Selectrecord(objEventMyctBLL);

    //        //txtBrideName.Text = Convert.ToString(objEventMyctBLL.BrideName1);
    //        //txtGroom.Text = Convert.ToString(objEventMyctBLL.GroomName1);
    //        rdbInvite.Text = Convert.ToString(objEventMyctBLL.InvitionFrom1);
    //        //txtDateOfMgs.Text = Convert.ToString(DateSplitUpdate(objEventMyctBLL.DateOfMgs1));
    //        txtTime.Text= Convert.ToString(objEventMyctBLL.Time1);
    //        txtLocation.Text = Convert.ToString(objEventMyctBLL.Location1);
    //        txtMobileNo.Text=Convert.ToString(objEventMyctBLL.MobileNumber1);
    //        txtPersonName.Text=Convert.ToString(objEventMyctBLL.PersonName1);
    //        rbtnPvisit.Text = Convert.ToString(objEventMyctBLL.PVisit1);
    //        txtTextMgs.Text=Convert.ToString(objEventMyctBLL.MDescp1);
            
    //        //txtTextMgs.Text = Convert.ToString(objEventMyctBLL.SendMgs1);
    //        //string[] tmp = Data.Split(':');
    //        //if (Convert.ToInt32(tmp[0].ToString()) < 12)
    //        //{
    //        //    StartTime.SetTime(Convert.ToInt32(tmp[0].ToString()), Convert.ToInt32(tmp[1].ToString()), Convert.ToInt32(tmp[2].ToString()), MKB.TimePicker.TimeSelector.AmPmSpec.AM);
    //        //}
    //        //else
    //        //{
    //        //    StartTime.SetTime(Convert.ToInt32(tmp[0].ToString()), Convert.ToInt32(tmp[1].ToString()), Convert.ToInt32(tmp[2].ToString()), MKB.TimePicker.TimeSelector.AmPmSpec.PM);
    //        //}
    //    }
    //    //if (Convert.ToString(e.CommandName) == "Print")
    //    //{
    //    //    string Id = Convert.ToString(e.CommandArgument);
    //    //    lblId.Text = Id;
    //    //    Response.Redirect("EventPrint.aspx?Id=" + Id + "");
    //    //    objEventMyctBLL.Id1 = Convert.ToInt16(Id);
    //    //    int status = objEventMyctBLL.DeleterecordBll(objEventMyctBLL);
    //    //    if (status == -1)
    //    //    {
    //    //        LoadGrid();
    //    //        Clear();
    //    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Delete Successfully')", true);
    //    //    }
    //    //    else
    //    //    {
    //    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event not Delete Successfully')", true);
    //    //    //}
    //    //}
    //}

    //public string DateSplitUpdate(string data)
    //{
    //    string[] dt = data.Split(' ');
    //    string[] Dts = dt[0].Split('/');
    //    data = Dts[2] + "-" + Dts[0] + "-" + Dts[1];
    //    return data;
    //}

    //protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{

    //}
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }


    protected void gvItem_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSubmit.Text = "Update";
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            objEventMyctBLL.Id1 = Convert.ToInt16(Id);
            objEventMyctBLL.Selectrecord(objEventMyctBLL);

            txtBrideName.Text = Convert.ToString(objEventMyctBLL.BrideName1);
            txtGroom.Text = Convert.ToString(objEventMyctBLL.GroomName1);
            rdbInvite.Text = Convert.ToString(objEventMyctBLL.InvitionFrom1);
            txtDateOfMgs.Text = Convert.ToString(objEventMyctBLL.Date1);
            //txtDateOfMgs.Text = Convert.ToString(DateSplitUpdate(objEventMyctBLL.DateOfMgs1));
            txtTime.Text = Convert.ToString(objEventMyctBLL.Time1);
            txtRemDate.Text = Convert.ToString(objEventMyctBLL.RemDate1);
            txtRemTime.Text = Convert.ToString(objEventMyctBLL.RemTime1);
            txtLocation.Text = Convert.ToString(objEventMyctBLL.Location1);
            txtMobileNo.Text = Convert.ToString(objEventMyctBLL.MobileNumber1);
            txtPersonName.Text = Convert.ToString(objEventMyctBLL.PersonName1);
            rbtnPvisit.Text = Convert.ToString(objEventMyctBLL.PVisit1);
            txtTextMgs.Text = Convert.ToString(objEventMyctBLL.MDescp1);

            //txtTextMgs.Text = Convert.ToString(objEventMyctBLL.SendMgs1);
            //string[] tmp = Data.Split(':');
            //if (Convert.ToInt32(tmp[0].ToString()) < 12)
            //{
            //    StartTime.SetTime(Convert.ToInt32(tmp[0].ToString()), Convert.ToInt32(tmp[1].ToString()), Convert.ToInt32(tmp[2].ToString()), MKB.TimePicker.TimeSelector.AmPmSpec.AM);
            //}
            //else
            //{
            //    StartTime.SetTime(Convert.ToInt32(tmp[0].ToString()), Convert.ToInt32(tmp[1].ToString()), Convert.ToInt32(tmp[2].ToString()), MKB.TimePicker.TimeSelector.AmPmSpec.PM);
            //}
        }
        if (Convert.ToString(e.CommandName) == "Delete")
        {
            string Id = Convert.ToString(e.CommandArgument);
            lblId.Text = Id;
            objEventMyctBLL.Id1 = Convert.ToInt16(Id);
            con.Open();
            string str = "Delete From [Come2myCityDB].[dbo].[tbl_EventMyCt] where Id='"+Id+"'";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    protected void gvItem_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gvItem_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

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
        string Id = string.Empty;
        string BrideName = string.Empty;
        string GroomName = string.Empty;
        string InvitionFrom = string.Empty;
        string Date = string.Empty;
        string Time = string.Empty;
        string Location = string.Empty;
        string PersonName = string.Empty;
        string MobileNumber = string.Empty;
        string PVisit = string.Empty;
        string MDescp = string.Empty;
        string EnteryMobileNo=string.Empty;
        for (int k = 0; k < excelDS.Tables[0].Rows.Count; k++)
        {
            //Id = Convert.ToInt32(excelDS.Tables[0].Rows[k][0]);
            BrideName = excelDS.Tables[0].Rows[k][0].ToString();
            GroomName = excelDS.Tables[0].Rows[k][1].ToString();
            InvitionFrom = excelDS.Tables[0].Rows[k][2].ToString();
            Date = excelDS.Tables[0].Rows[k][3].ToString();
            Time = excelDS.Tables[0].Rows[k][4].ToString();
            Location = excelDS.Tables[0].Rows[k][5].ToString();
            PersonName = excelDS.Tables[0].Rows[k][6].ToString();
            MobileNumber = excelDS.Tables[0].Rows[k][7].ToString();
            PVisit = excelDS.Tables[0].Rows[k][8].ToString();
            MDescp = excelDS.Tables[0].Rows[k][9].ToString();

            //if ((Id).ToString() != "" && Id != "")
            //{
            //    //string SqlQuery1 = " Select StudName From tblSocialWelFareResult Where CenterIdNo='" + centerIdNo + "' and UserIdNo='" + userIdNo + "'";
                //string student = cc.ExecuteScalar(SqlQuery1);

                //if (student != "")
                //{
                //}
                //else
                //{
            
                string SqlQuery = "Insert Into tbl_EventMyCt(BrideName,GroomName,InvitionFrom,Date,Time,Location,PersonName,MobileNumber,PVisit,MDescp,MyCt_UserId)" +
                                 " values(N'" + BrideName + "',N'" + GroomName + "',N'" + InvitionFrom + "',N'" + Date + "',N'" + Time + "',N'" + Location + "',N'" + PersonName + "',N'" + MobileNumber + "',N'" + PVisit + "',N'" + MDescp + "','" + Session["User"].ToString() + "')";
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

    protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "Delete From [Come2myCityDB].[dbo].[tbl_EventMyCt] where MyCt_UserId='"+Session["User"].ToString()+"'";
        SqlCommand cmd = new SqlCommand(str,con);
        cmd.ExecuteNonQuery();
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        //try
        //{

        //    Response.ContentType = "application/vnd.ms-excel";
        //    string fileName = Server.MapPath("~\\Download\\marriage.xlsx");

        //    Response.AppendHeader("Content-Disposition", "attachment; filename=marriage.xlsx");

        //    //Specify the file name which needs to be displayed while prompting

        //    Response.TransmitFile(fileName);

        //    Response.End();

        //}

        //catch (ThreadAbortException ex)
        //{
        //    throw;
        //}
        Response.Redirect("../Download/marriage.xlsx");
    }
}

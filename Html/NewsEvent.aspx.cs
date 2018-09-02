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
using Microsoft.ApplicationBlocks.Data;
using System.Data.OleDb;
using System.Threading;
using System.ComponentModel;
using System.Text;

public partial class html_NewsEvent : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    EventNewsBLL objEventNewsBLL = new EventNewsBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
   
    //gridbind gb = new gridbind();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String UserSessionId = Convert.ToString(Session["User"]);
        //string MobileNo = Convert.ToString(Session["usrMobileNo"]);
        MultiView1.SetActiveView(View1);
            if(UserSessionId=="")
            {
                Response.Redirect("../Default.aspx");
            }
            else
            {
                if(!IsPostBack)
                {
                    LoadGrid();
                    fillddl();
                    clear();
                }
            }
    }
    public void LoadGrid()
    {
        objEventNewsBLL.UserId1 = Convert.ToString(Session["User"].ToString());
        DataSet ds = objEventNewsBLL.LoadGridBLL(objEventNewsBLL);
        if(ds.Tables[0].Rows.Count!=0)
        {
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
        
        
        
    }
    //public void LoadGrid1()
    //{
    //    //objEventNewsBLL.usrMobileNo1 = Convert.ToString(Session["MobileNo"].ToString());
    //    DataSet ds = objEventNewsBLL.LoadGridBLL1(objEventNewsBLL);
    //    if (ds.Tables[0].Rows.Count != 0)
    //    {
    //        gvItem1.DataSource = ds.Tables[0];
    //        gvItem1.DataBind();
    //    }
    //}
    public void Addrecord()
    {
        string str=null;
        string sql = null;
        if (txtNPaper.Text != "")
        {
            str = txtNPaper.Text;
            string str1 = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='"+str+"'";
             sql = cc.ExecuteScalar(str1);
        }
        else if (DDLNPaper.SelectedItem.Text != "")
        {
            str = DDLNPaper.SelectedItem.Text;
            string str1 = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='"+str+"'";
             sql = cc.ExecuteScalar(str1);
        }
        
        objEventNewsBLL.UserId1 = Convert.ToString(Session["User"]);
        objEventNewsBLL.NewsHead1 = Convert.ToString(txtNewsHead.Text);
        objEventNewsBLL.NewsDetails1 = Convert.ToString(txtNDetails.Text);
        objEventNewsBLL.NPaper1 = Convert.ToString(sql);
        objEventNewsBLL.Role1 = Convert.ToString(txtRole.Text);
        objEventNewsBLL.Date1 = Convert.ToString(txtDate.Text);
        objEventNewsBLL.Time1 = Convert.ToString(txtTime.Text);
        objEventNewsBLL.TypeOfNews1 = Convert.ToString(rbtnTONews.Text);
        objEventNewsBLL.Location1 = Convert.ToString(txtLocation.Text);
        objEventNewsBLL.Feedback1 = Convert.ToString(txtFeedback.Text);
        objEventNewsBLL.UserId1 = Convert.ToString(Session["User"].ToString());
        int Status = objEventNewsBLL.AddRecordBLL(objEventNewsBLL);
        if (Status == 1)
        {

            LoadGrid();
            clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void UpdateRecord(string NID)
    {
        string sql1 = null;
        string str1 = null;
        try
        {
            

            if (DDLNPaper.SelectedItem.Text != "")
            {
                str1 = DDLNPaper.SelectedItem.Text;
                string str2 = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str1 + "'";
              sql1 = cc.ExecuteScalar(str2);
            }
        objEventNewsBLL.NID1 = Convert.ToInt16(NID);
        objEventNewsBLL.NewsHead1 = Convert.ToString(txtNewsHead.Text);
        objEventNewsBLL.NewsDetails1 = Convert.ToString(txtNDetails.Text);
        objEventNewsBLL.NPaper1 = Convert.ToString(sql1);
        objEventNewsBLL.Role1 = Convert.ToString(txtRole.Text);
        objEventNewsBLL.Date1 = Convert.ToString(txtDate.Text);
        objEventNewsBLL.Time1 = Convert.ToString(txtTime.Text);
        objEventNewsBLL.TypeOfNews1 = Convert.ToString(rbtnTONews.Text);
        objEventNewsBLL.Location1 = Convert.ToString(txtLocation.Text);
        objEventNewsBLL.Feedback1 = Convert.ToString(txtFeedback.Text);
        objEventNewsBLL.UserId1 = Convert.ToString(Session["User"].ToString());

        int status = objEventNewsBLL.UpdateBLL(objEventNewsBLL);
        if(status==1)
        {
            LoadGrid();
            clear();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string NID = Convert.ToString(lblId.Text.ToString());
        if (NID == "" || NID == null)
        {
            Addrecord();
        }
        {
            UpdateRecord(NID);
        }
    }
    public void clear()
    {
        lblId.Text = "";
        txtNewsHead.Text = "";
        txtNDetails.Text = "";
        txtDate.Text = "";
        txtFeedback.Text = "";
        //DDLNPaper.Text="";
        txtRole.Text = "";
        txtTime.Text = "";
        rbtnTONews.Text = "";

        btnSubmit.Text = "Submit";
        
    }
    protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
        }
    }


    public void fillddl()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
           
            //string str = "select NPaper as Id from [Come2myCityDB].[dbo].[tbl_EventNews]";
            string str = "select ID,Name from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='1'";

            DataSet ds = new DataSet();
            //SqlCommand cmd = new SqlCommand();

            SqlDataAdapter da = new SqlDataAdapter(str, con);
            da.Fill(ds);
            DDLNPaper.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                DDLNPaper.DataTextField = "Name";
                DDLNPaper.DataValueField = "Id";

            }
            DDLNPaper.DataBind();
            DDLNPaper.Items.Add("Add New");
            DDLNPaper.Items.Add("---Select---");
            DDLNPaper.SelectedIndex = DDLNPaper.Items.Count - 1;
            DDLNPaper.Items[DDLNPaper.Items.Count - 1].Value = "";



        }
        catch (Exception ex)
        {
            throw ex;

        }
        finally
        {
            con.Open();
        }
    
    }
    public void cmbadd(DropDownList ddl, TextBox tb)
    {
        if (DDLNPaper.SelectedItem.Text == "Add New")
        {
            tb.Visible = true;
            tb.Focus();
            tb.Text = "";
            ddl.Visible = false;
        }
    }
    public void txtchange(DropDownList ddl, TextBox tb)
    {
        string str = "insert into [Come2myCityDB].[dbo].[tbl_Main_ID](Sub_ID,Name,UserId)values('1','" + txtNPaper.Text + "','" + Convert.ToString(Session["User"]) + "')";
        DataSet ds = new DataSet();
        int stat= cc.ExecuteNonQuery(str);

        string str1 = "select ID,Name from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='1'";
        ds = cc.ExecuteDataset(str1);

        DDLNPaper.DataSource = ds;
        DDLNPaper.DataTextField = "Name";
        DDLNPaper.DataValueField = "ID";
        DDLNPaper.DataBind();

        DDLNPaper.Items.Insert(0,new ListItem("Select","0"));
        DDLNPaper.SelectedIndex = 0;

        ddl.Visible = true;
        tb.Visible = false;



        //ddl.Items.Add(tb.Text);
        //ddl.SelectedValue = tb.Text;
        //string str = "select * from [Come2myCityDB].[dbo].[tbl_EventNews] where UserId='"+Convert.ToString(Session["User"])+"'";
        //DataSet ds = new DataSet();
        //ds = cc.ExecuteDataset(str);
        //string str2 = Convert.ToString(ds.Tables[0].Rows[0]["NPaper"]);

        //string str1 = "insert into [Come2myCityDB].[dbo].[tbl_Main_ID](Name)values('" + str2 + "')";
        //ds = cc.ExecuteDataset(str1);
        ////ddl.Items.Add(tb.Text);
        ////ddl.SelectedValue = tb.Text;
        //ddl.Visible = true;
        //tb.Visible = false;
    }
    protected void gvItem1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void DDLNPaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmbadd(DDLNPaper, txtNPaper);
    }
    protected void txtNPaper_TextChanged(object sender, EventArgs e)
    {
        txtchange(DDLNPaper,txtNPaper);
    }
    protected void lkbtnShowChlid_Click(object sender, EventArgs e)
    {
        //LoadGrid1();
        MultiView1.Visible = true;
        MultiView1.SetActiveView(View2);


    }
    protected void gvItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "Delete From [Come2myCityDB].[dbo].[tbl_EventNews] where UserId='" + Session["User"].ToString() + "'";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
    }
    protected void lnkdownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Download/News.xlsx");
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

        string NewsHead = string.Empty;
        string NewsDetails = string.Empty;
        string NPaper = string.Empty;
        string Role = string.Empty;
        string Date = string.Empty;
        string Time = string.Empty;
        string TypeOfNews = string.Empty;
        string Location = string.Empty;
        string Feedback = string.Empty;
        string EnteryMobileNo = string.Empty;
        for (int k = 0; k < excelDS.Tables[0].Rows.Count; k++)
        {
            //Id = Convert.ToInt32(excelDS.Tables[0].Rows[k][0]);
            NewsHead = excelDS.Tables[0].Rows[k][0].ToString();
            NewsDetails = excelDS.Tables[0].Rows[k][1].ToString();
            NPaper = excelDS.Tables[0].Rows[k][2].ToString();
            Role = excelDS.Tables[0].Rows[k][3].ToString();
            Date = excelDS.Tables[0].Rows[k][4].ToString();
            Time = excelDS.Tables[0].Rows[k][5].ToString();
            TypeOfNews = excelDS.Tables[0].Rows[k][6].ToString();
            Location = excelDS.Tables[0].Rows[k][7].ToString();
            Feedback = excelDS.Tables[0].Rows[k][8].ToString();
            //if ((Id).ToString() != "" && Id != "")
            //{
            //    //string SqlQuery1 = " Select StudName From tblSocialWelFareResult Where CenterIdNo='" + centerIdNo + "' and UserIdNo='" + userIdNo + "'";
            //string student = cc.ExecuteScalar(SqlQuery1);

            //if (student != "")
            //{
            //}
            //else
            //{
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string SqlQuery = "Insert Into [Come2myCityDB].[dbo].[tbl_EventNews]([NewsHead],[NewsDetails],[NPaper],[Role],[Date],[Time],[TypeOfNews],[Location],[Feedback],[UserId],[CurrentDate])" +
                             " values(N'" + NewsHead + "',N'" + NewsDetails + "',N'" + NPaper + "',N'" + Role + "',N'" + Date + "',N'" + Time + "',N'" + TypeOfNews + "',N'" + Location + "',N'" + Feedback + "','" + Session["User"].ToString() + "','" + str + "')";
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
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    
    {
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            btnSubmit.Text = "Update";
            string NID = Convert.ToString(e.CommandArgument);
            lblId.Text = NID;
            objEventNewsBLL.NID1 = Convert.ToInt16(NID);
            objEventNewsBLL.SelectRecordBLL(objEventNewsBLL);

            txtNewsHead.Text = Convert.ToString(objEventNewsBLL.NewsHead1);
            txtNDetails.Text = Convert.ToString(objEventNewsBLL.NewsDetails1);
            //txtNPaper.Text = Convert.ToString(objEventNewsBLL.NPaper1);
            DDLNPaper.SelectedItem.Text = Convert.ToString(objEventNewsBLL.NPaper1);
            txtRole.Text = Convert.ToString(objEventNewsBLL.Role1);
            txtDate.Text = Convert.ToString(objEventNewsBLL.Date1);
            txtTime.Text = Convert.ToString(objEventNewsBLL.Time1);
            rbtnTONews.Text = Convert.ToString(objEventNewsBLL.TypeOfNews1);
            txtLocation.Text = Convert.ToString(objEventNewsBLL.Location1);
            txtFeedback.Text = Convert.ToString(objEventNewsBLL.Feedback1);
        }
        if (Convert.ToString(e.CommandName) == "Delete")
        {

            string NID = Convert.ToString(e.CommandArgument);
            lblId.Text = NID;
            objEventNewsBLL.NID1 = Convert.ToInt16(NID);
            
            if(NID!=null && NID!="")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Do u want delete')", true);
                con.Open();
                string str = "Delete from [Come2myCityDB].[dbo].[tbl_EventNews] where NID='" + NID + "' ";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

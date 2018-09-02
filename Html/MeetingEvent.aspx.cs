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

public partial class html_MeetingEvent : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    EventMeetingBLL objEventMeetingBLL = new EventMeetingBLL();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        String UserIdSession = Convert.ToString(Session["User"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Loadgrid();
                fillDDL();
            }
        }
    }
    public void Loadgrid()
    {
        objEventMeetingBLL.UserId1 = Convert.ToString(Session["User"]);
        DataSet ds = objEventMeetingBLL.LoadgridBLL(objEventMeetingBLL);
        if (ds != null && ds.Tables[0].Rows.Count != 0)
        {
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
    }
    //public void LoadGrid1()
    //{
    //    //objEventMeetingBLL.UserId1 = Convert.ToString(Session["User"]);
    //    objEventMeetingBLL.usrMobileNo1 = Convert.ToString(Session["MobileNo"]);
    //    DataSet ds = objEventMeetingBLL.LoadGrid1BLL(objEventMeetingBLL);
    //    if (ds != null && ds.Tables[0].Rows.Count != 0)
    //    {
    //        gvItem1.DataSource = ds.Tables[0];
    //        gvItem1.DataBind();
    //    }
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    
    {
        String ID = Convert.ToString(lblId.Text.ToString());
        if (ID == "" || ID == null)
        {
            Addrecord();
        }
        else
        {
            Update(ID);
        }
    }
    public void fillDDL()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        try
        {
            //string str = "select MeetingType as Id from tbl_EventMeeting";
            string str = "select Name as Id from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='2' and UserId='" + Convert.ToString(Session["User"]) + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(str,con);
            da.Fill(ds);
            DDLMeetingType.DataSource = ds.Tables[0];
            if(ds.Tables[0].Rows.Count>0)
            {
                DDLMeetingType.DataValueField = "Id";
            }
            DDLMeetingType.DataBind();
            DDLMeetingType.Items.Add("Add New");
            DDLMeetingType.Items.Add("Select");
            DDLMeetingType.Items.Insert(0, new ListItem("Select","0" ));
            DDLMeetingType.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void cmbadd(DropDownList ddl, TextBox tb)
    {
        if (DDLMeetingType.SelectedItem.Text == "Add New")
        {
            tb.Visible = true;
            tb.Focus();
            tb.Text = "";
            ddl.Visible = false;
        }
    }
    public void txtChange(DropDownList ddl,TextBox tb)
    {
        string str1 = "select ID,Name from[Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='2'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str1);
        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        {
            if(Convert.ToString(txtMeetingType.Text)==Convert.ToString(ds.Tables[0].Rows[i]["Name"]))
            {
            ViewState["abc"]=txtMeetingType.Text;
            }
        }
        if(Convert.ToString(txtMeetingType.Text)==Convert.ToString(ViewState["abc"]))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('this type of Status Already Present')", true);
            DDLMeetingType.Visible = true;
          txtMeetingType.Visible = false;
            ViewState["abc"] = null;
        }
        else
        {
            string st = txtMeetingType.Text.ToUpper();
        string str = "insert into [Come2myCityDB].[dbo].[tbl_Main_ID](Sub_ID,Name,UserId)values('2','"+txtMeetingType.Text+"','"+Convert.ToString(Session["User"])+"')";
        int status = cc.ExecuteNonQuery(str);
        

        DDLMeetingType.DataSource = ds;
        DDLMeetingType.DataTextField = "Name";
        DDLMeetingType.DataValueField = "ID";
        DDLMeetingType.DataBind();

        DDLMeetingType.Items.Insert(0,new ListItem("0","Select"));
        DDLMeetingType.SelectedIndex = 0;

        ddl.Visible = true;
        tb.Visible = false;
        }
    }
    public void Addrecord()
    {
        string str, sql;
        if(txtMeetingType.Text!="")
        {

            str = txtMeetingType.Text;
            string str1="select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='"+str+"'";
            sql=cc.ExecuteScalar(str1);
        }
        else
        {
        str=DDLMeetingType.SelectedItem.Text;
        string str1 = "select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str + "'";
        sql = cc.ExecuteScalar(str1);
        }
        objEventMeetingBLL.ETitle1 = Convert.ToString(txtETitle.Text);
        objEventMeetingBLL.MeetingType1 = Convert.ToString(sql);
        objEventMeetingBLL.Location1 = Convert.ToString(txtLocation.Text);
        objEventMeetingBLL.FrmTime1 = Convert.ToString(txtFTime.Text);
        objEventMeetingBLL.FrmDate1 = Convert.ToString(txtFDate.Text);
        objEventMeetingBLL.UptoDate1 = Convert.ToString(txtUDate.Text);
        objEventMeetingBLL.UptoTime1 = Convert.ToString(txtUTime.Text);
        objEventMeetingBLL.RemDate1 = Convert.ToString(txtRemDate.Text);
        objEventMeetingBLL.RemTime1 = Convert.ToString(txtRemTime.Text);
        objEventMeetingBLL.Descp1 = Convert.ToString(txtDescp.Text);
        objEventMeetingBLL.RepRemainder1 = Convert.ToString(rbtnRRemainder.Text);
        objEventMeetingBLL.UserId1 = Convert.ToString(Session["User"].ToString());
        int Status = objEventMeetingBLL.AddRecordBLL(objEventMeetingBLL);
        if (Status == 1)
        {
            Loadgrid();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
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
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Modify")
        {
            btnSubmit.Text = "Update";
            string ID = Convert.ToString(e.CommandArgument);
            lblId.Text = ID;
            objEventMeetingBLL.ID1 = Convert.ToInt16(ID);
            objEventMeetingBLL.SelectRecordBLL(objEventMeetingBLL);

            txtETitle.Text = Convert.ToString(objEventMeetingBLL.ETitle1);
            DDLMeetingType.Text = Convert.ToString(objEventMeetingBLL.MeetingType1);
            txtLocation.Text = Convert.ToString(objEventMeetingBLL.Location1);
            txtFDate.Text = Convert.ToString(objEventMeetingBLL.FrmDate1);
            txtUDate.Text = Convert.ToString(objEventMeetingBLL.UptoDate1);
            txtFTime.Text = Convert.ToString(objEventMeetingBLL.FrmTime1);
            txtUTime.Text = Convert.ToString(objEventMeetingBLL.UptoTime1);
            txtDescp.Text = Convert.ToString(objEventMeetingBLL.Descp1);
            txtRemDate.Text = Convert.ToString(objEventMeetingBLL.RemDate1);
            txtRemTime.Text = Convert.ToString(objEventMeetingBLL.RemTime1);
            rbtnRRemainder.Text = Convert.ToString(objEventMeetingBLL.RepRemainder1);
       }

        if (Convert.ToString(e.CommandName) == "Delete")
        {
            string ID = Convert.ToString(e.CommandArgument);
            lblId.Text = ID;
            objEventMeetingBLL.ID1 = Convert.ToInt16(ID);
            string str= "Delete from [Come2myCityDB].[dbo].[tbl_EventMeeting] where ID='"+ID+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
    public void Update(string ID)
    {
        try{
        objEventMeetingBLL.ID1 = Convert.ToInt16(ID);
        objEventMeetingBLL.ETitle1 = Convert.ToString(txtETitle.Text);
        objEventMeetingBLL.MeetingType1 = Convert.ToString(DDLMeetingType.Text);
        objEventMeetingBLL.Location1 = Convert.ToString(txtLocation.Text);
        objEventMeetingBLL.FrmDate1 = Convert.ToString(txtFDate.Text);
        objEventMeetingBLL.UptoDate1 = Convert.ToString(txtUDate.Text);
        objEventMeetingBLL.UptoTime1 = Convert.ToString(txtUTime.Text);
        objEventMeetingBLL.FrmTime1 = Convert.ToString(txtFTime.Text);
        objEventMeetingBLL.RemDate1 = Convert.ToString(txtRemDate.Text);
        objEventMeetingBLL.RemTime1 = Convert.ToString(txtRemTime.Text);
        objEventMeetingBLL.RepRemainder1 = Convert.ToString(rbtnRRemainder.Text);
        objEventMeetingBLL.Descp1 = Convert.ToString(txtDescp.Text);
        objEventMeetingBLL.UserId1 = Convert.ToString(Session["User"]);
        int Status = objEventMeetingBLL.UpdateBLL(objEventMeetingBLL);
        if(Status==1)
        {
            Loadgrid();
            //Clear();
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
    //protected void txtMeetingType_TextChanged(object sender, EventArgs e)
    //{
    //    txtChange(DDLMeetingType,txtMeetingType);
    //}

    protected void DDLMeetingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmbadd(DDLMeetingType, txtMeetingType);
    }
    protected void txtMeetingType_TextChanged(object sender, EventArgs e)
    {
        txtChange(DDLMeetingType, txtMeetingType);
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
        string ETitle = string.Empty;
        string MeetingType = string.Empty;
        string Location = string.Empty;
        string FrmDate = string.Empty;
        string UptoDate = string.Empty;
        string FrmTime = string.Empty;
        string UptoTime = string.Empty;
        
        string Descp = string.Empty;
       
        string EnteryMobileNo = string.Empty;
        for (int k = 0; k < excelDS.Tables[0].Rows.Count; k++)
        {
            //Id = Convert.ToInt32(excelDS.Tables[0].Rows[k][0]);
            ETitle = excelDS.Tables[0].Rows[k][0].ToString();
            MeetingType = excelDS.Tables[0].Rows[k][1].ToString();
            Location = excelDS.Tables[0].Rows[k][2].ToString();
            FrmDate = excelDS.Tables[0].Rows[k][3].ToString();
            UptoDate = excelDS.Tables[0].Rows[k][4].ToString();
            FrmTime=excelDS.Tables[0].Rows[k][5].ToString();
            UptoTime=excelDS.Tables[0].Rows[k][6].ToString();
           
            Descp = excelDS.Tables[0].Rows[k][7].ToString();
           
            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string SqlQuery = "Insert Into [Come2myCityDB].[dbo].[tbl_EventMeeting]([ETitle],[MeetingType],[Location],[FrmDate],[UptoDate],[FrmTime],[UptoTime],[Descp],[UserId],[CurrentDate])" +
                             " values(N'" + ETitle + "',N'" + MeetingType + "',N'" + Location + "',N'" + FrmDate + "',N'" + UptoDate + "',N'" + FrmTime + "',N'" + UptoTime + "',N'" + Descp + "','" + Session["User"].ToString() + "','"+str+"')";
           
            DataSet ds = cc.ExecuteDataset(SqlQuery);

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

    protected void lnkDownloadE_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Download/Meeting.xlsx");
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

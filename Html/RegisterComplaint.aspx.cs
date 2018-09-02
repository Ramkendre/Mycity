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
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;


public partial class html_RegisterComplaint : System.Web.UI.Page
{
    EventComplaintBLL objECBLL = new EventComplaintBLL();
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        //DataColumn dc = new DataColumn("CompType");
        
        //dt.Columns.Add(dc);
        
        //ds.Tables.Add(dt);
        //Session["data"] = ds;
        string UserIdSession = Convert.ToString(Session["User"]);
        MultiView1.SetActiveView(View1);
        
        //Loadgrid1();
        //MultiView1.SetActiveView(View2);
        //string UserMobileNo = Convert.ToString(Session["MobileNo"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Loadgrid();
                fillDDL();
                fillDDL1();
               // getDate();
            }
        }
       
    }
    DataTable dt;
    //public void getDate()
    //{
    //    SqlDataAdapter da = new SqlDataAdapter("select * from [Come2myCityDB].[dbo].[tbl_EventComplaint]", con);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    gvItem.DataSource = dt;
    //    gvItem.DataBind();
    //}

    public void Loadgrid()
    {
        try
        {
        objECBLL.UserId1 = Convert.ToString(Session["User"].ToString());
        //objECBLL.UsrMobileNo1 = Convert.ToString(Session["MobileNo"].ToString());

        DataSet ds = objECBLL.LoadGridBLL(objECBLL);
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
    //public void Loadgrig1()
    //{
    //    try
    //    {
    //        objECBLL.UsrMobileNo1 = Convert.ToString(Session["MobileNo"].ToString());
    //        DataSet ds = objECBLL.LoadGridBLL1(objECBLL);

    //    }
    //    catch (Exception ex)
    //    { }
    //}
    public void Loadgrid1()
    {
        try
        {
            //objECBLL.UserId1 = Convert.ToString(Session["User"].ToString());
            objECBLL.UsrMobileNo1 = Convert.ToString(Session["MobileNo"].ToString());
            DataSet ds = objECBLL.LoadGridBLL1(objECBLL);
            gvItem1.DataSource = ds.Tables[0];
            gvItem1.DataBind();
            foreach (GridViewRow row in gvItem1.Rows)
            {
                String data1 = row.Cells[5].Text.ToString();
                row.Cells[5].Text = data1;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    public void Addrecord()
    {
        string str, result;
        if (txtCType.Text != "")
        {
            str = txtCType.Text;
            string sql = "select (ID) from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str + "' ";
            result = cc.ExecuteScalar(sql);
        }
        else
        {
            str = DDLCType.SelectedItem.Text;
            string sql = "select (ID) from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str + "' ";
             result = cc.ExecuteScalar(sql);
        }
        string str1,result1;
        if (txtCFDept.Text != "")
        {
            str1 = txtCFDept.Text;
            string sql1 = "select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str1 + "' ";
            result1 = cc.ExecuteScalar(sql1);
        }
        else
        {
            str1 = DDLCFDept.SelectedItem.Text;
            string sql1 = "select max(ID) from [Come2myCityDB].[dbo].[tbl_Main_ID] where Name='" + str1 + "' ";
            result1 = cc.ExecuteScalar(sql1);
        }

        objECBLL.UserId1 = Convert.ToString(Session["User"]);
        objECBLL.CompType1 = Convert.ToString(result);
        objECBLL.Date1 = Convert.ToString(txtdate.Text);
        objECBLL.CompFDept1 = Convert.ToString(result1);
        objECBLL.CompName1 = Convert.ToString(txtCName.Text);
        objECBLL.CompSub1 = Convert.ToString(txtCSub.Text);
        objECBLL.CompDetails1 = Convert.ToString(txtCDetails.Text);
        objECBLL.Address1 = Convert.ToString(txtAddress.Text);
        objECBLL.MobileNo1 = Convert.ToString(txtMoblieNo.Text);
        int Status = objECBLL.AddrecordBLL(objECBLL);
        if (Status == 1)
        {
            Loadgrid();
            ////clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }

    public void Updaterecord(string CID)
    {
        objECBLL.CID1 = Convert.ToInt16(CID);
        objECBLL.CompType1 = Convert.ToString(DDLCType.SelectedItem.Text);
        objECBLL.Date1 = Convert.ToString(txtdate.Text);
        objECBLL.CompFDept1 = Convert.ToString(DDLCFDept.SelectedItem.Text);
        objECBLL.CompName1 = Convert.ToString(txtCName.Text);
        objECBLL.CompSub1 = Convert.ToString(txtCSub.Text);
        objECBLL.CompDetails1 = Convert.ToString(txtCDetails.Text);
        objECBLL.Address1 = Convert.ToString(txtAddress.Text);
        objECBLL.MobileNo1 = Convert.ToString(txtMoblieNo.Text);
        objECBLL.UserId1 = Convert.ToString(Session["User"]);

        int Status = objECBLL.UpdateBLL(objECBLL);
        if (Status == 1)
        {
            Loadgrid();
            clear();
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Update Successfully')", true);
        }
    }
 
    protected void btnSubmit_Click1(object sender, EventArgs e)
    {
        string CID = Convert.ToString(lblId.Text.ToString());
        
        if (CID == "" || CID == null)
        {
            Addrecord();
        }
        else
        {
            Updaterecord(CID);
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
    public void clear()
    {
        txtAddress.Text = "";
        txtCDetails.Text = "";
        txtCName.Text = "";
        txtCSub.Text = "";
        txtMoblieNo.Text = "";
    }
    public void fillDDL()
    {
        //string str = "select Name as Id from [Come2myCityDB].[dbo].[tbl_Main_ID] where UserId='" + Session["User"].ToString() + "' and Sub_Id='3'";
        string str = "select ID,Name from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='3'";

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);

        DDLCType.DataSource = ds.Tables[0];

        if(ds.Tables[0].Rows.Count>0)
        {
            DDLCType.DataTextField = "Name";
            DDLCType.DataValueField = "Id";
        }

        DDLCType.DataBind();
        DDLCType.Items.Add("Add New");
        DDLCType.Items.Add("--Select--");

        DDLCType.Items.Insert(0, new ListItem("Select","0"));
        DDLCType.SelectedIndex = 0;

    }
    public void fillDDL1()
    {
        //string str = "select Name as Id from [Come2myCityDB].[dbo].[tbl_Main_ID] where UserId='" + Session["User"].ToString() + "' and AdminUserId='0'";
        string str = "select ID,Name from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='4'";

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);

        DDLCFDept.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            DDLCFDept.DataTextField = "Name";
            DDLCFDept.DataValueField = "Id";
        }
        DDLCFDept.DataBind();
        DDLCFDept.Items.Add("Add New");
        DDLCFDept.Items.Add("select");

        DDLCFDept.Items.Insert(0,new ListItem("select","0"));
        DDLCFDept.SelectedIndex = 0;
    }
    public void txtChange(DropDownList ddl,TextBox tb)
    {
        string str1 = "select ID,Name from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='3'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str1);
        for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
        {
            if(Convert.ToString(txtCType.Text)==Convert.ToString(ds.Tables[0].Rows[i]["Name"]))
            {
                ViewState["abc"] = txtCType.Text;
            }
        }
        if(Convert.ToString(txtCType.Text)==Convert.ToString(ViewState["abc"]))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Already present')", true);
            DDLCType.Visible = true;
            txtCType.Visible = false;

        }
        else
        {
            string ss = txtCType.Text.ToUpper();

            string str = "insert into [Come2myCityDB].[dbo].[tbl_Main_ID](Sub_ID,Name,UserId,AdminUserId)values('3','" + ss + "','" + Convert.ToString(Session["User"]) + "','0')";
            int row = cc.ExecuteNonQuery(str);



            DDLCType.DataSource = ds;
            DDLCType.DataTextField = "Name";
            DDLCType.DataValueField = "ID";
            DDLCType.DataBind();

            DDLCType.Items.Insert(0, new ListItem("Select", "0"));
            DDLCType.SelectedIndex = 0;

            ddl.Visible = true;
            tb.Visible = false;
        }

       
    }
    public void txtChange1(DropDownList ddl,TextBox tb)
    {
        string str1 = "select ID,Name from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='4' and UserId='" + Convert.ToString(Session["User"]) + "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(str1);
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (Convert.ToString(txtCFDept.Text) == Convert.ToString(ds.Tables[0].Rows[i]["Name"]))
            {
                ViewState["abc"] = txtCFDept.Text;
            }
        }
        if (Convert.ToString(txtCFDept.Text) == Convert.ToString(ViewState["abc"]))
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
            DDLCFDept.Visible = true;
            txtCFDept.Visible = false;

        }
        string ss1 = txtCFDept.Text.ToUpper();
        string str = "insert into [Come2myCityDB].[dbo].[tbl_Main_ID](Sub_ID,Name,UserId)values('4','" + ss1 + "','" + Convert.ToString(Session["User"]) + "')";
        int row = cc.ExecuteNonQuery(str);

        DDLCFDept.DataSource = ds;
        DDLCFDept.DataTextField = "Name";
        DDLCFDept.DataValueField = "ID";
        DDLCFDept.DataBind();

        DDLCFDept.Items.Insert(0, new ListItem("Select","0"));
        DDLCFDept.SelectedIndex = 0;

        ddl.Visible = true;
        tb.Visible = false;


    }
    public void cmb(DropDownList ddl,TextBox tb)
    {
        if (DDLCType.SelectedItem.Text == "Add New")
        {
            txtCType.Visible = true;
            tb.Focus();
            tb.Text = "";
            ddl.Visible = false;
        }
       
    }

    public void cmb1(DropDownList ddl, TextBox tb)
    { 
    
     if(DDLCFDept.SelectedItem.Text=="Add New")
        {
            txtCFDept.Visible = true;
            tb.Focus();
            tb.Text = "";
            ddl.Visible = false;
        }
    }
    //protected void btnExportToExcel_Click(object sender, EventArgs e)
    //{
    //    //getDate();
    //    //exporttoexcel("Report.xls", gvItem);
    //    //gvItem= null;
    //    //gvItem.Dispose();
    //    Response.Clear();
    //    Response.AddHeader("content-disposition", "attachment;filename=Complaint.xlsx");
    //    Response.ContentType = "application/vnd.xls";
    //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    //    gvItem.RenderControl(htmlWrite);
    //    Response.Write(stringWrite.ToString());
    //    Response.End();    //}
 //public void exporttoexcel(string filename, GridView gv)
    //{
    //    string attachment = "attachment; filename=FileStatus.xlsx";
    //    Response.ClearContent();
    //    Response.AddHeader("content-disposition", attachment);
    //    Response.ContentType = "applicatio/excel";
    //    StringWriter sw = new StringWriter(); 
    //    HtmlTextWriter htm = new HtmlTextWriter(sw);
    //    gv.RenderControl(htm);
    //    Response.Write(sw.ToString());
    //    Response.End();
    //}
    //public override void VerifyRenderingInServerForm(Control control)
    //{



    //}
    //protected void btnExportToExcel_Click(object sender, EventArgs e)
    //{
    //    Response.Clear();
    //    Response.AddHeader("content-disposition", "attachment;filename=Complaint.xlsx");
    //    Response.ContentType = "application/excel";
    //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    //    gvItem.RenderControl(htmlWrite);
    //    Response.Write(stringWrite.ToString());
    //    Response.End();

    
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ClearContent();
        //Response.ClearHeaders();
        //Response.Charset = "";
        //string FileName = "MyStore" + DateTime.Now + ".xls";
        //System.IO.StringWriter strwritter = new System.IO.StringWriter();
        //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = "application/vnd.ms-excel";
        //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
        //gvItem.GridLines = GridLines.Both;
        //gvItem.HeaderStyle.Font.Bold = true;
        //gvItem.RenderControl(htmltextwrtter);
        //Response.Write(strwritter.ToString());
        //Response.End();      
    //}
    protected void lkbtnShowChlid_Click(object sender, EventArgs e)
    {
        Loadgrid1();
        MultiView1.Visible = true;
        // View2.Visible = true;
        MultiView1.SetActiveView(View2);
        //MultiView1.ActiveViewIndex = 1;
        
        
    }
    //protected void gvItem1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

    //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
    //    }
    //}
    //protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = -1;
    //}
    //protected void gvItem1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor;" + " this.style.backgroundColor='#FFFFE0';");

    //        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;");
    //    }
    //}
    protected void lkbtnBack_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
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
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void DDLCType_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb(DDLCType,txtCType);
    }
    protected void txtCType_TextChanged(object sender, EventArgs e)
    {
        txtChange(DDLCType,txtCType);
    }
    protected void DDLCFDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmb1(DDLCFDept, txtCFDept);
    }

    protected void txtCFDept_TextChanged(object sender, EventArgs e)
    {
      
        txtChange1(DDLCFDept, txtCFDept);
    }
    private void BindGridViewData()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        string str = "select * from [dbo].[tbl_EFileUpDown]";
        SqlCommand cmd = new SqlCommand(str, con);
        con.Open();
        gvFileUpload.DataSource = cmd.ExecuteReader();
        gvFileUpload.DataBind();
    }
    //protected void btnUpload_Click(object sender, EventArgs e)
    //{
    //    string FileName = Path.GetFileName(Fileupload.PostedFile.FileName);
    //    Stream str = Fileupload.PostedFile.InputStream;
    //    BinaryReader br = new BinaryReader(str);
    //    Byte[] size = br.ReadBytes((int)str.Length);
    //    using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
    //    {
    //        using (SqlCommand cmd = new SqlCommand())
    //        {
    //            cmd.CommandText = "insert into [dbo].[tbl_EFileUpDown](FileName,FileType,FileData) values(@Name,@Type,@Data)";
    //            cmd.Parameters.AddWithValue("@Name", FileName);
    //            cmd.Parameters.AddWithValue("@Type", "application/word");
    //            cmd.Parameters.AddWithValue("@Data", size);
    //            cmd.Connection = con;
    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //            BindGridViewData();
    //        }
    //    }
    //}
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
        string CompType = string.Empty;
        string Date = string.Empty;
        string CompSub = string.Empty;
        string CompDetails = string.Empty;
        string CompFDept = string.Empty;
        string CompName = string.Empty;
        string MobileNo = string.Empty;

        string Address = string.Empty;

        string EnteryMobileNo = string.Empty;
        for (int k = 0; k < excelDS.Tables[0].Rows.Count; k++)
        {
            //Id = Convert.ToInt32(excelDS.Tables[0].Rows[k][0]);
            CompType = excelDS.Tables[0].Rows[k][0].ToString();
            Date = excelDS.Tables[0].Rows[k][1].ToString();
            CompSub = excelDS.Tables[0].Rows[k][2].ToString();
            CompDetails = excelDS.Tables[0].Rows[k][3].ToString();
            CompFDept = excelDS.Tables[0].Rows[k][4].ToString();
            CompName = excelDS.Tables[0].Rows[k][5].ToString();
            MobileNo = excelDS.Tables[0].Rows[k][6].ToString();


            Address = excelDS.Tables[0].Rows[k][7].ToString();

            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string SqlQuery = "Insert Into [Come2myCityDB].[dbo].[tbl_EventComplaint]([CompType],[Date],[CompSub],[CompDetails],[CompFDept],[CompName],[MobileNo],[Address],[UserId],[CurrentDate])" +
                             " values(N'" +CompType + "',N'" + Date + "',N'" + CompSub + "',N'" + CompDetails + "',N'" + CompFDept + "',N'" + CompName + "',N'" + MobileNo + "',N'" + Address + "','" + Session["User"].ToString() + "','" + str + "')";

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

    protected void lnkbtnDown_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        int fileid = Convert.ToInt32(gvFileUpload.DataKeys[gvrow.RowIndex].Value.ToString());
        string name, type;
        using (SqlConnection con = new SqlConnection((ConfigurationManager.AppSettings["ConnectionString"])))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select FileName, FileType, FileData from [dbo].[tbl_EFileUpDown] where Id=@Id";
                cmd.Parameters.AddWithValue("@id", fileid);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Response.ContentType = dr["FileType"].ToString();
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + dr["FileName"] + "\"");
                    Response.BinaryWrite((byte[])dr["FileData"]);
                    Response.End();
                }
            }
        }
    }
    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(Convert.ToString(e.CommandName)=="Modify")
        {
            btnSubmit.Text = "Update";
            string CID = Convert.ToString(e.CommandArgument);
            lblId.Text = CID;
            objECBLL.CID1 = Convert.ToInt16(CID);
            objECBLL.SelectBLL(objECBLL);

            DDLCType.SelectedItem.Text = Convert.ToString(objECBLL.CompType1);
            txtdate.Text = Convert.ToString(objECBLL.Date1);
            txtCDetails.Text = Convert.ToString(objECBLL.CompDetails1);
            txtCSub.Text = Convert.ToString(objECBLL.CompSub1);
            DDLCFDept.SelectedItem.Text = Convert.ToString(objECBLL.CompFDept1);
            txtCName.Text = Convert.ToString(objECBLL.CompName1);
            txtMoblieNo.Text = Convert.ToString(objECBLL.MobileNo1);
            txtAddress.Text = Convert.ToString(objECBLL.Address1);
        }
        if (Convert.ToString(e.CommandName) == "Delete")
        {
            string CID = Convert.ToString(e.CommandArgument);
            lblId.Text = CID;
            objECBLL.CID1 = Convert.ToInt16(CID);
            con.Open();
            
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Do u want Delete')", true);
                string str = "Delete From [Come2myCityDB].[dbo].[tbl_EventComplaint] where CID='" + CID + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            
            con.Close();
        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Download/Complaint.xlsx");
    }
    protected void gvItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}

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
public partial class MarketingAdmin_AddProgrames : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    string DateFormat, desc, Cdate, execute, data1;
    DateTime date;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSubmit.Text = "Submit";

        if (!IsPostBack)
        {
            DateFormatStatus();
            //txtDate.Text = DateFormat;

            string sql2 = "select count(EzeeDrugAppId) from EzeeDrugsAppDetail where keyword = 'MHVIDHANAPP'";
            execute = cc.ExecuteScalar(sql2);
            hlCount.Text = execute;

        }
        pnlId.Visible = false;
        txtProgName.Enabled = true;
        bindata();
        LoadData();
    }
    public string DateFormatStatus()
    {
        DateTime dt = DateTime.Now; // get current date
        double d = 12; //add hours in time
        double m = 30; //add min in time 
        DateTime SystemDate = Convert.ToDateTime(dt).AddHours(d);
        SystemDate = SystemDate.AddMinutes(m);
        DateFormat = SystemDate.ToString("yyyy-MM-dd");
        string ds1 = Convert.ToString(DateFormat);

        return ds1;
    }
    public void getData()
    {        
        Cdate = txtProgName.Text;
        desc = txtdescription.Text;
        data1 = "data";
    }
    public void bindata()
    {

        DataSet ds = new DataSet();
        string sql1 = "SELECT [Progid] ,[ProgName],[ProgDescription],[LastModifieddate] FROM [Come2myCityDB].[dbo].[ProgrameDetails] order by Progid Desc";
        ds = cc.ExecuteDataset(sql1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            GvVMshow.DataSource = ds.Tables[0];
            GvVMshow.DataBind();
        }
        else
        {
        }

    }
    public void LoadData()
    {
        try
        {
            string Sql4 = "SELECT EzeeDrugAppId,keyword,strSimSerialNo,firstName,lastName,firmName,mobileNo,address FROM EzeeDrugsAppDetail where keyword = 'MHVIDHANAPP' order by EntryDate desc";
            DataSet ds = cc.ExecuteDataset(Sql4);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gridview1.DataSource = ds.Tables[0];
                gridview1.DataBind();
            }
        }
        catch (Exception ex)
        { }
    }

    protected void GvVMshow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Modify")
            {
                txtProgName.Enabled = false;
                DataSet ds = new DataSet();
                int id = Convert.ToInt16(e.CommandArgument);
                string sql = "select Progid,ProgName, ProgDescription from [Come2myCityDB].[dbo].[ProgrameDetails] where Progid = '" + id + "'";
                ds = cc.ExecuteDataset(sql);
                pnlId.Visible = true;
                if (ds.Tables[0].Rows.Count > 0)
                {

                    //txtDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["VidhanDate"]);
                    lblID.Text = Convert.ToString(ds.Tables[0].Rows[0]["Progid"]);
                    txtProgName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProgName"]);
                    txtdescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProgDescription"]);
                    btnSubmit.Text = "Modify";
                }
                lblID.Text = Convert.ToString(id);
            }
            else if (e.CommandName == "Delete")
            {
                int str;
                int id = Convert.ToInt16(e.CommandArgument);
                string sql = "delete from [Come2myCityDB].[dbo].[ProgrameDetails] where Progid = '" + id + "'";
                str = cc.ExecuteNonQuery(sql);

                if (str != 0)
                {
                    Response.Write("<script>alert('record deleted succesfully')</script>");
                    bindata();
                }

            }

        }
        catch (Exception)
        {

        }
    }
    protected void GVMshow_Rowdeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        DateFormatStatus();
        getData();
        int i = 0;
        if (txtdescription.Text == "")
        {
            Response.Write("<script>alert('enter the desctiption details')</script>");
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('enter the desctiption details')", true);
        }
        else
        {
            if (lblID.Text == "" || lblID.Text == null)
            {

                //string sql = "insert into VidhanMandalDetails (VidhanDate, Vidhanmandal,VidhanDescr ) Values  ( '" + Cdate + "' , '" + ddldata + "','" + desc + "' )";
                //i = cc.ExecuteNonQuery(sql);

                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                con.Open();
                SqlParameter[] par = new SqlParameter[5];

                par[0] = new SqlParameter("@ProgName", Cdate);                
                par[1] = new SqlParameter("@ProgDescription", desc);
                par[2] = new SqlParameter("@LastModifieddate", DateFormat);
                par[3] = new SqlParameter("@usrdata",data1);
                par[4] = new SqlParameter("@Status", 1);
                par[4].Direction = ParameterDirection.Output;

                i = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spProgramedetails", par);

            }
            else
            {
                //string sql = "update VidhanMandalDetails set  VidhanDescr = '" + desc + "',LastModifieddate = '" + DateFormat + "',Vidhanmandal = '" + ddldata + "' where Vid ='" + lblID.Text + "' ";
                //i = cc.ExecuteNonQuery(sql);
                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
                con.Open();
                SqlParameter[] par = new SqlParameter[4];

                par[0] = new SqlParameter("@ProgDescription", desc);
                par[1] = new SqlParameter("@LastModifieddate", DateFormat);                
                par[2] = new SqlParameter("@lblid", lblID.Text);
                par[3] = new SqlParameter("@Status", 1);
                par[3].Direction = ParameterDirection.Output;

                i = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spupdateProgramedetails", par);
                lblID.Text = "";
            }

            if (i > 0)
            {
                Response.Write("Record save Successfully");
                clear();
                bindata();
            }
            else
            {
                Response.Write("Please check the details");
            }

        }
    }
    public void clear()
    {
        txtProgName.Text = "";
        txtdescription.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void GvVMshow_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GvVMshow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvVMshow.PageIndex = e.NewPageIndex;
        bindata();
    }
}

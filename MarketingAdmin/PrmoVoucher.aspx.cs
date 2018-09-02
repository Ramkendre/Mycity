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

public partial class Add_User : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connectionstring"]);
    SqlCommand cmd = new SqlCommand();
    Random rndom = new Random();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //BindAddusrGrid();
            BindCoupenDetails();

            txtDate.Text = DateTime.Now.ToString();
            bindgrid();
        }
    }
 
    public void BindCoupenDetails()
    {
        try
        {
            string sql3 = "SELECT TOP 10 [State_Stocklist],[Date_Of_Allotment],[VoucherRange_From],[VoucherRange_To]FROM [Come2myCityDB].[dbo].[PromoVoucher_CpnDetails]";
            DataSet ds1 = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql3, con);
            da.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                gvCoupenDetails.DataSource = ds1;
                gvCoupenDetails.DataBind();
            }
            else
            {
                gvCoupenDetails.EmptyDataText = "No Record Available";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string rndstring = string.Empty;
        char c;
        string schrachCode = string.Empty;
        uint series = Convert.ToUInt32(txttotacodes.Text);
        uint srNo = Convert.ToUInt16(txtseries.Text);
        series += srNo;

        for (; srNo <= series; srNo++)
        {

            //schrachCode = getScrachCode();
            string select = "";
            string sqlQuer = "";
            cmd.Connection = con;

            try
            {
                for (; ; )
                {
                    int isExeist;
                    schrachCode = getScrachCode(Convert.ToUInt16(txtscratchcode.Text));
                    select = "SELECT  [SrNo] FROM [ezeedruglocal].[dbo].[tblScratchcode] where Scratchcode='" + schrachCode + "'";
                    cmd.CommandText = select;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    isExeist = cmd.ExecuteNonQuery();
                    if (isExeist < 0)
                        break;

                }


                sqlQuer = "insert into tblScratchcode (SrNo,Scratchcode,CreateDate)values(" + srNo + ",'" + schrachCode + "','" + txtDate.Text + "')";
                cmd.CommandText = sqlQuer;
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();



            }
            catch (SqlException sqlException)
            {
                //if (sqlException.Number == 2627)
                //{
                //    schrachCode = getScrachCode();
                //    sqlQuer = "insert into tblScratchcode (SrNo,Scratchcode)values(" + srNo + ",'" + schrachCode + "')";
                //    cmd.CommandText = sqlQuer;
                //    if (cmd.Connection.State == ConnectionState.Closed)
                //        cmd.Connection.Open();
                //    cmd.ExecuteNonQuery();
                //    cmd.Connection.Close();
                //}
                srNo--;
            }
            catch (Exception execption)
            {
                srNo--;
            }

        }
        bindgrid();
        Clear();
    }
    public void bindgrid()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connectionstring"]);
        //string str = "select SrNo, Scratchcode from tblScratchcode";              
        //cmd.CommandText = str;
        //cmd.CommandType = CommandType.Text;
        cmd = new SqlCommand("select SrNo, Scratchcode from tblScratchcode order by SrNo,CreateDate", con);
        // cmd.ExecuteNonQuery();
        // con.Close();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvcodelist.DataSource = ds;
            gvcodelist.DataBind();
        }
    }

    private string getScrachCode(int digit)
    {
        string schrachCode = string.Empty;
        for (int i = 0; i < digit; i++)
        {
            int flag = rndom.Next();
            int reminder = 0;
            if (rdobtnYesNo.SelectedValue == "1")
                reminder = (flag % 3);

            if (reminder == 0)
            {
                flag = rndom.Next();
                int rmd = flag % 9;
                schrachCode += rmd;

            }
            if (reminder == 1)
            {
                flag = rndom.Next(65, 90);
                schrachCode += Convert.ToChar(flag);
            }
            if (reminder == 2)
            {
                flag = rndom.Next(97, 122);
                schrachCode += Convert.ToChar(flag);
            }

        }
        return schrachCode;


    }
    protected void gvcodelist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvcodelist.PageIndex = e.NewPageIndex;
        gvcodelist.DataBind();
        bindgrid();
    }
    public void Clear()
    {
        txtseries.Text = "";
        txtscratchcode.Text = "";
        txttotacodes.Text = "";
        txtDate.Text = "";
        rdobtnYesNo.ClearSelection();

    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string sql1 = "insert into [Come2myCityDB].[dbo].[PromoVoucher_CpnDetails]([State_Stocklist],[Date_Of_Allotment],[VoucherRange_From],[VoucherRange_To])" +
                        " values ('" + ddlStateStockiest.SelectedItem.Text + "','" + txtDateTime.Text + "','" + txtSrnoFrom.Text + "','" + txtSrnoTo.Text + "') ";
            cmd = new SqlCommand(sql1, con);
            con.Open();
            string success2 = Convert.ToString(cmd.ExecuteNonQuery());

            if (success2 != "" || success2 != null)
            {
                Response.Write("<script>alert('Record Save successfully...!')</script>");
                BindCoupenDetails();
            }
            else
            {
                Response.Write("<script>alert('Please Enter Valid Details...!!')</script>");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    
}

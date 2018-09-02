using System;
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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public partial class Dynamic_code_generate : System.Web.UI.Page
{
    Random rndom = new Random();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["Connectionstring"]);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDate.Text = DateTime.Now.ToString();
            bindgrid();
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string rndstring = string.Empty;
        char c;
        string schrachCode = string.Empty;
        uint series = Convert.ToUInt32(txttotacodes.Text);
        uint srNo = Convert.ToUInt32(txtseries.Text);
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
                    select = "SELECT  [SrNo][Scratchcode] FROM [Come2myCityDB].[dbo].[tblScratchcode] where Scratchcode='" + schrachCode + "'";
                    cmd.CommandText = select;
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();
                    isExeist = cmd.ExecuteNonQuery();
                    if (isExeist < 0)
                        break;

                }


                sqlQuer = "insert into tblScratchcode (SrNo,Scratchcode,CreateDate,isUsed)values(" + srNo + ",'" + schrachCode + "','" + txtDate.Text + "','0')";
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
                //    schrachCode = getScrachCode(Convert.ToUInt16(txtscratchcode.Text));
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
            if(rdobtnYesNo.SelectedValue=="1")            
                reminder = (flag % 2);
            
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
            //if (reminder == 2)
            //{
            //    flag = rndom.Next(97, 122);
            //    schrachCode += Convert.ToChar(flag);
            //}

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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
}

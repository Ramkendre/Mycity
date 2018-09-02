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


public partial class Html_SecReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        int total = 0;
        if (!IsPostBack)
        {
            fill();
            Sum();
            //loadall(Sum());
            LoadGrid();
            //BindGrid();
            load();
        }
    }

    public void fill()
    {
        string str = "select MID,FName from [Come2myCityDB].[dbo].[tbl_BMRegistration]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        ddlSMember.DataSource = ds.Tables[0];
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlSMember.DataValueField = "MID";
            ddlSMember.DataTextField = "FName";
        }
        ddlSMember.DataBind();
        ddlSMember.Items.Add("Select");
        ddlSMember.SelectedIndex = ddlSMember.Items.Count - 1;
        ddlSMember.Items[ddlSMember.Items.Count - 1].Value = "";
    }
    public decimal cal()
    {
        DataSet ds = new DataSet();
        //string str =
        //            " with Event as( " +
        //            " select *from( " +
        //            " (SELECT ID,[MID] as m,[PreBalance],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate] FROM [Come2myCityDB].[dbo].[tbl_BIssueLoan] where [UserId]='"+Session["User"]+"') as t" +
        //            " left join " +
        //            " [Come2myCityDB].[dbo].[tbl_BMRegistration] as t1 " +
        //            " on " +
        //            " t.m=t1.MID " +
        //            " ) " +
        //            " ) ";
        string str = "SELECT ID,[MID] as m,[PreBalance],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate] FROM [Come2myCityDB].[dbo].[tbl_BIssueLoan] where MID='" + ddlSMember.SelectedValue + "'";
        ds = cc.ExecuteDataset(str);
        decimal str1 = Convert.ToInt32(ds.Tables[0].Rows[0]["LoanAmt"]);
        decimal str2 = Convert.ToInt32(ds.Tables[0].Rows[0]["DueDate"]);

        string sql = "select IntOnLoan FROM [Come2myCityDB].[dbo].[tbl_BSSGRuleSetting]";
        ds = cc.ExecuteDataset(sql);
        decimal sql1 = Convert.ToInt32(ds.Tables[0].Rows[0]["IntOnLoan"]);
        decimal cal = ((str1 * str2 * sql1 )/ 100);

        
        lblCal.Text ="Simple Intrest="+cal.ToString();
        //Label lbl = gvItem.FindControl("lblCal") as Label;
        //lbl.Text = Convert.ToString(cal); 
        return cal;
    }
    public void LoadGrid(decimal cal)
    {
        string str = "SELECT [MID],[GID],[FName],[LName],[MobileNo],[Post],[DOJ],[Subscription],[Deposite],[Loan] FROM [Come2myCityDB].[dbo].[tbl_BMRegistration] where MID='"+ddlSMember.SelectedValue+"'";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        DataSet dataset = new DataSet();
        DataTable table = new DataTable();
        table.Columns.Add("MID", typeof(string));
        table.Columns.Add("GID", typeof(string));
        table.Columns.Add("FName", typeof(string));
        table.Columns.Add("LName", typeof(string));
        table.Columns.Add("MobileNo", typeof(string));
        table.Columns.Add("Post", typeof(string));
        table.Columns.Add("DOJ", typeof(string));
        table.Columns.Add("Subscription", typeof(string));
        table.Columns.Add("Deposite", typeof(string));
        table.Columns.Add("Loan", typeof(string));
        table.Columns.Add("Cal", typeof(string));

        for (int i=0;i<ds.Tables[0].Rows.Count;i++)
            table.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], ds.Tables[0].Rows[i][6], ds.Tables[0].Rows[i][7], ds.Tables[0].Rows[i][8], ds.Tables[0].Rows[i][9], cal);
        gvItem.DataSource = table;
        gvItem.DataBind();
       
    }
    public void LoadGridInst()
    {
        string str1 = "SELECT [ID],[MID],[SubAmt],[LInstalment],[LIMonth],[Date] FROM [Come2myCityDB].[dbo].[tbl_BSubInstalment] where MID='" + ddlSMember.SelectedValue + "'";
        DataSet ds = new DataSet();
        SqlDataAdapter da=new SqlDataAdapter(str1,con);
        da.Fill(ds);
        gvItemInst.DataSource=ds.Tables[0];
        gvItemInst.DataBind();
    }
    protected void ddlSMember_SelectedIndexChanged(object sender, EventArgs e)
    {

        LoadGrid(cal());
        
        LoadGridInst();
    }
    //protected void gvItem_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    DataSet ds = new DataSet();
    //    //string str =
    //    //            " with Event as( " +
    //    //            " select *from( " +
    //    //            " (SELECT ID,[MID] as m,[PreBalance],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate] FROM [Come2myCityDB].[dbo].[tbl_BIssueLoan] where [UserId]='"+Session["User"]+"') as t" +
    //    //            " left join " +
    //    //            " [Come2myCityDB].[dbo].[tbl_BMRegistration] as t1 " +
    //    //            " on " +
    //    //            " t.m=t1.MID " +
    //    //            " ) " +
    //    //            " ) ";
    //    string str = "SELECT ID,[MID] as m,[PreBalance],[LoanAmt],[DateOfIssue],[MInstalment],[DueDate] FROM [Come2myCityDB].[dbo].[tbl_BIssueLoan] where MID='" + ddlSMember.SelectedValue + "'";
    //    ds = cc.ExecuteDataset(str);
    //    decimal str1 = Convert.ToInt32(ds.Tables[0].Rows[0]["LoanAmt"]);
    //    decimal str2 = Convert.ToInt32(ds.Tables[0].Rows[0]["DueDate"]);

    //    string sql = "select IntOnLoan FROM [Come2myCityDB].[dbo].[tbl_BSSGRuleSetting]";
    //    ds = cc.ExecuteDataset(sql);
    //    decimal sql1 = Convert.ToInt32(ds.Tables[0].Rows[0]["IntOnLoan"]);
    //    decimal cal = ((str1 * str2 * sql1) / 100);
    //    lblCal.Text = cal.ToString();

       
    //        //Label lbl = (Label)e.Row.FindControl("lblCal");
    //        //lbl.Text = cal.ToString();

    //    Label lbl = gvItem.Rows[rowIndex].FindControl("lblCal") as Label;
    //    lbl.Text = Convert.ToString(cal);
        
    //}
    public string Sum()
    {
        string str = "select Sum(cast(SubAmt as int)) from [Come2myCityDB].[dbo].[tbl_BSubInstalment] where UserId='"+Session["User"]+"' ";
        string st = cc.ExecuteScalar(str);
        return st;
        
        
    }

    public void load()
    {
        string str =
                         " with Event as( " +
                         " select *from( " +
                         " (select [MID] as m,[SubAmt],[LInstalment],[LIMonth],[Date] FROM [Come2myCityDB].[dbo].[tbl_BSubInstalment] where UserId='" + Session["User"] + "')as t" +
                         " inner join " +
                         " [Come2myCityDB].[dbo].[tbl_BIssueLoan] as t1 " +
                         " on " +
                         " t.m=t1.MID " +
                         " left join " +
                         " (select MID as m1,FName from [Come2myCityDB].[dbo].[tbl_BMRegistration]) as t3 " +
                         " on " +
                         " t1.MID=t3.m1 " +
                         " ) " +
                         " ) ";
        str += "select [FName],[SubAmt],[LInstalment],[LIMonth],LoanAmt,MInstalment from Event";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        //DataTable table = new DataTable();
        //table.Columns.Add("FName", typeof(string));
        //table.Columns.Add("SubAmt", typeof(string));
        //table.Columns.Add("LInstalment", typeof(string));
        //table.Columns.Add("LIMonth", typeof(string));
        //table.Columns.Add("LoanAmt", typeof(string));
        //table.Columns.Add("MInstalment", typeof(string));
        //table.Columns.Add("St", typeof(string));

        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    table.Rows.Add(ds.Tables[0].Rows[i][0], ds.Tables[0].Rows[i][1], ds.Tables[0].Rows[i][2], ds.Tables[0].Rows[i][3], ds.Tables[0].Rows[i][4], ds.Tables[0].Rows[i][5], st);

        gvItemAll.DataSource = ds;
        gvItemAll.DataBind();
    }
    public void LoadGrid()
     {
        DataTable dt = new DataTable();
        //SqlCommand cmd = new SqlCommand();
        using (SqlCommand cmd = con.CreateCommand())
        {
            cmd.CommandText =
                            " select *from( " +
                            " (select [MID] as m,[SubAmt],[LInstalment],[LIMonth],[Date] FROM [Come2myCityDB].[dbo].[tbl_BSubInstalment] where UserId='" + Session["User"] + "')as t" +
                            " inner join " +
                            " [Come2myCityDB].[dbo].[tbl_BIssueLoan] as t1 " +
                            " on " +
                            " t.m=t1.MID " +
                            " left join " +
                            " (select MID as m1,FName from [Come2myCityDB].[dbo].[tbl_BMRegistration]) as t3 " +
                            " on " +
                            " t1.MID=t3.m1 " +

                            " ) ";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            if (ViewState["Sum"] == null)
            {
                int sum = 0;
                int s = 0;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    //System.Nullable<Decimal>;
                    ////if (dt["Sum"] is System.DBNull.Value)
                    //dPrice += dt.Rows[i].Field<Decimal>(2);
                    //s += dt.Rows[i].Field<string>("SubAmt").ToString<string>();
                    //object number = dt.Rows[i];
                    //sum += Convert.ToInt32(number);
                    //int num = Convert.ToInt32(dt.Rows[i]);
                    //s += num;
                }

                //foreach (DataRow rows in dt.Rows)
                //{
                //    for (int i = 0; i < dt.Columns.Count; i++)
                //    {
                //        for (int j = 0; j < dt.Rows.Count; j++)
                //        {


                //            int number = Convert.ToInt32(dt.Rows[j].Field<int>(i));
                //            sum += number;
                //        }
                //    }

                //          rows["testrow"] = sum;
                //    }

                //}
                //ViewState["Sum"] = sum;
                //DataSet ds = new DataSet();
                //dt = ds;
                //dt.Columns.Add("testrow", typeof(int));
                //DataRow dr = dt.NewRow();
                ////int sum = 0;
                //for (int i = 1; i < dt.Columns.Count; i++)
                //{
                //    for (int j = 1; j < dt.Rows.Count; j++)
                //    {

                //        if (j == dt.Rows.Count - 1)
                //        {
                //            dt.Rows[i][j] = Convert.ToInt32(sum);
                //            sum = 0;
                //        }
                //        else
                //        {
                //            object number = dt.Rows[i][j];
                //            sum += Convert.ToInt32(number);
                //        }

            }
            //dataGridView1.DataSource = dt;
        }

        gvItemAll.DataSource = dt;
        gvItemAll.DataBind();



    }
    //private void BindGrid()
    //{
    //    string query = " select *from( " +
    //                        " (select [MID] as m,[SubAmt],[LInstalment],[LIMonth],[Date] FROM [Come2myCityDB].[dbo].[tbl_BSubInstalment] where UserId='" + Session["User"] + "')as t" +
    //                        " inner join " +
    //                        " [Come2myCityDB].[dbo].[tbl_BIssueLoan] as t1 " +
    //                        " on " +
    //                        " t.m=t1.MID " +
    //                        " left join " +
    //                        " (select MID as m1,FName from [Come2myCityDB].[dbo].[tbl_BMRegistration]) as t3 " +
    //                        " on " +
    //                        " t1.MID=t3.m1 " +

    //                        " ) ";
      
       
    //        using (SqlCommand cmd = new SqlCommand(query))
    //        {
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.Connection = con;
    //                sda.SelectCommand = cmd;
    //                using (DataTable dt = new DataTable())
    //                {
    //                    sda.Fill(dt);
    //                    gvItemAll.DataSource = dt;
    //                    gvItemAll.DataBind();

    //                    //Calculate Sum and display in Footer Row
    //                    decimal total = dt.AsEnumerable().Sum(row => row.Field<decimal>("SubAmt"));
    //                    gvItemAll.FooterRow.Cells[1].Text = "Sum";
    //                    gvItemAll.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
    //                    gvItemAll.FooterRow.Cells[2].Text = total.ToString("N2");
    //                }
    //            }
    //        }
        
    //}
    protected void gvItemAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemAll.PageIndex = e.NewPageIndex;
        gvItemAll.DataBind();
        LoadGrid();
        //loadall(Sum());
    }
    int total=0;
    protected void gvItemAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblqy = (Label)e.Row.FindControl("lblqty");
            int qty = Int32.Parse(lblqy.Text);
            total = total + qty;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalqty = (Label)e.Row.FindControl("lblTotalqty");
            lblTotalqty.Text = total.ToString();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ClosedXML;
//using ClosedXML.Excel;

public partial class MarketingAdmin_CommanLongCodeReport : System.Web.UI.Page
{
    // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyHeritageConnectionString"].ConnectionString);
    SqlCommand cmd;
    DataSet ds = new DataSet();
    DataSet dscount = new DataSet();
    ArrayList ArryLst1 = new ArrayList();
    ArrayList ArryLst2 = new ArrayList();
    string LSTString = "";
    string Chklist = "";
    string tableName = string.Empty;
    string LblColName = string.Empty;

    CommonCode cc = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //loadDDLField();
            loadAllTable();
            // LoadAllGV();
        }
    }


    public void loadAllTable()
    {
        string sql = "select [TId],[DisplayTableName] from [ItemMasterTable]";
        DataSet ds = cc.ExecuteDataset(sql);

        ddlMstTable.DataSource = ds.Tables[0];
        ddlMstTable.DataTextField = "DisplayTableName";
        ddlMstTable.DataValueField = "TId";
        ddlMstTable.DataBind();
        ddlMstTable.Items.Add("--Select--");
        ddlMstTable.SelectedIndex = ddlMstTable.Items.Count - 1;
    }

    protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Sql = string.Empty;
        string fldMstId = string.Empty; string DuptColname = string.Empty;
        string colId = string.Empty; string dtype = string.Empty;

        SqlDataAdapter da = new SqlDataAdapter();
        Sql = "Select [TableColumnName],[TableId],[LblColumnName],[ColId],[Type] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
        DataSet Dtset = new DataSet();
        Dtset = cc.ExecuteDataset(Sql);

        colId = Convert.ToString(Dtset.Tables[0].Rows[0]["ColId"]);
        dtype = Convert.ToString(Dtset.Tables[0].Rows[0]["Type"]);
        if (Dtset.Tables[0].Rows.Count > 0)
        {
            if (colId == "21")
            {
                Sql = "select [EID],[ExpenseType] from [tblExpenseType]  where [fieldId]='" + colId + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(Sql);

                ddlFieldItem.DataSource = ds.Tables[0];
                ddlFieldItem.DataTextField = "ExpenseType";
                ddlFieldItem.DataValueField = "EID";
                ddlFieldItem.DataBind();

                ddlFieldItem.Items.Add("--Select--");
                ddlFieldItem.SelectedIndex = ddlFieldItem.Items.Count - 1;
                ddlFieldItem.Visible = true;
                txtSrchNumber.Visible = false;
                txtDate.Visible = false;
            }
            else if (dtype == "date")
            {
                txtDate.Visible = true;
                txtSrchNumber.Visible = false;
                ddlFieldItem.Visible = false;
                txtSrchChar.Visible = false;
            }

            else if (colId == "9" || colId == "5" || colId == "21" || colId == "13" || colId == "16")
            {
                Sql = "select [fixid],[Name] from [ItemValueSubMasterTable] where [fieldid]='" + colId + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(Sql);

                ddlFieldItem.DataSource = ds.Tables[0];
                ddlFieldItem.DataTextField = "Name";
                ddlFieldItem.DataValueField = "fixid";
                ddlFieldItem.DataBind();

                ddlFieldItem.Items.Add("--Select--");
                ddlFieldItem.SelectedIndex = ddlFieldItem.Items.Count - 1;
                ddlFieldItem.Visible = true;
                txtSrchNumber.Visible = false;
                txtDate.Visible = false;
                txtSrchChar.Visible = false;
            }
            else if (dtype == "int")
            {
                txtSrchNumber.Visible = true;
                txtSrchChar.Visible = false;
                ddlFieldItem.Visible = false;
                txtDate.Visible = false;
            }
            else
            {
                txtSrchChar.Visible = true;
                txtSrchNumber.Visible = false;
                ddlFieldItem.Visible = false;
                txtDate.Visible = false;
            }
        }
    }

    //protected void btnAdd_Click(object sender, EventArgs e)
    //{
    //    string field = string.Empty; string fielditem = string.Empty;
    //    string oprt = string.Empty; string valOrdate = string.Empty;
    //    string Sql = string.Empty; string textval = string.Empty;
    //    string textDate = string.Empty;
    //    SqlDataAdapter da = new SqlDataAdapter();
    //    try
    //    {
    //        Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
    //        DataSet ds1 = new DataSet();
    //        ds1 = cc.ExecuteDataset(Sql);

    //        LblColName = Convert.ToString(ds1.Tables[0].Rows[0]["TableColumnName"]);

    //        fielditem = ddlFieldItem.SelectedValue;
    //        oprt = ddlOperator.SelectedItem.Text;
    //        textval = txtSrchNumber.Text;
    //        textDate = txtDate.Text;
    //        if (fielditem != "")
    //        {
    //            ChkAddList.Items.Add(LblColName + " " + oprt + " " + "'" + fielditem + "'");
    //        }
    //        else if (textval != "")
    //        {
    //            ChkAddList.Items.Add(LblColName + " " + oprt + " " + "'" + textval + "'");
    //        }
    //        else if (textDate != "")
    //        {
    //            ChkAddList.Items.Add(LblColName + " " + oprt + " " + "'" + textDate + "'");
    //        }
    //        ddlFieldItem.Items.Clear();
    //    }
    //    catch
    //    {

    //    }
    //}

    protected void btnRight_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstbox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < lstbox1.Items.Count; i++)
                {
                    if (lstbox1.Items[i].Selected)
                    {
                        if (!ArryLst1.Contains(lstbox1.Items[i]))
                        {
                            ArryLst1.Add(lstbox1.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ArryLst1.Count; i++)
                {
                    if (!lstbox2.Items.Contains(((ListItem)ArryLst1[i])))
                    {
                        lstbox2.Items.Add(((ListItem)ArryLst1[i]));
                    }
                }
            }
        }
        catch
        {

        }
    }

    protected void btnleft_Click(object sender, EventArgs e)
    {
        try
        {
            if (lstbox2.SelectedIndex >= 0)
            {
                for (int i = 0; i < lstbox2.Items.Count; i++)
                {
                    if (lstbox2.Items[i].Selected)
                    {
                        if (!ArryLst2.Contains(lstbox2.Items[i]))
                        {
                            ArryLst2.Add(lstbox2.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < ArryLst2.Count; i++)
                {
                    if (!lstbox1.Items.Contains(((ListItem)ArryLst2[i])))
                    {
                        lstbox1.Items.Add(((ListItem)ArryLst2[i]));
                    }
                    lstbox2.Items.Remove(((ListItem)ArryLst2[i]));
                }
                lstbox1.SelectedIndex = -1;
            }
        }
        catch
        {

        }
    }

    public void BindGvTrngReport(string LSTString, string chklist)
    {
        if (ddlOperator.SelectedValue == "6")
        {
            ViewState["LSTString"] = LSTString;

            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
            DataSet ds2 = new DataSet();
            ds2 = cc.ExecuteDataset(Sql);

            tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

            Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
            DataSet ds3 = new DataSet();
            ds3 = cc.ExecuteDataset(Sql);

            LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

            DataSet ds = new DataSet();
            if (chklist != "")
            {
                ViewState["chklist"] = chklist;
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " ";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (ddlFieldItem.SelectedValue != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' ";

                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;

            }
            else if (txtSrchNumber.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtSrchChar.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtDate.Text != "")
            {
                string datestring = txtDate.Text;
                DateTime formatdatetime = DateTime.ParseExact(datestring, "d MMM yyyy", null);
                string mydate = formatdatetime.ToString("yyyy-MM-dd");

                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + mydate + "%' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        else
        {
            ViewState["LSTString"] = LSTString;

            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
            DataSet ds2 = new DataSet();
            ds2 = cc.ExecuteDataset(Sql);

            tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

            Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
            DataSet ds3 = new DataSet();
            ds3 = cc.ExecuteDataset(Sql);

            LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

            DataSet ds = new DataSet();
            if (chklist != "")
            {
                ViewState["chklist"] = chklist;
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + "";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (ddlFieldItem.SelectedValue != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' ";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;

            }
            else if (txtSrchNumber.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtSrchChar.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchChar.Text + "%' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtDate.Text != "")
            {
                string datestring = txtDate.Text;
                DateTime formatdatetime = DateTime.ParseExact(datestring, "d MMM yyyy", null);
                string mydate = formatdatetime.ToString("yyyy-MM-dd");

                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + mydate + "' ";                                                 // WHERE " + ddlField.SelectedItem.Text.Trim() + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [InsertBy]=" + txtSrchNumber.Text + "";
                ds = cc.ExecuteDataset(sql);

                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }

    string lsttext = string.Empty;

    int lstbx2cunt = 0;

    public void SelectAllTextInListBox()
    {
        foreach (ListItem item in lstbox2.Items)
        {
            item.Selected = true;
        }
        lstbx2cunt = Convert.ToInt32(lstbox2.Items.Count);
    }



    //---------------------------OKCL SMS Report PAge-------------------------------------------------
    public string returnCurDate()
    {
        TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        string dt = indianTime.ToString("d MMM yyyy");
        return dt;
    }

    string datefrmt = string.Empty;
    public void BindOKCLSmsReport(string LSTString, string chklist)
    {
        if (ddlOperator.SelectedValue == "6")
        {
            ViewState["LSTString"] = LSTString;

            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + " ";
            DataSet ds2 = new DataSet();
            ds2 = cc.ExecuteDataset(Sql);
            tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

            Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "' ";
            DataSet ds3 = new DataSet();
            ds3 = cc.ExecuteDataset(Sql);
            LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

            DataSet ds = new DataSet();
            if (chklist != "")
            {
                ViewState["chklist"] = chklist;
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (ddlFieldItem.SelectedValue != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' and [p1]='89915309029902859651' and [p2]='352742064913669' ";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtSrchNumber.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtSrchChar.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtDate.Text != "")
            {
                datefrmt = txtDate.Text;//returnCurDate();

                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + datefrmt + "%' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        else
        {
            ViewState["LSTString"] = LSTString;

            string SqlQry = string.Empty; string Countid = string.Empty;
            string Sql = string.Empty;
            SqlDataAdapter da = new SqlDataAdapter();
            Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
            DataSet ds2 = new DataSet();
            ds2 = cc.ExecuteDataset(Sql);
            tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

            Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
            DataSet ds3 = new DataSet();
            ds3 = cc.ExecuteDataset(Sql);
            LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

            DataSet ds = new DataSet();
            if (chklist != "")
            {
                ViewState["chklist"] = chklist;
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (ddlFieldItem.SelectedValue != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;

            }
            else if (txtSrchNumber.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + "  " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtSrchChar.Text != "")
            {
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + "  " + ddlOperator.SelectedItem.Text + " '" + txtSrchChar.Text + "' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            else if (txtDate.Text != "")
            {
                datefrmt = txtDate.Text; //returnCurDate();
                string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + datefrmt + "%' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                ds = cc.ExecuteDataset(sql);
                Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                lblCount.Text = Countid;
            }
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

    }

    protected void btdisplay_Click(object sender, EventArgs e)
    {
        SelectAllTextInListBox();
        CommanData();
        string roleid = Session["RoleId"].ToString();
        if (roleid == "115")
        {
            BindOKCLSmsReport(LSTString, Chklist);
        }
        else
        {
            BindGvTrngReport(LSTString, Chklist);
        }
    }

    public void CommanData()
    {
        SqlDataAdapter da = new SqlDataAdapter();
        for (int i = 0; i < lstbox2.Items.Count; i++)
        {
            if (lstbox2.Items[i].Selected == true)
            {
                lsttext = lsttext + "," + Convert.ToString(lstbox2.Items[i].Value);
            }
        }
        lsttext = lsttext.Substring(1);

        string sql = "select [TableColumnName] from [ItemValueMasterTable] where [ColId] IN (" + lsttext + ")";
        ds = cc.ExecuteDataset(sql);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int itm = 0; itm < ds.Tables[0].Rows.Count; itm++)
            {
                LSTString = LSTString + "," + Convert.ToString(ds.Tables[0].Rows[itm][0]);
            }
        }

        if (LSTString.Length > 1)
        {
            LSTString = LSTString.Substring(1);
        }

        for (int c = 0; c < ChkAddList.Items.Count; c++)
        {
            if (ChkAddList.Items[c].Selected == true)
            {
                Chklist = Chklist + " and " + ChkAddList.Items[c].Text;
            }
        }
        if (Chklist.Length > 1)
        {
            Chklist = Chklist.Substring(4);
        }
        // BindGvTrngReport(LSTString, Chklist);
    }


    public DataTable DataTableReports(string LSTString, string chklist)
    {
        string SqlQry = string.Empty; string Countid = string.Empty;
        string Sql = string.Empty;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
            DataSet ds2 = new DataSet();
            ds2 = cc.ExecuteDataset(Sql);
            tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

            Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
            DataSet ds3 = new DataSet();
            ds3 = cc.ExecuteDataset(Sql);
            LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

            if (ddlOperator.SelectedValue == "6")
            {
                ViewState["LSTString"] = LSTString;

                DataSet ds = new DataSet();
                if (chklist != "")
                {
                    ViewState["chklist"] = chklist;
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + "";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }
                else if (ddlFieldItem.SelectedValue != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + ddlFieldItem.SelectedValue + "%' ";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;

                }
                else if (txtSrchNumber.Text != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchNumber.Text + "%' ";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }
                else if (txtSrchChar.Text != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' ";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }
                else if (txtDate.Text != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtDate.Text + "' ";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            else
            {
                ViewState["LSTString"] = LSTString;

                DataSet ds = new DataSet();
                if (chklist != "")
                {
                    ViewState["chklist"] = chklist;
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + chklist + " and [p1]='89915309029902859651' and [p2]='352742064913669'";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }
                else if (ddlFieldItem.SelectedValue != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + ddlFieldItem.SelectedValue + "' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;

                }
                else if (txtSrchNumber.Text != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " " + ddlOperator.SelectedItem.Text + " '" + txtSrchNumber.Text + "' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }
                else if (txtSrchChar.Text != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtSrchChar.Text + "%' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }
                else if (txtDate.Text != "")
                {
                    string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtDate.Text + " %' and [p1]='89915309029902859651' and [p2]='352742064913669'";
                    ds = cc.ExecuteDataset(sql);

                    Countid = Convert.ToString(ds.Tables[0].Rows.Count);
                    lblCount.Text = Countid;
                }
                dt = ds.Tables[0];
            }
            return dt;
        }
        catch
        {
            return dt = null;
        }
    }

    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        string Sql = string.Empty;
        try
        {
            GridView1.Visible = false;
            Sql = "select [TableName] from [ItemMasterTable] where [TId]=" + ddlMstTable.SelectedValue + "";
            DataSet ds2 = new DataSet();
            ds2 = cc.ExecuteDataset(Sql);
            tableName = Convert.ToString(ds2.Tables[0].Rows[0]["TableName"]);

            Sql = "Select [TableColumnName],[TableId],[LblColumnName] from [ItemValueMasterTable] where [ColId]='" + ddlField.SelectedValue + "'";
            DataSet ds3 = new DataSet();
            ds3 = cc.ExecuteDataset(Sql);
            LblColName = Convert.ToString(ds3.Tables[0].Rows[0]["TableColumnName"]);

            SelectAllTextInListBox();
            CommanData();

            string sql = "SELECT " + LSTString + " FROM " + tableName + " WHERE " + LblColName + " like '" + txtDate.Text + " %' and [p1]='89915309029902859651' and [p2]='352742064913669'";
            ds = cc.ExecuteDataset(sql);
            GridView2.Visible = true;
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
           
            //GridView1.AllowPaging = false;

            //if (GridView2.visible)
            //{
                Response.AddHeader("content-disposition", "attachment; filename = MsgStatusReport.xls");
                Response.ContentType = "application/excel";
                StringWriter sWriter = new StringWriter();
                HtmlTextWriter hTextWriter = new HtmlTextWriter(sWriter);
                
                //GridView1.RenderControl(hTextWriter);

                GridView2.RenderControl(hTextWriter);

                Response.Write(sWriter.ToString());
                Response.End();

                GridView2.Visible = false;
           // }
        }
        catch
        {

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void ddlMstTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sql = string.Empty;
        SqlDataAdapter da = new SqlDataAdapter();

        sql = "select [ColId],[LblColumnName] from [ItemValueMasterTable] where [ddlfieldBindId]='" + ddlMstTable.SelectedValue + "'";
        DataSet ds4 = new DataSet();
        ds4 = cc.ExecuteDataset(sql);

        ddlField.DataSource = ds4.Tables[0];
        ddlField.DataTextField = "LblColumnName";
        ddlField.DataValueField = "ColId";
        ddlField.DataBind();
        ddlField.Items.Add("--Select--");
        ddlField.SelectedIndex = ddlField.Items.Count - 1;

        sql = "Select [ColId],[TableColumnName],[LblColumnName] from [ItemValueMasterTable] where [TableId]=" + ddlMstTable.SelectedValue + "";
        DataSet ds5 = new DataSet();
        ds5 = cc.ExecuteDataset(sql);

        lstbox1.DataSource = ds5.Tables[0];
        lstbox1.DataTextField = "LblColumnName";
        lstbox1.DataValueField = "ColId";
        lstbox1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            LSTString = ViewState["LSTString"].ToString();
            GridView1.PageIndex = e.NewPageIndex;
            BindOKCLSmsReport(LSTString, Chklist);
            // BindGvTrngReport(LSTString, Chklist);
        }
        catch
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindOKCLSmsReport(LSTString, Chklist);
            //BindGvTrngReport(LSTString, Chklist);
        }
    }
}
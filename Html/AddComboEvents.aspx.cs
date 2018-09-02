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

public partial class Html_AddComboEvents : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        string useridsession = Convert.ToString(Session["user"]);
        MultiView1.SetActiveView(View1);
        if (!IsPostBack)
        {
            fill();
            loadGrid();
        }
        Session.Timeout = 60;
    }
    public void fill()
    {
        string str = "select Name as id from [Come2myCityDB].[dbo].[tbl_Sub_ID]";
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(str, con);
        da.Fill(ds);
        ddlEvent.DataSource = ds;
        if(ds.Tables[0].Rows.Count>0)
        {
            ddlEvent.DataValueField = "id";
        }
        ddlEvent.DataBind();
        ddlEvent.Items.Add("select");
        ddlEvent.Items.Insert(0,new ListItem("select","0"));
        ddlEvent.SelectedIndex = 0;
    }
    public void loadGrid()
    {
        DataSet ds = new DataSet();
        string sq = "select ID from [Come2myCityDB].[dbo].[tbl_Sub_ID] where Name='"+ddlEvent.SelectedValue.ToString()+"'";
        string sq1 = cc.ExecuteScalar(sq);
        string str = "select * from [Come2myCityDB].[dbo].[tbl_Main_ID] where Sub_ID='"+sq1+"'";
        
        //ds = cc.ExecuteDataset(str);
        SqlDataAdapter da = new SqlDataAdapter(str,con);
        da.Fill(ds);
        if(ds.Tables[0].Rows.Count>0)
        {
            gvItem.DataSource = ds;
            gvItem.DataBind();
        
        }
    }
    public void addrecord()
    {
        string str1 = "select ID from [Come2myCityDB].[dbo].[tbl_Sub_ID] where Name='" + ddlEvent.SelectedValue.ToString() + "'";
        string s = cc.ExecuteScalar(str1);
        string str = "insert into [Come2myCityDB].[dbo].[tbl_Main_ID](Sub_ID,Name,UserId)values('" + s + "','" + txtCombo.Text + "','"+Convert.ToString(Session["User"])+"')";
        int result = cc.ExecuteNonQuery(str);
        if (result == 1)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Event Added Successfully')", true);
        }
    }
    public void RetrieveCombo()
    {
        string gvSNO = "";
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            CheckBox chkbox = (CheckBox)gvItem.Rows[i].Cells[2].FindControl("chk");

            if (chkbox != null)
            {
                if (chkbox.Checked == true)
                {
                    gvSNO += Convert.ToString(gvItem.DataKeys[i].Value) + ",";

                }
            }
            chkbox.Checked = false;
        }

        if (gvSNO == "")
        {
            lblalert.Text = "Please select atleast one Test  !!!";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select atleast one Test  !!!')", true);
        }

        else if (gvSNO != "")
        {
            gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
        }



        string TestIDSet = gvSNO;

        if (TestIDSet != "")
        {
            string[] splitid = TestIDSet.Split(',');

            //Session["TestIDVal"] = splitid[i];
            //ArrayList t = (ArrayList)Session["TestIDSet"];

            if (splitid.Length > 0)
            {
                Session["TestIDVal"] = splitid;

                for (int i = 0; i < splitid.Length; i++)
                {

                    //string Sql = "Select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where ID=" + splitid[i] + "";
                    //string TestIDVal = Convert.ToString(cc.ExecuteScalar(Sql));

                    //if (TestIDVal != "")
                    //{

                    //        Session["TestIDVal"] = splitid[i];


                    //}
                    //else
                    //{

                    //    lblalert.ForeColor = System.Drawing.Color.Red;
                    //    lblalert.Text = "Test Already Exist !!!";
                    //    MultiView1.SetActiveView(View1);
                    //            //}
                }
                //    }
            }
            //else
            //{
            //    lblalert.Text = "Please select atleast one Test  !!!";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select atleast one Test  !!!')", true);
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string gvSNO = "";
        for (int i = 0; i < gvItem.Rows.Count; i++)
        {
            CheckBox chkbox = (CheckBox)gvItem.Rows[i].Cells[2].FindControl("chk");

            if (chkbox != null)
            {
                if (chkbox.Checked == true)
                {
                    gvSNO += Convert.ToString(gvItem.DataKeys[i].Value) + ",";

                }
            }
            chkbox.Checked = false;
        }

        if (gvSNO == "")
        {
            lblalert.Text = "Please select atleast one Test  !!!";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select atleast one Test  !!!')", true);
        }

        else if (gvSNO != "")
        {
            gvSNO = gvSNO.Substring(0, gvSNO.Length - 1);
        }



        string TestIDSet = gvSNO;

        if (TestIDSet != "")
        {
            string[] splitid = TestIDSet.Split(',');

            //Session["TestIDVal"] = splitid[i];
            //ArrayList t = (ArrayList)Session["TestIDSet"];

            if (splitid.Length > 0)
            {
                Session["TestIDVal"] = splitid;

                for (int i = 0; i < splitid.Length; i++)
                {

                    //string Sql = "Select ID from [Come2myCityDB].[dbo].[tbl_Main_ID] where ID=" + splitid[i] + "";
                    //string TestIDVal = Convert.ToString(cc.ExecuteScalar(Sql));

                    //if (TestIDVal != "")
                    //{

                    //        Session["TestIDVal"] = splitid[i];


                    //}
                    //else
                    //{

                    //    lblalert.ForeColor = System.Drawing.Color.Red;
                    //    lblalert.Text = "Test Already Exist !!!";
                    //    MultiView1.SetActiveView(View1);
                    //            //}
                }
                //    }
            }
            //else
            //{
            //    lblalert.Text = "Please select atleast one Test  !!!";
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please select atleast one Test  !!!')", true);
        }
        //addrecord();
        //try 
        //{
        
        //    string ID = lblalert.Text;
        //    if(ID==""||ID==null)
        //    {
        //        addrecord();
        //    }
        //    else
        //    {
        //        RetrieveCombo();
        //    }
        //}
        //catch(Exception ex)
        //{
        
        //}
        
        
    }
    protected void ddlEvent_SelectedIndexChanged(object sender, EventArgs e)
    {
        //MultiView1.SetActiveView(View2);
        loadGrid();
    }

    protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Modify")
        {
            //btnCtreate.Text = "Update";
            string ID = Convert.ToString(e.CommandArgument);
            ID = Convert.ToString(lblalert.Text);
        }



    }
}

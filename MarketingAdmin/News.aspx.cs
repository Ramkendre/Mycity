using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class MarketingAdmin_News : System.Web.UI.Page
{
    NewsBLL NewsBLLobj = new NewsBLL();
    DataSet ds = new DataSet();
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDDL();
            //LoadDist();
            location();
        }

    }
    public void LoadDDL()
    {
        List<NewsBLL> newsObj = new List<NewsBLL>();
        newsObj = NewsBLLobj.getNewsDDL();
        ddlNewsName.DataSource = newsObj;
        ddlNewsName.DataTextField = "NewsPaperName";
        ddlNewsName.DataValueField = "NewsPaperId";
        ddlNewsName.DataBind();
        ddlNewsName.Items.Add("--Select--");
        ddlNewsName.SelectedIndex = ddlNewsName.Items.Count - 1;
        ddlNewsName.Items[ddlNewsName.Items.Count - 1].Value = "";
      
    
    }

    //public void LoadDist()
    //{
    //    List<NewsBLL> distObj = new List<NewsBLL>();
    //    distObj = NewsBLLobj.getDistNames();
    //    ddlDist.DataSource = distObj;
    //    ddlDist.DataTextField = "DistName";
    //    ddlDist.DataValueField = "DistId";
    //    ddlDist.DataBind();
    //    ddlDist.Items.Add("--Select--");
    //    ddlDist.SelectedIndex = ddlDist.Items.Count - 1;
    //    ddlDist.Items[ddlDist.Items.Count - 1].Value = "";
    
    //}
    public void location()
    {
        try
        {
            ds = (DataSet)Session["Location"];
            if (ds == null)
            {
                Location loc = new Location();
                ds = loc.getAllLocation();
                Session["Location"] = ds;
            }
            if (ds.Tables[0] != null)
            {

                ddlState.DataSource = ds.Tables[0];
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Add("--Select--");
                ddlState.Items[ddlState.Items.Count - 1].Value = " ";
                ddlDistrict.Items.Add("--Select--");
                ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
                //ddlCity.Items.Add("--Select--");
                //ddlCity.Items[ddlCity.Items.Count - 1].Value = " ";

                ddlState.SelectedIndex = ddlState.Items.Count - 1;
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = (DataSet)Session["Location"];
            if (ddlState.SelectedIndex != ddlState.Items.Count - 1)
            {
                if (ds.Tables[1] != null)
                {
                    DataRow[] dr = ds.Tables[1].Select("StateId=" + ddlState.SelectedValue.ToString() + "");
                    ddlDistrict.DataSource = getDataTable(dr);
                    ddlDistrict.DataTextField = "Name";
                    ddlDistrict.DataValueField = "Id";
                    ddlDistrict.DataBind();
                    ddlDistrict.Items.Add("--Select--");
                    ddlDistrict.Items[ddlDistrict.Items.Count - 1].Value = " ";
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.Count - 1;
                }
            }
            else
            {
                //ddlCity.Items.Clear();
                ddlDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    private DataTable getDataTable(DataRow[] dr1)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        try
        {
            foreach (DataRow dr in dr1)
            {
                DataRow ddr = dt.NewRow();
                ddr["Id"] = dr[0].ToString();
                ddr["Name"] = dr[1].ToString();
                dt.Rows.Add(ddr);
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        return dt;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        NewsBLLobj.DistId = Convert.ToInt32(Convert.ToString(ddlDistrict.SelectedValue));
        NewsBLLobj.NewsPaperId = Convert.ToInt32(Convert .ToString (ddlNewsName .SelectedValue ) );
        List<NewsBLL> nwsObj = NewsBLLobj.getNewsData(NewsBLLobj );
        gvNews.DataSource = nwsObj;
        gvNews.DataBind();

    }
}

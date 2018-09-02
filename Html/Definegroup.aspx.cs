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

public partial class html_Definegroup : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    int status;

    protected void Page_Load(object sender, EventArgs e)
    {
        string UserIdSession = Convert.ToString(Session["User"]);
        if (UserIdSession == "")
        {
            Response.Redirect("../default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!IsPostBack)
                    {
                        show();
                    }
                }
                catch (Exception ex)
                { }
            }
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {

        try
        {
            string Sql = "", GroupId = "", GroupName = "";
            foreach (GridViewRow gr in gvgroup.Rows)
            {
                try
                {
                    //lblGroupId
                    Label lbl = (Label)gr.Cells[0].FindControl("lblGroupId");
                    GroupId = GroupId + "," + lbl.Text.ToString();
                    TextBox txt = (TextBox)gr.Cells[1].FindControl("txtGroupName");
                    GroupName = GroupName + "," + txt.Text.ToString();
                }
                catch (Exception ex)
                { }

            }
            Sql = "Update UserMaster set GroupId='" + GroupId.Substring(1) + "',GroupName='" + GroupName.Substring(1) + "' " +
                " Where usrUserId='" + Convert.ToString(Session["User"]) + "' ";
            cc.ExecuteNonQuery(Sql);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Updated Successfully')", true);
        }
        catch (Exception ex)
        {
            //throw ex;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Group Not Updated')", true);
        }

    }

    public void show()
    {
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            string sql = "select groupid,groupname from usermaster where usrUserid='" + urUserRegBLLObj.usrUserId + "' ";
            DataSet ds = cc.ExecuteDataset(sql);
            object ss = ds.Tables[0].Rows[0][0];

            string sss = (string)ss;

            string[] ArrLine = sss.Split(',');
            object p = ds.Tables[0].Rows[0][1];
            string pp = (string)p;
            string[] groupname = pp.Split(',');
            DataTable dt = new DataTable();
            dt.Columns.Add("groupid", Type.GetType("System.String"));
            dt.Columns.Add("groupname", Type.GetType("System.String"));

            dt.Rows.Add();
            DataTable table = new DataTable();

            table.Columns.Add("groupid", Type.GetType("System.String"));
            foreach (string value in ArrLine)
            {
                DataRow row = table.NewRow();
                row["groupid"] = value;
                table.Rows.Add(row);
            }
            table.Columns.Add("groupname", Type.GetType("System.String"));
            int i = 0;
            foreach (string value in groupname)
            {
                DataRow row = table.NewRow();
                //DataRow sd[0][1]=table.NewRow();

                row["groupname"] = value;
                //table.Rows.Add(row);

                table.Rows[i++][1] = value;

            }
            gvgroup.DataSource = table;
            gvgroup.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    protected void gvgroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}

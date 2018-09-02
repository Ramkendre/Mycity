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

public partial class MarketingAdmin_MenuMaster1 : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Id = Convert.ToString(Request.QueryString["pageid"]);
            LoadValue(Id);

        }

    }
    private void LoadValue(string Id)
    {
        try
        {
            string userid = Session["MarketingUser"].ToString();
            string Role = Convert.ToString(Session["RoleId"]);
            if (Role == "34" || Role == "35" || Role == "36")
            {
                string sql = "select UseRole from [Come2myCityDB].[come2mycity].[MartketingSubuser] where Uid1='" + userid + "'";
                string rolename = cc.ExecuteScalar(sql);
                if (rolename == "SWF Region Head-Public" || rolename == "SWF District Head-Public" || rolename == "SWF Taluka Head-Public")
                {
                    string Menus = "19";
                    string Sql = "SELECT  pagename,pageurl from [Come2myCityDB].[come2mycity].[PageMenuMaster]  where pageparentid=" + Id + " and pageid in(" + Menus + ") ";
                    DataSet ds = cc.ExecuteDataset(Sql);
                    gvMenu.DataSource = ds.Tables[0];
                    gvMenu.DataBind();

                }
                else if (rolename == "SWF Region Head-Govt" || rolename == "SWF District Head-Govt" || rolename == "SWF Taluka Head-Govt")
                {
                    string Menus = "33";
                    string Sql = "SELECT  pagename,pageurl from [Come2myCityDB].[come2mycity].[PageMenuMaster]  where pageparentid=" + Id + " and pageid in(" + Menus + ") ";
                    DataSet ds = cc.ExecuteDataset(Sql);
                    gvMenu.DataSource = ds.Tables[0];
                    gvMenu.DataBind();

                }
            }
            else
            {
                string Sql = "select PageAccessPerm from [Come2myCityDB].[come2mycity].[SubMenuPermission] where RoleId='" + Role + "'";
                string Menus = Convert.ToString(cc.ExecuteScalar(Sql));

                Sql = "SELECT  pagename,pageurl from [Come2myCityDB].[come2mycity].[PageMenuMaster]  where pageparentid=" + Id + " and pageid in(" + Menus + ") ";
                DataSet ds = cc.ExecuteDataset(Sql);
                gvMenu.DataSource = ds.Tables[0];
                gvMenu.DataBind();
            }


        }
        catch (Exception ex)
        {

        }
    }
    protected void gvMenu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

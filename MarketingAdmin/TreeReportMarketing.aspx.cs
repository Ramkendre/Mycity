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
using System.Drawing;

public partial class MarketingAdmin_TreeReportMarketing : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateRootLevel();
    }
    private void PopulateRootLevel()
    {
        string userId = Convert.ToString(Session["Mobile"]);
        string mobileno = Convert.ToString(Session["MobileNumber"]);
        //string sql = "  select usrFirstName as firstName,usrMobileNo as m,usrAutoId as id,usrUserId,(select count(*)  from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='"+mobileno+"')as childnodecount from UserMaster where usrMobileNo='"+mobileno+"'";
        string sql = "select top 1  usrMobileNo as m,usrFirstName as firstName,ID,Parent_MobileNo,(select count(*) FROM [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] where Parent_MobileNo='" + mobileno + "')as childnodecount FROM [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] table1 right outer join UserMaster ws on usrMobileNo=table1.Parent_MobileNo  where usrMobileNo='" + mobileno + "'";
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        PopulateNodes(dt, TreeView1.Nodes);
    }
    private void PopulateNodes(DataTable dt, TreeNodeCollection nodes)
    {
        //TreeNode tn = new TreeNode();
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr["m"].ToString() + "(" + (dr["firstName"].ToString()) + ")";
            tn.Value = dr["Parent_MobileNo"].ToString();
            string name = dr["firstName"].ToString();
            string nchild = dr["childnodecount"].ToString();

            nodes.Add(tn);
            tn.ToolTip = name;
            string id = Convert.ToString(tn.Value.ToString());

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
            int count = Convert.ToInt32(dr["childnodecount"].ToString());
           
        }

    }
    private void PopulateNodes1(DataTable dt, TreeNodeCollection nodes)
    {
        //TreeNode tn = new TreeNode();
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr["m"].ToString() + "(" + (dr["firstName"].ToString()) + ")";
            tn.Value = dr["Child_MobileNo"].ToString();
            string name = dr["firstName"].ToString();
            string nchild = dr["childnodecount"].ToString();

            nodes.Add(tn);
            tn.ToolTip = name;
            string id = Convert.ToString(tn.Value.ToString());

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
            int count = Convert.ToInt32(dr["childnodecount"].ToString());
           
        }

    }
    private void PopulateSubLevel(string Parent_MobileNo, TreeNode parentNode)
    {
        string str = "select distinct mobileNo as m,firstName as firstName,ID,Child_MobileNo,Parent_MobileNo,(select count(*) FROM [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] where Parent_MobileNo=table1.Child_MobileNo) childnodecount FROM [Come2myCityDB].[come2mycity].[tbl_TreeDemOfMarketingSection] table1 inner join [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] ws on mobileNo=table1.Child_MobileNo where  Parent_MobileNo=@Parent_MobileNo";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.Add("@Parent_MobileNo", Parent_MobileNo);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        PopulateNodes1(dt, parentNode.ChildNodes);
        //PopulateNodes(ds.Tables[0], parentNode.ChildNodes);  

    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevel(Convert.ToString(e.Node.Value), e.Node);
    }
}

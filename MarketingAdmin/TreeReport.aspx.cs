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

public partial class MarketingAdmin_TreeReport : System.Web.UI.Page
{
    string UserName = "";
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //PopulateRootLevelM();


        }
        
    }
    protected void lnkNameWise_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View2);
        PopulateRootLevelN();
        //LoadGridLogin();

    }
    protected void lnkMobileNoWise_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(View1);
        PopulateRootLevelM();
        //LoadGridLogin();
    }
    private void PopulateRootLevelM()
    {
        string sql1 = "";
        UserName = Convert.ToString(Session["MarketingUser"]);
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        if (UserName == "Admin")
        {
            sql1 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster" +
                        " on usrUserId =userid where  parentID=0";
            SqlCommand cmd = new SqlCommand(sql1, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodesM(dt, TreeView1.Nodes);
        }
        else
        {
            string query = "select roleid from AdminSubMarketingSubUser where friendid='" + UserName + "'";
            string roleid = cc.ExecuteScalar(query);
            if (roleid == "2")
            {
                sql1 = "select friendid from AdminSubMarketingSubUser where userid='" + UserName + "'";
                DataSet ds = cc.ExecuteDataset(sql1);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string userid = Convert.ToString(dr["friendid"]);
                    sql1 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster on usrUserId =userid where userid='" + userid + "' and parentID=0";
                    SqlCommand cmd = new SqlCommand(sql1, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    PopulateNodesM(dt, TreeView1.Nodes);
                }

            }
            else
            {
                string query1 = "select id from Treedemo where userid='" + UserName + "'";
                string parentid = cc.ExecuteScalar(query1);
                sql1 = "select friendid from AdminSubMarketingSubUser where userid='" + UserName + "'";
                DataSet ds = cc.ExecuteDataset(sql1);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string userid = Convert.ToString(dr["friendid"]);
                    sql1 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster on usrUserId =userid where userid='" + userid + "' and parentID='" + parentid + "'";
                    SqlCommand cmd = new SqlCommand(sql1, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    PopulateNodesM(dt, TreeView1.Nodes);
                }

            }
        }



    }
    private void PopulateNodesM(DataTable dt, TreeNodeCollection nodes)
    {
        //TreeNode tn = new TreeNode();
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr["FullName"].ToString();
            tn.Value = dr["id"].ToString();
            string name = dr["name"].ToString();

            nodes.Add(tn);
            tn.ToolTip = name;
            //int id = Convert.ToInt32(tn.Value.ToString()); 

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
            //int count = Convert.ToInt32(dr["childnodecount"].ToString());
            //if (count >= 0)
            //{
            //    PopulateSubLevel(id, tn);
            //}

        }



    }
    private void PopulateSubLevelM(int parentid, TreeNode parentNode)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string sql12 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name, id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster" +
            " on usrUserId =userid where parentID=@parentID";
        SqlCommand cmd = new SqlCommand(sql12, cn);
        cmd.Parameters.Add("@parentID", SqlDbType.Int).Value = parentid;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        PopulateNodesM(dt, parentNode.ChildNodes);


    }
    protected void TreeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        PopulateSubLevelM(Convert.ToInt32(e.Node.Value), e.Node);
        //PopulateSubLevel(e.Node.Value, e.Node);
    }
    private void PopulateRootLevelN()
    {
        string sql1 = "";
        UserName = Convert.ToString(Session["MarketingUser"]);
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        if (UserName == "Admin")
        {
            sql1 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster" +
                        " on usrUserId =userid where  parentID=0";
            SqlCommand cmd = new SqlCommand(sql1, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            PopulateNodesN(dt, TreeView2.Nodes);
        }
        else
        {
            string query = "select roleid from AdminSubMarketingSubUser where friendid='" + UserName + "'";
            string roleid = cc.ExecuteScalar(query);
            if (roleid == "2")
            {
                sql1 = "select friendid from AdminSubMarketingSubUser where userid='" + UserName + "'";
                DataSet ds = cc.ExecuteDataset(sql1);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string userid = Convert.ToString(dr["friendid"]);
                    sql1 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster on usrUserId =userid where userid='" + userid + "' and parentID=0";
                    SqlCommand cmd = new SqlCommand(sql1, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    PopulateNodesN(dt, TreeView2.Nodes);
                }

            }
            else
            {
                string query1 = "select id from Treedemo where userid='" + UserName + "'";
                string parentid = cc.ExecuteScalar(query1);
                sql1 = "select friendid from AdminSubMarketingSubUser where userid='" + UserName + "'";
                DataSet ds = cc.ExecuteDataset(sql1);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string userid = Convert.ToString(dr["friendid"]);
                    sql1 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name,id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster on usrUserId =userid where userid='" + userid + "' and parentID='" + parentid + "'";
                    SqlCommand cmd = new SqlCommand(sql1, cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    PopulateNodesN(dt, TreeView2.Nodes);
                }

            }
        }



    }
    private void PopulateNodesN(DataTable dt, TreeNodeCollection nodes)
    {
        //TreeNode tn = new TreeNode();
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr["name"].ToString();
            tn.Value = dr["name"].ToString();
            //tn.Value = dr["id"].ToString();
            string name = dr["FullName"].ToString();

            nodes.Add(tn);
            tn.ToolTip = name;
            //int id = Convert.ToInt32(tn.Value.ToString()); 

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
            //int count = Convert.ToInt32(dr["childnodecount"].ToString());
            //if (count >= 0)
            //{
            //    PopulateSubLevel(id, tn);
            //}

        }



    }
    private void PopulateSubLevelN(string name, TreeNode parentNode)
    {
        DataSet ds0 = new DataSet();
        string d = "select usrUserid from UserMaster where usrFirstName+''+usrLastName='" + name + "'";
        ds0=cc.ExecuteDataset(d);
        string uid=ds0.Tables[0].Rows[0][0].ToString();
        string st = "select id from TreeDemo where [userid]='" + uid + "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(st);
        int parentid = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        string sql12 = "select usrMobileNo as FullName,usrFirstName+''+usrLastName as name, id,userid,(select count(*) FROM TreeDemo WHERE parentID=sc.id) childnodecount FROM TreeDemo sc inner join usermaster" +
            " on usrUserId =userid where parentID=@parentID";
        SqlCommand cmd = new SqlCommand(sql12, cn);
        cmd.Parameters.Add("@parentID", SqlDbType.Int).Value = parentid;
        //cmd.Parameters.Add("@name", SqlDbType.Text).Value = name;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        PopulateNodesN(dt, parentNode.ChildNodes);


    }
    protected void TreeView2_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        //PopulateSubLevelN(Convert.ToInt32(e.Node.Value), e.Node);
        PopulateSubLevelN( Convert.ToString(e.Node.Value), e.Node);
        //PopulateSubLevel(e.Node.Value, e.Node);
    }



    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
    protected void btnback2_Click(object sender, EventArgs e)
    {
        //Response.Redirect("../MarketingAdmin/MenuMaster1.aspx?pageid=2");
    }
}

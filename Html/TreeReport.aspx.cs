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

public partial class Html_TreeReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            PopulateRootLevel();


        }
        
    }
    private void PopulateRootLevel()
    {
        string userId = Convert.ToString(Session["User"]);
        string mobileno = Convert.ToString(Session["MobileNo"]);
        //string sql = "  select usrFirstName as firstName,usrMobileNo as m,usrAutoId as id,usrUserId,(select count(*)  from [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] where [RefMobileNo]='"+mobileno+"')as childnodecount from UserMaster where usrMobileNo='"+mobileno+"'";
        string sql = "select top 1  usrMobileNo as m,usrFirstName as firstName,ID,Senior_ID,(select count(*) FROM [Come2myCityDB].[dbo].[tbl_TreeDemo] where SMobile_No='" + mobileno + "')as childnodecount FROM [Come2myCityDB].[dbo].[tbl_TreeDemo] table1 right outer join UserMaster ws on usrUserId=table1.Senior_ID  where usrMobileNo='" + mobileno + "'";
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
            tn.Text = dr["m"].ToString() + "("+( dr["firstName"].ToString())+")";
            tn.Value = dr["Senior_ID"].ToString();
            string name = dr["firstName"].ToString();
            string nchild = dr["childnodecount"].ToString();

            nodes.Add(tn);
            tn.ToolTip = name;
            string id = Convert.ToString(tn.Value.ToString());

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
            int count = Convert.ToInt32(dr["childnodecount"].ToString());
            //if (count >= 0)
            //{
            //    PopulateSubLevel(id, tn);
            //}

        }



    }
    private void PopulateNodes1(DataTable dt, TreeNodeCollection nodes)
    {
        //TreeNode tn = new TreeNode();
        foreach (DataRow dr in dt.Rows)
        {
            TreeNode tn = new TreeNode();
            tn.Text = dr["m"].ToString() + "("+(dr["firstName"].ToString())+")";
            tn.Value = dr["Child_ID"].ToString();
            string name = dr["firstName"].ToString();
            string nchild = dr["childnodecount"].ToString();

            nodes.Add(tn);
            tn.ToolTip = name;
            string id = Convert.ToString(tn.Value.ToString());

            tn.PopulateOnDemand = (Convert.ToInt32(dr["childnodecount"]) > 0);
            int count = Convert.ToInt32(dr["childnodecount"].ToString());
            //if (count >= 0)
            //{
            //    PopulateSubLevel(id, tn);
            //}

        }



    }
    private void PopulateSubLevel(string senior_ID, TreeNode parentNode)
    {


        //string str = "select Child_ID form TreeDemo where senior_ID='" + senior_ID + "'";

         string str = "select mobileNo as m,firstName as firstName,ID,Child_ID,Senior_ID,(select count(*) FROM [Come2myCityDB].[dbo].[tbl_TreeDemo] where Senior_ID=table1.Child_ID) childnodecount FROM [Come2myCityDB].[dbo].[tbl_TreeDemo] table1 inner join [Come2myCityDB].[dbo].[EzeeDrugsAppDetail] ws on UserId=table1.Child_ID where  Senior_ID=@Senior_ID";
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.Parameters.Add("@Senior_ID", senior_ID);
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

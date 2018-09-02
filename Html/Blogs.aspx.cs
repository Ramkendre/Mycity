using System;
using System.Collections.Generic;
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

public partial class Html_Blogs : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    BlogBll BlogBllObj = new BlogBll();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                loadDdlGroupList();
                //updateBlog(9);
            }
            catch (Exception rrr)
            {
                throw rrr;
            }
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int index = Convert.ToInt32(Convert.ToString(ddlGroupNm.SelectedValue));
        //updateBlog(index);
    }
    public void loadDdlGroupList()
    {
        try
        {
            string userId = Convert.ToString(Session["User"]);
            string  sqlDllGr = "select GroupValueId,GroupValueName from GroupValue inner join UserGroup on ";
            sqlDllGr += "UserGroup.GroupId=GroupValue.GroupValueId";
            sqlDllGr+=" where UserGroup.UserId='"+userId .ToString ()+"'";
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(sqlDllGr );
            ddlGroupNm.DataSource = ds;
            ddlGroupNm.DataValueField = "GroupValueId";
            ddlGroupNm.DataTextField = "GroupValueName";
            ddlGroupNm.DataBind();
            ddlGroupNm.Items.Add("--Select--");
            ddlGroupNm.SelectedIndex = ddlGroupNm.Items.Count - 1;
            ddlGroupNm.Items[ddlGroupNm.Items.Count - 1].Value = "";


        }
        catch (Exception rrrr)
        {
            throw rrrr;
        }
        
    }

    public void updateBlog(int id)
    {

        //string sql = "select top 15 bgId,BgWriter,Bg,BgDate,aggri,notAggri from tblBlog where bgGrId=" + id + " order by(BgDate) DESC";
        //string sql= "select top 15 b.bgId,b.BgWriter,b.Bg,b.BgDate,b.aggri,b.notAggri,'~\User_Resource\' + UM.usrUserId + '\Profile_Photo\' + UM.usrProfilePhoto AS usrProfilePhoto from tblBlog b inner join UserMaster UM on b.BgWriter=UM.usrFirstName+' '+UM.usrLastName where bgGrId="+id +" order by(BgDate) DESC";
        
        //DataSet ds = new DataSet();
        //ds.Clear();
        //ds = cc.ExecuteDataset(sql );
        BlogBllObj.bgId = id;
        List<BlogBll> lst = new List<BlogBll>();
        lst = BlogBllObj.getBlogData(BlogBllObj);
        gvBlogData.DataSource = lst;
        gvBlogData.DataBind();
        UpdatePanel1.Update();
        //this.UpdatePanel1.Update();

    
    }
    protected void ddlGroupNm_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Convert.ToInt32(Convert.ToString(ddlGroupNm.SelectedValue));
        updateBlog(index );
    }

    public void chkAggri_OnCheckedChanged(object sender, EventArgs e)
    {
        try
        {
            
            CheckBox chkStatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
            string cid = row.Cells[0].Text;
            string userId = Convert.ToString(Session["User"]);
            string SqlUsrMoNo = "select usrMobileNo from userMaster where usrUserId='" + userId .ToString ()+ "'";
            string mono = cc.ExecuteScalar(SqlUsrMoNo);
            string SqlAgg = "select aggri,AggriMoNo,NotAggriMoNo from tblBlog where bgId=" + Convert.ToInt32(cid);
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(SqlAgg );
            int TotAgg =0;
            string aggMoNos="";
            string NotAggriMoNo = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TotAgg = Convert.ToInt32(dr["aggri"]);
                aggMoNos = Convert.ToString(dr["AggriMoNo"]);
                NotAggriMoNo = Convert.ToString(dr["NotAggriMoNo"]);
            }
            string[] monoSplit = aggMoNos.Split(',');
            bool visited = false;
            for (int i = 0; i < monoSplit.Length; i++)
            {
                if (visitedUser (monoSplit [i ].ToString (),mono .ToString ()))
                {
                    visited = true;
                    break;
                }
            }
            // Check Anather Visit
            string[] monoSplitAna = NotAggriMoNo.Split(',');
            bool visitedAna = false;
            for (int i = 0; i < monoSplitAna.Length; i++)
            {
                if (visitedUser(monoSplitAna[i].ToString(), mono.ToString()))
                {
                    visitedAna = true;
                    break;
                }
            }

            if (visitedAna != true)
            {
                if (visited == true)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Thank you, You are voted Like already!')", true);
                }
                else
                {
                    if (aggMoNos == "")
                    {
                        aggMoNos += mono.ToString();
                    }
                    else
                    {
                        aggMoNos += "," + mono.ToString();
                    }
                    TotAgg += 1;
                    string sqlUpdate = "update tblBlog set aggri=" + TotAgg + ",AggriMoNo='" + aggMoNos.ToString() + "' where bgId=" + cid;
                    int ijk = cc.ExecuteNonQuery(sqlUpdate);
                    if (ijk > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Thank you,You are aggri.')", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry,You are woted not aggri already.')", true);
            }

        }
        catch (Exception pp)
        {
            throw pp;
        }
        DataTable dt = new DataTable();
        dt.Rows.Clear();
        gvBlogData.DataSource = dt;
        gvBlogData.DataBind();
        int index = Convert.ToInt32(Convert.ToString(ddlGroupNm.SelectedValue));
        updateBlog(index);
        //ddlGroupNm_SelectedIndexChanged(sender, e);       
    }

    public bool visitedUser(string n1,string n2)
    {
        bool yesNo = false;
        char[] no1 = n1.ToCharArray();
        char[] no2 = n2.ToCharArray();
        int i = 0, j = 0;
        for (;i < no1 .Length && j < no2 .Length ; )
        {
            if (no1[i] == no2[j])
            {
                i++;
                j++;
            }
            else
            {
                break;
            }
        }
        if (i == no1.Length && j == no2.Length )
        {
            yesNo = true;
        }
            return yesNo;
    }
    public void chkNotAggri_OnCheckedChanged(object sender, EventArgs e)
    {
        try
        {

            CheckBox chkStatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
            string cid = row.Cells[0].Text;
            string userId = Convert.ToString(Session["User"]);
            string SqlUsrMoNo = "select usrMobileNo from userMaster where usrUserId='" + userId.ToString() + "'";
            string mono = cc.ExecuteScalar(SqlUsrMoNo);
            string SqlAgg = "select notAggri,AggriMoNo,NotAggriMoNo from tblBlog where bgId=" + Convert.ToInt32(cid);
            DataSet ds = new DataSet();
            ds = cc.ExecuteDataset(SqlAgg);
            int TotAgg = 0;
            string aggMoNos = "";
            string AggriAnather = "";
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                TotAgg = Convert.ToInt32(dr["notAggri"]);
                aggMoNos = Convert.ToString(dr["NotAggriMoNo"]);
                AggriAnather = Convert.ToString(dr["AggriMoNo"]);
            }
            string[] monoSplit = aggMoNos.Split(',');
            bool visited = false;
            for (int i = 0; i < monoSplit.Length; i++)
            {
                if (visitedUser(monoSplit[i].ToString(), mono.ToString()))
                {
                    visited = true;
                    break;
                }
            }

            //Check aggri anather
            string[] monoSplitAnather = AggriAnather.Split(',');
            bool visitedAnather = false;
            for (int i = 0; i < monoSplitAnather.Length; i++)
            {
                if (visitedUser(monoSplitAnather[i].ToString(), mono.ToString()))
                {
                    visitedAnather = true;
                    break;
                }
            }

            if (visitedAnather != true)
            {

                if (visited == true)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Thank you, You are already not aggri woted.')", true);
                }
                else
                {
                    if (aggMoNos == "")
                    {
                        aggMoNos += mono.ToString();
                    }
                    else
                    {
                        aggMoNos += "," + mono.ToString();
                    }
                    TotAgg += 1;
                    string sqlUpdate = "update tblBlog set notAggri=" + TotAgg + ",NotAggriMoNo='" + aggMoNos.ToString() + "' where bgId=" + cid;
                    int ijk = cc.ExecuteNonQuery(sqlUpdate);
                    if (ijk > 0)
                    {

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Thank you,You are not aggri woted.')", true);
                    }
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Sorry,You are already aggri woted.')", true);
            
            }

        }
        catch (Exception pp)
        {
            throw pp;
        }
        DataTable dt = new DataTable();
        dt.Rows.Clear();
        gvBlogData.DataSource = dt;
        gvBlogData.DataBind();
        int index = Convert.ToInt32(Convert.ToString(ddlGroupNm.SelectedValue));
        updateBlog(index);
    }
    
    
    protected void gvBlogData_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
       // int i =gvBlogData .SelectedIndex ;
       // //Override GridView's RowUpdating event to update the datafield values.
       //  GridViewRow grdvwrw_UPD =((GridView)sender).Rows[i ];
       //bool value;
       // value = ((CheckBox)grdvwrw_UPD.Cells[0].FindControl("chk1")).Checked;
       // if (value == true)
       // {
       //    e.NewValues.Add("RESULTS", 1);
       // }
       // else
       // {
       //    e.NewValues.Add("RESULTS", 0);
       // }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UpdatePanel1.Update();
    }
}

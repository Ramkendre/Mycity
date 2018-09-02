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

public partial class Html_PaidGroup : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    static string gr1 = "", gr2 = "", gr3 = "", gr4 = "", gr5 = "";
    string UserId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrNames();
            loadPaidGroups();
            PaidBal();
        }
    }
    public void PaidBal()
    {
        string sqlSpaidBal = "select paidCount from userMaster where usrUserId='" + Convert.ToString(Session["User"]) + "'";
        lblPaidRemBal.Text = Convert.ToString(cc.ExecuteScalar (sqlSpaidBal ));

    }
    public void loadPaidGroups()
    {
        string Uid = Convert.ToString(Session["User"]);
        string sqlGroup = "select top 5 GrName from tblPaidSmsGroup where UserId='" + Uid .ToString ()+ "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlGroup );
        DataTable dt = new DataTable();
        dt.Columns.Add("GroupId",typeof (int));
        dt.Columns .Add ("GroupName",typeof (string));
        string name="";
        int id=0;
        foreach (DataRow dr in ds .Tables [0].Rows )
        {
        name = Convert .ToString (dr ["GrName"]);
        id =id +1;
        dt .Rows .Add (id ,name );            
        }
        ddlGIgroupName .DataSource = dt ;
        ddlGIgroupName .DataValueField = "GroupId";
        ddlGIgroupName .DataTextField ="GroupName";
        ddlGIgroupName.DataBind();
        ddlGIgroupName.Items.Add("--SELECT--");
        ddlGIgroupName.SelectedIndex = ddlGIgroupName.Items.Count - 1;
        ddlGIgroupName.Items[ddlGIgroupName.Items.Count - 1].Value = "";

        ddlPaidGroup.DataSource = dt;
        ddlPaidGroup.DataValueField = "GroupId";
        ddlPaidGroup.DataTextField = "GroupName";
        ddlPaidGroup.DataBind();
        ddlPaidGroup.Items.Add("--SELECT--");
        ddlPaidGroup.SelectedIndex = ddlPaidGroup.Items.Count - 1;
        ddlPaidGroup.Items[ddlPaidGroup.Items.Count - 1].Value = "";

        
    
    }
    public void LoadGrNames()
    {
        UserId = Convert.ToString(Session["User"]);
        string sqlgr = "select Top 5 GrName from tblPaidSmsGroup where UserId='"+UserId .ToString ()+"'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlgr );
        int i = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (i == 0)
            {
                txtGrFirst.Text = Convert.ToString(dr["GrName"]);
                gr1 = Convert.ToString(dr["GrName"]);
                i++;
            }
            else if (i == 1)
            {
                txtGrSecond .Text = Convert.ToString(dr["GrName"]);
                gr2 = Convert.ToString(dr["GrName"]);
                i++;
            }
            else if (i == 2)
            {
                txtGrThird.Text = Convert.ToString(dr["GrName"]);
                gr3 = Convert.ToString(dr["GrName"]);
                i++;
            }
            else if (i == 3)
            {
                txtGrFourth .Text = Convert.ToString(dr["GrName"]);
                gr4 = Convert.ToString(dr["GrName"]);
                i++;
            }
            else if (i == 4)
            {
                txtGrFive .Text = Convert.ToString(dr["GrName"]);
                gr5 = Convert.ToString(dr["GrName"]);
                i++;
            }
        }
        loadPaidGroups();
    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserId = Convert.ToString(Session["User"]);
        if (gr1 .ToString () != "" || gr2 .ToString () !="" || gr3 .ToString () != "" || gr4 .ToString ()!="" || gr5 .ToString () !="")
        {
            string sqlUpdate = "update tblPaidSmsGroup";
                   sqlUpdate +=" set GrName=case GrName";
                   sqlUpdate += " when '" + gr1.ToString() + "' then '"+txtGrFirst .Text .ToString ()+"'";
                   sqlUpdate += " when '" + gr2.ToString() + "' then '"+txtGrSecond .Text .ToString ()+"'";
                   sqlUpdate += " when '" + gr3.ToString() + "' then '"+txtGrThird .Text .ToString ()+"'";
                   sqlUpdate += " when '" + gr4.ToString() + "' then '"+txtGrFourth .Text .ToString ()+"'";
                   sqlUpdate += " when '" + gr5.ToString() + "' then '"+txtGrFive .Text .ToString ()+"'";
                   sqlUpdate +=" End ";
                   sqlUpdate += " where UserId='" + UserId .ToString ()+ "'";
             int I = cc.ExecuteNonQuery(sqlUpdate );
        }
        else if (txtGrFirst.Text != "" && txtGrSecond.Text != "" && txtGrThird.Text != "" && txtGrFourth.Text != "" && txtGrFive.Text != "")
        {
            if (txtGrFirst.Text.ToString() != "")
            {
                string sqlU = "insert into tblPaidSmsGroup(UserID,GrName)";
                       sqlU +=" values('"+UserId .ToString ()+"','"+txtGrFirst .Text .ToString ()+"')";
                       int i = cc.ExecuteNonQuery(sqlU );
            }

            if (txtGrSecond.Text.ToString() != "")
            {
                string sqlU = "insert into tblPaidSmsGroup(UserID,GrName)";
                sqlU += " values('" + UserId.ToString() + "','" + txtGrSecond.Text.ToString() + "')";
                int i = cc.ExecuteNonQuery(sqlU);
            }

            if (txtGrThird.Text.ToString() != "")
            {
                string sqlU = "insert into tblPaidSmsGroup(UserID,GrName)";
                sqlU += " values('" + UserId.ToString() + "','" + txtGrThird.Text.ToString() + "')";
                int i = cc.ExecuteNonQuery(sqlU);
            }

            if (txtGrFourth.Text.ToString() != "")
            {
                string sqlU = "insert into tblPaidSmsGroup(UserID,GrName)";
                sqlU += " values('" + UserId.ToString() + "','" + txtGrFourth.Text.ToString() + "')";
                int i = cc.ExecuteNonQuery(sqlU);
            }

            if (txtGrFive.Text.ToString() != "")
            {
                string sqlU = "insert into tblPaidSmsGroup(UserID,GrName)";
                sqlU += " values('" + UserId.ToString() + "','" + txtGrFive.Text.ToString() + "')";
                int i = cc.ExecuteNonQuery(sqlU);
            }
        
        }
    }
    protected void ddlGIgroupName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedGroupId = Convert.ToInt32(ddlGIgroupName.SelectedValue);
        UserId = Convert.ToString(Session["User"]);
        string sqlGV = "select GM.MemMoNo,GM.MemFName,GM.MemLName from tblGroupSmsMember GM inner join tblPaidSmsGroup GID on GM.GrIdRf = GID.GrId where GM.GroupId='" + Convert.ToInt32(selectedGroupId) + "' AND GID.UserId='" + UserId.ToString() + "'";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlGV );
        DataTable dt = new DataTable();
        dt.Columns .Add ("id",typeof (int ));
        dt.Columns .Add ("mno",typeof (string ));
        dt.Columns .Add ("fnm",typeof (string ));
        dt.Columns .Add ("lnm",typeof (string ));
        int mid = 0;

        try
        {
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dt.Rows.Add(mid++, Convert.ToString(dr["MemMoNo"]), Convert.ToString(dr["MemFName"]), Convert.ToString(dr["MemLName"]));
                }
                gvInsertMem.DataSource = dt;
                gvInsertMem.DataBind();
            }

        }
        catch (Exception rrr)
        {
            gvInsertMem.Columns.Clear();
            //gvInsertMem.Rows = "";
        }
        
    }
    protected void btnInsertPan2_Click(object sender, EventArgs e)
    {
        string  selectedGroupId = Convert.ToString (ddlGIgroupName.SelectedItem );
        int paidGrId = Convert.ToInt32(ddlGIgroupName .SelectedValue );
        UserId = Convert.ToString(Session["User"]);
        string sqlfid = "select GrId from tblPaidSmsGroup where UserId='" + UserId .ToString ()+ "' AND GrName='" + selectedGroupId.ToString() + "'";
        string refStrId = cc.ExecuteScalar(sqlfid);
        int refId = Convert.ToInt32(refStrId);
        string insertSql = "insert into tblGroupSmsMember(MemMoNo,MemFName,MemLName,GroupId,GrIdRf)";
        insertSql += " values('" + txtGImobileNo.Text.ToString() + "','" + txtGIfirstName.Text.ToString() + "','" + txtGIlastName.Text.ToString() + "'," + Convert.ToInt32(paidGrId) + "," + Convert.ToInt32(refId) + ")";
        int recins = cc.ExecuteNonQuery(insertSql);
        if (recins > 0)
        {
            Response.Write("<SCRIPT>alert('One Member Inserted.')</SCRIPT>");
            txtGIfirstName.Text = "";
            txtGIlastName.Text = "";
            txtGImobileNo.Text = "";
            ddlGIgroupName.SelectedIndex = ddlGIgroupName.Items.Count - 1;
        }
        //int selectedGroupId1 = Convert.ToInt32(ddlGIgroupName.SelectedValue);
        //UserId = Convert.ToString(Session["User"]);
        //string sqlGV = "select GM.MemMoNo,GM.MemFName,GM.MemLName from tblGroupSmsMember GM inner join tblPaidSmsGroup GID on GM.GrIdRf = GID.GrId where GM.GroupId='" + Convert.ToInt32(selectedGroupId1) + "' AND GID.UserId='" + UserId.ToString() + "'";
        //DataSet ds = new DataSet();
        //ds = cc.ExecuteDataset(sqlGV);
        //DataTable dt = new DataTable();
        //dt.Columns.Add("id", typeof(int));
        //dt.Columns.Add("mno", typeof(string));
        //dt.Columns.Add("fnm", typeof(string));
        //dt.Columns.Add("lnm", typeof(string));
        //int mid = 0;

        //try
        //{
        //    if (ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            dt.Rows.Add(mid++, Convert.ToString(dr["MemMoNo"]), Convert.ToString(dr["MemFName"]), Convert.ToString(dr["MemLName"]));
        //        }
        //        gvInsertMem.DataSource = dt;
        //        gvInsertMem.DataBind();
        //    }

        //}
        //catch (Exception rrr)
        //{
        //    gvInsertMem.Columns.Clear();
        //    //gvInsertMem.Rows = "";
        //}

    }
    protected void btnSendPaidSMS_Click(object sender, EventArgs e)
    {
        string selGrNm = ddlPaidGroup.SelectedValue.ToString();
        string usrId = Convert.ToString(Session["User"]);
        string sqlMem = "select m.MemMoNo ";
               sqlMem+=" from  tblGroupSmsMember m inner join tblPaidSmsGroup g";
               sqlMem+=" on m.GrIdRf = g.GrId";
               sqlMem += " where g.UserId='" + usrId.ToString() + "' AND m.GroupId=" + selGrNm.ToString() + ";";
        DataSet ds = new DataSet();
        ds = cc.ExecuteDataset(sqlMem );
        string mobileNo = "";
        string strMsg = "";
        strMsg = txtSmsText.Text.ToString() + " Via:www.myct.in";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            mobileNo = Convert.ToString(dr["MemMoNo"]);
            cc.SendMessage1(mobileNo ,mobileNo ,strMsg );
        }
    }
}

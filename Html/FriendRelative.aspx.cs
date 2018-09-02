using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.ApplicationBlocks.Data;
using System.Data.OleDb;

public partial class Html_FriendRelative : System.Web.UI.Page
{

    string currFilePath = string.Empty; //File Full Path
    string currFileExtension = string.Empty;  //File Extension
    CommonCode cc = new CommonCode();
    CommonSqlQueryCode cqc = new CommonSqlQueryCode();
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLObj = new FriendGroupBLL();
    DropDownList drdList;

    public DataTable dtFriendGroup;
    int status;
    PagedDataSource pds = new PagedDataSource();
    string userId;
    string FriId, FriReid;
    string cityName;
    string FriName;
    string[] RgArr;
    //string cityNameN;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
                    FriendImageLoad();
                    //LoadFriendRelative();
                    pnlfrndRel.Visible = false;
                    pnlFriend.Visible = false;
                    pnlSelectLocation.Visible = false;
                    //pnlfrndlist.Visible = false;
                    FriendGroupLoad();
                }
            }
        }
        catch { }
    }

    #region LoadFriRelatives
    public void LoadFriendRelative()
    {
        try
        {
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            pds.AllowPaging = true;
            pds.PageSize = 20;
            pds.CurrentPageIndex = CurrentPage;
            // lnkNext.Enabled = !pds.IsLastPage;
            // lnkPrev.Enabled = !pds.IsFirstPage;
            dlFriendRelative.DataSource = pds;
            dlFriendRelative.DataBind();
            // doPaging();
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    #endregion

    #region FriendImageLoad
    private void FriendImageLoad()
    {
        ArrayList arr = new ArrayList();
        DataTable dt = new DataTable();
        try
        {
            string user = Convert.ToString(Session["User"]);
            string sql1 = "select usrAutoId,usrFirstname+' '+usrLastName as FullName,usrUserid from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId = FriendRelationMaster.FriendId where FriendRelationMaster.userid='" + user + "'";
            DataSet ds = cc.ExecuteDataset(sql1);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string usrAutoId = Convert.ToString(dr["usrAutoId"]);
                string usrFirstname = Convert.ToString(dr["FullName"]);
                string userid = Convert.ToString(dr["usrUserid"]);
                string sql = "select id from storeimage where usrAutoId='" + usrAutoId + "'";
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                    usrAutoId = "0";
                    id = "1";

                    arr.Add(id);
                    arr.Add(usrFirstname);
                    arr.Add(userid);
                }
                else
                {
                    arr.Add(id);
                    arr.Add(usrFirstname);
                    arr.Add(userid);
                }
            }
            int i;
            DataColumn dc = new DataColumn();
            DataColumn dc1 = new DataColumn();
            DataColumn dc2 = new DataColumn();
            dc.ColumnName = "id";
            dc1.ColumnName = "FullName";
            dc2.ColumnName = "userid";
            dt.Columns.Add(dc);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            for (i = 0; i < arr.Count; i = i + 2)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = arr[i];
                dr["FullName"] = arr[i + 1];
                dr["userid"] = arr[i + 2];

                dt.Rows.Add(dr);
                i++;
            }
            dlFriendRelative.DataSource = dt;
            dlFriendRelative.DataBind();
        }
        catch (Exception ex)
        { }
    }
    #endregion

    protected void btnSearchFriRel_Click(object sender, EventArgs e)
    {
        pnlFriend.Visible = true;
        FriendRelativeSearch();
    }

    public DataTable FriendGroup()
    {
        //dtFriendGroup = fgBLLObj.BLLShowAllFriendGroup(urUserRegBLLObj);
        dtFriendGroup = urUserRegBLLObj.BLLShowAllFriendGroup(urUserRegBLLObj);
        return dtFriendGroup;
    }

    #region FriendRelativeSearch
    public void FriendRelativeSearch()
    {
        try
        {
            urUserRegBLLObj.usrAltMobileNo = Convert.ToString(Session["Mobile"]);
            urUserRegBLLObj.usrMobileNo = Convert.ToString(txtSearchFriRel.Text);
            DataTable dtUserList = urUserRegBLLObj.BLLFriendRelativeByMob(urUserRegBLLObj);
            urUserRegBLLObj.usrUserId = Convert.ToString(Session["User"]);
            dtFriendGroup = urUserRegBLLObj.BLLShowAllFriendGroup(urUserRegBLLObj);
            gvFriendRelativeSearch.DataSource = dtUserList;
            gvFriendRelativeSearch.DataBind();
            txtSearchFriRel.Text = "";
            foreach (GridViewRow grdRow in gvFriendRelativeSearch.Rows)
            {
                string sql = "select GroupName from usermaster where usrUserId='" + urUserRegBLLObj.usrUserId + "'";
                DataSet ds = new DataSet();
                ds = cc.ExecuteDataset(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string Gname = Convert.ToString(ds.Tables[0].Rows[0]["GroupName"]);
                    string[] tmp = Gname.Split(',');
                    //drdList.Items.Clear();
                    drdList = (DropDownList)(gvFriendRelativeSearch.Rows[grdRow.RowIndex].Cells[0].FindControl("cmbGroupType"));
                    foreach (string s in tmp)
                    {
                        drdList.Items.Add(s);
                        drdList.ID.Insert(0, s);
                    }
                    if (drdList.SelectedValue == "All")
                    {
                        cqc.FR1 = drdList.SelectedValue;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region RowcommandSearch
    protected void gvFriendRelativeSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddFriRel")
        {
            string[] cmndAgrs = Convert.ToString(e.CommandArgument).Split(',');
            string friendId = cmndAgrs[0];
            string frirelName = cmndAgrs[1];
            urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
            urUserRegBLLObj.frnrelFriendId = friendId;
            urUserRegBLLObj.frnrelFrnRelName = frirelName;
            urUserRegBLLObj.frnrelRelation = "friend";
            cqc.frnrelUserId = Convert.ToString(Session["User"]);
            cqc.frnrelFriendId = friendId;
            string friendIdNN = Convert.ToString(urUserRegBLLObj.frnrelFriendId);
            if (urUserRegBLLObj.frnrelUserId == urUserRegBLLObj.frnrelFriendId)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('You can't yourself as friend.')", true);
            }
            else
            {
                foreach (GridViewRow grdRow in gvFriendRelativeSearch.Rows)
                {
                    drdList = (DropDownList)(gvFriendRelativeSearch.Rows[grdRow.RowIndex].Cells[0].FindControl("cmbGroupType"));
                    if (drdList.SelectedValue == "All" || drdList.SelectedIndex == 0)
                    {
                        cqc.FR1 = "1";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='" + cqc.FR1 + "', FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='" + cqc.FR1 + "', FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 1)
                    {
                        cqc.FR2 = "2";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR2='" + cqc.FR2 + "', FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR2='" + cqc.FR2 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 2)
                    {
                        cqc.FR3 = "3";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1', FR3='" + cqc.FR3 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR3='" + cqc.FR3 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 3)
                    {
                        cqc.FR4 = "4";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR4='" + cqc.FR4 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR4='" + cqc.FR4 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 4)
                    {
                        cqc.FR5 = "5";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR5='" + cqc.FR5 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR5='" + cqc.FR5 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 5)
                    {
                        cqc.FR6 = "6";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR6='" + cqc.FR6 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);

                            string query = "update FriendRelationMaster set FR1='1',FR6='" + cqc.FR6 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 6)
                    {
                        cqc.FR7 = "7";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR7='" + cqc.FR7 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR7='" + cqc.FR7 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 7)
                    {
                        cqc.FR8 = "8";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR8='" + cqc.FR8 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR8='" + cqc.FR8 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }

                    else if (drdList.SelectedIndex == 8)
                    {
                        cqc.FR9 = "9";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR9='" + cqc.FR9 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR9='" + cqc.FR9 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 9)
                    {
                        cqc.FR10 = "10";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR10='" + cqc.FR10 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Udated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR10='" + cqc.FR10 + "',FriendPrefix='Dear',senderid='myctin'  where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 10)
                    {
                        cqc.FR11 = "11";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR11='" + cqc.FR11 + "',FriendPrefix='Dear',senderid='myctin'  where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR11='" + cqc.FR11 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 11)
                    {
                        cqc.FR12 = "12";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR12='" + cqc.FR12 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR12='" + cqc.FR12 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 12)
                    {
                        cqc.FR13 = "13";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR13='" + cqc.FR13 + "',FriendPrefix='Dear',senderid='myctin'  where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR13='" + cqc.FR13 + "' ,FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 13)
                    {
                        cqc.FR14 = "14";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR14='" + cqc.FR14 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR14='" + cqc.FR14 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 14)
                    {
                        cqc.FR15 = "15";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR15='" + cqc.FR15 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR15='" + cqc.FR15 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 15)
                    {
                        cqc.FR16 = "16";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR16='" + cqc.FR16 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR16='" + cqc.FR16 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 16)
                    {
                        cqc.FR17 = "17";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR17='" + cqc.FR17 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR17='" + cqc.FR17 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 17)
                    {
                        cqc.FR18 = "18";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR18='" + cqc.FR18 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR18='" + cqc.FR18 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }

                    }
                    else if (drdList.SelectedIndex == 18)
                    {
                        cqc.FR19 = "19";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR19='" + cqc.FR19 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR19='" + cqc.FR19 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 19)
                    {
                        cqc.FR20 = "20";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR20='" + cqc.FR20 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR20='" + cqc.FR20 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 20)
                    {
                        cqc.FR21 = "21";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR21='" + cqc.FR21 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR21='" + cqc.FR21 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 21)
                    {
                        cqc.FR22 = "22";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR22='" + cqc.FR22 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR22='" + cqc.FR22 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 22)
                    {
                        cqc.FR23 = "23";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR23='" + cqc.FR23 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR23='" + cqc.FR23 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 23)
                    {
                        cqc.FR24 = "24";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR24='" + cqc.FR24 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR24='" + cqc.FR24 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }
                    }
                    else if (drdList.SelectedIndex == 24)
                    {
                        cqc.FR25 = "25";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR25='" + cqc.FR25 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR25='" + cqc.FR25 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;

                        }

                    }
                    else if (drdList.SelectedIndex == 25)
                    {
                        cqc.FR26 = "26";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR26='" + cqc.FR26 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR26='" + cqc.FR26 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 26)
                    {
                        cqc.FR27 = "27";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 0)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR27='" + cqc.FR27 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR27='" + cqc.FR27 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 27)
                    {
                        cqc.FR28 = "28";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR28='" + cqc.FR28 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR28='" + cqc.FR28 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 28)
                    {
                        cqc.FR29 = "29";
                        status = cqc.BLLTestUserFriendRelative(cqc);

                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR29='" + cqc.FR29 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR29='" + cqc.FR29 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    else if (drdList.SelectedIndex == 29)
                    {
                        cqc.FR30 = "30";
                        status = cqc.BLLTestUserFriendRelative(cqc);
                        if (status == 1)
                        {
                            string query = "update FriendRelationMaster set FR1='1',FR30='" + cqc.FR30 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Updated Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                        else
                        {
                            urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);
                            string query = "update FriendRelationMaster set FR1='1',FR30='" + cqc.FR30 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + urUserRegBLLObj.frnrelUserId + "' and  FriendId='" + friendId + "' ";
                            status = cc.ExecuteNonQuery(query);
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added Successfully in your Friend List.')", true);
                            gvFriendRelativeSearch.Visible = false;
                        }
                    }
                    LoadFriendRelative();
                }
            }
            clearAddFriend();
        }
    }
    #endregion

    private void friendAddedMsg(string friendIdN)
    {
        try
        {
            //string friendIdN = Convert.ToString(friendId2);
            string sqlN = "select usrMobileNo from UserMaster where usrUserId = '" + Convert.ToString(friendIdN) + "'";
            DataSet ds = cc.ExecuteDataset(sqlN);
            string sendToN = Convert.ToString(ds.Tables[0].Rows[0]["usrMobileNo"]);
            string sendFrom = Convert.ToString(Session["Mobile"]);
            string myNameN = Convert.ToString(Session["UserFirstNameN"]) + " " + Convert.ToString(Session["UserLastNameN"]);
            string AddedMessage = "I " + myNameN + "(" + sendFrom.ToString() + ") added u in come2mycity.com. to send free sms." + cc.AddSMS(sendToN);
            cc.SendMessage1(sendFrom, sendToN, AddedMessage);
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    protected void dlFriendRelative_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string Id = Convert.ToString(e.CommandArgument);
        //lblId.Text = Id;
        Response.Redirect("~/html/ViewAddress.aspx?uid=" + Id + "");
    }

    #region AddNew Person

    public void FriendGroupLoad()
    {
        try
        {
            string strGr = "select GroupName from userMaster where usrUserId='" + Convert.ToString(Session["User"]) + "'";
            string GrName = cc.ExecuteScalar(strGr);
            DataTable dt = new DataTable();
            dt.Columns.Add("friendGroupName", typeof(string));
            dt.Columns.Add("friendGroupId", typeof(int));
            string[] ss = GrName.Split(',');
            for (int i = 0; i < ss.Length; i++)
            {
                dt.Rows.Add(ss[i].ToString(), i + 1);
            }
            cmbFriendGroup.DataSource = dt;
            cmbFriendGroup.DataTextField = "friendGroupName";
            cmbFriendGroup.DataValueField = "friendGroupId";
            cmbFriendGroup.DataBind();
            cmbFriendGroup.SelectedValue = "1";
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }

    private void FriendRelativeAdd()
    {
        try
        {
            urUserRegBLLObj.usrUserId = System.Guid.NewGuid().ToString();
            string friendid = urUserRegBLLObj.usrUserId;
            // urUserRegBLLObj.usrUserName = Convert.ToString(txtUserName.Text);
            urUserRegBLLObj.usrMobileNo = Convert.ToString(txtMobileNumber.Text);
            urUserRegBLLObj.usrAddress = Convert.ToString(txtAddress.Text);
            urUserRegBLLObj.usrFirstName = Convert.ToString(txtFirstName.Text);
            urUserRegBLLObj.usrLastName = Convert.ToString(txtLastName.Text);

            if (rdoCityLocation.SelectedItem.Value == "SC")
            {
                urUserRegBLLObj.usrCityId = Convert.ToInt32(Session["City"]);
            }
            else if (rdoCityLocation.SelectedItem.Value == "DC")
            {
                if (cmbCity.SelectedValue != null)
                {
                    urUserRegBLLObj.usrCityId = Convert.ToInt32(Convert.ToString(cmbCity.SelectedValue));
                }
                else
                {
                    urUserRegBLLObj.usrCityId = Convert.ToInt32(Session["City"]);

                }

            }
            Random rnd = new Random();
            urUserRegBLLObj.usrPassword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));
            string pass = cc.DESDecrypt(urUserRegBLLObj.usrPassword);

            status = urUserRegBLLObj.BLLIsExistUserRegistrationInitial(urUserRegBLLObj);

            if (status == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User already Exists...')", true);
            }
            else
            {
                status = urUserRegBLLObj.BLLInsertUserRegistrationInitial(urUserRegBLLObj);
                if (status > 0)
                {

                    urUserRegBLLObj.frnrelUserId = Convert.ToString(Session["User"]);
                    urUserRegBLLObj.frnrelFriendId = urUserRegBLLObj.usrUserId;
                    urUserRegBLLObj.frnrelFrnRelName = Convert.ToString(urUserRegBLLObj.usrFirstName + " " + urUserRegBLLObj.usrLastName);
                    urUserRegBLLObj.frnrelRelation = Convert.ToString(txtRelation.Text);
                    int frcount = urUserRegBLLObj.BLLInsertUserFriendRelative(urUserRegBLLObj);

                    if (frcount > 0)
                    {
                        UserFriRelSMSInfo(urUserRegBLLObj.usrMobileNo);
                    }
                    string frnGroupId = Convert.ToString(cmbFriendGroup.SelectedValue);
                    string login = Convert.ToString(Session["User"]);
                    if (frnGroupId == "1")
                    {

                        cqc.FR1 = frnGroupId;
                        string query = "update FriendRelationMaster set FR1='" + cqc.FR1 + "',FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "2")
                    {
                        cqc.FR2 = frnGroupId;
                        string query = "update FriendRelationMaster set FR2='" + cqc.FR2 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "3")
                    {
                        cqc.FR3 = frnGroupId;
                        string query = "update FriendRelationMaster set FR3='" + cqc.FR3 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "4")
                    {
                        cqc.FR4 = frnGroupId;
                        string query = "update FriendRelationMaster set FR4='" + cqc.FR4 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "5")
                    {
                        cqc.FR5 = frnGroupId;
                        string query = "update FriendRelationMaster set FR5='" + cqc.FR5 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "6")
                    {
                        cqc.FR6 = frnGroupId;
                        string query = "update FriendRelationMaster set FR6='" + cqc.FR6 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "7")
                    {
                        cqc.FR7 = frnGroupId;
                        string query = "update FriendRelationMaster set FR7='" + cqc.FR7 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "8")
                    {
                        cqc.FR8 = frnGroupId;
                        string query = "update FriendRelationMaster set FR8='" + cqc.FR8 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "9")
                    {
                        cqc.FR9 = frnGroupId;
                        string query = "update FriendRelationMaster set FR9='" + cqc.FR9 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "10")
                    {
                        cqc.FR10 = frnGroupId;
                        string query = "update FriendRelationMaster set FR10='" + cqc.FR10 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "11")
                    {
                        cqc.FR11 = frnGroupId;
                        string query = "update FriendRelationMaster set FR11='" + cqc.FR11 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "12")
                    {
                        cqc.FR12 = frnGroupId;
                        string query = "update FriendRelationMaster set FR12='" + cqc.FR12 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "13")
                    {
                        cqc.FR13 = frnGroupId;
                        string query = "update FriendRelationMaster set FR13='" + cqc.FR13 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "14")
                    {
                        cqc.FR14 = frnGroupId;
                        string query = "update FriendRelationMaster set FR14='" + cqc.FR14 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "15")
                    {
                        cqc.FR15 = frnGroupId;
                        string query = "update FriendRelationMaster set FR15='" + cqc.FR15 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "16")
                    {
                        cqc.FR16 = frnGroupId;
                        string query = "update FriendRelationMaster set FR16='" + cqc.FR16 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "17")
                    {
                        cqc.FR17 = frnGroupId;
                        string query = "update FriendRelationMaster set FR17='" + cqc.FR17 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "18")
                    {
                        cqc.FR18 = frnGroupId;
                        string query = "update FriendRelationMaster set FR18='" + cqc.FR18 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "19")
                    {
                        cqc.FR19 = frnGroupId;
                        string query = "update FriendRelationMaster set FR19='" + cqc.FR19 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "20")
                    {
                        cqc.FR20 = frnGroupId;
                        string query = "update FriendRelationMaster set FR20='" + cqc.FR20 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "21")
                    {
                        cqc.FR21 = frnGroupId;
                        string query = "update FriendRelationMaster set FR21='" + cqc.FR21 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "22")
                    {
                        cqc.FR22 = frnGroupId;
                        string query = "update FriendRelationMaster set FR22='" + cqc.FR22 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "23")
                    {
                        cqc.FR23 = frnGroupId;
                        string query = "update FriendRelationMaster set FR23='" + cqc.FR23 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "24")
                    {
                        cqc.FR24 = frnGroupId;
                        string query = "update FriendRelationMaster set FR24='" + cqc.FR24 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "25")
                    {
                        cqc.FR25 = frnGroupId;
                        string query = "update FriendRelationMaster set FR25='" + cqc.FR25 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "26")
                    {
                        cqc.FR26 = frnGroupId;
                        string query = "update FriendRelationMaster set FR26='" + cqc.FR26 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "27")
                    {
                        cqc.FR27 = frnGroupId;
                        string query = "update FriendRelationMaster set FR27='" + cqc.FR27 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "28")
                    {
                        cqc.FR28 = frnGroupId;
                        string query = "update FriendRelationMaster set FR28='" + cqc.FR28 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "29")
                    {
                        cqc.FR29 = frnGroupId;
                        string query = "update FriendRelationMaster set FR29='" + cqc.FR29 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }
                    else if (frnGroupId == "30")
                    {
                        cqc.FR30 = frnGroupId;
                        string query = "update FriendRelationMaster set FR30='" + cqc.FR30 + "', FR1='1', FriendPrefix='Dear',senderid='myctin' where UserId='" + login + "' and  FriendId='" + friendid + "' ";
                        string a = cc.ExecuteScalar(query);

                    }

                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Added')", true);
                    Response.Redirect("FriendRelative.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Friend Not added')", true);
                }
            }

            clearAddFriend();
        }
        catch (Exception ex)
        {
            //throw ex;
        }
    }
    private void UserFriRelSMSInfo(string usrMobileNo)
    {
        try
        {
            string cityName;
            DataTable dtUserInfoList = urUserRegBLLObj.BLLGetUserRegistrationSMSInfo(usrMobileNo);
            DataRow dRowUserInfoList = dtUserInfoList.Rows[0];
            string sendTo = Convert.ToString(dRowUserInfoList["usrMobileNo"]);
            string myPassword = cc.DESDecrypt(Convert.ToString(dRowUserInfoList["usrPassword"]));
            string myName = Convert.ToString(dRowUserInfoList["usrFirstName"]);
            string firstName = Convert.ToString(Session["UserFirstNameN"]);
            string lastName = Convert.ToString(Session["UserLastNameN"]);
            string sendFrom = Convert.ToString(Session["Mobile"]);
            string senderName = firstName + " " + lastName;
            if (rdoCityLocation.SelectedItem.Value == "SC")
                cityName = Convert.ToString(Session["CityNameN"]);
            else
                cityName = Convert.ToString(cmbCity.SelectedItem.Text);
            string passwordMessage = "I " + senderName + "(" + sendFrom.ToString() + ") added u in come2mycity.com. U use it to send free SMS.Dear " + myName + ",Password for ur First Login is " + myPassword.ToString();
            cc.SendMessage1(sendFrom, sendTo, passwordMessage);
            cc.SendMessageImp1(sendFrom, sendTo, passwordMessage);
        }

        catch (Exception ex)
        {
            //throw ex;
        }
    }

    private void LoadState()
    {
        DataSet ds = new DataSet();
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
                cmbState.DataSource = ds.Tables[0];
                cmbState.DataTextField = "StateName";
                cmbState.DataValueField = "StateId";
                cmbState.DataBind();
                cmbState.Items.Add("--Select--");
                cmbState.Items[cmbState.Items.Count - 1].Value = " ";
                cmbDistrict.Items.Add("--Select--");
                cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = " ";
                cmbCity.Items.Add("--Select--");
                cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";
                cmbState.SelectedIndex = cmbState.Items.Count - 1;
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
    protected void cmbState_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = (DataSet)Session["Location"];
            if (cmbState.SelectedIndex != cmbState.Items.Count - 1)
            {
                if (ds.Tables[1] != null)
                {
                    DataRow[] dr = ds.Tables[1].Select("StateId=" + cmbState.SelectedValue.ToString() + "");
                    cmbDistrict.DataSource = getDataTable(dr);
                    cmbDistrict.DataTextField = "Name";
                    cmbDistrict.DataValueField = "Id";
                    cmbDistrict.DataBind();
                    cmbDistrict.Items.Add("--Select--");
                    cmbDistrict.Items[cmbDistrict.Items.Count - 1].Value = " ";
                    cmbDistrict.SelectedIndex = cmbDistrict.Items.Count - 1;
                }
            }
            else
            {
                cmbCity.Items.Clear();
                cmbDistrict.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        mdlAddContact.Show();
    }

    protected void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ds = (DataSet)Session["Location"];
            if (cmbDistrict.SelectedIndex != cmbDistrict.Items.Count - 1)
            {
                if (ds.Tables[2] != null)
                {
                    DataRow[] dr = ds.Tables[2].Select("DistrictId=" + cmbDistrict.SelectedValue.ToString() + "");
                    cmbCity.DataSource = getDataTable(dr);
                    cmbCity.DataTextField = "Name";
                    cmbCity.DataValueField = "Id";
                    cmbCity.DataBind();
                    cmbCity.Items.Add("--Select--");
                    cmbCity.Items[cmbCity.Items.Count - 1].Value = " ";
                    cmbCity.SelectedIndex = cmbCity.Items.Count - 1;
                }
            }
            else
            {
                cmbCity.Items.Clear();

            }
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        mdlAddContact.Show();
    }
    public void clearAddFriend()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtMobileNumber.Text = "";
        txtRelation.Text = "";
        txtAddress.Text = "";

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        FriendRelativeAdd();
        clearAddFriend();
    }

    protected void rdoCityLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdoCityLocation.SelectedValue == "DC")
        {
            pnlSelectLocation.Visible = true;
            LoadState();
        }
        else
        {
            pnlSelectLocation.Visible = false;
        }
        mdlAddContact.Show();
    }

    #endregion


    #region PagingFunction

    public int CurrentPage
    {
        get
        {
            if (this.ViewState["CurrentPage"] == null)
                return 0;
            else
                return Convert.ToInt16(this.ViewState["CurrentPage"].ToString());
        }
        set
        {
            this.ViewState["CurrentPage"] = value;
        }
    }
    protected void lnkPrev_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        LoadFriendRelative();
    }
    protected void lnkNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        LoadFriendRelative();
    }

    #endregion

    #region SearchFriend
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pnlfrndRel.Visible = true;
        //pnlfrndlist.Visible = true;
        Searchfrnd(dlFriendRelative, TextfirstN, TextlastN);
    }

    protected void Searchfrnd(DataList dl, TextBox fn, TextBox ln)
    {
        try
        {
            ArrayList arr = new ArrayList();
            DataTable dt = new DataTable();
            string user = Convert.ToString(Session["User"]);
            string sql1 = "select usrAutoId,usrFirstname+' '+usrLastName as FullName,usrUserid from UserMaster inner join FriendRelationMaster on UserMaster.usrUserId = FriendRelationMaster.FriendId where FriendRelationMaster.userid='" + user + "' and usrFirstname like '" + TextfirstN.Text + "%' and usrLastName like '" + TextlastN.Text + "%'";
            DataSet ds = cc.ExecuteDataset(sql1);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string usrAutoId = Convert.ToString(dr["usrAutoId"]);
                string usrFirstname = Convert.ToString(dr["FullName"]);
                string userid = Convert.ToString(dr["usrUserid"]);
                string sql = "select id from storeimage where usrAutoId='" + usrAutoId + "'";
                string id = cc.ExecuteScalar(sql);
                if (id == "" || id == null)
                {
                    usrAutoId = "0";
                    id = "1";
                    arr.Add(id);
                    arr.Add(usrFirstname);
                    arr.Add(userid);

                }
                else
                {
                    arr.Add(id);
                    arr.Add(usrFirstname);
                    arr.Add(userid);
                }
            }
            int i;
            DataColumn dc = new DataColumn();
            DataColumn dc1 = new DataColumn();
            DataColumn dc2 = new DataColumn();
            dc.ColumnName = "id";
            dc1.ColumnName = "FullName";
            dc2.ColumnName = "userid";
            dt.Columns.Add(dc);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            for (i = 0; i < arr.Count; i = i + 2)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = arr[i];
                dr["FullName"] = arr[i + 1];
                dr["userid"] = arr[i + 2];

                dt.Rows.Add(dr);
                i++;
            }
            dlFriendRelative.DataSource = dt;
            dlFriendRelative.DataBind();
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
    }
    #endregion

    protected void DataListSearch_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Show")
        {
            Session["usrAddressId"] = e.CommandArgument;
            Response.Redirect("../html/ViewAddress.aspx?uid=" + e.CommandArgument + "");
        }
    }
    protected void gvFriendRelativeSearch_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public int BLLIsExistUserRegistrationInitial(string mno)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        int Check = 1;
        try
        {
            SqlParameter[] par = new SqlParameter[2];
            par[0] = new SqlParameter("@usrMobileNo", mno);
            par[1] = new SqlParameter("@status", 11);
            par[1].Direction = ParameterDirection.Output;
            Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "UserRegistrationIsExist", par));
            Check = (int)par[1].Value;
        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
        return Check;
    }

    #region ExecutionPart
    public DataSet ExecuteDataset(string sqlQuery)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        DataSet ds = new DataSet();
        try
        {
            con.Open();
            ds = SqlHelper.ExecuteDataset(con, CommandType.Text, sqlQuery);

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            con.Close();
        }
        return ds;
    }
    public int ExecuteNonQuery(string Sql)
    {
        int flag = 0;
        SqlConnection cons4 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {

            flag = SqlHelper.ExecuteNonQuery(cons4, CommandType.Text, Sql);

        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            cons4.Close();
        }

        return flag;
    }

    public string ExecuteScalar(string Sql)
    {
        string Data = "";
        SqlConnection cons3 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        try
        {
            Data = Convert.ToString(SqlHelper.ExecuteScalar(cons3, CommandType.Text, Sql));
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            cons3.Close();
        }

        return Data;
    }
    #endregion

    #region NewRegistration
    public bool RegisterNew(string mno, string fnm, string lnm, string pin, string gr, string ct, string defltgrp)
    {
        int status = 1;
        bool Check = false;
        try
        {
            string usrmoNo = Convert.ToString(Session["Mobile"]);
            cqc.usrMobileNo = usrmoNo.ToString();
            status = BLLIsExistUserRegistrationInitial(usrmoNo);
            if (status == 0)
            {
                status = BLLIsExistUserRegistrationInitial(mno);
                if (status == 0)
                {
                    //DataTable dt1 = new DataTable();
                    string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + usrmoNo.ToString() + "'";
                    DataSet ds = new DataSet();
                    ds = ExecuteDataset(sql);
                    //dt1 = ds.Tables[0];

                    string usrName = "";
                    int cityId;
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        cqc.frnrelUserId = userId;
                        cqc.usrCityId = cityId;
                    }
                    string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + mno.ToString() + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = ExecuteDataset(sql1);
                    gr = defltgrp + "" + gr;
                    string[] RgArr = gr.Split('&');
                    if (RgArr.Length > 0)
                    {
                        for (int s = 0; s < RgArr.Length; s++)
                        {
                            foreach (DataRow dr2 in ds1.Tables[0].Rows)
                            {
                                FriId = Convert.ToString(dr2["usrUserId"]);
                                FriName = Convert.ToString(dr2["usrFirstName"]);
                                cqc.frnrelFriendId = FriId;
                                cqc.frnrelFrnRelName = FriName;
                                cqc.frnrelRelation = "friend";
                                //cqc.frnrelGroup = RgArr[s].ToString();
                                if (gr == "1")
                                {
                                    cqc.FR1 = gr;
                                }
                                else if (gr == "2")
                                {
                                    cqc.FR2 = gr;
                                }
                                else if (gr == "3")
                                {
                                    cqc.FR3 = gr;
                                }
                                else if (gr == "4")
                                {
                                    cqc.FR4 = gr;
                                }
                                else if (gr == "5")
                                {
                                    cqc.FR5 = gr;
                                }
                                else if (gr == "6")
                                {
                                    cqc.FR6 = gr;

                                }
                                else if (gr == "7")
                                {
                                    cqc.FR7 = gr;
                                }
                                else if (gr == "7")
                                {
                                    cqc.FR7 = gr;
                                }
                                else if (gr == "8")
                                {
                                    cqc.FR8 = gr;

                                }
                                else if (gr == "9")
                                {
                                    cqc.FR9 = gr;

                                }
                                else if (gr == "10")
                                {
                                    cqc.FR10 = gr;

                                }
                                else if (gr == "11")
                                {
                                    cqc.FR11 = gr;

                                }
                                else if (gr == "12")
                                {
                                    cqc.FR12 = gr;

                                }
                                else if (gr == "13")
                                {
                                    cqc.FR13 = gr;

                                }
                                else if (gr == "14")
                                {
                                    cqc.FR14 = gr;

                                }
                                else if (gr == "15")
                                {
                                    cqc.FR15 = gr;

                                }
                                else if (gr == "16")
                                {
                                    cqc.FR16 = gr;

                                }
                                else if (gr == "17")
                                {
                                    cqc.FR17 = gr;

                                }
                                else if (gr == "18")
                                {
                                    cqc.FR18 = gr;


                                }
                                else if (gr == "19")
                                {
                                    cqc.FR19 = gr;

                                }
                                else if (gr == "20")
                                {
                                    cqc.FR20 = gr;

                                }
                                else if (gr == "20")
                                {
                                    cqc.FR20 = gr;

                                }
                                else if (gr == "21")
                                {
                                    cqc.FR21 = gr;

                                }
                                else if (gr == "22")
                                {
                                    cqc.FR22 = gr;

                                }
                                else if (gr == "23")
                                {
                                    cqc.FR23 = gr;

                                }
                                else if (gr == "24")
                                {
                                    cqc.FR24 = gr;

                                }
                                else if (gr == "25")
                                {
                                    cqc.FR25 = gr;

                                }
                                else if (gr == "26")
                                {
                                    cqc.FR26 = gr;

                                }
                                else if (gr == "27")
                                {
                                    cqc.FR27 = gr;

                                }
                                else if (gr == "28")
                                {
                                    cqc.FR28 = gr;

                                }
                                else if (gr == "29")
                                {
                                    cqc.FR29 = gr;

                                }
                                else if (gr == "30")
                                {
                                    cqc.FR30 = gr;

                                }
                                else
                                {

                                }


                            }
                            status = cqc.BLLTestUserFriendRelative(cqc);
                            if (status == 0)
                            {
                                cqc.BLLInsertUserFriendRelative(cqc);
                            }
                            else
                            {
                                cqc.BLLUpdateUserFriendRelative(cqc);
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        {
                            FriId = Convert.ToString(dr2["usrUserId"]);
                            FriName = Convert.ToString(dr2["usrFirstName"]);
                            cqc.frnrelFriendId = FriId;
                            cqc.frnrelFrnRelName = FriName;
                            cqc.frnrelRelation = "friend";
                        }
                        status = cqc.BLLInsertUserFriendRelative(cqc);
                    }
                    Check = true;
                }
                else
                {
                    string sql3 = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + cqc.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = ExecuteDataset(sql3);
                    string userId;
                    string usrName = "";
                    int cityId = 0;
                    string cityName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        cqc.frnrelUserId = userId;
                        cqc.usrCityId = cityId;
                        // cqc.frnrelGroup = "1";
                    }
                    string sqlquery = "select cityName from CityMaster where cityId='" + Convert.ToString(cityId) + "'";
                    cityName = ExecuteScalar(sqlquery);
                    cqc.usrUserId = System.Guid.NewGuid().ToString();
                    cqc.usrAddress = Convert.ToString(ct);
                    cqc.usrMobileNo = mno.ToString();
                    cqc.usrFirstName = fnm.ToString();
                    cqc.usrLastName = lnm.ToString();
                    cqc.usrPIN = pin.ToString();

                    Random rnd = new Random();
                    cqc.usrPasssword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = cqc.DALInsertUserRegistrationInitial(cqc);
                    if (status > 0)
                    {
                        string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + cqc.usrMobileNo + "'";
                        DataSet ds1 = new DataSet();
                        ds1 = ExecuteDataset(sql1);
                        string FriId;
                        string FriName;
                        gr = defltgrp + "" + gr;
                        string[] RgArr = gr.Split('&');
                        if (RgArr.Length > 0)
                        {
                            for (int s = 0; s < RgArr.Length; s++)
                            {
                                foreach (DataRow dr2 in ds1.Tables[0].Rows)
                                {
                                    FriId = Convert.ToString(dr2["usrUserId"]);
                                    FriName = Convert.ToString(dr2["usrFirstName"]);
                                    cqc.frnrelFriendId = FriId;
                                    cqc.frnrelFrnRelName = FriName;
                                    cqc.frnrelRelation = "friend";
                                    //cqc.frnrelGroup = RgArr[s].ToString();

                                    if (gr == "1")
                                    {
                                        cqc.FR1 = gr;

                                    }
                                    else if (gr == "2")
                                    {
                                        cqc.FR2 = gr;

                                    }
                                    else if (gr == "3")
                                    {
                                        cqc.FR3 = gr;

                                    }
                                    else if (gr == "4")
                                    {
                                        cqc.FR4 = gr;

                                    }
                                    else if (gr == "5")
                                    {
                                        cqc.FR5 = gr;

                                    }
                                    else if (gr == "6")
                                    {
                                        cqc.FR6 = gr;

                                    }
                                    else if (gr == "7")
                                    {
                                        cqc.FR7 = gr;

                                    }
                                    else if (gr == "7")
                                    {
                                        cqc.FR7 = gr;

                                    }
                                    else if (gr == "8")
                                    {
                                        cqc.FR8 = gr;

                                    }
                                    else if (gr == "9")
                                    {
                                        cqc.FR9 = gr;

                                    }
                                    else if (gr == "10")
                                    {
                                        cqc.FR10 = gr;

                                    }
                                    else if (gr == "11")
                                    {
                                        cqc.FR11 = gr;

                                    }
                                    else if (gr == "12")
                                    {
                                        cqc.FR12 = gr;

                                    }
                                    else if (gr == "13")
                                    {
                                        cqc.FR13 = gr;

                                    }
                                    else if (gr == "14")
                                    {
                                        cqc.FR14 = gr;

                                    }
                                    else if (gr == "15")
                                    {
                                        cqc.FR15 = gr;

                                    }
                                    else if (gr == "16")
                                    {
                                        cqc.FR16 = gr;

                                    }
                                    else if (gr == "17")
                                    {
                                        cqc.FR17 = gr;

                                    }
                                    else if (gr == "18")
                                    {
                                        cqc.FR18 = gr;


                                    }
                                    else if (gr == "19")
                                    {
                                        cqc.FR19 = gr;

                                    }
                                    else if (gr == "20")
                                    {
                                        cqc.FR20 = gr;

                                    }
                                    else if (gr == "20")
                                    {
                                        cqc.FR20 = gr;

                                    }
                                    else if (gr == "21")
                                    {
                                        cqc.FR21 = gr;

                                    }
                                    else if (gr == "22")
                                    {
                                        cqc.FR22 = gr;

                                    }
                                    else if (gr == "23")
                                    {
                                        cqc.FR23 = gr;

                                    }
                                    else if (gr == "24")
                                    {
                                        cqc.FR24 = gr;

                                    }
                                    else if (gr == "25")
                                    {
                                        cqc.FR25 = gr;

                                    }
                                    else if (gr == "26")
                                    {
                                        cqc.FR26 = gr;

                                    }
                                    else if (gr == "27")
                                    {
                                        cqc.FR27 = gr;

                                    }
                                    else if (gr == "28")
                                    {
                                        cqc.FR28 = gr;

                                    }
                                    else if (gr == "29")
                                    {
                                        cqc.FR29 = gr;

                                    }
                                    else if (gr == "30")
                                    {
                                        cqc.FR30 = gr;

                                    }
                                    else
                                    {

                                    }
                                }
                                status = cqc.BLLInsertUserFriendRelative(cqc);

                                if (status == 1)
                                {
                                    cqc.BLLUpdateUserFriendRelative(cqc);
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dr2 in ds1.Tables[0].Rows)
                            {
                                FriId = Convert.ToString(dr2["usrUserId"]);
                                FriName = Convert.ToString(dr2["usrFirstName"]);
                                cqc.frnrelFriendId = FriId;
                                cqc.frnrelFrnRelName = FriName;
                                cqc.frnrelRelation = "friend";
                            }
                        }
                        // status = cqc.BLLInsertUserFriendRelative(cqc);
                        if (status > 0)
                        {

                        }
                        string senderId = Convert.ToString(Session["Mobile"]);
                        string myMobileNo = mno.ToString();
                        string myPassword = cc.DESDecrypt(cqc.usrPasssword);
                        string myName = cqc.frnrelFrnRelName;
                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") added u on www.myct.in to send SMS.Password for ur First Login is " + myPassword + " for www.myct.in";
                        cc.SendMessageTra(senderId, myMobileNo, passwordMessage);
                        Check = true;
                    }
                }
            }
            else
            {
                //NotRegisterMessageForLongCode(urRegistBll);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Check;
    }
    #endregion

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    #region UploadCSVAndExcel

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int i = 0;
        string path = "";
        if (CSVUpload.HasFile)
        {


            path = Server.MapPath("File_Upload");




            string fileName = CSVUpload.FileName;
            path = path + "\\" + CSVUpload.FileName;
            this.currFileExtension = System.IO.Path.GetExtension(fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                //File.Delete(Server.MapPath("~/Html/File_Upload/") + CSVUpload.FileName);
                CSVUpload.SaveAs(path);
            }
            else
            {
                CSVUpload.SaveAs(path);
            }
        }
        //    StreamReader sr = new StreamReader(path);
        //    string line = sr.ReadLine();

        //    do
        //    {
        //        line = sr.ReadLine();
        //        string mno = "", fnm = "", lnm = "", pin = "", gr = "", ct = "", defltgrp = "", prefix = "";
        //        i++;
        //        if (i == 1)
        //        {
        //            string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + Convert.ToString(Session["Mobile"]) + "'";
        //            DataSet ds = new DataSet();
        //            ds = ExecuteDataset(sql);
        //            string userId;
        //            foreach (DataRow dr1 in ds.Tables[0].Rows)
        //            {
        //                userId = Convert.ToString(dr1["usrUserId"]);
        //            }
        //        }
        //        if (line != null)
        //        {
        //            string[] ArrLine = line.Split(',');
        //            mno = Convert.ToString(ArrLine[0].Replace("'", "."));
        //            fnm = Convert.ToString(ArrLine[1].Replace("'", "."));
        //            lnm = Convert.ToString(ArrLine[2].Replace("'", "."));
        //            pin = Convert.ToString(ArrLine[3].Replace("'", "."));

        //            gr = Convert.ToString(ArrLine[4].Replace("'", "."));
        //            ct = Convert.ToString(ArrLine[5].Replace("'", "."));
        //            prefix = Convert.ToString(ArrLine[6].Replace("'", "."));

        //            defltgrp = "1";
        //            RegisterNewExcel(mno, fnm, lnm, pin, gr, ct, prefix, defltgrp);
        //        }

        //    } while (line != null);
        //    Response.Write("<script>(alert)('File Uploaded Sucessfully....!')</script>");
        //}

        if (this.currFileExtension == ".xlsx" || this.currFileExtension == ".xls")
        {

            string strQuery = "Select * From [Sheet1$]";
            DataSet dscount = GetDataTable(strQuery);

            FetchData(dscount);

            lblStatus.Text = "Record Added Successfully..!!!";
            lblStatus.Font.Bold = true;
            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Visible = true;
            //Read Excel File (.XLS and .XLSX Format)
        }
        else if (this.currFileExtension == ".csv")
        {
            CSVUpload1(path);  //Read .CSV File
        }
    }
    public void FetchData(DataSet excelDS)
    {
        string mno = "", fnm = "", lnm = "", pin = "", gr = "", ct = "", defltgrp = "", prefix = "";

        for (int k = 0; k < excelDS.Tables[0].Rows.Count; k++)
        {
            //Id = Convert.ToInt32(excelDS.Tables[0].Rows[k][0]);
            mno = excelDS.Tables[0].Rows[k][0].ToString();
            fnm = excelDS.Tables[0].Rows[k][1].ToString();
            lnm = excelDS.Tables[0].Rows[k][2].ToString();
            pin = excelDS.Tables[0].Rows[k][3].ToString();
            gr = excelDS.Tables[0].Rows[k][4].ToString();
            ct = excelDS.Tables[0].Rows[k][5].ToString();
            prefix = excelDS.Tables[0].Rows[k][6].ToString();
            defltgrp = "1";

            string str = DateTime.Now.Date.ToString("yyyy-MM-dd");
            RegisterNewExcel(mno, fnm, lnm, pin, gr, ct, prefix, defltgrp);
        }
    }

    public DataSet GetDataTable(string strQuery)
    {
        DataSet tempDs = null;
        string filePath = Server.MapPath("File_Upload\\" + CSVUpload.FileName);
        {
            string conPath = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
            OleDbConnection conn = new OleDbConnection(conPath);
            try
            {
                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(strQuery, conn);
                tempDs = new DataSet();
                adapter.Fill(tempDs);
            }
            catch (Exception ex)
            {
                Response.Write("<h4>" + ex.Message);
            }
            conn.Close();
        }
        return tempDs;

    }
    public void CSVUpload1(string path)
    {
        int i = 0;
        StreamReader sr = new StreamReader(path);
        string line = sr.ReadLine();

        do
        {
            line = sr.ReadLine();
            string mno = "", fnm = "", lnm = "", pin = "", gr = "", ct = "", defltgrp = "", prefix = "";
            i++;
            if (i == 1)
            {
                string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + Convert.ToString(Session["Mobile"]) + "'";
                DataSet ds = new DataSet();
                ds = ExecuteDataset(sql);
                string userId;
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    userId = Convert.ToString(dr1["usrUserId"]);
                }
            }
            if (line != null)
            {
                string[] ArrLine = line.Split(',');
                mno = Convert.ToString(ArrLine[0].Replace("'", "."));
                fnm = Convert.ToString(ArrLine[1].Replace("'", "."));
                lnm = Convert.ToString(ArrLine[2].Replace("'", "."));
                pin = Convert.ToString(ArrLine[3].Replace("'", "."));

                gr = Convert.ToString(ArrLine[4].Replace("'", "."));
                ct = Convert.ToString(ArrLine[5].Replace("'", "."));
                prefix = Convert.ToString(ArrLine[6].Replace("'", "."));

                defltgrp = "1";
                RegisterNewExcel(mno, fnm, lnm, pin, gr, ct, prefix, defltgrp);
            }

        } while (line != null);
        Response.Write("<script>(alert)('File Uploaded Sucessfully....!')</script>");


    }
    #endregion

    public bool RegisterNewExcel(string mno, string fnm, string lnm, string pin, string gr, string ct, string prefix, string defltgrp)
    {
        int status = 1;
        bool Check = false;
        try
        {
            string usrmoNo = Convert.ToString(Session["Mobile"]);
            cqc.usrMobileNo = usrmoNo.ToString();
            status = BLLIsExistUserRegistrationInitial(usrmoNo);
            if (status == 0)
            {
                status = BLLIsExistUserRegistrationInitial(mno);
                if (status == 0)
                {
                    string sql = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + usrmoNo.ToString() + "'";
                    DataSet ds = new DataSet();
                    ds = ExecuteDataset(sql);
                    string usrName = "";
                    int cityId;
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        cqc.frnrelUserId = userId;
                        cqc.usrCityId = cityId;
                    }
                    string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + mno.ToString() + "'";
                    DataSet ds1 = new DataSet();
                    ds1 = ExecuteDataset(sql1);
                    gr = defltgrp + "&" + gr;
                    RgArr = gr.Split('&');
                    if (RgArr.Length > 0)
                    {
                        for (int s = 0; s < RgArr.Length; s++)
                        {
                            foreach (DataRow dr2 in ds1.Tables[0].Rows)
                            {

                                FriId = Convert.ToString(dr2["usrUserId"]);
                                FriName = Convert.ToString(dr2["usrFirstName"]);
                                cqc.frnrelFriendId = FriId;
                                cqc.frnrelFrnRelName = FriName;
                                cqc.frnrelRelation = "friend";
                                cqc.Senderid = "myctin";
                                if (prefix == "1")
                                {
                                    cqc.FrnrelPrefix = "Dear";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= N'" + cqc.FrnrelPrefix + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }
                                else if (prefix == "2")
                                {
                                    cqc.FrnrelPrefix = "Shri";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= N'" + cqc.FrnrelPrefix + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }
                                else if (prefix == "3")
                                {
                                    cqc.FrnrelPrefix = "Smt";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= N'" + cqc.FrnrelPrefix + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }
                                else if (prefix == "" || prefix == null)
                                {
                                    cqc.FrnrelPrefix = "Dear";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= N'" + cqc.FrnrelPrefix + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }

                                if (RgArr[s] == "1")
                                {
                                    cqc.FR1 = RgArr[s];
                                    // status = cqc.BLLUpdateUserFriendRelative(cqc);
                                    string query = "update FriendRelationMaster set FR1='" + cqc.FR1 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR1 = "";
                                }
                                else if (RgArr[s] == "2")
                                {
                                    cqc.FR2 = RgArr[s];
                                    //status = cqc.BLLUpdateUserFriendRelative(cqc);
                                    string query = "update FriendRelationMaster set FR2='" + cqc.FR2 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR2 = "";

                                }
                                else if (RgArr[s] == "3")
                                {
                                    cqc.FR3 = RgArr[s];
                                    //status = cqc.BLLUpdateUserFriendRelative(cqc);
                                    string query = "update FriendRelationMaster set FR3='" + cqc.FR3 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR3 = "";

                                }
                                else if (RgArr[s] == "4")
                                {
                                    cqc.FR4 = RgArr[s];
                                    //status = cqc.BLLUpdateUserFriendRelative(cqc);
                                    string query = "update FriendRelationMaster set FR4='" + cqc.FR4 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR4 = "";

                                }
                                else if (RgArr[s] == "5")
                                {
                                    cqc.FR5 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR5='" + cqc.FR5 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR5 = "";

                                }
                                else if (RgArr[s] == "6")
                                {
                                    cqc.FR6 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR6='" + cqc.FR6 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR6 = "";

                                }
                                else if (RgArr[s] == "7")
                                {
                                    cqc.FR7 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR7='" + cqc.FR7 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR7 = "";

                                }

                                else if (RgArr[s] == "8")
                                {
                                    cqc.FR8 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR8='" + cqc.FR8 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR8 = "";
                                }
                                else if (RgArr[s] == "9")
                                {
                                    cqc.FR9 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR9='" + cqc.FR9 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR9 = "";

                                }
                                else if (RgArr[s] == "10")
                                {
                                    cqc.FR10 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR10='" + cqc.FR10 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR10 = "";

                                }
                                else if (RgArr[s] == "11")
                                {
                                    cqc.FR11 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR11='" + cqc.FR11 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR11 = "";
                                }
                                else if (RgArr[s] == "12")
                                {
                                    cqc.FR12 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR12='" + cqc.FR12 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR12 = "";

                                }
                                else if (RgArr[s] == "13")
                                {
                                    cqc.FR13 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR13='" + cqc.FR13 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR13 = "";

                                }
                                else if (RgArr[s] == "14")
                                {
                                    cqc.FR14 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR14='" + cqc.FR14 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR14 = "";

                                }
                                else if (RgArr[s] == "15")
                                {
                                    cqc.FR15 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR15='" + cqc.FR15 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR15 = "";

                                }
                                else if (RgArr[s] == "16")
                                {
                                    cqc.FR16 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR16='" + cqc.FR16 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR16 = "";

                                }
                                else if (RgArr[s] == "17")
                                {
                                    cqc.FR17 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR17='" + cqc.FR17 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR17 = "";

                                }
                                else if (RgArr[s] == "18")
                                {
                                    cqc.FR18 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR18='" + cqc.FR18 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR18 = "";


                                }
                                else if (RgArr[s] == "19")
                                {
                                    cqc.FR19 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR19='" + cqc.FR19 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR19 = "";
                                }
                                else if (RgArr[s] == "20")
                                {
                                    cqc.FR20 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR20='" + cqc.FR20 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR20 = "";

                                }

                                else if (RgArr[s] == "21")
                                {
                                    cqc.FR21 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR21='" + cqc.FR21 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR21 = "";

                                }
                                else if (RgArr[s] == "22")
                                {
                                    cqc.FR22 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR22='" + cqc.FR22 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR22 = "";

                                }
                                else if (RgArr[s] == "23")
                                {
                                    cqc.FR23 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR23='" + cqc.FR23 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR23 = "";

                                }
                                else if (RgArr[s] == "24")
                                {
                                    cqc.FR24 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR24='" + cqc.FR24 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR24 = "";

                                }

                                else if (RgArr[s] == "25")
                                {
                                    cqc.FR25 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR25='" + cqc.FR25 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR25 = "";

                                }
                                else if (RgArr[s] == "26")
                                {
                                    cqc.FR26 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR26='" + cqc.FR26 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR26 = "";

                                }
                                else if (RgArr[s] == "27")
                                {
                                    cqc.FR27 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR27='" + cqc.FR27 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR27 = "";


                                }
                                else if (RgArr[s] == "28")
                                {
                                    cqc.FR28 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR28='" + cqc.FR28 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR28 = "";

                                }
                                else if (RgArr[s] == "29")
                                {
                                    cqc.FR29 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR29='" + cqc.FR29 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR29 = "";

                                }
                                else if (RgArr[s] == "30")
                                {
                                    cqc.FR30 = RgArr[s];
                                    string query = "update FriendRelationMaster set FR30='" + cqc.FR30 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query);
                                    cqc.FR30 = "";
                                }
                                else
                                {

                                }
                                status = cqc.BLLTestUserFriendRelative(cqc);
                                if (status == 0)
                                {
                                    cqc.BLLInsertUserFriendRelative(cqc);
                                    if (RgArr[s] == "1")
                                    {
                                        cqc.FR1 = RgArr[s];
                                        // status = cqc.BLLUpdateUserFriendRelative(cqc);
                                        string query = "update FriendRelationMaster set FR1='" + cqc.FR1 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        cc.ExecuteNonQuery(query);
                                        cqc.FR1 = "";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow dr2 in ds1.Tables[0].Rows)
                        {
                            FriId = Convert.ToString(dr2["usrUserId"]);
                            FriName = Convert.ToString(dr2["usrFirstName"]);
                            cqc.frnrelFriendId = FriId;
                            cqc.frnrelFrnRelName = FriName;
                            cqc.frnrelRelation = "friend";
                            cqc.Senderid = "myctin";
                            //cqc.FrnrelPrefix = "Dear";
                            if (prefix == "1")
                            {
                                cqc.FrnrelPrefix = "Dear";
                                string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                status = cc.ExecuteNonQuery(query1);

                            }
                            else if (prefix == "2")
                            {
                                cqc.FrnrelPrefix = "Shri";
                                string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                status = cc.ExecuteNonQuery(query1);
                            }
                            else if (prefix == "3")
                            {
                                cqc.FrnrelPrefix = "Smt";
                                string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                status = cc.ExecuteNonQuery(query1);
                            }
                            else if (prefix == "" || prefix == null)
                            {
                                cqc.FrnrelPrefix = "Dear";
                                string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                status = cc.ExecuteNonQuery(query1);
                            }
                            else
                            { }
                        }
                        status = cqc.BLLInsertUserFriendRelative(cqc);
                    }
                    Check = true;
                }
                else
                {

                    string sql3 = "select usrUserId, usrFirstName,usrCityId from UserMaster where usrMobileNo='" + cqc.usrMobileNo + "'";
                    DataSet ds = new DataSet();
                    ds = ExecuteDataset(sql3);

                    string userId;
                    string usrName = "";
                    int cityId = 0;
                    string cityName = "";
                    foreach (DataRow dr1 in ds.Tables[0].Rows)
                    {
                        userId = Convert.ToString(dr1["usrUserId"]);
                        usrName = Convert.ToString(dr1["usrFirstName"]);
                        cityId = Convert.ToInt32(dr1["usrCityId"]);
                        cqc.frnrelUserId = userId;
                        cqc.usrCityId = cityId;
                        //cqc.frnrelGroup = "1";

                    }
                    string sqlquery = "select cityName from CityMaster where cityId='" + Convert.ToString(cityId) + "'";
                    cityName = ExecuteScalar(sqlquery);
                    //--------UserId And Password Creation----------------------
                    cqc.usrUserId = System.Guid.NewGuid().ToString();
                    cqc.usrAddress = Convert.ToString(ct);
                    cqc.usrMobileNo = mno.ToString();

                    cqc.usrFirstName = fnm.ToString();
                    cqc.usrLastName = lnm.ToString();
                    cqc.usrPIN = pin.ToString();

                    Random rnd = new Random();
                    cqc.usrPasssword = cc.DESEncrypt(Convert.ToString(rnd.Next(10001, 99999)));

                    status = cqc.DALInsertUserRegistrationInitial(cqc);
                    if (status > 0)
                    {

                        string sql1 = "select usrUserId, usrFirstName from UserMaster where usrMobileNo='" + cqc.usrMobileNo + "'";
                        DataSet ds1 = new DataSet();
                        ds1 = ExecuteDataset(sql1);
                        string FriId;
                        string FriName;
                        gr = defltgrp + "" + gr;
                        string[] RgArr = gr.Split('&');
                        if (RgArr.Length > 0)
                        {
                            for (int s = 0; s < RgArr.Length; s++)
                            {

                                foreach (DataRow dr2 in ds1.Tables[0].Rows)
                                {
                                    FriId = Convert.ToString(dr2["usrUserId"]);
                                    FriName = Convert.ToString(dr2["usrFirstName"]);
                                    cqc.frnrelFriendId = FriId;
                                    cqc.frnrelFrnRelName = FriName;
                                    cqc.frnrelRelation = "friend";
                                    cqc.Senderid = "myctin";
                                    if (prefix == "1")
                                    {
                                        cqc.FrnrelPrefix = "Dear";
                                        string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query1);
                                    }
                                    else if (prefix == "2")
                                    {
                                        cqc.FrnrelPrefix = "Shri";
                                        string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query1);
                                    }
                                    else if (prefix == "3")
                                    {
                                        cqc.FrnrelPrefix = "Smt";
                                        string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query1);
                                    }
                                    else if (prefix == "" || prefix == null)
                                    {
                                        cqc.FrnrelPrefix = "Dear";
                                        string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query1);
                                    }
                                    if (RgArr[s] == "1")
                                    {
                                        cqc.FR1 = RgArr[s];
                                        // status = cqc.BLLUpdateUserFriendRelative(cqc);
                                        string query = "update FriendRelationMaster set FR1='" + cqc.FR1 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR1 = "";


                                    }
                                    else if (RgArr[s] == "2")
                                    {
                                        cqc.FR2 = RgArr[s];
                                        //status = cqc.BLLUpdateUserFriendRelative(cqc);
                                        string query = "update FriendRelationMaster set FR2='" + cqc.FR2 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR2 = "";

                                    }
                                    else if (RgArr[s] == "3")
                                    {
                                        cqc.FR3 = RgArr[s];
                                        //status = cqc.BLLUpdateUserFriendRelative(cqc);
                                        string query = "update FriendRelationMaster set FR3='" + cqc.FR3 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR3 = "";

                                    }
                                    else if (RgArr[s] == "4")
                                    {
                                        cqc.FR4 = RgArr[s];
                                        //status = cqc.BLLUpdateUserFriendRelative(cqc);
                                        string query = "update FriendRelationMaster set FR4='" + cqc.FR4 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR4 = "";

                                    }
                                    else if (RgArr[s] == "5")
                                    {
                                        cqc.FR5 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR5='" + cqc.FR5 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR5 = "";

                                    }
                                    else if (RgArr[s] == "6")
                                    {
                                        cqc.FR6 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR6='" + cqc.FR6 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR6 = "";

                                    }
                                    else if (RgArr[s] == "7")
                                    {
                                        cqc.FR7 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR7='" + cqc.FR7 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR7 = "";

                                    }

                                    else if (RgArr[s] == "8")
                                    {
                                        cqc.FR8 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR8='" + cqc.FR8 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR8 = "";
                                    }
                                    else if (RgArr[s] == "9")
                                    {
                                        cqc.FR9 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR9='" + cqc.FR9 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR9 = "";

                                    }
                                    else if (RgArr[s] == "10")
                                    {
                                        cqc.FR10 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR10='" + cqc.FR10 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR10 = "";

                                    }
                                    else if (RgArr[s] == "11")
                                    {
                                        cqc.FR11 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR11='" + cqc.FR11 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR11 = "";
                                    }
                                    else if (RgArr[s] == "12")
                                    {
                                        cqc.FR12 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR12='" + cqc.FR12 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR12 = "";

                                    }
                                    else if (RgArr[s] == "13")
                                    {
                                        cqc.FR13 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR13='" + cqc.FR13 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR13 = "";

                                    }
                                    else if (RgArr[s] == "14")
                                    {
                                        cqc.FR14 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR14='" + cqc.FR14 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR14 = "";

                                    }
                                    else if (RgArr[s] == "15")
                                    {
                                        cqc.FR15 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR15='" + cqc.FR15 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR15 = "";

                                    }
                                    else if (RgArr[s] == "16")
                                    {
                                        cqc.FR16 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR16='" + cqc.FR16 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR16 = "";

                                    }
                                    else if (RgArr[s] == "17")
                                    {
                                        cqc.FR17 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR17='" + cqc.FR17 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR17 = "";

                                    }
                                    else if (RgArr[s] == "18")
                                    {
                                        cqc.FR18 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR18='" + cqc.FR18 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR18 = "";


                                    }
                                    else if (RgArr[s] == "19")
                                    {
                                        cqc.FR19 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR19='" + cqc.FR19 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR19 = "";
                                    }
                                    else if (RgArr[s] == "20")
                                    {
                                        cqc.FR20 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR20='" + cqc.FR20 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR20 = "";

                                    }

                                    else if (RgArr[s] == "21")
                                    {
                                        cqc.FR21 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR21='" + cqc.FR21 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR21 = "";

                                    }
                                    else if (RgArr[s] == "22")
                                    {
                                        cqc.FR22 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR22='" + cqc.FR22 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR22 = "";

                                    }
                                    else if (RgArr[s] == "23")
                                    {
                                        cqc.FR23 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR23='" + cqc.FR23 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR23 = "";

                                    }
                                    else if (RgArr[s] == "24")
                                    {
                                        cqc.FR24 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR24='" + cqc.FR24 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR24 = "";

                                    }
                                    else if (RgArr[s] == "25")
                                    {
                                        cqc.FR25 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR25='" + cqc.FR25 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR25 = "";

                                    }
                                    else if (RgArr[s] == "26")
                                    {
                                        cqc.FR26 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR26='" + cqc.FR26 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR26 = "";

                                    }
                                    else if (RgArr[s] == "27")
                                    {
                                        cqc.FR27 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR27='" + cqc.FR27 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR27 = "";


                                    }
                                    else if (RgArr[s] == "28")
                                    {
                                        cqc.FR28 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR28='" + cqc.FR28 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR28 = "";

                                    }
                                    else if (RgArr[s] == "29")
                                    {
                                        cqc.FR29 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR29='" + cqc.FR29 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR29 = "";

                                    }
                                    else if (RgArr[s] == "30")
                                    {
                                        cqc.FR30 = RgArr[s];
                                        string query = "update FriendRelationMaster set FR30='" + cqc.FR30 + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                        status = cc.ExecuteNonQuery(query);
                                        cqc.FR30 = "";
                                    }
                                    else
                                    {

                                    }
                                    status = cqc.BLLTestUserFriendRelative(cqc);

                                    if (status == 0)
                                    {
                                        cqc.BLLInsertUserFriendRelative(cqc);
                                        if (RgArr[s] == "1")
                                        {
                                            cqc.FR1 = RgArr[s];
                                            // status = cqc.BLLUpdateUserFriendRelative(cqc);
                                            string query = "update FriendRelationMaster set FR1='" + cqc.FR1 + "' where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                            cc.ExecuteNonQuery(query);
                                            cqc.FR1 = "";
                                        }
                                    }

                                    else
                                    {


                                        cqc.BLLUpdateUserFriendRelative(cqc);
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (DataRow dr2 in ds1.Tables[0].Rows)
                            {
                                FriId = Convert.ToString(dr2["usrUserId"]);
                                FriName = Convert.ToString(dr2["usrFirstName"]);
                                cqc.frnrelFriendId = FriId;
                                cqc.frnrelFrnRelName = FriName;
                                cqc.frnrelRelation = "friend";
                                cqc.Senderid = "myctin";
                                //cqc.FrnrelPrefix = "Dear";
                                if (prefix == "1")
                                {
                                    cqc.FrnrelPrefix = "Dear";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }
                                else if (prefix == "2")
                                {
                                    cqc.FrnrelPrefix = "Shri";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }
                                else if (prefix == "3")
                                {
                                    cqc.FrnrelPrefix = "Smt";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }
                                else if (prefix == "" || prefix == null)
                                {
                                    cqc.FrnrelPrefix = "Dear";
                                    string query1 = "Update FriendRelationMaster set FriendPrefix= '" + cqc.FrnrelPrefix + "'where UserId='" + cqc.frnrelUserId + "' and  FriendId='" + cqc.frnrelFriendId + "' ";
                                    status = cc.ExecuteNonQuery(query1);
                                }
                                else
                                { }
                            }
                        }
                        if (status > 0)
                        {

                        }
                        string senderId = Convert.ToString(Session["Mobile"]);

                        string myMobileNo = mno.ToString();
                        string myPassword = cc.DESDecrypt(cqc.usrPasssword);
                        string myName = cqc.frnrelFrnRelName;

                        string passwordMessage = "I " + usrName + "(" + senderId.ToString() + ") in " + cityName + " added u on www.myct.in to send SMS.Password for ur First Login is " + myPassword + " for www.myct.in ";
                        int length = passwordMessage.Length;
                        cc.SendMessageRegistrationSMS("Website", myMobileNo, passwordMessage, length);
                        Check = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Check;
    }

    protected void btnDowmLoad_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Friendlist Format/MyCityFriendFile1.csv");

    }
    protected void btnDownloadExcel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Friendlist Format/MyCityFriendFileExcel.xlsx");

    }
    protected void lnkAddFriRel_Click(object sender, EventArgs e)
    {

    }

}



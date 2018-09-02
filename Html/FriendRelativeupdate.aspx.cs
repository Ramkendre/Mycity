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

public partial class html_FriendRelativeupdate : System.Web.UI.Page
{
    string Id;
    UserRegistrationBLL urUserRegBLLObj = new UserRegistrationBLL();
    FriendGroupBLL fgBLLobj = new FriendGroupBLL();
    SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
    string s = "", fname = "", lname = "";
    string[] infix;
    CommonCode cc = new CommonCode();
    int status;
    CommonSqlQueryCode cqc = new CommonSqlQueryCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        Id = Convert.ToString(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            chkGroup1.ClearSelection();

           
            if (Id != "" && Id != null)
            {

                this.show(Id);
            }
        }
       
    }
    private void show(string Id)
    {
        string sql = "select usrFirstName+'  '+usrLastname as name,Relation,FR1,FR2,FR3,FR4,FR5,FR6,FR7,FR8,FR9,FR10,FR11,FR12,FR13,FR14,FR15,FR16,FR17,FR18,FR19,FR20,FR21,FR22,FR23,FR24,FR25,FR26,FR27,FR28,FR29,FR30 from  FriendRelationMaster Right Outer JOIN  UserMaster ON  UserMaster.usrUserId = FriendRelationMaster.FriendId where FriRelId='" + Id + "'";
        DataSet ds = cc.ExecuteDataset(sql);
        txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
            txtRelation.Text = Convert.ToString(ds.Tables[0].Rows[0]["Relation"]);
            string FR1 = Convert.ToString(ds.Tables[0].Rows[0]["FR1"]);
            string FR2 = Convert.ToString(ds.Tables[0].Rows[0]["FR2"]);
            string FR3 = Convert.ToString(ds.Tables[0].Rows[0]["FR3"]);
            string FR4 = Convert.ToString(ds.Tables[0].Rows[0]["FR4"]);
            string FR5 = Convert.ToString(ds.Tables[0].Rows[0]["FR5"]);
            string FR6 = Convert.ToString(ds.Tables[0].Rows[0]["FR6"]);
            string FR7 = Convert.ToString(ds.Tables[0].Rows[0]["FR7"]);
            string FR8 = Convert.ToString(ds.Tables[0].Rows[0]["FR8"]);
            string FR9 = Convert.ToString(ds.Tables[0].Rows[0]["FR9"]);
            string FR10 = Convert.ToString(ds.Tables[0].Rows[0]["FR10"]);
            string FR11 = Convert.ToString(ds.Tables[0].Rows[0]["FR11"]);
            string FR12 = Convert.ToString(ds.Tables[0].Rows[0]["FR12"]);
            string FR13 = Convert.ToString(ds.Tables[0].Rows[0]["FR13"]);
            string FR14 = Convert.ToString(ds.Tables[0].Rows[0]["FR14"]);
            string FR15 = Convert.ToString(ds.Tables[0].Rows[0]["FR15"]);
            string FR16 = Convert.ToString(ds.Tables[0].Rows[0]["FR16"]);
            string FR17 = Convert.ToString(ds.Tables[0].Rows[0]["FR17"]);
            string FR18 = Convert.ToString(ds.Tables[0].Rows[0]["FR18"]);
            string FR19 = Convert.ToString(ds.Tables[0].Rows[0]["FR19"]);
            string FR20 = Convert.ToString(ds.Tables[0].Rows[0]["FR20"]);
            string FR21 = Convert.ToString(ds.Tables[0].Rows[0]["FR21"]);
            string FR22 = Convert.ToString(ds.Tables[0].Rows[0]["FR22"]);
            string FR23 = Convert.ToString(ds.Tables[0].Rows[0]["FR23"]);
            string FR24 = Convert.ToString(ds.Tables[0].Rows[0]["FR24"]);
            string FR25 = Convert.ToString(ds.Tables[0].Rows[0]["FR25"]);
            string FR26 = Convert.ToString(ds.Tables[0].Rows[0]["FR26"]);
            string FR27 = Convert.ToString(ds.Tables[0].Rows[0]["FR27"]);
            string FR28 = Convert.ToString(ds.Tables[0].Rows[0]["FR28"]);
            string FR29 = Convert.ToString(ds.Tables[0].Rows[0]["FR29"]);
            string FR30 = Convert.ToString(ds.Tables[0].Rows[0]["FR30"]);

            
            if (FR1=="1")
            {
                chkGroup1.Items[0].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[0].Selected = false;
            //}
           if (FR2 =="2")
            {
                chkGroup1.Items[1].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[1].Selected = false;
            //}
          if (FR3 =="3")
            {
                chkGroup1.Items[2].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[2].Selected = false;

            //}
          if (FR4 == "4")
            {
                chkGroup1.Items[3].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[3].Selected = false;
            //}
            if (FR5 == "5")
            {
                chkGroup1.Items[4].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[4].Selected = false;
            //}
           if (FR6 == "6")
            {
                chkGroup1.Items[5].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[5].Selected = false;
            //}
            if (FR7 == "7")
            {
                chkGroup1.Items[6].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[6].Selected = false;
            //}
          if (FR8 == "8")
            {
                chkGroup1.Items[7].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[7].Selected = false;
            //}
            if (FR9 == "9")
            {
                chkGroup1.Items[8].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[8].Selected = false;
            //}
        if (FR10 == "10")
            {
                chkGroup1.Items[9].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[9].Selected = false;
            //}
            if (FR11 == "11")
            {
                chkGroup1.Items[10].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[10].Selected = false;
            //}
           if (FR12 == "12")
            {
                chkGroup1.Items[11].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[11].Selected = false;
            //}
             if (FR13 == "13")
            {
                chkGroup1.Items[12].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[12].Selected = false;
            //}
         if (FR14 == "14")
            {
                chkGroup1.Items[13].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[13].Selected = false;
            //}
            if (FR15 == "15")
            {
                chkGroup1.Items[14].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[14].Selected = false;
            //}
          if (FR16 == "16")
            {
                chkGroup1.Items[15].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[15].Selected = false;
            //}
         if (FR17 == "17")
            {
                chkGroup1.Items[16].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[16].Selected = false;
            //}
           if (FR18 == "18")
            {
                chkGroup1.Items[17].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[17].Selected = false;
            //}
           if (FR19 == "19")
            {
                chkGroup1.Items[18].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[18].Selected = false;
            //}
           if (FR20 == "20")
            {
                chkGroup1.Items[19].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[19].Selected = false;
            //}
            if (FR21 == "21")
            {
                chkGroup1.Items[20].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[20].Selected = false;
            //}
            if (FR22 == "22")
            {
                chkGroup1.Items[21].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[21].Selected = false;
            //}
           if (FR23 == "23")
            {
                chkGroup1.Items[22].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[22].Selected = false;
            //}
           if (FR24 == "24")
            {
                chkGroup1.Items[23].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[23].Selected = false;
            //}
            if (FR25 == "25")
            {
                chkGroup1.Items[24].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[24].Selected = false;
            //}
            if (FR26 == "26")
            {
                chkGroup1.Items[25].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[25].Selected = false;
            //}
         if (FR27 == "27")
            {
                chkGroup1.Items[26].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[26].Selected = false;
            //}
            if (FR28 == "28")
            {
                chkGroup1.Items[27].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[27].Selected = false;
            //}
           if (FR29 == "29")
            {
                chkGroup1.Items[28].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[28].Selected = false;
            //}
            if (FR30 == "30")
            {
                chkGroup1.Items[29].Selected = true;
            }
            //else
            //{
            //    chkGroup1.Items[29].Selected = false;

            //}
            else { }
        
        try
            {
                 
//                con.Open();
//                string sql1 = "Select usrFirstName+'  '+usrLastname as name "+
//                " from FriendRelationMaster Right Outer JOIN  UserMaster "+
//" ON  UserMaster.usrUserId = FriendRelationMaster.FriendId  "+ 
//" where FriRelId= '" + Id.ToString() + "'";
//                SqlCommand cmd = new SqlCommand(sql1, con);
            

//                SqlDataReader dr = cmd.ExecuteReader();
//                DataSet dset = cc.ExecuteDataset(sql);

            string Sql="Select usrFirstName+' '+usrLastname as name  from FriendRelationMaster Right Outer JOIN  UserMaster " +
                       " ON  UserMaster.usrUserId = FriendRelationMaster.FriendId  where FriRelId= '" + Id.ToString() + "'";
            ds = cc.ExecuteDataset(Sql);

            foreach (DataRow dr1 in ds.Tables[0].Rows)
                 {
                    fname =Convert.ToString(dr1["name"]);
                     
                 }
                 string fullname = fname;
             infix = fullname.Split(' ');
               //ddlinfix.Items.Add(infix[0]);
            
               if (infix[1] ==" "||infix[1]==null)
               {
                   ddlinfix.Items.Add("");
               }
               else
               {
                   ddlinfix.Items.Add(infix[0]);
                   ddlinfix.Items.Add(infix[1]);
               }
               ddlinfix.DataBind();



            }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    protected void btnUpdateGroup_Click(object sender, EventArgs e)
    {
        try
        {
            Id = Convert.ToString(Request.QueryString["Id"]);
            cqc.frnrelFrnRelName = Convert.ToString(txtName.Text);
            cqc.frnrelRelation = Convert.ToString(txtRelation.Text);
            cqc.FR1 = Convert.ToString(chkGroup1.Items[0]);
            cqc.FR2 = Convert.ToString(chkGroup1.Items[1]);
            cqc.FR3 = Convert.ToString(chkGroup1.Items[2]);
            cqc.FR4 = Convert.ToString(chkGroup1.Items[3]);
            cqc.FR5 = Convert.ToString(chkGroup1.Items[4]);
            cqc.FR6 = Convert.ToString(chkGroup1.Items[5]);
            cqc.FR7 = Convert.ToString(chkGroup1.Items[6]);
            cqc.FR8 = Convert.ToString(chkGroup1.Items[7]);
            cqc.FR9 = Convert.ToString(chkGroup1.Items[8]);
            cqc.FR10 = Convert.ToString(chkGroup1.Items[9]);
            cqc.FR11 = Convert.ToString(chkGroup1.Items[10]);
            cqc.FR12 = Convert.ToString(chkGroup1.Items[11]);
            cqc.FR13 = Convert.ToString(chkGroup1.Items[12]);
            cqc.FR14 = Convert.ToString(chkGroup1.Items[13]);
            cqc.FR15 = Convert.ToString(chkGroup1.Items[14]);
            cqc.FR16 = Convert.ToString(chkGroup1.Items[15]);
            cqc.FR17 = Convert.ToString(chkGroup1.Items[16]);
            cqc.FR18 = Convert.ToString(chkGroup1.Items[17]);
            cqc.FR19 = Convert.ToString(chkGroup1.Items[18]);
            cqc.FR20 = Convert.ToString(chkGroup1.Items[19]);
            cqc.FR21 = Convert.ToString(chkGroup1.Items[20]);
            cqc.FR22 = Convert.ToString(chkGroup1.Items[21]);
            cqc.FR23 = Convert.ToString(chkGroup1.Items[22]);
            cqc.FR24 = Convert.ToString(chkGroup1.Items[23]);
            cqc.FR25 = Convert.ToString(chkGroup1.Items[24]);
            cqc.FR26 = Convert.ToString(chkGroup1.Items[25]);
            cqc.FR27 = Convert.ToString(chkGroup1.Items[26]);
            cqc.FR28 = Convert.ToString(chkGroup1.Items[27]);
            cqc.FR29 = Convert.ToString(chkGroup1.Items[28]);
            cqc.FR30 = Convert.ToString(chkGroup1.Items[29]);
            cqc.FrnrelPrefix = Convert.ToString(ddlprefix.SelectedItem.Text);
            if (ddlprefix.SelectedItem.Text == null)
            {
                cqc.FrnrelPrefix = "Dear";
            }
            cqc.Frnrelinfix = Convert.ToString(ddlinfix.SelectedItem.Text);
            if (ddlinfix.SelectedItem.Text == null)
            {
                cqc.Frnrelinfix = infix[0];
            }
            cqc.Frnrelpostfix = Convert.ToString(ddlpostfix.SelectedItem.Text);
            if (ddlpostfix.SelectedItem.Text == null)
            {
                cqc.Frnrelpostfix = " ";
            }

           // cqc.frnrelRelation = txtRelation.Text;
            try
            {
                string sql11 = "update FriendRelationMaster set FriendPrefix='" + ddlprefix.SelectedItem.Text + "', " +
                    "FriendInfix='" + ddlinfix.SelectedItem.Text + "',FriendPostfix='" + ddlpostfix.SelectedItem.Text + "',Relation='" + txtRelation.Text + "'" +
                    "where FriRelId= '" + Id.ToString() + "'";
                DataSet ds1 = cc.ExecuteDataset(sql11);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                string sql1 = "select UserId,FriendId,FriendPrefix,FriendInfix,FriendPostfix from FriendRelationMaster where FriRelId='" + Id + "' ";
                DataSet ds1 = cc.ExecuteDataset(sql1);
                status = cqc.BLLPrefixUpdate(cqc);
                if (status == 0)
                {
                    //ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('User already Exists')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            string sql = "update FriendRelationMaster set ";


            if (chkGroup1.Items[0].Selected == true)
            {
                sql = sql + "FR1='" + chkGroup1.Items[0].Value + "'";
            }
            else
            {
                sql = sql + "FR1=' '";
            }
            if (chkGroup1.Items[1].Selected == true)
            {
                sql = sql + ",FR2='" + chkGroup1.Items[1].Value + "'";
            }
            else
            {
                sql = sql + ",FR2=' '";
            }
            if (chkGroup1.Items[2].Selected == true)
            {
                sql = sql + ",FR3='" + chkGroup1.Items[2].Value + "'";
            }
            else
            {
                sql = sql + ",FR3=' '";
            }
            if (chkGroup1.Items[3].Selected == true)
            {
                sql = sql + ",FR4='" + chkGroup1.Items[3].Value + "'";
            }
            else
            {
                sql = sql + ",FR4=' '";
            }
            if (chkGroup1.Items[4].Selected == true)
            {
                sql = sql + ",FR5='" + chkGroup1.Items[4].Value + "'";
            }
            else
            {
                sql = sql + ",FR5=' '";
            }
            if (chkGroup1.Items[5].Selected == true)
            {
                sql = sql + ",FR6='" + chkGroup1.Items[5].Value + "'";
            }
            else
            {
                sql = sql + ",FR6=' '";
            }
            if (chkGroup1.Items[6].Selected == true)
            {
                sql = sql + ",FR7='" + chkGroup1.Items[6].Value + "'";
            }
            else
            {
                sql = sql + ",FR7=' '";
            }
            if (chkGroup1.Items[7].Selected == true)
            {
                sql = sql + ",FR8='" + chkGroup1.Items[7].Value + "'";
            }
            else
            {
                sql = sql + ",FR8=' '";
            }
            if (chkGroup1.Items[8].Selected == true)
            {
                sql = sql + ",FR9='" + chkGroup1.Items[8].Value + "'";
            }
            else
            {
                sql = sql + ",FR9=' '";
            }
            if (chkGroup1.Items[9].Selected == true)
            {
                sql = sql + ",FR10='" + chkGroup1.Items[9].Value + "'";
            }
            else
            {
                sql = sql + ",FR10=' '";
            }
            if (chkGroup1.Items[10].Selected == true)
            {
                sql = sql + ",FR11='" + chkGroup1.Items[10].Value + "'";
            }
            else
            {
                sql = sql + ",FR11=' '";
            }
            if (chkGroup1.Items[11].Selected == true)
            {
                sql = sql + ",FR12='" + chkGroup1.Items[11].Value + "'";
            }
            else
            {
                sql = sql + ",FR12=' '";
            }
            if (chkGroup1.Items[12].Selected == true)
            {
                sql = sql + ",FR13='" + chkGroup1.Items[12].Value + "'";
            }
            else
            {
                sql = sql + ",FR13=' '";
            }
            if (chkGroup1.Items[13].Selected == true)
            {
                sql = sql + ",FR14='" + chkGroup1.Items[13].Value + "'";
            }
            else
            {
                sql = sql + ",FR14=' '";
            }
            if (chkGroup1.Items[14].Selected == true)
            {
                sql = sql + ",FR15='" + chkGroup1.Items[14].Value + "'";
            }
            else
            {
                sql = sql + ",FR15=' '";
            }
            if (chkGroup1.Items[15].Selected == true)
            {
                sql = sql + ",FR16='" + chkGroup1.Items[15].Value + "'";
            }
            else
            {
                sql = sql + ",FR16=' '";
            }
            if (chkGroup1.Items[16].Selected == true)
            {
                sql = sql + ",FR17='" + chkGroup1.Items[16].Value + "'";
            }
            else
            {
                sql = sql + ",FR17=' '";
            }
            if (chkGroup1.Items[17].Selected == true)
            {
                sql = sql + ",FR18='" + chkGroup1.Items[17].Value + "'";
            }
            else
            {
                sql = sql + ",FR18=' '";
            }
            if (chkGroup1.Items[18].Selected == true)
            {
                sql = sql + ",FR19='" + chkGroup1.Items[18].Value + "'";
            }
            else
            {
                sql = sql + ",FR19=' '";
            }
            if (chkGroup1.Items[19].Selected == true)
            {
                sql = sql + ",FR20='" + chkGroup1.Items[19].Value + "'";
            }
            else
            {
                sql = sql + ",FR20=' '";
            }
            if (chkGroup1.Items[20].Selected == true)
            {
                sql = sql + ",FR21='" + chkGroup1.Items[20].Value + "'";
            }
            else
            {
                sql = sql + ",FR21=' '";
            }
            if (chkGroup1.Items[21].Selected == true)
            {
                sql = sql + ",FR22='" + chkGroup1.Items[21].Value + "'";
            }
            else
            {
                sql = sql + ",FR22=' '";
            }
            if (chkGroup1.Items[22].Selected == true)
            {
                sql = sql + ",FR23='" + chkGroup1.Items[22].Value + "'";
            }
            else
            {
                sql = sql + ",FR23=' '";
            }
            if (chkGroup1.Items[23].Selected == true)
            {
                sql = sql + ",FR24='" + chkGroup1.Items[23].Value + "'";
            }
            else
            {
                sql = sql + ",FR24=' '";
            }
            if (chkGroup1.Items[24].Selected == true)
            {
                sql = sql + ",FR25='" + chkGroup1.Items[24].Value + "'";
            }
            else
            {
                sql = sql + ",FR25=' '";
            }
            if (chkGroup1.Items[25].Selected == true)
            {
                sql = sql + ",FR26='" + chkGroup1.Items[25].Value + "'";
            }
            else
            {
                sql = sql + ",FR26=' '";
            }
            if (chkGroup1.Items[26].Selected == true)
            {
                sql = sql + ",FR27='" + chkGroup1.Items[26].Value + "'";
            }
            else
            {
                sql = sql + ",FR27=' '";
            }
            if (chkGroup1.Items[27].Selected == true)
            {
                sql = sql + ",FR28='" + chkGroup1.Items[27].Value + "'";
            }
            else
            {
                sql = sql + ",FR28=' '";
            }
            if (chkGroup1.Items[28].Selected == true)
            {
                sql = sql + ",FR29='" + chkGroup1.Items[28].Value + "'";
            }
            else
            {
                sql = sql + ",FR29=' '";
            }
            if (chkGroup1.Items[29].Selected == true)
            {
                sql = sql + ",FR30='" + chkGroup1.Items[29].Value + "'";
            }
            else
            {
                sql = sql + ",FR30=' '";
            }


            sql = sql + " where FriRelId='" + Id + "'";

            DataSet ds = cc.ExecuteDataset(sql);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Record Updated successfully')", true);
               
            Response.Redirect("profileSetting1.aspx");
         }
        catch (Exception ex)
        { 
        
        
        }

    }
}

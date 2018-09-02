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

public partial class MarketingAdmin_FamilyReport : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        try
        {
            string Sql = "SELECT TOp(10) EzeeApp_Id,IMEINo,SIMNo,MemberName,AppMobileNo,Purpose,RefMobileNo,PartyName,PassCode,Active,RegDate FROM Apart_RegEzeeDevice";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvItem.DataSource = ds.Tables[0];
            gvItem.DataBind();
        }
        catch (Exception ex)
        { }

        try
        {
            string Sql = "Select Id, p5+' '+p6+' '+p7 as FullName , p4 , p24 from  androidlongcode where p3='Head' order by id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvVoter.DataSource = ds.Tables[0];
            gvVoter.DataBind();
        }
        catch (Exception ex)
        { }
    }

    //---------------------------Word No---------------------------------------------

    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Select Id, p5+' '+p6+' '+p7 as FullName , p4 , p9 from  androidlongcode where p9='" + txtWordNo.Text + "' order by id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvWordNoHead.DataSource = ds.Tables[0];
            gvWordNoHead.DataBind();

            //string Sql1 = "Select Id, p5+' '+p6+' '+p7 as FullName , p4 , p9 from  androidlongcode where p9='" + txtWordNo.Text + "' order by id desc";
            //DataSet ds1 = cc.ExecuteDataset(Sql1);
            //gvWordNoMem.DataSource = ds1.Tables[0];
            //gvWordNoMem.DataBind();
        }
        catch (Exception ex)
        { }
    }
    protected void gvWordNoHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Push")
        {
            string Id = Convert.ToString(e.CommandArgument);
            string Sql1 = "Select p4 from  androidlongcode where id=" + Id + "";
            string HeadMobileNo = cc.ExecuteScalar(Sql1);
            if (HeadMobileNo == "" || HeadMobileNo == null)
            { }
            else
            {
                string Sql = "Select Id, p7+' '+p8+' '+p9 as FullName ,p6  , p11 ,p4 ,p5 from androidlongcode where p4='" + HeadMobileNo + "' and p3='Member'";
                DataSet ds1 = cc.ExecuteDataset(Sql);
                gvWordNoMem.DataSource = ds1.Tables[0];
                gvWordNoMem.DataBind();
            }
        }

    }
    protected void btnReligion_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Select Id, p5+' '+p6+' '+p7 as FullName , p4 , p18 from  androidlongcode where p18='" + ddlReligion.SelectedItem.Text + "' order by id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvReligionHead.DataSource = ds.Tables[0];
            gvReligionHead.DataBind();
        }
        catch (Exception ex)
        { }
    }

    protected void gvReligionHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Push")
        {
            string Id = Convert.ToString(e.CommandArgument);
            string Sql1 = "Select p4 from  androidlongcode where id=" + Id + "";
            string HeadMobileNo = cc.ExecuteScalar(Sql1);
            if (HeadMobileNo == "" || HeadMobileNo == null)
            { }
            else
            {
                string Sql = "Select Id, p7+' '+p8+' '+p9 as FullName ,p6 ,p4 ,p5 from androidlongcode where p4='" + HeadMobileNo + "' and p3='Member'";
                DataSet ds1 = cc.ExecuteDataset(Sql);
                GvMemReligion1.DataSource = ds1.Tables[0];
                GvMemReligion1.DataBind();
            }
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt16(txtAge1.Text) < Convert.ToInt16(txtAge2.Text))
            {
                string sql = "Select Id, p5+' '+p6+' '+p7 as FullName , p4 , p12 from  androidlongcode where p12 between '" + Convert.ToInt16(txtAge1.Text) + "' and '" + Convert.ToInt16(txtAge2.Text) + "' And p3='Head' order by id desc";
                DataSet ds1 = cc.ExecuteDataset(sql);

                gvAgeHead.DataSource = ds1.Tables[0];
                gvAgeHead.DataBind();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Input string was not in a correct format.") ;

        }
    }

    protected void gvAgeHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Push")
        {
            string sql = "select Id, p7+' '+p8+' '+p9 as FullName, p6 , p14 from androidlongcode where p4='(Select p4 from  androidlongcode where id=" + Convert.ToString(e.CommandArgument) + ")'";
            DataSet ds2 = cc.ExecuteDataset(sql);

            gvAgeMember.DataSource = ds2.Tables[0];
            gvAgeMember.DataBind();
        }
    }

    protected void btnPincode_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPincode.Text.Length == 6)
            {
                string sql = "select Id, p5+' '+p6+' '+p7 as FullName , p4 , p10 from androidlongcode where p10='" + Convert.ToInt32(txtPincode.Text) + "'";
                DataSet ds1 = cc.ExecuteDataset(sql);

                gvPincodeHead.DataSource = ds1.Tables[0];
                gvPincodeHead.DataBind();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Input string was not in a correct format.")
                ;
        }
    }

    protected void gvPincodeHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Push")
        {
            string sql = "select Id, p7+' '+p8+' '+p9 as FullName, p6 , p12 from androidlongcode where p4='(Select p4 from  androidlongcode where id=" + Convert.ToString(e.CommandArgument) + ")'";
            DataSet ds2 = cc.ExecuteDataset(sql);

            gvPincodeMember.DataSource = ds2.Tables[0];
            gvPincodeMember.DataBind();
        }
    }

    protected void btnEdu_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtEdu.Text != "")
            {
                string sql = "select Id, p5+' '+p6+' '+p7 as FullName , p4 , p14 from androidlongcode where p14='" + Convert.ToString(txtEdu.Text) + "'";
                DataSet ds1 = cc.ExecuteDataset(sql);

                gvEduHead.DataSource = ds1.Tables[0];
                gvEduHead.DataBind();
            }
        }
        catch (Exception ex)
        {
            if (ex.Message == "Input string was not in a correct format.")
                ;
        }
    }

    protected void gvEduHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToString(e.CommandName) == "Push")
        {
            string sql = "select Id, p7+' '+p8+' '+p9 as FullName, p6 , p16 from androidlongcode where p4='(Select p4 from  androidlongcode where id=" + Convert.ToString(e.CommandArgument) + ")'";
            DataSet ds2 = cc.ExecuteDataset(sql);

            gvEduMember.DataSource = ds2.Tables[0];
            gvEduMember.DataBind();
        }
    }
    //-------------------------------------Voting List No----------------------------------------------

    protected void btnDisplay_Click(object sender, EventArgs e)
    {
        try
        {
            string Sql = "Select Id, p5+' '+p6+' '+p7 as FullName , p4 , p24 from  androidlongcode where  p24 ='"+txtVoting.Text+"' and p3='Head' order by id desc";
            DataSet ds = cc.ExecuteDataset(Sql);
            gvVoter.DataSource = ds.Tables[0];
            gvVoter.DataBind();
        }
        catch (Exception xe)
        { }
    }
}

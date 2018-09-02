using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MarketingAdmin_SMSPushing : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //pnlPhoto.Visible = false;
            if (Convert.ToString(Session["MarketingUser"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                
                DataSet ds = new DataSet();
                string Sql = "Select GroupValueId, GroupValueName from GroupValue where GroupItemId=1 order by GroupValueName ";
                Sql = Sql + " Select GroupValueId, GroupValueName from GroupValue where GroupItemId=2 order by GroupValueName ";
                Sql = Sql + " Select GroupValueId, GroupValueName from GroupValue where GroupItemId=3 order by GroupValueName ";
                Sql = Sql + " Select GroupValueId, GroupValueName from GroupValue where GroupItemId=4 order by GroupValueName ";
                Sql = Sql + " Select GroupValueId, GroupValueName from GroupValue where GroupItemId=5 order by GroupValueName ";
                Sql = Sql + " SELECT     CityMaster.cityId as Id, StateMaster.stateName+' - '+ DistrictMaster.distName+' - '+ CityMaster.cityName as Name " +
                         " FROM         CityMaster INNER JOIN  DistrictMaster ON CityMaster.distId = DistrictMaster.distId INNER JOIN " +
                         " StateMaster ON DistrictMaster.stateId = StateMaster.stateId   order by stateName,distName,cityName  ";
                
                ds = cc.ExecuteDataset(Sql);
                ViewState["Group"] = ds;
                LoadAllSocialGroup();
                string MId = Convert.ToString(Request.QueryString["Id"]);
                if (MId != null && MId != "")
                {
                    LoadAllData(MId);
                }
            }
        }
    }
    private void LoadAllData(string Mid)
    {
        try
        {
            string Sql = "Select Name, Msg, TotalMsg,Days, StartDate from SMSPushing where Id=" + Mid + "";
            Sql = Sql + " Select CityId from SMSPushingCity where SMSPushingId=" + Mid + "";
            Sql = Sql + " Select GroupId from SMSPushingGroup where SMSPushingId=" + Mid + "";
            DataSet ds = cc.ExecuteDataset(Sql);

            txtName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            txtMsg.Text = Convert.ToString(ds.Tables[0].Rows[0]["Msg"]);
            txtTotal.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalMsg"]);
            txtTotalDays.Text = Convert.ToString(ds.Tables[0].Rows[0]["Days"]);
            txtValidFrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["StartDate"]);

            foreach (ListItem lst in lstCity.Items)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    if (Convert.ToString(dr["CityId"]) == lst.Value.ToString())
                    {
                        lst.Selected = true;
                    }
                }
            }


            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                foreach (ListItem lst in lstBussiness.Items)
                {
                    if (Convert.ToString(dr["GroupId"]) == lst.Value.ToString())
                    {
                        lst.Selected = true;
                    }
                    else
                    {
                        foreach (ListItem lst1 in lstMemberOf.Items)
                        {
                            if (Convert.ToString(dr["GroupId"]) == lst1.Value.ToString())
                            {
                                lst1.Selected = true;
                            }
                            else
                            {
                                foreach (ListItem lst2 in lstPolitical.Items)
                                {
                                    if (Convert.ToString(dr["GroupId"]) == lst2.Value.ToString())
                                    {
                                        lst2.Selected = true;
                                    }
                                    else
                                    {
                                        foreach (ListItem lst3 in lstProfessional.Items )
                                        {
                                            if (Convert.ToString(dr["GroupId"]) == lst3.Value.ToString())
                                            {
                                                lst3.Selected = true;
                                            }
                                            else
                                            {
                                                foreach (ListItem lst4 in lstSocial.Items)
                                                {
                                                    if (Convert.ToString(dr["GroupId"]) == lst4.Value.ToString())
                                                    {
                                                        lst4.Selected = true;
                                                    }
                                                }
                                            }
                                        }//lstprofessional
                                    }
                                }//lst political
                            }
                        }//lst member of
                    }
                }//lstbussiness


            }

        }
        catch (Exception ex)
        {
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int i = ValidateData();
        if (i == 0)
        {
            try
            {
                string Id = Convert.ToString(Request.QueryString["Id"]);
                
                string Sql=" Update SMSPushing set Name='"+txtName.Text.ToString()+"', "+
                    " Msg='"+txtMsg.Text.ToString()+"' "+
                    " Where Id="+Id+"";
                Sql = Sql + " Delete from SMSPushingCity where SMSPushingId=" + Id + "";
                foreach(ListItem lst in lstCity.Items)
                {
                    if(lst.Selected)
                    {
                        Sql=Sql + " Insert into SMSPushingCity(SMSPushingId, CityId) Values("+Id+","+lst.Value.ToString()+")";
                    }
                }
                Sql = Sql + " Delete from SMSPushingGroup where SMSPushingId=" + Id + "";
                foreach(ListItem lst in lstBussiness.Items)
                {
                    if(lst.Selected)
                    {
                        Sql=Sql + " Insert into SMSPushingGroup(SMSPushingId, GroupId) Values("+Id+","+lst.Value.ToString()+")";
                    }
                }

                foreach(ListItem lst in lstMemberOf.Items )
                {
                    if(lst.Selected)
                    {
                        Sql=Sql + " Insert into SMSPushingGroup(SMSPushingId, GroupId) Values("+Id+","+lst.Value.ToString()+")";
                    }
                }

                foreach(ListItem lst in lstPolitical.Items )
                {
                    if(lst.Selected)
                    {
                        Sql=Sql + " Insert into SMSPushingGroup(SMSPushingId, GroupId) Values("+Id+","+lst.Value.ToString()+")";
                    }
                }

                foreach(ListItem lst in lstProfessional.Items )
                {
                    if(lst.Selected)
                    {
                        Sql=Sql + " Insert into SMSPushingGroup(SMSPushingId, GroupId) Values("+Id+","+lst.Value.ToString()+")";
                    }
                }

                foreach(ListItem lst in lstSocial.Items)
                {
                    if(lst.Selected)
                    {
                        Sql=Sql + " Insert into SMSPushingGroup(SMSPushingId, GroupId) Values("+Id+","+lst.Value.ToString()+")";
                    }
                }

                cc.ExecuteNonQuery(Sql);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Data Updated successfully')", true);
                lblError.Text = "Data Updated successfully";
                Response.Redirect("SMSPushingList.aspx");
            }
            catch (Exception ex)
            { 
            
            ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Message Not Updated')", true);
                lblError.Text = "SMS Not Update";
            }
        }
    }
    private int ValidateData()
    {
        int flag = 0;
        try
        {
            if (txtName.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Sender Name')", true);
                lblError.Text = "Please Enter SenderName";
                flag=1;
            }
            else if (txtMsg.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Message')", true);
                lblError.Text = "Please Enter SenderName";
                flag = 1;
            }
            else if (lstCity.SelectedItem == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select atleast one city')", true);
                lblError.Text = "Please Select Atleast one city";
                flag = 1;
            }
            else if (lstBussiness.SelectedItem == null && lstMemberOf.SelectedItem==null && lstPolitical.SelectedItem==null && lstProfessional.SelectedItem==null && lstSocial.SelectedItem==null )
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please Select atleast one Group')", true);
                lblError.Text = "Please Select Atleast one Group";
                flag = 1;
            }
            else if (txtTotal.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Total no of msg')", true);
                lblError.Text = "Please Enter Total no of msg";
                flag = 1;
            }
            else if (txtTotalDays.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Please enter Total no of Days')", true);
                lblError.Text = "Please Enter Total no of Days";
                flag = 1;
            }
            else
            {
                try
                {
                    int TotalMsg = Convert.ToInt32(txtTotal.Text.ToString());
                    if (TotalMsg < 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Total Message must be greater than 0')", true);
                        lblError.Text = "Total Message must be greater than 0";
                        flag = 1;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Total Message must be greater than 0')", true);
                    lblError.Text = "Total Message must be greater than 0";
                    flag = 1;
                }

                try
                {
                    int TotalDays = Convert.ToInt32(txtTotalDays.Text.ToString());
                    if (TotalDays < 1)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Total Days must be greater than 0')", true);
                        lblError.Text = "Total Days must be greater than 0";
                        flag = 1;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Total Days must be greater than 0')", true);
                    lblError.Text = "Total Days must be greater than 0";
                    flag = 1;
                }

                try
                {
                    DateTime dt = Convert.ToDateTime(txtValidFrom.Text);
                    if (dt < System.DateTime.Now)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Start day must be greater than or equal to today date')", true);
                        lblError.Text = "Start day must be greater than or equal to today date";
                        flag = 1;
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "msg", "alert('Start day must be greater than or equal to today date')", true);
                    lblError.Text = "Start day must be greater than or equal to today date";
                    flag = 1;
                }

            }


        }
        catch (Exception ex)
        {
            flag = 1;
        }
        return flag;
    }

    private void LoadAllSocialGroup()
    {
        lstSocial.Items.Clear();
        lstProfessional.Items.Clear();
        lstBussiness.Items.Clear();
        lstPolitical.Items.Clear();
        lstMemberOf.Items.Clear();
        lstCity.Items.Clear();
        try
        {
            DataSet ds = (DataSet)ViewState["Group"];
            lstSocial.DataSource = ds.Tables[0];
            lstProfessional.DataSource = ds.Tables[1];
            lstBussiness.DataSource = ds.Tables[2];
            lstPolitical.DataSource = ds.Tables[3];
            lstMemberOf.DataSource = ds.Tables[4];
            lstCity.DataSource = ds.Tables[5];

            lstSocial.DataTextField = "GroupValueName";
            lstProfessional.DataTextField = "GroupValueName";
            lstBussiness.DataTextField = "GroupValueName";
            lstPolitical.DataTextField = "GroupValueName";
            lstMemberOf.DataTextField = "GroupValueName";
            lstCity.DataTextField = "Name";

            lstSocial.DataValueField = "GroupValueId";
            lstProfessional.DataValueField = "GroupValueId";
            lstBussiness.DataValueField = "GroupValueId";
            lstPolitical.DataValueField = "GroupValueId";
            lstMemberOf.DataValueField = "GroupValueId";
            lstCity.DataValueField = "Id";

            lstSocial.DataBind();
            lstProfessional.DataBind();
            lstBussiness.DataBind();
            lstPolitical.DataBind();
            lstMemberOf.DataBind();
            lstCity.DataBind();

        }
        catch (Exception ex)
        { }
    }
}

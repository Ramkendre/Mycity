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
using System.Collections.Generic;

public partial class MarketingAdmin_UdiseSchoolecodeSmsDetails : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]

    public static List<string> GetCountries(string prefixText)
    {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
            con.Open();
            string sql = "select SchoolCode " +
                        " FROM [Come2myCityDB].[dbo].[UDISE_RegisterStudent] as t1 " +
                        " where  SchoolCode like @SchoolCode+'%'  group by  SchoolCode";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@SchoolCode", prefixText);
            SqlDataReader dr = cmd.ExecuteReader(); 
            List<string> CountryNames = new List<string>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    CountryNames.Add(dt.Rows[i][1].ToString());
            //}
            while (dr.Read())
            {
                CountryNames.Add(dr["SchoolCode"].ToString());
            }

        return CountryNames;

        
    }

    protected void tbnSearch_Click(object sender, EventArgs e)
    {
        
        try
        {
            if (ddlList.SelectedValue == "ADM")
            {
                if (txtdatefrom.Text == "" || txtdateto.Text == "")
                {
                    string sql = "select t1.SchoolCode ,t5.[SchoolName] , sum(t1.[RegBoys]) as boycount,sum(t1.[RegGirls]) as girlcount " +
                                " FROM [Come2myCityDB].[dbo].[UDISE_RegisterStudent] as t1 inner join [UDISE_SchoolMaster] as t5 on t1.SchoolCode=t5.SchoolCode " +
                                " where  t1.SchoolCode like '" + txtCountry.Text + "%'  group by  t1.SchoolCode,t5.[SchoolName]";
                    ds = cc.ExecuteDataset(sql);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDataDisplay.DataSource = ds;
                        gvDataDisplay.DataBind();
                    }
                    else
                    {
                        gvDataDisplay.DataSource = ds;
                        gvDataDisplay.DataBind();

                    }
                }
                else
                {
                    // Select By dates ADM
                    string sql4 = "  select t4.[SchoolCode],t4.[Class],t4.[Division],t4.[RegBoys],t4.[RegGirls] ,t2.boycount,t2.girlcount " +
                                  " from (  select SchoolCode  , sum(t1.[RegBoys]) as boycount,sum(t1.[RegGirls]) as girlcount " +
                                  " FROM [Come2myCityDB].[dbo].[UDISE_RegisterStudent] as t1 " +
                                  "where  t1.SchoolCode like '" + txtCountry.Text + "%' and [EntryDate] BETWEEN  '" + txtdatefrom.Text + "' and '" + txtdateto.Text + "'   group by  SchoolCode ) as t2 inner join [Come2myCityDB].[dbo].[UDISE_RegisterStudent] as t4 on t2.SchoolCode=t4.SchoolCode ";
                   
                
                    ds = cc.ExecuteDataset(sql4);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDataDisplay.DataSource = ds;
                        gvDataDisplay.DataBind();
                    }
                    else
                    {
                        gvDataDisplay.DataSource = ds;
                        gvDataDisplay.DataBind();

                    }

                }
            }
            else
            {
                if (txtdatefrom.Text == "" || txtdateto.Text == "")
                {

                    //string sql = " SELECT Distinct CONVERT(VARCHAR(10), t1.[EntryDate], 101) AS [MM/DD/YYYY],t1.[SchoolCode],t5.SchoolName " +
                    //               "  ,sum(t1.[Present_B]) as TotPresntBoys " +
                    //               " ,sum(t1.[Present_G]) as TotPresentgirls " +
                    //               " ,sum(t1.[mdmStudPresent]) as TotMealStud " +
                    //               "   FROM [Come2myCityDB].[dbo].[UDISE_StudentPresenty] as t1 " +
                    //               "   inner join [UDISE_SchoolMaster] as t5 on t1.SchoolCode=t5.SchoolCode " +
                    //               "   where  t1.SchoolCode like '" + txtCountry.Text + "%' " +
                    //               "  group By t1.SchoolCode,t1.EntryDate,SchoolName ";

                    string sql = " SELECT Distinct CONVERT(VARCHAR(10), t1.[EntryDate], 101) AS [MM/DD/YYYY],t1.[SchoolCode],t5.SchoolName ,sum(t1.RegBoys+t1.RegGirls) as Register_Enrollment_Total,    " +
                                 " sum(t1.[Present_B] + t1.[Present_G]) as Present_Total,sum(t1.[mdmStudPresent]) as TotMealStud , t4.Total_sms_Count " +
                                 " FROM ( Select count(shortcode) as Total_sms_Count,SchoolCode from  " +
                                 " come2Mycity.test inner join UserMaster on UserMaster.usrMobileNo =test.mobile  " +
                                 " inner join UDISE_TeacherMaster on UDISE_TeacherMaster.junior_id  =UserMaster.usrUserId  " +
                                 " where  UDISE_TeacherMaster.SchoolCode like '" + txtCountry.Text + "%' group by SchoolCode ) as t4 " +
                                 " inner join  [Come2myCityDB].[dbo].[UDISE_StudentPresenty] as t1 on t4.SchoolCode = t1.SchoolCode     " +
                                 " inner join [UDISE_SchoolMaster] as t5 on t1.SchoolCode=t5.SchoolCode     " +
                                 " where  t1.SchoolCode like '" + txtCountry.Text + "%' group By t1.SchoolCode,t1.EntryDate,SchoolName,t4.Total_sms_Count ";
  

                    ds = cc.ExecuteDataset(sql);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gvDataDisplay.DataSource = ds;
                        gvDataDisplay.DataBind();
                    }
                    else
                    {
                        gvDataDisplay.DataSource = ds;
                        gvDataDisplay.DataBind();
                    }
                }
                else
                {
                    //string sql3 = "  Select distinct CONVERT(VARCHAR(10),t2.[EntryDate], 101) AS [MM/DD/YYYY], t4.SchoolCode,t5.[SchoolName],t4.[Class],t4.[Division],t4.[Present_B],t4.[Present_G],t2.TotMealStud  from  " +
                    //                 "   ( SELECT t1.[SchoolCode],t1.[EntryDate] " +
                    //                 "  ,sum(t1.[Present_B]) as TotPresntBoys " +
                    //                 "  ,sum(t1.[Present_G]) as TotPresentgirls " +
                    //                 "  ,sum(t1.[mdmStudPresent]) as TotMealStud " +
                    //                 "   FROM [Come2myCityDB].[dbo].[UDISE_StudentPresenty] as t1   " +
                    //                 " where  t1.SchoolCode like '" + txtCountry.Text + "%' and [EntryDate] BETWEEN  '" + txtdatefrom.Text + "' and '" + txtdateto.Text + "'  " +
                    //                 " group By t1.SchoolCode,t1.EntryDate) as t2  " +
                    //                 " inner join [Come2myCityDB].[dbo].[UDISE_StudentPresenty] as t4 on  " +
                    //                 "  t2.SchoolCode=t4.SchoolCode   and  " +
                    //                 " t2.[EntryDate]=t4.[EntryDate] " +
                    //                 " inner join [UDISE_SchoolMaster] as t5 on t4.SchoolCode=t5.SchoolCode";

                 

                    string sql3 = "   Select distinct (CONVERT(VARCHAR(10),t2.[EntryDate], 101)) AS [MM/DD/YYYY], t4.SchoolCode,t5.[SchoolName],t2.Register_Enrollment,t2.Presenty_Total,t2.TotMealStud ,t2.Total_sms_Count " +  
                                   " from     (   " +
                                   "  SELECT t1.[SchoolCode],t1.[EntryDate],sum(t1.RegBoys+t1.RegGirls) as Register_Enrollment ,sum(t1.[Present_B] + t1.[Present_G]) as Presenty_Total ,sum(t1.[mdmStudPresent]) as TotMealStud ,t7.Total_sms_Count  " +  
                                   "  FROM (Select count(shortcode) as Total_sms_Count,SchoolCode from  " +
                                   " come2Mycity.test inner join UserMaster on UserMaster.usrMobileNo =test.mobile  " +
                                   " inner join UDISE_TeacherMaster on UDISE_TeacherMaster.junior_id  =UserMaster.usrUserId  " +
                                   " where  UDISE_TeacherMaster.SchoolCode like '" + txtCountry.Text + "%' group by SchoolCode) as t7 " +
                                   " inner join [Come2myCityDB].[dbo].[UDISE_StudentPresenty] as t1 on t7.SchoolCode = t1.SchoolCode    " +
                                   "  where  t1.SchoolCode like '" + txtCountry.Text + "%' " +
                                   "  and [EntryDate] BETWEEN '" + txtdatefrom.Text + "' and '" + txtdateto.Text + "'   " +
                                   "  group By t1.SchoolCode,t1.EntryDate,t7.Total_sms_Count) as t2    " +
                                   "  inner join [Come2myCityDB].[dbo].[UDISE_StudentPresenty] as t4 on    t2.SchoolCode=t4.SchoolCode " +  
                                   "  and   t2.[EntryDate]=t4.[EntryDate]  " +
                                   "  inner join [UDISE_SchoolMaster] as t5 on t4.SchoolCode=t5.SchoolCode "; 
  
  

                    ds = cc.ExecuteDataset(sql3);
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDataDisplay.DataSource = ds;
                    gvDataDisplay.DataBind();
                }
            }
        }
        catch (Exception ex)
        {

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=MDM-"+DateTime.Now+".xls");
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            gvDataDisplay.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();

        }
        catch (Exception ex)
        {

        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

 
}

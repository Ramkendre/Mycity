using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : WebService
{
    public AutoComplete()
    {
    }

    [WebMethod]
    public string[] GetQualification(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
            SqlParameter prm;
            string sql = "Select cast(qualificationId as nvarchar)+':'+qualificationName as qualificationName FROM UserQualification WHERE qualificationName LIKE @prefixText";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            prm = new SqlParameter("@prefixText", SqlDbType.VarChar, 50);
            prm.Value = "%" + prefixText + "%";
            cmd.SelectCommand.Parameters.Add(prm);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["qualificationName"].ToString(), i);
                i++;
            }
            connection.Close();
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string[] GetBoardUniversity(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
            SqlParameter prm;
            string sql = "Select cast (brduniId as nvarchar) +':'+ brduniName as brduniName FROM UserBoardUniversity WHERE brduniName LIKE @prefixText";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            prm = new SqlParameter("@prefixText", SqlDbType.VarChar, 50);
            prm.Value = "%" + prefixText + "%";
            cmd.SelectCommand.Parameters.Add(prm);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["brduniName"].ToString(), i);
                i++;
            }
            connection.Close();
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [WebMethod]
    public string[] GetProfession(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
            SqlParameter prm;
            string sql = "Select cast (professionId as nvarchar) +':'+ professionName as professionName FROM UserProfession WHERE professionName LIKE @prefixText";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            prm = new SqlParameter("@prefixText", SqlDbType.VarChar, 50);
            prm.Value = "%" + prefixText + "%";
            cmd.SelectCommand.Parameters.Add(prm);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["professionName"].ToString(), i);
                i++;
            }
            connection.Close();
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string[] GetIndustry(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
            SqlParameter prm;
            string sql = "Select cast (industryId as nvarchar) +':'+ industryName as  industryName FROM UserIndustry WHERE industryName LIKE @prefixText";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            prm = new SqlParameter("@prefixText", SqlDbType.VarChar, 50);
            prm.Value = "%" + prefixText + "%";
            cmd.SelectCommand.Parameters.Add(prm);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["industryName"].ToString(), i);
                i++;
            }
            connection.Close();
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string[] GetArea(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
            SqlParameter prm;
            string sql = "Select cast (userAreaId as nvarchar) +':'+userAreaName as userAreaName  FROM UserArea WHERE userAreaName LIKE @prefixText";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            prm = new SqlParameter("@prefixText", SqlDbType.VarChar, 50);
            prm.Value = "%" + prefixText + "%";
            cmd.SelectCommand.Parameters.Add(prm);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["userAreaName"].ToString(), i);
                i++;
            }
            connection.Close();
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string[] GetSocialMembership(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
            SqlParameter prm;
            string sql = "Select cast(mbrSocialId as nvarchar)+':'+mbrSocialName as mbrSocialName FROM UserSocialMembership WHERE mbrSocialName LIKE @prefixText";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            prm = new SqlParameter("@prefixText", SqlDbType.VarChar, 50);
            prm.Value = "%" + prefixText + "%";
            cmd.SelectCommand.Parameters.Add(prm);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["mbrSocialName"].ToString(), i);
                i++;
            }
            connection.Close();
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    [WebMethod]
    public string[] GetPoliticalMembership(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
            SqlParameter prm;
            string sql = "Select cast(mbrPolId as nvarchar)+':'+ mbrPolName as mbrPolName FROM UserPoliticalMembership WHERE mbrPolName LIKE @prefixText";
            SqlDataAdapter cmd = new SqlDataAdapter(sql, connection);
            prm = new SqlParameter("@prefixText", SqlDbType.VarChar, 50);
            prm.Value = "%" + prefixText + "%";
            cmd.SelectCommand.Parameters.Add(prm);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                items.SetValue(dr["mbrPolName"].ToString(), i);
                i++;
            }
            connection.Close();
            return items;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    [WebMethod]
    public string[] GetPoliticalMembershipTest(string prefixText, int count)
    {
        try
        {
            SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
            connection.Open();
        
            string sql = "Select mbrPolId,mbrPolName FROM UserPoliticalMembership WHERE mbrPolName LIKE @prefixText";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@mbrPolName", prefixText + "%");

            SqlDataReader dr = cmd.ExecuteReader();
            List<string> MbrPolList = new List<string>();
            string mbrItem = string.Empty;
            while (dr.Read())
            {
                mbrItem = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr[0].ToString(), dr[1].ToString());
                MbrPolList.Add(mbrItem);
            }



            connection.Close();
            return MbrPolList.ToArray();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}



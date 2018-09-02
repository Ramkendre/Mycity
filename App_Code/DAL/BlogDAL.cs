using System;
using System.Collections .Generic ;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for BlogDAL
/// </summary>
public class BlogDAL
{
	public BlogDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public List<BlogBll> getBlog(BlogBll obj)
    {
        List<BlogBll> list = new List<BlogBll>();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {
                SqlParameter[] para = new SqlParameter[1];
                para[0] = new SqlParameter("@id",obj .bgId );
                dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "uspBlogInfo", para);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        BlogBll bg = new BlogBll();
                        bg.bgId = Convert.ToInt32(dr ["bgId"]);
                        bg.BgWriter = Convert.ToString(dr ["BgWriter"]);
                        bg.Bg = Convert.ToString(dr ["Bg"]);
                        bg.BgDate = Convert.ToDateTime(dr ["BgDate"]);
                        bg.aggri = Convert.ToInt32(dr ["aggri"]);
                        bg.notAggri = Convert.ToInt32(dr ["notAggri"]);
                        bg.photo = Convert.ToString(dr ["photo"]);

                        list.Add(bg );
                    
                    
                    }
                
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }



        return list;
    
    }
}

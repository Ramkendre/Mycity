using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for NewsDAL
/// </summary>
public class NewsDAL
{
    CommonCode cc = new CommonCode();
	public NewsDAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<NewsBLL> getNewsDDL()
    {
        DataSet ds = new DataSet();
        List<NewsBLL> news = new List<NewsBLL>();
        try
        {
            string sql = "select * from GroupValue where GroupItemId=6";
            ds = cc.ExecuteDataset(sql );
            string nm = "";
            int id = 0;
            foreach (DataRow dr in ds.Tables[0].Rows )
            {
                NewsBLL obj1 = new NewsBLL();
                id = Convert.ToInt32(dr["GroupValueId"]);
                nm = Convert.ToString(dr["GroupValueName"]);
                obj1.NewsPaperId = id;
                obj1.NewsPaperName = nm;
                news.Add(obj1 );
            }

        }
        catch (Exception tt)
        {
            throw tt;
        }
      return news;
    }

    public List<NewsBLL> getDistNames()
    {
        DataSet ds = new DataSet();
        List<NewsBLL> news = new List<NewsBLL>();
        try
        {
            string sql = "select * from DistrictMaster";
            ds = cc.ExecuteDataset(sql);
            string nm = "";
            int id = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                NewsBLL obj1 = new NewsBLL();
                id = Convert.ToInt32(dr["distId"]);
                nm = Convert.ToString(dr["distName"]);
                obj1.DistId = id;
                obj1.DistName = nm;
                news.Add(obj1);
            }

        }
        catch (Exception tt)
        {
            throw tt;
        }
        return news;
    }

    public List<NewsBLL> getNewsData(NewsBLL objk)
    {
        List<NewsBLL> NewsDataObj = new List<NewsBLL>();
        DataSet ds = new DataSet();
        string sqlStr = "SELECT News_Update.id as ID, News_Update.NewsFrom as NEWSFROM, News_Update.News as NEWS,News_Update.GroupValId as GROUPVALID,News_Update.CurDate as NDATE, DistrictMaster.distId as DID,DistrictMaster.distName as DNAME,CityMaster.cityId as CID, CityMaster.cityName as CNAME FROM  CityMaster INNER JOIN DistrictMaster ON CityMaster.distId = DistrictMaster.distId INNER JOIN News_Update ON CityMaster.cityId = News_Update.CityId where DistrictMaster.distId = "+objk .DistId +" AND GROUPVALID= "+objk .NewsPaperId +"";
              
        ds = cc.ExecuteDataset(sqlStr );
       foreach (DataRow dr in ds.Tables[0].Rows)
        {
            NewsBLL ob = new NewsBLL();
            ob.ID = Convert.ToInt32(dr ["ID"]);
            ob.NewsFrom = Convert.ToString(dr["NEWSFROM"]);
            ob.News = Convert.ToString(dr["NEWS"]);
            ob.Date = Convert.ToDateTime(dr["NDATE"]);
            NewsDataObj.Add(ob );
        
        }

        return NewsDataObj;
    
    }

}

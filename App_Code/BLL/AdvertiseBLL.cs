using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AddAdvertiseBLL
/// </summary>
public class AdvertiseBLL
{
    AdvertiseDAL advDALObj = new AdvertiseDAL();
    public AdvertiseBLL()
    {

    }

    int status;

    private string _AdvId;
    private string _Name;
    private string _ImageURL;
    private string _CreationDate;
    private string _ModifiedDate;
    private string _ValidFrom;
    private string _ValidTo;
    private string _Active;
    private string _AgentName;
    private string _ModifierName;
    private string _Imgname;
    private int _maxId;
    private string _Type;





    public string AdvId { get; set; }
    public string Name { get; set; }
    public string ImageURL { get; set; }
    public string CreationDate { get; set; }
    public string ModifiedDate { get; set; }
    public string ValidFrom { get; set; }
    public string ValidTo { get; set; }
    public string Active { get; set; }
    public string AgentName { get; set; }
    public string ModifierName { get; set; }
    public string Imgname { get; set; }
    public int maxId { get; set; }
    public string Type { get; set; }


    public int BLLAdvertiseInsert(AdvertiseBLL ad)
    {
        status = advDALObj.DALAdvertiseInsert(ad);
        return status;
    }

    public DataTable BLLAdvertiseShowAll()
    {
        DataTable dtAdvertiseShowAll = advDALObj.DALAdvertiseShowAll();
        return dtAdvertiseShowAll;
    }


    //public void getAddById(AdvertiseBLL ad)
    //{
    //    this.GetAddById = advDALObj.GetAdvertiseInfo(ad);
    //}

    public int BLLAdvertiseUpdate(AdvertiseBLL ad)
    {
        status = advDALObj.DALAdvertiseUpdate(ad);
        return status;
    }



}

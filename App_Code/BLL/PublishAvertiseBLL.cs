using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PublishAvertiseBLL
/// </summary>
public class PublishAvertiseBLL
{
    PublishAdvertiseDAL pubAdvDALObj = new PublishAdvertiseDAL();
    public PublishAvertiseBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int status;

    private int _TypeId;
    private string _TypeName;

    private int _LocId;
    private string _LocationName;

    private int _PubId;
    private string _State;
    private string _City;
    private string _Category;
    private string _Type;
    private string _CreationDate;
    private string _ModifiedDate;
    private string _ValidFrom;
    private string _ValidTo;
    private string _Active;
    private string _AgentName;
    private string _ModifierName;
    private string _AdvId;
    private string _currentDate;


    public int TypeId { get; set; }
    public string TypeName { get; set; }

    public int LocId { get; set; }
    public string LocationName { get; set; }

    public int PubId { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
    public string CreationDate { get; set; }
    public string ModifiedDate { get; set; }
    public string ValidFrom { get; set; }
    public string ValidTo { get; set; }
    public string Active { get; set; }
    public string AgentName { get; set; }
    public string ModifierDate { get; set; }
    public string AdvId { get; set; }
    public string currentDate { get; set; }

    public DataTable BLLAdvertiseTypeSelect()
    {
        DataTable dtAdvertiseType = pubAdvDALObj.DALAdvertiseTypeSelect();
        return dtAdvertiseType;
    }

    public int InsertPublishAddInfo(PublishAvertiseBLL pub)
    {
        status = pubAdvDALObj.DALPublishAdvertiseInsert(pub);
        return status;
    }

    public DataTable BLLAdvertiseLocation()
    {
        return pubAdvDALObj.DALAdvertiseLocationSelect();
    }

    public bool BLLAdvtiseCheckIfExist(PublishAvertiseBLL pub)
    {
        return pubAdvDALObj.DALCheckIsExistAtLocation(pub);
    }




}

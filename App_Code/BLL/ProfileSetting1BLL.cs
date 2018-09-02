using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ProfileSetting1BLL
/// </summary>
public class ProfileSetting1BLL
{
    ProfileSetting1DAL objdal = new ProfileSetting1DAL();
    int status;
    public ProfileSetting1BLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }

    private string _Groupid;

    public string Groupid
    {
        get { return _Groupid; }
        set { _Groupid = value; }
    }

    private string _GroupName;

    public string GroupName
    {
        get { return _GroupName; }
        set { _GroupName = value; }
    }

    public DataSet BLLGetUserFriendRelationById(ProfileSetting1BLL obj)
    {
        DataSet ds = objdal.DALGetUserFriendRelationById(obj);
        return ds;
    }
    public DataSet BLLGetUserFriendNameRelationById(ProfileSetting1BLL obj)
    {
        DataSet ds = objdal.DALGetUserFriendNameRelationById(obj);
        return ds;
    }
    public DataSet BLLGetUserGroup(ProfileSetting1BLL obj)
    {
        DataSet ds = objdal.DALGetUserGroup(obj);
        return ds;
    }
    public DataSet BLLGetUserGroupTotal(ProfileSetting1BLL obj)
    {
        DataSet ds = objdal.DALGetUserGroupTotal(obj);
        return ds;
    }
    public int BLLUserGroupNameUpdate(ProfileSetting1BLL obj)
    {
        status = objdal.DALUserGroupNameUpdate(obj);
        return status;

    }


}

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
/// Summary description for FriendRelativeBLL
/// </summary>
public class FriendRelativeBLL
{
    FriendRelativeDAL objdal = new FriendRelativeDAL();
	public FriendRelativeBLL()
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
    private int _usrAutoId;

    public int UsrAutoId
    {
        get { return _usrAutoId; }
        set { _usrAutoId = value; }
    }
    private string _friendid;

    public string Friendid
    {
        get { return _friendid; }
        set { _friendid = value; }
    }

    private int _groupid;

    public int Groupid
    {
        get { return _groupid; }
        set { _groupid = value; }
    }
    private string _FR1;

    public string FR1
    {
        get { return _FR1; }
        set { _FR1 = value; }
    }
    private string _FR2;

    public string FR2
    {
        get { return _FR2; }
        set { _FR2 = value; }
    }
    private string _FR3;
    private string _FR4;
    private string _FR5;
    private string _FR6;
    private string _FR7;
    private string _FR8;
    private string _FR9;
    private string _FR10;
    private string _FR11;
    private string _FR12;
    private string _FR13;
    private string _FR14;
    private string _FR15;
    private string _FR16;
    private string _FR17;
    private string _FR18;
    private string _FR19;
    private string _FR20;
    private string _FR21;
    private string _FR22;
    private string _FR23;
    private string _FR24;
    private string _FR25;
    private string _FR26;
    private string _FR27;
    private string _FR28;
    private string _FR29;
    private string _FR30;
    public string FR3
    {
        get { return _FR3; }
        set { _FR3 = value; }
    }
    public string FR4
    {
        get { return _FR4; }
        set { _FR4 = value; }
    }
    public string FR5
    {
        get { return _FR5; }
        set { _FR5 = value; }
    }
    public string FR6
    {
        get { return _FR6; }
        set { _FR6 = value; }
    }
    public string FR7
    {
        get { return _FR7; }
        set { _FR7 = value; }
    }
    public string FR8
    {
        get { return _FR8; }
        set { _FR8 = value; }
    }
    public string FR9
    {
        get { return _FR9; }
        set { _FR9 = value; }
    }
    public string FR10
    {
        get { return _FR10; }
        set { _FR10 = value; }
    }
    public string FR11
    {
        get { return _FR11; }
        set { _FR11 = value; }
    }

    public string FR12
    {
        get { return _FR12; }
        set { _FR12 = value; }
    }

    public string FR13
    {
        get { return _FR13; }
        set { _FR13 = value; }
    }

    public string FR14
    {
        get { return _FR14; }
        set { _FR14 = value; }
    }

    public string FR15
    {
        get { return _FR15; }
        set { _FR15 = value; }
    }

    public string FR16
    {
        get { return _FR16; }
        set { _FR16 = value; }
    }

    public string FR17
    {
        get { return _FR17; }
        set { _FR17 = value; }
    }
    public string FR18
    {
        get { return _FR18; }
        set { _FR18 = value; }
    }

    public string FR19
    {
        get { return _FR19; }
        set { _FR19 = value; }
    }
    public string FR20
    {
        get { return _FR20; }
        set { _FR20 = value; }
    }
    public string FR21
    {
        get { return _FR21; }
        set { _FR21 = value; }
    }
    public string FR22
    {
        get { return _FR22; }
        set { _FR22 = value; }
    }
    public string FR23
    {
        get { return _FR23; }
        set { _FR23 = value; }
    }
    public string FR24
    {
        get { return _FR24; }
        set { _FR24 = value; }
    }
    public string FR25
    {
        get { return _FR25; }
        set { _FR25 = value; }
    }
    public string FR26
    {
        get { return _FR26; }
        set { _FR26 = value; }
    }
    public string FR27
    {
        get { return _FR27; }
        set { _FR27 = value; }
    }
    public string FR28
    {
        get { return _FR28; }
        set { _FR28 = value; }
    }
    public string FR29
    {
        get { return _FR29; }
        set { _FR29 = value; }
    }
    public string FR30
    {
        get { return _FR30; }
        set { _FR30 = value; }
    }

    private string _usrfname;

    public string Usrfname
    {
        get { return _usrfname; }
        set { _usrfname = value; }
    }
    private string _usrlname;

    public string Usrlname
    {
        get { return _usrlname; }
        set { _usrlname = value; }
    }
    private string _usrMobile;

    public string UsrMobile
    {
        get { return _usrMobile; }
        set { _usrMobile = value; }
    }

    public DataSet BLLGetUserFrndIdName(FriendRelativeBLL obj)
    {
        DataSet ds = objdal.DALGetUserFrndIdName(obj);
        return ds;
    }
    public DataSet BLLGetUserAutoId(FriendRelativeBLL obj)
    {
        DataSet ds = objdal.DALGetUserAutoId(obj);
        return ds;
    }
    public DataSet BLLGetUserGroup(FriendRelativeBLL obj)
    {
        DataSet ds = objdal.DALGetUserGroup(obj);
        return ds;
    }
    public DataSet BLLspUserRegistrationMobileSelectById(FriendRelativeBLL obj)
    {
        DataSet ds = objdal.DALspUserRegistrationMobileSelectById(obj);
        return ds;
    }
    public DataSet BLLGetfrndinfo(FriendRelativeBLL obj)
    {
        DataSet ds = objdal.DALGetfrndinfo(obj);
        return ds;
    }
    public DataSet BLLUserImageId(FriendRelativeBLL obj)
    {
        DataSet ds = objdal.DALUserImageId(obj);
        return ds;
    }
    public DataSet BLLGetUsrBasicInfobyMobile(FriendRelativeBLL obj)
    {
        DataSet ds = objdal.DALGetUsrBasicInfobyMobile(obj);
        return ds;
    }

    public int BLLUpdateFrndGroup(FriendRelativeBLL obj)
    {
        int status = objdal.DALUpdateFrndGroup(obj);
        return status;
    }

}

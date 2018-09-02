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
/// Summary description for UserInfoBLL
/// </summary>
public class UserInfoBLL
{
    int status;
    UserInfoDAL dalobj=new UserInfoDAL();
	public UserInfoBLL()
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

    private int _usrAutoid;

    public int UsrAutoid
    {
        get { return _usrAutoid; }
        set { _usrAutoid = value; }
    }


    private byte[] image;

    public byte[] Image
    {
        get { return image; }
        set { image = value; }
    }
    private int _groupid;

    public int Groupid
    {
        get { return _groupid; }
        set { _groupid = value; }
    }
    private int groupitemid;

    public int Groupitemid
    {
        get { return groupitemid; }
        set { groupitemid = value; }
    }

    private string _ConsumerNo;

    public string ConsumerNo
    {
        get { return _ConsumerNo; }
        set { _ConsumerNo = value; }
    }
    private int _schoolid;

    public int Schoolid
    {
        get { return _schoolid; }
        set { _schoolid = value; }
    }
    private int _classid;

    public int Classid
    {
        get { return _classid; }
        set { _classid = value; }
    }
    public DataSet BLLGetUserAutoId(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetUserAutoId(obj);
        return ds;
    }
    public DataSet BLLGetUserImageId(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetUserImageId(obj);
        return ds;
    }

    public DataSet BLLGetReligion(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetReligion(obj);
        return ds;
    }
    public DataSet BLLGetCategory(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetCategory(obj);
        return ds;
    }
    public DataSet BLLGetGroupRecord(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetGroupRecord(obj);
        return ds;
    }
    public int BLLUserImageInsert(UserInfoBLL obj)
    {
        
        status = dalobj.DALUserImageInsert(obj);
        return status;

    }
    public int BLLUserImageUpdate(UserInfoBLL obj)
    {

        status = dalobj.DALUserImageUpdate(obj);
        return status;

    }
    public DataSet BLLLGetUserGroup(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetUserGroup(obj);
        return ds;
    }
    public int BLLUserGroupDelete(UserInfoBLL obj)
    {

        status = dalobj.DALUserGroupDelete(obj);
        return status;

    }
    public int BLLUserGroupInsert(UserInfoBLL obj)
    {

        status = dalobj.DALUserGroupInsert(obj);
        return status;

    }
    public DataSet BLLGetUserConsumerNo(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetUserConsumerNo(obj);
        return ds;
    }
    public int BLLUserConsumerDelete(UserInfoBLL obj)
    {

        status = dalobj.DALUserConsumerDelete(obj);
        return status;

    }
    public int BLLUserConsumerInsert(UserInfoBLL obj)
    {

        status = dalobj.DALUserConsumerInsert(obj);
        return status;

    }
    public DataSet BLLGetSchoolRecord(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetSchoolRecord(obj);
        return ds;
    }
    public DataSet BLLGetClassRecord(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetClassRecord(obj);
        return ds;
    }
    public DataSet BLLLGetSchoolbyId(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetSchoolbyId(obj);
        return ds;
    }
    public DataSet BLLGetClassbyId(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetClassbyId(obj);
        return ds;
    }
    public DataSet BLLGetFamilyInfobyId(UserInfoBLL obj)
    {
        DataSet ds = dalobj.DALGetFamilyInfobyId(obj);
        return ds;
    }
    
   
}

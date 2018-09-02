using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FriendGroupBLL
/// </summary>
public class FriendGroupBLL
{
    FriendGroupDAL fgDALObj = new FriendGroupDAL();
    int status;

    public FriendGroupBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int _friendGroupId;
    private string _friendGroupName;
    private int _Rowid;
    private string _UserName;
    private string _mobileNo;
    private string _usercity;

    public int rowNumber
    {
        get
        {
            return _Rowid;
        }
        set
        {
            _Rowid = value;
        }
    }

    public string usrFullName
    {
        get
        {
            return _UserName;
        }
        set
        {
            _UserName = value;
        }

    }

    public string usrMobileNo
    {
        get
        {
            return _mobileNo;
        }
        set
        {
            _mobileNo = value;
        }

    }

    public string usrCity
    {
        get
        {
            return _usercity;
        }
        set
        {
            _usercity = value;
        }

    }

    public int friendGroupId
    {
        get
        {
            return _friendGroupId;
        }
        set
        {
            _friendGroupId = value;
        }

    }


    public string friendGroupName
    {
        get
        {
            return _friendGroupName;
        }

        set
        {
            _friendGroupName = value;
        }
    }



  
    //public int BLLFriendGroupInsert(FriendGroupBLL fg)
    //{
    //    status = fgDALObj.DALFriendGroupInsert(fg);
    //    return status;
    //}

    //public int BLLFriendGroupUpdate(FriendGroupBLL fg)
    //{
    //    status = fgDALObj.DALFriendGroupUpdate(fg);
    //    return status;
    //}

    //public DataTable BLLShowAllFriendGroup(UserRegistrationBLL ur)
    //{
    //    DataTable dtShowAllFriendGroup = fgDALObj.DALSelectAllFriendGroup(ur);
    //    return dtShowAllFriendGroup;
    //}

    //public DataTable BLLGetSelectedFriendGroup(FriendGroupBLL fg)
    //{
    //    DataTable dtFriendGrupSelected=fgDALObj.DALFriendGroupSelectedById(fg);
    //    return dtFriendGrupSelected;
    //}

    //public DataTable BLLGetSelectedFriendGroupName(FriendGroupBLL fg)
    //{
    //    DataTable dtFriendGrupSelected = fgDALObj.DALFriendGroupNameSelectedById(fg);
    //    return dtFriendGrupSelected;
    //}



    public DataTable BLLShowFriendGroupForUser(UserRegistrationBLL ur)
    {
        DataTable dtShowFriendGroup = fgDALObj.DALShowFriendGroupForUser(ur);
        return dtShowFriendGroup;
    }

    public DataTable BLLShowFriendInGroup(UserRegistrationBLL ur)
    {
        DataTable dtShowFriendInGroup = fgDALObj.DALShowFriendInGroup(ur);
        return dtShowFriendInGroup;
    }
    


}

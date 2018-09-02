using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CityBLL
/// </summary>
public class UserBLL
{
    UserDAL userDAL = new UserDAL();
    public UserBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    DataSet ds = new DataSet();

    private string _loginid;
    private string _username;
    private string _password;
    private string _contactno;
    private string _address;
    private DateTime _doj;
    private int _role;
    private int _companyId;
    private string _rolename;
    private string _companyname;
    private string _userid;

    public string Userid
    {
        get { return _userid; }
        set { _userid = value; }
    }
    private string _committeeid;

    public string Committeeid
    {
        get { return _committeeid; }
        set { _committeeid = value; }
    }
    

    //********************for sub user***********************

    private string _Userid;
    private string _cityname;
    private string _rolename1;
    private string _Mono;
    private string _Doj;
    private string _District;
    private int _RoleId;

    private int _Mid;

    private List<UserBLL> _getAllUser;

    #region Properties
    //*********************Foe subuser/******************

    public string Id
    {
        get
        {
            return _Userid;
        }
        set
        {
            _Userid = value;
        }
    }
   

    public string CityName
    {
        get
        {
            return _cityname;
        }
        set
        {
            _cityname = value;
        }
    }
    public string District
    {
        get
        {
            return _District;
        }
        set
        {
            _District = value;
        }
    }
    public string RoleName1
    {
        get
        {
            return _rolename1;
        }
        set
        {
            _rolename1 = value;
        }
    }
    public string MONO
    {
        get
        {
            return _Mono;
        }
        set
        {
            _Mono = value;
        }
    }
     public string Date
    {
        get
        {
            return _Doj;
        }
        set
        {
            _Doj = value;
        }
    }

     public int  RoleId1
     {
         get
         {
             return _RoleId;
         }
         set
         {
             _RoleId = value;
         }
     }






     public int MID
     {
         get
         {
             return _Mid;
         }
         set
         {
             _Mid = value;
         }
     }




    public string LoginId
    {
        get
        {
            return _loginid;
        }
        set
        {
            _loginid = value;
        }
    }

    public string UserName
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }

    public string Password 
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
        }
    }

    public string ContactNo
    {
        get
        {
            return _contactno;
        }
        set
        {
            _contactno = value;
        }
    }

    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }

    public DateTime DOJ
    {
        get
        {
            return _doj;
        }
        set
        {
            _doj = value;
        }
    }

    public int Role
    {
        get
        {
            return _role;
        }
        set
        {
            _role = value;
        }
    }

    public string RoleName
    {
        get
        {
            return _rolename;
        }
        set
        {
            _rolename = value;
        }
    }
    public int CompanyId
    {
        get
        {
            return _companyId;
        }
        set
        {
            _companyId = value;
        }
    }

    public string CompanyName
    {
        get
        {
            return _companyname;
        }
    }

    public List<UserBLL> getAllUser
    {
        get
        {
            return _getAllUser;
        }
        set
        {
            _getAllUser = value;
        }
    }



 

#endregion properties 

    public DataSet GetUserDetails(UserBLL user)
    {
        ds = userDAL.DALShowUserDetails(user);
        return ds;
    }
    public int UpdateOwnDetails(UserBLL user)
    {
        status = userDAL.UpdateOwnDetails(user);
        return status;
    }


    public int insertUser(UserBLL user)
    {
        status = userDAL.insertUser1(user);
        return status;
    }


    public int updateUser(UserBLL user)
    {
        status = userDAL.updateUser1(user);
        return status;
    }

    public int BLLinsertUserCommittee(UserBLL user)
    {
        status = userDAL.insertUserCommitee(user);
        return status;
    }

    public int BLLUpdateUserCommittee(UserBLL user)
    {
        status = userDAL.UpdateUserCommitee(user);
        return status;
    }
    public int BLLGetUserId(UserBLL user)
    {
        status = userDAL.DALGetUserId(user);
        return status;
    }
    



    

}

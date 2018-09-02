using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CityBLL
/// </summary>
public class Role
{
    RoleDAL roledal = new RoleDAL();
    public Role()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    DataSet ds = new DataSet();

    private int _roleid;
    private string _rolename;
    private string _menuid;

    private List<Role> _getAllRole;

    #region Properties
    public int RoleId
    {
        get
        {
            return _roleid;
        }
        set
        {
            _roleid  = value;
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
            _rolename  = value;
        }
    }

    public string MenuId
    {
        get
        {
            return _menuid;
        }
        set
        {
            _menuid  = value;
        }
    }

    public List<Role  > getAllRole
    {
        get
        {
            return _getAllRole;
        }
        set
        {
            _getAllRole  = value;
        }
    }

    #endregion properties

    public DataSet GetAllRole()
    {
        ds = roledal.DALGetAllRole();
        return ds;
    }

   




}

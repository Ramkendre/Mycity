using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DistrictBLL
/// </summary>
public class DistrictBLL
{
    DistrictDAL districtBLLObj = new DistrictDAL();
    int status;
    public DistrictBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int _distId;
    private string _distName;
    private int _stateId;
    private int _countryId;
    private string _stateName;
    public List<DistrictBLL> _getAllDistrict;

    public int distId
    {
        get
        {
            return _distId;
        }
        set
        {
            _distId = value;
        }
    }


    public string distName
    {
        get
        {
            return _distName;
        }
        set
        {
            _distName = value;
        }
    }

    public int stateId
    {
        get
        {
            return _stateId;
        }
        set
        {
            _stateId = value;
        }
    }

    public int countryId
    {
        get
        {
            return _countryId;
        }
        set
        {
            _countryId = value;
        }
    }

    public string stateName
    {
        get
        {
            return _stateName;
        }
        set
        {
            _stateName = value;
        }
    }

    public List<DistrictBLL> getAllDistrict
    {
        get
        {
            return _getAllDistrict;
        }
        set
        {
            _getAllDistrict = value;
        }
    }

    public DataTable BLLDistrictShowAll()
    {
        DataTable dtDistrictShowAll = districtBLLObj.DALDistrictShowAll();
        return dtDistrictShowAll;
    }

    public int BLLDistrictInsert(DistrictBLL dt)
    {
        status = districtBLLObj.DALInsertDistrict(dt);
        return status;
    }

    public int BLLDisrtictUpdate(DistrictBLL dt)
    {
        status = districtBLLObj.DALDistrictUpdate(dt);
        return status;
    }


    public bool BLLIsExistDistrictName(DistrictBLL bt)
    {
        bool flag = false;

        flag = districtBLLObj.DALIsExistDistrictName(bt);
        return flag;
    }


    public bool BLLIsExistDistrict(DistrictBLL dt)
    {
        bool flag = false;
        int i;
        flag = districtBLLObj.DALIsExistDistrict(dt);

        if (flag == false)
        {


            i = districtBLLObj.DALDistrictUpdate(dt);
            if (i == 0)
            {
                flag = true;
            }

        }
        return flag;

    }


    public DataTable BLLDistrictSelected(DistrictBLL dt)
    {

        DataTable dtDisrictSelectById = districtBLLObj.DALGetSelectedDistrict(dt);
        return dtDisrictSelectById;
    }




    public DataTable BLLGetSelectedDistrictBySId(DistrictBLL dt, int i)
    {
        DataTable dtDistrictSelectBySId = districtBLLObj.DALDistrictSelectBySId(dt, i);
        return dtDistrictSelectBySId;
    }

    public DataTable BLLDistrictHCShowAll(int sId)
    {
        DataTable dtDistrictShowAll = districtBLLObj.DALDistrictHCShowAll(sId);
        return dtDistrictShowAll;
    }
}
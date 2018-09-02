using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CityBLL
/// </summary>
public class CityBLL
{
    CityDAL cityDALObj = new CityDAL();
    public CityBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int status;
    DataSet ds = new DataSet();

    private int _cityId;
    private string _cityName;
    private int _distId;
    private string _distName;
    private int _stateId;
    private string _stateName;
    private List<CityBLL> _getAllCity;
    private List<CityBLL> _getCitySearchFor;


    public int cityId
    {
        get
        {
            return _cityId;
        }
        set
        {
            _cityId = value;
        }
    }

    public string cityName
    {
        get
        {
            return _cityName;
        }
        set
        {
            _cityName = value;
        }
    }

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

    public List<CityBLL> getAllCity
    {
        get
        {
            return _getAllCity;
        }
        set
        {
            _getAllCity = value;
        }
    }

    public List<CityBLL> getCitySearchFor
    {
        get
        {
            return _getCitySearchFor;
        }
        set
        {
            _getCitySearchFor = value;
        }
    }


    public DataTable BLLShowAllCity()
    {
        DataTable dtCityShowAll = cityDALObj.DALShowAllCity();
        return dtCityShowAll;
    }


    public bool BLLIsExistCityName(CityBLL ct)
    {
        bool flag = false;
        flag = cityDALObj.DALIsExistCityName(ct);
        return flag;
    }

    public int BLLInsertCity(CityBLL ct)
    {
        status = cityDALObj.DALInsertCity(ct);
        return status;
    }


    public int BLLUpdateCity(CityBLL ct)
    {
        status = cityDALObj.DALUpdateCity(ct);
        return status;
    }



    public DataTable BLLGetSelectedCity(CityBLL ct)
    {
        DataTable dtCitySelectById = cityDALObj.DALCitySelectedById(ct);
        return dtCitySelectById;
    }

    //public int DeleteCity(CityBLL ct)
    //{
    //    int i = cityDALObj.delete(ct);
    //    return i;
    //}

    public DataTable BLLGetSelectedCityForSearch(CityBLL ct)
    {
        DataTable dtCitySearchFor = cityDALObj.DALCitySelectedById(ct);
        return dtCitySearchFor;
    }


    public DataTable BLLGetSelectedCityByDId(CityBLL ct, int i)
    {
        DataTable dtCitySelectByDId = cityDALObj.DALCitySelectedByDId(ct, i);
        return dtCitySelectByDId;
    }

    public DataTable BLLGetSelectedCitySearch(CityBLL ct)
    {
        DataTable dtCitySelectSearch = cityDALObj.DALCitySelectedSearch(ct);
        return dtCitySelectSearch;
    }

}

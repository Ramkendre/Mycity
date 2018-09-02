using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CityInformationBLL
/// </summary>
public class CityInformationBLL
{
    CityInformationDAL ctInfoDALObj = new CityInformationDAL();
    public CityInformationBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int _cityRefId;
    private string _cityName;
    private string _cityAbout;
    private string _cityLongtitude;
    private string _cityLatitude;
    private string _cityArea;
    private string _cityHeightFromSea;
    private string _cityLanguage;
    private string _cityLiteracy;
    private string _cityPopulation;

    private string _cityHistoricalImp;
    private string _cityGeographicalImp;
    private string _citySocialImp;
    private string _cityRegionalImp;
    private string _cityPoliticalImp;



    private string _cityByRailApro;
    private string _cityByAirApro;
    private string _cityByBusApro;

    private List<CityInformationBLL> _getCityInformation;

    public int cityRefId
    {
        get
        {
            return _cityRefId;
        }
        set
        {
            _cityRefId = value;
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
    public string cityAbout
    {
        get
        {
            return _cityAbout;
        }
        set
        {
            _cityAbout = value;
        }
    }

    public string cityLongtitude
    {
        get
        {
            return _cityLongtitude;
        }
        set
        {
            _cityLongtitude = value;
        }
    }
    public string cityLatitude
    {
        get
        {
            return _cityLatitude;
        }
        set
        {
            _cityLatitude = value;
        }
    }


    public string cityArea
    {
        get
        {
            return _cityArea;
        }
        set
        {
            _cityArea = value;
        }
    }
    public string cityHeightFromSea
    {
        get
        {
            return _cityHeightFromSea;
        }
        set
        {
            _cityHeightFromSea = value;
        }
    }
    public string cityLanguage
    {
        get
        {
            return _cityLanguage;
        }
        set
        {
            _cityLanguage = value;
        }
    }
    public string cityLiteracy
    {
        get
        {
            return _cityLiteracy;
        }
        set
        {
            _cityLiteracy = value;
        }
    }
    public string cityPopulation
    {
        get
        {
            return _cityPopulation;
        }
        set
        {
            _cityPopulation = value;
        }
    }

    public string cityHistoricalImp
    {
        get
        {
            return _cityHistoricalImp;
        }
        set
        {
            _cityHistoricalImp = value;
        }
    }
    public string cityGeographicalImp
    {
        get
        {
            return _cityGeographicalImp;
        }
        set
        {
            _cityGeographicalImp = value;
        }
    }
    public string citySocialImp
    {
        get
        {
            return _citySocialImp;
        }
        set
        {
            _citySocialImp = value;
        }
    }
    public string cityRegionalImp
    {
        get
        {
            return _cityRegionalImp;
        }
        set
        {
            _cityRegionalImp = value;
        }
    }
    public string cityPoliticalImp
    {
        get
        {
            return _cityPoliticalImp;
        }
        set
        {
            _cityPoliticalImp = value;
        }
    }



    public string cityByRailApro
    {
        get
        {
            return _cityByRailApro;
        }
        set
        {
            _cityByRailApro = value;
        }
    }
    public string cityByAirApro
    {
        get
        {
            return _cityByAirApro;
        }
        set
        {
            _cityByAirApro = value;
        }
    }
    public string cityByBusApro
    {
        get
        {
            return _cityByBusApro;
        }
        set
        {
            _cityByBusApro = value;
        }
    }


    public List<CityInformationBLL> getCityInformation
    {
        get
        {
            return _getCityInformation;
        }
        set
        {
            _getCityInformation = value;
        }
    }

    public DataTable BLLGetCityInformationById(int cityId)
    {
        DataTable dtCityInfoShowAll = ctInfoDALObj.DALCityInformationSelectedById(cityId);
        return dtCityInfoShowAll;
    }

    public int BLLCityInformationUpdate(CityInformationBLL cti)
    {
        int j = ctInfoDALObj.DALUpdateCityInformation(cti);
        return j;
    }
}

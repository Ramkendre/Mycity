using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CountryBLL
/// </summary>
public class CountryBLL
{
    CountryDAL countryDALObj = new CountryDAL();
    int status;

    public CountryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int _countryId;
    private string _countryName;
    private List<CountryBLL> _getAllCountry;

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


    public string countryName
    {
        get
        {
            return _countryName;
        }

        set
        {
            _countryName = value;
        }
    }


    public List<CountryBLL> GetAllCountry
    {
        get
        {
            return _getAllCountry;
        }
        set
        {
            _getAllCountry = value;
        }
    }


    public int BLLCountryInsert(CountryBLL cn)
    {
        status = countryDALObj.DALCountryInsert(cn);
        return status;
    }

    public int BLLCountryUpdate(CountryBLL cn)
    {
        status = countryDALObj.DALCountryUpdate(cn);
        return status;
    }

    public DataTable BLLShowAllCountry()
    {
        DataTable dtShowAllCountry = countryDALObj.DALCountrySelectAll();
        return dtShowAllCountry;
    }

    public void BLLGetSelectedCountry(CountryBLL cn)
    {
        countryDALObj.DALCountrySelectedById(cn);
    }





}
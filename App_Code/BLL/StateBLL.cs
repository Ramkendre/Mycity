using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for StateBLL
/// </summary>
public class StateBLL
{
    StateDAL stateDALObj = new StateDAL();
    int status;
    public StateBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int _stateId;
    private string _stateName;
    private int _countryId;
    private string _countryName;
    private List<StateBLL> _getStateAll;
    private List<StateBLL> _getStateSelected;
    private List<StateBLL> _getStateByCName;

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

    public List<StateBLL> getStateAll
    {
        get
        {
            return _getStateAll;
        }
        set
        {
            _getStateAll = value;
        }
    }

    public List<StateBLL> getStateSelected
    {
        get
        {
            return _getStateSelected;
        }
        set
        {
            _getStateSelected = value;
        }
    }

    public List<StateBLL> getStateByCName
    {
        get
        {
            return _getStateByCName;
        }
        set
        {
            _getStateByCName = value;
        }
    }

    public int BLLStateInsert(StateBLL st)
    {
        status = stateDALObj.DALStateInsert(st);
        return status;
    }

    public int BLLStateUpdate(StateBLL st)
    {
        status = stateDALObj.DALStateUpdate(st);
        return status;
    }

    public DataTable BLLStateShowAll()
    {
        DataTable dtStateShowAll = stateDALObj.DALStateShowAll();
        return dtStateShowAll;
    }
    //public DataSet BLLStateShowAll()
    //{
    //    DataSet ds = new DataSet();
    //    ds = stateDALObj.DALStateShowAll();
    //    return ds;
    //}

    public DataTable BLLGetSelectedState(StateBLL st)
    {

        DataTable dtStateSelectBySId = stateDALObj.DALStateSelectBySId(st);
        return dtStateSelectBySId;
    }


    public DataTable BLLGetSelectedState(StateBLL st, int i)
    {

        DataTable dtStateSelectByCId = stateDALObj.DALStateSelectByCId(st, i);
        return dtStateSelectByCId;
    }


    public bool BLLIsExistStateName(StateBLL st)
    {
        bool flag = false;
        flag = stateDALObj.DALIsExistCountryName(st);
        return flag;

    }

    public bool BLLIsExistState(StateBLL st)
    {
        bool flag = false;
        int i;
        flag = stateDALObj.DALIsExistState(st);
        if (flag == false)
        {

            i = stateDALObj.DALStateUpdate(st);
            if (i == 0)
            {
                flag = true;
            }

        }
        return flag;

    }

    public DataTable BLLStateHCShowAll()
    {
        DataTable dtStateHCShowAll = stateDALObj.BLLHCStateShowAll();
        return dtStateHCShowAll;
    }


}

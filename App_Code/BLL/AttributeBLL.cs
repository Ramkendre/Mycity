using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AttributeBLL
/// </summary>
public class AttributeBLL
{

    public AttributeBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    AttributeDAL attributeDALObj = new AttributeDAL();

    DataTable dtAttribute = new DataTable();
    int status;

    private int _attributeId;
    private string _attributeName;
    private string _attributeValue;
    private string _attributeType;
    private int _categoryId;
    private bool _isExistAttribute;
    private string _itemAId;
    private int _icaId;




    public int attributeId
    {
        get
        {
            return _attributeId;
        }
        set
        {
            _attributeId = value;
        }
    }


    public string attributeName
    {
        get
        {
            return _attributeName;
        }
        set
        {
            _attributeName = value;
        }
    }

    public string attributeValue
    {
        get
        {
            return _attributeValue;
        }
        set
        {
            _attributeValue = value;
        }
    }

    public string attributeType
    {
        get
        {
            return _attributeType;
        }
        set
        {
            _attributeType = value;
        }
    }

    public int categoryId
    {
        get
        {
            return _categoryId;
        }
        set
        {
            _categoryId = value;
        }
    }

    public string itemAId
    {
        get
        {
            return _itemAId;
        }
        set
        {
            _itemAId = value;
        }
    }

    public int icaId
    {
        get
        {
            return _icaId;
        }
        set
        {
            _icaId = value;
        }
    }

    public bool isExistAttribute
    {
        get
        {
            return _isExistAttribute;
        }
        set
        {
            _isExistAttribute = value;
        }
    }






    public int BLLInsertCategoryAttribute(AttributeBLL at)
    {
        return status = attributeDALObj.DALInsertAttribute(at);
    }

    public int BLLUpdateCategoryAttribute(AttributeBLL at)
    {
        return status = attributeDALObj.DALUpdateAttribute(at);
    }

    public DataTable BLLShowAllAttribute()
    {
        DataTable dtAttributeShowAll = attributeDALObj.DALGetAllAttribute();
        return dtAttributeShowAll;
    }

    public DataTable BLLGetSelectedRecord(AttributeBLL at)
    {
        return dtAttribute = attributeDALObj.DALGetSelectedAttribute(at);
    }

    public DataTable BLLGetCategoryWiseAttribute(AttributeBLL ic)
    {
        return dtAttribute = attributeDALObj.DALGetCategoryWiseAttribute(ic);
    }


    public DataTable BLLShowAttributeByCategoryId(AttributeBLL ic)
    {
        return dtAttribute = attributeDALObj.DALShowAttributeByCategoryId(ic);
    }

}

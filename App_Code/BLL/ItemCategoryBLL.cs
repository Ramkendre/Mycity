using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemCategoryBLL
/// </summary>
public class ItemCategoryBLL
{
    ItemCategoryDAL icDALObj = new ItemCategoryDAL();
    public ItemCategoryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int _itemCategoryId;
    private string _itemICId;
    private string _categoryICId;
    private int _tmpCatId;
    private string _catName;
    private int _attributeId;
    private string _attributeValue;


    private List<ItemCategoryBLL> _getAllItemCategory;
    private List<ItemCategoryBLL> _getSelectedCategory;
    private List<ItemBLL> _GetAllAttribute;

    public int itemCategoryId
    {
        get
        {
            return _itemCategoryId;
        }
        set
        {
            _itemCategoryId = value;
        }
    }

    public string itemICId
    {
        get
        {
            return _itemICId;
        }
        set
        {
            _itemICId = value;
        }
    }

    public string categoryICId
    {
        get
        {
            return _categoryICId;
        }
        set
        {
            _categoryICId = value;
        }
    }

    public int tmpCatId
    {
        get
        {
            return tmpCatId;
        }
        set
        {
            _tmpCatId = value;
        }
    }

    public string catName
    {
        get
        {
            return _catName;
        }
        set
        {
            _catName = value;
        }
    }

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

    public List<ItemCategoryBLL> getAllItemCategory
    {
        get
        {
            return _getAllItemCategory;
        }
        set
        {
            _getAllItemCategory = value;
        }
    }

    public List<ItemCategoryBLL> getSelectedCategory
    {
        get
        {
            return _getSelectedCategory;
        }
        set
        {
            _getSelectedCategory = value;
        }
    }

    public List<ItemBLL> GetAllAttribute
    {
        get
        {

            return _GetAllAttribute;
        }
        set
        {
            _GetAllAttribute = value;
        }
    }

    public int BLLItemCategoryInsert(ItemCategoryBLL ic)
    {
        int i = icDALObj.DALItemCategoryInsert(ic);
        return i;
    }
    public List<ItemCategoryBLL> BLLGetSelectedCityByItemId(ItemCategoryBLL ic)
    {
        return icDALObj.DALGetItemWiseCategory(ic);
    }

    public void BLLShowAttributeByCategory(ItemCategoryBLL it)
    {
        this.GetAllAttribute = ItemCategoryDAL.DALGetAllAttribute(it);
    }


}

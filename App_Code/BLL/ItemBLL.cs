using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ItemBLL
/// </summary>
public class ItemBLL
{
    ItemDAL itemDALObj = new ItemDAL();
    int status;
    public ItemBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int _srNo;
    private string _itemId;
    private string _itemName;
    private string _itemDescription;
    private string _itemImage;
    private string _timg;
    private int _cityId;
    private string _cityName;
    private int _Active;
    private bool _isItemExist;
    private string _categoryId;
    public int _attributeId;


    private List<ItemBLL> _GetAllItem;


    public int srNo
    {
        get
        {
            return _srNo;
        }
        set
        {
            _srNo = value;
        }
    }

    public string itemId
    {
        get
        {
            return _itemId;
        }
        set
        {
            _itemId = value;
        }
    }

    public string itemName
    {
        get
        {
            return _itemName;
        }
        set
        {
            _itemName = value;
        }
    }

    public string itemDescription
    {
        get
        {
            return _itemDescription;
        }
        set
        {
            _itemDescription = value;
        }
    }

    public string itemImage
    {
        get
        {
            return _itemImage;
        }
        set
        {
            _itemImage = value;
        }
    }

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
    public bool isExistItem
    {
        get
        {
            return _isItemExist;
        }
        set
        {
            _isItemExist = value;
        }
    }

    public int itemActive
    {
        get
        {
            return _Active;
        }
        set
        {
            _Active = value;
        }
    }

    public string timg
    {
        get
        {
            return _timg;
        }
        set
        {
            _timg = value;
        }

    }

    public string categoryId
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





    public int BLLInsertItem(ItemBLL it)
    {
        return status = itemDALObj.DALInsertItem(it);
    }

    public int BLLUpdateItem(ItemBLL it)
    {
        return status = itemDALObj.DALUpdateItem(it);
    }

    public DataTable BLLShowAllItem()
    {
        DataTable dtItemShowAll = itemDALObj.DALGetAllItem();
        return dtItemShowAll;
    }



    public DataTable BLLGetSelectedItem(ItemBLL it)
    {
        DataTable dtItemSelectById = itemDALObj.DALGetSelectedItem(it);
        return dtItemSelectById;
    }



}

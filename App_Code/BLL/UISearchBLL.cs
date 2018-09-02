using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UISearchBLL
/// </summary>
public class UISearchBLL
{
    UISearchDAL usDALObj = new UISearchDAL();
    public UISearchBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int _srNo;

    private int _categoryId;

    private int _cityId;

    private int _imageId;

    private string _categoryName;

    private string _itemId;

    private string _itemName;

    private string _itemDescription;

    private string _itemImage;

    private string _attributeName;

    private string _attributeValue;
    public int imageId
    {
        get
        {
            return _imageId;
        }
        set
        {
            _imageId = value;
        }
    }
    private string _imageName;
    private string _imageDescription;

    private string _tmpImage1;
    private string _tmpImage2;
    private string _tmpImage3;

    private string _itemDtlImage1;

    private string _itemDtlImage2;

    private string _itemDtlImage3;

    private List<UISearchBLL> _getSearchItems;

    private List<UISearchBLL> _getCategoryByCity;

    private List<UISearchBLL> _getItemDescription;

    private List<UISearchBLL> _getItemImageDisplay;


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

    public string categoryName
    {
        get
        {
            return _categoryName;
        }
        set
        {
            _categoryName = value;
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

    public string imageName
    {
        get
        {
            return _imageName;
        }
        set
        {
            _imageName = value;
        }
    }

    public string imageDescription
    {
        get
        {
            return _imageDescription;
        }
        set
        {
            _imageDescription = value;
        }
    }

    public string tmpImage1
    {
        get
        {
            return _tmpImage1;
        }
        set
        {
            _tmpImage1 = value;
        }

    }

    public string tmpImage2
    {
        get
        {
            return _tmpImage2;
        }
        set
        {
            _tmpImage2 = value;
        }
    }

    public string tmpImage3
    {
        get
        {
            return _tmpImage3;
        }
        set
        {
            _tmpImage3 = value;
        }
    }

    public string itemDtlImage1
    {
        get
        {
            return _itemDtlImage1;
        }
        set
        {
            _itemDtlImage1 = value;
        }
    }

    public string itemDtlImage2
    {
        get
        {
            return _itemDtlImage2;
        }
        set
        {
            _itemDtlImage2 = value;
        }
    }

    public string itemDtlImage3
    {
        get
        {
            return _itemDtlImage3;
        }
        set
        {
            _itemDtlImage3 = value;
        }
    }

    public List<UISearchBLL> getSearchItems
    {
        get
        {
            return _getSearchItems;
        }
        set
        {
            _getSearchItems = value;
        }
    }

    public List<UISearchBLL> getItemDesciption
    {
        get
        {
            return _getItemDescription;
        }
        set
        {
            _getItemDescription = value;
        }
    }

    public List<UISearchBLL> getCategoryByCity
    {
        get
        {
            return _getCategoryByCity;
        }
        set
        {
            _getCategoryByCity = value;
        }
    }

    public List<UISearchBLL> getItemImageDisplay
    {
        get
        {
            return _getItemImageDisplay;
        }
        set
        {
            _getItemImageDisplay = value;
        }
    }

    public DataTable BLLSearchItem(UISearchBLL usb)
    {
        DataTable dtSearchItem = usDALObj.DALCitySelectedById(usb);
        return dtSearchItem;
    }

    public DataTable BLLItemDescription(UISearchBLL usb)
    {
        DataTable dtItemDescriptionDisplay = usDALObj.DALItemDescriptionDisplay(usb);
        return dtItemDescriptionDisplay;
    }

    public DataTable BLLCategoryByCity(UISearchBLL usb)
    {
        DataTable dtCategoryByCity = usDALObj.DALCategorySelectedByCity(usb);
        return dtCategoryByCity;
    }

    public DataTable BLLTotalRecordNo(UISearchBLL usb)
    {
        DataTable dtTotalRecordNo = usDALObj.DALCitySelectedById(usb);
        return dtTotalRecordNo;
    }

    public DataTable BLLItemDescriptionImageDisplay(UISearchBLL usb)
    {
        DataTable dtItemImageDisplay = usDALObj.DALItemDescriptionImageDisplay(usb);
        return dtItemImageDisplay;
    }


}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemCategoryImageBLL
/// </summary>
public class ItemCategoryImageBLL
{
    ItemCategoryImageDAL iciDALObj = new ItemCategoryImageDAL();
    int status;
    public ItemCategoryImageBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private int _imageId;
    private int _imageSetType;
    private string _imageName;
    private string _imageDescription;
    private string _itemId;
    private int _categoryId;
    private string _categoryName;
    private string _image1;
    private string _image2;
    private string _image3;

    private List<ItemCategoryImageBLL> _getItemCategoryAllImage;

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

    public int imageSetType
    {
        get
        {
            return _imageSetType;
        }
        set
        {
            _imageSetType = value;
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

    public string image1
    {
        get
        {
            return _image1;
        }
        set
        {
            _image1 = value;
        }
    }

    public string image2
    {
        get
        {
            return _image2;
        }
        set
        {
            _image2 = value;
        }

    }

    public string image3
    {
        get
        {
            return _image3;
        }
        set
        {
            _image3 = value;
        }
    }

    public List<ItemCategoryImageBLL> getItemCategoryAllImage
    {
        get
        {
            return _getItemCategoryAllImage;
        }
        set
        {
            _getItemCategoryAllImage = value;
        }
    }


    public int BLLItemCategoryImageInsert(ItemCategoryImageBLL ici)
    {
        status = iciDALObj.DALItemCategoryImageInsert(ici);
        return status;
    }

    public void BLLIsExistsItemCategoryImage(ItemCategoryImageBLL ici, out int status, out int imgId)
    {

        iciDALObj.DALIsExistItemCategoryImage(ici, out status, out imgId);

    }

    public int BLLIsExistsMainItemCategoryImage(ItemCategoryImageBLL ici)
    {

        status = iciDALObj.DALIsExistMainItemCategoryImage(ici);
        return status;
    }

    public int BLLItemCategoryImageUpdate(ItemCategoryImageBLL ici)
    {
        status = iciDALObj.DALItemCategoryImageUpdate(ici);
        return status;
    }

    public int BLLItemCategoryImageSet(ItemCategoryImageBLL ici)
    {
        status = iciDALObj.DALItemCategoryImageSet(ici);
        return status;
    }
}

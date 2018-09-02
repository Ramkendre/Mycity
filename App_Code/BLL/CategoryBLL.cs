using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CategoryBLL
/// </summary>
public class CategoryBLL
{
    public CategoryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int status;

    CategoryDAL categoryDALObj = new CategoryDAL();

    private int _srNo;
    private int _categoryId;
    private int _parentcategoryId;
    private string _categoryName;
    private string _Active;
    private string _menuParentId;
    private int _catLevel;
    private bool _isExistCategory = true;
    private List<CategoryBLL> _selectParentCategory;
    private List<CategoryBLL> _getParentCategory;
    private List<CategoryBLL> _getLeftCategoryMenu;
    private string _parentId;

    public string parentId
    {
        get
        {
            return _parentId;
        }
        set
        {
            _parentId = value;
        }
    }
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


    public int parentCategoryId
    {
        get
        {
            return _parentcategoryId;
        }
        set
        {
            _parentcategoryId = value;
        }
    }

    public string Active
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

    public string menuParentId
    {
        get
        {
            return menuParentId;
        }
        set
        {
            menuParentId = value;
        }
    }

    public int catLevel
    {
        get
        {
            return _catLevel;
        }
        set
        {
            _catLevel = value;
        }
    }

    public bool isExistCategory
    {
        get
        {
            return _isExistCategory;
        }
        set
        {
            _isExistCategory = value;
        }
    }

    public List<CategoryBLL> SelectParentCategory
    {
        get
        {
            return _selectParentCategory;
        }
        set
        {
            _selectParentCategory = value;
        }
    }



    public List<CategoryBLL> GetParentCategoryLevel
    {
        get
        {
            return _getParentCategory;
        }
        set
        {
            _getParentCategory = value;
        }
    }

    public List<CategoryBLL> GetLeftCategoryMenu
    {
        get
        {
            return _getLeftCategoryMenu;
        }
        set
        {
            _getLeftCategoryMenu = value;
        }
    }



    public int BLLInsertCategory(CategoryBLL ct)
    {
        return status = categoryDALObj.DALInsertCategory(ct);
    }


    public int BLLUpdateCategory(CategoryBLL ct)
    {
        return status = categoryDALObj.DALUpdateCategory(ct);
    }

    public DataTable BLLGetAllCategory()
    {
        DataTable dtCategoryShowAll = categoryDALObj.DALGetAllCategory();
        return dtCategoryShowAll;
    }

    public DataTable BLLGetSelectedCategory(CategoryBLL ct)
    {
        DataTable dtCategoryGetSelected = categoryDALObj.DALGetSelectedCategory(ct);
        return dtCategoryGetSelected;
    }

    public int BLLGetSelectedCategoryLevel(CategoryBLL ct)
    {
        int catLevel;
        catLevel = categoryDALObj.DALGetSelectedCategoryLevel(ct);
        return catLevel;
    }

    public List<CategoryBLL> BLLGetLeftCategoryMenu(int i, int j)
    {
        return categoryDALObj.DALGetLeftCategoryMenu(i, j);
    }

    public string BLLGetMenuParent(string id)
    {
        string parentId = id;
        string defaultId = "-1";
        if (parentId != null && parentId != "")
        {
            defaultId = defaultId + "," + parentId;

            while (parentId != "-1")
            {
                parentId = categoryDALObj.DALGetMenuParent(parentId);
                defaultId = defaultId + "," + parentId;
            }
        }

        return defaultId;
    }

    public DataTable BLLGetCategoryWOParent()
    {
        DataTable dtCategoryWOParent = categoryDALObj.DALGetAllCategoryWOParent();
        return dtCategoryWOParent;
    }

    public DataTable BLLGetCategoryForItem()
    {
        DataTable dtCategoryForItem = categoryDALObj.DALGetAllCategoryParentForItem();
        return dtCategoryForItem;
    }
}

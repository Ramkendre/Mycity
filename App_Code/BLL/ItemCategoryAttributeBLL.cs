using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemCategoryAttributeBLL
/// </summary>
public class ItemCategoryAttributeBLL
{
    ItemCategoryAttributeDAL icaDALObj = new ItemCategoryAttributeDAL();
    public ItemCategoryAttributeBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int _icaId;
    private string _itemIdICA;
    private int _categoryIdICA;
    private int _attributeIdICA;
    private string _attributeValueICA;


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

    public string itemIdICA
    {
        get
        {
            return _itemIdICA;
        }
        set
        {
            _itemIdICA = value;
        }
    }

    public int categoryIdICA
    {
        get
        {
            return _categoryIdICA;
        }
        set
        {
            _categoryIdICA = value;
        }
    }

    public int attributeIdICA
    {
        get
        {
            return _attributeIdICA;

        }
        set
        {
            _attributeIdICA = value;
        }
    }

    public string attributeValueICA
    {
        get
        {
            return _attributeValueICA;
        }
        set
        {
            _attributeValueICA = value;
        }
    }



    public int BLLInsertItemCategoryAttribute(ItemCategoryAttributeBLL ica)
    {
        int i = icaDALObj.DALInsertItemCategoryAttribute(ica);
        return i;
    }

    public int BLLInsertItemCategoryAttributeFirst(ItemCategoryBLL ic)
    {
        int i = icaDALObj.DALInsertItemCategoryAttributeFirst(ic);
        return i;
    }

    public bool BLLIsExistItemCategoryAttribute(ItemCategoryAttributeBLL ica)
    {
        int i;
        bool flag = false;
        string aValue = "";

        aValue = icaDALObj.DALIsExistItemCategoryAttribute(ica);



        if (ica.icaId != 0)
        {
            i = icaDALObj.DALUpdateItemCategoryAttribute(ica);
            if (i == 0)
            {
                flag = true;
            }
        }
        else
        {

            icaDALObj.DALInsertItemCategoryAttribute(ica);

            flag = false;
        }
        return flag;
    }



}

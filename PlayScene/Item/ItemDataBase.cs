using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{ 
    [SerializeField]
    private List<Item> mItemList = new List<Item>();

    [SerializeField]
    private Item[] mItemArray;

    private Item mItem;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {   
    }

    //アイテムリストを返すアクセッサ
    public List<Item> GetItemList()
    {
        return mItemList;
    }

    public Item GetItem()
    {
        return mItem;
    }

    public Item[] GetItemArray()
    {
        return mItemArray;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    //アイテムデータベースを触るための変数
    [SerializeField]
    private ItemDataBase mItemDataBase;

    //アイテムの数を管理するリスト
    private Dictionary<Item, int> mItemNum = new Dictionary<Item, int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //名前でアイテムを取得する為のアクセッサ
    public Item GetItem(string searchName)
    {
        //ラムダ式でアイテムの名前を検索し、returnする
        return mItemDataBase.GetItemList().Find(itemName => itemName.GetItemName() == searchName);
    }
}

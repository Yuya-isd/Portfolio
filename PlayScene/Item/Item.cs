using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class Item : ScriptableObject
{
    //アイテムの種類
    public enum ITEM_KINDS
    {
        //～マス進める系のアイテム
        ONE_FORWARD,
        TWO_FORWARD,
        THREE_FORWARD,
        FOUR_FORWARD,
        FIVE_FOWARD,
        SIX_FORWARD,

        //お金に倍率を掛けるアイテム
        DIAMETERMONEY,
        ALL,
    }

    //アイテムの種類
    [SerializeField]
    private ITEM_KINDS itemKinds;

    //アイテムのアイコンスプライト
    [SerializeField]
    private Sprite icon;

    //アイテムの名前
    [SerializeField]
    private string itemName;

    //アイテムの情報
    [SerializeField]
    private string info;

    //アイテムを買う時の金額
    [SerializeField]
    private int money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ITEM_KINDS GetItemKind()
    {
        return itemKinds;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemInfo()
    {
        return info;
    }

    public int GetItemMoney()
    {
        return money;
    }
}

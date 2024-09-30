using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static ImageExt;

public static class ImageExt
{
    //アイテムの数が0の時、イメージの透明度を変える関数
    //alphaの値が1.0で完全に不透明になる
    public static Image SetOpacity(this Image image, float alpha)
    {
        Color color = image.color;
        image.color = new Color(color.r, color.g, color.b, alpha);
        return image;
    }

    //アイテムの数が0の時、イメージの透明度を代入するアクセッサ
    //alphaの値が1.0で完全に不透明になる
    public static Color GetOpacity(Color image, float alpha)
    {
        image = new Color(image.r, image.g, image.b, alpha);
        return image;
    }
}

public class ItemUI : MonoBehaviour
{
    //アイテムデータベースを触る為の変数
    [SerializeField]
    private ItemDataBase mItemDataBase;

    //所持しているアイテムの数を取得する為に必要な変数
    [SerializeField]
    private Player mPlayer;

    //アイテムのUIのイメージを触るための変数
    [SerializeField]
    private List<Image> mItemImage = new List<Image>();

    //アイテムUIのテキストを触るための変数
    [SerializeField]
    private List<Text> mUIText = new List<Text>();

    //アイテムの数を保持する変数
    [SerializeField]
    private static Dictionary<Item.ITEM_KINDS, int> mItemNum = new Dictionary<Item.ITEM_KINDS, int>()
    {
        {Item.ITEM_KINDS.ONE_FORWARD,0},
        {Item.ITEM_KINDS.TWO_FORWARD,0},
        {Item.ITEM_KINDS.THREE_FORWARD,0},
        {Item.ITEM_KINDS.FOUR_FORWARD,0},
        {Item.ITEM_KINDS.FIVE_FOWARD,0},
        {Item.ITEM_KINDS.SIX_FORWARD,0},
        {Item.ITEM_KINDS.DIAMETERMONEY,0},
        {Item.ITEM_KINDS.ALL,0}
    };

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] imageObj = GameObject.FindGameObjectsWithTag("ItemUI");
        GameObject[] textObj = GameObject.FindGameObjectsWithTag("UItext");

        for (int i = 0; i < imageObj.Length; i++)
        {
            mItemImage.Add(imageObj[i].GetComponent<Image>());
        }

        foreach (GameObject obj in textObj)
        {
            mUIText.Add(obj.GetComponent<Text>());
        }

        //UIの画像をアイテムデータベースに保存してあるアイコンから引き出す
        for (int i = 0; i < mItemImage.Count; i++)
        {
            for (int j = 0; j < mItemDataBase.GetItemList().Count; j++)
            {
                mItemImage[j].sprite = mItemDataBase.GetItemList()[j].GetIcon();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mItemNum == null || mItemImage == null || mUIText == null || SceneManager.GetActiveScene().name == "play")
        {
            mPlayer = GameObject.Find("Player").GetComponent<Player>();
            
            //mItemImageがnullの場合
            if(mItemImage == null)
            {
                GameObject[] imageObj = GameObject.FindGameObjectsWithTag("ItemUI");

                for (int i = 0; i < imageObj.Length; i++)
                {
                    mItemImage.Add(imageObj[i].GetComponent<Image>());
                }
            }

            //UIの画像をアイテムデータベースに保存してあるアイコンから引き出す
            for (int i = 0; i < mItemImage.Count; i++)
            {
                for (int j = 0; j < mItemDataBase.GetItemList().Count; j++)
                {
                    mItemImage[j].sprite = mItemDataBase.GetItemList()[j].GetIcon();
                }
            }

            //mUItextがnullの場合
            if (mUIText == null)
            {
                GameObject[] textObj = GameObject.FindGameObjectsWithTag("UItext");

                foreach (GameObject obj in textObj)
                {
                    mUIText.Add(obj.GetComponent<Text>());
                }
            }
        }

        //アイテムの数を入手
        for (Item.ITEM_KINDS i = 0; i < Item.ITEM_KINDS.ALL; i++)
        {
            //if (mItemNum.Count >= (int)Item.ITEM_KINDS.ALL) mItemNum.Add(i, mPlayer.GetItemNum(i));
            mItemNum[i] = mPlayer.GetItemNum(i);
        }

        foreach (KeyValuePair<Item.ITEM_KINDS, int> item in mItemNum)
        {
            //IndexOverのエラーが出ない為の例外処理
            if (item.Key >= Item.ITEM_KINDS.ALL) return;

            //現在のItemのKeyとValueを確認するテストログ
            //Debug.Log("Key:" + item.Key + "  Value:" + item.Value);

            if (item.Value <= 0)
            {
                mItemImage[(int)item.Key].SetOpacity(0.5f);
                //mItemImage[i].color = GetOpacity(mItemImage[i].color, 0.5f);
            }

            else
            {
                mItemImage[(int)item.Key].SetOpacity(1.0f);
                //mItemImage[i].color = GetOpacity(mItemImage[i].color, 1.0f);
            }

            //アイテムの個数を表示
            mUIText[(int)item.Key].text = item.Value.ToString();
        }
    }

    public Item GetItem(string searchName)
    {
        //ラムダ式でアイテムの名前を検索し、returnする
        return mItemDataBase.GetItemList().Find(itemName => itemName.GetItemName() == searchName);
    }
}

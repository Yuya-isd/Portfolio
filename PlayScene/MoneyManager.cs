using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{
    //プレイヤー達の情報を保持しておくためのリスト
    private List<Player> mPlayerList = new List<Player>();

    //プレイヤー達のお金の情報を取得するための配列
    private int[] mPlayerMoneys;

    //プレイヤー達のお金の情報を取得するリスト（ソートに使用
    private List<int> mPlayerMoneysList = new List<int>();

    //お金を表示するテキストオブジェクト
    [SerializeField]
    private GameObject mMoneyTextObj;

    //お金を表示するためのテキスト
    [SerializeField]
    private Text mMoneyText;

    // Start is called before the first frame update
    void Start()
    {
        //リストにプレイヤー情報を格納
        GameObject[] playerObj = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject obj in playerObj)
        {
            mPlayerList.Add(obj.GetComponent<Player>());
        }

        mMoneyTextObj = GameObject.Find("MoneyText");

        //mPlayerListの要素の数だけ配列の要素数を作成
        mPlayerMoneys = new int[mPlayerList.Count];
        
        //mMoneyTextにテキストの情報をアタッチ
        mMoneyText = mMoneyTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //mMoneyTextにテキストの情報をアタッチ(シーンが遷移した際にNullを吐かないようにする為)
        if (!mMoneyTextObj && SceneManager.GetActiveScene().name == "play")
        {
            mMoneyTextObj = GameObject.Find("MoneyText");
            mMoneyText = mMoneyTextObj.GetComponent<Text>();
        }

        //プレイヤーから現在の所持金の情報を取得する
        for (int i = 0; i < mPlayerList.Count; i++)
        {
            mPlayerMoneys[i] = mPlayerList[i].GetPlayerMoneys();
        }

        //プレイヤーの金額表示
        if (SceneManager.GetActiveScene().name == "play")
        {
            mMoneyText.text = "Playerの所持金" + mPlayerMoneys[0].ToString("N0");
        }

        //プレイヤーどちらかのmMoneyFlagがtrueになった時に関数を呼ぶ
        for (int i = 0; i < mPlayerList.Count; i++)
        {
            if (mPlayerList[i].mMoneyFlag)
            {
                Player1ToPlayer2_Money(1000, mPlayerList[0], mPlayerList[1]);

                return;
            }
        }
    }

    //mPlayerMoneysListの要素を数が大きい順に降順で並べ変える関数
    void ReplacementList()
    {
        //現状のプレイヤーの所持金を全てリストに格納する
        mPlayerMoneysList.AddRange(mPlayerMoneys);

        mPlayerMoneysList.Sort();
        mPlayerMoneysList.Reverse();
    }

    //プレイヤー同士のお金の移動を処理する関数
    //引数：money...移動するお金,player1...お金が増える側のプレイヤー,player2...お金が減る側のプレイヤー
    public void Player1ToPlayer2_Money(int money, Player player1, Player player2)
    {
        //プレイヤー１のお金が増える場合
        if (player1.mMoneyFlag)
        {
            //プレイヤー１のお金を増やす
            player1.SetPlayerMoney(money);

            //プレイヤー２のお金を減らす
            player2.SetPlayerMoney(-money);
        }

        //プレイヤー２のお金が増える場合
        else
        {
            //プレイヤー１のお金を減らす
            player1.SetPlayerMoney(-money);

            //プレイヤー２のお金を増やす
            player2.SetPlayerMoney(money);
        }
    }
}

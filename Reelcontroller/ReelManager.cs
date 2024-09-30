using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelManager : MonoBehaviour
{
    //DiceToPlayスクリプトを触るための変数
    //共通関数
    private int MaxLottery;     //spinボタン用フラグ

    //LotteryCreatorから貰った変数lotteryを保持するリスト
    private List<int> lotteryList = new List<int>();

    static int mLottertNum;
    LotteryCreator mLotteryCreator;

    //リールの役を保持しておく変数
    private static string koyaku = "";


    private int GetKoyaku(int lottery)
    {
        if (lottery >= 0 && lottery <= 299) return 0;
        else if (lottery >= 300 && lottery <= 399) return 1;
        else if (lottery >= 400 && lottery <= 599) return 5;
        else if (lottery >= 600 && lottery <= 749) return 2;
        else if (lottery >= 750 && lottery <= 899) return 6;
        else if (lottery >= 900 && lottery <= 949) return 3;
        else if (lottery >= 950 && lottery <= 999) return 4;
        else return 7;
    }

    //LotteryCreatorで使う、変数lotteryをlotteryListに格納するためのセッター
    public void SetLottery(int lottery)
    {
        lotteryList.Add(lottery);
    }

    //リストの内部を参照し役を判別する関数
    private void ReferenceLotteryList()
    {
        foreach (int i in lotteryList)
        {
            
        }
    }

    public int ransu()
    {
        var random = new System.Random();

        MaxLottery = 1000;

        //0～999まで(MaxLottery個)の判定をリターン
        return random.Next(MaxLottery);
    }

    // Start is called before the first frame update
    void Start()
    {
        mLotteryCreator = GameObject.Find("CenterReel1").GetComponent<LotteryCreator>();
        mLottertNum = mLotteryCreator.GetKoyakuLottery();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static int GetKoyakuLottery()
    {
        return mLottertNum;
    }
}

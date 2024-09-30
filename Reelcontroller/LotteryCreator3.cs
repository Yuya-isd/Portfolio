using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotteryCreator3 : MonoBehaviour
{

    //共通関数
    int lottery;
    private int MaxLottery;     //spinボタン用フラグ

    ReelManager Reelmanager = new ReelManager();

    //小役位置返却メソッド
    public float LotteryKoyakuPoint()
    {

        //抽選
        lottery = Reelmanager.ransu();

        //抽選結果から小役を選択
        int koyaku = GetKoyaku(lottery);

        //小役からwin判定の処理


        //Debug.Log(koyaku);

        //抽選結果をもとに小役判定、位置をreturn
        return KoyakuPoint(koyaku);



    }

    public int Lotterykoyaku()
    {

        lottery = Reelmanager.ransu();

        int lotterykoyaku = GetKoyaku(lottery);

        return lotterykoyaku;
    }

    //抽選処理
    //private int Lottery()
    //{
    //    var random = new System.Random();

    //    MaxLottery = 1000;

    //    //0～999まで(MaxLottery個)の判定をリターン
    //    return random.Next(MaxLottery);
    //}
    //抽選結果から小役の振り分け
    //それぞれの小役に対応する番号と抽選悔過の範囲
    //  <summary>
    //  0リプ　    0～499
    //  1,5ベル　    500～599,600～699
    //　2チェリー  700～799
    //　6スイカ    800～919
    //  3バー      920～969
    //  4赤7       970～999

    private int GetKoyaku(int lottery)
    {
         if (lottery >= 0 && lottery <= 299)         return 0;
         else if (lottery >= 300 && lottery <= 399) return 1;
         else if (lottery >= 400 && lottery <= 599) return 5;
         else if (lottery >= 600 && lottery <= 749) return 2;
         else if (lottery >= 750 && lottery <= 899) return 6;
         else if (lottery >= 900 && lottery <= 949) return 3;
        else if (lottery >= 950 && lottery <= 999) return 4;
        else return 7;
    }

    //抽選結果をもとに小役判定をして小役位置を返すメソッド
    //
    //  0　リプ        -7.0f
    //  1　ベル        3.0f
    //  2  チェリー    6.0f
    //  3  バー        8.5f
    //  4  赤七        -3.0f
    //  5　ベル        -4.0f
    //  6　スイカ      0.0f


    private float KoyakuPoint(int koyaku)
    {
        //リールの返却位置
        switch (koyaku)
        {
            case 0: return 3.0f;
            case 1: return 0.0f;
            case 2: return -6.2f;
            case 3: return -4.5f;
            case 4: return -2.0f;
            case 5: return 4.5f;
            case 6: return 7.9f;
            default: return 0;

        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Reelmanager.SetLottery(lottery);
    }
}

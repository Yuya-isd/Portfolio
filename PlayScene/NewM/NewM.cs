using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewM : MonoBehaviour
{
    //定数
    //ベット出来る最大額
    [SerializeField]
    private int MAX_BET = 1000000;

    //ベット出来る最少額
    [SerializeField]
    private int MIN_BET = 10000;

    //カジノのオブジェクト
    private GameObject mNewMPanel;

    //プレイヤー側が操作するベットの金額
    private int mPlayerBet = 10000;

    //プレイヤーの情報を触るための変数
    private Player mPlayer;

    //ベット額を表示するテキストを触る為の寝数
    private Text mBetText;

    //レバーの重複判定を取らないようにするフラグ
    bool flag = false;

    //ベットがこれ以上できないと表示するためのイメージ
    private GameObject mNotBetObj;
    

    // Start is called before the first frame update
    void Start()
    {
        //カジノのパネルオブジェクトを検知
        mNewMPanel = GameObject.Find("NewMPanel");

        //ベット出来ない際に表示するオブジェクト
        mNotBetObj = GameObject.Find("NotBet");

        //テキストオブジェクトをアタッチ
        mBetText = GameObject.Find("betText").GetComponent<Text>();

        //ベット出来ないオブジェクト
        mNotBetObj.SetActive(true);

        //パネルのアクティブを切る
        mNewMPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ベット金額を変える処理
        //ベットの最小金額は10,000で固定
        //コントローラーのR1を押したら処理を通す
        if (Input.GetKeyUp(KeyCode.JoystickButton7) && mNewMPanel.activeSelf)
        {
            //ベット額が1,000,000になったらベット出来ないようにする
            if (mPlayerBet >= MAX_BET) return;

            //ベット額を増やす
            mPlayerBet += 10000;
        }

        //コントローラーのL1を押したら処理を通す
        if (Input.GetKeyUp(KeyCode.JoystickButton6) && mNewMPanel.activeSelf)
        {
            //ベット額が最少額の10000を下回りそうならベット出来ないようにする
            if (mPlayerBet <= MIN_BET) return;

            //ベット額を減らす
            mPlayerBet -= 10000;
        }

        //一気にMaxベットまで引き上げる処理
        if (Input.GetKeyUp(KeyCode.JoystickButton5))
        {
            mPlayerBet = MAX_BET;
        }

        //テキストに現在のベットを表示
        mBetText.text = mPlayerBet.ToString("N0");

        //上限又は下限のベット額の際にUIを表示
        if (mPlayerBet >= MAX_BET || mPlayerBet <= MIN_BET)
        {
            mNotBetObj.SetActive(true);
        }

        else
        {
            mNotBetObj.SetActive(false);
        }

        //コントローラーのレバーを使用する為の変数
        float leverVertical = Input.GetAxis("Vertical");

        //レバーを倒したら現在のベット額を決定する
        if (leverVertical < 0 && !flag && mNewMPanel.activeSelf)
        {
            DecisionBet(mPlayerBet);
            flag = true;
        }

        if (flag)
        {
            mNewMPanel.SetActive(false);
            flag = false;
        }

        //キャンセルボタンの処理
        if (Input.GetKeyUp(KeyCode.JoystickButton4))
        {
            mNewMPanel.SetActive(false);
            flag = false;
        }
    }

    public void DecisionBet(int bet)
    {
        //プレイヤーがNULLの場合例外処理を回して検知する
        if (!mPlayer) mPlayer = GameObject.Find("Player").GetComponent<Player>();

        //コントローラーのレバーを使用する為の変数
        float leverVertical = Input.GetAxis("Vertical");

        //レバーを倒したら現在のベット額を決定する
        if (leverVertical < 0 && !flag)
        {
            //プレイヤーに返す金額を決める
            switch (BetRandom() % 10)
            {
                //負け
                case 1:
                    mPlayer.SetPlayerMoney(bet * (int)-1.5);
                    Debug.Log("負け");
                    break;

                //大負け
                case 2:
                    mPlayer.SetPlayerMoney(bet * -2);
                    Debug.Log("大負け");
                    break;

                //弱勝ち
                case 3:
                    mPlayer.SetPlayerMoney(bet * (int)1.2);
                    Debug.Log("弱勝ち");
                    break;

                //勝ち
                case 4:
                    mPlayer.SetPlayerMoney(bet * (int)1.5);
                    Debug.Log("勝ち");
                    break;

                //大勝ち
                case 5:
                    mPlayer.SetPlayerMoney(bet * 2);
                    Debug.Log("大勝ち");
                    break;

                //シケ
                default:
                    mPlayer.SetPlayerMoney(bet * (int)-1.2);
                    Debug.Log("シケ");
                    break;
            }
        }
    }

    public int BetRandom()
    {
        return Random.Range(1, 50);
    }
}

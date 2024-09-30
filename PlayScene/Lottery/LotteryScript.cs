using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotteryScript : MonoBehaviour
{
    //LotteryPanelのオブジェクト
    [SerializeField]
    private GameObject mLotteryPanel;

    //セレクトイメージ
    private Image mSelect;

    //YesとNoのイメージリスト
    private List<Image> mImageList = new List<Image>();

    //どちらを選んでいるかのIndex情報を保持しておくための変数
    private int mSelectIndex;

    //プレイヤーの情報を触るための変数
    private Player mPlayer;

    //レバーの重複判定を取らないようにするフラグ
    bool flag = false;

    //宝くじを使った際にプレイヤーに渡す金額
    private int money = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //ヒエラルキーにあるLotteryImageタグが付いているImageオブジェクトを取得する
        GameObject[] imageObj = GameObject.FindGameObjectsWithTag("LotteryImage");

        foreach (GameObject obj in imageObj)
        {
            mImageList.Add(obj.GetComponent<Image>());
        }

        //セレクトイメージを取得
        mSelect = GameObject.Find("LotterySelect").GetComponent<Image>();

        //セレクトの位置をYes側に寄せる
        mSelect.transform.position = mImageList[0].transform.position;

        //LotteyPanelを検知
        mLotteryPanel = GameObject.Find("LotteryPanel");
        mLotteryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //コントローラーのR1を押したら処理を通す(Lotteryパネルがアクティブの状態なら)
        if (Input.GetKeyUp(KeyCode.JoystickButton7) && mLotteryPanel.activeSelf)
        {
            if (mImageList[mSelectIndex].name == "NoImage")
            {
                mSelectIndex = 0;
            }

            mSelectIndex += 1;
            mSelect.transform.position = mImageList[mSelectIndex].transform.position;
        }

        //コントローラーのL1を押したら処理を通す(Lotteryパネルがアクティブの状態なら)
        if (Input.GetKeyUp(KeyCode.JoystickButton6) && mLotteryPanel.activeSelf)
        {
            if (mImageList[mSelectIndex].name == "YesImage")
            {
                mSelectIndex = 1;
            }

            mSelectIndex -= 1;
            mSelect.transform.position = mImageList[mSelectIndex].transform.position;
        }

        float leverVertical = Input.GetAxis("Vertical");

        //レバーを倒したら処理を通す
        if (leverVertical < 0 && mLotteryPanel.activeSelf)
        {
            UseLottery();
        }

    }

    public void UseLottery()
    {
        if (!mPlayer) mPlayer = GameObject.Find("Player").GetComponent<Player>();

        int index = 0;

        //コントローラーのレバーを使用するための変数
        float leverVertical = Input.GetAxis("Vertical");

        //現在選択しているインデックス情報をローカル変数indexに渡す
        index = mSelectIndex;

        //宝くじのパネルがONの時レバーを倒したら、処理を通す
        if (leverVertical < 0 && mLotteryPanel.activeSelf)
        {
            //セレクトしてるイメージの名前がYesの場合
            if (mImageList[index].name == "YesImage")
            {
                //プレイヤーの所持金から50万引く
                mPlayer.SetUsePlayerMoney(500000);

                //入手できるお金の額を決定
                money = LotteryMoneys();

                //プレイヤーに金額を渡す
                mPlayer.SetPlayerMoney(money);

                //処理を通したらLotteryPanelアクティブを切る
                mLotteryPanel.SetActive(false);
            }

            //それ以外の場合
            else
            {
                //パネルを非アクティブ化する
                mLotteryPanel.SetActive(false);
            }
        }
    }

    //外部から宝くじパネルのアクティブをいじる時に使う関数
    public void LotteryActive()
    {
        mLotteryPanel.SetActive(true);
    }

    //宝くじでお金を入手する額を決める関数
    int LotteryMoneys()
    {
        int num = 0;

        switch (LotteryRandom() % 10)
        {
            case 1:
                num += 600000;
                break;

            case 2:
                num += 700000;
                break;

            case 3:
                num += 800000;
                break;

            case 4:
                num += 900000;
                break;

            case 5:
                num += 1000000;
                break;

            //それ以外の場合
            default:
                num += 500000;
                break;
        }

        return num;
    }

    //入手できる金額を決める時に使うランダム関数
    private int LotteryRandom()
    {
        //整数1～50を返す
        return Random.Range(1, 50);
    }
}

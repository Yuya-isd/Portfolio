using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reelcontoroller : MonoBehaviour
{
    //共通変数
    private bool SpinButtonFlg;     //spinボタン用フラグ
    public bool StopButtonFlg;     //stopボタン用フラグ

    private float TargetPointA;     //停止位置A
    private float TargetPointB;     //停止位置B
    int cnt;
    int lotterykoyaku;

    private float ShiftPoint;       //ずれ修正

    LotteryCreator Lottery = new LotteryCreator();

    
    // Start is called before the first frame update
    void Start()
    {
        SpinButtonFlg = false;
        StopButtonFlg = false;
        TargetPointA = 0.0f;
        TargetPointB = 0.0f;
        lotterykoyaku = 0;
        cnt = 300;
    }

    // Update is called once per frame
    void Update()
    {
        if (StopButtonFlg == true&&(transform.position.y) <= TargetPointA && transform.position.y > TargetPointB) 
        {
            SpinButtonFlg = false;
            StopButtonFlg = false;

            //(transform.position.y) <= TargetPointA && transform.position.y > TargetPointB
           

            //------------------------------------------------
            //本来はwin枚数反映処理、今回は何の役がそろったか
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        }

        //spinボタンが押されたら
        if (SpinButtonFlg == true)
        {
            //リールの回転処理
            transform.Translate(0, -0.6425f, 0);

            //リール位置が一定位置を超えたら先頭に戻る
            if (transform.position.y < -12.25f + ShiftPoint)
            {
                transform.position = new Vector3(0, 11.2f + ShiftPoint, 0);
            }
        }
        
        PlaySlot();
    }


    //　スロットのボタンを押したときの処理
    void PlaySlot()
    {
        //ずれ修正
        ShiftPoint = Sortkoyakupoint();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        cnt++;

        //spinボタン
        if (0 > v)
        {
            if (cnt > 300)
            {
                cnt = 0;
                //リール停止位置AとBの取得
                TargetPointA = Lottery.LotteryKoyakuPoint();
                TargetPointB = TargetPointA - 0.6425f;

                SpinButtonFlg = true;

                lotterykoyaku = Lottery.Lotterykoyaku();
            }
        }

        //stopボタン
        if (Input.GetKey(KeyCode.JoystickButton2) || Input.GetKey(KeyCode.W) && SpinButtonFlg == true) 
        {
            StopButtonFlg = true;
        }
    }

    private float Sortkoyakupoint()
    {
        lotterykoyaku = Lottery.Lotterykoyaku();
        switch (lotterykoyaku)
        {
            case 0: return 0.4f;
            case 1: return 0.35f;
            case 2: return -0.5f;
            case 3: return -0.2f;
            case 4: return 0.0f;
            case 5: return -0.5f;
            case 6: return 0.0f;
        }

        return 0.0f;
    }
}

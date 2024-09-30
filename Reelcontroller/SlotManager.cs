using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotManager : MonoBehaviour
{
    Player mPlayer;
    private LotteryCreator m_lottery;
    bool DiameterMoneyFlag = false;
    bool SceneFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mPlayer) mPlayer = GameObject.Find("Player").GetComponent<Player>();
        if (!m_lottery) m_lottery = GameObject.Find("CenterReel1").GetComponent<LotteryCreator>();

        //お金に倍率を掛けるアイテムを使っているかどうかのフラグを貰ってくる
        DiameterMoneyFlag = GameObject.Find("Player").GetComponent<Player>().DiameterMoneyFlag;

        if (!SceneFlag)
        {
            //スロットマスに止まった際にプレイヤーのお金派増やす為にLotteryCreatorからセッターを呼ぶ
            //お金の入手額を3倍に増やすアイテムが使用されている場合
            if (DiameterMoneyFlag)
            {
                mPlayer.SetPlayerMoney(m_lottery.GetLotteryMoney() * 3);
                SceneFlag = true;
            }

            //アイテムを使用していない場合
            else
            {
                mPlayer.SetPlayerMoney(m_lottery.GetLotteryMoney());
                SceneFlag = true;
            }
        }

        if (SceneManager.GetActiveScene().name != "testscene")
        {
            SceneFlag = false;
        }
    }
}

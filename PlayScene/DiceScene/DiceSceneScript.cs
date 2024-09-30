using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSceneScript : MonoBehaviour
{
    //シングルトン用の変数
    private static DiceSceneScript mDiceSceneManager;

    public static DiceSceneScript Instance()
    {
        return mDiceSceneManager;
    }

    //プレイヤーを検知する為の変数
    private GameObject mPlayer;

    //シーンを遷移しているかどうかのフラグ
    private bool mSceneFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーのオブジェクトを検知
        mPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //ダイスシーンの間はプレイヤーのオブジェクトをオフにする
        if (!mSceneFlag) mPlayer.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayToSlot : MonoBehaviour
{
    //マスの名前の情報を保存しておく変数
    private string mMasname;

    //プレイヤーが振れていたマスの名前情報を一時的に保存しておく変数
    private string mMass;

    //ダイスのデータ
    private int dice;

    //重複してシーン遷移をしないようにする
    bool flag = false; 

    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dice == 0) dice = GameObject.Find("Player").GetComponent<Player>().GetDicePlayer();

        if (dice > 0) flag = true;
    }

    public void PlayToSlotChangeScene()
    {
        if (flag || Input.GetKey(KeyCode.F))
        {
            flag = false;
            SceneManager.LoadScene("testscene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dicepoint : MonoBehaviour
{
    public static int DicePoint;
    GameObject Dice;
    private bool DiceDestroy;

    //DiceToPlayスクリプトを触るための変数
    DicetoPlay mDiceToPlay;

    private static Dicepoint mDicePointInstance;

    public static Dicepoint Instance()
    {
        return mDicePointInstance;
    }

    void Awake()
    {
        if (mDicePointInstance != null)
        {
            return;
        }

        mDicePointInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        DicePoint = 0;

        Dice = GameObject.Find("NomalDice");
        Dice.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Dice != null)
        {
            DicePoint = Dice.GetComponent<DiceScript>().GetDice();
        }

        if (DicePoint >= 1)
        {
            if (Dice == null) return;

            //ダイスの目を渡したらダイスを非アクティブ化
            Dice.SetActive(false);

            //ダイスのオブジェクトが非アクティブ化したらシーン遷移を通す
            if (Dice.activeSelf != true)
            {
                mDiceToPlay = GameObject.Find("DiceManager").GetComponent<DicetoPlay>();
                mDiceToPlay.ChangeScene();
            }
        }

    }

    public static int DicePointGet()
    {
        return DicePoint;
    }
}

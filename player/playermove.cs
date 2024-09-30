using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class playermove : MonoBehaviour
{
    //ダイスのデータにアクセスするための変数
    Dicepoint DiceMan;
    private int DiceNum;
    int statenum;
    List<GameObject> Dice = new List<GameObject>();

    // Start is called before the first frame update
    int cnt;

    void Start()
    {
        cnt = 0;
        statenum = 0;
        Dice.AddRange(GameObject.FindGameObjectsWithTag("DontDestroy"));
    }

    // Update is called once per frame
    void Update()
    {
        
        { 
            cnt++;
            if (cnt > 12)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position += new Vector3(-1.1f, 0, 0);
                    cnt = 0;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position += new Vector3(1.1f, 0, 0);
                    cnt = 0;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.position += new Vector3(0, 0, 1.1f);
                    cnt = 0;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.position += new Vector3(0, 0, -1.1f);
                    cnt = 0;
                }


                //if(サイコロの値が０)
                //{
                //    statenum=5;
                //}
            }

        }

        //foreach (GameObject obj in Dice)
        //{
        //    DiceNum = obj.GetComponent<Dicepoint>().DicePointGet();
        //    Debug.Log(DiceNum);
        //}

    }

    public int StateChengeM()
    {
        return statenum;
    }

    
}


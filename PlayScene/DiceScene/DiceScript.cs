using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiceScript : MonoBehaviour
{
    //サウンド
    [SerializeField]
    private SouadAll soundAll;
  
    //一回しかスペースを押せない
    private bool SpaceFlag;

    //定数
    private int MAX_DICESPEED = 1000;
    private int MIN_DICESPEED = -1000;

    private Rigidbody rb;

    Quaternion rot;

    [SerializeField]
    private Transform[] diceSpots;

    private int dice;

    //ダイスの回る速度を保持する関数
    [SerializeField]
    private Vector3 m_diceSpeed;

    //回転中のフラグ
    bool isRotate = false;

    //ダイスシーンに使える時間の変数(20秒)
    float diceTimer;

    // Start is called before the first frame update
    void Start()
    {
        SpaceFlag = false;

        gameObject.SetActive(true);

        diceTimer = 0.0f;

        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;

        //ダイスの回転速度・方向をランダムで決定
        m_diceSpeed.x = Random.Range(MIN_DICESPEED, MAX_DICESPEED);
        m_diceSpeed.y = Random.Range(MIN_DICESPEED, MAX_DICESPEED);
        m_diceSpeed.z = Random.Range(MIN_DICESPEED, MAX_DICESPEED);
        
        //ダイスに回転を掛ける
        rb.angularVelocity = new Vector3(m_diceSpeed.x, m_diceSpeed.y, m_diceSpeed.z);
    }

    // Update is called once per frame
    void Update()
    {
        //回転中は入力を受け付けない
        if (isRotate) return;

        float leverVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) || leverVertical < 0 &&SpaceFlag==false)
        {   
            SpaceFlag = true;
            rb.useGravity = true;
            rb.velocity = Vector3.left;
        }

        diceTimer += Time.deltaTime;

        CheckSpot();
    }

    //ダイスの上の値を取得する関数
    public int GetDice()
    {
        return dice;
    }

    //地面に着いたら回転速度に減算を掛ける
    private void CheckSpot()
    {
        if (!rb.IsSleeping())   return;

        int topIndex = 0;
        float topValue = diceSpots[0].transform.position.y;

        for (int i = 1; i < diceSpots.Length; ++i)
        {
            if (diceSpots[i].transform.position.y < topValue)
                continue;

            topValue = diceSpots[i].transform.position.y;
            topIndex = i;
        }

        dice = topIndex + 1;
    }
}

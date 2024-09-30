using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    private static ScoreManager mScoreManager;

    public static ScoreManager Instance()
    {
        return mScoreManager;
    }

    void Awake()
    {
        if (mScoreManager != null)
        {
            Destroy(gameObject);
            return;
        }

        mScoreManager = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject score_object;

    private int money_num;
    // Start is called before the first frame update
    void Start()
    {
        money_num = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        //Text score_text = score_object.GetComponent<Text>();
        //score_text.text = "獲得金額" + money_num + "万円";
    }
}

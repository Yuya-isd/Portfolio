using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlaytoDice : MonoBehaviour
{

    GameObject mUseItemPanel;
    GameObject mShopPanel;
    GameObject mLotteryPanel;
    GameObject mNewPanel;

    private void Awake()
    {
        if (!mUseItemPanel) mUseItemPanel = GameObject.Find("UseItemPanel");
        if (!mShopPanel) mShopPanel = GameObject.Find("ShopPanel");
        if (!mLotteryPanel) mLotteryPanel = GameObject.Find("LotteryPanel");
        if (!mNewPanel) mNewPanel = GameObject.Find("NewMPanel");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "play")
        {
            if (!mUseItemPanel) mUseItemPanel = GameObject.Find("UseItemPanel");
            if (!mShopPanel) mShopPanel = GameObject.Find("ShopPanel");
            if (!mLotteryPanel) mLotteryPanel = GameObject.Find("LotteryPanel");
            if (!mNewPanel) mNewPanel = GameObject.Find("NewMPanel");

            if (!mUseItemPanel) mUseItemPanel.SetActive(false);
            if (!mShopPanel) mShopPanel.SetActive(false);
            if (!mLotteryPanel) mLotteryPanel.SetActive(false);
            if (!mNewPanel) mNewPanel.SetActive(false);
        }

        if (mUseItemPanel.activeSelf || mShopPanel.activeSelf || mLotteryPanel.activeSelf || mNewPanel.activeSelf) return;

        if (Input.GetKey(KeyCode.X) || Input.GetKeyUp(KeyCode.JoystickButton7))
        {
            Debug.Log("Dice");
            ChangePlayToSceneScene();
        }
    }

    void LateUpdate()
    {
        GameObject obj = GameObject.Find("DontDestroyOnLoad");

        Destroy(obj);
    }

    void ChangePlayToSceneScene()
    {
        SceneManager.LoadScene("DiceScenePlay");
    }
}
